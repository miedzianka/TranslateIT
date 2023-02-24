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
    class WszysycPracownicyViewModel : AllViewModel<PracownikForAllView>
    {
        #region Constructor
        public WszysycPracownicyViewModel() : base("Pracownicy")
        {
        }
        #endregion
        #region Properties
        private PracownikForAllView _WybranyPracownik;
        public PracownikForAllView WybranyPracownik
        {
            get
            {
                return _WybranyPracownik;
            }
            set
            {
                if (_WybranyPracownik != value)
                {
                    _WybranyPracownik = value;
                    Messenger.Default.Send(_WybranyPracownik);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
            (
                from pracownik in TranslateITEntities.Pracownik
                where pracownik.CzyAktywne == true
                select new PracownikForAllView
                {
                    IdPracownika = pracownik.IdPracownika,
                    Imie = pracownik.Imie,
                    Nazwisko = pracownik.Nazwisko_a,
                    DataUrodzenia = pracownik.DataUrodzenia,
                    Pesel = pracownik.Pesel,
                    NrKonta = pracownik.nrKonta,
                    Bank = pracownik.Bank,
                    StatusStudenta = pracownik.StatusStudenta,
                    Email = pracownik.E_mail,
                    NrTelefonu1 = pracownik.NrTelefonu1,
                    UlicaPracownik=pracownik.Adres.Ulica,
                    NrDomuPracownika =pracownik.Adres.NumerDomu,
                    PracownikNrMieszkania = pracownik.Adres.NumerMieszkania,
                    KodPocztowyPracownika=pracownik.Adres.KodPocztowy,
                    MiastoPracownika=pracownik.Adres.Miasto,
                    KrajPracownika=pracownik.Adres.Kraj.NazwaKraju,
                    DataNawiazanieWspolpracy = pracownik.DataNawiazaniaWspolpracy,
                    Firma =
                        pracownik.DaneFirmy.NIP + ", " +
                        pracownik.DaneFirmy.NazwaFirmy,
                }
            );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "IdPracownika", "Imie", "Nazwisko" };
        }
        public override void Sort()
        {
            if (SortField == "IdPracownika")
            {
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(Item => Item.IdPracownika));
            }
            if (SortField == "Imie")
            {
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(Item => Item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(Item => Item.Nazwisko));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Imie", "Nazwisko" };
        }
        public override void Find()
        {
            if (FindField == "Imie")
            {
                List = new ObservableCollection<PracownikForAllView>(List.Where(Item => Item.Imie != null && Item.Imie.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<PracownikForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
