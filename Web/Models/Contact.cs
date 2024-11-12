using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Email обязателен для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат email.")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов.")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен для заполнения.")]
        [RegularExpression(@"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "Ошибка ввода номера телефона. Формат: +7(999)999-99-99")]
        [StringLength(16, ErrorMessage = "Номер телефона не должен превышать 16 символов.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваше сообщение.")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}