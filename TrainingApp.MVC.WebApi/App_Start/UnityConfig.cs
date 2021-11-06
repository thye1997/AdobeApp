using System.Web.Http;
using TrainingApp.MVC.Business;
using TrainingApp.MVC.Data;
using TrainingApp.MVC.Data.Context;
using TrainingApp.MVC.Data.UnitOfWork;
using TrainingApp.MVC.Framework.Interfaces;
using Unity;
using Unity.WebApi;

namespace TrainingApp.MVC.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AppDbContext>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserComponent, UserComponent>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}