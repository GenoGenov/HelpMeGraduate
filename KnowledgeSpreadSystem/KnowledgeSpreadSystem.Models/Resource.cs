namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Models.Enums;

    public class Resource
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string MIMEType { get; set; }

        public virtual CourseModule Module { get; set; }

        [Required]
        public int ModuleId { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}