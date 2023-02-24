using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class RezyserzyForAllView
    {
        public int? IdRezysera { get; set; }
        public int? IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string OpisRezysera { get; set; }
    }
}
