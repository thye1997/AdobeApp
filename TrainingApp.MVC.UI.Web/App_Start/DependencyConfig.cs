using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingApp.MVC.Framework.WebServices;
using TrainingApp.MVC.Framework.WebServices.Interfaces;
using TrainingApp.MVC.UI.Process.Interfaces;
using TrainingApp.MVC.UI.Process.Processes;
using Unity;
using Unity.Mvc5;
namespace TrainingApp.MVC.UI.Dependency
{
    public class DependencyConfig
    {

        public static void RegisterDependency()
        {
            var container = new UnityContainer();

            container.RegisterType<IWebServiceHelper, WebServiceExecutor>();
            container.RegisterType<IUserProcess, UserProcess>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}