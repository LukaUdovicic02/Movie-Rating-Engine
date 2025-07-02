using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.Context
{
    public class MovieReviewEngineContext : DbContext
    {

        public MovieReviewEngineContext() { }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cast> Casts { get; set; }

        public DbSet<ContentCast> ContentCasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\EfcDataAccess\MovieReviewEngineDB.db");

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys

            modelBuilder.Entity<Content>().HasKey(content => content.ContentId);
            modelBuilder.Entity<Review>().HasKey(review => review.ReviewId);
            modelBuilder.Entity<Cast>().HasKey(cast => cast.CastId);
            modelBuilder.Entity<ContentCast>()
                .HasKey(cc => new { cc.ContentId, cc.CastId });

           // Conversion of the Enum to string

            modelBuilder.Entity<Content>()
                .Property(c => c.Type)
                .HasConversion<string>();

            // Property config

            modelBuilder.Entity<Content>().Property(c => c.Title).HasMaxLength(100);
            modelBuilder.Entity<Content>().Property(c => c.Description).HasMaxLength(500);

            modelBuilder.Entity<Review>().Property(r => r.Rating).IsRequired();
            modelBuilder.Entity<Review>().HasCheckConstraint("CK_Review_Rating", "Rating >= 1 AND Rating <= 5");

            modelBuilder.Entity<Cast>().Property(c => c.Name).HasMaxLength(50);

            // Relationships

            modelBuilder.Entity<ContentCast>()
                .HasOne(cc => cc.Content)
                .WithMany(c => c.ContentCasts)
                .HasForeignKey(cc => cc.ContentId);

            modelBuilder.Entity<ContentCast>()
                .HasOne(cc => cc.Cast)
                .WithMany(c => c.ContentCasts)
                .HasForeignKey(cc => cc.CastId);
        }

    }
}
