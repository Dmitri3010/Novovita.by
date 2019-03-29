using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Novovita.by.Models;
using Novovita.by.Repository;

namespace Novovita.by.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var categories = Categories.Get();
            var products = Products.Get();
            var news = NewsRepository.Get();
            ViewData["Products"] = products;
            ViewData["News"] = news ;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contacts()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult News()
        {
            var news = NewsRepository.Get();

            return View(news);
        }

        public IActionResult Product()
        {
            var products = Products.Get();
            return View(products);

        }

        public IActionResult SingleNews(int id)
        {
            return View();
        }

        public IActionResult SingleProduct(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
