using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class PracownikB : DatabaseClass
    {
        #region Constructor
        public PracownikB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {

        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywniPracownicy()
        {
            return
                (
                    from pracownik in TranslateITEntities.Pracownik
                    where pracownik.CzyAktywne == true
                    select new KeyAndValue
                    {
                        Key = pracownik.IdPracownika,
                        Value = pracownik.Imie + " " + pracownik.Nazwisko_a
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
