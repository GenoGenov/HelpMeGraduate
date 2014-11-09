namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    using ProjectGallery.Data;

    [Authorize(Roles = "Administrator")]
    public class UniversitiesController : BaseController
    {
        public UniversitiesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView();
            }

            return this.View();
        }

        public JsonResult UpdateUniversity([DataSourceRequest] DataSourceRequest request, UniversityViewModel uni)
        {
            var uniExisting = this.Data.Universities.All().FirstOrDefault(x => x.Id == uni.Id);

            if (this.ModelState.IsValid)
            {
                uniExisting.Name = uni.Name;
                uniExisting.About = uni.About;

                this.Data.SaveChanges();
            }

            if (uniExisting == null)
            {
                this.ModelState.AddModelError(string.Empty, "No such university exists!");
            }

            return this.Json(new[] { uni }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUniversity([DataSourceRequest] DataSourceRequest request, UniversityViewModel uni)
        {
            var uniExisting = this.Data.Universities.All().FirstOrDefault(x => x.Id == uni.Id);
            if (uniExisting != null)
            {
                foreach (var faculty in uniExisting.Faculties.ToList())
                {
                    foreach (var course in faculty.Courses.ToList())
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

                    this.Data.Faculties.Delete(faculty);
                }

                this.Data.Universities.Delete(uniExisting);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { uni }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateUniversity([DataSourceRequest] DataSourceRequest request, UniversityViewModel uni)
        {
            if (this.ModelState.IsValid)
            {
                var newUni = new University() { About = uni.About, Name = uni.Name };
                this.Data.Universities.Add(newUni);
                this.Data.SaveChanges();
                uni.Id = newUni.Id;
            }

            return this.Json(new[] { uni }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllUniversities([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Universities.All().Project().To<UniversityViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult AllUniversitiesDropDown()
        {
            var result = this.Data.Universities.All().Project().To<UniversityViewModel>().ToList();
            return this.PartialView("_AllUniversitiesDDL", result);
        }
    }
}