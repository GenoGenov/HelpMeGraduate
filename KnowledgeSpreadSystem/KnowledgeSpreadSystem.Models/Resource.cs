namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Enums;

    public class Resource : AuditInfo, IDeletableEntity
    {
        public Resource()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string MIMEType { get; set; }

        public virtual CourseModule Module { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }

        [Required]
        public int ContentSize { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public int Rating { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}