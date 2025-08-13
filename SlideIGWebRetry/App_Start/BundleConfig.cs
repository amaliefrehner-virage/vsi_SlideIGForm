using System.Web;
using System.Web.Optimization;

namespace SlideIGWebRetry
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap"
            ));

            bundles.Add(new ScriptBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"
            ));
        }
    }
}
