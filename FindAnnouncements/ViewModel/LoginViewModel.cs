using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class LoginViewModel : BaseViewModel
    {

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
        public ICommand GuestCommand { get; }

        public LoginViewModel(AuthorizationStore authorizationStore ,NavigationService registrationNavigationService,
            NavigationService announcementsDeskNavigationService)
        {
            RegistrationCommand = new NavigateCommand(registrationNavigationService);
            GuestCommand = new NavigateCommand(announcementsDeskNavigationService);
            LoginCommand = new LoginCommand(this, authorizationStore, announcementsDeskNavigationService);
        }
    }
}
