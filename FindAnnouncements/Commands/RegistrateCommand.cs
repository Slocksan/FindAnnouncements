using System;
using System.Collections.Generic;
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
        }
    }
}
