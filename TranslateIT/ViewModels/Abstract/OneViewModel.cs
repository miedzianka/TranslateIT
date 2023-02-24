using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.Entity;

namespace TranslateIT.ViewModels.Abstract
{
    public abstract class OneViewModel<T>:WorkspaceViewModel
    {
        #region Fields
        public TranslateITEntities4 Db { get; set; } 
        public T Item { get; set; }
        #endregion
        #region Konstruktor
        public OneViewModel(string DisplayName)
        {
            base.DisplayName = DisplayName;
            Db = new TranslateITEntities4();
        }
        #endregion
        #region Command
        private BaseCommand _SavaAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if(_SavaAndCloseCommand == null)
                {
                    _SavaAndCloseCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SavaAndCloseCommand;
            }
        }
        private BaseCommand _SavaCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SavaCommand == null)
                {
                    _SavaCommand = new BaseCommand(() => JustSave());
                }
                return _SavaCommand;
            }
        }
        private BaseCommand _CloseCommand;
        public ICommand JustCloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new BaseCommand(() => JustClose());
                }
                return _CloseCommand;
            }
        }
        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
        #region Save
        public abstract void Save();
        private void SaveAndClose()
        {
            if (IsValid())
            {
                Save();
                //ShowMessageBoxInformation("Zapisano Nowy Obiekt");//
                base.OnRequestClose();
            }
            else
            {
                MessageBox.Show("Popraw wszystkie dane!");
            }
        }
        private void JustClose()
        {
            base.OnRequestClose();
        }
        private void JustSave()
        {
            Save();
        }
        #endregion
    }
}
