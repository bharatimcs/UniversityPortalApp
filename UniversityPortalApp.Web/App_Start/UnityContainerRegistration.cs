using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityPortalApp.Core;
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

            //Registry the dependencies
            container.RegisterType<IRepository<Student>, Repository<Student>>();
            container.RegisterType<IRepository<Instructor>, Repository<Instructor>>();
            container.RegisterType<IRepository<Course>, Repository<Course>>();
            container.RegisterType<IRepository<Department>, Repository<Department>>();
            container.RegisterType<IRepository<Address>, Repository<Address>>();
            container.RegisterType<IRepository<Enrollment>, Repository<Enrollment>>();

            container.RegisterType<StudentController>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}