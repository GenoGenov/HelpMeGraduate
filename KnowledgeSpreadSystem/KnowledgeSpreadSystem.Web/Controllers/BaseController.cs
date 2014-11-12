﻿namespace KnowledgeSpreadSystem.Web.Infrastructure
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.ViewModels;

    using Microsoft.AspNet.Identity;

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
            this.TempData["notification"] = notification;
            this.TempData["type"] = type;
        }
    }
}