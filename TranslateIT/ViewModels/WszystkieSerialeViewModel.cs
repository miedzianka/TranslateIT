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
    public class WszystkieSerialeViewModel : AllViewModel<SerialeForAllView>
    {
        public WszystkieSerialeViewModel() : base("Seriale")
        {
        }
        #region Properties
        private SerialeForAllView _WybranySerial;
        public SerialeForAllView WybranySerial
        {
            get
            {
                return _WybranySerial;
            }
            set
            {
                if (_WybranySerial != value)
                {
                    _WybranySerial = value;
                    Messenger.Default.Send(_WybranySerial);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SerialeForAllView>
                (
                    from serial in TranslateITEntities.Serial
                    where serial.CzyAktywne == true
                    select new SerialeForAllView
                    {
                        IdSerialu= serial.IdSerialu,
                        OryginalnyTytul=serial.OryginalnyTytul,
                        TytulSerialu=serial.TytułSerialuTlumaczenie,
                        IloscSezonow=serial.IloscSezonow,
                        IloscOdcinkow=serial.IloscOdcinkow,
                        OcenaFilmweb=serial.OcenaFilmweb,
                        WWWFilmweb=serial.WWWDoFilmweb,
                        DataProdukcji=serial.DataProdukcji,
                        CzyNadalNagrywamy=serial.CzyNadalNagrywany,
                        RokZakonczeniaProdukcji=serial.RokZakonczeniaProdukcji,
                        TlumaczoneDla=serial.TlumaczoneDla,
                        KrajPochodzenia=serial.Kraj.NazwaKraju
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "OryginalnyTytul", "TytulSerialu", "OcenaFilmweb", "CzyNadalNagrywamy", "TlumaczoneDla",
                "KrajPochodzenia" };
        }
        public override void Sort()
        {
            if (SortField == "OryginalnyTytul")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.OryginalnyTytul));
            }
            if (SortField == "TytulSerialu")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.TytulSerialu));
            }
            if (SortField == "OcenaFilmweb")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.OcenaFilmweb));
            }
            if (SortField == "CzyNadalNagrywamy")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.CzyNadalNagrywamy));
            }
            if (SortField == "TlumaczoneDla")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.TlumaczoneDla));
            }
            if (SortField == "KrajPochodzenia")
            {
                List = new ObservableCollection<SerialeForAllView>(List.OrderBy(Item => Item.KrajPochodzenia));
            }            
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "OryginalnyTytul", "TytulSerialu",  "CzyNadalNagrywamy", "TlumaczoneDla",
                "KrajPochodzenia" };
        }
        public override void Find()
        {
            if (FindField == "OryginalnyTytul")
            {
                List = new ObservableCollection<SerialeForAllView>(List.Where(Item => Item.OryginalnyTytul != null && Item.OryginalnyTytul.Contains(FindTextBox)));
            }
            if (FindField == "TytulSerialu")
            {
                List = new ObservableCollection<SerialeForAllView>(List.Where(Item => Item.TytulSerialu != null && Item.TytulSerialu.Contains(FindTextBox)));
            }
            if (FindField == "CzyNadalNagrywamy")
            {
                List = new ObservableCollection<SerialeForAllView>(List.Where(Item => Item.CzyNadalNagrywamy != null && Item.CzyNadalNagrywamy.Equals(FindTextBox)));
            }
            if (FindField == "TlumaczoneDla")
            {
                List = new ObservableCollection<SerialeForAllView>(List.Where(Item => Item.TlumaczoneDla != null && Item.TlumaczoneDla.Contains(FindTextBox)));
            }
            if (FindField == "KrajPochodzenia")
            {
                List = new ObservableCollection<SerialeForAllView>(List.Where(Item => Item.KrajPochodzenia != null && Item.KrajPochodzenia.Contains(FindTextBox)));
            }
        }
        #endregion
    }
}
