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
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class UniversityViewModel : AdminViewModel, IMapFrom<University>, ISimpleView<SimpleViewModel>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MinLength(20)]
        [MaxLength(700)]
        public string About { get; set; }

        //public ICollection<FacultyViewModel> Faculties { get; set; }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<University, UniversityViewModel>().
        //}
    }
}