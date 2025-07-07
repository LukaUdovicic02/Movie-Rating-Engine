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

            modelBuilder.Entity<Cast>().HasData(

                 // The Matrix (sci-fi action)
                 new Cast { CastId = Guid.Parse("f7b6e9d0-1f24-4c58-a5d3-111111111111"), Name = "Keanu Reeves" },
                 new Cast { CastId = Guid.Parse("e2c1f1a7-4a56-4eab-bd2d-222222222222"), Name = "Carrie-Anne Moss" },
                 new Cast { CastId = Guid.Parse("d9f3a7d3-2b16-4d4d-b8b8-333333333333"), Name = "Laurence Fishburne" },

                 // Friends (TV sitcom)
                 new Cast { CastId = Guid.Parse("a8d3f35c-c7d4-4a88-9111-444444444444"), Name = "Jennifer Aniston" },
                 new Cast { CastId = Guid.Parse("b1d1f57e-66f0-4b1d-bb1c-555555555555"), Name = "Courteney Cox" },
                 new Cast { CastId = Guid.Parse("c7d3a5b1-e4b7-4eae-8d6e-666666666666"), Name = "Matthew Perry" },

                 // The Godfather (crime drama)
                 new Cast { CastId = Guid.Parse("2e70b7a4-84e0-43a6-93b8-777777777777"), Name = "Marlon Brando" },
                 new Cast { CastId = Guid.Parse("bbfc7892-d752-4d9f-92a2-888888888888"), Name = "Al Pacino" },
                 new Cast { CastId = Guid.Parse("975f7c8c-4f9c-4ebd-8284-999999999999"), Name = "James Caan" },

                 // Breaking Bad (crime thriller TV show)
                 new Cast { CastId = Guid.Parse("84d3f779-14f1-4c88-b9d7-aaaaaaaaaaaa"), Name = "Bryan Cranston" },
                 new Cast { CastId = Guid.Parse("b3f8c7aa-43c7-43ad-b765-bbbbbbbbbbbb"), Name = "Aaron Paul" },
                 new Cast { CastId = Guid.Parse("96e63e2d-7c65-4d44-984e-cccccccccccc"), Name = "Anna Gunn" },

                 // Inception (Movie)
                 new Cast { CastId = Guid.Parse("38a62e4d-8bca-4ec6-9f27-dddddddddddd"), Name = "Leonardo DiCaprio" },
                 new Cast { CastId = Guid.Parse("a1b2c3d4-5e6f-4a7b-8c9d-eeeeeeeeeeee"), Name = "Joseph Gordon-Levitt" },
                 new Cast { CastId = Guid.Parse("f1e2d3c4-b5a6-4789-9012-ffffffffffff"), Name = "Ellen Page" },

                 // Stranger Things (TV Show)
                 new Cast { CastId = Guid.Parse("12345678-9abc-def0-1234-111111111111"), Name = "Millie Bobby Brown" },
                 new Cast { CastId = Guid.Parse("23456789-abcd-ef01-2345-222222222222"), Name = "Finn Wolfhard" },
                 new Cast { CastId = Guid.Parse("3456789a-bcde-f012-3456-333333333333"), Name = "Winona Ryder" },

                 // Game of Thrones (fantasy drama)
                 new Cast { CastId = Guid.Parse("10000000-0000-0000-0000-000000000001"), Name = "Emilia Clarke" },
                 new Cast { CastId = Guid.Parse("10000000-0000-0000-0000-000000000002"), Name = "Kit Harington" },
                 new Cast { CastId = Guid.Parse("10000000-0000-0000-0000-000000000003"), Name = "Peter Dinklage" },

                 // The Office (TV sitcom)
                 new Cast { CastId = Guid.Parse("20000000-0000-0000-0000-000000000001"), Name = "Steve Carell" },
                 new Cast { CastId = Guid.Parse("20000000-0000-0000-0000-000000000002"), Name = "John Krasinski" },
                 new Cast { CastId = Guid.Parse("20000000-0000-0000-0000-000000000003"), Name = "Jenna Fischer" },

                 // Black Mirror (sci-fi anthology)
                 new Cast { CastId = Guid.Parse("70000000-0000-0000-0000-000000000001"), Name = "Bryce Dallas Howard" },
                 new Cast { CastId = Guid.Parse("70000000-0000-0000-0000-000000000002"), Name = "Jon Hamm" },
                 new Cast { CastId = Guid.Parse("70000000-0000-0000-0000-000000000003"), Name = "Mackenzie Davis" },

                 // The Crown (historical drama)
                 new Cast { CastId = Guid.Parse("80000000-0000-0000-0000-000000000001"), Name = "Claire Foy" },
                 new Cast { CastId = Guid.Parse("80000000-0000-0000-0000-000000000002"), Name = "Matt Smith" },
                 new Cast { CastId = Guid.Parse("80000000-0000-0000-0000-000000000003"), Name = "Olivia Colman" },

                 // Westworld (sci-fi western)
                 new Cast { CastId = Guid.Parse("b0000001-0000-0000-0000-000000000001"), Name = "Evan Rachel Wood" },
                 new Cast { CastId = Guid.Parse("b0000002-0000-0000-0000-000000000002"), Name = "Thandie Newton" },
                 new Cast { CastId = Guid.Parse("b0000003-0000-0000-0000-000000000003"), Name = "Jeffrey Wright" },

                 // Peaky Blinders (crime drama)
                 new Cast { CastId = Guid.Parse("d0000001-0000-0000-0000-000000000001"), Name = "Cillian Murphy" },
                 new Cast { CastId = Guid.Parse("d0000002-0000-0000-0000-000000000002"), Name = "Helen McCrory" },
                 new Cast { CastId = Guid.Parse("d0000003-0000-0000-0000-000000000003"), Name = "Paul Anderson" },

                 // The Mandalorian (sci-fi western)
                 new Cast { CastId = Guid.Parse("e0000001-0000-0000-0000-000000000001"), Name = "Pedro Pascal" },
                 new Cast { CastId = Guid.Parse("e0000002-0000-0000-0000-000000000002"), Name = "Gina Carano" },
                 new Cast { CastId = Guid.Parse("e0000003-0000-0000-0000-000000000003"), Name = "Carl Weathers" },

                 // The Boys (superhero drama)
                 new Cast { CastId = Guid.Parse("a1000001-0000-0000-0000-000000000001"), Name = "Karl Urban" },
                 new Cast { CastId = Guid.Parse("a1000002-0000-0000-0000-000000000002"), Name = "Jack Quaid" },
                 new Cast { CastId = Guid.Parse("a1000003-0000-0000-0000-000000000003"), Name = "Antony Starr" },

                 // WandaVision
                 new Cast { CastId = Guid.Parse("a2000001-0000-0000-0000-000000000001"), Name = "Elizabeth Olsen" },
                 new Cast { CastId = Guid.Parse("a2000002-0000-0000-0000-000000000002"), Name = "Paul Bettany" },
                 new Cast { CastId = Guid.Parse("a2000003-0000-0000-0000-000000000003"), Name = "Kathryn Hahn" },

                 // Succession
                 new Cast { CastId = Guid.Parse("a2000004-0000-0000-0000-000000000004"), Name = "Brian Cox" },
                 new Cast { CastId = Guid.Parse("a2000005-0000-0000-0000-000000000005"), Name = "Jeremy Strong" },
                 new Cast { CastId = Guid.Parse("a2000006-0000-0000-0000-000000000006"), Name = "Sarah Snook" },

                 // Moonlight
                 new Cast { CastId = Guid.Parse("a2000007-0000-0000-0000-000000000007"), Name = "Trevante Rhodes" },
                 new Cast { CastId = Guid.Parse("a2000008-0000-0000-0000-000000000008"), Name = "Mahershala Ali" },
                 new Cast { CastId = Guid.Parse("a2000009-0000-0000-0000-000000000009"), Name = "Naomie Harris" },

                 // Seinfeld
                 new Cast { CastId = Guid.Parse("a2000010-0000-0000-0000-000000000010"), Name = "Jerry Seinfeld" },
                 new Cast { CastId = Guid.Parse("a2000011-0000-0000-0000-000000000011"), Name = "Julia Louis-Dreyfus" },
                 new Cast { CastId = Guid.Parse("a2000012-0000-0000-0000-000000000012"), Name = "Michael Richards" },

                 // Killers of the Flower Moon
                 new Cast { CastId = Guid.Parse("a2000013-0000-0000-0000-000000000013"), Name = "Leonardo DiCaprio" },
                 new Cast { CastId = Guid.Parse("a2000014-0000-0000-0000-000000000014"), Name = "Robert De Niro" },
                 new Cast { CastId = Guid.Parse("a2000015-0000-0000-0000-000000000015"), Name = "Jesse Plemons" },

                 // The Wire
                 new Cast { CastId = Guid.Parse("a2000019-0000-0000-0000-000000000019"), Name = "Dominic West" },
                 new Cast { CastId = Guid.Parse("a2000020-0000-0000-0000-000000000020"), Name = "Idris Elba" },
                 new Cast { CastId = Guid.Parse("a2000021-0000-0000-0000-000000000021"), Name = "Michael K. Williams" },

                 // Mad Max: Fury Road
                 new Cast { CastId = Guid.Parse("a2000022-0000-0000-0000-000000000022"), Name = "Tom Hardy" },
                 new Cast { CastId = Guid.Parse("a2000023-0000-0000-0000-000000000023"), Name = "Charlize Theron" },
                 new Cast { CastId = Guid.Parse("a2000024-0000-0000-0000-000000000024"), Name = "Nicholas Hoult" },

                 // Top Gun: Maverick
                 new Cast { CastId = Guid.Parse("a2000025-0000-0000-0000-000000000025"), Name = "Tom Cruise" },
                 new Cast { CastId = Guid.Parse("a2000026-0000-0000-0000-000000000026"), Name = "Miles Teller" },
                 new Cast { CastId = Guid.Parse("a2000027-0000-0000-0000-000000000027"), Name = "Jennifer Connelly" },

                 // Oppenheimer
                 new Cast { CastId = Guid.Parse("a2000028-0000-0000-0000-000000000028"), Name = "Cillian Murphy" },
                 new Cast { CastId = Guid.Parse("a2000029-0000-0000-0000-000000000029"), Name = "Emily Blunt" },
                 new Cast { CastId = Guid.Parse("a2000030-0000-0000-0000-000000000030"), Name = "Matt Damon" },

                 // Barbie
                 new Cast { CastId = Guid.Parse("a2000040-0000-0000-0000-000000000040"), Name = "Margot Robbie" },
                 new Cast { CastId = Guid.Parse("a2000041-0000-0000-0000-000000000041"), Name = "Ryan Gosling" },
                 new Cast { CastId = Guid.Parse("a2000042-0000-0000-0000-000000000042"), Name = "America Ferrera" },

               // 12 Years a Slave
                 new Cast { CastId = Guid.Parse("f0000001-0000-0000-0000-000000000001"), Name = "Chiwetel Ejiofor" },
                 new Cast { CastId = Guid.Parse("f0000031-0000-0000-0000-000000000031"), Name = "Michael Fassbender" },

                 // Squid Game
                 new Cast { CastId = Guid.Parse("f0000002-0000-0000-0000-000000000002"), Name = "Lee Jung-jae" },
                 new Cast { CastId = Guid.Parse("f0000032-0000-0000-0000-000000000032"), Name = "HoYeon Jung" },

                 // Citizen Kane
                 new Cast { CastId = Guid.Parse("f0000003-0000-0000-0000-000000000003"), Name = "Orson Welles" },
                 new Cast { CastId = Guid.Parse("f0000033-0000-0000-0000-000000000033"), Name = "Joseph Cotten" },

                 // Chernobyl
                 new Cast { CastId = Guid.Parse("f0000004-0000-0000-0000-000000000004"), Name = "Jared Harris" },
                 new Cast { CastId = Guid.Parse("f0000034-0000-0000-0000-000000000034"), Name = "Stellan Skarsgård" },

                 // The Bear
                 new Cast { CastId = Guid.Parse("f0000005-0000-0000-0000-000000000005"), Name = "Jeremy Allen White" },
                 new Cast { CastId = Guid.Parse("f0000035-0000-0000-0000-000000000035"), Name = "Ayo Edebiri" },

                 // Dark
                 new Cast { CastId = Guid.Parse("f0000006-0000-0000-0000-000000000006"), Name = "Louis Hofmann" },
                 new Cast { CastId = Guid.Parse("f0000036-0000-0000-0000-000000000036"), Name = "Lisa Vicari" },

                 // The Last of Us
                 new Cast { CastId = Guid.Parse("f0000007-0000-0000-0000-000000000007"), Name = "Bella Ramsey" },
                 new Cast { CastId = Guid.Parse("f0000037-0000-0000-0000-000000000037"), Name = "Pedro Pascal" },

                 // The Power of the Dog
                 new Cast { CastId = Guid.Parse("f0000008-0000-0000-0000-000000000008"), Name = "Benedict Cumberbatch" },
                 new Cast { CastId = Guid.Parse("f0000038-0000-0000-0000-000000000038"), Name = "Kirsten Dunst" },

                 // The Trial of the Chicago 7
                 new Cast { CastId = Guid.Parse("f0000009-0000-0000-0000-000000000009"), Name = "Sacha Baron Cohen" },
                 new Cast { CastId = Guid.Parse("f0000039-0000-0000-0000-000000000039"), Name = "Eddie Redmayne" },

                 // The Whale
                 new Cast { CastId = Guid.Parse("f0000010-0000-0000-0000-000000000010"), Name = "Brendan Fraser" },
                 new Cast { CastId = Guid.Parse("f0000040-0000-0000-0000-000000000040"), Name = "Sadie Sink" },

                 // Ozark
                 new Cast { CastId = Guid.Parse("f0000011-0000-0000-0000-000000000011"), Name = "Jason Bateman" },
                 new Cast { CastId = Guid.Parse("f0000041-0000-0000-0000-000000000041"), Name = "Laura Linney" },

                 // Wednesday
                 new Cast { CastId = Guid.Parse("f0000012-0000-0000-0000-000000000012"), Name = "Jenna Ortega" },
                 new Cast { CastId = Guid.Parse("f0000042-0000-0000-0000-000000000042"), Name = "Catherine Zeta-Jones" },

                 // Poor Things
                 new Cast { CastId = Guid.Parse("f0000013-0000-0000-0000-000000000013"), Name = "Emma Stone" },
                 new Cast { CastId = Guid.Parse("f0000043-0000-0000-0000-000000000043"), Name = "Mark Ruffalo" },

                 // Soul
                 new Cast { CastId = Guid.Parse("f0000014-0000-0000-0000-000000000014"), Name = "Jamie Foxx" },
                 new Cast { CastId = Guid.Parse("f0000044-0000-0000-0000-000000000044"), Name = "Tina Fey" },

                 // Spider-Man: Across the Spider‑Verse
                 new Cast { CastId = Guid.Parse("f0000015-0000-0000-0000-000000000015"), Name = "Shameik Moore" },
                 new Cast { CastId = Guid.Parse("f0000045-0000-0000-0000-000000000045"), Name = "Hailee Steinfeld" },

                 // The Queen's Gambit
                 new Cast { CastId = Guid.Parse("f0000016-0000-0000-0000-000000000016"), Name = "Anya Taylor-Joy" },
                 new Cast { CastId = Guid.Parse("f0000046-0000-0000-0000-000000000046"), Name = "Thomas Brodie-Sangster" },

                 // House of the Dragon
                 new Cast { CastId = Guid.Parse("f0000017-0000-0000-0000-000000000017"), Name = "Emma D'Arcy" },
                 new Cast { CastId = Guid.Parse("f0000047-0000-0000-0000-000000000047"), Name = "Matt Smith" },

                 // Better Call Saul
                 new Cast { CastId = Guid.Parse("f0000018-0000-0000-0000-000000000018"), Name = "Bob Odenkirk" },
                 new Cast { CastId = Guid.Parse("f0000048-0000-0000-0000-000000000048"), Name = "Rhea Seehorn" },

                 // Nomadland
                 new Cast { CastId = Guid.Parse("f0000019-0000-0000-0000-000000000019"), Name = "Frances McDormand" },
                 new Cast { CastId = Guid.Parse("f0000049-0000-0000-0000-000000000049"), Name = "David Strathairn" },

                 // Casablanca
                 new Cast { CastId = Guid.Parse("f0000020-0000-0000-0000-000000000020"), Name = "Humphrey Bogart" },
                 new Cast { CastId = Guid.Parse("f0000050-0000-0000-0000-000000000050"), Name = "Ingrid Bergman" },

                 // Schindler's List
                 new Cast { CastId = Guid.Parse("f0000021-0000-0000-0000-000000000021"), Name = "Liam Neeson" },
                 new Cast { CastId = Guid.Parse("f0000051-0000-0000-0000-000000000051"), Name = "Ralph Fiennes" },

                 // The Sopranos
                 new Cast { CastId = Guid.Parse("f0000022-0000-0000-0000-000000000022"), Name = "James Gandolfini" },
                 new Cast { CastId = Guid.Parse("f0000052-0000-0000-0000-000000000052"), Name = "Edie Falco" },

                 // Ted Lasso
                 new Cast { CastId = Guid.Parse("f0000023-0000-0000-0000-000000000023"), Name = "Jason Sudeikis" },
                 new Cast { CastId = Guid.Parse("f0000053-0000-0000-0000-000000000053"), Name = "Hannah Waddingham" },

                 // Gladiator
                 new Cast { CastId = Guid.Parse("f0000024-0000-0000-0000-000000000024"), Name = "Russell Crowe" },
                 new Cast { CastId = Guid.Parse("f0000054-0000-0000-0000-000000000054"), Name = "Joaquin Phoenix" },

                 // E.T. the Extra-Terrestrial
                 new Cast { CastId = Guid.Parse("f0000025-0000-0000-0000-000000000025"), Name = "Henry Thomas" },
                 new Cast { CastId = Guid.Parse("f0000055-0000-0000-0000-000000000055"), Name = "Drew Barrymore" },

                 // Dune
                 new Cast { CastId = Guid.Parse("f0000026-0000-0000-0000-000000000026"), Name = "Timothée Chalamet" },
                 new Cast { CastId = Guid.Parse("f0000056-0000-0000-0000-000000000056"), Name = "Zendaya" },

                 // Fargo
                 new Cast { CastId = Guid.Parse("f0000027-0000-0000-0000-000000000027"), Name = "Frances McDormand" },
                 new Cast { CastId = Guid.Parse("f0000057-0000-0000-0000-000000000057"), Name = "William H. Macy" },

                 // Jaws
                 new Cast { CastId = Guid.Parse("f0000028-0000-0000-0000-000000000028"), Name = "Roy Scheider" },
                 new Cast { CastId = Guid.Parse("f0000058-0000-0000-0000-000000000058"), Name = "Richard Dreyfuss" }



            );


            







        }
    }
}