using System;
using System.Windows.Input;

namespace TranslateHelperWpf.Models
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;
        private object p;

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);
            else
                return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }
    }
}
