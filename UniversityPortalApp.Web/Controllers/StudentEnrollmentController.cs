using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityPortalApp.Core;
using UniversityPortalApp.Infrastructure;

namespace UniversityPortalApp.Web.Controllers
{
    [Authorize]
    [HandleExceptionsAttribute]
    public class StudentEnrollmentController : BaseController
    {
        private IRepository<Student> StudentRepository;
        private IRepository<Enrollment> EnrollmentRepository;
        private IRepository<StudentEnrollment> StudentEnrollmentRepository;

        public StudentEnrollmentController(IRepository<Student> studentRepository,
            IRepository<Enrollment> enrollmentRepository,
            IRepository<StudentEnrollment> studentEnrollmentRepository)
        {
            this.StudentRepository = studentRepository;
            this.EnrollmentRepository = enrollmentRepository;
            this.StudentEnrollmentRepository = studentEnrollmentRepository;
        }

        // GET: StudentEnrollment
        public ActionResult Enroll(int studentId)
        {
            ViewBag.StudentEnrollments = string.Join(",", this.StudentEnrollmentRepository.GetAll.Where(x => x.StudentId == studentId)
                .Select(x => x.EnrollmentId));
            ViewBag.StudentEnrolledCourses = string.Join(",", this.StudentEnrollmentRepository.GetAll.Where(x => x.StudentId == studentId)
                .Select(x => x.Enrollment.Course.CourseName));
            ViewBag.StudentId = studentId;
            ViewBag.AvailableEnrollments = this.EnrollmentRepository.GetAll.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(int StudentId, string EnrollmentIds)
        {
            var enrolled = this.StudentEnrollmentRepository.GetAll.Where(x => x.StudentId == StudentId);
            this.StudentEnrollmentRepository.DeleteAll(enrolled);
            EnrollmentIds.Split(',').Select(x => int.Parse(x)).ToList()
                .ForEach(x =>
                {
                    this.StudentEnrollmentRepository.InsertOrEdit(
                        new StudentEnrollment
                        {
                            EnrollmentId = x,
                            StudentId = StudentId
                        });
                });
            return RedirectToAction("Detail", "Student", new { id = StudentId });
        }

        public ActionResult DeEnroll(int id, int studentId)
        {
            this.StudentEnrollmentRepository.Delete(id);
            return RedirectToAction("Detail", "Student", new { id = studentId });
        }
    }
}