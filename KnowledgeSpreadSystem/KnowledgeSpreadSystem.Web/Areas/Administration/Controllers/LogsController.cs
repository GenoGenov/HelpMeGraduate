namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Web.Mvc;

        [Authorize(Roles = "Administrator")]
    public class LogsController : Controller
    {
        public ActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }
}