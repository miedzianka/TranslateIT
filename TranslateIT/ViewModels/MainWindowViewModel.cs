using TranslateIT.Helpers;
//using TranslateIT.ViewResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TranslateIT.ViewResources;
using GalaSoft.MvvmLight.Messaging;
using TranslateIT.Views;

namespace TranslateIT.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region PolaIWlasciwosci
        private int _SzerokoscKolumnyMenuBocznego;
        public int SzerokoscKolumnyMenuBocznego
        {
            get
            {
                return _SzerokoscKolumnyMenuBocznego;
            }
            set
            {
                if (_SzerokoscKolumnyMenuBocznego != value)
                {
                    _SzerokoscKolumnyMenuBocznego = value;
                    OnPropertyChanged(() => SzerokoscKolumnyMenuBocznego);
                }
            }
        }
        #endregion

        //będzie zawierała kolekcje komend, które pojawiają się w menu lewym oraz kolekcje zakładek 
        #region Komendy menu i paska narzedzi

       
        public ICommand NowaFakturaCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFakturaViewModel()));
            }
        }
        public ICommand NowaFirmaCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFirmaViewModel()));
            }
        }
        
        public ICommand NowySezonCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowySezonViewModel()));
            }
        }
        
        public ICommand NowyPracownikCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyPracownikViewModel()));
            }
        }
        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(showAllFaktury);
            }
        }
        public ICommand DaneFirmyCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFirmaViewModel()));
            }
        }
        public ICommand NowyAktorCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyAktorViewModel()));
            }
        }
        public ICommand NowyAdresCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyAdresViewModel()));
            }
        }
        public ICommand AktorzyCommand
        {
            get
            {
                return new BaseCommand(showAllAktorzy);
            }
        }
        public ICommand NowyRezyserCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyRezyserViewModel()));
            }
        }
        public ICommand RezyserzyCommand
        {
            get
            {
                return new BaseCommand(showAllRezyserzy);
            }
        }
        public ICommand NowyFilmCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyFilmViewModel()));
            }
        }
        public ICommand FilmyCommand
        {
            get
            {
                return new BaseCommand(showAllFilmy);
            }
        }
        public ICommand NowySerialCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowySerialViewModel()));
            }
        }
        public ICommand SerialeCommand
        {
            get
            {
                return new BaseCommand(showAllSeriale);
            }
        }
        public ICommand NowyOdcinekCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyOdcinekViewModel()));
            }
        }
        public ICommand OdcinkiCommand
        {
            get
            {
                return new BaseCommand(showAllOdcinki);
            }
        }
        public ICommand NowyTlumaczCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyTlumaczViewModel()));
            }
        }
        public ICommand TlumaczeCommand
        {
            get
            {
                return new BaseCommand(showAllTlumacze);
            }
        }
        public ICommand NowaUmowaCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaUmowaViewModel()));
            }
        }
        public ICommand UmowyCommand
        {
            get
            {
                return new BaseCommand(showAllUmowy);
            }
        }
        public ICommand DodajDoUmowyCommand
        {
            get
            {
                return new BaseCommand(() => createView(new DodajDoUmowyViewModel()));
            }

        }
        public ICommand DodajDoFakturyCommand
        {
            get
            {
                return new BaseCommand(() => createView(new DodajDoFakturyViewModel()));
            }

        }
        public ICommand PokazUkryjMenuBoczneAsyncCommand { get { return new BaseCommand(async () => await PokazUkryjMenuBoczneAsync()); } }
        #endregion

        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands;
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
       

        /// <summary>
        /// Dodajemy do menu bocznego przyciski otwierające nasze zakładki. Tutaj również jako nazwy przycisku użyjmy
        /// <'see cref="ViewResources.GlobalResources"/'>.
        /// </summary>
        /// <returns></returns>
        private List<CommandViewModel> CreateCommands()//tu decydujemy jakie przyciski są w lewym menu
        {
            Messenger.Default.Register<string>(this, Open);
            return new List<CommandViewModel>
            {
                new CommandViewModel("Faktura",new BaseCommand(()=>createView(new NowaFakturaViewModel()))),
                new CommandViewModel("Faktury",new BaseCommand(showAllFaktury)),
                new CommandViewModel("Firma",new BaseCommand(()=>createView(new NowaFirmaViewModel()))),
                new CommandViewModel("Firmy",new BaseCommand(showAllFirmy)),
                new CommandViewModel("Pracownik",new BaseCommand(()=>createView(new NowyPracownikViewModel()))),
                new CommandViewModel("Pracownicy",new BaseCommand(showAllPracownicy)),
                new CommandViewModel("Koordynator",new BaseCommand(()=>createView(new NowyKoordynatorViewModel()))),
                new CommandViewModel("Koordynatorzy",new BaseCommand(showAllKoordynatorzy)),
                new CommandViewModel("Sezon",new BaseCommand(()=>createView(new NowySezonViewModel()))),
                new CommandViewModel("Sezony",new BaseCommand(showAllSezony)),
                new CommandViewModel("Adres",new BaseCommand(()=>createView(new NowyAdresViewModel()))),
                new CommandViewModel("Adresy",new BaseCommand(showAllAdresy)),
                new CommandViewModel("Aktor",new BaseCommand(()=>createView(new NowyAktorViewModel()))),
                new CommandViewModel("Aktorzy",new BaseCommand(showAllAktorzy)),
                new CommandViewModel("Reżyser",new BaseCommand(()=>createView(new NowyRezyserViewModel()))),
                new CommandViewModel("Reżyserzy",new BaseCommand(showAllRezyserzy)),
                new CommandViewModel("Film",new BaseCommand(()=>createView(new NowyFilmViewModel()))),
                new CommandViewModel("Filmy",new BaseCommand(showAllFilmy)),
                new CommandViewModel("Serial",new BaseCommand(()=>createView(new NowySerialViewModel()))),
                new CommandViewModel("Seriale",new BaseCommand(showAllSeriale)),
                new CommandViewModel("Odcinek",new BaseCommand(()=>createView(new NowyOdcinekViewModel()))),
                new CommandViewModel("Odcinki",new BaseCommand(showAllOdcinki)),
                new CommandViewModel("Tłumacz",new BaseCommand(()=>createView(new NowyTlumaczViewModel()))),
                new CommandViewModel("Tłumacze",new BaseCommand(showAllTlumacze)),
                new CommandViewModel("Umowa",new BaseCommand(()=>createView(new NowaUmowaViewModel()))),
                new CommandViewModel("Umowy",new BaseCommand(showAllUmowy)),
                new CommandViewModel("Faktury za projekty", new BaseCommand(ShowProjektyFaktury)),
                new CommandViewModel("Umowy za projekty", new BaseCommand(ShowProjektyUmowy)),
                new CommandViewModel("Oblicz fakture", new BaseCommand(ShowPozycjeFaktury)),
                new CommandViewModel("Oblicz umowe", new BaseCommand(ShowPozycjeUmowy)),
                new CommandViewModel("Dodaj do umowy",new BaseCommand(()=>createView(new DodajDoUmowyViewModel()))),
                new CommandViewModel("Dodaj do faktury",new BaseCommand(()=>createView(new DodajDoFakturyViewModel()))),
            };
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Funkcje pomocnicze
        private async Task PokazUkryjMenuBoczneAsync()
        {
            if (SzerokoscKolumnyMenuBocznego > 0)
            {
                while (SzerokoscKolumnyMenuBocznego > 0)
                {
                    SzerokoscKolumnyMenuBocznego -= 10;
                    await Task.Delay(1);
                }
            }
            else
            {
                while (SzerokoscKolumnyMenuBocznego < 150)
                {
                    SzerokoscKolumnyMenuBocznego += 10;
                    await Task.Delay(1);
                }
            }
        }
        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        private void showAll(WorkspaceViewModel workspace)
        {
            workspace = this.Workspaces.FirstOrDefault(x => x is WorkspaceViewModel) as WorkspaceViewModel;
            if(workspace == null)
            {
                workspace = new WorkspaceViewModel();
                this.Workspaces.Add(workspace);
            }
            this.Workspaces.Add(workspace);
        }

        private void ShowPozycjeUmowy()
        {
            ZaUmoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ZaUmoweViewModel) as ZaUmoweViewModel;
            if (workspace == null)
            {
                workspace = new ZaUmoweViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void ShowPozycjeFaktury()
        {
            ZaFaktureViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ZaFaktureViewModel) as ZaFaktureViewModel;
            if (workspace == null)
            {
                workspace = new ZaFaktureViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void ShowProjektyFaktury()
        {
            ProjektyFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm=>vm is ProjektyFakturyViewModel) as ProjektyFakturyViewModel;
            if(workspace == null)
            {
                workspace = new ProjektyFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void ShowProjektyUmowy()
        {
            ProjektyUmowyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ProjektyUmowyViewModel) as ProjektyUmowyViewModel;
            if (workspace == null)
            {
                workspace = new ProjektyUmowyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllFaktury()
        {
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllPracownicy()
        {
            WszysycPracownicyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszysycPracownicyViewModel) as WszysycPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszysycPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllFirmy()
        {
            WszystkieFirmyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFirmyViewModel) as WszystkieFirmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFirmyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllSezony()
        {
            WszystkieSezonyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSezonyViewModel) as WszystkieSezonyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSezonyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllKoordynatorzy()
        {
            WszyscyKoordynatorzyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyKoordynatorzyViewModel) as WszyscyKoordynatorzyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKoordynatorzyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllAdresy()
        {
            WszystkieAdresyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel) as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllAktorzy()
        {
            WszyscyAktorzyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyAktorzyViewModel) as WszyscyAktorzyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyAktorzyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllRezyserzy()
        {
            WszyscyRezyserzyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyRezyserzyViewModel) as WszyscyRezyserzyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyRezyserzyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllFilmy()
        {
            WszystkieFilmyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFilmyViewModel) as WszystkieFilmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFilmyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllSeriale()
        {
            WszystkieSerialeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSerialeViewModel) as WszystkieSerialeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSerialeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllOdcinki()
        {
            WszystkieOdcinkiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieOdcinkiViewModel) as WszystkieOdcinkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieOdcinkiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllTlumacze()
        {
            WszyscyTlumaczeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyTlumaczeViewModel) as WszyscyTlumaczeViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyTlumaczeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllUmowy()
        {
            WszystkieUmowyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieUmowyViewModel) as WszystkieUmowyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUmowyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void Open(String name)
        {
            // jezeli komunikat jest TowaryAdd, to otwieramy okno do dodawania towarow.
            if (name == "AktorzyAdd")
            {
                createView(new NowyAktorViewModel());
            }
            if (name == "AktorzyAll")
            {
                showAllAktorzy();
            }
            if (name == "KoordynatorzyAdd")
            {
                createView(new NowyKoordynatorViewModel());
            }
            if (name == "KoordynatorzyAll")
            {
                showAllKoordynatorzy();
            }
            if (name == "RezyserzyAdd")
            {
                createView(new NowyRezyserViewModel());
            }
            if (name == "RezyserzyAll")
            {
                showAllRezyserzy();
            }
            if (name == "TlumaczeAdd")
            {
                createView(new NowyTlumaczViewModel());
            }
            if (name == "TlumaczeAll")
            {
                showAllTlumacze();
            }
            if (name == "AdresyAdd")
            {
                createView(new NowyAdresViewModel());
            }
            if (name == "AdresyAll")
            {
                showAllAdresy();
            }
            if (name == "FakturyAdd")
            {
                createView(new NowaFakturaViewModel());
            }
            if (name == "FakturyAll")
            {
                showAllFaktury();
            }
            if (name == "FilmyAdd")
            {
                createView(new NowyFilmViewModel());
            }
            if (name == "FilmyAll")
            {
                showAllFilmy();
            }
            if (name == "FirmyAdd")
            {
                createView(new NowaFirmaViewModel());
            }
            if (name == "FirmyAll")
            {
                showAllFirmy();
            }
            if (name == "OdcinkiAdd")
            {
                createView(new NowyOdcinekViewModel());
            }
            if (name == "OdcinkiAll")
            {
                showAllOdcinki();
            }
            if (name == "ProjektyAdd")
            {
                createView(new NowyProjektViewModel());
            }
            if (name == "ProjektyAll")
            {
                showAllAktorzy();
            }
            if (name == "SerialeAdd")
            {
                createView(new NowySerialViewModel());
            }
            if (name == "SerialeAll")
            {
                showAllSeriale();
            }
            if (name == "SezonyAdd")
            {
                createView(new NowySezonViewModel());
            }
            if (name == "SezonyAll")
            {
                showAllSezony();
            }
            if (name == "UmowyAdd")
            {
                createView(new NowaUmowaViewModel());
            }
            if (name == "UmowyAll")
            {
                showAllUmowy();
            }
            if (name == "PracownicyAdd")
            {
                createView(new NowyPracownikViewModel());
            }
            if (name == "PracownicyAll")
            {
                showAllPracownicy();
            }
        }
        #endregion
    }
}
