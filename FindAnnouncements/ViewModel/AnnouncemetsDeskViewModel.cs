using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    class AnnouncemetsDeskViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public Authorization Authorization { get; set; }

        public List<Announcement> Announcements { get; set; } =
            AnnouncementService.GetAllAnnouncements().Where(e => e.UserID == 1).ToList();

        public AnnouncemetsDeskViewModel(NavigationStore navigationStore, Authorization authorization)
        {
            _navigationStore = navigationStore;
            Authorization = authorization;
        }
    }
}
