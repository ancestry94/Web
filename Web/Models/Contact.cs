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
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [StringLength(15, ErrorMessage = "Номер телефона не должен превышать 15 символов.")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}