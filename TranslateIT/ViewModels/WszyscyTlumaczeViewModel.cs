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
    public class WszyscyTlumaczeViewModel : AllViewModel<TlumaczeForAllView>
    {
        public WszyscyTlumaczeViewModel() : base("Tlumacze")
        {
        }
        #region Properties
        private TlumaczeForAllView _WybranyTlumacz;
        public TlumaczeForAllView WybranyTlumacz
        {
            get
            {
                return _WybranyTlumacz;
            }
            set
            {
                if (_WybranyTlumacz != value)
                {
                    _WybranyTlumacz = value;
                    Messenger.Default.Send(_WybranyTlumacz);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TlumaczeForAllView>
               (
                   from tlumacz in TranslateITEntities.Tlumacze
                   where tlumacz.CzyAktywne == true
                   select new TlumaczeForAllView
                   {
                       IdTlumacza=tlumacz.IdTlumacza,
                       IdPracownika = tlumacz.IdPracownika,
                       Imie = tlumacz.Pracownik.Imie,
                       Nazwisko = tlumacz.Pracownik.Nazwisko_a,
                       OpisTlumacza = tlumacz.OpisTlumacza
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
                List = new ObservableCollection<TlumaczeForAllView>(List.OrderBy(Item => Item.IdPracownika));
            }
            if (SortField == "Imie")
            {
                List = new ObservableCollection<TlumaczeForAllView>(List.OrderBy(Item => Item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<TlumaczeForAllView>(List.OrderBy(Item => Item.Nazwisko));
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
                List = new ObservableCollection<TlumaczeForAllView>(List.Where(Item => Item.Imie != null && Item.Imie.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<TlumaczeForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
