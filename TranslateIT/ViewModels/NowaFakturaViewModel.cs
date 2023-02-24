using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.Model.Validators;
using TranslateIT.ViewModels.Abstract;
using TranslateIT.ViewResources;

namespace TranslateIT.ViewModels
{
    public class NowaFakturaViewModel:OneViewModel<Faktura>, IDataErrorInfo
    {
        #region Constructor
        public NowaFakturaViewModel()
            :base("Faktura")
        {
            Item = new Faktura();
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
            Messenger.Default.Send("PracownicyAll");
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
                    base.OnPropertyChanged(()=> Numer);
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
                            select new KeyAndValue
                            {
                                Key = firma.IdFirmy,
                                Value = firma.SkroconaNazwa + " " + firma.NIP
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
                try
                {

                    return
                        (
                            from pracownik in Db.Pracownik
                            select new KeyAndValue
                            {
                                Key = pracownik.IdPracownika,
                                Value = pracownik.Imie + " " + pracownik.Nazwisko_a + " " + pracownik.NIP
                            }
                        ).ToList().AsQueryable();
                }
                catch
                {
                    return null;
                }
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
        private string _FirmaKraj;
        public string FirmaKraj
        {
            get
            {
                return _FirmaKraj;
            }
            set
            {
                if (value != _FirmaKraj)
                {
                    _FirmaKraj = value;
                    base.OnPropertyChanged(() => _FirmaKraj);
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
        private string _FirmaNrDomu;
        public string FirmaNrDomu
        {
            get
            {
                return _FirmaNrDomu;
            }
            set
            {
                if (value != _FirmaNrDomu)
                {
                    _FirmaNrDomu = value;
                    base.OnPropertyChanged(() => _FirmaNrDomu);
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
                if (value != _FirmaKodPocztowy)
                {
                    _FirmaKodPocztowy = value;
                    base.OnPropertyChanged(() => _FirmaKodPocztowy);
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
                    komunikat = BusinessValidator.SprawdzNumerFaktury(Numer);
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
            Db.Faktura.AddObject(Item);
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
            FirmaKraj = firmyForAllView.FirmaKraj;
            FirmaUlica = firmyForAllView.FirmaUlica;
            FirmaMiasto= firmyForAllView.FirmaMiasto;
            FirmaNrDomu= firmyForAllView.FirmaNrDomu;
            FirmaKodPocztowy= firmyForAllView.FirmaKodPocztowy;
        }
        private void GetWybranyPracownik(PracownikForAllView pracownikForAllView)
        {
            PracownikId = pracownikForAllView.IdPracownika;
            Imie = pracownikForAllView.Imie;
            Nazwisko = pracownikForAllView.Nazwisko;
        }
        #endregion
    }
}
