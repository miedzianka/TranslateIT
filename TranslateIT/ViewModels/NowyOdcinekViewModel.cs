using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.Model.Validators;
using TranslateIT.ViewModels.Abstract;
using TranslateIT.Views;

namespace TranslateIT.ViewModels
{
    public class NowyOdcinekViewModel : OneViewModel<Odcinki>, IDataErrorInfo
    {
        #region Constructor
        public NowyOdcinekViewModel()
            :base("Odcinek")
        {
            Item = new Odcinki();
            Messenger.Default.Register<SerialeForAllView>(this, GetWybranySerial);
            Messenger.Default.Register<SezonyForAllView>(this, GetWybranySezon);
            Messenger.Default.Register<FirmyForAllView>(this, GetWybranaFirma);
            Messenger.Default.Register<ProjektyForAllView>(this, GetWybranyProjekt);
        }
        #endregion
        #region Commands
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
        private BaseCommand _ShowSerialeCommand;
        public ICommand ShowSerialeCommand
        {
            get
            {
                if (_ShowSerialeCommand == null)
                {
                    _ShowSerialeCommand = new BaseCommand(() => ShowSeriale());
                }
                return _ShowSerialeCommand;
            }
        }
        public void ShowSeriale()
        {
            Messenger.Default.Send("SerialeAll");
        }
        private BaseCommand _ShowSezonyCommand;
        public ICommand ShowSezonyCommand
        {
            get
            {
                if (_ShowSezonyCommand == null)
                {
                    _ShowSezonyCommand = new BaseCommand(() => ShowSezony());
                }
                return _ShowSezonyCommand;
            }
        }
        public void ShowSezony()
        {
            Messenger.Default.Send("SezonyAll");
        }
        #endregion
        #region Properties
        public int? NumerOdcinka
        {
            get
            {
                return Item.NumerOdcinka;
            }
            set
            {
                if (value != Item.NumerOdcinka)
                {
                    Item.NumerOdcinka = value;
                    base.OnPropertyChanged(() => NumerOdcinka);//to odswieza okno
                }
            }
        } 
        public string NazwaOdcinka
        {
            get
            {
                return Item.NazwaOdcinka;
            }
            set
            {
                if (value != Item.NazwaOdcinka)
                {
                    Item.NazwaOdcinka = value;
                    base.OnPropertyChanged(() => NazwaOdcinka);
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
                if (value!=Item.Deadline)
                {
                    Item.Deadline = value;
                    base.OnPropertyChanged(() => Deadline);//to odswieza okno
                }
            }
        } 
        public DateTime? DataProdukcji

        {
            get
            {
                return Item.DataProdukcji;
            }
            set
            {
                if (value!=Item.DataProdukcji)
                {
                    Item.DataProdukcji = value;
                    base.OnPropertyChanged(() => DataProdukcji);//to odswieza okno
                }
            }
        } 
        public int? Piosenki
        {
            get
            {
                return Item.Piosenki;
            }
            set
            {
                if (value!=Item.Piosenki)
                {
                    Item.Piosenki = value;
                    base.OnPropertyChanged(() => Piosenki);//to odswieza okno
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
                if (value!=Item.Postacie)
                {
                    Item.Postacie = value;
                    base.OnPropertyChanged(() => Postacie);//to odswieza okno
                }
            }
        } 
        public string OpisOdcinka
        {
            get
            {
                return Item.OpisOdcinka;
            }
            set
            {
                if (value!=Item.OpisOdcinka)
                {
                    Item.OpisOdcinka = value;
                    base.OnPropertyChanged(() => OpisOdcinka);//to odswieza okno
                }
            }
        } 
        public string DlugoscOdcinkaMIN
        {
            get
            {
                return Item.DlugoscOdcinkaMIN;
            }
            set
            {
                if (value!=Item.DlugoscOdcinkaMIN)
                {
                    Item.DlugoscOdcinkaMIN = value;
                    base.OnPropertyChanged(() => DlugoscOdcinkaMIN);//to odswieza okno
                }
            }
        } 
        public int? IloscLinijek
        {
            get
            {
                return Item.IloscLinijek;
            }
            set
            {
                if (value!=Item.IloscLinijek)
                {
                    Item.IloscLinijek = value;
                    base.OnPropertyChanged(() => IloscLinijek);//to odswieza okno
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
                if (value!=Item.Akty)
                {
                    Item.Akty = value;
                    base.OnPropertyChanged(() => Akty);//to odswieza okno
                }
            }
        } 
        public DateTime? DataPrzyjecia
        {
            get
            {
                return Item.DataPrzyjecia;
            }
            set
            {
                if (value!=Item.DataPrzyjecia)
                {
                    Item.DataPrzyjecia = value;
                    base.OnPropertyChanged(() => DataPrzyjecia);//to odswieza okno
                }
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
                if (value!=Item.Budzet)
                {
                    Item.Budzet = value;
                    base.OnPropertyChanged(() => Budzet);//to odswieza okno
                }
            }
        } 
        private int? _IdSezonu;
        public int? IdSezonuu
        {
            get
            {
                return _IdSezonu;
            }
            set
            {
                if (value != _IdSezonu)
                {
                    _IdSezonu = value;
                    base.OnPropertyChanged(() => _IdSezonu);
                }
            }
        }
        private int? _NumerSezonu;
        public int? NumerSezonu
        {
            get
            {
                return _NumerSezonu;
            }
            set
            {
                if (value != _NumerSezonu)
                {
                    _NumerSezonu = value;
                    base.OnPropertyChanged(() => _NumerSezonu);
                }
            }
        }
        private int? _IdSerialu;
        public int? IdSerialuu
        {
            get
            {
                return _IdSerialu;
            }
            set
            {
                if (value != _IdSerialu)
                {
                    _IdSerialu = value;
                    base.OnPropertyChanged(() => _IdSerialu);
                }
            }
        }

        private string _NazwaSerialu;
        public string NazwaSerialu
        {
            get
            {
                return _NazwaSerialu;
            }
            set
            {
                if (value != _NazwaSerialu)
                {
                    _NazwaSerialu = value;
                    base.OnPropertyChanged(() => _NazwaSerialu);
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
                if (name == "NazwaOdcinka")
                    komunikat = StringValidator.IsUpperCase(NazwaOdcinka);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaOdcinka"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            //najpierw dodajemy towar do lokalnej kolekcji nastepnie zapisujemy dane w bazie danych
            Db.Odcinki.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranySerial(SerialeForAllView serialeforallview)
        { 
            IdSerialuu = serialeforallview.IdSerialu;
            NazwaSerialu = serialeforallview.TytulSerialu;
        }
        private void GetWybranySezon(SezonyForAllView sezonyForAllView)
        {
            IdSezonuu = sezonyForAllView.IdSezonu;
            NumerSezonu = sezonyForAllView.NumerSezonu;
        }
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
