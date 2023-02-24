using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class FirmaB: DatabaseClass
    {
        #region Constructor
        public FirmaB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {

        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneFirmy()
        {
            return
                (
                    from firmy in TranslateITEntities.DaneFirmy
                    where firmy.CzyAktywne==true
                    select new KeyAndValue
                    {
                        Key = firmy.IdFirmy,
                        Value = firmy.NazwaFirmy + " NIP:" +firmy.NIP
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
