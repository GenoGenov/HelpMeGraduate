namespace KnowledgeSpreadSystem.Web.ViewModels.Course
{
    using System.Collections.Generic;

    using KnowledgeSpreadSystem.Web.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public abstract class DetailedCourseViewModel : CourseViewModel
    {
        public IList<ResourceInputViewModel> TopResources { get; set; }

        public IList<InsightViewModel> TopInsights { get; set; }
    }
}