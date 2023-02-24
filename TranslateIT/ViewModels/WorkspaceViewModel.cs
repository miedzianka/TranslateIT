using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslateIT.Helpers;

namespace TranslateIT.ViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        #region pola i komendy
        public string  DisplayName { get; set; }
        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose());
                return (ICommand)_CloseCommand;
            }
        }
        #endregion
        #region event RequestClose
        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

        
    }
}
