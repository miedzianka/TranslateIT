using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class SerialeForAllView
    {
        #region Properties
        public int? IdSerialu { get; set; }
        public string OryginalnyTytul { get; set; }
        public byte[] LogoSerialu { get; set; }
        public string TytulSerialu { get; set; }
        public int? IloscSezonow { get; set; }
        public int? IloscOdcinkow { get; set; }
        public decimal? OcenaFilmweb { get; set; }
        public string WWWFilmweb { get; set; }
        public DateTime? DataProdukcji { get; set; }
        public bool? CzyNadalNagrywamy { get; set; }
        public DateTime? RokZakonczeniaProdukcji { get; set; }
        public string TlumaczoneDla { get; set; }
        public string KrajPochodzenia { get; set; }

        #endregion
    }
}
