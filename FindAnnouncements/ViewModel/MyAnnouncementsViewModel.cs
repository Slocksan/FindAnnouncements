using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class MyAnnouncementsViewModel : BaseViewModel
    {
        public AuthorizationStore AuthorizationStore { get; }

        private Announcement _selectedAnnouncement;
        public Announcement SelectedAnnouncement
        {
            get
            {
                return _selectedAnnouncement;
            }
            set
            {
                _selectedAnnouncement = value;
                OnPropertyChanged(nameof(SelectedAnnouncement));
            }
        }

        private List<Announcement> _announcements;

        public List<Announcement> Announcements
        {
            get
            {
                return _announcements;
            }
            set
            {
                _announcements = value;
                OnPropertyChanged(nameof(Announcements));
            }
        }

        public ICommand OpenAnnouncementsDeskCommand { get; }

        public ICommand UpdateAnnouncementsCommand { get; }

        public ICommand EditAnnouncementCommand { get; }

        public ICommand AddAnnouncementCommand { get; }

        public MyAnnouncementsViewModel(AuthorizationStore authorizationStore, NavigationService announcementsDeskNavigationService)
        {
            AuthorizationStore = authorizationStore;
            Announcements = new List<Announcement>();

            UpdateAnnouncementsCommand = new UpdateMyAnnouncementsCommand(this);

            EditAnnouncementCommand = new EditAnnouncementCommand(authorizationStore.ActualAuthorization.User);
            AddAnnouncementCommand = new EditAnnouncementCommand(authorizationStore.ActualAuthorization.User);

            OpenAnnouncementsDeskCommand = new NavigateCommand(announcementsDeskNavigationService);

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
