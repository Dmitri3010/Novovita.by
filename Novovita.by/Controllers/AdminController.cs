using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

        public IActionResult CategoriesList()
        {
            return View();
        }
    }
}
