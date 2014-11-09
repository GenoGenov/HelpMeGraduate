using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Web.UI;

    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Web.Infrastructure;
    using KnowledgeSpreadSystem.Web.Models;

    using ProjectGallery.Data;

    public class MenuController : BaseController
    {
        public MenuController(IKSSData data)
            : base(data)
        {
        }

#if !DEBUG
        [OutputCache(Duration = 10*60, VaryByParam = "none")]
#endif
        [ChildActionOnly]
        public ActionResult UniversityLinks()
        {
            var universities = this.Data.Universities.All().Project().To<UniversityViewModel>().ToList();
            return this.PartialView("_UniversitiesPartial", universities);
        }
    }
}