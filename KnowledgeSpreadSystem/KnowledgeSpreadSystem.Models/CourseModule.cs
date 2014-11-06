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
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Started { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string LecturerId { get; set; }

        public virtual User Lecturer { get; set; }

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


    }
}
