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
    public class DodajDoFakturyViewModel : OneViewModel<PozycjaFaktury>, IDataErrorInfo
    {
        #region Constructor
        public DodajDoFakturyViewModel()
            : base("Dodaj do faktury")
        {
            Item = new PozycjaFaktury();
            Messenger.Default.Register<FakturyForAllView>(this, GetWybranaFaktura);
            Messenger.Default.Register<OdcinkiForAllView>(this, GetWybranyOdcinekProjekt);
            Messenger.Default.Register<FilmyForAllVIew>(this, GetWybranyFilmProjekt);
        }

        #endregion
        #region Commands

        private BaseCommand _ShowFakturyCommand;
        public ICommand ShowFakturyCommand
        {
            get
            {
                if (_ShowFakturyCommand == null)
                {
                    _ShowFakturyCommand = new BaseCommand(() => ShowFaktury());
                }
                return _ShowFakturyCommand;
            }
        }

        public void ShowFaktury()
        { 
            Messenger.Default.Send("FakturyAll");
        }
        private BaseCommand _ShowOdcinkiCommand;
        public ICommand ShowOdcinkiCommand
        {
            get
            {
                if (_ShowOdcinkiCommand == null)
                {
                    _ShowOdcinkiCommand = new BaseCommand(() => ShowOdcinki());
                }
                return _ShowOdcinkiCommand;
            }
        }

        public void ShowOdcinki()
        {
            Messenger.Default.Send("OdcinkiAll");
        }
        private BaseCommand _ShowFilmyCommand;
        public ICommand ShowFilmyCommand
        {
            get
            {
                if (_ShowFilmyCommand == null)
                {
                    _ShowFilmyCommand = new BaseCommand(() => ShowFilmy());
                }
                return _ShowFilmyCommand;
            }
        }

        public void ShowFilmy()
        {
            Messenger.Default.Send("FilmyAll");
        }
        #endregion
        #region Properties
        public int? Ilosc
        {
            get
            {
                return Item.Ilosc;
            }
            set
            {
                if (Item.Ilosc != value)
                {
                    Item.Ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
                }
            }
        }
        public decimal? StawkaBrutto
        {
            get
            {
                return Item.StawkaBrutto;
            }
            set
            {
                if (Item.StawkaBrutto != value)
                {
                    Item.StawkaBrutto = value;
                    base.OnPropertyChanged(() => StawkaBrutto);
                }
            }
        }
        public decimal? StawkaNetto
        {
            get
            {
                return Item.StawkaNetto;
            }
            set
            {
                if (Item.StawkaNetto != value)
                {
                    Item.StawkaNetto = value;
                    base.OnPropertyChanged(() => StawkaNetto);
                }
            }
        }
        public decimal? VAT
        {
            get
            {
                return Item.VAT;
            }
            set
            {
                if (Item.VAT != value)
                {
                    Item.VAT = value;
                    base.OnPropertyChanged(() => VAT);
                }
            }
        }
        public decimal? Rabat
        {
            get
            {
                return Item.Rabat;
            }
            set
            {
                if (Item.Rabat != value)
                {
                    Item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
                }
            }
        }
        private string _TytulOdcinka;
        public string TytulOdcinka
        {
            get
            {
                return _TytulOdcinka;
            }
            set
            {
                if (value != _TytulOdcinka)
                {
                    _TytulOdcinka = value;
                    base.OnPropertyChanged(() => _TytulOdcinka);
                }
            }
        }
        private string _TytulFilmu;
        public string TytulFilmu
        {
            get
            {
                return _TytulFilmu;
            }
            set
            {
                if (value != _TytulFilmu)
                {
                    _TytulFilmu = value;
                    base.OnPropertyChanged(() => _TytulFilmu);
                }
            }
        }
        private string _NumerFaktury;
        public string NumerFaktury
        {
            get
            {
                return _NumerFaktury;
            }
            set
            {
                if (value != _NumerFaktury)
                {
                    _NumerFaktury = value;
                    base.OnPropertyChanged(() => _NumerFaktury);
                }
            }
        }
        private string _NazwaFirmy;
        public string NazwaFirmy
        {
            get
            {
                return _NazwaFirmy;
            }
            set
            {
                if (value != _NazwaFirmy)
                {
                    _NazwaFirmy = value;
                    base.OnPropertyChanged(() => _NazwaFirmy);
                }
            }
        }
        private string _ImiePracownika;
        public string ImiePracownika
        {
            get
            {
                return _ImiePracownika;
            }
            set
            {
                if (value != _ImiePracownika)
                {
                    _ImiePracownika = value;
                    base.OnPropertyChanged(() => _ImiePracownika);
                }
            }
        }
        private string _NazwiskoPracownika;
        public string NazwiskoPracownika
        {
            get
            {
                return _NazwiskoPracownika;
            }
            set
            {
                if (value != _NazwiskoPracownika)
                {
                    _NazwiskoPracownika = value;
                    base.OnPropertyChanged(() => _NazwiskoPracownika);
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
                if (name == "StawkaBrutto")
                    komunikat = BusinessValidator.StawkaNettoMniejsza(StawkaNetto, StawkaBrutto);
                if (name == "VAT")
                    komunikat = BusinessValidator.SprawdzVAT(VAT);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["StawkaBrutto"] == null && this["VAT"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Db.PozycjaFaktury.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranaFaktura(FakturyForAllView fakturyForAllView)
        {
            NumerFaktury = fakturyForAllView.Numer;
            NazwaFirmy = fakturyForAllView.FirmaSkroconaNazwa;
            ImiePracownika = fakturyForAllView.ImiePracownika;
            NazwiskoPracownika = fakturyForAllView.NazwiskaPracownika;
        }
        private void GetWybranyOdcinekProjekt(OdcinkiForAllView projektForAllView)
        {
            TytulOdcinka = projektForAllView.NazwaOdcinka;
            IdProjektu = projektForAllView.IdProjektu;
        }
        private void GetWybranyFilmProjekt(FilmyForAllVIew projektForAllView)
        {
            TytulFilmu = projektForAllView.OriginalTitle;
            IdProjektu = projektForAllView.IdProjektu;
        }
        #endregion
    }
}
