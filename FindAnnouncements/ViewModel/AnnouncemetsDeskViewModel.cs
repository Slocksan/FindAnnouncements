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
    class AnnouncemetsDeskViewModel : BaseViewModel
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

        public List<Announcement> Announcements {
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


        public ICommand LoginCommand { get; }

        public ICommand UpdateAnnouncementsCommand { get; }

        public ICommand CreateAnnouncementCommand { get; }

        public AnnouncemetsDeskViewModel(AuthorizationStore authorizationStore, NavigationService LoginNavigationService)
        {
            UpdateAnnouncementsCommand = new UpdateAnnouncementsCommand(this);
            LoginCommand = new NavigateCommand(LoginNavigationService);
            AuthorizationStore = authorizationStore;

            CreateAnnouncementCommand = new EditAnnouncementCommand(AuthorizationStore.ActualAuthorization.User);

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
