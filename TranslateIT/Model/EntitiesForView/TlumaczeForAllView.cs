using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class TlumaczeForAllView
    {
        public int? IdTlumacza { get; set; }
        public int? IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string OpisTlumacza { get; set; }
    }
}
