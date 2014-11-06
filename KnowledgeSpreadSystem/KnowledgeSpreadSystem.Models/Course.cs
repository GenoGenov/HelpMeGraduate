namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<CalendarEvent> events;

        private ICollection<CourseModule> courseModules; 
        public Course()
        {
            this.events=new HashSet<CalendarEvent>();
            this.courseModules=new HashSet<CourseModule>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(700)]
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
        public int Year { get; set; }

        [Required]
        public int FacoultyId { get; set; }

        public virtual Facoulty Facoulty { get; set; }

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
    }
}
