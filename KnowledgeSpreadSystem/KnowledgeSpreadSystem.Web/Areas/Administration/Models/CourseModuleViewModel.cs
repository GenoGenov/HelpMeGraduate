namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class CourseModuleViewModel : IMapFrom<CourseModule>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

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
        public string Moderator { get; set; }

        [Required]
        public string Course { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CourseModule, CourseModuleViewModel>()
                         .ForMember(
                                    x => x.Moderator,
                                    opt => opt.MapFrom(y => y.Moderator.UserName));

            configuration.CreateMap<CourseModule, CourseModuleViewModel>()
                         .ForMember(
                                    x => x.Course,
                                    opt => opt.MapFrom(y => y.Course.Name));
        }
    }
}