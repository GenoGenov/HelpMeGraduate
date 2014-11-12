using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using KnowledgeSpreadSystem.Data;

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