using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class FilmyForAllVIew
    {
        public int? IdFilmu { get; set; }
        public int? IdProjektu { get; set; }
        public string OriginalTitle { get; set; }
        public string TranslateTitle { get; set; }
        public string NameCode { get; set; }
        public int? Akty { get; set; }
        public int? Linijki { get; set; }
        public int? Postacie { get; set; }
        public string NazwaFirmy { get; set; }
        public string NIP { get; set; }
        public string KrajPochodzenia { get; set; }
        public int? RokProdukcji { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? DataPremiery { get; set; }
        public string OpisFilmu { get; set; }

    }
}
