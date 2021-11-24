using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Models;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class RegistrationViewModel : BaseViewModel
    {
        private readonly AuthorizationStore _authorizationStore;

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

        private string _firstName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _secondName;

        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        private string _patronymic;

        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _email;

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

        public ICommand RegistrateCommand { get; }

        public ICommand LoginCommand { get; }

        public ICommand GuestCommand { get; }

        public RegistrationViewModel(AuthorizationStore authorizationStore, NavigationService loginNavigationService, NavigationService announcementsDeskNavigationService)
        {
            RegistrateCommand = new RegistrateCommand(authorizationStore, this, announcementsDeskNavigationService);

            LoginCommand = new NavigateCommand(loginNavigationService);

            GuestCommand = new NavigateCommand(announcementsDeskNavigationService);

            _authorizationStore = authorizationStore;
        }
    }
}
