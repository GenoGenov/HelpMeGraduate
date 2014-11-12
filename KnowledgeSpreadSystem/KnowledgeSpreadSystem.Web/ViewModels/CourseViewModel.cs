namespace KnowledgeSpreadSystem.Web.ViewModels
{
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;

    public class CourseViewModel : BaseViewModel, IMapFrom<Course>
    {
        public string Description { get; set; }

        public int Year { get; set; }
    }
}