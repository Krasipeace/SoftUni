using Blog.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data
{
    /// <summary>
    /// Context describing the database
    /// </summary>
    public class BlogDbContext : DbContext
    {
        /// <summary>
        /// Creates empty constructor for migrations
        /// </summary>
        public BlogDbContext()
        {
        }

        /// <summary>
        /// Creates constructor with options
        /// </summary>
        /// <param name="options">Context options</param>
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Articles table
        /// </summary>
        public DbSet<Article> Articles { get; set; } = null!;

        /// <summary>
        /// Application users table
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        /// <summary>
        /// Genres table
        /// </summary>
        public DbSet<Genre> Genres { get; set; } = null!;
    }
}
