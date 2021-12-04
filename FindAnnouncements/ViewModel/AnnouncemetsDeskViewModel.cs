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
    class AnnouncemetsDeskViewModel : BaseAnnouncementDeskViewModel
    {
        public ICommand LoginCommand { get; }

        public ICommand UpdateAnnouncementsCommand { get; }

        public ICommand CreateAnnouncementCommand { get; }

        public ICommand OpenMyAnnouncementsCommand { get; }

        public AnnouncemetsDeskViewModel(AuthorizationStore authorizationStore, NavigationService loginNavigationService, NavigationService myAnnouncementsNavigationService)
        {
            Announcements = new List<Announcement>();

            LoginCommand = new NavigateCommand(loginNavigationService);
            OpenMyAnnouncementsCommand = new NavigateCommand(myAnnouncementsNavigationService);
            AuthorizationStore = authorizationStore;

            CreateAnnouncementCommand = new AddAnnouncementCommand(AuthorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);

            AnnouncementSorters = new List<AnnouncementSorter>
            {
                new AnnouncementSorter("Дата находки раньше", "PublishDate", false),
                new AnnouncementSorter("Дата находки позже", "PublishDate", true),
                new AnnouncementSorter("Имя животного", "AnimalName", false),
                new AnnouncementSorter("Категория животного", "AnimalCategory", false)
            };

            AnnouncementsFilter = "true";

            SelectedAnnouncementSorter = AnnouncementSorters[0];

            UpdateAnnouncementsCommand = new UpdateAnnouncementsCommand(this);

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
