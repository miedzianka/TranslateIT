using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class AdresForAllView
    {
        #region Properties
        public int? IdAdresu { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerMieszkania { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string Poczta { get; set; }
        public string NazwaKraju { get; set; }
        public int? IdKraju { get; set; }

        #endregion
    }
}
