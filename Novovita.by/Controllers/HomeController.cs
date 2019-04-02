using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Novovita.by.Models;
using Novovita.by.Repository;
using Novovita.by.Services;

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
            ViewData["Categories"] = categories;
            ViewData["News"] = news;
            return View();
        }

        public IActionResult About()
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contacts()
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(EmailMessage emailMessage)
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            EmailSender.Send(emailMessage);
            return View();
        }

        public IActionResult News()
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            var news = NewsRepository.Get();
            ViewData["News"] = news;

            return View();
        }

        public IActionResult ContactForm()
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            return PartialView();
        }

        public IActionResult Product()
        {
            var products = Products.Get();
            var categories = Categories.Get();
            foreach (var prod in products)
            {
                prod.Category = Categories.Get(prod.CategoryId);
            }
            ViewData[nameof(Category)] = categories;
            ViewData["Products"] = products;
            ViewData["Categories"] = categories;

            return View();

        }

        public IActionResult SingleNews(int id)
        {
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            var news = NewsRepository.Get(id);
            ViewData["News"] = NewsRepository.Get().Take(5).ToList();
            ViewData["Single"] = news;
            return View();
        }

        public IActionResult SingleProduct(int id)
        {
            var product = Products.Get(id);
            product.Category = Categories.Get(product.CategoryId);
            var products = Products.Get();
            if (Products.Get(id + 1) != null)
            {
                var nextProduct = Products.Get(id + 1);
                nextProduct.Category = Categories.Get(id + 1);
                ViewData["next"] = nextProduct;
            }
            else
            {
                ViewData["next"] = product;
            }

            if (Products.Get(id - 1) != null)
            {
                var previosProduct = Products.Get(id - 1);
                previosProduct.Category = Categories.Get(id - 1);
                ViewData["previos"] = previosProduct;
            }

            else
            {
                ViewData["previos"] = product;
            }
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            ViewData["Product"] = product;
            return View();
        }

        [HttpGet]
        public IActionResult Filtered(int categoryId)
        {
            var products = Products.GetFiltered(categoryId);
            var category = Categories.Get(categoryId);
            ViewData["Product"] = products;
            var categories = Categories.Get();
            ViewData["Categories"] = categories;
            return PartialView(category);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
