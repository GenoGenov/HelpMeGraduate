namespace KnowledgeSpreadSystem.Web.ViewModels.Insight
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class InsightViewModel : AuditInfo, IMapFrom<Insight>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Content { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public string AuthorId { get; set; }

        public string Author { get; set; }

        public SimpleViewModel Target { get; set; }

        public int Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Insight, InsightViewModel>()
                         .ForMember(x => x.PreserveCreatedOn, opt => opt.Ignore());

            configuration.CreateMap<Insight, InsightViewModel>()
                         .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName));
        }
    }
}