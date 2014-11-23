namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels.Course;

    [Authorize]
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

            if (course == null)
            {
                this.AddNotification("No course exists with the given ID !", "error");
                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.Enrolled = this.CurrentUser.Courses.Any(c => c.Id == course.Id);

            var mapped = Mapper.Map<CourseViewModel>(course);

            ViewBag.UniversityName = course.Faculty.University.Name;
            ViewBag.UniversityId = course.Faculty.UniversityId;

            ViewBag.FacultyName = course.Faculty.Name;
            ViewBag.FacultyId = course.FacultyId;

            return View(mapped);
        }

        public ActionResult Enroll(int id)
        {
            var course = this.Data.Courses.Find(id);

            if (course == null)
            {
                this.AddNotification("No course exists with the given ID !", "error");
                return this.RedirectToAction("Index", "Home");
            }

            if (this.CurrentUser.Courses.Any(c => c.Id == course.Id))
            {
                this.AddNotification("You are already enrolled for course " + course.Name + "!", "error");
                return this.RedirectToAction("Details", new { id = id });
            }

            this.CurrentUser.Courses.Add(course);
            this.Data.SaveChanges();
            this.AddNotification("You are enroled for the course " + course.Name + "!", "success");
            return this.RedirectToAction("Details", new { id = id });
        }

        public ActionResult Unenroll(int id)
        {
            var course = this.Data.Courses.Find(id);

            if (course == null)
            {
                this.AddNotification("No course exists with the given ID !", "error");
                return this.RedirectToAction("Index", "Home");
            }

            if (this.CurrentUser.Courses.Any(c => c.Id == course.Id))
            {
                this.CurrentUser.Courses.Remove(course);
                this.Data.SaveChanges();
                this.AddNotification("You have unenrolled for the course " + course.Name + "!", "success");
                return this.RedirectToAction("Details", new { id = id });
            }

            this.AddNotification("You are NOT enrolled for course " + course.Name + "!", "error");
            return this.RedirectToAction("Details", new { id = id });
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60 * 15)]
        public ActionResult Latest([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.Data.Courses
                .All()
                .OrderByDescending(x => x.CreatedOn);

            var courses = data.Project().To<CourseViewModel>()
                 .ForEach(x =>
                 {
                     x.Description = x.Description.ToShortString(250);
                     return x;
                 });
            return this.Json(courses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int id)
        {
            var data = this.Data.Courses.All().Where(x => x.FacultyId == id);

            var courses = data.Project().To<CourseViewModel>()
                 .ForEach(x =>
                 {
                     x.Description = x.Description.ToShortString(250);
                     return x;
                 });
            return this.Json(courses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}