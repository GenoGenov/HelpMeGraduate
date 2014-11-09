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

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using ProjectGallery.Data;

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

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.Data.Context));
            var adminRole = roleManager.Roles.First(x => x.Name == "Administrator");
            this.ViewData["users"] =
                this.Data.Users.All()
                    .Where(u => u.Roles.All(r => r.RoleId != adminRole.Id))
                    .Project()
                    .To<UserViewModel>().ToList();

            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        public JsonResult AllCourses([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Courses.All().Project().To<CourseViewModel>();

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
                    FacultyId = int.Parse(course.Faculty),
                    Moderator = this.Data.Users.Find(course.Moderator),
                    ModeratorId = course.Moderator,
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
                courseExisting.FacultyId = int.Parse(course.Faculty);
                courseExisting.Moderator = this.Data.Users.Find(course.Moderator);
                courseExisting.ModeratorId = course.Moderator;
                courseExisting.Year = course.Year;
                this.Data.SaveChanges();
            }

            if (courseExisting == null)
            {
                this.ModelState.AddModelError(string.Empty, "No such faculty exists!");
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