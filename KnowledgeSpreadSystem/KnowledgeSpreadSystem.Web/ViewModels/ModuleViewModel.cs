namespace KnowledgeSpreadSystem.Web.ViewModels
{
    using System;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;

    public class ModuleViewModel : BaseViewModel, IMapFrom<CourseModule>
    {
        public string Description { get; set; }

        public DateTime Started { get; set; }

        public DateTime End { get; set; }

        public string Lecturer { get; set; }
    }
}