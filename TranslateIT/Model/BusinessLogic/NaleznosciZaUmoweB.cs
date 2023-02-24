using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class NaleznosciZaUmoweB : DatabaseClass
    {
        #region Konstruktor
        public NaleznosciZaUmoweB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }
        #endregion

        #region BusinessFunction
        public decimal? StawkaZaUmowe(int idUmowy)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                where
                    pozycja.IdUmowy == idUmowy &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto - pozycja.Zaliczka
                ).Sum();
        }
        #endregion
    }
}
