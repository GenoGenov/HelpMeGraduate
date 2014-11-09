using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Controllers
{
    using KnowledgeSpreadSystem.Web.Infrastructure;

    using ProjectGallery.Data;

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