using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        //public IList<CourseViewModel> Courses { get; set; }

        //public IList<CourseModuleViewModel> CourseModules { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {

            //configuration.CreateMap<User, UserViewModel>()
            //             .ForMember(
            //                        x => x.Courses,
            //                        opt => opt.MapFrom(y => y.Courses));
            //configuration.CreateMap<User, UserViewModel>()
            //             .ForMember(
            //                        x => x.ModeratorForModules,
            //                        opt =>
            //                        opt.MapFrom(
            //                                    y => y.CourseModules.AsQueryable().Project().To<CourseModuleViewModel>()));
        }
    }
}