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
    public class NowySezonViewModel : OneViewModel<Sezony>, IDataErrorInfo
    {
        #region Constructor
        public NowySezonViewModel()
            : base("Sezon")
        {
            Item = new Sezony();
            Messenger.Default.Register<SerialeForAllView>(this, GetWybranySerial);
        }
        #endregion
        #region Commands
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
        #endregion
        #region Properties
        public string NazwaSezonu
        {
            get
            {
                return Item.NazwaSezonu;

            }
            set
            {
                if (value != Item.NazwaSezonu)
                {
                    Item.NazwaSezonu = value;
                    base.OnPropertyChanged(() => NazwaSezonu);
                }
            }
        }
        public int? NumerSezonu
        {
            get
            {
                return Item.NumerSezonu;

            }
            set
            {
                if (value != Item.NumerSezonu)
                {
                    Item.NumerSezonu = value;
                    base.OnPropertyChanged(() => NumerSezonu);
                }
            }
        }
        public int? IloscOdcinkow
        {
            get
            {
                return Item.IloscOdcinkow;

            }
            set
            {
                if (value != Item.IloscOdcinkow)
                {
                    Item.IloscOdcinkow = value;
                    base.OnPropertyChanged(() => IloscOdcinkow);
                }
            }
        }
        public string OpisSezonu
        {
            get
            {
                return Item.OpisSezonu;

            }
            set
            {
                if (value != Item.OpisSezonu)
                {
                    Item.OpisSezonu = value;
                    base.OnPropertyChanged(() => OpisSezonu);
                }
            }
        }
        public int? IloscPostaci
        {
            get
            {
                return Item.IloscPostaci;

            }
            set
            {
                if (value != Item.IloscPostaci)
                {
                    Item.IloscPostaci = value;
                    base.OnPropertyChanged(() => IloscPostaci);
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
                if (value != Item.DataProdukcji)
                {
                    Item.DataProdukcji = value;
                    base.OnPropertyChanged(() => DataProdukcji);
                }
            }
        }
        private int? _IdSerial;
        public int? IdSerial
        {
            get
            {
                return _IdSerial;
            }
            set
            {
                if (value != _IdSerial)
                {
                    _IdSerial = value;
                    base.OnPropertyChanged(() => _IdSerial);
                }
            }
        }
        private string _SerialNazwa;
        public string SerialNazwa
        {
            get
            {
                return _SerialNazwa;
            }
            set
            {
                if (value != _SerialNazwa)
                {
                    _SerialNazwa = value;
                    base.OnPropertyChanged(() => _SerialNazwa);
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
                if (name == "NazwaSezonu")
                    komunikat = StringValidator.IsUpperCase(NazwaSezonu);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaSezonu"] == null && this["TytulSerialuTlumaczenie"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.Sezony.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranySerial(SerialeForAllView serialeForAllView)
        {
            IdSerial = serialeForAllView.IdSerialu;
            SerialNazwa = serialeForAllView.TytulSerialu;
        }
        #endregion
    }
}
