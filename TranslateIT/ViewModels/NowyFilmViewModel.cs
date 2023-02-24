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
using TranslateIT.Model.Validators;
using TranslateIT.ViewModels.Abstract;

namespace TranslateIT.ViewModels
{
    public class NowyFilmViewModel : OneViewModel<Film>, IDataErrorInfo
    {
        #region Constructor
        public NowyFilmViewModel()
            : base("Film")
        {
            Item = new Film();
            Messenger.Default.Register<FirmyForAllView>(this, GetWybranaFirma);
            Messenger.Default.Register<ProjektyForAllView>(this, GetWybranyProjekt);
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
        private BaseCommand _ShowProjektyCommand;
        public ICommand ShowProjektyCommand
        {
            get
            {
                if (_ShowProjektyCommand == null)
                {
                    _ShowProjektyCommand = new BaseCommand(() => ShowProjekty());
                }
                return _ShowProjektyCommand;
            }
        }

        public void ShowProjekty()
        {
            Messenger.Default.Send("ProjektyAll");
        }
        #endregion
        #region Properties
        public string TytulFilmu
        {
            get
            {
                return Item.TutulFilmu;

            }
            set 
            {
                if(value!=Item.TutulFilmu)
                {
                    Item.TutulFilmu = value;
                    base.OnPropertyChanged(() => TytulFilmu);
                }
            }
        }
        public string OriginalTitle
        {
            get
            {
                return Item.OryginalnyTytuł;

            }
            set
            {
                if (value != Item.OryginalnyTytuł)
                {
                    Item.OryginalnyTytuł = value;
                    base.OnPropertyChanged(() => OriginalTitle);
                }
            }
        }
        public string NameCode
        {
            get
            {
                return Item.NameCode;

            }
            set
            {
                if (value != Item.NameCode)
                {
                    Item.NameCode = value;
                    base.OnPropertyChanged(() => NameCode);
                }
            }
        }
        public int? OcenaFilmuFilmweb
        {
            get
            {
                return Item.OcenaFilmuFilmweb;

            }
            set
            {
                if (value != Item.OcenaFilmuFilmweb)
                {
                    Item.OcenaFilmuFilmweb = value;
                    base.OnPropertyChanged(() => OcenaFilmuFilmweb);
                }
            }
        }
        public string WWWFilmweb
        {
            get
            {
                return Item.WWWFilmweb;

            }
            set
            {
                if (value != Item.WWWFilmweb)
                {
                    Item.WWWFilmweb = value;
                    base.OnPropertyChanged(() => WWWFilmweb);
                }
            }
        }
        public string CzasTrwaniaFilmuMin
        {
            get
            {
                return Item.CzasTrwaniaFilmuMin;

            }
            set
            {
                if (value != Item.CzasTrwaniaFilmuMin)
                {
                    Item.CzasTrwaniaFilmuMin = value;
                    base.OnPropertyChanged(() => CzasTrwaniaFilmuMin);
                }
            }
        }
        public int? Akty
        {
            get
            {
                return Item.Akty;

            }
            set
            {
                if (value != Item.Akty)
                {
                    Item.Akty = value;
                    base.OnPropertyChanged(() => Akty);
                }
            }
        }
        public int? Postacie
        {
            get
            {
                return Item.Postacie;

            }
            set
            {
                if (value != Item.Postacie)
                {
                    Item.Postacie = value;
                    base.OnPropertyChanged(() => Postacie);
                }
            }
        }
        public int? IdFirmy
        {
            get
            {
                return Item.IdFirmy;

            }
            set
            {
                if (value != Item.IdFirmy)
                {
                    Item.IdFirmy = value;
                    base.OnPropertyChanged(() => IdFirmy);
                }
            }
        }
        public IQueryable<KeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                    (
                        from firma in Db.DaneFirmy
                        select new KeyAndValue
                        {
                            Key = firma.IdFirmy,
                            Value = firma.NazwaFirmy + " | NIP: " + firma.NIP
                        }
                    ).ToList().AsQueryable();
            }
        }
        public byte[] LogoFilmu
        {
            get
            {
                return Item.LogoFilmu;

            }
            set
            {
                if (value != Item.LogoFilmu)
                {
                    Item.LogoFilmu = value;
                    base.OnPropertyChanged(() => LogoFilmu);
                }
            }
        }        
        public int? IdKrajPochodzenia
        {
            get
            {
                return Item.IdKrajPochodzenia;

            }
            set
            {
                if (value != Item.IdKrajPochodzenia)
                {
                    Item.IdKrajPochodzenia = value;
                    base.OnPropertyChanged(() => IdKrajPochodzenia);
                }
            }
        }
        public IQueryable<KeyAndValue> KrajeComboBoxItems
        {
            get
            {
                return
                    (
                        from kraje in Db.Kraj
                        select new KeyAndValue
                        {
                            Key = kraje.IdKraju,
                            Value = kraje.NazwaKraju
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? RokProdukcji
        {
            get
            {
                return Item.RokProdukcji;

            }
            set
            {
                if (value != Item.RokProdukcji)
                {
                    Item.RokProdukcji = value;
                    base.OnPropertyChanged(() => RokProdukcji);
                }
            }
        }
        public DateTime? Deadline
        {
            get
            {
                return Item.Deadline;

            }
            set
            {
                if (value != Item.Deadline)
                {
                    Item.Deadline = value;
                    base.OnPropertyChanged(() => Deadline);
                }
            }
        }
        public DateTime? DataPremiery
        {
            get
            {
                return Item.DataPremiery;

            }
            set
            {
                if (value != Item.DataPremiery)
                {
                    Item.DataPremiery = value;
                    base.OnPropertyChanged(() => DataPremiery);
                }
            }
        }
        public string OpisFilmu
        {
            get
            {
                return Item.OpisFilmu;

            }
            set
            {
                if (value != Item.OpisFilmu)
                {
                    Item.OpisFilmu = value;
                    base.OnPropertyChanged(() => OpisFilmu);
                }
            }
        }
        private int? _IdProjektu;
        public int? IdProjektu
        {
            get
            {
                return _IdProjektu;
            }
            set
            {
                if (value != _IdProjektu)
                {
                    _IdProjektu = value;
                    base.OnPropertyChanged(() => _IdProjektu);
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

        private string _FirmaAdres;
        public string FirmaAdres
        {
            get
            {
                return _FirmaAdres;
            }
            set
            {
                if (value != _FirmaAdres)
                {
                    _FirmaAdres = value;
                    base.OnPropertyChanged(() => _FirmaAdres);
                }
            }
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "TytulFilmu")
                    komunikat = StringValidator.IsUpperCase(TytulFilmu);
                if (name == "OriginalTitle")
                    komunikat = StringValidator.IsUpperCase(OriginalTitle);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["TytulFilmu"] == null && this["OriginalTitle"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne=true;
            Db.Film.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranaFirma(FirmyForAllView firmyForAllView)
        {
            IdFirma = firmyForAllView.IdFirma;
            FirmaNazwa = firmyForAllView.FirmaNazwa;
            FirmaNIP = firmyForAllView.FirmaNIP;
            //FirmaAdres = firmyForAllView.FirmaAdres;
        }
        private void GetWybranyProjekt(ProjektyForAllView projektyForAllView)
        {
            IdProjektu = projektyForAllView.IdProjektu;
        }
        #endregion
    }
}
