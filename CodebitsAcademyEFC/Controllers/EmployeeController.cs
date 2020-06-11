using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.DepartmentRepository;
using CodebitsAcademyEFC.EmployeeRepository;
using CodebitsAcademyEFC.Models;
using CodebitsAcademyEFC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodebitsAcademyEFC.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IDepartment _department;
        public EmployeeController(IEmployee employee, IWebHostEnvironment webHostEnvironment,IDepartment department) {
            _employee = employee;
            this.webHostEnvironment = webHostEnvironment;
            _department = department;

        } 
       
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        public IActionResult Lists()
        {
            return View(_employee.Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_department.AllDepartments, "ID","Name");
            return View();
        }

        [HttpPost]
        public IActionResult  Create(EmployeeViewModel model)
        {
            ViewBag.Departments = new SelectList( _department.AllDepartments, "ID", "Name");
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {

                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee employees = new Employee()
                {
                    //Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Gender = model.Gender,
                    Address = model.Address,
                    PhotoPath = uniqueFileName
                };
                _employee.AddEmployee(employees);
                return View("SuccessMessage", employees);
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult DeleteConfirm(long Id)
        {
            Employee employee = _employee.GetEmployee(Id);
            if(employee == null)
            {
                //error message
                return RedirectToAction("Lists");
            }
            return View(employee);
        }

        [HttpPost] 
        public IActionResult Delete(long Id)
        {
            var employee = _employee.Delete(Id);
            return View("DeleteMessage",employee);

        }

        public IActionResult Details(long Id)
        {
            Employee employee = _employee.GetEmployee(Id);
            return View( employee);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            Employee employee = _employee.GetEmployee(Id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            //if (ModelState.IsValid)
            //{
            //    string uniqueFileName = null;
            //    if (model.Photo != null)
            //    {

            //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            //    }
            //    Employee employees = new Employee()
            //    {
            //        Id = model.Id,
            //        FirstName = model.FirstName,
            //        LastName = model.LastName,
            //        Age = model.Age,
            //        PhoneNumber = model.PhoneNumber,
            //        Email = model.Email,
            //        Gender = model.Gender,
            //        Address = model.Address,
            //        PhotoPath = uniqueFileName
            //    };
                
                _employee.EditEmployee(employee);
                return View("UpdatedSuccess", employee);
            //}
            //else
            //{
            //    return View();
            //}
          
        }

        [HttpPost]
        public IActionResult Search(string Surname)
        {
     
            IQueryable<Employee> employees = _employee.Search(Surname);


           return View("NewView",employees);
        }

        [HttpGet]
        public IActionResult Search()
        {
           


            return View();
        }


      


    }
}