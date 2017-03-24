using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity.Mvc5;
using UniversityPortalApp.Data;
using UniversityPortalApp.Infrastructure;
using UniversityPortalApp.Web.Areas.Api.Controllers;
using UniversityPortalApp.Web.Controllers;

namespace UniversityPortalApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<UniversityContext>();

            //Registering Generic repository
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            //Register AccountController and ManageController and forces Unity to use parameterless constructor
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            #region NO NEED OF REGISTERING CONTROLLERSS (Registering controllers has commented out)
            //typeof(BaseController).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseController))).ToList().ForEach(x =>
            //{
            //    container.RegisterType(x);
            //});


            ///NO NEED OF REGISTERING CONTROLLERSS
            //typeof(BaseApiController).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseApiController))).ToList().ForEach(x =>
            //{
            //    container.RegisterType(x);
            //});
            #endregion
        }
    }
}