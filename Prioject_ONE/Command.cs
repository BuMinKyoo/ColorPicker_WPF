using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColorPicker_WPF
{
    internal class Command : ICommand
    {
        private Action<object> _execute;

        public event EventHandler? CanExecuteChanged;
        public Command(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
