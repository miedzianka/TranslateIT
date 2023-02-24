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
    public class ZaFaktureViewModel : WorkspaceViewModel
    {
        #region Properties
        public TranslateITEntities4 TranslateITEntities { get; set; }
        private int _IdFaktury;
        private decimal? _Naleznosc;

        public int IdFaktury
        {
            get { return _IdFaktury; }
            set
            {
                if (value != _IdFaktury)
                    _IdFaktury = value;
                OnPropertyChanged(() => IdFaktury);
            }
        }
        public decimal? Naleznosc
        {
            get { return _Naleznosc; }
            set
            {
                if (value != _Naleznosc)
                    _Naleznosc = value;
                OnPropertyChanged(() => Naleznosc);
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => ObliczNaleznoscClick());

                    return _ObliczCommand;
                }
                return _ObliczCommand;

            }
        }
        public IQueryable<KeyAndValue> FakturyComboBoxItems
        {
            get
            {
                return new FakturaB(TranslateITEntities).GetAktywneFaktury();
            }
        }
        #endregion
        #region Helpers
        private void ObliczNaleznoscClick()
        {
            Naleznosc = new NaleznosciZaFaktureB(TranslateITEntities).StawkaZaFakture(IdFaktury);
        }
        #endregion
        #region Konstruktor
        public ZaFaktureViewModel()
        {
            base.DisplayName = "Naleznosci za fakture";
            TranslateITEntities = new TranslateITEntities4();
            Naleznosc = 0;
        }
        #endregion
    }
}
