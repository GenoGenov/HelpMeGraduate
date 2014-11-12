namespace KnowledgeSpreadSystem.Web.Controllers.Base
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;

    public abstract class BaseKendoGridController : BaseController
    {
        public BaseKendoGridController(IKSSData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.GetData().ToDataSourceResult(request);

            return this.Json(data);
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        protected abstract IEnumerable GetData();
    }
}