using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class ProjektFakturaPracownikB : DatabaseClass
    {
        #region Konstruktor

        public ProjektFakturaPracownikB(TranslateITEntities4 translateITEntities)
            : base(translateITEntities)
        {
        }

        #endregion

        #region BusinessFunction
        public decimal? FakturaPracownikFilmy(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                join film in TranslateITEntities.Film on pozycja.IdProjektu equals film.IdProjektu
                where
                    pozycja.IdProjektu == film.IdProjektu &&
                    pozycja.Faktura.IdPracownika == idPracownika &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        public decimal? FakturaPracownikOdcinki(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                join odcinki in TranslateITEntities.Odcinki on pozycja.IdProjektu equals odcinki.IdProjektu
                where
                    pozycja.IdProjektu == odcinki.IdProjektu &&
                    pozycja.Faktura.IdPracownika == idPracownika &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        public decimal? ZarobkiPracownikaZaOkres(int idPracownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                where
                    pozycja.Faktura.IdPracownika == idPracownika &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.StawkaBrutto * pozycja.Ilosc
                ).Sum();
        }
        public decimal? StanBudzetuZaProjekt(int idProjektu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in TranslateITEntities.PozycjaFaktury
                join pozycjaUmowy in TranslateITEntities.PozycjaUmowy on pozycja.IdProjektu equals pozycjaUmowy.IdProjektu
                where
                    pozycja.IdProjektu == idProjektu &&
                    pozycja.IdProjektu == pozycjaUmowy.IdProjektu &&
                    pozycja.Faktura.DataWystawienia >= dataOd &&
                    pozycja.Faktura.TerminPlatnosci <= dataDo &&
                    pozycja.CzyAktywna == true
                select
                    pozycja.Projekt.Budzet -(pozycja.Ilosc*pozycja.StawkaBrutto+pozycjaUmowy.StawkaBrutto*pozycjaUmowy.Ilosc)
                ).Sum();
        }
        #endregion
    }
}