namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;

    public class RatingController : BaseController
    {
        public RatingController(IKSSData data)
            : base(data)
        {
        }

        public JsonResult RateResource(string id, int value)
        {
            return Json("Success");
        }
    }
}