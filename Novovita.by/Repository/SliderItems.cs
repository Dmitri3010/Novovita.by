using Novovita.by.Context;
using Novovita.by.Models;
using System.Collections.Generic;
using System.Linq;

namespace Novovita.by.Repository
{
    public class SliderItems
    {
        static EfContext db = new EfContext();

        public static List<MainSlider> Get()
        {
            return db.MainSliders.ToList();
        }

        public static MainSlider Get(int id)
        {
            return db.MainSliders.FirstOrDefault(p => p.Id == id);
        }

        public static MainSlider AddOrUpdate(MainSlider slider)
        {
            var set = db.MainSliders.Add(slider).Entity;
            db.SaveChanges();
            return set;
        }
        public static MainSlider Delete(MainSlider slider)
        {
            var set = db.MainSliders.Remove(slider).Entity;

            db.SaveChanges();

            return set;
        }
    }
}
