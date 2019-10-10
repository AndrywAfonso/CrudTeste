using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CRUDTeste.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.3.1.min.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                "~/Scripts/inputmask/inputmask.js",
                "~/Scripts/inputmask/jquery.inputmask.js",
                "~/Scripts/inputmask/inputmask.extensions.js",
                "~/Scripts/inputmask/inputmask.date.extensions.js",
                "~/Scripts/inputmask/inputmask.numeric.extensions.js"));
        }
    }
}