using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _navigationStore = new NavigationStore();

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _navigationStore.CurrentViewModel = createLoginViewModel();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private RegistrationViewModel createRegistrationViewModel()
        {
            return new RegistrationViewModel(_navigationStore, createLoginViewModel);
        }

        private LoginViewModel createLoginViewModel()
        {
            return new LoginViewModel(_navigationStore, createRegistrationViewModel);
        }
    }
}
