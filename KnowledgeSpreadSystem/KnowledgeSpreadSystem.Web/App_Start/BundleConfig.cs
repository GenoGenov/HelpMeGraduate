namespace KnowledgeSpreadSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

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
                                                                    "~/Scripts/Kendo/kendo.aspnetmvc.min.js",
                                                                    "~/Scripts/Kendo/handlers.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(
                        new ScriptBundle("~/bundles/bootstrap").Include(
                                                                        "~/Scripts/bootstrap.js",
                                                                        "~/Scripts/respond.js"));

            bundles.Add(
                        new StyleBundle("~/Content/bootstrap")
                        .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                       "~/Content/Kendo/kendo.common-bootstrap.min.css",
                       "~/Content/Kendo/kendo.bootstrap.min.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}