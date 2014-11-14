namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class Course : AuditInfo, IDeletableEntity
    {
        private ICollection<CalendarEvent> events;

        private ICollection<CourseModule> courseModules;

        private ICollection<User> moderators;

        private ICollection<User> participants;

        public Course()
        {
            this.events = new HashSet<CalendarEvent>();
            this.courseModules = new HashSet<CourseModule>();
            this.moderators = new HashSet<User>();
            this.participants = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(400)]
        public string Description { get; set; }

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

        [Required]
        [Range(2000, 2100)]
        public int Year { get; set; }

        [Required]
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<CourseModule> CourseModules
        {
            get
            {
                return this.courseModules;
            }
            set
            {
                this.courseModules = value;
            }
        }

        public ICollection<User> Moderators
        {
            get
            {
                return this.moderators;
            }
            set
            {
                this.moderators = value;
            }
        }

        public ICollection<User> Participants
        {
            get
            {
                return this.participants;
            }

            set
            {
                this.participants = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
