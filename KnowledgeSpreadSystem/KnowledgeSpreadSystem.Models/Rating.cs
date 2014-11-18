namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourceEntity;

    public class Rating : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public User Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public Guid InsightId { get; set; }

        public virtual Insight Insight { get; set; }

        public Guid ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
