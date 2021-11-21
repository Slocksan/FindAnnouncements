using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.viewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AnnouncementsDesk":
                    viewModel.CurrentViewModel = new AnnouncemetsDeskViewModel();
                    break;
                case "MyAnnouncements":
                    viewModel.CurrentViewModel = new MyAnnouncementsViewModel();
                    break;
                case "Login":
                    viewModel.CurrentViewModel = new LoginViewModel();
                    break;
                case "Registration":
                    viewModel.CurrentViewModel = new RegistrationViewModel();
                    break;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
