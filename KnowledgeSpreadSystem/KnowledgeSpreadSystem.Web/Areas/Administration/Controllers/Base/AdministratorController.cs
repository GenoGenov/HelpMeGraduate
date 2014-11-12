namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;

    [Authorize(Roles = "Administrator")]
    public abstract class AdministratorController : AdministrationKendoGridController
    {
        public AdministratorController(IKSSData data)
            : base(data)
        {
        }

    }
}