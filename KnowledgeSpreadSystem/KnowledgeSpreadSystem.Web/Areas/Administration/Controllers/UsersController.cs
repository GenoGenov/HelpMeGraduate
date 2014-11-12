namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.User;

    public class UsersController : AdministratorController
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

        protected override IEnumerable GetData()
        {
            throw new NotImplementedException();
        }
    }
}