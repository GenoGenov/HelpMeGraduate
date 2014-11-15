namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourceEntity;

    public class CalendarEvent : ResourceEntity, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Content { get; set; }


        [Required]
        public DateTime TargetDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}