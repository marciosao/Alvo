using System.Web;
using System.Web.Optimization;

namespace Alvo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                //"~/Scripts/jquery-{version}.js"
                                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                                "~/Scripts/bootstrap.min.js",
                                "~/Scripts/changeSystem.js",
                                "~/Scripts/select2.full.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/methods_pt.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-theme.min.css",
                    "~/Content/font-awesome.css",
                    "~/Content/bootstrap-datepicker.css",
                    "~/Content/bootstrap-datepicker3.css",
                    "~/Content/jquery.dataTables.min.css",
                    "~/Content/jquery.fileupload",
                    "~/Content/alvo.css",
                    "~/Content/PagedList.css",
                    "~/Content/select2.min.css",
                    "~/Content/Site.css"
                      ));
        }
    }
}
