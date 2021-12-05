using System.Collections.Generic;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Models;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class MyAnnouncementsViewModel : BaseAnnouncementDeskViewModel
    {
        public ICommand OpenAnnouncementsDeskCommand { get; }
        public ICommand UpdateAnnouncementsCommand { get; }
        public ICommand EditAnnouncementCommand { get; }
        public ICommand CreateAnnouncementCommand { get; }
        public ICommand DeleteAnnouncementCommand { get; }
        public ICommand AnnouncementsFilterCommand { get; }

        public MyAnnouncementsViewModel(AuthorizationStore authorizationStore, NavigationService announcementsDeskNavigationService)
        {
            AuthorizationStore = authorizationStore;
            Announcements = new List<Announcement>();

            AnnouncementSorters = new List<AnnouncementSorter>
            {
                new AnnouncementSorter("Дата находки раньше", "PublishDate", false),
                new AnnouncementSorter("Дата находки позже", "PublishDate", true),
                new AnnouncementSorter("Имя животного", "AnimalName", false),
                new AnnouncementSorter("Категория животного", "AnimalCategory", false)
            };
            SelectedAnnouncementSorter = AnnouncementSorters[0];

            AnnouncementsFilter = new AnnouncementFilter {User = AuthorizationStore.ActualAuthorization.User};


            UpdateAnnouncementsCommand = new UpdateAnnouncementsCommand(this);
            EditAnnouncementCommand = new EditAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            CreateAnnouncementCommand = new AddAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            DeleteAnnouncementCommand = new DeleteAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            OpenAnnouncementsDeskCommand = new NavigateCommand(announcementsDeskNavigationService);
            AnnouncementsFilterCommand = new EditAnnouncementFilterCommand(this);

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
