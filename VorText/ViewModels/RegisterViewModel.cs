using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VorText.Commands;

namespace VorText.ViewModels
{
    internal class RegisterViewModel : ViewModelBase
    {
        private string _email;
        private string _username;
        private string _password;
        private string _confirmPassword;

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
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
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
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public RegisterViewModel(Firebase.Auth.FirebaseAuthProvider firebaseAuthProvider)
        {
            SubmitCommand = new RegisterCommand(this, firebaseAuthProvider);
        }
    }
}
