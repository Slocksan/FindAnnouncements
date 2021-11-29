using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FindAnnouncements.Models;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly AuthorizationStore _authorizationStore;
        private readonly NavigationService _announcementsDeskNavigationService;

        public LoginCommand(LoginViewModel loginViewModel, AuthorizationStore authorizationStore,
            NavigationService announcementsDeskNavigationService)
        {
            _authorizationStore = authorizationStore;
            _loginViewModel = loginViewModel;
            _announcementsDeskNavigationService = announcementsDeskNavigationService;

            _loginViewModel.PropertyChanged += LoginViewModelOnPropertyChanged;
        }

        private void LoginViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username)
            || e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !(string.IsNullOrEmpty(_loginViewModel.Username)) &&
                     !(string.IsNullOrEmpty(_loginViewModel.Password)) && 
                     base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            var userToLogin = new User()
            {
                Login = _loginViewModel.Username,
                Password = _loginViewModel.Password
            };

            var userAuthorization = Authorization.Login(userToLogin);

            if (userAuthorization.IsAutorized)
            {
                _authorizationStore.ActualAuthorization = userAuthorization;
                Authorization.Journaling(userAuthorization);
                _announcementsDeskNavigationService.Navigate();
            }
            else
            {
                MessageBox.Show(userAuthorization.ErrorMassage);
                if (!(userAuthorization.User is null)) Authorization.Journaling(_authorizationStore.ActualAuthorization);
            }
        }
    }
}
