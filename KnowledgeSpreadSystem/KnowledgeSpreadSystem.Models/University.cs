namespace KnowledgeSpreadSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class University
    {
        private ICollection<CalendarEvent> events;

        private ICollection<Facoulty> facoulties;
 
        public University()
        {
            this.events=new HashSet<CalendarEvent>();
            this.facoulties=new HashSet<Facoulty>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
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

        public virtual ICollection<Facoulty> Facoulties
        {
            get
            {
                return this.facoulties;
            }
            set
            {
                this.facoulties = value;
            }
        }
    }
}
