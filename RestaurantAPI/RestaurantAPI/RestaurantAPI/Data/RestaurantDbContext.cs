using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {

        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantEntity>().ToTable("Restaurants");
            modelBuilder.Entity<RestaurantEntity>().HasMany(r => r.Dishes).WithOne(d => d.Restaurant);
            modelBuilder.Entity<RestaurantEntity>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<DishEntity>().ToTable("Dishes");
            modelBuilder.Entity<DishEntity>().HasOne(d => d.Restaurant).WithMany(r => r.Dishes);
            modelBuilder.Entity<DishEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
        }
    }
}
