using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodebitsAcademyEFC.AccountsRepository;
using CodebitsAcademyEFC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsAcademyEFC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccounts _accounts;
        public AccountController(IAccounts accounts) => _accounts = accounts;
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lists()
        {
            return View(_accounts.AllSystemUsers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SystemUsersModel systemUsersModel)
        {
            if (ModelState.IsValid)
            {
                _accounts.AddSystemUser(systemUsersModel);
                return View("Success", systemUsersModel);
            }

            return View();
            


        }

        public IActionResult Details(long Id)
        {
            SystemUsersModel systemUsersModel = _accounts.GetSystemUser(Id);
            return View(systemUsersModel);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            SystemUsersModel systemUsersModel = _accounts.GetSystemUser(Id);
            return View(systemUsersModel);
        }

        [HttpPost]
        public IActionResult Edit(SystemUsersModel systemUsersModel)
        {
            _accounts.EditSystemUser(systemUsersModel);
            return View("editSuccess",systemUsersModel);
        }


        [HttpGet]

        public IActionResult Delete(long Id)
        {
            SystemUsersModel systemUsersModel = _accounts.GetSystemUser(Id);
            return View(systemUsersModel);
        }

        [HttpPost]
        public IActionResult Delete(SystemUsersModel systemUsersModel)
        {
             _accounts.DeleteSystemUser(systemUsersModel);
            return View("deleteSuccess",systemUsersModel);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string surname)
        {
            IQueryable<SystemUsersModel> systemUsers = _accounts.Search(surname);
            return View("searchView", systemUsers);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var status = _accounts.Authentiction(username, password);
            ViewBag.Name = username; 
            if (status)
            {
                return View("SuccessLogin");
            }
            return View("FailedLogin");
        }
    }
}