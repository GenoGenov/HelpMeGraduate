using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeSpreadSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
