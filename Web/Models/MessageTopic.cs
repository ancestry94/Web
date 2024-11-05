using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class MessageTopic
    {
        [Key]
        public int TopicId { get; set; }

        [Required]
        [StringLength(100)]
        public string TopicName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}