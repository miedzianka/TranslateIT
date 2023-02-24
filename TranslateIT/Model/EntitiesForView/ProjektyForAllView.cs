using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class ProjektyForAllView
    {
        public int? IdProjektu { get; set; }
        public string FirmaNazwa { get; set; }
        public string FirmaNIP { get; set; }
        public string DaneKoordynatorLektor { get; set; }
        public string DaneKoordynatorNapisy { get; set; }
        public string DaneKoordynatorDubbing { get; set; }
        public string DaneTlumaczLektor { get; set; }
        public string DaneTlumaczNapisy { get; set; }
        public string DaneTlumaczDubbing { get; set; }
        public string EtapProjektu { get; set; }
        public bool? CzyNapisy { get; set; }
        public bool? CzyLektor { get; set; }
        public bool? CzyDubbing { get; set; }
        public string JezykOryginalny { get; set; }
        public decimal? Budzet { get; set; }
    }
}
