namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Course;
    using KnowledgeSpreadSystem.Web.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

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

        public ActionResult Course(int courseId)
        {
            var course = this.CurrentUser.Courses.AsQueryable().FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {

                var result = Mapper.Map<CourseViewModel>(course);

                ViewBag.IsModerator = course.Moderators.Any(u => u.Id == this.CurrentUser.Id);
                return this.View(result);
            }

            this.AddNotification("No such course exists in your enrolled courses!", "error");
            return this.RedirectToAction("Index");
        }

        public ActionResult Index(int? courseId, string moduleName)
        {

            if (courseId.HasValue)
            {
               
            }

            return View();
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