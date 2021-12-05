using System.Collections.Generic;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Models;
using FindAnnouncements.Services;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class AnnouncementsDeskViewModel : BaseAnnouncementDeskViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand UpdateAnnouncementsCommand { get; }
        public ICommand CreateAnnouncementCommand { get; }
        public ICommand OpenMyAnnouncementsCommand { get; }
        public ICommand AnnouncementsFilterCommand { get; }

        public AnnouncementsDeskViewModel(AuthorizationStore authorizationStore, NavigationService loginNavigationService, NavigationService myAnnouncementsNavigationService)
        {
            Announcements = new List<Announcement>();
            AuthorizationStore = authorizationStore;

            AnnouncementSorters = new List<AnnouncementSorter>
            {
                new AnnouncementSorter("Дата находки раньше", "PublishDate", false),
                new AnnouncementSorter("Дата находки позже", "PublishDate", true),
                new AnnouncementSorter("Имя животного", "AnimalName", false),
                new AnnouncementSorter("Категория животного", "AnimalCategory", false)
            };
            SelectedAnnouncementSorter = AnnouncementSorters[0];
            
            AnnouncementsFilter = new AnnouncementFilter();

            LoginCommand = new NavigateCommand(loginNavigationService);
            OpenMyAnnouncementsCommand = new NavigateCommand(myAnnouncementsNavigationService);
            UpdateAnnouncementsCommand = new UpdateAnnouncementsCommand(this);
            AnnouncementsFilterCommand = new EditAnnouncementFilterCommand(this);
            CreateAnnouncementCommand = new AddAnnouncementCommand(AuthorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
