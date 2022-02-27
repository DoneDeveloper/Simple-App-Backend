using backend.Models;
using backend.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        //public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\arxdev-11-21\Desktop\Cognizant Full Stack coding challenge warehouse v5\database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Location>()
            //    .HasOne(p => p.Warehouse)
            //    .WithOne(p => p.Location);

            //modelBuilder.Entity<Car>()
            //    .HasOne(p => p.Warehouse)
            //    .WithMany(p => p.Cars);
        }

    }
}
