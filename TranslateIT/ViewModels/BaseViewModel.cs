using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TranslateIT.Helpers;

namespace TranslateIT.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Command
        public delegate void CommandDelegate();
        protected BaseCommand GetCommand( BaseCommand baseCommand, CommandDelegate function)
        {
            if (baseCommand == null)
            {
                baseCommand = new BaseCommand(() => function());
            }
            return baseCommand;
        }

        #endregion

        #region Property changed
        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }
        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)

            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
