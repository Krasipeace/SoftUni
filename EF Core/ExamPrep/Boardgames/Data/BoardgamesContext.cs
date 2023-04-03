namespace Boardgames.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class BoardgamesContext : DbContext
    {
        public BoardgamesContext()
        { 
        }

        public BoardgamesContext(DbContextOptions options)
            : base(options) 
        {
        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Creator> Creators { get; set; }

        public DbSet<Boardgame> Boardgames { get; set; }

        public DbSet<BoardgameSeller> BoardgamesSellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BoardgameSeller>(bs =>
                {
                    bs.HasKey(bs => new { bs.BoardgameId, bs.SellerId });
                });           
        }
    }
}
