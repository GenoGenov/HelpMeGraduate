namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;

    [Authorize(Roles = "Administrator")]
    public abstract class AdministratorController : BaseController
    {
        public AdministratorController(IKSSData data)
            : base(data)
        {
        }

    }
}