namespace ForumApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Post>()
                .HasIndex(p => p.Title)
                .IsUnique();      // anti-spam 

            SeedPosts seed = new();
            seed.SeedPost();
            modelBuilder
                .Entity<Post>()
                .HasData(seed.FirstPost, seed.SecondPost, seed.ThirdPost);

            base.OnModelCreating(modelBuilder);
        }
    }
}
