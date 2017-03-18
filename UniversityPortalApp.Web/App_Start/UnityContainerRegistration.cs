using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityPortalApp.Core;
using UniversityPortalApp.Data;
using UniversityPortalApp.Infrastructure;
using UniversityPortalApp.Web.Controllers;

namespace UniversityPortalApp.Web
{
    public class UnityContainerRegistration
    {
        public static IUnityContainer InitialiseContainer()
        {
            //Initialise container
            var container = new UnityContainer();

            //Registring the Context
            container.RegisterType<UniversityContext>();

            //Registering Generic repository
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            //Registering Controllers of typeof(BaseController) dynamically
            typeof(BaseController).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseController))).ToList().ForEach(x =>
            {
                container.RegisterType(x);
            });

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}