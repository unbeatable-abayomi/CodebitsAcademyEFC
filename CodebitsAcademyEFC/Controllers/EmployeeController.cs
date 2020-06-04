using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.EmployeeRepository;
using CodebitsAcademyEFC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsAcademyEFC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee) => _employee = employee;
       
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
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View();
            }

        }
    }
}