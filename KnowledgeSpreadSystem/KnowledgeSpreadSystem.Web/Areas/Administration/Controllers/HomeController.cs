using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using KnowledgeSpreadSystem.Web.Infrastructure;

    using ProjectGallery.Data;

    public class HomeController : BaseController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}