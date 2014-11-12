using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Course;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    public class DropDownController : AdministratorController
    {
        public DropDownController(IKSSData data)
            : base(data)
        {
        }

        public JsonResult GetCascadeUniversities()
        {
            var result = this.Data.Universities.All().Project().To<SimpleViewModel>();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeFaculties(int? universities)
        {
            var result = this.Data.Faculties.All().Project().To<FacultyViewModel>();

            var filtered = result.Where(x => x.University.Id == universities);

            return Json(filtered, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeCourses(int? faculties)
        {
            var result = this.Data.Courses.All().Project().To<CourseViewModel>();

            var filtered = result.Where(x => x.Faculty.Id == faculties);

            return Json(filtered, JsonRequestBehavior.AllowGet);
        }
    }
}