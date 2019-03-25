using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Novovita.by.Models;
using System.Collections.Generic;

namespace Novovita.by.Context
{
    public class EfContext : DbContext
    {
        public static string ConnectionString { private get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GE4L5QE;Database=Novovita.by;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
