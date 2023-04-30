using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorText.Stores;

namespace VorText.Commands
{
    class LogoutCommand : CommandBase
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly INavigationService _loginNavigationService;

        //Constructor
        public LogoutCommand(AuthenticationStore authenticationStore, INavigationService loginNavigationService)
        {
            _authenticationStore = authenticationStore;
            _loginNavigationService = loginNavigationService;
        }

        //Methods
        public override void Execute(object parameter)
        {
            _authenticationStore.Logout();

            //Navigate to Login Page
            _loginNavigationService.Navigate();
        }
    }
}
