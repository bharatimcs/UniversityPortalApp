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
using UniversityPortalApp.Web.Areas.Api.Controllers;

namespace UniversityPortalApp.Test
{
    [TestClass]
    public class StudentApiControllerTest
    {
        private StudentApiController StudentApiController;
        private Mock<IRepository<Student>> studentMockRepository;
        public StudentApiControllerTest()
        {
            studentMockRepository = new Mock<IRepository<Student>>();
            this.StudentApiController = new StudentApiController(studentMockRepository.Object);
        }

        [TestMethod]
        public void IndexViewNameTest()
        {
            var result = (ViewResult)this.StudentController.Index();

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
