using Novovita.by.Context;
using Novovita.by.Models;
using System.Collections.Generic;
using System.Linq;

namespace Novovita.by.Services.Repository
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
            return db.Categories.FirstOrDefault(p => p.id == id);
        }
    }
}
