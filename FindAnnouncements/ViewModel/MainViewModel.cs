using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Models;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Authorization _authorization;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _navigationStore = new NavigationStore();
            _authorization = new Authorization() {IsAutorized = false};

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _navigationStore.CurrentViewModel = createLoginViewModel();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private RegistrationViewModel createRegistrationViewModel()
        {
            return new RegistrationViewModel(_navigationStore, createLoginViewModel, createGuestAnnouncemetsDeskViewModel);
        }

        private LoginViewModel createLoginViewModel()
        {
            return new LoginViewModel(_navigationStore, createRegistrationViewModel, createGuestAnnouncemetsDeskViewModel);
        }

        private AnnouncemetsDeskViewModel createGuestAnnouncemetsDeskViewModel()
        {
            return new AnnouncemetsDeskViewModel(_navigationStore, _authorization);
        }
    }
}
