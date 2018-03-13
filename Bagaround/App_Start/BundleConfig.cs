using System.Web.Optimization;

namespace Bagaround
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
                "~/Scripts/summernote.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepice").Include(
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-datepicker.th.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pgwsliderjs").Include(
                "~/Scripts/pgwslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/bxslider").Include(
                "~/Scripts/jquery.bxslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/filestyle").Include(
                "~/Scripts/bootstrap-filestyle.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/font-awesome.css",
                "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/summernote").Include(
                "~/Content/summernote.css"));

            bundles.Add(new StyleBundle("~/Content/datpick").Include(
                "~/Content/bootstrap-datepicker.css",
                "~/Contnet/bootstrap-datepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/pgwslider").Include(
                "~/Content/pgwslider.css"));

            bundles.Add(new StyleBundle("~/Content/bxslider").Include(
               "~/Content/jquery.bxslider.css"));

            bundles.Add(new StyleBundle("~/Content/CartTable").Include(
               "~/Content/CartTable.css"));

            bundles.Add(new StyleBundle("~/Content/OrderList").Include(
          "~/Content/OrderList.css"));

            bundles.Add(new StyleBundle("~/Content/AddNewProduct").Include(
          "~/Content/AddNewProduct.css"));

            bundles.Add(new StyleBundle("~/Content/AlertCs").Include(
                "~/Content/alertify.css",
                "~/Content/default.css"));

            bundles.Add(new ScriptBundle("~/bundle/AlertJs").Include(
                "~/Scripts/alertify.js"));
        }
    }
}