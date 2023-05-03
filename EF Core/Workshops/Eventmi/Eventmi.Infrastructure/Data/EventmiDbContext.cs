using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data
{
    /// <summary>
    /// Context describers database
    /// </summary>
    public class EventmiDbContext : DbContext
    {
        /// <summary>
        /// Creates empty constructor
        /// </summary>
        public EventmiDbContext()
        {
        }

        /// <summary>
        /// Creates constructor with options
        /// </summary>
        /// <param name="options">Context options</param>
        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Events table
        /// </summary>
        public DbSet<Event> Events { get; set; } = null!;
    }
}
