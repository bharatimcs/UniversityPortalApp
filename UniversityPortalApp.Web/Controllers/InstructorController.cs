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
    public class InstructorController : BaseController
    {
        // GET: Instructor
        private IRepository<Instructor> InstructorRepository;
        private IRepository<Department> DepartmentRepository;


        public InstructorController(IRepository<Instructor> instructorRepository, IRepository<Department> departmentRepository)
        {
            this.InstructorRepository = instructorRepository;
            this.DepartmentRepository = departmentRepository;
        }


        public ActionResult Index()
        {
            var result = this.InstructorRepository.GetAll;
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View(instructor);
            }
            else
            {
                this.InstructorRepository.InsertOrEdit(instructor);
                return RedirectToAction("Detail", new { id = instructor.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.InstructorRepository.GetById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.InstructorRepository.GetById(id);
            ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = this.DepartmentRepository.GetAll.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.Id.ToString() }).ToList();
                return View(instructor);
            }
            else
            {
                this.InstructorRepository.InsertOrEdit(instructor);
                return RedirectToAction("Detail", new { id = instructor.Id });
            }
        }

        public ActionResult Delete(int id)
        {
            this.InstructorRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}