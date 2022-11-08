using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WowAPI.Models;

namespace WowAPI
{
    public class GetRequests
    {
        public async Task MountRequest() 
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.AccesTokenAPI);
                var response = await client.GetStringAsync($"https://us.api.blizzard.com/data/wow/mount/6?namespace=static-us&locale=en_US&access_token={Properties.Settings.Default.AccesTokenAPI}");

                if (response is null)
                {
                    MessageBox.Show("FAILED TO RETRIEVE DATA", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("WOHOO", "bvma", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                var data = JsonConvert.DeserializeObject<MountEntity>(response);
            }
        }

    }
}
