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
    public class WszystkieSezonyViewModel : AllViewModel<SezonyForAllView>
    {
        #region Constructor
        public WszystkieSezonyViewModel() : base("Sezony")
        {
        }
        #endregion
        #region Properties
        private SezonyForAllView _WybranySezon;
        public SezonyForAllView WybranySezon
        {
            get
            {
                return _WybranySezon;
            }
            set
            {
                if (_WybranySezon != value)
                {
                    _WybranySezon = value;
                    Messenger.Default.Send(_WybranySezon);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SezonyForAllView>
                (
                    from sezon in TranslateITEntities.Sezony
                    where sezon.CzyAktywne == true
                    select new SezonyForAllView
                    {
                        IdSezonu = sezon.IdSezonu,
                        NazwaSerialu = sezon.Serial.TytułSerialuTlumaczenie,
                        NumerSezonu = sezon.NumerSezonu,
                        NazwaSezonu = sezon.NazwaSezonu,
                        IloscOdcinkow = sezon.IloscOdcinkow,
                        IloscPostaci = sezon.IloscPostaci,
                        DataProdukcji = sezon.DataProdukcji,
                        OpisSezonu = sezon.OpisSezonu
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaSerialu", "NumerSezonu", "NazwaSezonu", "IloscOdcinkow","IloscPostaci",
                "DataProdukcji" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaSerialu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.NazwaSerialu));
            }
            if (SortField == "NumerSezonu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.NumerSezonu));
            }
            if (SortField == "NazwaSezonu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.NazwaSezonu));
            }
            if (SortField == "IloscOdcinkow")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.IloscOdcinkow));
            }
            if (SortField == "IloscPostaci")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.IloscPostaci));
            }
            if (SortField == "DataProdukcji")
            {
                List = new ObservableCollection<SezonyForAllView>(List.OrderBy(Item => Item.DataProdukcji));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaSerialu", "NumerSezonu", "NazwaSezonu", "IloscOdcinkow",
                "DataProdukcji" };
        }
        public override void Find()
        {
            if (FindField == "NazwaSerialu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.Where(Item => Item.NazwaSerialu != null && Item.NazwaSezonu.Contains(FindTextBox)));
            }
            if (FindField == "NumerSezonu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.Where(Item => Item.NumerSezonu != null && Item.NumerSezonu.Equals(FindTextBox)));
            }
            if (FindField == "NazwaSezonu")
            {
                List = new ObservableCollection<SezonyForAllView>(List.Where(Item => Item.NazwaSezonu != null && Item.NazwaSezonu.Contains(FindTextBox)));
            }
            if (FindField == "IloscOdcinkow")
            {
                List = new ObservableCollection<SezonyForAllView>(List.Where(Item => Item.IloscOdcinkow != null && Item.IloscOdcinkow.Equals(FindTextBox)));
            }
            if (FindField == "DataProdukcji")
            {
                List = new ObservableCollection<SezonyForAllView>(List.Where(Item => Item.DataProdukcji != null && Item.DataProdukcji.Equals(FindTextBox)));
            }
        }
        #endregion
    }
}
