namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Course;
    using KnowledgeSpreadSystem.Web.Filters;

    public class CoursesController : AdministrationKendoGridController
    {
        // GET: Administration/Courses
        public CoursesController(IKSSData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CourseViewModel model)
        {
            var dbModel = base.Create<Course>(model);

            model.Id = dbModel != null ? dbModel.Id : (int?)null;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, CourseViewModel model)
        {
            base.Update<Course, CourseViewModel>(model, model.Id);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, CourseViewModel model)
        {
            base.Delete<Course>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Courses.All().Project().To<CourseViewModel>();
        }
    }
}