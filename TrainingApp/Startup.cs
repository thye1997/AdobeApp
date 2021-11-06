using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(TrainingApp.Startup))]

namespace TrainingApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
