using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class RegistrateCommand : CommandBase
    {
        private readonly RegistrationViewModel _registrationViewModel;

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

            _registrationViewModel.Authorization = Authorization.Registrate(userToRegistrate);

            if (!(_registrationViewModel.Authorization.User is null))
            {
                MessageBox.Show(_registrationViewModel.Authorization.ErrorMassage);
            }
            else
            {
                MessageBox.Show("Теперь вы зарегистрированы");
            }
        }

        public RegistrateCommand(RegistrationViewModel registrationViewModel)
        {
            _registrationViewModel = registrationViewModel;

            _registrationViewModel.PropertyChanged += RegistrationViewModelOnPropertyChanged;
        }

        private void RegistrationViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username)
                || e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !(string.IsNullOrEmpty(_registrationViewModel.Username)) &&
                   !(string.IsNullOrEmpty(_registrationViewModel.Password)) &&
                   base.CanExecute(parameter);
        }
    }
}
