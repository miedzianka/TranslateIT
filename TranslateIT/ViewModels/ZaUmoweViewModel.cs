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
    public class ZaUmoweViewModel : WorkspaceViewModel
    {
        #region Properties
        public TranslateITEntities4 TranslateITEntities { get; set; }
        private int _IdUmowy;
        private decimal? _Naleznosc;

        public int IdUmowy
        {
            get { return _IdUmowy;}
            set
            {
                if(value !=_IdUmowy) 
                    _IdUmowy= value;
                OnPropertyChanged(() => IdUmowy);
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

        public IQueryable<KeyAndValue> UmowyComboBoxItems
        {
            get
            {
                return new UmowaB(TranslateITEntities).GetAktywneUmowy();
            }
        }

        #endregion

        #region Helpers
        private void ObliczNaleznoscClick()
        {
            Naleznosc = new NaleznosciZaUmoweB(TranslateITEntities).StawkaZaUmowe(IdUmowy);
        }
        #endregion 
        #region Konstruktor
        public ZaUmoweViewModel()
        {
            base.DisplayName = "Naleznosci za umowe";
            TranslateITEntities = new TranslateITEntities4();
            Naleznosc = 0;
        }
        #endregion
    }
}
