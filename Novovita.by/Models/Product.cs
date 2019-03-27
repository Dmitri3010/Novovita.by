using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novovita.by.Models
{
    public class Product: Base
    {
        public string Name { get; set; }

        public string Discription { get; set; }

        public double Cost { get; set; }

        public bool IsInStock { get; set; }

        public string MainImage { get; set; }

        [Column("Images")]
        public string JImages
        {
            get => ImagesObj != null ? JsonConvert.SerializeObject(ImagesObj) : string.Empty;
            set => ImagesObj = JsonConvert.DeserializeObject<List<string>>(value ?? string.Empty);
        }

        [NotMapped]
        public List<string> ImagesObj { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
