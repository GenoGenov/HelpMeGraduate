namespace KnowledgeSpreadSystem.Models.Base.ResourceEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public abstract class ResourceEntity : AuditInfo, IResourceEntity
    {

        public virtual CourseModule Module { get; set; }

        public int? ModuleId { get; set; }

        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
