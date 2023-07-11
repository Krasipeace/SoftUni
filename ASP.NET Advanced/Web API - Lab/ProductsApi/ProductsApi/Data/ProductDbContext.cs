namespace ProductsApi.Data
{
    using Microsoft.EntityFrameworkCore;

    using ProductsApi.Data.Models;
    using System.Reflection.Emit;

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product 
                    { 
                        Id = 1, 
                        Name = "Product 1", 
                        Description = "Description Product 1" 
                    },
                    new Product 
                    { 
                        Id = 2, 
                        Name = "Product 2", 
                        Description = "Description Product 2" 
                    },
                    new Product 
                    { 
                        Id = 3, 
                        Name = "Product 3", 
                        Description = "Description Product 3"
                    }
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
