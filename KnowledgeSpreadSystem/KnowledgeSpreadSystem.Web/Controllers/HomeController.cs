namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Infrastructure;
    using KnowledgeSpreadSystem.Web.Models;

    using ProjectGallery.Data;

    public class HomeController : BaseController
    {
        public HomeController(IKSSData data)
            : base(data)
        {
        }

        public HomeController():base(new KSSData())
        {
            
        }

        public ActionResult Index()
        {
            return this.View();
        }

        
    }
}