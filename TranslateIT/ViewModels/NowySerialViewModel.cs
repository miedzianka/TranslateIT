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
    public class NowySerialViewModel : OneViewModel<Serial>, IDataErrorInfo
    {
        #region Constructor
        public NowySerialViewModel()
            : base("Serial")
        {
            Item = new Serial();
        }

        #endregion
        #region Properties
        public string OryginalyTytul
        {
            get
            {
                return Item.OryginalnyTytul;

            }
            set
            {
                if (value != Item.OryginalnyTytul)
                {
                    Item.OryginalnyTytul = value;
                    base.OnPropertyChanged(() => OryginalyTytul);
                }
            }
        }
        public string TytulSerialuTlumaczenie
        {
            get
            {
                return Item.TytułSerialuTlumaczenie;

            }
            set
            {
                if (value != Item.TytułSerialuTlumaczenie)
                {
                    Item.TytułSerialuTlumaczenie = value;
                    base.OnPropertyChanged(() => TytulSerialuTlumaczenie);
                }
            }
        }
        public string NameCode
        {
            get
            {
                return Item.NameCode;

            }
            set
            {
                if (value != Item.NameCode)
                {
                    Item.NameCode = value;
                    base.OnPropertyChanged(() => NameCode);
                }
            }
        }
        public decimal? OcenaFilmweb
        {
            get
            {
                return Item.OcenaFilmweb;

            }
            set
            {
                if (value != Item.OcenaFilmweb)
                {
                    Item.OcenaFilmweb = value;
                    base.OnPropertyChanged(() => OcenaFilmweb);
                }
            }
        }
        public string WWWFilmweb
        {
            get
            {
                return Item.WWWDoFilmweb;

            }
            set
            {
                if (value != Item.WWWDoFilmweb)
                {
                    Item.WWWDoFilmweb = value;
                    base.OnPropertyChanged(() => WWWFilmweb);
                }
            }
        }
        public DateTime? TlumaczoneOd
        {
            get
            {
                return Item.TlumaczoneOd;

            }
            set
            {
                if (value != Item.TlumaczoneOd)
                {
                    Item.TlumaczoneOd = value;
                    base.OnPropertyChanged(() => TlumaczoneOd);
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
        public bool? CzyNadalNagrywamy
        {
            get
            {
                return Item.CzyNadalNagrywany;

            }
            set
            {
                if (value != Item.CzyNadalNagrywany)
                {
                    Item.CzyNadalNagrywany = value;
                    base.OnPropertyChanged(() => CzyNadalNagrywamy);
                }
            }
        }
        public int? IdKrajProdukcji
        {
            get
            {
                return Item.IdKrajProdukcji;

            }
            set
            {
                if (value != Item.IdKrajProdukcji)
                {
                    Item.IdKrajProdukcji = value;
                    base.OnPropertyChanged(() => IdKrajProdukcji);
                }
            }
        }
        public IQueryable<KeyAndValue> KrajProdukcjiComboBoxItems
        {
            get
            {
                return
                    (
                        from kraj in Db.Kraj
                        select new KeyAndValue
                        {
                            Key = kraj.IdKraju,
                            Value = kraj.NazwaKraju
                        }
                    ).ToList().AsQueryable();
            }
        }
        public string Opis
        {
            get
            {
                return Item.Opis;

            }
            set
            {
                if (value != Item.Opis)
                {
                    Item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
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
                if (name == "OryginalnyTytul")
                    komunikat = StringValidator.IsUpperCase(OryginalyTytul);
                if (name == "TytulSerialuTlumaczenie")
                    komunikat = StringValidator.IsUpperCase(TytulSerialuTlumaczenie);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["OryginalnyTytul"] == null && this["TytulSerialuTlumaczenie"] == null)
                return true;
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.Serial.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
