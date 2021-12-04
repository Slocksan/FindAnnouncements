using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FindAnnouncements.Models
{
    public abstract class AnnouncementSorter
    {
        public abstract Type GetTypeOfGeneric();
    }

    public class AnnouncementSorter<TOrderBy> : AnnouncementSorter
    {
        public string SorterName { get; set; }

        public Expression<Func<Announcement, TOrderBy>> SorterExpression { get; set; }

        public bool ByDescending { get; set; }

        public AnnouncementSorter(string name, Expression<Func<Announcement, TOrderBy>> expression, bool byDescending)
        {
            SorterName = name;
            SorterExpression = expression;
            ByDescending = byDescending;
        }

        public override Type GetTypeOfGeneric() => typeof(TOrderBy);
    }
}
