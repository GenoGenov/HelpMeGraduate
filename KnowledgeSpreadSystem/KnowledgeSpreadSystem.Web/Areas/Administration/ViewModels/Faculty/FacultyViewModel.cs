namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Faculty
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class FacultyViewModel : AdminViewModel, IMapFrom<Faculty>, ISimpleView<SimpleViewModel>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(800)]
        public string Description { get; set; }

        [UIHint("UniversitiesEditor")]
        public SimpleViewModel University { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<FacultyViewModel, Faculty>()
                         .ForMember(
                                    x => x.UniversityId,
                                    opt => opt.MapFrom(y => y.University.Id));

            configuration.CreateMap<FacultyViewModel, Faculty>().ForMember(x => x.University, opt => opt.Ignore());
        }
    }
}