namespace ProductShop.Data;

using Microsoft.EntityFrameworkCore;

using ProductShop.Models;

public class ProductShopContext : DbContext
{
    public ProductShopContext()
    {
    }

    public ProductShopContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<CategoryProduct> CategoriesProducts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasMany(u => u.ProductsBought)
                .WithOne(u => u.Buyer)
                .HasForeignKey(u => u.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasMany(u => u.ProductsSold)
                .WithOne(u => u.Seller)
                .HasForeignKey(u => u.SellerId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .Property(p => p.BuyerId)
                .IsRequired(false);
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(cp => new { cp.CategoryId, cp.ProductId });
        });
    }
}
