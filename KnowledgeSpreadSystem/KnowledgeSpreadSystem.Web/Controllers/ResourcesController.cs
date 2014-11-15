namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

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
                return this.RedirectToAction("Index", "Home");
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

            var resource = new Resource() { ModuleId = id };
            
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
            var module = this.Data.Courses.Find(id);
            if (module == null)
            {
                this.AddNotification("No such course exists!", "error");
                return this.RedirectToAction("Index", "Home");
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
            this.Data.Recourses.Add(initial);
            this.Data.SaveChanges();

            return successResult;
        }
    }
}