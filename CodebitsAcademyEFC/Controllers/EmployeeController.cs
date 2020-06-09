using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.EmployeeRepository;
using CodebitsAcademyEFC.Models;
using CodebitsAcademyEFC.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsAcademyEFC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeController(IEmployee employee, IWebHostEnvironment webHostEnvironment) {
            _employee = employee;
            this.webHostEnvironment = webHostEnvironment;

        } 
       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Lists()
        {
            return View(_employee.Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {

                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath,"images");
                    uniqueFileName = Guid.NewGuid().ToString() +"_"+model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee employees = new Employee()
                { Id = model.Id,
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