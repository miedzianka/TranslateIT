using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;
using TranslateIT.Model.EntitiesForView;

namespace TranslateIT.Model.BusinessLogic
{
    class UmowaB : DatabaseClass
    {
        #region Constructor
        public UmowaB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {

        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneUmowy()
        {
            return
                (
                    from umowy in TranslateITEntities.Umowa
                    where umowy.CzyAktywna == true
                    select new KeyAndValue
                    {
                        Key = umowy.IdUmowy,
                        Value = umowy.Numer + " " + umowy.DaneFirmy.SkroconaNazwa + " " + umowy.Pracownik.Imie + " " + umowy.Pracownik.Nazwisko_a
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
