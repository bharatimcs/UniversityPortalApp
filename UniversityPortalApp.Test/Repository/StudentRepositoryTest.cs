using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityPortalApp.Core;
using UniversityPortalApp.Infrastructure;

namespace UniversityPortalApp.Test.Repository
{
    [TestClass]
    public class StudentRepositoryTest
    {
        [TestMethod]
        public void CreateStudentTest()
        {
            var student = new Student { Id =1, FirstName = "Bharat", LastName = "Sontam" };
            var mockRepository = new Mock<IRepository<Student>>();
            mockRepository.Setup(x => x.InsertOrEdit(student));
            mockRepository.Object.InsertOrEdit(student);
            mockRepository.Verify(x => x.InsertOrEdit(student), Times.Once());
        }

        [TestMethod]
        public void EditStudentTest()
        {
            var student = new Student { Id = 1, FirstName = "Bharat", LastName = "Sontam" };
            var mockRepository = new Mock<IRepository<Student>>();
            mockRepository.Setup(x => x.InsertOrEdit(student));
            mockRepository.Object.InsertOrEdit(student);

            student.FirstName = "BharathKumar";
            mockRepository.Object.InsertOrEdit(student);

            mockRepository.Verify(x => x.InsertOrEdit(student), Times.Exactly(2));
        }

        [TestMethod]
        public void GetStudentbyId()
        {
            var student = new Student { Id = 1 };
            var mockRepository = new Mock<IRepository<Student>>();
            mockRepository.Setup(x => x.GetById(1)).Returns(student);

            mockRepository.Object.GetById(1).ShouldBe(student);

            mockRepository.Verify(x => x.GetById(student.Id), Times.Once());
        }

        [TestMethod]
        public void DeleteStudent()
        {
            var student = new Student { Id = 1 };
            var mockRepository = new Mock<IRepository<Student>>();
            mockRepository.Setup(x => x.Delete(1));
            mockRepository.Object.Delete(1);

            mockRepository.Setup(x=>x.GetById(1));
            mockRepository.Object.GetById(1).ShouldBe(null);

            mockRepository.Verify(x => x.Delete(student.Id), Times.Once());
        }
    }
}
