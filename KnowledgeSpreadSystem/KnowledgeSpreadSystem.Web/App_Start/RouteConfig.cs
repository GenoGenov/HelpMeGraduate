namespace KnowledgeSpreadSystem.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                             name: "Upload resource",
                             url: "Modules/{id}/UploadResource",
                             defaults: new { controller = "Modules", action = "UploadResource" },
                             namespaces: new string[] { "KnowledgeSpreadSystem.Web.Controllers" });

            routes.MapRoute(
                             name: "Enroll",
                             url: "Courses/Details/{id}/Enroll",
                             defaults: new { controller = "Courses", action = "Enroll" },
                             namespaces: new string[] { "KnowledgeSpreadSystem.Web.Controllers" });
            routes.MapRoute(
                             name: "Unenroll",
                             url: "Courses/Details/{id}/Unenroll",
                             defaults: new { controller = "Courses", action = "Unenroll" },
                             namespaces: new string[] { "KnowledgeSpreadSystem.Web.Controllers" });

            routes.MapRoute(
                            name: "Default",
                            url: "{controller}/{action}/{id}",
                            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                            namespaces: new string[] { "KnowledgeSpreadSystem.Web.Controllers" });

            routes.MapRoute(
                            name: "Statics",
                            url: "{action}",
                            defaults: new { controller = "Home" },
                            namespaces: new string[] { "KnowledgeSpreadSystem.Web.Controllers" });
        }

    }
}
