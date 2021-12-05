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
