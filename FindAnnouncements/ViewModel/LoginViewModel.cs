using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Models;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public Authorization Authorization { get; set; }

        private string _username;

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

        private string _password;

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

        public ICommand LoginCommand { get; }

        public ICommand RegistrationCommand { get; }

        public LoginViewModel(NavigationStore navigationStore, Func<RegistrationViewModel> createRegistrationViewModel)
        {
            RegistrationCommand = new NavigateCommand(navigationStore, createRegistrationViewModel);

            LoginCommand = new LoginCommand(this);
        }
    }
}
