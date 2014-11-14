namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class CourseModule : AuditInfo, IDeletableEntity
    {
        private ICollection<CalendarEvent> events;

        private ICollection<Insight> insights;
 
        public CourseModule()
        {
            this.insights = new HashSet<Insight>();
            this.events = new HashSet<CalendarEvent>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Started { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Lecturer { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<CalendarEvent> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }

        public ICollection<Insight> Insights
        {
            get
            {
                return this.insights;
            }
            set
            {
                this.insights = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
