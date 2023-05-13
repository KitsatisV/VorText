using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VorText.Commands;
using VorText.Stores;

namespace VorText.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly AuthenticationStore _authenticationStore;

        //Getting the Current User from the Authentication Store
        public string Username => _authenticationStore.CurrentUser?.DisplayName ?? "Unknown";

        //Commands
        public ICommand LoadSecretMessageCommand { get; }
        public ICommand LogoutCommand { get; }

        //Constructor
        public HomeViewModel(AuthenticationStore authenticationStore, INavigationService loginNavigationService)
        {
            _authenticationStore = authenticationStore;

            LogoutCommand = new LogoutCommand(authenticationStore, loginNavigationService);
        }

        //Methods
        public static HomeViewModel LoadViewModel(AuthenticationStore authenticationStore,  INavigationService loginNavigationService)
        {
            HomeViewModel homeViewModel = new HomeViewModel(authenticationStore, loginNavigationService);

            return homeViewModel;
        }
    }
}
