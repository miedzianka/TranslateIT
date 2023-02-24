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
    public class NowaUmowaViewModel : OneViewModel<Umowa>, IDataErrorInfo
    {
        #region Constructor

        public NowaUmowaViewModel()
            : base("Umowa")
        {
            Item = new Umowa();
            Messenger.Default.Register<FirmyForAllView>(this, GetWybranaFirma);
            Messenger.Default.Register<PracownikForAllView>(this, GetWybranyPracownik);
        }
        #endregion
        #region Commands
        private BaseCommand _ShowPracownicyCommand;
        public ICommand ShowPracownicyCommand
        {
            get
            {
                if (_ShowPracownicyCommand == null)
                {
                    _ShowPracownicyCommand = new BaseCommand(() => ShowPracownicy());
                }
                return _ShowPracownicyCommand;
            }
        }
        public void ShowPracownicy()
        {
            //Messenger.Default.Send("KontrahenciAll");
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
            //Messenger.Default.Send("KontrahenciAll");
        }
        #endregion
        #region Properties
        public string Numer
        {
            get
            {
                return Item.Numer;
            }
            set
            {
                if (Item.Numer != value)
                {
                    Item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return Item.DataWystawienia;
            }
            set
            {
                if (Item.DataWystawienia != value)
                {
                    Item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
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
                if (Item.IdFirmy != value)
                {
                    Item.IdFirmy = value;
                    base.OnPropertyChanged(() => IdFirmy);
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
        public int? IdPracownika
        {
            get
            {
                return Item.IdPracownika;
            }
            set
            {
                if (Item.IdPracownika != value)
                {
                    Item.IdPracownika = value;
                    base.OnPropertyChanged(() => IdPracownika);
                }
            }
        }

        public IQueryable<KeyAndValue> PracownicyComboBoxItems
        {
            get
            {
                return
                    (
                        from pracownik in Db.Pracownik
                        where pracownik.CzyAktywne == true
                        select new KeyAndValue
                        {
                            Key = pracownik.IdPracownika,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko_a + " " + pracownik.NIP
                        }
                    ).ToList().AsQueryable();
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return Item.TerminPlatnosci;
            }
            set
            {
                if (Item.TerminPlatnosci != value)
                {
                    Item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public bool? CzyZatwierdzona
        {
            get
            {
                return Item.CzyZatwierdzona;
            }
            set
            {
                if (Item.CzyZatwierdzona != value)
                {
                    Item.CzyZatwierdzona = value;
                    base.OnPropertyChanged(() => CzyZatwierdzona);
                }
            }
        }
        public int? IdSposobuPlatnosci
        {
            get
            {
                return Item.IdSposobuPlatnosci;
            }
            set
            {
                if (Item.IdSposobuPlatnosci != value)
                {
                    Item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public IQueryable<KeyAndValue> SposobyPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from platnosc in Db.SposobPlatnosci
                        where platnosc.CzyAktywna == true
                        select new KeyAndValue
                        {
                            Key = platnosc.IdSposobuPlatnosci,
                            Value = platnosc.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdRodzajuUmowy
        {
            get
            {
                return Item.IdRodzajuUmowy;
            }
            set
            {
                if (Item.IdRodzajuUmowy != value)
                {
                    Item.IdRodzajuUmowy = value;
                    base.OnPropertyChanged(() => IdRodzajuUmowy);
                }
            }
        }
        public IQueryable<KeyAndValue> RodzajeUmowyComboBoxItems
        {
            get
            {
                return
                    (
                        from rodzajUmowy in Db.RodzajUmowy
                        where rodzajUmowy.CzyAktywne == true
                        select new KeyAndValue
                        {
                            Key = rodzajUmowy.IdRodzajuUmowy,
                            Value = rodzajUmowy.Nazwa
                        }
                    ).ToList().AsQueryable();
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
        private string _FirmaREGON;
        public string FirmaREGON
        {
            get
            {
                return _FirmaREGON;
            }
            set
            {
                if (value != _FirmaREGON)
                {
                    _FirmaREGON = value;
                    base.OnPropertyChanged(() => _FirmaREGON);
                }
            }
        }
        private int? _IdPracownika;
        public int? PracownikId
        {
            get
            {
                return _IdPracownika;
            }
            set
            {
                if (value != _IdPracownika)
                {
                    _IdPracownika = value;
                    base.OnPropertyChanged(() => _IdPracownika);
                }
            }
        }
        private string _Imie;
        public string Imie
        {
            get
            {
                return _Imie;
            }
            set
            {
                if (value != _Imie)
                {
                    _Imie = value;
                    base.OnPropertyChanged(() => _Imie);
                }
            }
        }

        private string _Nazwisko;
        public string Nazwisko
        {
            get
            {
                return _Nazwisko;
            }
            set
            {
                if (value != _Nazwisko)
                {
                    _Nazwisko = value;
                    base.OnPropertyChanged(() => _Nazwisko);
                }
            }
        }
        private string _NumerKonta;
        public string NumerKonta
        {
            get
            {
                return _NumerKonta;
            }
            set
            {
                if (value != _NumerKonta)
                {
                    _NumerKonta = value;
                    base.OnPropertyChanged(() => _NumerKonta);
                }
            }
        }

        private string _Kraj;
        public string Kraj
        {
            get
            {
                return _Kraj;
            }
            set
            {
                if (value != _Kraj)
                {
                    _Kraj = value;
                    base.OnPropertyChanged(() => _Kraj);
                }
            }
        }
        private string _Ulica;
        public string Ulica
        {
            get
            {
                return _Ulica;
            }
            set
            {
                if (value != _Ulica)
                {
                    _Ulica = value;
                    base.OnPropertyChanged(() => _Ulica);
                }
            }
        }

        private string _Miasto;
        public string Miasto
        {
            get
            {
                return _Miasto;
            }
            set
            {
                if (value != _Miasto)
                {
                    _Miasto = value;
                    base.OnPropertyChanged(() => _Miasto);
                }
            }
        }
        private string _Pesel;
        public string Pesel
        {
            get
            {
                return _Pesel;
            }
            set
            {
                if (value != _Pesel)
                {
                    _Pesel = value;
                    base.OnPropertyChanged(() => _Pesel);
                }
            }
        }
        private string _NrDomu;
        public string NrDomu
        {
            get
            {
                return _NrDomu;
            }
            set
            {
                if (value != _NrDomu)
                {
                    _NrDomu = value;
                    base.OnPropertyChanged(() => _NrDomu);
                }
            }
        }
        private string _NrMieszkania;
        public string NrMieszkania
        {
            get
            {
                return _NrMieszkania;
            }
            set
            {
                if (value != _NrMieszkania)
                {
                    _NrMieszkania = value;
                    base.OnPropertyChanged(() => _NrMieszkania);
                }
            }
        }

        private string _KodPocztowy;
        public string KodPocztowy
        {
            get
            {
                return _KodPocztowy;
            }
            set
            {
                if (value != _KodPocztowy)
                {
                    _KodPocztowy = value;
                    base.OnPropertyChanged(() => _KodPocztowy);
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
                if (name == "Numer")
                    komunikat = BusinessValidator.SprawdzNumerUmowy(Numer);
                if (name == "DataPlatnosci")
                    komunikat = BusinessValidator.JestWczesniej(DataWystawienia, TerminPlatnosci);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Numer"] == null && this["DataPlatnosci"]==null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Db.Umowa.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranaFirma(FirmyForAllView firmyForAllView)
        {
            IdFirma = firmyForAllView.IdFirma;
            FirmaNazwa = firmyForAllView.FirmaNazwa;
            FirmaNIP = firmyForAllView.FirmaNIP;
            FirmaREGON = firmyForAllView.FirmaREGON;
        }
        private void GetWybranyPracownik(PracownikForAllView pracownikForAllView)
        {
            PracownikId = pracownikForAllView.IdPracownika;
            Imie = pracownikForAllView.Imie;
            Nazwisko = pracownikForAllView.Nazwisko;
            NumerKonta = pracownikForAllView.NrKonta;
            Pesel = pracownikForAllView.Pesel;
            Kraj = pracownikForAllView.KrajPracownika;
            Ulica = pracownikForAllView.UlicaPracownik;
            Miasto = pracownikForAllView.MiastoPracownika;
            NrDomu = pracownikForAllView.NrDomuPracownika;
            KodPocztowy = pracownikForAllView.KodPocztowyPracownika;
            NrMieszkania = pracownikForAllView.PracownikNrMieszkania;
        }
        #endregion
    }
}