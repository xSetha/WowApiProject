using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowAPI.Models;
using WowAPI.Models.Auction;

namespace WowAPI.ViewModels.AuctionVM
{
    public partial class AuctionViewModel
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

        public ItemClass SelectedItem
        {
            get => selectedItem;
            set => SetValue(ref selectedItem, value);
        }

        public ItemSubClass SelectedSubItem
        {
            get => selectedSubItem;
            set => SetValue(ref selectedSubItem, value);
        }

        public ObservableCollection<AuctionModel> Auctions
        {
            get => auction;
            set => SetValue(ref auction, value);
        }
    }
}
