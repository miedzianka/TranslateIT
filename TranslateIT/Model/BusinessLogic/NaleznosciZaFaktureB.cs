using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class NaleznosciZaFaktureB : DatabaseClass
    {
        #region Konstruktor
        public NaleznosciZaFaktureB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }
        #endregion

        #region BusinessFunction
        public decimal? StawkaZaFakture(int idFaktury)
        {
            return
            (
                from pozycja in TranslateITEntities.PozycjaFaktury
                where
                    pozycja.IdFaktury == idFaktury &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto - pozycja.Rabat
                ).Sum();
        }
        #endregion
    }
}
