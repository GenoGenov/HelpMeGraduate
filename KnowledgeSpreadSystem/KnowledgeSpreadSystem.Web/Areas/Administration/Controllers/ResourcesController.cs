namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;

    public class ResourcesController : AdministratorController
    {
        // GET: Administration/Resources
        public ResourcesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }
            return View();
        }

        public ActionResult CreateResource()
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteResource()
        {
            throw new NotImplementedException();
        }

        public ActionResult AllResources()
        {
            throw new NotImplementedException();
        }
    }
}