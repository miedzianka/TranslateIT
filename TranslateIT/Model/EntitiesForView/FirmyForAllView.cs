using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class FirmyForAllView
    {
        public int? IdFirma { get; set; }
        public string FirmaSkroconaNazwa { get; set; }
        public string FirmaNazwa { get; set; }
        public string FirmaNIP { get; set; }
        public string FirmaKraj { get; set; }
        public string FirmaUlica { get; set; }
        public string FirmaMiasto { get; set; }
        public string FirmaNrDomu { get; set; }
        public string FirmaKodPocztowy { get; set; }
        public string FirmaREGON { get; set; }
        public string FirmaFAX { get; set; }
        public string StronaWWW { get; set; }
        public string Email { get; set; }
        public bool? CzyOsobaFizyczna { get; set; }
    }
}
