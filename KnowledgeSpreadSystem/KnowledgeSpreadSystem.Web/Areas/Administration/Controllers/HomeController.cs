namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;

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
            var controllers = new[]
                                      {
                                          "Universities",
                                          "Faculties",
                                          "Courses",
                                          "Modules", 
                                          "Resources",
                                          "Insights",
                                          "Users",
                                          "Logs"
                                      };
            return this.View("_SideMenuPartial", controllers);
        }

    }
}