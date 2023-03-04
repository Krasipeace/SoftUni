namespace MusicHub.Data;

using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Writer> Writers { get; set; }

    public DbSet<Producer> Producers { get; set; }

    public DbSet<Album> Albums { get; set; }

    public DbSet<Performer> Performers { get; set; }

    public DbSet<Song> Songs { get; set; }

    public DbSet<SongPerformer> SongsPerformers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Writer>(entity =>
        {
            entity
                .HasKey(w => w.Id);

            entity
                .Property(w => w.Name)
                .HasMaxLength(ValidationConstants.WRITER_NAME_MAX_LENGTH)
                .IsRequired();
        });

        builder.Entity<Producer>(entity =>
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.Name)
                .HasMaxLength(ValidationConstants.PRODUCER_NAME_MAX_LENGTH)
                .IsRequired();
        });

        builder.Entity<Album>(entity =>
        {
            entity
                .HasKey(a => a.Id);

            entity
                .Property(a => a.Name)
                .HasMaxLength(ValidationConstants.ALBUM_NAME_MAX_LENGTH)
                .IsRequired();

            entity
                .Property(a => a.ReleaseDate)
                .HasColumnType("date")
                .IsRequired();

            entity
                .HasOne(a => a.Producer)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.ProducerId);
        });

        builder.Entity<Performer>(entity =>
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.FirstName)
                .HasMaxLength(ValidationConstants.PERFORMER_FIRST_NAME_MAX_LENGTH)
                .IsRequired();

            entity
                .Property(p => p.LastName)
                .HasMaxLength(ValidationConstants.PERFORMER_LAST_NAME_MAX_LENGTH)
                .IsRequired();

            entity
                .Property(p => p.Age)
                .IsRequired();

            entity
                .Property(p => p.NetWorth)
                .IsRequired();
        });

        builder.Entity<Song>(entity =>
        {
            entity
                .HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .HasMaxLength(ValidationConstants.SONG_NAME_MAX_LENGTH)
                .IsRequired();

            entity
                .Property(s => s.Duration)
                .IsRequired();

            entity
                .Property(s => s.CreatedOn)
                .HasColumnType("date")
                .IsRequired();

            entity
                .Property(s => s.Genre)
                .IsRequired();

            entity
                .HasOne(s => s.Album)
                .WithMany(s => s.Songs)
                .HasForeignKey(s => s.AlbumId);

            entity
                .HasOne(s => s.Writer)
                .WithMany(s => s.Songs)
                .HasForeignKey(s => s.WriterId);

            entity
                .Property(s => s.Price)
                .IsRequired();
        });

        builder.Entity<SongPerformer>(entity =>
        {
            entity
                .HasKey(sp => new { sp.SongId, sp.PerformerId});

            entity
                .HasOne(sp => sp.Song)
                .WithMany(sp => sp.SongPerformers)
                .HasForeignKey(sp => sp.SongId);

            entity
                .HasOne(sp => sp.Performer)
                .WithMany(sp => sp.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId);
        });
    }
}
