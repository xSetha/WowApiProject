using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WowAPI.Command;
using WowAPI.Constants;
using WowAPI.Helpers;
using WowAPI.Models;
using WowAPI.ViewModels.AuctionVM;
using WowAPI.Views;

namespace WowAPI.ViewModels.MainVM
{
    public partial class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentChildView;

        public MainViewModel()
        {
            OpenAuctionViewCommand = new ViewModelCommand(ExecuteOpenAuctionViewCommand);
        }

        private void Initialize()
        {
            CurrentChildView = new AuctionViewModel();
        }


        private void ExecuteOpenAuctionViewCommand(object obj)
        {
            CurrentChildView = new AuctionViewModel();
        }
    }
}
