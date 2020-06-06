﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.EmployeeRepository;
using CodebitsAcademyEFC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsAcademyEFC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IEmployee employee, IWebHostEnvironment webHostEnvironment) {
            _employee = employee;
            _webHostEnvironment = webHostEnvironment;

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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.AddEmployee(employee);
                return View("SuccessMessage", employee);
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
            _employee.EditEmployee(employee);
            return View("UpdatedSuccess",employee);
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