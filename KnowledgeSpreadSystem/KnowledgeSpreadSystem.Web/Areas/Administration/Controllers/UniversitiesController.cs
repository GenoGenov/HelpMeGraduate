namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.University;
    using KnowledgeSpreadSystem.Web.Filters;

    public class UniversitiesController : AdministrationKendoGridController
    {
        public UniversitiesController(IKSSData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, UniversityViewModel model)
        {
            var dbModel = base.Create<University>(model);

            model.Id = dbModel != null ? dbModel.Id : (int?)null;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, UniversityViewModel model)
        {
            base.Update<University, UniversityViewModel>(model, model.Id);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, UniversityViewModel model)
        {
            base.Delete<University>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Universities.All().Project().To<UniversityViewModel>();
        }
    }
}