namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Course;

    public class HomeController : BaseController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public HomeController()
            : base(new KSSData())
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult SearchCourse(string filter)
        {
            var result =
                this.Data.Courses.All()
                    .Where(x => x.Name.ToLower().Contains(filter.ToLower()))
                    .Project()
                    .To<CourseViewModel>()
                    .ToList();
            ViewBag.Filter = filter;
            return this.View(result);
        }

    }
}