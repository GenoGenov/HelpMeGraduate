namespace KnowledgeSpreadSystem.Web.ViewModels.Rating
{
    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class RatingViewModel 
    {
        public int Id { get; set; }

        public string TargetId { get; set; }

        public int? Value { get; set; }

        public string RouteToAction { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //configuration.CreateMap<Rating, RatingViewModel>()
            //             .ForMember(x => x.InsightId, opt => opt.MapFrom(y => y.InsightId.ToString()))
            //             .ForMember(x => x.ResourceId, opt => opt.MapFrom(y => y.ResourceId.ToString()));
        }
    }
}