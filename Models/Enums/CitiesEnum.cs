using System.ComponentModel;

namespace Models.Enums
{
    /// <summary>
    /// Предположим, что у нас тут список всех городов
    /// </summary>
    public enum CitiesEnum
    {
        /// <summary>
        /// Москва
        /// </summary>
        [Description("Москва")]
        Msk = 1,
        
        /// <summary>
        /// Брянск
        /// </summary>
        [Description("Брянск")]
        Bryansk = 2,
        
        /// <summary>
        /// Новосибирск
        /// </summary>
        [Description("Новосибирск")]
        Novosib = 3,
        
        /// <summary>
        /// Питер
        /// </summary>
        [Description("Питер")]
        Piter = 4
    }
}