using System.ComponentModel;

namespace FindAnnouncements.Enums
{
    /// <summary>
    /// Типы животных.
    /// </summary>
    public enum AnimalType
    {
        /// <summary>
        /// Кошка
        /// </summary>
        [Description("Кошка")]
        Cat = 0,
        /// <summary>
        /// Собака
        /// </summary>
        [Description("Собака")]
        Dog = 1,
        /// <summary>
        /// Змея
        /// </summary>
        [Description("Змея")]
        Snake = 2,

    }
}