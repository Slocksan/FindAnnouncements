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
    class MyAnnouncementsViewModel : BaseAnnouncementDeskViewModel
    {
        public ICommand OpenAnnouncementsDeskCommand { get; }

        public ICommand UpdateAnnouncementsCommand { get; }

        public ICommand EditAnnouncementCommand { get; }

        public ICommand CreateAnnouncementCommand { get; }

        public ICommand DeleteAnnouncementCommand { get; }

        public MyAnnouncementsViewModel(AuthorizationStore authorizationStore, NavigationService announcementsDeskNavigationService)
        {
            AuthorizationStore = authorizationStore;
            Announcements = new List<Announcement>();

            UpdateAnnouncementsCommand = new UpdateAnnouncementsCommand(this);

            EditAnnouncementCommand = new EditAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            CreateAnnouncementCommand = new AddAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);
            DeleteAnnouncementCommand = new DeleteAnnouncementCommand(authorizationStore.ActualAuthorization.User, UpdateAnnouncementsCommand);

            OpenAnnouncementsDeskCommand = new NavigateCommand(announcementsDeskNavigationService);

            AnnouncementSorters = new List<AnnouncementSorter>
            {
                new AnnouncementSorter("Дата находки раньше", "PublishDate", false),
                new AnnouncementSorter("Дата находки позже", "PublishDate", true),
                new AnnouncementSorter("Имя животного", "AnimalName", false),
                new AnnouncementSorter("Категория животного", "AnimalCategory", false)
            };

            AnnouncementsFilter = $"UserId == {authorizationStore.ActualAuthorization.User.UserID}";

            SelectedAnnouncementSorter = AnnouncementSorters[0];

            UpdateAnnouncementsCommand.Execute(null);
        }
    }
}
