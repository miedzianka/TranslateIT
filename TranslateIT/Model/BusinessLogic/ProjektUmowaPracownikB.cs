using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    class ProjektUmowaPracownikB : DatabaseClass
    {
        #region Konstruktor

        public ProjektUmowaPracownikB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }

        #endregion

        #region BusinessFunction
        public decimal? UmowaPracownikFilmy(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                join film in TranslateITEntities.Film on pozycja.IdProjektu equals film.IdProjektu
                where
                    pozycja.IdProjektu == film.IdProjektu &&
                    pozycja.Umowa.IdPracownika == idPracownika &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        public decimal? UmowaPracownikOdcinki(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                join odcinki in TranslateITEntities.Odcinki on pozycja.IdProjektu equals odcinki.IdProjektu
                where
                    pozycja.IdProjektu == odcinki.IdProjektu &&
                    pozycja.Umowa.IdPracownika == idPracownika &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        public decimal? ZarobkiPracownikaZaOkres(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                where
                    pozycja.Umowa.IdPracownika == idPracownika &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        #endregion
    }
}
