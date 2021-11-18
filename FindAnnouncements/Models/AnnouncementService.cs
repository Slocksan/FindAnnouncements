using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FindAnnouncements.Models
{
    public static class AnnouncementService
    {

        public static void AddAnnouncement(Announcement announcementToAdd)
        {
            using (var context = new FindAnnouncementsModel())
            {
                context.Announcements.Add(announcementToAdd);
                context.SaveChanges();
            }
        }

        public static void EditAnnouncement(Announcement announcementToEdit, Announcement newAnnouncement)
        {
            using (var context = new FindAnnouncementsModel())
            {
                var announcement=context.Announcements.Find(announcementToEdit);
                announcement = newAnnouncement;
                context.SaveChanges();
            }
        }

        public static void DeleteAnnouncement(Announcement announcementToDelete)
        {
            using (var context = new FindAnnouncementsModel())
            {
                context.Announcements.Remove(announcementToDelete);
                context.SaveChanges();
            }
        }


        public static List<Announcement> GetAllAnnouncements()
        {
            using (var context = new FindAnnouncementsModel())
            {
                var AllAnnouncmentns = context.Announcements.ToList();
                return AllAnnouncmentns;
            }
        }
    }
}
