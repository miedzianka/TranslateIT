using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class UmowyForAllView
    {
        #region Properties
        public int IdUmowy { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string ImiePracownika { get; set; }
        public string NazwiskaPracownika { get; set; }
        public string AdresPracownika { get; set; }
        //nizej znajduja sie pola ktore zastepuja klucz obcy idKontrahenta
        public string FirmaNIP { get; set; }
        public byte[] FirmaLogo { get; set; }
        public string FirmaNazwa { get; set; }
        public string FirmaAdres { get; set; }

        //koniec pol ktore zastepuja idkontrahenta
        //pola zastepujace IdPracownika
        public DateTime? TerminPlatnosci { get; set; }
        public string RodzajUmowy { get; set; }
        //teraz tak samo z idSposobuPlatnosci
        public string SposobPlatnosciNazwa { get; set; }
        #endregion
    }
}
