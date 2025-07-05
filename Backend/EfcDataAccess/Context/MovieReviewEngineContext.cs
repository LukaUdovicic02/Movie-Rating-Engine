using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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

                new Content { ContentId = Guid.NewGuid(), Title = "Casablanca", Description = "A romantic drama set during WWII in Casablanca.", ReleaseDate = new DateTime(1942, 11, 26), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image1.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Citizen Kane", Description = "A newspaper magnate’s rise and fall.", ReleaseDate = new DateTime(1941, 5, 1), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image2.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "2001: A Space Odyssey", Description = "A voyage through space and time.", ReleaseDate = new DateTime(1968, 4, 3), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image3.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", ReleaseDate = new DateTime(1972, 3, 24), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image4.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Jaws", Description = "A great white shark terrorizes a summer resort town.", ReleaseDate = new DateTime(1975, 6, 20), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image5.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "E.T. the Extra-Terrestrial", Description = "A lost alien befriends a boy in suburbia.", ReleaseDate = new DateTime(1982, 6, 11), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image6.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Schindler's List", Description = "The story of Oskar Schindler and his efforts to save Jews during the Holocaust.", ReleaseDate = new DateTime(1993, 12, 15), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image7.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Matrix", Description = "A hacker discovers reality is an illusion.", ReleaseDate = new DateTime(1999, 3, 31), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image8.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Gladiator", Description = "A Roman general becomes a gladiator.", ReleaseDate = new DateTime(2000, 5, 5), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image9.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Dark Knight", Description = "Batman faces the Joker.", ReleaseDate = new DateTime(2008, 7, 18), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image10.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Inception", Description = "A thief who steals corporate secrets through dream-sharing.", ReleaseDate = new DateTime(2010, 7, 16), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image11.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "12 Years a Slave", Description = "A free black man is kidnapped and sold into slavery.", ReleaseDate = new DateTime(2013, 10, 18), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image12.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Mad Max: Fury Road", Description = "Post-apocalyptic road war.", ReleaseDate = new DateTime(2015, 5, 15), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image13.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Moonlight", Description = "A young black man grows up in Miami.", ReleaseDate = new DateTime(2016, 10, 21), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image14.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Parasite", Description = "Poor family infiltrates a wealthy household.", ReleaseDate = new DateTime(2019, 5, 30), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image15.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Nomadland", Description = "A woman lives as a van-dwelling modern nomad.", ReleaseDate = new DateTime(2020, 2, 19), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image16.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Dune", Description = "A son of a noble family leads a rebellion on a desert planet.", ReleaseDate = new DateTime(2021, 10, 22), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image17.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Everything Everywhere All at Once", Description = "A multiverse adventure through family and identity.", ReleaseDate = new DateTime(2022, 3, 25), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image18.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Top Gun: Maverick", Description = "A naval aviator returns as a flight instructor.", ReleaseDate = new DateTime(2022, 5, 27), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image19.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Oppenheimer", Description = "The story of the father of the atomic bomb.", ReleaseDate = new DateTime(2023, 7, 21), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image20.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Barbie", Description = "A journey of self-discovery in Barbie Land.", ReleaseDate = new DateTime(2023, 7, 21), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image21.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Killers of the Flower Moon", Description = "A true-crime saga in 1920s Oklahoma.", ReleaseDate = new DateTime(2023, 10, 20), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image22.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Poor Things", Description = "A Victorian tale of a woman brought back to life.", ReleaseDate = new DateTime(2023, 12, 8), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image23.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Spider-Man: Across the Spider‑Verse", Description = "Miles Morales returns for more multiverse action.", ReleaseDate = new DateTime(2023, 6, 2), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image24.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Whale", Description = "A reclusive teacher tries to reconnect with his daughter.", ReleaseDate = new DateTime(2022, 12, 9), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image25.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Power of the Dog", Description = "A rancher responds brutally to a new marriage.", ReleaseDate = new DateTime(2021, 11, 17), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image26.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Trial of the Chicago 7", Description = "Dramatization of a famous protest trial.", ReleaseDate = new DateTime(2020, 9, 25), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image27.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Soul", Description = "A musician travels from Earth to the afterlife.", ReleaseDate = new DateTime(2020, 12, 25), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image28.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Last of Us", Description = "Post-apocalyptic survival drama (film adaption placeholder).", ReleaseDate = new DateTime(2023, 1, 15), Type = ContentType.Movie, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image29.jpg" },


                new Content { ContentId = Guid.NewGuid(), Title = "The Sopranos", Description = "A mafia boss tries to balance crime and family.", ReleaseDate = new DateTime(1999, 1, 10), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image1.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Wire", Description = "An in-depth look into crime, bureaucracy and society in Baltimore.", ReleaseDate = new DateTime(2002, 6, 2), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image2.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Breaking Bad", Description = "A chemistry teacher becomes a meth kingpin.", ReleaseDate = new DateTime(2008, 1, 20), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image3.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Game of Thrones", Description = "Noble families vie for power in a mythical land.", ReleaseDate = new DateTime(2011, 4, 17), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image4.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Stranger Things", Description = "Kids uncover government secrets and supernatural horrors in 1980s Indiana.", ReleaseDate = new DateTime(2016, 7, 15), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image5.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Crown", Description = "A dramatized history of the British royal family.", ReleaseDate = new DateTime(2016, 11, 4), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image6.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Mandalorian", Description = "A lone bounty hunter in the Star Wars universe.", ReleaseDate = new DateTime(2019, 11, 12), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image7.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Office", Description = "A mockumentary about office workers in Scranton, PA.", ReleaseDate = new DateTime(2005, 3, 24), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image8.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Friends", Description = "Six friends navigating life in New York City.", ReleaseDate = new DateTime(1994, 9, 22), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image9.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Seinfeld", Description = "A show about nothing centered on a quirky group of friends.", ReleaseDate = new DateTime(1989, 7, 5), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image10.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Better Call Saul", Description = "The story of criminal lawyer Saul Goodman before Breaking Bad.", ReleaseDate = new DateTime(2015, 2, 8), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image11.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Boys", Description = "A group takes on corrupt superheroes.", ReleaseDate = new DateTime(2019, 7, 26), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image12.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Last of Us", Description = "A hardened survivor escorts a girl across post-apocalyptic America.", ReleaseDate = new DateTime(2023, 1, 15), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image13.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Squid Game", Description = "Desperate contestants play deadly children's games for money.", ReleaseDate = new DateTime(2021, 9, 17), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image14.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "House of the Dragon", Description = "A prequel to Game of Thrones about House Targaryen.", ReleaseDate = new DateTime(2022, 8, 21), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image15.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Peaky Blinders", Description = "A gangster family in post-WWI Birmingham, England.", ReleaseDate = new DateTime(2013, 9, 12), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image16.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Handmaid's Tale", Description = "A dystopian society where women are forced into servitude.", ReleaseDate = new DateTime(2017, 4, 26), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image17.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Westworld", Description = "A theme park where robots develop consciousness.", ReleaseDate = new DateTime(2016, 10, 2), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image18.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Chernobyl", Description = "A dramatization of the 1986 nuclear disaster.", ReleaseDate = new DateTime(2019, 5, 6), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image19.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Queen's Gambit", Description = "A young chess prodigy rises amid addiction and competition.", ReleaseDate = new DateTime(2020, 10, 23), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image20.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Dark", Description = "A German sci-fi thriller involving time travel.", ReleaseDate = new DateTime(2017, 12, 1), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image21.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Black Mirror", Description = "Anthology series exploring technology's dark side.", ReleaseDate = new DateTime(2011, 12, 4), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image22.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Fargo", Description = "Crime stories in the Midwest with dark humor.", ReleaseDate = new DateTime(2014, 4, 15), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image23.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Ozark", Description = "A family launders drug money in Missouri.", ReleaseDate = new DateTime(2017, 7, 21), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image24.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Succession", Description = "A powerful family's battle for control of a media empire.", ReleaseDate = new DateTime(2018, 6, 3), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image25.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Ted Lasso", Description = "A kind-hearted coach leads a UK soccer team.", ReleaseDate = new DateTime(2020, 8, 14), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image26.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Loki", Description = "The god of mischief causes chaos across timelines.", ReleaseDate = new DateTime(2021, 6, 9), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image27.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "WandaVision", Description = "Superpowered couple trapped in a sitcom reality.", ReleaseDate = new DateTime(2021, 1, 15), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image28.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "The Bear", Description = "A chef returns to run his family’s sandwich shop in Chicago.", ReleaseDate = new DateTime(2022, 6, 23), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image29.jpg" },
                new Content { ContentId = Guid.NewGuid(), Title = "Wednesday", Description = "Wednesday Addams navigates high school and murder mysteries.", ReleaseDate = new DateTime(2022, 11, 23), Type = ContentType.TVShow, ImageURL = "https://mreimagestorage.blob.core.windows.net/imagecontainer/tv-image30.jpg" }


             );
            

        }
    }
}