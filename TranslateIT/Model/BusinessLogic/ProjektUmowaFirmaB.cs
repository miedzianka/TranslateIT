using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class ProjektUmowaFirmaB : DatabaseClass
    {
        #region Konstruktor

        public ProjektUmowaFirmaB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }

        #endregion

        #region BusinessFunction
        public decimal? UmowaFirmaFilmy(int idFirmy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                join film in TranslateITEntities.Film on pozycja.IdProjektu equals film.IdProjektu
                where
                    pozycja.IdProjektu == film.IdProjektu &&
                    pozycja.Umowa.IdFirmy == idFirmy &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto
                ).Sum();
        }
        public decimal? UmowaFirmaOdcinki(int idFirmy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                join odcinki in TranslateITEntities.Odcinki on pozycja.IdProjektu equals odcinki.IdProjektu
                where
                    pozycja.IdProjektu == odcinki.IdProjektu &&
                    pozycja.Umowa.IdFirmy == idFirmy &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto
                ).Sum();
        }
        
        public decimal? StanBudzetuZaProjekt(int idProjektu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaUmowy
                join pozycjaUmowy in TranslateITEntities.PozycjaUmowy on pozycja.IdProjektu equals pozycjaUmowy.IdProjektu
                where
                    pozycja.IdProjektu == idProjektu &&
                    pozycja.IdProjektu == pozycjaUmowy.IdProjektu &&
                    pozycja.Umowa.DataWystawienia >= dataOd &&
                    pozycja.Umowa.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.Projekt.Budzet - (pozycja.Ilosc * pozycja.StawkaBrutto + pozycjaUmowy.StawkaBrutto * pozycjaUmowy.Ilosc)
                ).Sum();
        }
        #endregion
    }
}
