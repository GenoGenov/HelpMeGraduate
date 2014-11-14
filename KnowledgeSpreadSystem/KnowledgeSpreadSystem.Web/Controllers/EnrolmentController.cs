namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels;
    using KnowledgeSpreadSystem.Web.ViewModels.Course;

    [Authorize]
    public class EnrolmentController : BaseController
    {
        // GET: Enrolment
        public EnrolmentController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Module(int id)
        {
            var module = this.Data.CourseModules.Find(id);
            if (module != null && this.CurrentUser.Courses.Any(c => c.Id == module.CourseId))
            {
                
            }
            return this.View();
        }

        public ActionResult Course(int id)
        {
            return Content(id.ToString());
        }

        public ActionResult Index(int? page)
        {
            var currentPage = page ?? 1;
            ViewBag.Page = currentPage;
            var courses =
                this.CurrentUser.Courses.AsQueryable()
                    .OrderBy(c => c.Name)
                    .Skip(10 * (currentPage - 1))
                    .Take(10)
                    .Project()
                    .To<CourseViewModel>();

            ViewBag.Total = this.CurrentUser.Courses.Count();
            return View(courses);
        }

        public JsonResult SideMenu(int? id)
        {
            if (id.HasValue)
            {
                var course = this.CurrentUser.Courses.FirstOrDefault(x => x.Id == id);
                if (course != null)
                {
                    var modules = course.CourseModules.Select(
                                                              m => new { id = m.Id, Name = m.Name, hasChildren = false });
                    return this.Json(modules, JsonRequestBehavior.AllowGet);
                }

                    return null;
            }

            return
                this.Json(
                     this.CurrentUser.Courses.Select(
                                                     c =>
                                                     new
                                                         {
                                                             id = c.Id,
                                                             Name = c.Name,
                                                             hasChildren = c.CourseModules.Any(),
                                                         }),
                     JsonRequestBehavior.AllowGet);

        }
    }
}