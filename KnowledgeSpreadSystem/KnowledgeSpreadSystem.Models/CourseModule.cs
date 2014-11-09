using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeSpreadSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseModule
    {
        private ICollection<CalendarEvent> events;
        public CourseModule()
        {
            this.events=new HashSet<CalendarEvent>();
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

        [Required]
        public string ModeratorId { get; set; }

        public User Moderator { get; set; }

    }
}
