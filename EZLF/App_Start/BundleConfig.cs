﻿using System.Web;
using System.Web.Optimization;

namespace EZLF
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/layout2013.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Homecss").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/layout2013.css",
                     "~/Content/layouthomeadjustments.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/NewHomecss").Include(
                    "~/Content/font-awesome.min.css",
                    "~/Content/icomoon.css",
                    "~/Content/main.css",
                    "~/Content/paymentInfo.css",
                    "~/Content/responsive.css",
                    "~/Content/template.css",
                    "~/Content/owl.carousel.css"));


            bundles.Add(new ScriptBundle("~/bundles/NewHomeScript").Include(
                     //"~/Scripts/jquery.inputmask.date.extensions.js",
                     //"~/Scripts/jquery.inputmask.js",
                     "~/Scripts/main.js",
                     "~/Scripts/mobile-plans-table.js",
                     "~/Scripts/owl.carousel.js",
                     "~/Scripts/plus-minus-input.js",
                     //"~/Scripts/validation-credit-cards.js",
                     "~/Scripts/respond.js"));

        }
    }
}
