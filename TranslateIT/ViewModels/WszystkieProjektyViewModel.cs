using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels
{
    class WszystkieProjektyViewModel : AllViewModel<ProjektyForAllView>
    { 
        public WszystkieProjektyViewModel() : base("Projekty")
        {
        }
        #region Properties
        private ProjektyForAllView _WybranyProjekt;
        public ProjektyForAllView WybranyProjekt
        {
            get
            {
                return _WybranyProjekt;
            }
            set
            {
                if (_WybranyProjekt != value)
                {
                    _WybranyProjekt = value;
                    Messenger.Default.Send(_WybranyProjekt);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ProjektyForAllView>
                (
                    from projekt in TranslateITEntities.Projekt
                    where projekt.CzyAktywne == true
                    select new ProjektyForAllView
                    {
                        IdProjektu=projekt.IdProjektu,
                        FirmaNazwa = projekt.DaneFirmy.NazwaFirmy,
                        FirmaNIP = projekt.DaneFirmy.NIP,
                        DaneKoordynatorDubbing =
                            projekt.Koordynator.Pracownik.Imie + " " +
                            projekt.Koordynator.Pracownik.Nazwisko_a,
                        DaneKoordynatorLektor =
                            projekt.Koordynator1.Pracownik.Imie + " " +
                            projekt.Koordynator1.Pracownik.Nazwisko_a,
                        DaneKoordynatorNapisy =
                            projekt.Koordynator2.Pracownik.Imie + " " +
                            projekt.Koordynator2.Pracownik.Nazwisko_a,
                        DaneTlumaczDubbing =
                            projekt.Tlumacze.Pracownik.Imie + " " +
                            projekt.Tlumacze.Pracownik.Nazwisko_a,
                        DaneTlumaczLektor =
                            projekt.Tlumacze1.Pracownik.Imie + " " +
                            projekt.Tlumacze1.Pracownik.Nazwisko_a,
                        DaneTlumaczNapisy =
                            projekt.Tlumacze2.Pracownik.Imie + " " +
                            projekt.Tlumacze2.Pracownik.Nazwisko_a,
                        EtapProjektu = projekt.EtapyProjektu.EtapProjektu,
                        CzyDubbing = projekt.CzyDubbing,
                        CzyLektor = projekt.CzyLektor,
                        CzyNapisy = projekt.CzyNapisy,
                        Budzet = projekt.Budzet,
                        JezykOryginalny = projekt.Jezyki.Jezyk,
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "IdProjektu", "FirmaNazwa", "FirmaNIP", "DaneKoordynatorDubbing", "DaneKoordynatorLektor",
                "DaneKoordynatorNapisy", "DaneTlumaczDubbing", "DaneTlumaczLektor","DaneTlumaczNapisy", "EtapProjektu","Budzet" };
        }
        public override void Sort()
        {
            if (SortField == "IdProjektu")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.IdProjektu));
            }
            if (SortField == "FirmaNazwa")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.FirmaNazwa));
            }
            if (SortField == "FirmaNIP")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.FirmaNIP));
            }
            if (SortField == "DaneKoordynatorDubbing")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneKoordynatorDubbing));
            }
            if (SortField == "DaneKoordynatorLektor")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneKoordynatorLektor));
            }
            if (SortField == "DaneKoordynatorNapisy")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneKoordynatorNapisy));
            }
            if (SortField == "DaneTlumaczDubbing")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneTlumaczDubbing));
            }
            if (SortField == "DaneTlumaczLektor")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneTlumaczLektor));
            }
            if (SortField == "DaneTlumaczNapisy")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.DaneTlumaczNapisy));
            }
            if (SortField == "EtapProjektu")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.EtapProjektu));
            }
            if (SortField == "Budzet")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(Item => Item.Budzet));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "FirmaNazwa", "FirmaNIP", "DaneKoordynatorDubbing", "DaneKoordynatorLektor",
                "DaneKoordynatorNapisy", "DaneTlumaczDubbing", "DaneTlumaczLektor","DaneTlumaczNapisy", "EtapProjektu" };
        }
        public override void Find()
        {
            if (FindField == "FirmaNazwa")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.FirmaNazwa != null && Item.FirmaNazwa.Contains(FindTextBox)));
            }
            if (FindField == "FirmaNIP")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.FirmaNIP != null && Item.FirmaNIP.Contains(FindTextBox)));
            }            
            if (FindField == "DaneKoordynatorDubbing")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneKoordynatorDubbing != null && Item.DaneKoordynatorDubbing.Contains(FindTextBox)));
            }
            if (FindField == "DaneKoordynatorLektor")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneKoordynatorLektor != null && Item.DaneKoordynatorLektor.Contains(FindTextBox)));
            }
            if (FindField == "DaneKoordynatorNapisy")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneKoordynatorNapisy != null && Item.DaneKoordynatorNapisy.Contains(FindTextBox)));
            }
            if (FindField == "DaneTlumaczDubbing")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneTlumaczDubbing != null && Item.DaneTlumaczDubbing.Contains(FindTextBox)));
            }
            if (FindField == "DaneTlumaczLektor")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneTlumaczLektor != null && Item.DaneTlumaczLektor.Contains(FindTextBox)));
            }
            if (FindField == "DaneTlumaczNapisy")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.DaneTlumaczNapisy != null && Item.DaneTlumaczNapisy.Contains(FindTextBox)));
            }
            if (FindField == "EtapProjektu")
            {
                List = new ObservableCollection<ProjektyForAllView>(List.Where(Item => Item.EtapProjektu != null && Item.EtapProjektu.Contains(FindTextBox)));
            }
        }
        #endregion
    }
}
