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
    public class WszystkieFakturyViewModel : AllViewModel<FakturyForAllView>
    {
        #region Constructor      
        public WszystkieFakturyViewModel()
            :base("Faktury")
        {
        }
        #endregion
        #region Properties
        private FakturyForAllView _WybranaFaktura;
        public FakturyForAllView WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }
            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    Messenger.Default.Send(_WybranaFaktura);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturyForAllView>
                (
                    from faktura in TranslateITEntities.Faktura
                    where faktura.CzyAktywna == true
                    select new FakturyForAllView
                    {
                        IdFaktury = faktura.IdFaktury,
                        Numer = faktura.Numer,
                        DataWystawienia=faktura.DataWystawienia,

                        FirmaSkroconaNazwa=faktura.DaneFirmy.SkroconaNazwa,
                        FirmaNIP=faktura.DaneFirmy.NIP,
                        FirmaLogo=faktura.DaneFirmy.Logo,
                        //33-00 Nowy Sacz, Zielona 267/3
                        FirmaAdres=faktura.DaneFirmy.Adres.KodPocztowy+", "+
                         faktura.DaneFirmy.Adres.Miasto+", "+
                         faktura.DaneFirmy.Adres.Ulica+", "+
                         faktura.DaneFirmy.Adres.NumerDomu,

                        ImiePracownika=faktura.Pracownik.Imie,
                        NazwiskaPracownika=faktura.Pracownik.Nazwisko_a,
                        AdresPracownika=faktura.Pracownik.Adres.KodPocztowy+", "+
                         faktura.Pracownik.Adres.Miasto+", "+
                         faktura.Pracownik.Adres.Ulica+", "+
                         faktura.Pracownik.Adres.NumerDomu+"/"+
                         faktura.Pracownik.Adres.NumerMieszkania,

                        TerminPlatnosci=faktura.TerminPlatnosci,

                        SposobPlatnosciNazwa=faktura.SposobPlatnosci.Nazwa
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer", "FirmaSkroconaNazwa", "FirmaNIP", "ImiePracownika", "NazwiskoPracownika", "SposobPlatnosci" };
        }
        public override void Sort()
        {
            if (SortField == "Numer")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.Numer));
            }
            if (SortField == "FirmaSkroconaNazwa")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.FirmaSkroconaNazwa));
            }
            if (SortField == "FirmaNIP")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.FirmaNIP));
            }
            if (SortField == "ImiePracownika")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.ImiePracownika));
            }
            if (SortField == "NazwiskoPracownika")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.NazwiskaPracownika));
            }
            if (SortField == "SposobPlatnosci")
            {
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(Item => Item.SposobPlatnosciNazwa));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer", "FirmaSkroconaNazwa", "FirmaNIP", "ImiePracownika", "NazwiskoPracownika", "SposobPlatnosci" };
        }
        public override void Find()
        {
            if (FindField == "Numer")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.Numer != null && Item.Numer.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaSkroconaNazwa")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.FirmaSkroconaNazwa != null && Item.FirmaSkroconaNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaNIP")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.FirmaNIP != null && Item.FirmaNIP.StartsWith(FindTextBox))); ;
            }
            if (FindField == "ImiePracownika")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.ImiePracownika != null && Item.ImiePracownika.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwiskoPracownika")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.NazwiskaPracownika != null && Item.NazwiskaPracownika.StartsWith(FindTextBox))); ;
            }
            if (FindField == "SposobPlatnosci")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(Item => Item.SposobPlatnosciNazwa != null && Item.SposobPlatnosciNazwa.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
