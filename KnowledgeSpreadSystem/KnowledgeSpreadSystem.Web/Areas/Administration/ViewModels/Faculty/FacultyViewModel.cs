namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class FacultyViewModel : AdminViewModel, IMapFrom<Faculty>, ISimpleView<SimpleViewModel>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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
            //Mapper.CreateMap<SimpleViewModel>(typeof(UniversityViewModel));
            //configuration.CreateMap<Faculty, FacultyViewModel>()
            //             .ForMember(
            //                        x => x.University,
            //                        opt => opt.MapFrom(y => y.University));
        }
    }
}