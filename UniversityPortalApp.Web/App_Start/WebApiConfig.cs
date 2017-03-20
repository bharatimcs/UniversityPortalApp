using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using UniversityPortalApp.Data;
using UniversityPortalApp.Infrastructure;
using UniversityPortalApp.Web.Areas.Api.Controllers;
using UniversityPortalApp.Web.Controllers;

namespace UniversityPortalApp.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Api_Api_Default",
                routeTemplate: "{controller}/api/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            #region formatters
            var jsonpFormatter = new JsonpFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);
            config.Formatters.Add(new BsonFormatter());
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("fmt", "xml", "text/xml"));

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            #endregion

            var container = new UnityContainer();
            //Registring the Context
            container.RegisterType<UniversityContext>();

            //Registering Generic repository
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new HierarchicalLifetimeManager());
            typeof(BaseApiController).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseApiController))).ToList().ForEach(x =>
            {
                container.RegisterType(x);
            });

            config.DependencyResolver = new UnityApiDependencyResolver(container);

        }
    }
}
