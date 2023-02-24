using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class SezonyForAllView
    {
        public int? IdSezonu { get; set; }
        public string NazwaSerialu { get; set; }
        public int? NumerSezonu { get; set; }
        public string NazwaSezonu { get; set; }
        public int? IloscOdcinkow { get; set; }
        public string OpisSezonu { get; set; }
        public int? IloscPostaci { get; set; }
        public DateTime? DataProdukcji { get; set; }
    }
}
