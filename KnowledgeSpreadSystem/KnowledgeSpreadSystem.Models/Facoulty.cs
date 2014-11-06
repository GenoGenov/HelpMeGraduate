namespace KnowledgeSpreadSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Facoulty
    {
        private ICollection<Course> courses; 
        public Facoulty()
        {
            this.courses=new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public int Name { get; set; }

        [Required]
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        [MinLength(10)]
        [MaxLength(800)]
        public string Description { get; set; }
    }
}
