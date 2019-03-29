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

        public static List<News> Get()
        {
            return db.News.ToList();
        }

        public static News Get(int id)
        {
            return db.News.FirstOrDefault(p => p.Id == id);
        }

        public static News AddOrUpdate(News news)
        {
            var set = db.News.Add(news).Entity;
            db.SaveChanges();
            return set;
        }
        public static News Delete(News news)
        {
            var set = db.News.Remove(news).Entity;

            db.SaveChanges();

            return set;
        }
    }
}
