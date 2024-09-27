using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicatioYearPorperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "PublicationYear",
                table: "Books",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublicationYear",
                value: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");
        }
    }
}
