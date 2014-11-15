namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourceEntity;

    public class Insight : ResourceEntity, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
