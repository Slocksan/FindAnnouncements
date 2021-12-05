using System.ComponentModel;

namespace FindAnnouncements.Enums
{
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Мальчик
        /// </summary>
        [Description("Мальчик")]
        Boy = 0,
        /// <summary>
        /// Девочка
        /// </summary>
        [Description("Девочка")]
        Girl = 1,
    }
}
