using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WowAPI.Models;
using WowAPI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using WowAPI.Constants;

namespace WowAPI.ViewModels.MainVm
{
    public class MainViewModel : BaseViewModel
    {
        private string labelContent = "sgpl";
        public string LabelContent
        {
            get => labelContent;
            set => SetValue(ref labelContent, value);
        }

        HttpClientHelper httpClientHelper = new HttpClientHelper();
        ObservableCollection<ItemClassIndexEntity> itemIndex;

        public ObservableCollection<ItemClassIndexEntity>? ItemIndexes
        {
            get => itemIndex;
            set => SetValue(ref itemIndex, value);
        }

        public ICommand GetDataCommand => CreateAsyncCommand((param) => ExecuteGetData(), () => true);

        public async Task ExecuteGetData()
        {
            HttpDataResponse<IEnumerable<ItemClassIndexEntity>> result = await httpClientHelper.GetCollectionAsync<ItemClassIndexEntity>($"https://eu.api.blizzard.com/data/wow/item-class/index?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if(result is null || result.Data is null)
            {
                MessageBox.Show("This shit aint good.");
            }

            ProcessResponse(result.Data);
        }

        private void ProcessResponse(IEnumerable<ItemClassIndexEntity>? itemClassIndexEntities)
        {
            IEnumerable<ItemClassIndexEntity> filteredEntities = itemClassIndexEntities.Select(e => new ItemClassIndexEntity(e.id, e.name));

            itemIndex = new ObservableCollection<ItemClassIndexEntity>(filteredEntities);
        }
    }
}
