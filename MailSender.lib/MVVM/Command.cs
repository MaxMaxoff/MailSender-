using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _onExecute;
        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> OnExecute, Func<object, bool> CanExecute = null)
        {
            _onExecute = OnExecute;
            _canExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _onExecute(parameter);
        }
    }
}
