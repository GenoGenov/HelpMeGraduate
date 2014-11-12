namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Course
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class CourseViewModel : AdminViewModel, IMapFrom<Course>, ISimpleView<SimpleViewModel>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [Range(2000, 2100)]
        public int Year { get; set; }

        [UIHint("FacultiesEditor")]
        public SimpleViewModel Faculty { get; set; }

        public SimpleViewModel University { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>()
                        .ForMember(x => x.Faculty, opt => opt.MapFrom(y => y.Faculty));

            configuration.CreateMap<Course, CourseViewModel>()
                         .ForMember(x => x.University, opt => opt.MapFrom(y => y.Faculty.University));
        }
    }
}