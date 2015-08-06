using System.Web;
using System.Web.Optimization;

namespace EngineerInDev
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Controllers")
                .Include("~/Content/Scripts/Controllers/*.js"));

            bundles.Add(new ScriptBundle("~/Content/Plugins")
                .IncludeDirectory("~/Content/Scripts/Plugins", "*.js", true));

            bundles.Add(new ScriptBundle("~/Content/Directives")
                .IncludeDirectory("~/Content/Scripts/Directives", "*.js"));

            bundles.Add(new ScriptBundle("~/Content/Filters")
                .IncludeDirectory("~/Content/Scripts/Filters", "*.js"));

            bundles.Add(new StyleBundle("~/Content/Styles")
                .IncludeDirectory("~/Content/Css", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
