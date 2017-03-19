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
    public class CourseController : BaseController
    {
        // GET: Course
        private IRepository<Course> CourseRepository;
        private IRepository<Department> DepartmentRepository;


        public CourseController(IRepository<Course> courseRepository, IRepository<Department> departmentRepository)
        {
            this.CourseRepository = courseRepository;
            this.DepartmentRepository = departmentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            var result = this.CourseRepository.GetAll;
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View(course);
            }
            else
            {
                this.CourseRepository.InsertOrEdit(course);
                return RedirectToAction("Detail", new { id = course.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.CourseRepository.GetById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.CourseRepository.GetById(id);
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View(course);
            }
            else
            {
                this.CourseRepository.InsertOrEdit(course);
                return RedirectToAction("Detail", new { id = course.Id });
            }
        }

        public ActionResult Delete(int id)
        {
            this.CourseRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}