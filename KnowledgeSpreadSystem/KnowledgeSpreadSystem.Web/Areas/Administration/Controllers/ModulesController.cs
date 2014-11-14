namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Module;

    public class ModulesController : AdministrationKendoGridController
    {
        // GET: Administration/CourseModules
        public ModulesController(IKSSData data)
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

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CourseModuleViewModel model)
        {
            var dbModel = base.Create<CourseModule>(model);

            model.Id = dbModel != null ? dbModel.Id : (int?)null;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, CourseModuleViewModel model)
        {
            base.Update<CourseModule, CourseModuleViewModel>(model, model.Id);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, CourseModuleViewModel model)
        {
            base.Delete<CourseModule>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.CourseModules.All().Project().To<CourseModuleViewModel>();
        }
    }
}