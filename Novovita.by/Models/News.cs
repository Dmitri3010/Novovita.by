using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novovita.by.Models
{
    public class News:Base
    {
        public string Title { get; set; }

        public string Discription { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }
    }
}
