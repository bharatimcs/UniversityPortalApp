using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace UniversityPortalApp.Web
{
    public class UnityApiDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityApiDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (this.container.IsRegistered(serviceType))
                return this.container.Resolve(serviceType);
            else
                return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.container.IsRegistered(serviceType))
                return this.container.ResolveAll(serviceType);
            else
                return new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityApiDependencyResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}