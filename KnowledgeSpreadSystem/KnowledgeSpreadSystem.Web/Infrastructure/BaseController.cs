namespace KnowledgeSpreadSystem.Web.Infrastructure
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Models;

    using Microsoft.AspNet.Identity;

    using ProjectGallery.Data;

    public abstract class BaseController : Controller
    {
        protected IKSSData Data { get; set; }

        protected BaseController(IKSSData data)
        {
            this.Data = data;
        }

        protected User CurrentUser
        {
            get
            {
                return this.Data.Users.Find(this.User.Identity.GetUserId());
            }
        }

        protected void AddNotification(string notification, string type)
        {
            TempData["notification"] = notification;
            TempData["type"] = type;
        }
    }
}