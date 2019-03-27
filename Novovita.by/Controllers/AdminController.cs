using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novovita.by.Models;
using Novovita.by.Repository;
using Novovita.by.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Novovita.by.Controllers
{
    public class AdminController:Controller
    {
        private static string WebRootPath => Statics.WebRootPath;

        public IActionResult Index()
        {
            return RedirectToAction( nameof(CategoriesList));
        }

        public IActionResult CategoriesList()
        {
            var categories = Categories.Get();
            return View(categories);
        }

        public IActionResult CategoriesAddOrUpdate(int id)
        {
            return View(Categories.Get(id));
        }

        [HttpPost]
        public IActionResult CategoriesAddOrUpdate(Category category, IFormFile mainfile)
        {
           
            category.Image = SaveFile(mainfile, "categories") ?? category.Image;

            Categories.AddOrUpdate(category);

            ViewData[nameof(Categories)] = Categories.Get();

            return RedirectToAction(nameof(CategoriesList));
        }

        [HttpGet]
        public IActionResult CategoriesDelete(int id)
        {
            var category = Categories.Get(id);

            Categories.Delete(category);

            return RedirectToAction(nameof(CategoriesList));
        }

        private static string SaveFile(IFormFile file, string folder)
        {
            if (file == null)
            {
                return null;
            }

            var fileName = $"{Guid.NewGuid()}__{file.FileName}";
            var saveImagePath = $"images/{folder}/{fileName}";
            var fullPath = Path.Combine(WebRootPath, saveImagePath);

            try
            {
                using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                    return fileName;
                }
            }
            catch
            {
                return null;
            }
        }

        public IActionResult ProductsList()
        {
            var products = Products.Get();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductsAddOrUpdate(int id = -1)
        {
          
            ViewData["Categories"] = Categories.Get();
            ViewData[nameof(Products)] = Products.Get();
            return View(Products.Get(id));
        }

        [HttpPost]
        public IActionResult ProductsAddOrUpdate(Product product, IFormFile[] files, IFormFile mainfile)
        {
          
            product.MainImage = SaveFile(mainfile, "products") ?? product.MainImage;

            if (files.Any())
            {
                product.ImagesObj = new List<string>();
                files.ToList().ForEach(f => product.ImagesObj.Add(SaveFile(f, "products")));
                product.ImagesObj = product.ImagesObj.Where(i => i != null).ToList();
            }

            Products.AddOrUpdate(product);

            ViewData["Categories"] = Categories.Get();

            return RedirectToAction(nameof(ProductsList));
        }


    }
}
