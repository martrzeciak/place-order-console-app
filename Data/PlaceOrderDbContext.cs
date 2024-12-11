using Microsoft.EntityFrameworkCore;
using PlaceOrderConsoleApp.Models;

namespace PlaceOrderConsoleApp.Data;

public class PlaceOrderDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public PlaceOrderDbContext(DbContextOptions<PlaceOrderDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed initial data for the Products table
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 2500 },
            new Product { Id = 2, Name = "Klawiatura", Price = 120 },
            new Product { Id = 3, Name = "Mysz", Price = 90 },
            new Product { Id = 4, Name = "Monitor", Price = 1000 },
            new Product { Id = 5, Name = "Kaczka debuggująca", Price = 66 }
        );
    }
}
