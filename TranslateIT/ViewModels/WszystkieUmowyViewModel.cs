using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels
{
    public class WszystkieUmowyViewModel : AllViewModel<UmowyForAllView>
    {
        #region Constructor
        public WszystkieUmowyViewModel() : base("Umowy")
        {
        }
        #endregion
        #region Properties
        private UmowyForAllView _WybranaUmowa;
        public UmowyForAllView WybranaUmowa
        {
            get
            {
                return _WybranaUmowa;
            }
            set
            {
                if (_WybranaUmowa != value)
                {
                    _WybranaUmowa = value;
                    Messenger.Default.Send(_WybranaUmowa);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UmowyForAllView>
                (
                    from umowa in TranslateITEntities.Umowa
                    where umowa.CzyAktywna == true
                    select new UmowyForAllView
                    {
                        IdUmowy= umowa.IdUmowy,
                        Numer = umowa.Numer,
                        RodzajUmowy = umowa.RodzajUmowy.Nazwa,
                        DataWystawienia = umowa.DataWystawienia,

                        ImiePracownika = umowa.Pracownik.Imie,
                        NazwiskaPracownika = umowa.Pracownik.Nazwisko_a,
                        AdresPracownika = umowa.Pracownik.Adres.KodPocztowy + ", " +
                         umowa.Pracownik.Adres.Miasto + ", " +
                         umowa.Pracownik.Adres.Ulica + ", " +
                         umowa.Pracownik.Adres.NumerDomu + "/" +
                         umowa.Pracownik.Adres.NumerMieszkania,
                        
                        FirmaNazwa = umowa.DaneFirmy.NazwaFirmy,
                        FirmaNIP = umowa.DaneFirmy.NIP,
                        FirmaAdres = umowa.DaneFirmy.Adres.KodPocztowy + ", " +
                         umowa.DaneFirmy.Adres.Miasto + ", " +
                         umowa.DaneFirmy.Adres.Ulica + ", " +
                         umowa.DaneFirmy.Adres.NumerDomu,

                        TerminPlatnosci = umowa.TerminPlatnosci,
                        SposobPlatnosciNazwa = umowa.SposobPlatnosci.Nazwa
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer", "RodzajUmowy", "DataWystawienia", "ImiePracownika","NazwiskaPracownika",
                "FirmaNazwa", "FirmaNIP", "SposobPlatnosciNazwa" };
        }
        public override void Sort()
        {
            if (SortField == "Numer")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.Numer));
            }
            if (SortField == "RodzajUmowy")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.RodzajUmowy));
            }
            if (SortField == "DataWystawienia")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.DataWystawienia));
            }
            if (SortField == "ImiePracownika")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.ImiePracownika));
            }
            if (SortField == "NazwiskaPracownika")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.NazwiskaPracownika));
            }
            if (SortField == "FirmaNazwa")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.FirmaNazwa));
            }
            if (SortField == "FirmaNIP")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.FirmaNIP));
            }
            if (SortField == "SposobPlatnosciNazwa")
            {
                List = new ObservableCollection<UmowyForAllView>(List.OrderBy(Item => Item.SposobPlatnosciNazwa));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer", "RodzajUmowy", "DataWystawienia", "ImiePracownika","NazwiskaPracownika",
                "FirmaNazwa", "FirmaNIP", "SposobPlatnosciNazwa" };
        }
        public override void Find()
        {
            if (FindField == "Numer")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.Numer != null && Item.Numer.Contains(FindTextBox)));
            }
            if (FindField == "RodzajUmowy")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.RodzajUmowy != null && Item.RodzajUmowy.Contains(FindTextBox)));
            }            
            if (FindField == "DataWystawienia")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.DataWystawienia != null && Item.DataWystawienia.Equals(FindTextBox)));
            }
            if (FindField == "ImiePracownika")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.ImiePracownika != null && Item.ImiePracownika.Contains(FindTextBox)));
            }
            if (FindField == "NazwiskaPracownika")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.NazwiskaPracownika != null && Item.NazwiskaPracownika.Contains(FindTextBox)));
            }
            if (FindField == "FirmaNazwa")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.FirmaNazwa != null && Item.FirmaNazwa.Equals(FindTextBox)));
            }
            if (FindField == "FirmaNIP")
            {
                List = new ObservableCollection<UmowyForAllView >(List.Where(Item => Item.FirmaNIP != null && Item.FirmaNIP.Equals(FindTextBox)));
            }
            if (FindField == "SposobPlatnosciNazwa")
            {
                List = new ObservableCollection<UmowyForAllView>(List.Where(Item => Item.SposobPlatnosciNazwa != null && Item.SposobPlatnosciNazwa.Contains(FindTextBox)));
            }
        }
        #endregion
    }
}
