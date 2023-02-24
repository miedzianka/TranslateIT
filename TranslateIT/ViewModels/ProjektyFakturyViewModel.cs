using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.BusinessLogic;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels
{
    public class ProjektyFakturyViewModel: WorkspaceViewModel
    {
        #region Properties
        public TranslateITEntities4 TranslateITEntities { get; set; }
        private DateTime _DataOd;
        private DateTime _DataDo;

        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (value != _DataOd)
                    _DataOd = value;
                OnPropertyChanged(() => DataOd);
            }
        }
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (value != _DataDo)
                    _DataDo = value;
                OnPropertyChanged(() => DataDo);
            }
        }

        private int _IdFirmy;        
        private decimal? _ZaFilmyFirma;
        private decimal? _ZaOdcinkiFirma;
        private decimal? _BudzetFirma;

        public int IdFirmy
        {
            get { return _IdFirmy; }
            set
            {
                if (value!= _IdFirmy) 
                    _IdFirmy = value; 
                OnPropertyChanged(() => IdFirmy);
            }
        }
        public decimal? ZaFilmyFirma
        {
            get { return _ZaFilmyFirma; }
            set
            {
                if (value != _ZaFilmyFirma)
                    _ZaFilmyFirma = value;
                OnPropertyChanged(() => _ZaFilmyFirma);
            }
        }
        public decimal? ZaOdcinkiFirma
        {
            get { return _ZaOdcinkiFirma; }
            set
            {
                if (value != _ZaOdcinkiFirma)
                    _ZaOdcinkiFirma = value;
                OnPropertyChanged(() => _ZaOdcinkiFirma);
            }
        }
        public decimal? BudzetFirma
        {
            get { return _BudzetFirma; }
            set
            {
                if (value != _BudzetFirma)
                    _BudzetFirma = value;
                OnPropertyChanged(() => _BudzetFirma);
            }
        }

        private int _IdPracownika;
        private decimal? _ZaFilmyPracownik;
        private decimal? _ZaOdcinkiPracownik;
        private decimal? _ZarobkiPracownik;
        private decimal? _StanBudzetu;
        public int IdPracownika
        {
            get { return _IdPracownika; }
            set
            {
                if (value != _IdPracownika)
                    _IdPracownika = value;
                OnPropertyChanged(() => _IdPracownika);
            }
        }
        public decimal? ZaFilmyPracownik
        {
            get { return _ZaFilmyPracownik; }
            set
            {
                if (value != _ZaFilmyPracownik)
                    _ZaFilmyPracownik = value;
                OnPropertyChanged(() => _ZaFilmyPracownik);
            }
        }
        public decimal? ZaOdcinkiPracownik
        {
            get { return _ZaOdcinkiPracownik; }
            set
            {
                if (value != _ZaOdcinkiPracownik)
                    _ZaOdcinkiPracownik = value;
                OnPropertyChanged(() => _ZaOdcinkiPracownik);
            }
        }
        public decimal? ZarobkiPracownik
        {
            get { return _ZarobkiPracownik; }
            set
            {
                if (value != _ZarobkiPracownik)
                    _ZarobkiPracownik = value;
                OnPropertyChanged(() => _ZarobkiPracownik);
            }
        }
        public decimal? StanBudzetu
        {
            get { return _StanBudzetu; }
            set
            {
                if (value != _StanBudzetu)
                    _StanBudzetu = value;
                OnPropertyChanged(() => _StanBudzetu);
            }
        }
        #endregion
        #region Company Commands
        private BaseCommand _ObliczFilmFirmaCommand;
        public ICommand ObliczFIlmFirmaCommand
        {
            get
            {
                if (_ObliczFilmFirmaCommand == null)
                {
                    _ObliczFilmFirmaCommand = new BaseCommand(() => ObliczFilmyFirmaClick());

                    return _ObliczFilmFirmaCommand;
                }
                return _ObliczFilmFirmaCommand;

            }
        }
        private BaseCommand _ObliczOdcinkiFirmaCommand;
        public ICommand ObliczOdcinkiFirmaCommand
        {
            get
            {
                if (_ObliczOdcinkiFirmaCommand == null)
                {
                    _ObliczOdcinkiFirmaCommand = new BaseCommand(() => ObliczOdcinkiFirmaClick());

                    return _ObliczOdcinkiFirmaCommand;
                }
                return _ObliczOdcinkiFirmaCommand;

            }
        }
        private BaseCommand _ObliczBudzetFirmaCommand;
        public ICommand ObliczBudzetFirmaCommand
        {
            get
            {
                if (_ObliczBudzetFirmaCommand == null)
                {
                    _ObliczBudzetFirmaCommand = new BaseCommand(() => ObliczBudzetFirmaClick());

                    return _ObliczBudzetFirmaCommand;
                }
                return _ObliczBudzetFirmaCommand;

            }
        }
        public IQueryable<KeyAndValue> FirmaComboBoxItems
        {
            get
            {
                return new FirmaB(TranslateITEntities).GetAktywneFirmy();
            }
        }
        #endregion
        #region Worker Commands
        private BaseCommand _ObliczFilmPracownikCommand;
        public ICommand ObliczFilmPracownikCommand
        {
            get
            {
                if (_ObliczFilmPracownikCommand == null)
                {
                    _ObliczFilmPracownikCommand = new BaseCommand(() => ObliczFilmyPracownikClick());

                    return _ObliczFilmPracownikCommand;
                }
                return _ObliczFilmPracownikCommand;

            }
        }
        private BaseCommand _ObliczOdcinkiPracownikCommand;
        public ICommand ObliczOdcinkiPracownikCommand
        {
            get
            {
                if (_ObliczOdcinkiPracownikCommand == null)
                {
                    _ObliczOdcinkiPracownikCommand = new BaseCommand(() => ObliczOdcinkiPracownikClick());

                    return _ObliczOdcinkiPracownikCommand;
                }
                return _ObliczOdcinkiPracownikCommand;

            }
        }
        private BaseCommand _ObliczZarobkiPracownikaCommand;
        public ICommand ObliczZarobkiPracownikaCommand
        {
            get
            {
                if (_ObliczZarobkiPracownikaCommand == null)
                {
                    _ObliczZarobkiPracownikaCommand = new BaseCommand(() => ObliczZarobkiPracownikaClick());

                    return _ObliczZarobkiPracownikaCommand;
                }
                return _ObliczZarobkiPracownikaCommand;

            }
        }
        private BaseCommand _SprawdzStanBudzetuZaProjektCommand;
        public ICommand SprawdzStanBudzetuZaProjektCommand
        {
            get
            {
                if (_SprawdzStanBudzetuZaProjektCommand == null)
                {
                    _SprawdzStanBudzetuZaProjektCommand = new BaseCommand(() => StanBudzetuClick());

                    return _SprawdzStanBudzetuZaProjektCommand;
                }
                return _SprawdzStanBudzetuZaProjektCommand;

            }
        }
        public IQueryable<KeyAndValue> PracownicyComboBoxItems
        {
            get
            {
                return new PracownikB(TranslateITEntities).GetAktywniPracownicy();
            }
        }
        #endregion
        #region Helpers Workers
        private void ObliczFilmyPracownikClick()
        {
            ZaFilmyPracownik = new ProjektFakturaPracownikB(TranslateITEntities).FakturaPracownikFilmy(IdFirmy, DataOd, DataDo);
        }
        private void ObliczOdcinkiPracownikClick()
        {
            ZaOdcinkiPracownik = new ProjektFakturaPracownikB(TranslateITEntities).FakturaPracownikOdcinki(IdFirmy, DataOd, DataDo);
        }
        private void ObliczZarobkiPracownikaClick()
        {
            ZarobkiPracownik = new ProjektFakturaPracownikB(TranslateITEntities).ZarobkiPracownikaZaOkres(IdFirmy, DataOd, DataDo);
        }
        private void StanBudzetuClick()
        {
            StanBudzetu = new ProjektFakturaPracownikB(TranslateITEntities).StanBudzetuZaProjekt(IdFirmy, DataOd, DataDo);
        }
        #endregion
        #region Helpers Company
        private void ObliczFilmyFirmaClick()
        {
            ZaFilmyFirma = new ProjektFakturaFirmaB(TranslateITEntities).FakturaFirmaFilmy(IdFirmy, DataOd, DataDo);
        }
        private void ObliczOdcinkiFirmaClick()
        {
            ZaOdcinkiFirma = new ProjektFakturaFirmaB(TranslateITEntities).FakturaFirmaOdcinki(IdFirmy, DataOd, DataDo);
        }
        private void ObliczBudzetFirmaClick()
        {
            BudzetFirma = new ProjektFakturaFirmaB(TranslateITEntities).BudzetFirmy(IdFirmy, DataOd, DataDo);
        }
        #endregion
        #region Constructor
        public ProjektyFakturyViewModel()
        {
            base.DisplayName = "Faktury za projekty";
            TranslateITEntities = new TranslateITEntities4();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            ZaFilmyFirma = 0;
            ZaOdcinkiFirma = 0;
            BudzetFirma = 0;
            ZaFilmyPracownik = 0;
            ZaOdcinkiPracownik = 0;
            ZarobkiPracownik = 0;
            StanBudzetu = 0;
        }
        #endregion
    }
}
