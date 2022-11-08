using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WowAPI.Views;
using WowAPI.ViewModels.LoginVM;

namespace WowAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel loginVM = new LoginViewModel();
            loginWindow.DataContext = loginVM;
            loginWindow.Show();
        }
    }
}
