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

        // Configuring the location and what db are gonna be used
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

            modelBuilder.Entity<Content>().HasData(

                // Movies
              new Content { ContentId = Guid.NewGuid(), Title = "The Last Horizon", Description = "A sci-fi drama exploring survival and identity.", ReleaseDate = new DateTime(2019, 4, 4), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image3.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Crimson Eclipse", Description = "An espionage thriller set during a solar event.", ReleaseDate = new DateTime(2019, 11, 27), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image4.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Silent River", Description = "A mystery thriller unraveling secrets in a remote village.", ReleaseDate = new DateTime(2020, 8, 15), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image5.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Velvet Crimes", Description = "A detective story with noir aesthetics.", ReleaseDate = new DateTime(2021, 1, 10), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image6.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Broken Compass", Description = "A survival adventure across the Arctic Circle.", ReleaseDate = new DateTime(2018, 9, 2), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image7.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Neon Depths", Description = "A cyberpunk action film set in a glowing megacity.", ReleaseDate = new DateTime(2020, 12, 19), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image8.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Letters to a Ghost", Description = "A romantic drama through time and memory.", ReleaseDate = new DateTime(2017, 5, 5), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image9.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Echoes of Tomorrow", Description = "A scientist’s journey through alternate realities.", ReleaseDate = new DateTime(2021, 6, 18), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image10.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Firelight Sonata", Description = "An emotional drama tied to a pianist’s legacy.", ReleaseDate = new DateTime(2016, 2, 23), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image11.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Steel Giants", Description = "A war epic involving machines and mankind.", ReleaseDate = new DateTime(2018, 7, 30), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image12.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Painted Skies", Description = "A poetic indie film exploring childhood and loss.", ReleaseDate = new DateTime(2019, 3, 11), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image13.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "The Archivist", Description = "A fantasy about a man who protects forgotten worlds.", ReleaseDate = new DateTime(2020, 10, 22), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image14.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Iron Melody", Description = "A musical drama following a band’s rise to fame.", ReleaseDate = new DateTime(2017, 11, 6), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image15.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Shadow Over Town", Description = "A dark thriller in a seemingly peaceful suburb.", ReleaseDate = new DateTime(2018, 4, 13), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image16.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Paper Moons", Description = "A drama about childhood dreams and family.", ReleaseDate = new DateTime(2015, 8, 1), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image17.jpeg" },

                // TV Shows
              new Content { ContentId = Guid.NewGuid(), Title = "Under the Surface", Description = "An investigative drama with deep secrets.", ReleaseDate = new DateTime(2017, 2, 19), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image18.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Skyline Stories", Description = "Urban lives intertwined through a rooftop café.", ReleaseDate = new DateTime(2015, 6, 11), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image19.jpeg" },                
              new Content { ContentId = Guid.NewGuid(), Title = "Dust & Mirrors", Description = "A magician’s journey across dimensions.", ReleaseDate = new DateTime(2021, 1, 22), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image20.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Halcyon Row", Description = "A historical drama in a pre-war aristocratic town.", ReleaseDate = new DateTime(2018, 12, 7), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image21.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Midnight Recipe", Description = "A culinary travelogue that mixes food and mystery.", ReleaseDate = new DateTime(2019, 10, 1), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image22.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Cold Signal", Description = "A sci-fi thriller about communication from beyond.", ReleaseDate = new DateTime(2020, 5, 9), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image23.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Echo Street", Description = "Anthology series exploring alternate outcomes.", ReleaseDate = new DateTime(2022, 9, 14), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image24.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Lanterns", Description = "Stories told by street performers in Tokyo.", ReleaseDate = new DateTime(2016, 1, 30), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image25.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Redline Division", Description = "Police procedural with futuristic gadgets.", ReleaseDate = new DateTime(2021, 3, 3), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image26.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Fractured Light", Description = "An artistic exploration of urban loneliness.", ReleaseDate = new DateTime(2019, 6, 29), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image27.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "The Watchmaker", Description = "A time-travel drama with family stakes.", ReleaseDate = new DateTime(2018, 8, 15), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image28.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Dreampoint", Description = "A docu-drama about dream studies and cases.", ReleaseDate = new DateTime(2020, 11, 4), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image29.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Beacon Hill", Description = "A story of journalists uncovering corruption.", ReleaseDate = new DateTime(2017, 7, 18), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image30.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Parallel Doors", Description = "Neighbors trapped in parallel timelines.", ReleaseDate = new DateTime(2016, 3, 8), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image31.jpeg" },
              new Content { ContentId = Guid.NewGuid(), Title = "Sea of Silence", Description = "Mysterious disappearances on an isolated island.", ReleaseDate = new DateTime(2015, 11, 25), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image32.jpeg" }
            );

        }
    }
}