using Microsoft.EntityFrameworkCore;
using System;
using WebApiRestLogging.Models;

namespace WebApiRestLogging.Database
{
    /// <summary>
    /// GroceryContext
    /// </summary>
    public class GroceryContext : DbContext
    {
        /// <summary>
        /// CroceryContext Cionstructor
        /// </summary>
        /// <param name="options"></param>
        public GroceryContext(DbContextOptions<GroceryContext> options) : base(options)
        { }

        /// <summary>
        /// Groceries
        /// </summary>
        public DbSet<Grocery> Groceries { get; set; }

        /// <summary>
        /// Images
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("ShopperSequence")
            //    .StartsAt(101130).IncrementsBy(99);

            //modelBuilder.Entity<Grocery>()
            //    .Property(o => o.Id)
            //    .HasDefaultValueSql("NEXT VALUE FOR ShopperSequence");

            //modelBuilder.HasSequence<int>("ImageSequence")
            //   .StartsAt(6409).IncrementsBy(101);

            //modelBuilder.Entity<Image>()
            //   .Property(o => o.Id)
            //   .HasDefaultValueSql("NEXT VALUE FOR ImageSequence");

            modelBuilder.Entity<Grocery>().HasData
            (
                new Grocery { Id = 1, Name = "Hunt's Tomato Paste", Department = "Perishable", Description = "Hunt's Tomato Paste, 6 oz", Quantity = 3, UnitPrice = 0.49m, DateCreated = DateTime.UtcNow, CreatedBy = "Aggregator" },
                new Grocery { Id = 2, Name = "Plantains", Department = "Produce", Description = "Ripe plantains", Quantity = 8, UnitPrice = 0.79m, DateCreated = DateTime.UtcNow, CreatedBy = "Forwarder" },
                new Grocery { Id = 3, Name = "12 Pack Beer", Department = "Refreshments", Description = "Heineken lager", Quantity = 1, UnitPrice = 14.49m, DateCreated = DateTime.UtcNow, CreatedBy = "System" }
            );
        }
    }
}