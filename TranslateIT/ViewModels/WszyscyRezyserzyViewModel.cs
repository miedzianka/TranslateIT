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
    public class WszyscyRezyserzyViewModel : AllViewModel<RezyserzyForAllView>
    {
        public WszyscyRezyserzyViewModel() : base("Rezyserzy")
        {
        }
        #region Properties
        private RezyserzyForAllView _WybranyRezyser;
        public RezyserzyForAllView WybranyRezyser
        {
            get
            {
                return _WybranyRezyser;
            }
            set
            {
                if (_WybranyRezyser != value)
                {
                    _WybranyRezyser = value;
                    Messenger.Default.Send(_WybranyRezyser);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RezyserzyForAllView>
               (
                   from rezyser in TranslateITEntities.Rezyserzy
                   where rezyser.CzyAktywne == true
                   select new RezyserzyForAllView
                   {
                       IdRezysera=rezyser.IdRezysera,
                       IdPracownika = rezyser.IdPracownika,
                       Imie = rezyser.Pracownik.Imie,
                       Nazwisko = rezyser.Pracownik.Nazwisko_a,
                       OpisRezysera = rezyser.OpisRezysera
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
                List = new ObservableCollection<RezyserzyForAllView>(List.OrderBy(Item => Item.IdPracownika));
            }
            if (SortField == "Imie")
            {
                List = new ObservableCollection<RezyserzyForAllView>(List.OrderBy(Item => Item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<RezyserzyForAllView>(List.OrderBy(Item => Item.Nazwisko));
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
                List = new ObservableCollection<RezyserzyForAllView>(List.Where(Item => Item.Imie != null && Item.Imie.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<RezyserzyForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
