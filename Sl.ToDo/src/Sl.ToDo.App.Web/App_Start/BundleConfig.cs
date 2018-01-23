using System.Web.Optimization;

namespace Sl.ToDo.App.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/bundle/css")
				.Include("~/Content/bootstrap/bootstrap.css"));

			bundles.Add(new ScriptBundle("~/bundle/vendors")
				.Include("~/Scripts/vendors/jquery/jquery-{version}.js"
					, "~/Scripts/vendors/bootstrap/bootstrap.js"));
		}
	}
}