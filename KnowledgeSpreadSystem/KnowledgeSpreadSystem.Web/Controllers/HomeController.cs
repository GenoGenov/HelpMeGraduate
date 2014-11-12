namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;

    public class HomeController : BaseController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public HomeController()
            : base(new KSSData())
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Moderator()
        {
            return this.View();
        }

    }
}