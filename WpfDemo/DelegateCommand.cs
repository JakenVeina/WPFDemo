using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFDemo
{
    public class DelegateCommand : ICommand
    {
        /**********************************************************************/
        #region Constructors

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            ExecuteDelegate = execute ?? throw new ArgumentNullException(nameof(execute));
            CanExecuteDelegate = canExecute ?? ((o) => true);
        }

        #endregion Constructors

        /**********************************************************************/
        #region ICommand

        public void Execute(object parameter) => ExecuteDelegate.Invoke(parameter);

        public bool CanExecute(object parameter) => CanExecuteDelegate.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion ICommand

        /**********************************************************************/
        #region Private Fields

        private Action<object> ExecuteDelegate;

        private Predicate<object> CanExecuteDelegate;

        #endregion Private Fields
    }
}
