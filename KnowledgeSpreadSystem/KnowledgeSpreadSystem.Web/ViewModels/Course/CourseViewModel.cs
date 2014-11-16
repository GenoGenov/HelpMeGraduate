namespace KnowledgeSpreadSystem.Web.ViewModels.Course
{
    using System.Collections.Generic;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public class CourseViewModel : BaseViewModel, IMapFrom<Course>
    {
        public string Description { get; set; }

        public int Year { get; set; }
    }
}