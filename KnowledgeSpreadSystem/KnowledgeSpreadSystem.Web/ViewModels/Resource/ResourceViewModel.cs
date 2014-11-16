namespace KnowledgeSpreadSystem.Web.ViewModels.Resource
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Insight;

    public class ResourceViewModel : AuditInfo, IMapFrom<Resource>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Size(in bytes)")]
        public int ContentSize { get; set; }

        [Display(Name = "File Extension")]
        public string FileExtension { get; set; }

        public int Rating { get; set; }

        public SimpleViewModel Target { get; set; }

        public string ImagePath { get; set; }

        public int? CourseId { get; set; }

        public int? ModuleId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Resource, ResourceViewModel>()
                         .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));

            configuration.CreateMap<Resource, ResourceViewModel>()
                         .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName));

            configuration.CreateMap<Resource, ResourceViewModel>()
                         .ForMember(x => x.PreserveCreatedOn, opt => opt.Ignore());
        }
    }
}