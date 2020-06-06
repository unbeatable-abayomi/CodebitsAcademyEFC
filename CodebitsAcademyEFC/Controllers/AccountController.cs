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
    }
}