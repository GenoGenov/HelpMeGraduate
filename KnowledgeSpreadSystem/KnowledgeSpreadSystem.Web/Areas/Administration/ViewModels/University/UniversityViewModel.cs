namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.University
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class UniversityViewModel : AdminViewModel, IMapFrom<University>, ISimpleView<SimpleViewModel>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MinLength(20)]
        [MaxLength(700)]
        public string About { get; set; }

    }
}