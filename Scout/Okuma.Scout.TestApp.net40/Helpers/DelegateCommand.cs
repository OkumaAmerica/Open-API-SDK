
namespace Okuma.Scout.TestApp.net40
{
    using System;

    public class DelegateCommand<T> : System.Windows.Input.ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public void Execute(object parameter)
        {
            _execute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
