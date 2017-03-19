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
    public class EnrollmentController : BaseController
    {
        // GET: Enrollment
        private IRepository<Course> CourseRepository;
        private IRepository<Instructor> InstructorRepository;
        private IRepository<Enrollment> EnrollmentRepository;
        private IRepository<Student> StudentRepository;


        public EnrollmentController(IRepository<Enrollment> enrollmentRepository, IRepository<Student> studentRepository, IRepository<Course> courseRepository, IRepository<Instructor> instructorRepository)
        {
            this.CourseRepository = courseRepository;
            this.InstructorRepository = instructorRepository;
            this.EnrollmentRepository = enrollmentRepository;
            this.StudentRepository = studentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            var result = this.EnrollmentRepository.GetAll;
            return View(result);
        }

        public ActionResult Create()
        {
            SetViewBags();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                SetViewBags();
                return View(enrollment);
            }
            else
            {
                this.EnrollmentRepository.InsertOrEdit(enrollment);
                return RedirectToAction("Detail", new { id = enrollment.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.EnrollmentRepository.GetById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.EnrollmentRepository.GetById(id);
            SetViewBags();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                SetViewBags();
                return View(enrollment);
            }
            else
            {
                this.EnrollmentRepository.InsertOrEdit(enrollment);
                return RedirectToAction("Detail", new { id = enrollment.Id });
            }
        }

        public ActionResult Delete(int id)
        {
            this.EnrollmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBags()
        {
            ViewBag.Courses = this.CourseRepository.GetAll.Select(x => new SelectListItem { Text = x.CourseName, Value = x.Id.ToString() }).ToList();
            ViewBag.Instructors = this.InstructorRepository.GetAll.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();
        }
    }
}