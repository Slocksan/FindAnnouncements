using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FindAnnouncements.Models
{
    public class AnnouncementSorter
    {
        public string SorterName { get; set; }

        public string SorterExpression { get; set; }

        public bool ByDescending { get; set; }

        public AnnouncementSorter(string name, string expression, bool byDescending)
        {
            SorterName = name;
            SorterExpression = expression;
            ByDescending = byDescending;
        }
    }
}
