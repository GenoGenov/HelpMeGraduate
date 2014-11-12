namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Course;

    public class ModulesController : AdministratorController
    {
        // GET: Administration/CourseModules
        public ModulesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            this.ViewData["courses"] = this.Data.Courses.All().Project().To<CourseViewModel>();
            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        [HttpPost]
        public JsonResult AllCourseModules([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.CourseModules.All().Project().To<CourseModuleViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateCourseModule(
            [DataSourceRequest] DataSourceRequest request,
            CourseModuleViewModel courseModule)
        {
            if (courseModule.End <= courseModule.Started)
            {
                ModelState.AddModelError(string.Empty, "The end date must be after the start date");
            }

            if (this.ModelState.IsValid)
            {
                var newModule = new CourseModule()
                                    {
                                        Description = courseModule.Description,
                                        Name = courseModule.Name,
                                        CourseId = courseModule.Course.Id,
                                        Started = courseModule.Started,
                                        End = courseModule.End,
                                        Lecturer = courseModule.Lecturer
                                    };
                this.Data.CourseModules.Add(newModule);
                this.Data.SaveChanges();
                courseModule.Id = newModule.Id;
            }

            return this.Json(
                             new[] { courseModule }.ToDataSourceResult(request, this.ModelState),
                             JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCourseModule(
            [DataSourceRequest] DataSourceRequest request,
            CourseModuleViewModel module)
        {
            var moduleExisting = this.Data.CourseModules.All().FirstOrDefault(x => x.Id == module.Id);

            if (this.ModelState.IsValid)
            {
                moduleExisting.Name = module.Name;
                moduleExisting.Description = module.Description;
                moduleExisting.Started = module.Started;
                moduleExisting.End = module.End;
                moduleExisting.Lecturer = module.Lecturer;
                moduleExisting.CourseId = module.Course.Id;
                this.Data.SaveChanges();
            }

            if (moduleExisting == null)
            {
                this.ModelState.AddModelError(string.Empty, "No such module exists!");
            }

            return this.Json(
                             new[] { module }.ToDataSourceResult(request, this.ModelState),
                             JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCourseModule([DataSourceRequest] DataSourceRequest request, CourseModuleViewModel module)
        {
            var moduleExisting = this.Data.CourseModules.All().FirstOrDefault(x => x.Id == module.Id);
            if (moduleExisting != null)
            {
                foreach (var calendarEvent in moduleExisting.Events.ToList())
                {
                    this.Data.CalendarEvents.Delete(calendarEvent);
                }

                this.Data.CourseModules.Delete(moduleExisting);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { module }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}