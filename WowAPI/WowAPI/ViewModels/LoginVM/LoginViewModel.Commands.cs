using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WowAPI.ViewModels.LoginVM
{
    public partial class LoginViewModel
    {
        public ICommand LogInCommand => CreateCommand(() => ExecuteLogIn(), () => true);
    }
}
