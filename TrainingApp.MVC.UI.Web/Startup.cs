using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using TrainingApp.MVC.UI.Dependency;

[assembly: OwinStartup(typeof(TrainingApp.MVC.UI.Web.Startup))]

namespace TrainingApp.MVC.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            AreaRegistration.RegisterAllAreas();
            DependencyConfig.RegisterDependency();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
