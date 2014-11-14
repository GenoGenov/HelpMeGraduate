namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class Insight : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
