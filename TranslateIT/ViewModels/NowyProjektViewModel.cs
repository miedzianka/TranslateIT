using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.ViewModels.Abstract;

namespace TranslateIT.ViewModels
{
    class NowyProjektViewModel : OneViewModel<Projekt>
    {
        #region Constructor
        public NowyProjektViewModel() : base("Nowy projekt")
        {
            Item = new Projekt();
            Messenger.Default.Register<FirmyForAllView>(this, GetWybranaFirma);
        }
        #endregion
        #region Commands
        private BaseCommand _ShowFirmyCommand;
        public ICommand ShowFirmyCommand
        {
            get
            {
                if (_ShowFirmyCommand == null)
                {
                    _ShowFirmyCommand = new BaseCommand(() => ShowFirmy());
                }
                return _ShowFirmyCommand;
            }
        }
        public void ShowFirmy()
        {
            Messenger.Default.Send("FirmyAll");
        }
        #endregion
        #region Properties
        public int? IdKoordynatoraLektor
        {
            get
            {
                return Item.IdKoordynatoraLektor;
            }
            set
            {
                if (value != Item.IdKoordynatoraLektor)
                {
                    Item.IdKoordynatoraLektor = value;
                    base.OnPropertyChanged(() => IdKoordynatoraLektor);
                }
            }
        }
        public IQueryable<KeyAndValue> KoordynatorLektorComboBoxItems
        {
            get
            {
                return
                    (
                        from koordynator in Db.Koordynator
                        join pracownik in Db.Pracownik on koordynator.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = koordynator.IdKoordynatora,
                            Value = pracownik.Imie+ " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdKoordynatoraDubbing
        {
            get
            {
                return Item.IdKoordynatoraDubbing;
            }
            set
            {
                if (value != Item.IdKoordynatoraDubbing)
                {
                    Item.IdKoordynatoraDubbing = value;
                    base.OnPropertyChanged(() => IdKoordynatoraDubbing);
                }
            }
        }
        public IQueryable<KeyAndValue> KoordynatorDubbingComboBoxItems
        {
            get
            {
                return
                    (
                        from koordynator in Db.Koordynator
                        join pracownik in Db.Pracownik on koordynator.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = koordynator.IdKoordynatora,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdKoordynatoraNapisy
        {
            get
            {
                return Item.IdKoordynatoraNapisy;
            }
            set
            {
                if (value != Item.IdKoordynatoraNapisy)
                {
                    Item.IdKoordynatoraNapisy = value;
                    base.OnPropertyChanged(() => IdKoordynatoraNapisy);
                }
            }
        }
        public IQueryable<KeyAndValue> KoordynatorNapisyComboBoxItems
        {
            get
            {
                return
                    (
                        from koordynator in Db.Koordynator
                        join pracownik in Db.Pracownik on koordynator.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = koordynator.IdKoordynatora,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdTlumaczLektor
        {
            get
            {
                return Item.IdTlumaczaLektor;
            }
            set
            {
                if (value != Item.IdTlumaczaLektor)
                {
                    Item.IdTlumaczaLektor = value;
                    base.OnPropertyChanged(() => IdTlumaczLektor);
                }
            }
        }
        public IQueryable<KeyAndValue> TLumaczLektorComboBoxItems
        {
            get
            {
                return
                    (
                        from tlumacz in Db.Tlumacze
                        join pracownik in Db.Pracownik on tlumacz.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = tlumacz.IdTlumacza,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdTlumaczDubbing
        {
            get
            {
                return Item.IdTlumaczaDubbing;
            }
            set
            {
                if (value != Item.IdTlumaczaDubbing)
                {
                    Item.IdTlumaczaDubbing = value;
                    base.OnPropertyChanged(() => IdTlumaczDubbing);
                }
            }
        }
        public IQueryable<KeyAndValue> TlumaczDubbingComboBoxItems
        {
            get
            {
                return
                    (
                        from tlumacz in Db.Tlumacze
                        join pracownik in Db.Pracownik on tlumacz.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = tlumacz.IdTlumacza,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdTlumaczaNapisy
        {
            get
            {
                return Item.IdTlumaczaNapisy;
            }
            set
            {
                if (value != Item.IdTlumaczaNapisy)
                {
                    Item.IdTlumaczaNapisy = value;
                    base.OnPropertyChanged(() => IdTlumaczaNapisy);
                }
            }
        }
        public IQueryable<KeyAndValue> TlumaczNapisyComboBoxItems
        {
            get
            {
                return
                    (
                        from tlumacz in Db.Tlumacze
                        join pracownik in Db.Pracownik on tlumacz.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = tlumacz.IdTlumacza,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdEtapuProjektu
        {
            get
            {
                return Item.IdEtapuProjektu;
            }
            set
            {
                if (value != Item.IdEtapuProjektu)
                {
                    Item.IdEtapuProjektu = value;
                    base.OnPropertyChanged(() => IdEtapuProjektu);
                }
            }
        }
        public IQueryable<KeyAndValue> EtapyProjektuComboBoxItems
        {
            get
            {
                return
                    (
                        from tlumacz in Db.Tlumacze
                        join pracownik in Db.Pracownik on tlumacz.IdPracownika equals pracownik.IdPracownika
                        select new KeyAndValue
                        {
                            Key = tlumacz.IdTlumacza,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                        }
                    ).ToList().AsQueryable();
            }
        }
        public bool? CzyLektor
        {
            get
            {
                return Item.CzyLektor;
            }
            set
            {
                if (value != Item.CzyLektor)
                {
                    Item.CzyLektor = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => CzyLektor);
                }
            }
        }
        public bool? CzyNapisy
        {
            get
            {
                return Item.CzyNapisy;
            }
            set
            {
                if (value != Item.CzyNapisy)
                {
                    Item.CzyNapisy = value;
                    base.OnPropertyChanged(() => CzyNapisy);
                }
            }
        }
        public bool? CzyDubbing
        {
            get
            {
                return Item.CzyDubbing;
            }
            set
            {
                if (value != Item.CzyDubbing)
                {
                    Item.CzyDubbing = value;
                    base.OnPropertyChanged(() => CzyDubbing);
                }
            }
        }
        public int? IdJezykaOryginalnego
        {
            get
            {
                return Item.IdJezykaOryginalnego;
            }
            set
            {
                if (value != Item.IdJezykaOryginalnego)
                {
                    Item.IdJezykaOryginalnego = value;
                    base.OnPropertyChanged(() => IdJezykaOryginalnego);
                }
            }
        }
        public IQueryable<KeyAndValue> JezykOryginalnyComboBoxItems
        {
            get
            {
                return
                    (
                        from jezyk in Db.Jezyki
                        select new KeyAndValue
                        {
                            Key = jezyk.IdLanguage,
                            Value = jezyk.Jezyk
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdJezykaTlumaczenia
        {
            get
            {
                return Item.IdJezykaTlumaczenia;
            }
            set
            {
                if (value != Item.IdJezykaTlumaczenia)
                {
                    Item.IdJezykaTlumaczenia = value;
                    base.OnPropertyChanged(() => IdJezykaTlumaczenia);
                }
            }
        }
        public IQueryable<KeyAndValue> JezykTlumaczeniaComboBoxItems
        {
            get
            {
                return
                    (
                        from jezyk in Db.Jezyki
                        select new KeyAndValue
                        {
                            Key = jezyk.IdLanguage,
                            Value = jezyk.Jezyk
                        }
                    ).ToList().AsQueryable();
            }
        }
        public decimal? Budzet
        {
            get
            {
                return Item.Budzet;
            }
            set
            {
                if (value != Item.Budzet)
                {
                    Item.Budzet = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => Budzet);
                }
            }
        }
        private int? _IdFirma;
        public int? IdFirma
        {
            get
            {
                return _IdFirma;
            }
            set
            {
                if (value != _IdFirma)
                {
                    _IdFirma = value;
                    base.OnPropertyChanged(() => _IdFirma);
                }
            }
        }
        private string _FirmaNazwa;
        public string FirmaNazwa
        {
            get
            {
                return _FirmaNazwa;
            }
            set
            {
                if (value != _FirmaNazwa)
                {
                    _FirmaNazwa = value;
                    base.OnPropertyChanged(() => _FirmaNazwa);
                }
            }
        }

        private string _FirmaNIP;
        public string FirmaNIP
        {
            get
            {
                return _FirmaNIP;
            }
            set
            {
                if (value != _FirmaNIP)
                {
                    _FirmaNIP = value;
                    base.OnPropertyChanged(() => _FirmaNIP);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.Projekt.AddObject(Item);
            Db.SaveChanges();
        }
        private void GetWybranaFirma(FirmyForAllView firmaForAllView)
        {
            IdFirma = firmaForAllView.IdFirma;
            FirmaNazwa = firmaForAllView.FirmaNazwa;
            FirmaNIP = firmaForAllView.FirmaNIP;
        }
        #endregion
    }
}
