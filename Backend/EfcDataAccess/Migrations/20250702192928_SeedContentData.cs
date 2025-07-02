using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedContentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "Description", "ImageURL", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("0b29d317-6dff-4bb9-bd69-1f3587af7819"), "A great movie.", "http://example.com/sample.jpg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Movie", "Movie" },
                    { new Guid("1235599f-50e7-4cc7-b9f6-292d1159e70f"), "A great TV Show.", "http://example.com/sample2.jpg", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample TV Show", "TVShow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("0b29d317-6dff-4bb9-bd69-1f3587af7819"));

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: new Guid("1235599f-50e7-4cc7-b9f6-292d1159e70f"));
        }
    }
}
