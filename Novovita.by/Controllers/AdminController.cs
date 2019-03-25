using Microsoft.AspNetCore.Mvc;
using Novovita.by.Models;
using Novovita.by.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novovita.by.Controllers
{
    public class AdminController:Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Admin";
            var categories = Categories.Get();


            return View();
        }

        public IActionResult CategoriesList()
        {
            var categories = Categories.Get();
            return View();
        }

        public IActionResult CategoriesAddOrUpdate()
        {
            return View();
        }
    }
}
