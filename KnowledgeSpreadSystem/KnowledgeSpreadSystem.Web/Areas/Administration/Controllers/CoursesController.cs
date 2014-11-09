using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CoursesController : BaseController
    {
        // GET: Administration/Courses
        public CoursesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            this.ViewData["faculties"] = this.Data.Faculties.All().Project().To<FacultyViewModel>();

            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        public JsonResult AllCourses([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Courses.All().Project().To<CourseViewModel>().ToList();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCourse([DataSourceRequest] DataSourceRequest request, CourseViewModel course)
        {
            if (this.ModelState.IsValid)
            {
                var newCourse = new Course()
                {
                    Description = course.Description,
                    Name = course.Name,
                    FacultyId = course.Faculty.Id,
                    Year = course.Year,
                };
                this.Data.Courses.Add(newCourse);
                this.Data.SaveChanges();
                course.Id = newCourse.Id;
            }

            return this.Json(
                             new[] { course }.ToDataSourceResult(request, this.ModelState),
                             JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCourse([DataSourceRequest] DataSourceRequest request, CourseViewModel course)
        {
            var courseExisting = this.Data.Courses.All().FirstOrDefault(x => x.Id == course.Id);

            if (this.ModelState.IsValid)
            {
                courseExisting.Name = course.Name;
                courseExisting.Description = course.Description;
                courseExisting.FacultyId = course.Faculty.Id;
                courseExisting.Year = course.Year;
                this.Data.SaveChanges();
            }

            if (courseExisting == null)
            {
                this.ModelState.AddModelError(string.Empty, "No such course exists!");
            }

            return this.Json(
                             new[] { course }.ToDataSourceResult(request, this.ModelState),
                             JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCourse([DataSourceRequest] DataSourceRequest request, CourseViewModel course)
        {
            var courseExisting = this.Data.Courses.All().FirstOrDefault(x => x.Id == course.Id);
            if (courseExisting != null)
            {

                    foreach (var courseModule in courseExisting.CourseModules.ToList())
                    {
                        foreach (var calendarEvent in courseModule.Events.ToList())
                        {
                            this.Data.CalendarEvents.Delete(calendarEvent);
                        }

                        this.Data.CourseModules.Delete(courseModule);
                    }

                    foreach (var calendarEvent in courseExisting.Events.ToList())
                    {
                        this.Data.CalendarEvents.Delete(calendarEvent);
                    }

                    this.Data.Courses.Delete(courseExisting);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { course }, JsonRequestBehavior.AllowGet);
        }
    }
}