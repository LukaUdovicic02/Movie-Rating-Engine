using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoreContentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("0b29d317-6dff-4bb9-bd69-1f3587af7819"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("1235599f-50e7-4cc7-b9f6-292d1159e70f"));

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "Description", "ImageURL", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("03cf1925-4bd4-4d08-ab57-988c7c1b862d"), "A survival adventure across the Arctic Circle.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image7.jpeg", new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Broken Compass", "Movie" },
                    { new Guid("06a7d48f-1ff0-4f13-a44b-b8091f582a5f"), "A culinary travelogue that mixes food and mystery.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image22.jpeg", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midnight Recipe", "TVShow" },
                    { new Guid("0b5af27e-8324-4f79-801e-0e93168e5d89"), "Mysterious disappearances on an isolated island.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image32.jpeg", new DateTime(2015, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sea of Silence", "TVShow" },
                    { new Guid("0cdc6b8a-2c18-435f-9f55-409e3f669d15"), "A war epic involving machines and mankind.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image12.jpeg", new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steel Giants", "Movie" },
                    { new Guid("16fc9521-cd19-40c9-8e06-c9f22ea3f278"), "A sci-fi drama exploring survival and identity.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image3.jpeg", new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last Horizon", "Movie" },
                    { new Guid("235cc7ac-2090-485e-8572-f59229a9432e"), "An investigative drama with deep secrets.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image18.jpeg", new DateTime(2017, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Under the Surface", "TVShow" },
                    { new Guid("4b417fb9-81e1-40cb-9ea8-ca59b654a822"), "A story of journalists uncovering corruption.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image30.jpeg", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beacon Hill", "TVShow" },
                    { new Guid("4cbf596b-087a-4012-b7f2-fe7528ef6547"), "A cyberpunk action film set in a glowing megacity.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image8.jpeg", new DateTime(2020, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neon Depths", "Movie" },
                    { new Guid("60644f90-4158-4cf8-8860-053fbdffd01e"), "A time-travel drama with family stakes.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image28.jpeg", new DateTime(2018, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Watchmaker", "TVShow" },
                    { new Guid("63b74640-2a18-4983-848e-baaf7f8719d5"), "An emotional drama tied to a pianist’s legacy.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image11.jpeg", new DateTime(2016, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Firelight Sonata", "Movie" },
                    { new Guid("66c85e8b-f354-40dd-ba43-28586a479dcc"), "A detective story with noir aesthetics.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image6.jpeg", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Velvet Crimes", "Movie" },
                    { new Guid("72b560c2-f902-4758-9135-7ef3361f231e"), "A romantic drama through time and memory.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image9.jpeg", new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letters to a Ghost", "Movie" },
                    { new Guid("7d486175-3d98-4708-a8d0-1a89ce784c6b"), "Neighbors trapped in parallel timelines.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image31.jpeg", new DateTime(2016, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parallel Doors", "TVShow" },
                    { new Guid("7decd574-5d0e-4509-8c30-54394a6f3b02"), "A mystery thriller unraveling secrets in a remote village.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image5.jpeg", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silent River", "Movie" },
                    { new Guid("9555d890-4763-4011-b243-4e046054d13b"), "Urban lives intertwined through a rooftop café.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image19.jpeg", new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skyline Stories", "TVShow" },
                    { new Guid("9820f95d-0a55-4aca-af98-613c1ef41a94"), "A scientist’s journey through alternate realities.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image10.jpeg", new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Echoes of Tomorrow", "Movie" },
                    { new Guid("b4744445-2677-4aba-a374-b2a1ab0d951e"), "Stories told by street performers in Tokyo.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image25.jpeg", new DateTime(2016, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lanterns", "TVShow" },
                    { new Guid("b8f64ba1-1046-4d9b-a01f-dc4c20740ddc"), "A musical drama following a band’s rise to fame.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image15.jpeg", new DateTime(2017, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Melody", "Movie" },
                    { new Guid("be66d9a7-4639-4851-8242-e1c9a4ec08f6"), "A historical drama in a pre-war aristocratic town.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image21.jpeg", new DateTime(2018, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halcyon Row", "TVShow" },
                    { new Guid("c30363b0-5301-4478-be53-dc117b5f0e0b"), "A docu-drama about dream studies and cases.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image29.jpeg", new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dreampoint", "TVShow" },
                    { new Guid("d00ce609-801d-4f5a-8053-af7da2f0d369"), "An artistic exploration of urban loneliness.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image27.jpeg", new DateTime(2019, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fractured Light", "TVShow" },
                    { new Guid("d2ed710d-9a3d-423f-b6fc-579d886a5336"), "A poetic indie film exploring childhood and loss.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image13.jpeg", new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Painted Skies", "Movie" },
                    { new Guid("d6b06619-41f6-49f8-af5e-bc64ff383ff5"), "A drama about childhood dreams and family.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image17.jpeg", new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paper Moons", "Movie" },
                    { new Guid("d8027469-1172-4792-aa38-ac245a68da81"), "A magician’s journey across dimensions.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image20.jpeg", new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dust & Mirrors", "TVShow" },
                    { new Guid("d88f6066-33b2-4563-90aa-da7962444ab9"), "Police procedural with futuristic gadgets.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image26.jpeg", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Redline Division", "TVShow" },
                    { new Guid("e77c2d86-0bea-41ca-93bb-db9cbfe8d014"), "An espionage thriller set during a solar event.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image4.jpeg", new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crimson Eclipse", "Movie" },
                    { new Guid("f44f4cb1-530a-4beb-abaa-8ac57caba443"), "A fantasy about a man who protects forgotten worlds.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image14.jpeg", new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Archivist", "Movie" },
                    { new Guid("f5449e66-3971-44ea-ba81-f422915956e9"), "Anthology series exploring alternate outcomes.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image24.jpeg", new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Echo Street", "TVShow" },
                    { new Guid("f9cc4f63-6893-48ae-bfb2-c9aefd5076c6"), "A dark thriller in a seemingly peaceful suburb.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image16.jpeg", new DateTime(2018, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shadow Over Town", "Movie" },
                    { new Guid("fe6e9d59-7fe4-4048-836d-af8503e2c443"), "A sci-fi thriller about communication from beyond.", "https://mreimagestorage.blob.core.windows.net/imagecontainer/movie-image23.jpeg", new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cold Signal", "TVShow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("03cf1925-4bd4-4d08-ab57-988c7c1b862d"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("06a7d48f-1ff0-4f13-a44b-b8091f582a5f"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("0b5af27e-8324-4f79-801e-0e93168e5d89"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("0cdc6b8a-2c18-435f-9f55-409e3f669d15"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("16fc9521-cd19-40c9-8e06-c9f22ea3f278"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("235cc7ac-2090-485e-8572-f59229a9432e"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("4b417fb9-81e1-40cb-9ea8-ca59b654a822"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("4cbf596b-087a-4012-b7f2-fe7528ef6547"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("60644f90-4158-4cf8-8860-053fbdffd01e"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("63b74640-2a18-4983-848e-baaf7f8719d5"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("66c85e8b-f354-40dd-ba43-28586a479dcc"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("72b560c2-f902-4758-9135-7ef3361f231e"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("7d486175-3d98-4708-a8d0-1a89ce784c6b"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("7decd574-5d0e-4509-8c30-54394a6f3b02"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("9555d890-4763-4011-b243-4e046054d13b"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("9820f95d-0a55-4aca-af98-613c1ef41a94"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("b4744445-2677-4aba-a374-b2a1ab0d951e"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("b8f64ba1-1046-4d9b-a01f-dc4c20740ddc"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("be66d9a7-4639-4851-8242-e1c9a4ec08f6"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("c30363b0-5301-4478-be53-dc117b5f0e0b"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("d00ce609-801d-4f5a-8053-af7da2f0d369"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("d2ed710d-9a3d-423f-b6fc-579d886a5336"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("d6b06619-41f6-49f8-af5e-bc64ff383ff5"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("d8027469-1172-4792-aa38-ac245a68da81"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("d88f6066-33b2-4563-90aa-da7962444ab9"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("e77c2d86-0bea-41ca-93bb-db9cbfe8d014"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("f44f4cb1-530a-4beb-abaa-8ac57caba443"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("f5449e66-3971-44ea-ba81-f422915956e9"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("f9cc4f63-6893-48ae-bfb2-c9aefd5076c6"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("fe6e9d59-7fe4-4048-836d-af8503e2c443"));

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "Description", "ImageURL", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("0b29d317-6dff-4bb9-bd69-1f3587af7819"), "A great movie.", "http://example.com/sample.jpg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Movie", "Movie" },
                    { new Guid("1235599f-50e7-4cc7-b9f6-292d1159e70f"), "A great TV Show.", "http://example.com/sample2.jpg", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample TV Show", "TVShow" }
                });
        }
    }
}
