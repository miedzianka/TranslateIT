using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;
using TranslateIT.Model.EntitiesForView;


namespace TranslateIT.Model.BusinessLogic
{
    class FakturaB :DatabaseClass
    {
        #region Constructor
        public FakturaB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneFaktury()
        {
            return
                (
                    from faktury in TranslateITEntities.Faktura
                    where faktury.CzyAktywna == true
                    select new KeyAndValue
                    {
                        Key = faktury.IdFaktury,
                        Value = faktury.Numer +  " " + faktury.DaneFirmy.SkroconaNazwa + " " + faktury.Pracownik.Imie + " " + faktury.Pracownik.Nazwisko_a

                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
