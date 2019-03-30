using System.Diagnostics;
using System.Linq;
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
            ViewData["News"] = news;
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
            var categories = Categories.Get();
            ViewData[nameof(Category)] = categories;
            return View(products);

        }

        public IActionResult SingleNews(int id)
        {
            var news = NewsRepository.Get(id);
            ViewData["News"] = NewsRepository.Get().Take(5).ToList();
            return View(news);
        }

        public IActionResult SingleProduct(int id)
        {
            var product = Products.Get(id);
            var products = Products.Get();
            if (Products.Get(id + 1) != null)
            {
                var nextProduct = Products.Get(id + 1);
                ViewData["next"] = nextProduct;
            }
            else
            {
                ViewData["next"] = product;
            }

            if (Products.Get(id - 1) != null)
            {
                var previosProduct = Products.Get(id - 1);
                ViewData["previos"] = previosProduct;
            }

            else
            {
                ViewData["previos"] = product;
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Filtered(int categoryId)
        {
            var products = Products.GetFiltered(categoryId);
            var category = Categories.Get(categoryId);
            ViewData["Product"] = products;
            return PartialView(category);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
