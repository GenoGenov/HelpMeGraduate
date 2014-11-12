namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;

    public class LogsController : AdministratorController
    {
        public LogsController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }
}