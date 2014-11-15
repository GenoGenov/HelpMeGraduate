namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.University;
    using KnowledgeSpreadSystem.Web.Filters;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public class ResourcesController : AdministrationKendoGridController
    {
        // GET: Administration/Resources
        public ResourcesController(IKSSData data)
            : base(data)
        {
        }

        //[HttpPost]
        //public JsonResult Update([DataSourceRequest] DataSourceRequest request, ResourceViewModel model)
        //{
        //    base.Update<Resource, ResourceViewModel>(model, model.Id);

        //    return this.GridOperation(model, request);
        //}

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, ResourceViewModel model)
        {
            base.Delete<Resource>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Recourses
                .All()
                .Project()
                .To<ResourceViewModel>()
                .ForEach(
                         x =>
                             {
                                 x.Target = x.ModuleId.HasValue
                                                ? this.Data.CourseModules.Find(x.ModuleId.Value).Name + "(module)"
                                                : this.Data.CourseModules.Find(x.CourseId.Value).Name + "(course)";
                                 return x;
                             });
        }
    }
}