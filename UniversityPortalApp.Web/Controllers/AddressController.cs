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
    public class AddressController : BaseController
    {
        private IRepository<Student> StudentRepository;
        private IRepository<Address> AddressRepository;

        public AddressController(IRepository<Student> studentRepository, IRepository<Address> addressRepository)
        {
            this.StudentRepository = studentRepository;
            this.AddressRepository = addressRepository;
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int studentId)
        {
            var model = new Address { StudentId = studentId };
            ViewBag.Student = this.StudentRepository.GetById(studentId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Student = this.StudentRepository.GetById(address.StudentId);
                return View(address);
            }
            else
            {
                this.AddressRepository.InsertOrEdit(address);
                return RedirectToAction("Detail", new { id = address.Id });
            }
        }

        public ActionResult Detail(int id)
        {
            var model = this.AddressRepository.GetById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = this.AddressRepository.GetById(id);
            ViewBag.Student = this.StudentRepository.GetById(model.StudentId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Student = this.StudentRepository.GetById(address.StudentId);
                return View(address);
            }
            else
            {
                this.AddressRepository.InsertOrEdit(address);
                return RedirectToAction("Detail", new { id = address.Id });
            }
        }

        public ActionResult Delete(int id, int studentId)
        {
            this.AddressRepository.Delete(id);
            return RedirectToAction("Detail", "Student", new { id = studentId });
        }
    }
}