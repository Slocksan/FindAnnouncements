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
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthorizationStore _authorizationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _navigationStore = new NavigationStore();
            _authorizationStore = new AuthorizationStore();

            _authorizationStore.ActualAuthorization = new Authorization() { IsAutorized = false };
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _navigationStore.CurrentViewModel = createLoginViewModel();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private RegistrationViewModel createRegistrationViewModel()
        {
            return new RegistrationViewModel(_authorizationStore, new NavigationService(_navigationStore, createLoginViewModel), new NavigationService(_navigationStore, createAnnouncemetsDeskViewModel));
        }

        private LoginViewModel createLoginViewModel()
        {
            return new LoginViewModel(_authorizationStore, new NavigationService(_navigationStore, createRegistrationViewModel),
                new NavigationService(_navigationStore, createAnnouncemetsDeskViewModel));
        }

        private AnnouncemetsDeskViewModel createAnnouncemetsDeskViewModel()
        {
            return new AnnouncemetsDeskViewModel(_authorizationStore, new NavigationService(_navigationStore, createLoginViewModel));
        }
    }
}
