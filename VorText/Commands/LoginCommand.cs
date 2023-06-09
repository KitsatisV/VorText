﻿using Firebase.Auth;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VorText.Stores;
using VorText.ViewModels;
using VorText.Windows;

namespace VorText.Commands
{
    class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly AuthenticationStore _authenticationStore;
        private readonly INavigationService _homeNavigationService;

        public LoginCommand(LoginViewModel loginViewModel, AuthenticationStore authenticationStore, INavigationService homeNavigationService)
        {
            _loginViewModel = loginViewModel;
            _authenticationStore = authenticationStore;
            _homeNavigationService = homeNavigationService;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //Letting the AuthenticationStore handle the Log In
                await _authenticationStore.Login(_loginViewModel.Email, _loginViewModel.Password);

                MessageBox.Show("Successfully logged in!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _homeNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Login failed! Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
