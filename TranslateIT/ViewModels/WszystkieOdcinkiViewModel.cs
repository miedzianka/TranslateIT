using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.Views;

namespace TranslateIT.ViewModels
{
    public class WszystkieOdcinkiViewModel : AllViewModel<OdcinkiForAllView>
    {
        #region Constructor
        public WszystkieOdcinkiViewModel()
            :base("Odcinki")
        {
        }
        #endregion
        #region Properties
        private OdcinkiForAllView _WybranyOdcinek;
        public OdcinkiForAllView WybranyOdcinek
        {
            get
            {
                return _WybranyOdcinek;
            }
            set
            {
                if (_WybranyOdcinek != value)
                {
                    _WybranyOdcinek = value;
                    Messenger.Default.Send(_WybranyOdcinek);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<OdcinkiForAllView>
            (
                from odcinki in TranslateITEntities.Odcinki
                where odcinki.CzyAktywne == true
                select new OdcinkiForAllView
                {
                    IdProjektu = odcinki.IdProjektu,
                    IdOdcinka = odcinki.IdOdcinka,
                    NazwaOdcinka = odcinki.NazwaOdcinka,
                    NumerOdcinka = odcinki.NumerOdcinka,
                    NumerSezonu =odcinki.Sezony.NumerSezonu,
                    NazwaSerialu = odcinki.Serial.TytułSerialuTlumaczenie,
                    Deadline= odcinki.Deadline,
                    DataProdukcji =odcinki.DataProdukcji,
                    Postacie = odcinki.Postacie,
                    DlugoscOdcinkaMIN=odcinki.DlugoscOdcinkaMIN,
                    IloscLinijek = odcinki.IloscLinijek,
                    Budzet = odcinki.Budzet,
                    Akty = odcinki.Akty,
                    OpisOdcinka = odcinki.OpisOdcinka
                }
            );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "IdProjektu", "NazwaOdcinka", "NumerSezonu", "NazwaSerialu", "NumerOdcinka", "Deadline", "Budzet" };
        }
        public override void Sort()
        {
            if (SortField == "IdProjektu")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.IdProjektu));
            }
            if (SortField == "NazwaOdcinka")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.NazwaOdcinka));
            }
            if (SortField == "NumerSezonu")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.NumerSezonu));
            }
            if (SortField == "NazwaSerialu")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.NazwaSerialu));
            }
            if (SortField == "NumerOdcinka")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.NumerOdcinka));
            }
            if (SortField == "Deadline")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.Deadline));
            }
            if (SortField == "Budzet")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.OrderBy(Item => Item.Budzet));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaOdcinka", "NazwaSerialu" };
        }
        public override void Find()
        {
            if (FindField == "NazwaOdcinka")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.Where(Item => Item.NazwaOdcinka != null && Item.NazwaOdcinka.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwaSerialu")
            {
                List = new ObservableCollection<OdcinkiForAllView>(List.Where(Item => Item.NazwaSerialu != null && Item.NazwaSerialu.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
