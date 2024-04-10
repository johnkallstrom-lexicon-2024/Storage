using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Storagge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 10, 14, 54, 4, 620, DateTimeKind.Local).AddTicks(7515)),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Count", "Description", "Name", "Price", "Shelf" },
                values: new object[,]
                {
                    { 1, "Entertainment", 10, "A boardgame about fighting invading alien ships!", "Under Falling Skies", 299, "A15" },
                    { 2, "Outdoors", 3, "A sturdy pair of hiking boots.", "Hanwag Hiking Boots", 1099, "B07" },
                    { 3, "Kitchen", 5, "Great coffee machine.", "Moccamaster", 1499, "C19" },
                    { 4, "Plants", 15, "An easy to care for plant that fits most homes!", "Monstera Delicsiosa", 199, "D01" },
                    { 5, "Entertainment", 15, "An awesome videogame!", "Zelda: Breath of the Wild", 699, "A08" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
