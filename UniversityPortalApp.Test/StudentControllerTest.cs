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
        public void IndexViewNameTest()
        {
            var result = (ViewResult)this.StudentController.Index();

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexResultTest()
        {
            var result = (ViewResult)this.StudentController.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexModelTest()
        {
            var result = (ViewResult)this.StudentController.Index();
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Student>));
        }

        [TestMethod]
        public void CreateHttpGetViewNameTest()
        {
            var result = (ViewResult)this.StudentController.Create();
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateHttpGetResultTest()
        {
            var result = (ViewResult)this.StudentController.Create();
            Assert.IsInstanceOfType(result.ViewBag.Departments, typeof(IEnumerable<SelectListItem>));
        }

        [TestMethod]
        public void CreateHttpPostModelStateValidTest()
        {
            var student = new Student();
            this.StudentController.ModelState.AddModelError("Test", "TestingError");
            var result = this.StudentController.Create(student) as ViewResult;
            var modelState = this.StudentController.ModelState;
            Assert.AreEqual(false, modelState.IsValid);
        }

        [TestMethod]
        public void CreateHttpPostModelStateNotValidViewNameTest()
        {
            var student = new Student();
            this.StudentController.ModelState.AddModelError("Test", "TestingError");
            var result = this.StudentController.Create(student) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreatehttpPostModelStateNotValidViewBagTest()
        {
            var student = new Student();
            this.StudentController.ModelState.AddModelError("Test", "TestingError");
            var result = this.StudentController.Create(student) as ViewResult;
            Assert.IsInstanceOfType(result.ViewBag.Departments, typeof(IEnumerable<SelectListItem>));
        }
    }
}
