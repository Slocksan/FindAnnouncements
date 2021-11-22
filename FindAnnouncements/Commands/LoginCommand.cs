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
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public override void Execute(object parameter)
        {
            var userToLogin = new User()
            {
                Login = _loginViewModel.Username,
                Password = _loginViewModel.Password
            };

            _loginViewModel.Authorization = Authorization.Login(userToLogin);

            if (_loginViewModel.Authorization.IsAutorized)
            {
                MessageBox.Show("Все ок, проходи");
            }
            else
            {
                MessageBox.Show(_loginViewModel.Authorization.ErrorMassage);
            }
        }
    }
}
