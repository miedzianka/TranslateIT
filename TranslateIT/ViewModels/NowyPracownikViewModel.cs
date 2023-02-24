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
    class NowyPracownikViewModel : OneViewModel<Pracownik>, IDataErrorInfo
    {
        #region Constructor
        public NowyPracownikViewModel() : base("Pracownik")
        {
            Item = new Pracownik();
            Messenger.Default.Register<FirmyForAllView>(this, GetWybranaFirma);
            Messenger.Default.Register<AdresForAllView>(this, GetWybranyAdres);
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
        public string BankField { get; set; }
        public string Imie
        {
            get
            {
                return Item.Imie;
            }
            set
            {
                if (value != Item.Imie)
                {
                    Item.Imie = value;
                    base.OnPropertyChanged(() => Imie);//to odswieza okno
                }
            }
        }
        public string DrugieImie
        {
            get
            {
                return Item.DrugieImie;
            }
            set
            {
                if (value != Item.DrugieImie)
                {
                    Item.DrugieImie = value;
                    base.OnPropertyChanged(() => DrugieImie);//to odswieza okno
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return Item.Nazwisko_a;
            }
            set
            {
                if (value != Item.Nazwisko_a)
                {
                    Item.Nazwisko_a = value;
                    base.OnPropertyChanged(() => Nazwisko);//to odswieza okno
                }
            }
        }
        public DateTime? DataUrodzenia
        {
            get
            {
                return Item.DataUrodzenia;
            }
            set
            {
                if (value != Item.DataUrodzenia)
                {
                    Item.DataUrodzenia = value;
                    base.OnPropertyChanged(() => DataUrodzenia);//to odswieza okno
                }
            }
        }
        public string Pesel
        {
            get
            {
                return Item.Pesel;
            }
            set
            {
                if (value != Item.Pesel)
                {
                    Item.Pesel = value;
                    base.OnPropertyChanged(() => Pesel);//to odswieza okno
                }
            }
        }
        public string NrKonta
        {
            get
            {
                return Item.nrKonta;
            }
            set
            {
                if (value != Item.nrKonta)
                {
                    Item.nrKonta = value;
                    base.OnPropertyChanged(() => NrKonta);//to odswieza okno
                }
            }
        }
        public string Bank
        {
            get
            {
                return Item.Bank;
            }
            set
            {
                if (value != Item.Bank)
                {
                    Item.Bank = value;
                    base.OnPropertyChanged(() => Bank);//to odswieza okno
                }
            }
        }
        public bool? StatusStudenta
        {
            get
            {
                return Item.StatusStudenta;
            }
            set
            {
                if (value != Item.StatusStudenta)
                {
                    Item.StatusStudenta = value;
                    base.OnPropertyChanged(() => StatusStudenta);//to odswieza okno
                }
            }
        }
        public string Email
        {
            get
            {
                return Item.E_mail;
            }
            set
            {
                if (value != Item.E_mail)
                {
                    Item.E_mail = value;
                    base.OnPropertyChanged(() => Email);//to odswieza okno
                }
            }
        }
        public string NrTelefonu
        {
            get
            {
                return Item.NrTelefonu1;
            }
            set
            {
                if (value != Item.NrTelefonu1)
                {
                    Item.NrTelefonu1 = value;
                    base.OnPropertyChanged(() => NrTelefonu);//to odswieza okno
                }
            }
        }
        public DateTime? DataNawiazaniaWspolpracy
        {
            get
            {
                return Item.DataNawiazaniaWspolpracy;
            }
            set
            {
                if (value != Item.DataNawiazaniaWspolpracy)
                {
                    Item.DataNawiazaniaWspolpracy = value;
                    base.OnPropertyChanged(() => DataNawiazaniaWspolpracy);//to odswieza okno
                }
            }
        }
        public int? IdFirma
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
                    base.OnPropertyChanged(() => IdFirma);//to odswieza okno
                }
            }
        }
        public IQueryable<KeyAndValue> FirmyComboBoxItems
        {
            get
            {
                return
                    (
                        from firma in Db.DaneFirmy
                        where firma.CzyAktywne == true
                        select new KeyAndValue
                        {
                            Key = firma.IdFirmy,
                            Value = firma.SkroconaNazwa + " " + firma.NIP + " " + firma.Logo
                        }
                    ).ToList().AsQueryable();
            }
        }
        private int? _IdFirmy;
        public int? IdFirmy
        {
            get
            {
                return _IdFirmy;
            }
            set
            {
                if (value != _IdFirmy)
                {
                    _IdFirmy = value;
                    base.OnPropertyChanged(() => _IdFirmy);
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
        private int? _PracownikIdAdresu;
        public int? PracownikIdAdresu
        {
            get
            {
                return _PracownikIdAdresu;
            }
            set
            {
                if (value != _PracownikIdAdresu)
                {
                    _PracownikIdAdresu = value;
                    base.OnPropertyChanged(() => _PracownikIdAdresu);
                }
            }
        }
        private string _PracownikKodPocztowy;
        public string PracownikKodPocztowy
        {
            get
            {
                return _PracownikKodPocztowy;
            }
            set
            {
                if (value != _PracownikKodPocztowy)
                {
                    _PracownikKodPocztowy = value;
                    base.OnPropertyChanged(() => _PracownikKodPocztowy);
                }
            }
        }
        private string _PracownikMiasto;
        public string PracownikMiasto
        {
            get
            {
                return _PracownikMiasto;
            }
            set
            {
                if (value != _PracownikMiasto)
                {
                    _PracownikMiasto = value;
                    base.OnPropertyChanged(() => _PracownikMiasto);
                }
            }
        }
        private string _PracownikUlica;
        public string PracownikUlica
        {
            get
            {
                return _PracownikUlica;
            }
            set
            {
                if (value != _PracownikUlica)
                {
                    _PracownikUlica = value;
                    base.OnPropertyChanged(() => _PracownikUlica);
                }
            }
        }
        private string _PracownikNumerDomu;
        public string PracownikNumerDomu
        {
            get
            {
                return _PracownikNumerDomu;
            }
            set
            {
                if (value != _PracownikNumerDomu)
                {
                    _PracownikNumerDomu = value;
                    base.OnPropertyChanged(() => _PracownikNumerDomu);
                }
            }
        }
        private string _PracownikNumerMieszkania;
        public string PracownikNumerMieszkania
        {
            get
            {
                return _PracownikNumerMieszkania;
            }
            set
            {
                if (value != _PracownikNumerMieszkania)
                {
                    _PracownikNumerMieszkania = value;
                    base.OnPropertyChanged(() => _PracownikNumerMieszkania);
                }
            }
        }
        private string _PracownikKraj;
        public string PracownikKraj
        {
            get
            {
                return _PracownikKraj;
            }
            set
            {
                if (value != _PracownikKraj)
                {
                    _PracownikKraj = value;
                    base.OnPropertyChanged(() => _PracownikKraj);
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
                if (name == "Imie")
                    komunikat = StringValidator.IsUpperCase(Imie);
                if (name == "DrugieImie")
                    komunikat = StringValidator.IsUpperCase(DrugieImie);
                if (name == "Nazwisko")
                    komunikat = StringValidator.IsUpperCase(Nazwisko);
                if (name == "Pesel")
                    komunikat = BusinessValidator.SprawdzPesel(Pesel);
                if (name == "NrKonta")
                {
                    komunikat = BusinessValidator.NumerIBAN(NrKonta);
                    BankField = BusinessValidator.SprawdzBank(NrKonta);
                }
                if (name == "NrTelefonu")
                    komunikat = BusinessValidator.SprawdzNumerTelefonu(NrTelefonu);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Imie"] == null && this["DrugieImie"] == null && this["Nazwisko"] == null &&
                this["Pesel"] == null && this["NrKonta"] == null && this["NrTelefonu"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.Pracownik.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranaFirma(FirmyForAllView firmyForAllView)
        {
            IdFirma = firmyForAllView.IdFirma;
            FirmaNazwa = firmyForAllView.FirmaNazwa;
            FirmaNIP = firmyForAllView.FirmaNIP;
        }
        private void GetWybranyAdres(AdresForAllView adresForAllView)
        {
            PracownikIdAdresu = adresForAllView.IdAdresu;
            PracownikKodPocztowy = adresForAllView.KodPocztowy;
            PracownikMiasto = adresForAllView.Miasto;
            PracownikUlica = adresForAllView.Ulica;
            PracownikNumerDomu = adresForAllView.NumerDomu;
            PracownikNumerMieszkania = adresForAllView.NumerMieszkania;
            PracownikKraj = adresForAllView.NazwaKraju;
        }
        #endregion
    }
}
