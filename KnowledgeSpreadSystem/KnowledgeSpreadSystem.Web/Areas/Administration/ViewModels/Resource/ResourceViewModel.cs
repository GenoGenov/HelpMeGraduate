﻿namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Resource
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class ResourceViewModel : AdminViewModel, IMapFrom<Resource>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "File Extension")]
        public string FileExtension { get; set; }

        public string Author { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "MIME Type")]
        public string MIMEType { get; set; }

        [Display(Name = "Size(in bytes)")]
        public int ContentSize { get; set; }

        public double Rating { get; set; }

        public string Target { get; set; }

        public int? CourseId { get; set; }

        public int? ModuleId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Resource, ResourceViewModel>()
                         .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));

            configuration.CreateMap<Resource, ResourceViewModel>()
                         .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName));
        }
    }
}