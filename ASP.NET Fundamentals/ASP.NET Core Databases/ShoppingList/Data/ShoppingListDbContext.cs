using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Models;

namespace ShoppingList.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ProductNote> ProductNotes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.;Database=ShoppingList;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductNotes)
                .WithOne(pn => pn.Product);
        }
    }
}
