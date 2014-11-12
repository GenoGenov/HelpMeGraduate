namespace KnowledgeSpreadSystem.Web.Controllers.Base
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;

    using Microsoft.AspNet.Identity;

    public abstract class BaseController : Controller
    {
        protected BaseController(IKSSData data)
        {
            this.Data = data;
        }

        protected IKSSData Data { get; set; }

        protected User CurrentUser
        {
            get
            {
                return this.Data.Users.Find(this.User.Identity.GetUserId());
            }
        }

        protected void AddNotification(string notification, string type)
        {
            this.TempData["notification"] = notification;
            this.TempData["type"] = type;
        }
    }
}