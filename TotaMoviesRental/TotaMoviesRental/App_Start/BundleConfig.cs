﻿using System.Web.Optimization;

namespace TotaMoviesRental
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/services/customerService.js",
                "~/Scripts/app/controllers/customersController.js",
                "~/Scripts/app/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/moment.js",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/bootbox.js",
                         "~/Scripts/respond.js",
                         "~/Scripts/datatables/jquery.datatables.js",
                         "~/Scripts/datatables/datatables.bootstrap.js",
                         "~/Scripts/bootstrap-datetimepicker.js",
                         "~/Scripts/typeahead.bundle.js",
                         "~/Scripts/toastr.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/bootstrap-luman.css",
                      "~/Content/datatables/css/bootstrap-datetimepicker.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/bootstrap-overrides.css",
                      "~/Content/site.css"));
        }
    }
}
