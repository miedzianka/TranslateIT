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
    public class WszyscyKoordynatorzyViewModel : AllViewModel<KoordynatorzyForAllView>
    {
        public WszyscyKoordynatorzyViewModel() : base("Koordynatorzy")
        {
        }
        #region Properties
        private KoordynatorzyForAllView _WybranyKoordynator;
        public KoordynatorzyForAllView WybranyKoordynator
        {
            get
            {
                return _WybranyKoordynator;
            }
            set
            {
                if (_WybranyKoordynator != value)
                {
                    _WybranyKoordynator = value;
                    Messenger.Default.Send(_WybranyKoordynator);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KoordynatorzyForAllView>
               (
                   from koordynator in TranslateITEntities.Koordynator
                   where koordynator.CzyAktywna == true
                   select new KoordynatorzyForAllView
                   {
                       IdKoordynatora= koordynator.IdKoordynatora,
                       IdPracownika = koordynator.IdPracownika,
                       Imie = koordynator.Pracownik.Imie,
                       Nazwisko = koordynator.Pracownik.Nazwisko_a,
                       Opis = koordynator.Opis
                   }
               );
        }
        #endregion
        #region Sortand Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "IdPracownika", "Imie", "Nazwisko" };
        }
        public override void Sort()
        {
            if(SortField=="IdPracownika")
            {
                List = new ObservableCollection<KoordynatorzyForAllView>(List.OrderBy(Item => Item.IdPracownika));
            }
            if (SortField == "Imie")
            {
                List = new ObservableCollection<KoordynatorzyForAllView>(List.OrderBy(Item => Item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<KoordynatorzyForAllView>(List.OrderBy(Item => Item.Nazwisko));
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
                List = new ObservableCollection<KoordynatorzyForAllView>(List.Where(Item => Item.Imie != null && Item.Imie.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<KoordynatorzyForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
