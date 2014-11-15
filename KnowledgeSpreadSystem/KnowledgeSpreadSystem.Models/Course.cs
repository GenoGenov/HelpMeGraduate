namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourcefulEntity;

    public class Course : ResourcefulEntity, IDeletableEntity
    {

        private ICollection<CourseModule> courseModules;

        private ICollection<User> moderators;

        private ICollection<User> participants;

        public Course()
        {
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

        public virtual ICollection<User> Moderators
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

        public virtual ICollection<User> Participants
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
