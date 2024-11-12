using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваше сообщение.")]
        public string MessageText { get; set; }

        [ForeignKey("MessageTopic")]
        public int? TopicId { get; set; }

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }

        public virtual MessageTopic MessageTopic { get; set; }
        public virtual Contact Contact { get; set; }
    }
}