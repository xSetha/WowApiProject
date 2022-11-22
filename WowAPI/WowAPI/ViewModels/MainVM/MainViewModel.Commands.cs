using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WowAPI.ViewModels.MainVM
{
    public partial class MainViewModel
    {
        public ICommand ItemClassCommand => CreateCommand(() => ExecuteItemClass(), () => true);
        public ICommand SubItemClassCommand => CreateCommand(() => ExecuteSubItemClass(), () => true);
    }
}
