namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    [Authorize(Roles = "Administrator")]
    public abstract class AdministratorController : BaseController
    {
        public AdministratorController(IKSSData data)
            : base(data)
        {
        }

    }
}