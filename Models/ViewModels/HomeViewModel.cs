using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models.ViewModels
{
    public class HomeViewModel
    {
        /// <summary>
        /// ФИО (текст, кирилица)
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать ФИО пользователя")]
        public string FullName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [RegularExpression(@"^(\+[0-9]{11})$", ErrorMessage = "Не правильно указан номер телефона")]
        [Required(ErrorMessage = "Необходимо указать номер телефона")]
        public string Phone { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Не правильно указана почта")]
        [Required(ErrorMessage = "Необходимо указать почту")]
        public string Email { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать город")]
        public CitiesEnum City { get; set; }

        /// <summary>
        /// Сообщение несущее в себе внутренюю ошибку
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}