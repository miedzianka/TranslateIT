using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class OdcinkiForAllView
    {

        #region Properties
        public int? IdOdcinka { get; set; }
        public string NazwaOdcinka { get; set; }
        public int? NumerOdcinka { get; set; }
        public int? NumerSezonu { get; set; }
        public string NazwaSerialu { get; set; }
        public int? IdProjektu { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? DataProdukcji { get; set; }
        public int? Postacie { get; set; }
        public string OpisOdcinka { get; set; }
        public string DlugoscOdcinkaMIN { get; set; }
        public int? IloscLinijek { get; set; }
        public decimal? Budzet { get; set; } //to usunac!!!!
        public int? Akty { get; set; }


        #endregion
    }
}
