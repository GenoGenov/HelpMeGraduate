namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels;
    using KnowledgeSpreadSystem.Web.ViewModels.Module;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    [Authorize]
    public class ModulesController : BaseController
    {


        // GET: Modules
        public ModulesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var module = this.Data.CourseModules.Find(id);

            if (module == null)
            {
                this.AddNotification("No module exists with the given ID !", "error");
                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.Enrolled = this.CurrentUser.Courses.Any(c => c.Id == module.CourseId);

            var mapped = Mapper.Map<ModuleViewModel>(module);

            ViewBag.UniversityName = module.Course.Faculty.University.Name;
            ViewBag.UniversityId = module.Course.Faculty.UniversityId;

            ViewBag.FacultyName = module.Course.Faculty.Name;
            ViewBag.FacultyId = module.Course.FacultyId;

            ViewBag.CourseName = module.Course.Name;
            ViewBag.CourseId = module.CourseId;

            return View(mapped);
        }


        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int? id)
        {
            if (id != null)
            {
                var data = this.Data.CourseModules.All().Where(x => x.CourseId == id);

                var modules = data.Project().To<ModuleViewModel>();
                return this.Json(modules.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}