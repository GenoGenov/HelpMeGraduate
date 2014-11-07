namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;

    using ProjectGallery.Data;

    public class HomeController : BaseController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public HomeController():base(new KSSData())
        {
            
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";
            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}