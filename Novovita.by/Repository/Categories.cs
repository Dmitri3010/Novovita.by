using Novovita.by.Context;
using Novovita.by.Models;
using System.Collections.Generic;
using System.Linq;

namespace Novovita.by.Repository
{

    public class Categories
    {
        static EfContext db = new EfContext();

        public static List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public static Category Get(int id)
        {
            return db.Categories.FirstOrDefault(p => p.Id == id);
        }

        public static Category AddOrUpdate(Category category)
        {
            var set = db.Categories.Update(category).Entity;

            db.SaveChanges();

            return set;
        }

        public static Category Delete(Category category)
        {
            var set = db.Categories.Remove(category).Entity;

            db.SaveChanges();

            return set;
        }
    }
}
