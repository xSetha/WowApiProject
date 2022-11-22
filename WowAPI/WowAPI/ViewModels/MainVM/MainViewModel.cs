using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using WowAPI.Helpers;
using WowAPI.Models;

namespace WowAPI.ViewModels.MainVM
{
    public partial class MainViewModel : BaseViewModel
    {

        HttpClientHelper httpClientHelper = new HttpClientHelper();
        ObservableCollection<ItemClass> itemClass = new ObservableCollection<ItemClass>();
        ObservableCollection<ItemSubClass> itemSubClass = new ObservableCollection<ItemSubClass>();
        int currentItemClassIndex = 0;
        int currentItemSubClassIndex = 0;

        public MainViewModel()
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
            HttpDataResponse<ItemClassEntity> result = await httpClientHelper.GetAsync<ItemClassEntity>($"https://eu.api.blizzard.com/data/wow/item-class/index?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("This shit aint good.");
                return;
            }

            ProcessItemClassesResponse(result.Data);
        }

        public async Task SetupItemSubClasses()
        {
            HttpDataResponse<ItemSubClassesEntity> result = await httpClientHelper.GetAsync<ItemSubClassesEntity>($"https://eu.api.blizzard.com/data/wow/item-class/0?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("This shit aint good.");
                return;
            }

            ProcessItemSubClassesResponse(result.Data);
        }

        private void ProcessItemSubClassesResponse(ItemSubClassesEntity data)
        {
            if (data is null) 
            {
                MessageBox.Show("This shit aint good.");
                return;
            }

            foreach (ItemSubClass item in data.ItemSubClasses)
            {
                item.CheckedSubItemStatus = false;
                itemSubClass.Add(item);
            }

            itemSubClass[0].CheckedSubItemStatus = true;
        }

        public void ExecuteItemClass()
        {
            throw new NotImplementedException();
        }

        public void ExecuteSubItemClass()
        {
            throw new NotImplementedException();
        }

        private void ProcessItemClassesResponse(ItemClassEntity? itemClassEntities)
        {
            if (itemClassEntities is null) 
            {
                MessageBox.Show("This shit aint good.");
                return;
            }

            foreach (ItemClass item in itemClassEntities.ItemClasses)
            {
                item.CheckedItemStatus = false;
                itemClass.Add(item);
            }

            itemClass[0].CheckedItemStatus = true;
        }
    }
}
