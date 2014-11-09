namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    public class FacultiesController : BaseController
    {
        public FacultiesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            this.ViewData["universities"] = this.Data.Universities.All().Project().To<UniversityViewModel>();

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        public JsonResult AllFaculties([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Faculties.All().Project().To<FacultyViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateFaculty([DataSourceRequest] DataSourceRequest request, FacultyViewModel faculty)
        {
            if (this.ModelState.IsValid)
            {
                var newfaculty = new Faculty()
                                     {
                                         Description = faculty.Description, 
                                         Name = faculty.Name, 
                                         UniversityId = faculty.University.Id
                                     };
                this.Data.Faculties.Add(newfaculty);
                this.Data.SaveChanges();
                faculty.Id = newfaculty.Id;
            }

            return this.Json(
                             new[] { faculty }.ToDataSourceResult(request, this.ModelState), 
                             JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateFaculty([DataSourceRequest] DataSourceRequest request, FacultyViewModel faculty)
        {
            var facultyExisting = this.Data.Faculties.All().FirstOrDefault(x => x.Id == faculty.Id);

            if (this.ModelState.IsValid)
            {
                facultyExisting.Name = faculty.Name;
                facultyExisting.Description = faculty.Description;
                facultyExisting.UniversityId = faculty.University.Id;
                this.Data.SaveChanges();
            }

            if (facultyExisting == null)
            {
                this.ModelState.AddModelError(string.Empty, "No such faculty exists!");
            }

            return this.Json(
                             new[] { faculty }.ToDataSourceResult(request, this.ModelState), 
                             JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFaculty([DataSourceRequest] DataSourceRequest request, FacultyViewModel faculty)
        {
            var facultyExisting = this.Data.Faculties.All().FirstOrDefault(x => x.Id == faculty.Id);
            if (facultyExisting != null)
            {
                foreach (var course in facultyExisting.Courses.ToList())
                {
                    foreach (var courseModule in course.CourseModules.ToList())
                    {
                        foreach (var calendarEvent in courseModule.Events.ToList())
                        {
                            this.Data.CalendarEvents.Delete(calendarEvent);
                        }

                        this.Data.CourseModules.Delete(courseModule);
                    }

                    foreach (var calendarEvent in course.Events.ToList())
                    {
                        this.Data.CalendarEvents.Delete(calendarEvent);
                    }

                    this.Data.Courses.Delete(course);
                }

                this.Data.Faculties.Delete(facultyExisting);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { faculty }, JsonRequestBehavior.AllowGet);
        }
    }
}