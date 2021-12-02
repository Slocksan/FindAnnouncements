using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq.Expressions;

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
                var announcements = context.Announcements.Where(announ => announ.AnnounID == announcementToEdit.AnnounID);
                if (announcements.Any())
                {
                    context.Announcements.Remove(announcements.First());
                    context.Announcements.Add(announcementToEdit);
                    context.SaveChanges();
                }
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


        public static List<Announcement> GetAllAnnouncements<TOrderBy>(Expression<Func<Announcement, bool>> filter, Expression<Func<Announcement, TOrderBy>> sorter)
        {
            using (var context = new FindAnnouncementsModel())
            {
                filter = e => true;
                var AllAnnouncmentns = context.Announcements.Where(filter).OrderBy(sorter).ToList();
                return AllAnnouncmentns;
            }
        }

        public static List<Announcement> GetAllAnnouncements(Expression<Func<Announcement, bool>> filter)
            => GetAllAnnouncements<DateTime>(filter, announcement => announcement.PublishDate);

        public static List<Announcement> GetAllAnnouncements<TOrderBy>(Expression<Func<Announcement, TOrderBy>> sorter)
            => GetAllAnnouncements<TOrderBy>(announcement => true, sorter);

        public static List<Announcement> GetAllAnnouncements()
            => GetAllAnnouncements<DateTime>(announcement => true, announcement => announcement.PublishDate);
    }
}
