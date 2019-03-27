using Novovita.by.Context;
using Novovita.by.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novovita.by.Repository
{
    public class NewsRepository
    {
        static EfContext db = new EfContext();

        public static List<News> Get => db.News.ToList();
    }
}
