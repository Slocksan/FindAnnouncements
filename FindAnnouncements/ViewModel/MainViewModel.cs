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
            _authorizationStore = new AuthorizationStore
            {
                ActualAuthorization = new Authorization() { IsAutorized = false }
            };

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _navigationStore.CurrentViewModel = CreateLoginViewModel();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private RegistrationViewModel CreateRegistrationViewModel()
        {
            return new RegistrationViewModel(_authorizationStore, new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateAnnouncementsDeskViewModel));
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(_authorizationStore, new NavigationService(_navigationStore, CreateRegistrationViewModel),
                new NavigationService(_navigationStore, CreateAnnouncementsDeskViewModel));
        }

        private AnnouncementsDeskViewModel CreateAnnouncementsDeskViewModel()
        {
            return new AnnouncementsDeskViewModel(_authorizationStore, new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateMyAnnouncementsViewModel));
        }

        private MyAnnouncementsViewModel CreateMyAnnouncementsViewModel()
        {
            return new MyAnnouncementsViewModel(_authorizationStore,
                new NavigationService(_navigationStore, CreateAnnouncementsDeskViewModel));
        }
    }
}
