using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class ProjektFakturaFirmaB : DatabaseClass
    {
        #region Konstruktor

        public ProjektFakturaFirmaB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }

        #endregion

        #region BusinessFunction
        public decimal? FakturaFirmaFilmy(int idFirmy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                join film in TranslateITEntities.Film on pozycja.IdProjektu equals film.IdProjektu 
                where
                    pozycja.IdProjektu == film.IdProjektu &&
                    pozycja.Faktura.IdFirmy == idFirmy &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto
                ).Sum();
        }
        public decimal? FakturaFirmaOdcinki(int idFirmy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                join odcinki in TranslateITEntities.Odcinki on pozycja.IdProjektu equals odcinki.IdProjektu
                where
                    pozycja.IdProjektu == odcinki.IdProjektu &&
                    pozycja.Faktura.IdFirmy == idFirmy &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto
                ).Sum();
        }
        public decimal? BudzetFirmy(int idFirmy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                where
                    pozycja.Faktura.IdFirmy == idFirmy &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.Projekt.Budzet
                ).Sum();
        }
        #endregion
    }
}
