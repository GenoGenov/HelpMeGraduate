namespace KnowledgeSpreadSystem.Web.ViewModels.Resource
{
    using System.ComponentModel.DataAnnotations;

    public class ResourceInputViewModel
    {     

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }
    }
}