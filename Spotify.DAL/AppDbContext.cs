using Microsoft.EntityFrameworkCore;
using Spotify.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public AppDbContext(DbContextOptions options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Artists

            builder.Entity<ArtistEntity>(e =>
            {
                e.HasKey(a => a.Id);
                e.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            });
            
            // Genres

            builder.Entity<GenreEntity>(e =>
            {
                e.HasKey(g => g.Id);
                e.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);
            });

            // Tracks

            builder.Entity<TrackEntity>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);
                e.Property(t => t.AudioUrl)
                .IsRequired()
                .HasMaxLength(50);
            });

            // Relationships

            builder.Entity<TrackEntity>()
                .HasOne(t => t.Genre)
                .WithMany(g => g.Tracks)
                .HasForeignKey(t => t.GenreId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<TrackEntity>()
                .HasMany(t => t.Artists)
                .WithMany(a => a.Tracks)
                .UsingEntity("ArtistTracks");
        }
    }
}
