using Firebase.Auth;
using MVVMEssentials.Commands;
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
    class LoginViewModel : ViewModelBase
    {
        private string _email;
        private string _password;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand NavigateRegisterCommand { get; }

        public LoginViewModel(AuthenticationStore authenticationStore, INavigationService registerNavigationService, INavigationService homeNavigationService)
        {
            SubmitCommand = new LoginCommand(this, authenticationStore, homeNavigationService);
            NavigateRegisterCommand = new NavigateCommand(registerNavigationService);
        }

    }
}
