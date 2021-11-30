using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindAnnouncements.Enums
{
    public static class WorkWithEnumExtansion
    {
        public static string GetEnumDecription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
                return attributes.First().Description;
            return value.ToString();

        }

        public static List<string> GetListOfEnumsDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => e.GetEnumDecription()).ToList();
        }
    }
}
