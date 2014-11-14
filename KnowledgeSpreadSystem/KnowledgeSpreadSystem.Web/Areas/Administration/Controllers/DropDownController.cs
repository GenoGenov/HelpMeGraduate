namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Course;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Faculty;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.User;

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
            if (universities.HasValue)
            {
                result = result.Where(x => x.University.Id == universities);
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeCourses(int? faculties)
        {
            var result = this.Data.Courses.All().Project().To<CourseViewModel>();

            if (faculties.HasValue)
            {
                result = result.Where(x => x.Faculty.Id == faculties);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeUsers(int? courses)
        {


            if (courses.HasValue)
            {
                HttpContext.Session["courseId"] = courses;
                var course = this.Data.Courses.All().Include("Moderators").FirstOrDefault(x => x.Id == courses.Value);

                var result = this.Data.Users.All().Project().To<ModeratorViewModel>().ToList();
                result = result.Where(x => course.Moderators.All(m => m.Id != x.Id)).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;

        }

        public JsonResult GetCascadeModerators(int? courses)
        {
            var result = this.Data.Users.All().Project().To<ModeratorViewModel>().ToList();

            if (courses.HasValue)
            {
                HttpContext.Session["courseId"] = courses;
                var course = this.Data.Courses.All().Include("Moderators").FirstOrDefault(x => x.Id == courses.Value);

                result = result.Where(x => course.Moderators.Any(m => m.Id == x.Id)).ToList();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}