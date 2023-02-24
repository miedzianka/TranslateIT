﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TranslateIT.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Wlasciwosci
        public string DisplayName { get; set; }
        public ICommand Command { get; set; }
        #endregion
        #region Konstruktor
        public CommandViewModel(string displayNae, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            this.DisplayName = displayNae;
            this.Command = command;
        }
        #endregion
    }
}
