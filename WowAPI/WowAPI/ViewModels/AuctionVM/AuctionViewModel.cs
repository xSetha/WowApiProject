using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using WowAPI.Constants;
using WowAPI.Helpers;
using WowAPI.Models;
using WowAPI.Models.Auction;

namespace WowAPI.ViewModels.AuctionVM
{
    public partial class AuctionViewModel : BaseViewModel
    {
        HttpClientHelper httpClientHelper = new HttpClientHelper();
        ObservableCollection<ItemClass> itemClass = new ObservableCollection<ItemClass>();
        ObservableCollection<ItemSubClass> itemSubClass = new ObservableCollection<ItemSubClass>();
        ObservableCollection<AuctionModel> auction = new ObservableCollection<AuctionModel>();
        private ItemClass selectedItem = new();
        private ItemSubClass selectedSubItem = new();

        public AuctionViewModel()
        {
            InitializeData();
        }

        private async void InitializeData()
        {
            await SetupItemClasses();
            await SetupItemSubClasses();
        }

        private async Task SetupItemClasses()
        {
            HttpDataResponse<ItemClassEntity> result = await httpClientHelper.GetAsync<ItemClassEntity>
                ($"{ApiConstants.BaseURL}/item-class/index?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            ProcessItemClassesResponse(result.Data);
        }

        public async Task SetupItemSubClasses()
        {
            HttpDataResponse<ItemSubClassesEntity> result = await httpClientHelper.GetAsync<ItemSubClassesEntity>
                ($"{ApiConstants.BaseURL}/item-class/0?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            ProcessItemSubClassesResponse(result.Data);
        }

        private void ProcessItemSubClassesResponse(ItemSubClassesEntity data)
        {
            if (data is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            foreach (ItemSubClass item in data.ItemSubClasses)
            {
                itemSubClass.Add(item);
            }
        }

        public async Task ExecuteItemClass()
        {
            itemSubClass.Clear();

            HttpDataResponse<ItemSubClassesEntity> result = await httpClientHelper.GetAsync<ItemSubClassesEntity>
                ($"{ApiConstants.BaseURL}/item-class/{selectedItem.Id}?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            ProcessItemSubClassesResponse(result.Data);
        }

        public void ExecuteSubItemClass()
        {
            //itemSubClass.Clear();

            //HttpDataResponse<ItemSubClassesEntity> result = await httpClientHelper.GetAsync<ItemSubClassesEntity>
            //    ($"{ApiConstants.BaseURL}/item-class/{SelectedItem.Id}/item-subclass/{selectedSubItem.Id}?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            //if (result is null || result.Data is null)
            //{
            //    MessageBox.Show("logmessage");
            //    return;
            //}

            //ProcessItemSubClassesResponse(result.Data);

            MessageBox.Show("logmessage");
        }

        public async Task ExecuteGetAuctionsCommand()
        {

            HttpDataResponse<AuctionModel> result = await httpClientHelper.GetAsync<AuctionModel>
                ($"{ApiConstants.BaseURL}/connected-realm/3674/auctions?namespace=dynamic-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("Empty");
                return;
            }

            MessageBox.Show("Done");

            //ProcessAuctions(result.Data);
        }

        private void ProcessAuctions(AuctionModel? auctions)
        {
            if (auctions is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            //foreach (AuctionModel item in auctions)
            //{
            //    auction.Add(item);
            //}
        }


        private void ProcessItemClassesResponse(ItemClassEntity? itemClassEntities)
        {
            if (itemClassEntities is null)
            {
                MessageBox.Show("logmessage");
                return;
            }

            foreach (ItemClass item in itemClassEntities.ItemClasses)
            {
                itemClass.Add(item);
            }
        }
    }
}
