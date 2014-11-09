namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class University : AuditInfo, IDeletableEntity
    {
        private ICollection<CalendarEvent> events;

        private ICollection<Faculty> faculties;
 
        public University()
        {
            this.events = new HashSet<CalendarEvent>();
            this.faculties = new HashSet<Faculty>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

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

        [MinLength(20)]
        [MaxLength(700)]
        public string About { get; set; }

        public virtual ICollection<Faculty> Faculties
        {
            get
            {
                return this.faculties;
            }
            set
            {
                this.faculties = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
