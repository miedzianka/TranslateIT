using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class FakturyForAllView
    {
        #region Properties
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string FirmaSkroconaNazwa { get; set; }
        public string FirmaNIP { get; set; }
        public byte[] FirmaLogo { get; set; }
        public string FirmaAdres { get; set; }
        public string ImiePracownika { get; set; }
        public string NazwiskaPracownika { get; set; }
        public string AdresPracownika { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        public string SposobPlatnosciNazwa { get; set; }
        #endregion
    }
}
