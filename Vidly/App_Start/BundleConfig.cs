using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                        "~/Scripts/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));
          // Use the development version of Modernizr to develop with and learn from. Then, when you're
          // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.


          bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                     "~/Scripts/bootbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                     "~/Scripts/popper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/Site.css",
                      "~/Content/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
