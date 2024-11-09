using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizQuest.Assets.Command
{
    internal class DelegateButtonCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T?, bool> canExecute;

        public event EventHandler? CanExecuteChanged;


        public DelegateButtonCommand(Action<T> execute, Func<T?, bool> canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void RaisedCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object? parameter)
        {
            return canExecute is null ? true : canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            execute((T)parameter);
        }
    }
}
