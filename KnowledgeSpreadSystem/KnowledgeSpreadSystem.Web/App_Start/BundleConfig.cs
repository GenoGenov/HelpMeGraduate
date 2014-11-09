namespace KnowledgeSpreadSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                        new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js")
                                                            .Include("~/Scripts/jquery-ui-{version}.js")
                                                            .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(
                        new ScriptBundle("~/bundles/noty").Include("~/Scripts/noty/jquery.noty.js")
                                                          .Include("~/Scripts/noty/layouts/top.js")
                                                          .Include("~/Scripts/noty/layouts/inline.js")
                                                          .Include("~/Scripts/noty/themes/default.js")
                                                          .Include("~/Scripts/noty/noty-config.js")
                                                          .Include("~/Scripts/noty/notificator.js"));

            bundles.Add(
                        new ScriptBundle("~/bundles/kendo").Include(
                                                                    "~/Scripts/Kendo/kendo.all.min.js",
                                                                    // or kendo.all.min.js if you want to use Kendo UI Web and Kendo UI DataViz
                                                                    "~/Scripts/Kendo/kendo.aspnetmvc.min.js",
                                                                    "~/Scripts/Kendo/handlers.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(
                        new ScriptBundle("~/bundles/bootstrap").Include(
                                                                        "~/Scripts/bootstrap.js",
                                                                        "~/Scripts/respond.js"));

            bundles.Add(
                        new StyleBundle("~/Content/css").Include(
                                                                 "~/Content/bootstrap.css",
                                                                 "~/Content/bootstrap.theme.min.css",
                                                                 "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                       "~/Content/Kendo/kendo.common.min.css",
                       "~/Content/Kendo/kendo.bootstrap.min.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}