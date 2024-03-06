using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class FileMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "UserInterest",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Interests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterestName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Imagepath = table.Column<string>(type: "TEXT", nullable: true),
                    Ts = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "UserInterest");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Interests");
        }
    }
}
