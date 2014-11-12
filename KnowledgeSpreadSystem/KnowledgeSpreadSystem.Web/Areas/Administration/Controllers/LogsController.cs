namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;

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

        protected override IEnumerable GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}