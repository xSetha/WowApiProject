using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WowAPI.Command
{
    public class AsyncCommand : IAsyncCommand
    {
        private readonly Func<bool> canExecute;
        private readonly Func<object?, Task> execute;
        private bool isExecuting;

        public AsyncCommand(Func<object?, Task> _execute, Func<bool> _canExecute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public AsyncCommand(Func<object?, Task> _execute) : this(_execute, () => true)
        {
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !isExecuting && canExecute();
        }

        public async void Execute(object? parameter)
        {
            await ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object? param)
        {
            if (CanExecute(param))
            {
                try
                {
                    isExecuting = true;
                    await execute(param);
                }
                catch
                {
                    MessageBox.Show("FAILED TO EXECUTE ASYNC", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    isExecuting = false;
                }
            }
        }

        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
