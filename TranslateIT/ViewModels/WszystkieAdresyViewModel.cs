using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;

namespace TranslateIT.ViewModels
{
    public class WszystkieAdresyViewModel : AllViewModel<AdresForAllView>
    {
        public WszystkieAdresyViewModel() : base("Adresy") { }
        #region Properties
        private AdresForAllView _WybranyAdres;
        public AdresForAllView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                if (_WybranyAdres != value)
                {
                    _WybranyAdres = value;
                    Messenger.Default.Send(_WybranyAdres);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<AdresForAllView>
                (
                    from adres in TranslateITEntities.Adres
                    where adres.czyAktywne == true
                    select new AdresForAllView
                    {
                        IdAdresu = adres.IdAdresu,
                        KodPocztowy=adres.KodPocztowy,
                        Ulica=adres.Ulica,
                        NumerDomu=adres.NumerDomu,
                        NumerMieszkania=adres.NumerMieszkania,
                        Miasto=adres.Miasto,
                        Poczta=adres.Poczta,
                        NazwaKraju=adres.Kraj.NazwaKraju
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "IdAdresu", "Miasto", "NazwaKraju", "Ulica" };
        }
        public override void Sort()
        {
            if (SortField == "IdAdresu")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.IdAdresu));
            }
            if (SortField == "Miasto")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.Miasto));
            }
            if (SortField == "NazwaKraju")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.NazwaKraju));
            }
            if (SortField == "Ulica")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.Ulica));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Miasto", "NazwaKraju", "Ulica", "KodPocztowy" };
        }
        public override void Find()
        {
            if (FindField == "Miasto")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.Miasto != null && Item.Miasto.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwaKraju")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.NazwaKraju != null && Item.NazwaKraju.StartsWith(FindTextBox)));
            }
            if (FindField == "Ulica")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.Ulica != null && Item.Ulica.StartsWith(FindTextBox))); ;
            }
            if (FindField == "KodPocztowy")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.KodPocztowy != null && Item.KodPocztowy.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
