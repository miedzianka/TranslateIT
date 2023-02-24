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
    public class WszystkieFirmyViewModel : AllViewModel<FirmyForAllView>
    {
        public WszystkieFirmyViewModel () : base("Firmy")
        {
        }
        #region Properties
        private FirmyForAllView _WybranaFirma;
        public FirmyForAllView WybranaFirma
        {
            get
            {
                return _WybranaFirma;
            }
            set
            {
                if (_WybranaFirma != value)
                {
                    _WybranaFirma = value;
                    Messenger.Default.Send(_WybranaFirma);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FirmyForAllView>
               (
                   from firma in TranslateITEntities.DaneFirmy
                   where firma.CzyAktywne == true
                   select new FirmyForAllView
                   {
                       IdFirma=firma.IdFirmy,
                       FirmaNazwa=firma.NazwaFirmy,
                       FirmaSkroconaNazwa=firma.SkroconaNazwa,
                       FirmaKodPocztowy=firma.Adres.KodPocztowy,
                       FirmaKraj=firma.Adres.Miasto,
                       FirmaMiasto=firma.Adres.Ulica,
                       FirmaNrDomu=firma.Adres.NumerDomu,
                       FirmaUlica=firma.Adres.NumerDomu,
                       FirmaREGON =firma.REGON,
                       FirmaNIP=firma.NIP,
                       FirmaFAX=firma.FAX,
                       StronaWWW=firma.StronaWWW,
                       Email=firma.EMail,
                       CzyOsobaFizyczna=firma.OsobaFizyczna
                   }
               );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "FirmaNazwa", "FirmaKodPocztowy", "FirmaKraj", "FirmaMiasto", "FirmaREGON", "FirmaNIP" };
        }
        public override void Sort()
        {
            if (SortField == "FirmaNazwa")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaNazwa));
            }
            if (SortField == "FirmaKodPocztowy")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaKodPocztowy));
            }
            if (SortField == "FirmaKraj")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaKraj));
            }
            if (SortField == "FirmaMiasto")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaMiasto));
            }
            if (SortField == "FirmaREGON")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaREGON));
            }
            if (SortField == "FirmaNIP")
            {
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(Item => Item.FirmaNIP));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "FirmaNazwa", "FirmaKodPocztowy", "FirmaKraj", "FirmaMiasto", "FirmaREGON", "FirmaNIP" };
        }
        public override void Find()
        {
            if (FindField == "FirmaNazwa")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaNazwa != null && Item.FirmaNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaKodPocztowy")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaKodPocztowy != null && Item.FirmaKodPocztowy.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaKraj")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaKraj != null && Item.FirmaKraj.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaMiasto")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaMiasto != null && Item.FirmaMiasto.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaREGON")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaREGON != null && Item.FirmaREGON.StartsWith(FindTextBox)));
            }
            if (FindField == "FirmaNIP")
            {
                List = new ObservableCollection<FirmyForAllView>(List.Where(Item => Item.FirmaNIP != null && Item.FirmaNIP.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
