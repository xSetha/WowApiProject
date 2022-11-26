using System.Windows.Input;

namespace WowAPI.ViewModels.AuctionVM
{
    public partial class AuctionViewModel
    {
        public ICommand ItemClassCommand => CreateCommand(() => ExecuteItemClass(), () => true);
        public ICommand SubItemClassCommand => CreateCommand(() => ExecuteSubItemClass(), () => true);
        public ICommand GetAuctionsCommand => CreateCommand(() => ExecuteGetAuctionsCommand(), () => true);
    }
}
