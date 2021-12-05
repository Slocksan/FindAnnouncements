using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnnouncements.Models
{
    public class AnnouncementFilter
    {
        public User User { get; set; }
        public string AnimalCategory { get; set; } = "";
        public string Gender { get; set; } = "";

        public bool IsUsedDateFilter { get; set; } = false;
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime EndDate { get; set; } = DateTime.Now;

        public string FilterExpression
        {
            get
            {
                var filterExpression = String.Empty;

                filterExpression += User == null ? "true " : $"UserID == \"{User.UserID}\" ";

                filterExpression += AnimalCategory != "" ? $" && AnimalCategory == \"{AnimalCategory}\" " : "";
                filterExpression += Gender != "" ? $" && Gender == \"{Gender}\" " : "";

                filterExpression += IsUsedDateFilter ? $" && ( DateTime({StartDate.ToString("yyyy, MM, dd")}) <= PublishDate && PublishDate <= DateTime({EndDate.ToString("yyyy, MM, dd")}))" : "";

                return filterExpression;
            }
        }
    }
}
