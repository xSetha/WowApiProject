using System.Collections.ObjectModel;
using WowAPI.Models;

namespace WowAPI.ViewModels.MainVM
{
    public partial class MainViewModel
    {
        public BaseViewModel CurrentChildView
        {
            get
            {
                return currentChildView;
            }

            set
            {
                currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
    }
}
