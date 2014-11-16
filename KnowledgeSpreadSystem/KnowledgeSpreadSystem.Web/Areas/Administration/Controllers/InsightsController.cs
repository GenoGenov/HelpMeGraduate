namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.Filters;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;

    public class InsightsController : AdministrationKendoGridController
    {
        // GET: Administration/Insights
        public InsightsController(IKSSData data)
            : base(data)
        {
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, InsightViewModel model)
        {
            base.Delete<Insight>(model.Id, true);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, InsightViewModel model)
        {
            model.AuthorId = this.CurrentUser.Id;
            var dbModel = base.Create<Insight>(model);

            model.Id = dbModel != null ? dbModel.Id.ToString() : null;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, InsightViewModel model)
        {
            base.Update<Insight, InsightViewModel>(model, Guid.Parse(model.Id));

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Insigths
                .All()
                .Project()
                .To<InsightViewModel>()
                .ForEach(
                         x =>
                         {
                             x.Target = x.ModuleId.HasValue
                                            ? this.Data.CourseModules.Find(x.ModuleId.Value).Name + "(module)"
                                            : this.Data.Courses.Find(x.CourseId.Value).Name + "(course)";
                             return x;
                         });
        }
    }
}