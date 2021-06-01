using System.Web.Optimization;

namespace BookShop
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

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                       "~/Areas/Admin/Data/plugins/jquery/jquery.min.js",
                       //"~/Areas/Admin/Data/plugins/jquery-ui/jquery-ui.min.js",
                       "~/Areas/Admin/Data/plugins/bootstrap/js/bootstrap.bundle.min.js",
                       "~/Scripts/bootbox.js",

                       "~/Areas/Admin/Data/plugins/datatables/jquery.dataTables.min.js",
                       "~/Areas/Admin/Data/plugins/datatables/jquery.dataTables.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-buttons/js/dataTables.buttons.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-buttons/js/buttons.bootstrap4.min.js",
                       "~/Areas/Admin/Data/plugins/jszip/jszip.min.js",
                       "~/Areas/Admin/Data/plugins/pdfmake/pdfmake.min.js",
                       "~/Areas/Admin/Data/plugins/pdfmake/vfs_fonts.js",
                       "~/Areas/Admin/Data/plugins/datatables-buttons/js/buttons.html5.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-buttons/js/buttons.print.min.js",
                       "~/Areas/Admin/Data/plugins/datatables-buttons/js/buttons.colVis.min.js",

                       "~/Areas/Admin/Data/dist/js/adminlte.js"


                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
