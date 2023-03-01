namespace P02_FootballBetting.Data;

using Microsoft.EntityFrameworkCore;

using P02_FootballBetting.Data.Common;
using P02_FootballBetting.Data.Models;

public class FootballBettingContext : DbContext
{
    public FootballBettingContext()
    {

    }

    // used by judge
    // loading of dbcontext with DI 
    public FootballBettingContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Town> Towns { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Position> Positions { get; set; }

    public DbSet<PlayerStatistic> PlayersStatistics { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Bet> Bets { get; set; }

    public DbSet<User> Users { get; set; }


    // connection configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // set default connection string
            optionsBuilder.UseSqlServer(DbConfig.CONNECTION_STRING);
        }

        base.OnConfiguring(optionsBuilder);
    }

    // fluent API and entities config
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}