using System.Collections.ObjectModel;
using WowAPI.Models;

namespace WowAPI.ViewModels.MainVM
{
    public partial class MainViewModel
    {
        public ObservableCollection<ItemClass> ItemClass
        {
            get => itemClass;
            set => SetValue(ref itemClass, value);
        }

        public ObservableCollection<ItemSubClass> ItemSubClass
        {
            get => itemSubClass;
            set => SetValue(ref itemSubClass, value);
        }
    }
}
