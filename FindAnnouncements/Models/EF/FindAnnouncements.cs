using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FindAnnouncements
{
    public partial class FindAnnouncementsModel : DbContext
    {
        public FindAnnouncementsModel()
            : base("name=FindAnnouncements")
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Organization)
                .WillCascadeOnDelete();
        }
    }
}
