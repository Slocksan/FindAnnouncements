using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.Stores;

namespace FindAnnouncements.ViewModel
{
    public abstract class BaseAnnouncementDeskViewModel : BaseViewModel
    {
        public AuthorizationStore AuthorizationStore { get; set; }

        private string _announcementsFilter;

        public string AnnouncementsFilter
        {
            get
            {
                return _announcementsFilter;
            }
            set
            {
                _announcementsFilter = value;
                OnPropertyChanged(nameof(AnnouncementsFilter));
            }
        }

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
    }
}
