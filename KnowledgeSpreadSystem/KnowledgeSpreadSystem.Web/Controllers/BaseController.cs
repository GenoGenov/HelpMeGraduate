using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Controllers
{
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
                return Data.Users.Find(User.Identity.GetUserId());
            }
        }
    }
}