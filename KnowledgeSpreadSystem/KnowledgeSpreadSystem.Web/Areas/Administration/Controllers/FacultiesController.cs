namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Faculty;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.University;

    public class FacultiesController : AdministrationKendoGridController
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

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, FacultyViewModel model)
        {
            var dbModel = base.Create<Faculty>(model);

            model.Id = dbModel != null ? dbModel.Id : (int?)null;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, FacultyViewModel model)
        {
            base.Update<Faculty, FacultyViewModel>(model, model.Id);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, FacultyViewModel model)
        {
            base.Delete<Faculty>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Faculties.All().Project().To<FacultyViewModel>();
        }
    }
}