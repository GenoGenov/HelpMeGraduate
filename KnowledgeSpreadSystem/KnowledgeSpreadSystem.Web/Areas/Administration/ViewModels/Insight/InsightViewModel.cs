namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Insight
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class InsightViewModel : AdminViewModel, IMapFrom<Insight>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Target { get; set; }

        public string Author { get; set; }

        public int? CourseId { get; set; }

        public int? ModuleId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Insight, InsightViewModel>()
                        .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName));
        }
    }
}