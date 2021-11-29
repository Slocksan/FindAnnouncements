using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Enums;

namespace FindAnnouncements.ViewModel
{
    class WorkWithAnnouncementViewModel
    {
        public string[] AnimalTypes { get; set; } = Enum.GetNames(typeof(AnimalType));

        public WorkWithAnnouncementViewModel(Announcement announcement, User user)
        {
            
        }
    }
}
