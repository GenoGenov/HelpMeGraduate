namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels;

    public class ModulesController : BaseController
    {
        // GET: Modules
        public ModulesController(IKSSData data)
            : base(data)
        {
        }



        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.CourseModules.All();
            data = id == null ? data : data.Where(x => x.CourseId == id);

            var modules = data.Project().To<ModuleViewModel>();
            var modulesShortenedDescription = modules.ForEach(
                                                                  x =>
                                                                  {
                                                                      x.Description = x.Description.ToShortString(200);
                                                                      return x;
                                                                  });
            return this.Json(modulesShortenedDescription.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}