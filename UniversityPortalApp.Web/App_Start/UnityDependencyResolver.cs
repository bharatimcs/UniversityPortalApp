using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace UniversityPortalApp.Web
{
    internal class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
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
        public void Dispose()
        {
            container.Dispose();
        }
    }
}