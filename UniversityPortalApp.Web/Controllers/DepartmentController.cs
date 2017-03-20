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
    [CustomActionFilter]
    [HandleExceptions]
    public class DepartmentController : BaseController
    {
        // GET: Department
        private IRepository<Instructor> InstructorRepository;
        private IRepository<Department> DepartmentRepository;


        public DepartmentController(IRepository<Instructor> instructorRepository, IRepository<Department> departmentRepository)
        {
            this.InstructorRepository = instructorRepository;
            this.DepartmentRepository = departmentRepository;
        }

     
        public ActionResult Index()
        {
            var result = this.DepartmentRepository.GetAll;
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Instructors = this.InstructorRepository.GetAll.Select(x => new SelectListItem { Text = x.FirstName+" "+x.LastName, Value = x.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Instructors = this.InstructorRepository.GetAll.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();
                return View(department);
            }
            else
            {
                this.DepartmentRepository.InsertOrEdit(department);
                return RedirectToAction("Detail", new { id = department.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.DepartmentRepository.GetById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.DepartmentRepository.GetById(id);
            ViewBag.Instructors = this.InstructorRepository.GetAll.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Instructors = this.InstructorRepository.GetAll.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();
                return View(department);
            }
            else
            {
                this.DepartmentRepository.InsertOrEdit(department);
                return RedirectToAction("Detail", new { id = department.Id });
            }
        }

        public ActionResult Delete(int id)
        {
            this.DepartmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}