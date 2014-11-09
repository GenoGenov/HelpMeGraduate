namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ForumSystem.Data.Common.Models;

    public class CalendarEvent : AuditInfo, IDeletableEntity
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

        public virtual User Creator { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public int ModuleId { get; set; }

        public virtual CourseModule Module { get; set; }

        [Required]
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}