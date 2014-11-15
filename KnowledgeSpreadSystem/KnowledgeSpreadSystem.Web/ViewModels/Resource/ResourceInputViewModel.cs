namespace KnowledgeSpreadSystem.Web.ViewModels.Resource
{
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;

    public class ResourceInputViewModel
    {     

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public SimpleViewModel Target { get; set; }

        public string AllowedFileFormats { get; set; }
    }
}