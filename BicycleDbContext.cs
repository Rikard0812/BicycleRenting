using System;
using System.Collections.Generic;
using System.Text;
using BicycleRenting.EntityConfigurations;
using BicycleRenting.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleRenting
{
    public class BicycleDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BicycleDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.
                ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.
                ApplyConfiguration(new BicycleConfiguration());
            modelBuilder.
                ApplyConfiguration(new BrandConfiguration());

        }
    }

}
