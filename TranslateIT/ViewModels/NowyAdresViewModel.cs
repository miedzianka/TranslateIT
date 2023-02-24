using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.Model.Validators;
using TranslateIT.ViewModels.Abstract;

namespace TranslateIT.ViewModels
{
    public class NowyAdresViewModel : OneViewModel<Adres>, IDataErrorInfo
    {
        public NowyAdresViewModel() : base("Adres")
        {
            Item = new Adres();
        }
        #region Properties
        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (Item.Ulica != value)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NumerDomu
        {
            get
            {
                return Item.NumerDomu;
            }
            set
            {
                if (Item.NumerDomu != value)
                {
                    Item.NumerDomu = value;
                    base.OnPropertyChanged(() => NumerDomu);
                }
            }
        }
        public string NumerMieszkania
        {
            get
            {
                return Item.NumerMieszkania;
            }
            set
            {
                if (Item.NumerMieszkania != value)
                {
                    Item.NumerMieszkania = value;
                    base.OnPropertyChanged(() => NumerMieszkania);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (Item.KodPocztowy != value)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Miasto
        {
            get
            {
                return Item.Miasto;
            }
            set
            {
                if (Item.Miasto != value)
                {
                    Item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return Item.Poczta;
            }
            set
            {
                if (Item.Poczta != value)
                {
                    Item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }
        public int? IdKraju
        {
            get
            {
                return Item.IdKraju;
            }
            set
            {
                if (Item.IdKraju != value)
                {
                    Item.IdKraju = value;
                    base.OnPropertyChanged(() => IdKraju);
                }
            }
        }
        public IQueryable<KeyAndValue> KrajeComboBoxItems
        {
            get
            {
                return
                    (
                        from kraje in Db.Kraj
                        where kraje.czyAktywne == true
                        select new KeyAndValue
                        {
                            Key = kraje.IdKraju,
                            Value = kraje.NazwaKraju
                        }
                    ).ToList().AsQueryable();
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
                if (name == "Ulica")
                    komunikat = StringValidator.IsUpperCase(Ulica);
                if (name == "Miasto")
                    komunikat = StringValidator.IsUpperCase(Miasto);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Ulica"] == null && this["Miasto"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.czyAktywne = true;
            Db.Adres.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
