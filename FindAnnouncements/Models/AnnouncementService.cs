using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

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

        public static void EditAnnouncement(Announcement announcementToEdit)
        {
            using (var context = new FindAnnouncementsModel())
            {
                var announcement = context.Announcements.Find(announcementToEdit.AnnounID);
                if (announcement != null)
                {
                    context.Announcements.Remove(announcement);
                    context.Announcements.Add(announcementToEdit);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteAnnouncement(Announcement announcementToDelete)
        {
            using (var context = new FindAnnouncementsModel())
            {
                var announcement = context.Announcements.Find(announcementToDelete.AnnounID);
                if (announcement != null)
                {
                    context.Announcements.Remove(announcement);
                    context.SaveChanges();
                }
            }
        }

        public static List<Announcement> GetAnnouncements(string filter, string sorter)
        {
            using (var context = new FindAnnouncementsModel())
            {
                var allAnnouncements = context.Announcements.Where(filter).OrderBy(sorter).ToList();
                return allAnnouncements;
            }
        }

        public static List<Announcement> GetAllAnnouncements()
            => GetAnnouncements("true", "PublishDate");
    }
}
