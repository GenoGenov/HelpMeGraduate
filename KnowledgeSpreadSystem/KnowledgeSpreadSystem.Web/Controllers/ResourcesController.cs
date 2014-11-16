namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    using WebGrease.Css.Extensions;

    public class ResourcesController : BaseController
    {
        private static readonly string[] AllowedFileFormats =
            {
                ".zip", ".rar", ".pdf", ".png", ".jpeg", ".doc", ".docx"
            };

        public ResourcesController(IKSSData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult UploadForModule(int id)
        {
            var module = this.Data.CourseModules.Find(id);
            if (module == null)
            {
                this.AddNotification("No such module exists!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }

            if (!this.IsEligible(module.CourseId))
            {
                this.AddNotification("You are not enrolled for that module's course!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }

            var viewModel = Mapper.Map<SimpleViewModel>(module);
            return this.View(
                             "UploadResource",
                             new ResourceInputViewModel
                                 {
                                     Target = viewModel,
                                     AllowedFileFormats = string.Join(",", AllowedFileFormats)
                                 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadForModule(int id, ResourceInputViewModel model, HttpPostedFileBase file)
        {
            var courseModule = this.Data.CourseModules.Find(id);
            if (!this.IsEligible(courseModule.CourseId))
            {
                this.AddNotification("You are not enrolled for that module's course!", "error");
                return this.RedirectToAction("Index", "Home");
            }
            var resource = new Resource() { ModuleId = id, CourseId = courseModule.CourseId};
            
            var successResult = this.RedirectToAction("Index", "Enrolment", new { id = id });
            var viewResult = this.UploadResource(
                                       successResult,
                                       resource,
                                       model,
                                       file);

            if (viewResult == successResult)
            {
                this.AddNotification(
                                     "Successfully uploaded resource " + resource.FileName + " to module "
                                     + model.Target.Name + " !",
                                     "success");
            }

            return viewResult;
        }

        [HttpGet]
        public ActionResult UploadForCourse(int id)
        {
            if (!this.IsEligible(id))
            {
                this.AddNotification("You are not enrolled for that course!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }

            var module = this.Data.Courses.Find(id);
            if (module == null)
            {
                this.AddNotification("No such course exists!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }

            var viewModel = Mapper.Map<SimpleViewModel>(module);
            return this.View(
                             "UploadResource",
                             new ResourceInputViewModel
                             {
                                 Target = viewModel,
                                 AllowedFileFormats = string.Join(",", AllowedFileFormats)
                             });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadForCourse(int id, ResourceInputViewModel model, HttpPostedFileBase file)
        {
            if (!this.IsEligible(id))
            {
                this.AddNotification("You are not enrolled for that course!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }
            var resource = new Resource() { CourseId = id };

            var successResult = this.RedirectToAction("Index", "Enrolment", new { id = model.Target.Id });
            var viewResult = this.UploadResource(
                                       successResult,
                                       resource,
                                       model,
                                       file);

            if (viewResult == successResult)
            {
                this.AddNotification(
                                     "Successfully uploaded resource " + resource.FileName + " to course "
                                     + model.Target.Name + " !",
                                     "success");
            }

            return viewResult;
        }

        private bool IsEligible(int courseId)
        {
            return this.CurrentUser.Courses.Any(x => x.Id == courseId) || this.User.IsInRole("Administrator");
        }

        public ActionResult ReadForCourse([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Resources.All();
            data = id == null ? data : data.Where(x => x.CourseId == id && x.ModuleId == null);

            var resources = data.Project().To<ResourceViewModel>()
                 .ForEach(x =>
                 {
                     x.Description = x.Description.ToShortString(250);
                     x.ImagePath = this.GetImagePath(x.FileExtension);
                     return x;
                 });
            return this.Json(resources.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadForModule([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Resources.All();
            data = id == null ? data : data.Where(x => x.ModuleId == id);

            var resources = data.Project().To<ResourceViewModel>()
                 .ForEach(x =>
                 {
                     x.Description = x.Description.ToShortString(250);
                     x.ImagePath = this.GetImagePath(x.FileExtension);
                     return x;
                 });
            return this.Json(resources.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Download(string id)
        {
            var idAsGuid = new Guid();
            if (!Guid.TryParse(id, out idAsGuid))
            {
                this.AddNotification("Invalid resource ID !", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }
            var resource = this.Data.Resources.Find(idAsGuid);
            if (!this.IsEligible(resource.CourseId))
            {
                this.AddNotification("You are not enroled for that course!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }

            return File(resource.Content, resource.MIMEType, resource.FileName);
        }

        public ActionResult Details(string id)
        {
            var idAsGuid = new Guid();
            if (!Guid.TryParse(id, out idAsGuid))
            {
                this.AddNotification("Invalid resource ID !", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }
            var resource = this.Data.Resources.Find(idAsGuid);
            if (!this.IsEligible(resource.CourseId))
            {
                this.AddNotification("You are not enroled for that course!", "error");
                return this.RedirectToAction("Index", "Enrolment");
            }
            return this.View(Mapper.Map<ResourceViewModel>(resource));
        }

        private string GetImagePath(string extension)
        {
            switch (extension.ToLower())
            {
                case ".pdf":
                    return "/Content/images/icons/PDF-icon.png";
                case ".doc":
                case ".docx":
                    return "/Content/images/icons/Doc-File-icon.png";
                case ".png":
                case ".jpeg":
                    return "/Content/images/icons/Graphics-icon.png";
                case ".zip":
                case ".rar":
                    return "/Content/images/icons/Archive-icon.png";
            }

            return "/Content/images/icons/file-icon.png";
        }

        private ActionResult UploadResource(ActionResult successResult, Resource initial, ResourceInputViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return this.View("UploadResource", model);
            }

            if (file == null)
            {
                this.AddNotification("File is mandatory!", "error");
                return this.View("UploadResource", model);
            }
            var extension = Path.GetExtension(file.FileName);
            if (!AllowedFileFormats.Contains(extension.ToLower()))
            {
                this.AddNotification("Not Allowed File Type!", "error");
                return this.View("UploadResource", model);
            }
            var buffer = new byte[file.ContentLength + 1];
            file.InputStream.Read(buffer, 0, buffer.Length);

            initial.Name = model.Name;
            initial.MIMEType = file.ContentType;
            initial.Description = model.Description;
            initial.FileExtension = extension;
            initial.FileName = file.FileName;
            initial.ContentSize = file.ContentLength;
            initial.Content = buffer;
            initial.AuthorId = this.CurrentUser.Id;
            this.Data.Resources.Add(initial);
            this.Data.SaveChanges();

            return successResult;
        }
    }
}