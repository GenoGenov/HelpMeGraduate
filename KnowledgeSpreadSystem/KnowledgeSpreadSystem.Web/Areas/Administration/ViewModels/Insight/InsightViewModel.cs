namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Insight
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class InsightViewModel : AdminViewModel, IMapFrom<Insight>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public string Target { get; set; }

        public string Author { get; set; }

        [UIHint("CourseEditor")]
        public SimpleViewModel Course { get; set; }

        [UIHint("_ModulesEditor")]
        public SimpleViewModel Module { get; set; }

        public double Rating { get; set; }

        public string AuthorId { get; set; }

        public int? CourseId { get; set; }

        public int? ModuleId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Insight, InsightViewModel>()
                        .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName));

            configuration.CreateMap<Insight, InsightViewModel>()
                        .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));

            configuration.CreateMap<InsightViewModel, Insight>()
                        .ForMember(
                                   x => x.CourseId,
                                   opt => opt.MapFrom(y => y.Course.Id));
            configuration.CreateMap<InsightViewModel, Insight>()
                        .ForMember(
                                   x => x.ModuleId,
                                   opt => opt.MapFrom(y => y.Module.Id));

            configuration.CreateMap<InsightViewModel, Insight>().ForMember(x => x.Course, opt => opt.Ignore());
            configuration.CreateMap<InsightViewModel, Insight>().ForMember(x => x.Module, opt => opt.Ignore());
            configuration.CreateMap<InsightViewModel, Insight>().ForMember(x => x.Author, opt => opt.Ignore());
        }
    }
}