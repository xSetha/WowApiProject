using Newtonsoft.Json;
using RestSharp;
using System.Windows;
using WowAPI.Constants;
using WowAPI.Models;
using WowAPI.Properties;
using WowAPI.ViewModels.MainVm;

namespace WowAPI.ViewModels.LoginVM
{

    public partial class LoginViewModel : BaseViewModel
    {
        OAuthToken authToken = new OAuthToken();
        private void ExecuteLogIn()
        {
            //if (string.IsNullOrEmpty(Settings.Default.AccesTokenAPI) ||
            //    Settings.Default.ExpiresInToken == 0)
            //{
            authToken = GetAuthentication();
            Settings.Default.AccesTokenAPI = authToken.access_token;
            Settings.Default.ExpiresInToken = authToken.expires_in;
            Settings.Default.Save();
            //}

            MainWindow window = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();
            window.DataContext = mainViewModel;
            window.Show();

        }

        private OAuthToken GetAuthentication()
        {
            var client = new RestClient(ApiConstants.TokenURL);
            var request = new RestRequest(ApiConstants.TokenURL, Method.Post);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={ApiConstants.ClientID}&client_secret={ApiConstants.ClientSecret}", ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            if (response is null)
            {
                MessageBox.Show("FAILED TO LOG IN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new OAuthToken();
            }

            var token = JsonConvert.DeserializeObject<OAuthToken>(response.Content);

            return token;
        }
    }
}
