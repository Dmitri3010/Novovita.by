using Microsoft.EntityFrameworkCore;
using Novovita.by.Models;
using System.Collections.Generic;

namespace Novovita.by.Context
{
    public class EfContext: DbContext
    {
        public static string ConnectionString { private get; set; }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }


        //public EfContext(DbContextOptions<EfContext> options):
        //    base (options)
        //{
        //    Database.EnsureCreated();
        //}
    }
}
