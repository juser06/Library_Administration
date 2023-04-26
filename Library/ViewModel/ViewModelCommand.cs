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

        //se definen un Action y Predicate, el Action funciona como una accion directa de lo que se pasa, por ejemplo:
        //Action<string> print = (x) => Console.WriteLine(x);
        //esto da como resultado la creacion de una funcion print que al llamarla va a imprimir los parametros dados
        //despues esta la definicion del Predicate que devuelve un bool, por ejemplo:
        //Predicate<int> predicate = ((number) => number > 2);
        //esto al pasarlo con una lista de int te va a devolver true en los elementos mayores a 2;
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExcecuteAction;

        //constructor

        //son los constructores con los parametros de los fields, uno es para la accion completa de chequear si se puede ejecutar y ejecutarlo,
        //y el otro para la cuando solo se debe ejecutar
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

        //el eventhandler 
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
