using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;

    public class UsersController : BaseController
    {
        public UsersController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByUsername(UserViewModel user)
        {
            var userFound =
                this.Data.Users.All().FirstOrDefault(x => x.UserName.ToLower().Contains(user.Username.ToLower()));
            var mappedUser = Mapper.Map<UserViewModel>(userFound);
            return this.View(mappedUser);
        }

        public ActionResult AllUsers()
        {
            throw new NotImplementedException();
        }

        [ChildActionOnly]
        public ActionResult AllUsersDropDown()
        {
            var result = this.Data.Users.All().Project().To<UserViewModel>().ToList();
            return this.PartialView("_AllUsersDropdown", result);
        }
    }
}