using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VorText.Commands;
using VorText.Queries;
using VorText.Stores;

namespace VorText.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly AuthenticationStore _authenticationStore;
        private string _secretMessage;
        public string SecretMessage
        {
            get
            {
                return _secretMessage;
            }
            set
            {
                _secretMessage = value;
                OnPropertyChanged(nameof(SecretMessage));
            }
        }

        //Getting the Current User from the Authentication Store
        public string Username => _authenticationStore.CurrentUser?.DisplayName ?? "Unknown";

        //Commands
        public ICommand LoadSecretMessageCommand { get; }
        public ICommand LogoutCommand { get; }

        //Constructor
        public HomeViewModel(AuthenticationStore authenticationStore, IGetSecretMessageQuery getSecretMessageQuery, INavigationService loginNavigationService)
        {
            _authenticationStore = authenticationStore;

            LoadSecretMessageCommand = new LoadSecretMessageCommand(this, getSecretMessageQuery);
            LogoutCommand = new LogoutCommand(authenticationStore, loginNavigationService);
        }

        //Methods
        public static HomeViewModel LoadViewModel(AuthenticationStore authenticationStore, IGetSecretMessageQuery getSecretMessageQuery, INavigationService loginNavigationService)
        {
            HomeViewModel homeViewModel = new HomeViewModel(authenticationStore, getSecretMessageQuery, loginNavigationService);

            homeViewModel.LoadSecretMessageCommand.Execute(null);

            return homeViewModel;
        }
    }
}
