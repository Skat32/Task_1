using Models.Enums;

namespace Models.Entities
{
    public class User : Base
    {
        /// <summary>
        /// ФИО (текст, кирилица)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public CitiesEnum Type { get; set; }
    }
}