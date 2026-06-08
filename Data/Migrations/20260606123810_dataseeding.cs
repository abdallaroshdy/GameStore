using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Data.migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action-Adventure" },
                    { 2, "Action RPG" },
                    { 3, "Sandbox" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GenreId", "Name", "Price", "RelaseDate" },
                values: new object[,]
                {
                    { 1, 1, "The Legend of Zelda: Breath of the Wild", 59.99m, new DateOnly(2017, 3, 3) },
                    { 2, 2, "Elden Ring", 59.99m, new DateOnly(2022, 2, 25) },
                    { 3, 1, "Red Dead Redemption 2", 49.99m, new DateOnly(2018, 10, 26) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Games");
        }
    }
}
