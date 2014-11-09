using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class CourseViewModel : IMapFrom<Course>
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

        [UIHint("UsersEditor")]
        public IList<UserViewModel> Moderators { get; set; }

        [Required]
        [UIHint("FacultiesEditor")]
        public FacultyViewModel Faculty { get; set; }
    }
}