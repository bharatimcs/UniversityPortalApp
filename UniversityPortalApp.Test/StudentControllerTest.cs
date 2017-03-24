using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPortalApp.Web.Controllers;
using UniversityPortalApp.Infrastructure;
using UniversityPortalApp.Core;
using System.Web.Mvc;
using System.Collections.Generic;
using UniversityPortalApp.Data;
using Moq;
using Shouldly;
using System.Linq;

namespace UniversityPortalApp.Test
{
    [TestClass]
    public class StudentControllerTest
    {
        private StudentController StudentController;
        private Mock<IRepository<Student>> studentMockRepository;
        private Mock<IRepository<Department>> departmentMockRepository;
        public StudentControllerTest()
        {
            studentMockRepository = new Mock<IRepository<Student>>();
            departmentMockRepository = new Mock<IRepository<Department>>();
            this.StudentController = new StudentController(studentMockRepository.Object, departmentMockRepository.Object);
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
            var studentList = new List<Student> {
                new Student { Id=1,FirstName="Test1", LastName="Test1" },
                new Student { Id=2,FirstName="Test2", LastName="Test2"},
                new Student { Id=3,FirstName="Test3", LastName="Test3"}
            };

            studentMockRepository.Setup(x => x.GetAll).Returns(studentList.AsQueryable());
            var result = (ViewResult)this.StudentController.Index();

            Assert.IsInstanceOfType(result.Model as IQueryable<Student>, typeof(IQueryable<Student>));
        }

        [TestMethod]
        public void CreateHttpGetViewNameTest()
        {
            var result = (ViewResult)this.StudentController.Create();
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateHttpGetViewBagTest()
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

        [TestMethod]
        public void DetailsTest()
        {

            var student = new Student { Id = 1, FirstName = "Bharat", LastName = "Sontam" };

            studentMockRepository.Setup(x => x.GetById(1)).Returns(student);

            var result = (ViewResult)this.StudentController.Detail(1);

            Assert.AreEqual((result.Model as Student).FirstName, "Bharat");
        }
    }
}
