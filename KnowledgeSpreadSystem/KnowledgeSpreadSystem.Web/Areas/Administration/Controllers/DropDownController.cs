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
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Module;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.User;
    using KnowledgeSpreadSystem.Web.ViewModels.Module;

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

        public JsonResult GetCascadeModules(int? courses)
        {
            var result = this.Data.CourseModules.All().Project().To<CourseModuleViewModel>();

            if (courses.HasValue)
            {
                result = result.Where(x => x.Course.Id == courses);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeUsers(int? courses)
        {
            if (courses.HasValue)
            {
                return Json(this.GetUsers(courses.Value, false), JsonRequestBehavior.AllowGet);
            }
            return null;

        }

        public JsonResult GetCascadeModerators(int? courses)
        {
            if (courses.HasValue)
            {
                return Json(this.GetUsers(courses.Value, true), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        private IQueryable<ModeratorViewModel> GetUsers(int courseId, bool isModerator)
        {
            HttpContext.Session["courseId"] = courseId;
            var moderatorIds = this.Data.Courses.Find(courseId).Moderators.Select(u => u.Id);
            var result = this.Data.Users.All().Project().To<ModeratorViewModel>();

            result = isModerator
                         ? result.Where(x => moderatorIds.Contains(x.Id))
                         : result.Where(x => !moderatorIds.Contains(x.Id));
            return result;
        } 
    }
}