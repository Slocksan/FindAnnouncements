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
    class MyAnnouncementsViewModel : BaseViewModel
    {
        public AuthorizationStore AuthorizationStore { get; }

        private List<AnnouncementSorter> _announcementSorters;

        public List<AnnouncementSorter> AnnouncementSorters
        {
            get
            {
                return _announcementSorters;
            }
            set
            {
                _announcementSorters = value;
                OnPropertyChanged(nameof(AnnouncementSorters));
            }
        }

        private AnnouncementSorter _selectedAnnouncementSorter;

        public AnnouncementSorter SelectedAnnouncementSorter
        {
            get
            {
                return _selectedAnnouncementSorter;
            }
            set
            {
                _selectedAnnouncementSorter = value;
                OnPropertyChanged(nameof(SelectedAnnouncementSorter));
            }
        }

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

        public ICommand CreateAnnouncementCommand { get; }

        public ICommand DeleteAnnouncementCommand { get; }

        public MyAnnouncementsViewModel(AuthorizationStore authorizationStore, NavigationService announcementsDeskNavigationService)
        {
            AuthorizationStore = authorizationStore;
            Announcements = new List<Announcement>();

            UpdateAnnouncementsCommand = new UpdateMyAnnouncementsCommand(this);

            EditAnnouncementCommand = new EditAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            CreateAnnouncementCommand = new AddAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            DeleteAnnouncementCommand = new DeleteAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);

            OpenAnnouncementsDeskCommand = new NavigateCommand(announcementsDeskNavigationService);

            AnnouncementSorters = new List<AnnouncementSorter>
            {
                new AnnouncementSorter<DateTime>("Дата находки раньше", announcement => announcement.PublishDate, false),
                new AnnouncementSorter<DateTime>("Дата находки позже", announcement => announcement.PublishDate, true),
                new AnnouncementSorter<string>("Имя животного", announcement => announcement.AnimalName, false),
                new AnnouncementSorter<string>("Категория животного", announcement => announcement.AnimalCategory, false)
            };

            SelectedAnnouncementSorter = AnnouncementSorters[0];

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
