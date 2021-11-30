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
    class RegistrateCommand : CommandBase
    {
        private readonly AuthorizationStore _authorizationStore;
        private readonly RegistrationViewModel _registrationViewModel;
        private readonly NavigationService _announcementsDeskNavigationService;

        public override void Execute(object parameter)
        {
            var userToRegistrate = new User()
            {
                Login = _registrationViewModel.Username,
                Password = _registrationViewModel.Password,
                FIO =
                    $"{_registrationViewModel.SecondName} {_registrationViewModel.SecondName} {_registrationViewModel.Patronymic}",
                Email = _registrationViewModel.Email,
                PhoneNumber = _registrationViewModel.PhoneNumber,
                RoleID = 3
            };

            var userAuthorization = Authorization.Registrate(userToRegistrate);

            if (userAuthorization.IsAutorized)
            {
                _authorizationStore.ActualAuthorization = userAuthorization;
                MessageBox.Show(userAuthorization.ErrorMessage);
                Authorization.Journaling(userAuthorization.User, "Регистрация", "Зарегистрирован новый пользователь");
            }
            else
            {
                _announcementsDeskNavigationService.Navigate();
            }
        }

        public RegistrateCommand(AuthorizationStore authorizationStore, RegistrationViewModel registrationViewModel, NavigationService announcementsDeskNavigationService)
        {
            _authorizationStore = authorizationStore;
            _registrationViewModel = registrationViewModel;
            _announcementsDeskNavigationService = announcementsDeskNavigationService;

            _registrationViewModel.PropertyChanged += RegistrationViewModelOnPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_registrationViewModel.Username) &&
                   !string.IsNullOrEmpty(_registrationViewModel.Password) &&
                   base.CanExecute(parameter);
        }

        private void RegistrationViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username)
                || e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
