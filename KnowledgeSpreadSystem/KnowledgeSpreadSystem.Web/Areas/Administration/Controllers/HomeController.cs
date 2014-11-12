using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    public class HomeController : AdministratorController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult SideMenu()
        {
            ViewBag.Controllers = new[]
                                      {
                                          "Universities",
                                          "Faculties",
                                          "Courses",
                                          "Modules", 
                                          "Resources",
                                          "Users",
                                          "Logs"
                                      };
            return this.View("_SideMenuPartial");
        }
    }
}