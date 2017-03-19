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
    public class StudentController : BaseController
    {
        private IRepository<Student> StudentRepository;
        private IRepository<Department> DepartmentRepository;


        public StudentController(IRepository<Student> studentRepository, IRepository<Department> departmentRepository)
        {
            this.StudentRepository = studentRepository;
            this.DepartmentRepository = departmentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            var result = this.StudentRepository.GetAll;
            return View("Index", result);
        }

        public ActionResult Create()
        {
            var model = new Student();
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View("Create", student);
            }
            else
            {
                this.StudentRepository.InsertOrEdit(student);
                return RedirectToAction("Detail", new { id = student.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.StudentRepository.GetById(id);
            return View("Detail", model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.StudentRepository.GetById(id);
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View("Edit", student);
            }
            else
            {
                this.StudentRepository.InsertOrEdit(student);
                return RedirectToAction("Detail", new { id = student.Id });
            }
        }

        public ActionResult Delete(int id)
        {
            this.StudentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}