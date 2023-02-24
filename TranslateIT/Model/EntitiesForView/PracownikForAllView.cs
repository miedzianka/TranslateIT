using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.EntitiesForView
{
    public class PracownikForAllView
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string NrKonta { get; set; }
        public string Bank { get; set; }
        public bool? StatusStudenta { get; set; }
        public string Email { get; set; }
        public string NrTelefonu1 { get; set; }
        public string Adres { get; set; }
        public string KrajPracownika { get; set; }
        public string UlicaPracownik { get; set; }
        public string MiastoPracownika { get; set; }
        public string NrDomuPracownika { get; set; }
        public string PracownikNrMieszkania { get; set; }
        public string KodPocztowyPracownika { get; set; }
        public DateTime? DataNawiazanieWspolpracy { get; set; }
        public string Firma { get; set; }

    }
}
