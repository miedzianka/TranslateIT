using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels
{
    public abstract class AllViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //polaczenie z baza danych
        private readonly TranslateITEntities4 translateITEntities;
        public TranslateITEntities4 TranslateITEntities
        {
            get 
            { 
                return translateITEntities; 
            }
        }
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if(_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand=new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        #endregion
        #region Properties
        //lista zaladowana z bazy danych
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor
        public AllViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.translateITEntities = new TranslateITEntities4();
        }
        #endregion
        #region Sort
        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if(_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        public string SortField { get; set; }
        public List<string> SortComboBoxItems
        {
            get
            {
                return GetComboBoxSortList();
            }
        }
        #endregion
        #region Find
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if(_FindCommand==null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        public string FindField { get; set; }
        public string FindTextBox { get; set; }
        public List<string> FindComboBoxItems
        {
            get
            {
                return GetComboBoxFindList();
            }
        }
        #endregion
        #region Helpers
        public abstract void Load();
        public abstract void Sort();
        public abstract List<string> GetComboBoxSortList();
        public abstract void Find();
        public abstract List<string> GetComboBoxFindList();
        private void Add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
    }
}
