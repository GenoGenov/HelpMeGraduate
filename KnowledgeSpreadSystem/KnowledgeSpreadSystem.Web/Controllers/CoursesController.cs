namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels;

    public class CoursesController : BaseController
    {
        // GET: Courses
        public CoursesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var course = this.Data.Courses.Find(id);

            var mapped = Mapper.Map<CourseViewModel>(course);

            ViewBag.UniversityName = course.Faculty.University.Name;
            ViewBag.UniversityId = course.Faculty.UniversityId;

            ViewBag.FacultyName = course.Faculty.Name;
            ViewBag.FacultyId = course.FacultyId;

            return View(mapped);
        }

        public ActionResult All()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Courses.All();
            data = id == null ? data : data.Where(x => x.FacultyId == id);

            var courses = data.Project().To<CourseViewModel>();
            var coursesShortenedDescription = courses.ForEach(
                                                                  x =>
                                                                  {
                                                                      x.Description = x.Description.ToShortString(200);
                                                                      return x;
                                                                  });
            return this.Json(coursesShortenedDescription.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}