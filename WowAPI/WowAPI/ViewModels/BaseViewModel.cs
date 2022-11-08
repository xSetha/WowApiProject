using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WowAPI.Command;

namespace WowAPI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetValue<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected ICommand CreateCommand(Action execute, Func<bool> canExecute, [CallerMemberName] string commandName = "")
        {
            ICommand command = new RelayCommand(execute, canExecute);
            return command;
        }

        protected ICommand CreateAsyncCommand(Func<object?, Task> execute, Func<bool> canExecute, [CallerMemberName] string commandName = "")
        {
            ICommand command = new AsyncCommand(execute, canExecute);
            return command;
        }
    }
}
