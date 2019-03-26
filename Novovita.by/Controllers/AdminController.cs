using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novovita.by.Models;
using Novovita.by.Repository;
using Novovita.by.Services;
using System;
using System.IO;

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


    }
}
