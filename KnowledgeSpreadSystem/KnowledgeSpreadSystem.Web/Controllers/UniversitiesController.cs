using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Controllers
{
    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    [Authorize]
    public class UniversitiesController : BaseController
    {
        // GET: Universities
        public UniversitiesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Uni(string id)
        {
            return Content("");
        }


    }
}