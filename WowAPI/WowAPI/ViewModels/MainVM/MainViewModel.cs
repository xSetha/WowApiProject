using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WowAPI.Helpers;
using WowAPI.Models;

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
        ObservableCollection<ItemClass> itemClass = new ObservableCollection<ItemClass>();

        public ObservableCollection<ItemClass> ItemClass
        {
            get => itemClass;
            set => SetValue(ref itemClass, value);
        }

        public ICommand GetDataCommand => CreateAsyncCommand((param) => ExecuteGetData(), () => true);

        public async Task ExecuteGetData()
        {
            HttpDataResponse<ItemClassIndexEntity> result = await httpClientHelper.GetAsync<ItemClassIndexEntity>($"https://eu.api.blizzard.com/data/wow/item-class/index?namespace=static-eu&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

            if (result is null || result.Data is null)
            {
                MessageBox.Show("This shit aint good.");
            }

            ProcessResponse(result.Data);
        }

        private void ProcessResponse(ItemClassIndexEntity? itemClassIndexEntities)
        {
            foreach (ItemClass item in itemClassIndexEntities.ItemClasses)
            {
                itemClass.Add(item);
            }
        }
    }
}
