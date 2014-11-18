namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourceEntity;

    public class Resource : ResourceEntity, IDeletableEntity
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

        [Required]
        public int ContentSize { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [DefaultValue(0)]
        public double Rating { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}