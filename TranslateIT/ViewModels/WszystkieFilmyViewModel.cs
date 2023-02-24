using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels
{
    public class WszystkieFilmyViewModel : AllViewModel<FilmyForAllVIew>
    {
        public WszystkieFilmyViewModel()
            :base("Filmy")
        {
        }
        #region Properties
        private PracownikForAllView _WybranyFilm;
        public PracownikForAllView WybranyFilm
        {
            get
            {
                return _WybranyFilm;
            }
            set
            {
                if (_WybranyFilm != value)
                {
                    _WybranyFilm = value;
                    Messenger.Default.Send(_WybranyFilm);
                    // zamykamy okno z kontrahentami
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FilmyForAllVIew>
                (
                    from film in TranslateITEntities.Film
                    where film.CzyAktywne==true
                    select new FilmyForAllVIew
                    {
                        IdProjektu = film.IdProjektu,
                        IdFilmu =film.IdFilmu,
                        OriginalTitle = film.OryginalnyTytuł,
                        TranslateTitle = film.TutulFilmu,
                        NameCode = film.NameCode,
                        Akty = film.Akty,
                        Linijki= film.Linijki,
                        Postacie = film.Postacie,
                        NazwaFirmy = film.DaneFirmy.SkroconaNazwa,
                        NIP = film.DaneFirmy.NIP,
                        KrajPochodzenia = film.Kraj.NazwaKraju,
                        RokProdukcji = film.RokProdukcji,
                        Deadline= film.Deadline,
                        DataPremiery= film.DataPremiery,
                        OpisFilmu= film.OpisFilmu
                    }
                );
        }
        #endregion
        #region Sort and Filtr
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "OriginalTitle", "TranslateTitle", "NameCode", "NazwaFirmy", "KrajPochodzenia", "Deadline" };
        }
        public override void Sort()
        {
            if (SortField == "OriginalTitle")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.OriginalTitle));
            }
            if (SortField == "TranslateTitle")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.TranslateTitle));
            }
            if (SortField == "NameCode")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.NameCode));
            }
            if (SortField == "NazwaFirmy")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.NazwaFirmy));
            }
            if (SortField == "KrajPochodzenia")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.KrajPochodzenia));
            }
            if (SortField == "Deadline")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.OrderBy(Item => Item.Deadline));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "OriginalTitle", "TranslateTitle", "NameCode", "NazwaFirmy",
                "KrajPochodzenia", "NIP" };
        }
        public override void Find()
        {
            if (FindField == "OriginalTitle")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.OriginalTitle != null && Item.OriginalTitle.StartsWith(FindTextBox)));
            }
            if (FindField == "TranslateTitle")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.TranslateTitle != null && Item.TranslateTitle.StartsWith(FindTextBox)));
            }
            if (FindField == "NameCode")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.NameCode != null && Item.NameCode.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwaFirmy")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.NazwaFirmy != null && Item.NazwaFirmy.StartsWith(FindTextBox)));
            }
            if (FindField == "KrajPochodzenia")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.KrajPochodzenia != null && Item.KrajPochodzenia.StartsWith(FindTextBox)));
            }
            if (FindField == "NIP")
            {
                List = new ObservableCollection<FilmyForAllVIew>(List.Where(Item => Item.NIP != null && Item.NIP.StartsWith(FindTextBox)));
            }
        }
        #endregion
    }
}
