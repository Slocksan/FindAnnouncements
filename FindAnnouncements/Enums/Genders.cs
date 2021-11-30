using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
