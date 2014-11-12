namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Module
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class CourseModuleViewModel : AdminViewModel, IMapFrom<CourseModule>,IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime Started { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime End { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Lecturer { get; set; }

        [Required]
        [UIHint("CourseEditor")]
        public SimpleViewModel Course { get; set; }

        public SimpleViewModel University { get; set; }

        public SimpleViewModel Faculty { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CourseModule, CourseModuleViewModel>()
                         .ForMember(x => x.Faculty, opt => opt.MapFrom(y => y.Course.Faculty));

            configuration.CreateMap<CourseModule, CourseModuleViewModel>()
                        .ForMember(x => x.University, opt => opt.MapFrom(y => y.Course.Faculty.University));

            configuration.CreateMap<CourseModuleViewModel, CourseModule>()
                        .ForMember(
                                   x => x.CourseId,
                                   opt => opt.MapFrom(y => y.Course.Id));

            configuration.CreateMap<CourseModuleViewModel, CourseModule>().ForMember(x => x.Course, opt => opt.Ignore());
        }
    }
}