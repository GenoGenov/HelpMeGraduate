using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class CourseViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        [HiddenInput]
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
        public int Year { get; set; }

        [Required]
        [UIHint("UsersEditor")]
        public string Moderator { get; set; }

        [Required]
        [UIHint("FacultiesEditor")]
        public string Faculty { get; set; }

        public string University { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>()
                         .ForMember(
                                    x => x.Moderator,
                                    opt => opt.MapFrom(y => y.Moderator.UserName));

            configuration.CreateMap<Course, CourseViewModel>()
                         .ForMember(
                                    x => x.Faculty,
                                    opt => opt.MapFrom(y => y.Faculty.Name));

            configuration.CreateMap<Course, CourseViewModel>()
                         .ForMember(
                                    x => x.University,
                                    opt => opt.MapFrom(y => y.Faculty.University.Name));
        }
    }
}