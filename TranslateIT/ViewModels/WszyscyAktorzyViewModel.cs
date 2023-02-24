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
    public class WszyscyAktorzyViewModel : AllViewModel<AktorzyForAllView>
    {
        public WszyscyAktorzyViewModel() : base("Aktorzy")
        {
        }
        #region Properties
        private AktorzyForAllView _WybranyAktor;
        public AktorzyForAllView WybranyAktor
        {
            get
            {
                return _WybranyAktor;
            }
            set
            {
                if (_WybranyAktor != value)
                {
                    _WybranyAktor = value;
                    Messenger.Default.Send(_WybranyAktor);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<AktorzyForAllView>
               (
                   from aktor in TranslateITEntities.Aktorzy
                   where aktor.CzyAktywne == true
                   select new AktorzyForAllView
                   {
                       IdAktora = aktor.IdAktora,
                       IdPracownika = aktor.IdPracownika,
                       Imie = aktor.Pracownik.Imie,
                       Nazwisko = aktor.Pracownik.Nazwisko_a,
                       OpisAktoraa = aktor.OpisAktora
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
            if (SortField == "Imie")
            {
                List = new ObservableCollection<AktorzyForAllView>(List.OrderBy(Item => Item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<AktorzyForAllView>(List.OrderBy(Item => Item.Nazwisko));
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
                List = new ObservableCollection<AktorzyForAllView>(List.Where(Item => Item.Imie != null && Item.Imie.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<AktorzyForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
