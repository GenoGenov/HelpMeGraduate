using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    using ProjectGallery.Data;

    public class CourseModulesController : BaseController
    {
        // GET: Administration/CourseModules
        public CourseModulesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        public JsonResult AllCourseModules([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.CourseModules.All().Project().To<CourseModuleViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCourseModule([DataSourceRequest] DataSourceRequest request, CourseModuleViewModel courseModule)
        {
            if (this.ModelState.IsValid)
            {
                var newModule = new CourseModule()
                {
                    Description = courseModule.Description,
                    Name = courseModule.Name,
                    CourseId = int.Parse(courseModule.Course),
                    Moderator = this.Data.Users.Find(courseModule.Moderator),
                    ModeratorId = courseModule.Moderator,
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
    }
}