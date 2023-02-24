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

namespace TranslateIT.ViewModels
{
    public class NowaFirmaViewModel : OneViewModel<DaneFirmy>, IDataErrorInfo
    {
        #region Constructor
        public NowaFirmaViewModel() : base("Wszystkie firmy")
        {
            Item = new DaneFirmy();
            Messenger.Default.Register<AdresForAllView>(this, GetWybranyAdres);
            //Item = new Adres();
        }
        #endregion
        #region Commands

        private BaseCommand _ShowAdresyCommand;
        public ICommand ShowAdresyCommand
        {
            get
            {
                if (_ShowAdresyCommand == null)
                {
                    _ShowAdresyCommand = new BaseCommand(() => ShowAdresy());
                }
                return _ShowAdresyCommand;
            }
        }

        public void ShowAdresy()
        {
            Messenger.Default.Send("AdresyAll");
        }
        #endregion
        #region Properties
        public string NazwaFirmy
        {
            get
            {
                return Item.NazwaFirmy;
            }
            set
            {
                if (value != Item.NazwaFirmy)
                {
                    Item.NazwaFirmy = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => NazwaFirmy);
                }
            }
        }
        public string SkroconaNazwa
        {
            get
            {
                return Item.SkroconaNazwa;
            }
            set
            {
                if (value != Item.SkroconaNazwa)
                {
                    Item.SkroconaNazwa = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => SkroconaNazwa);
                }
            }
        }
        public int? IdAdresu
        {
            get
            {
                return Item.IdAdresu;
            }
            set
            {
                if (value != Item.IdAdresu)
                {
                    Item.IdAdresu = value;
                    base.OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        public IQueryable<KeyAndValue> AdresyComboBoxItems
        {
            get
            {
                return
                    (
                        from adres in Db.Adres
                        select new KeyAndValue
                        {
                            Key = adres.IdAdresu,
                            Value = "ul. "+ adres.Ulica + " " + adres.NumerDomu +"/"+adres.NumerMieszkania+" "+adres.Miasto+" "+adres.KodPocztowy
                        }
                    ).ToList().AsQueryable();
            }
        }
        public string OpisFirmy
        {
            get
            {
                return Item.OpisFirmy;
            }
            set
            {
                if (value != Item.OpisFirmy)
                {
                    Item.OpisFirmy = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => OpisFirmy);
                }
            }
        }
        public string NIP
        {
            get
            {
                return Item.NIP;
            }
            set
            {
                if (value != Item.NIP)
                {
                    Item.NIP = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => NIP);
                }
            }
        }
        public string REGON
        {
            get
            {
                return Item.REGON;
            }
            set
            {
                if (value != Item.REGON)
                {
                    Item.REGON = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => REGON);
                }
            }
        }
        public string FAX
        {
            get
            {
                return Item.FAX;
            }
            set
            {
                if (value != Item.FAX)
                {
                    Item.FAX = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => FAX);
                }
            }
        }
        public string StronaWWW
        {
            get
            {
                return Item.StronaWWW;
            }
            set
            {
                if (value != Item.StronaWWW)
                {
                    Item.StronaWWW = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => StronaWWW);
                }
            }
        }

        //tego logo nie uzywamy bo to zuo
        public byte[] Logo ///
        {
            get
            {
                return Item.Logo;
            }
            set
            {
                if (value != Item.Logo)
                {
                    Item.Logo = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => Logo);
                }
            }
        }
        public string Email
        {
            get
            {
                return Item.EMail;
            }
            set
            {
                if (value != Item.EMail)
                {
                    Item.EMail = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => Email);
                }
            }
        }
        public bool? OsobaFizyczna
        {
            get
            {
                return Item.OsobaFizyczna;
            }
            set
            {
                if (value != Item.OsobaFizyczna)
                {
                    Item.OsobaFizyczna = value;
                    // wyrazenie lambda () =>
                    base.OnPropertyChanged(() => OsobaFizyczna);
                }
            }
        }
        private int? _FirmaIdAdresu;
        //tego nie
        public int? FirmaIdAdresu
        { 
            get
            {
                return _FirmaIdAdresu;
            }
            set
            {
                if (value != _FirmaIdAdresu)
                {
                    _FirmaIdAdresu = value;
                    base.OnPropertyChanged(() => _FirmaIdAdresu);
                }
            }
        }
        private string _FirmaKodPocztowy;
        public string FirmaKodPocztowy
        {
            get
            {
                return _FirmaKodPocztowy;
            }
            set
            {
                if(value!=_FirmaKodPocztowy) 
                {
                    _FirmaKodPocztowy= value;
                    base.OnPropertyChanged(() => _FirmaKodPocztowy);
                }
            }
        }
        private string _FirmaMiasto;
        public string FirmaMiasto
        {
            get
            {
                return _FirmaMiasto;
            }
            set
            {
                if (value != _FirmaMiasto)
                {
                    _FirmaMiasto = value;
                    base.OnPropertyChanged(() => _FirmaMiasto);
                }
            }
        }
        private string _FirmaUlica;
        public string FirmaUlica
        {
            get
            {
                return _FirmaUlica;
            }
            set
            {
                if (value != _FirmaUlica)
                {
                    _FirmaUlica = value;
                    base.OnPropertyChanged(() => _FirmaUlica);
                }
            }
        }
        private string _FirmaNumerDomu;
        public string FirmaNumerDomu
        {
            get
            {
                return _FirmaNumerDomu;
            }
            set
            {
                if (value != _FirmaNumerDomu)
                {
                    _FirmaNumerDomu = value;
                    base.OnPropertyChanged(() => _FirmaNumerDomu);
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
                if (name == "NazwaFirmy")
                    komunikat = StringValidator.IsUpperCase(NazwaFirmy);
                if (name == "SkroconaNazwa")
                    komunikat = StringValidator.IsUpperCase(SkroconaNazwa);
                if (name == "NIP")
                    komunikat = BusinessValidator.SprawdzPesel(NIP);
                if (name == "REGON")
                    komunikat = BusinessValidator.SprawdzREGON(REGON);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaFirmy"] == null && this["SkroconaNazwa"] == null && this["NIP"] == null &&
                this["REGON"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.DaneFirmy.AddObject(Item);
            Db.SaveChanges();
        }
        private void GetWybranyAdres(AdresForAllView adresForAllView)
        {
            FirmaIdAdresu = adresForAllView.IdAdresu;
            FirmaKodPocztowy = adresForAllView.KodPocztowy;
            FirmaMiasto = adresForAllView.Miasto;
            FirmaUlica = adresForAllView.Ulica;
            FirmaNumerDomu = adresForAllView.NumerDomu;
        }
        #endregion
    }
}
