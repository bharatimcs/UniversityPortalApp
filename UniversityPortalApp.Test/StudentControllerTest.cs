using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPortalApp.Web.Controllers;
using UniversityPortalApp.Infrastructure;
using UniversityPortalApp.Core;
using System.Web.Mvc;
using System.Collections.Generic;

namespace UniversityPortalApp.Test
{
    [TestClass]
    public class StudentControllerTest
    {
        private StudentController StudentController;
        public StudentControllerTest()
        {
            this.StudentController = new StudentController(new Repository<Student>(), new Repository<Department>());
        }
        [TestMethod]
        public void IndexTest()
        {
            var result = (ViewResult)this.StudentController.Index();

            Assert.AreEqual("Index", result.ViewName);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Student>));
        }

        [TestMethod]
        public void CreateHttpGetTest()
        {
            var result = (ViewResult)this.StudentController.Create();
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
