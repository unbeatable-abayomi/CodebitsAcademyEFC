using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.DepartmentRepository;
using CodebitsAcademyEFC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsAcademyEFC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;
        public DepartmentController(IDepartment dept)
        {
            _department = dept;

        }
        public IActionResult Index()
        {
            
            ViewBag.AllDepts = _department.AllDepartments;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _department.AddDepartment(department);
            return View();
        }
    }
}
