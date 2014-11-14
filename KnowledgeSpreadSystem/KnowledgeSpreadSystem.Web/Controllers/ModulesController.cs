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
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public class ModulesController : BaseController
    {
        private static readonly string[] AllowedFileFormats =
            {
                ".zip", ".rar", ".pdf", ".png", ".jpeg", ".doc", ".docx"
            };

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
            if (id != null && this.CurrentUser.Courses.Any(c => c.Id == id))
            {
                var data = this.Data.CourseModules.All().Where(x => x.CourseId == id);

                var modules = data.Project().To<ModuleViewModel>();
                return this.Json(modules.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public ActionResult UploadResource(int id)
        {
            var module = this.Data.CourseModules.Find(id);
            if (module == null)
            {
                this.AddNotification("No such module exists!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.Module = Mapper.Map<ModuleViewModel>(module);
            ViewBag.FileTypes = string.Join(",", AllowedFileFormats);
            return this.View();
        }

        [HttpPost]
        public ActionResult UploadResource(int id, ResourceInputViewModel model, HttpPostedFileBase file)
        {
            var module = this.Data.CourseModules.Find(id);
            ViewBag.Module = Mapper.Map<ModuleViewModel>(module);
            ViewBag.FileTypes = string.Join(",", AllowedFileFormats);
            if (module == null)
            {
                this.AddNotification("No such module exists!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            if (file == null)
            {
                this.AddNotification("File is mandatory!", "error");
                return this.View(model);
            }
            var extension = Path.GetExtension(file.FileName);
            if (!AllowedFileFormats.Contains(extension.ToLower()))
            {
                this.AddNotification("Not Allowed File Type!", "error");
                return this.View(model);
            }
            var buffer = new byte[file.ContentLength + 1];
            file.InputStream.Read(buffer, 0, buffer.Length);
            var resource = new Resource()
                               {
                                   Name = model.Name,
                                   ModuleId = id,
                                   MIMEType = file.ContentType,
                                   Description = model.Description,
                                   FileExtension = extension,
                                   FileName = file.FileName,
                                   ContentSize = file.ContentLength,
                                   Content = buffer
                               };
            this.Data.Recourses.Add(resource);
            this.Data.SaveChanges();
            this.AddNotification(
                                 "Successfully uploaded resource " + resource.FileName + " to module " + module.Name
                                 + " !",
                                 "success");
            return this.RedirectToAction("Details", "Modules", new { id = module.Id });
        }
    }
}