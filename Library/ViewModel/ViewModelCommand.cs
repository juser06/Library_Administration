using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExcecuteAction;

        //constructor
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExcecuteAction)
        {
            _executeAction = executeAction;
            _canExcecuteAction = canExcecuteAction;
        }

        //event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        //methods
        public bool CanExecute(object parameter)
        {
            return _canExcecuteAction == null ? true : _canExcecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
