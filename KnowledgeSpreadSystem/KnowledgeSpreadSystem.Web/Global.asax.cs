namespace KnowledgeSpreadSystem.Web
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();

            var db = new KSSDBContext();
            if (!db.Roles.Any())
            {
                var adminRole = new IdentityRole("Administrator");
                var userManager = new ApplicationUserManager(new UserStore<User>(db));
                var admin = new User { UserName = "Admin@helpmegraduate.com", Email = "Admin@helpmegraduate.com" };
                userManager.Create(admin, "secret");

                db.Roles.Add(adminRole);

                db.SaveChanges();
                userManager.AddToRole(admin.Id, "Administrator");
                db.SaveChanges();

                db.Roles.Add(new IdentityRole("Moderator"));
                db.SaveChanges();
            }
           

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
