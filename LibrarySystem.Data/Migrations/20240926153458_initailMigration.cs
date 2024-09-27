using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibrarySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class initailMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac Asimov" },
                    { 2, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling" },
                    { 3, new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Orwell" },
                    { 4, new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Austen" },
                    { 5, new DateTime(1917, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arthur C. Clarke" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Science Fiction", "Foundation" },
                    { 2, 2, "Fantasy", "Harry Potter and the Philosopher's Stone" },
                    { 3, 3, "Dystopian", "1984" },
                    { 4, 4, "Classic", "Pride and Prejudice" },
                    { 5, 5, "Science Fiction", "Rendezvous with Rama" },
                    { 6, 2, "Fantasy", "Harry Potter and the Chamber of Secrets" },
                    { 7, 3, "Political Satire", "Animal Farm" },
                    { 8, 4, "Classic", "Emma" },
                    { 9, 5, "Science Fiction", "Childhood's End" },
                    { 10, 1, "Science Fiction", "Foundation and Empire" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
