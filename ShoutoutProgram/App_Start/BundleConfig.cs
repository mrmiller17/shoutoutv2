﻿using System.Web.Optimization;

namespace ShoutoutProgram
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/DataTables/dataTables.semanticui.css",
                      "~/Content/semantic.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/DataTables/dataTables.semanticui.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullCalendar").Include(
                        "~/Scripts/moment.js"));

            //// Semantic UI helper scripts
            //bundles.Add(new ScriptBundle("~/bundles/tablesort").Include(
            //            "~/Scripts/SortTable.js"));

            //bundles.Add(new ScriptBundle("~/bundles/search").Include(
            //            "~/Scripts/search.js"));

            //bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
            //            "~/Scripts/DataTables/dataTables.semanticui.js"));
        }
    }
}
