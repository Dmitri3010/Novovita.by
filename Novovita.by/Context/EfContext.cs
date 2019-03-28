using Microsoft.EntityFrameworkCore;
using Novovita.by.Models;

namespace Novovita.by.Context
{
    public class EfContext : DbContext
    {
        public static string ConnectionString { private get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GE4L5QE;Database=Novovita.by;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
