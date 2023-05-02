using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
