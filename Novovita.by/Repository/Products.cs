using Novovita.by.Context;
using Novovita.by.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novovita.by.Repository
{
    public class Products
    {
        static EfContext db = new EfContext();

        public static List<Product> Get()
        {
            return db.Products.ToList();
        }

        public static Product Get(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public static Product AddOrUpdate(Product product)
        {
            var set = db.Products.Update(product).Entity;

            db.SaveChanges();

            return set;
        }

        public static Product Delete(Product product)
        {
            var set = db.Products.Remove(product).Entity;

            db.SaveChanges();

            return set;
        }

        public static List<Product> GetFiltered(int categoryId)
        {
            var prod = db.Products.Where(p => p.CategoryId == categoryId).ToList();

            return prod;
        }
    }
}
