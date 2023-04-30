using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorText.Stores;

namespace VorText.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly AuthenticationStore _authenticationStore;

        public HomeViewModel(AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
        }

        //Getting the Current User from the Authentication Store
        public string Username => _authenticationStore.CurrentUser?.DisplayName ?? "Unknown";
    }
}
