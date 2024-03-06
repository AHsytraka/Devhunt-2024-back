using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class InterDescriptionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterestDescription",
                table: "UserInterest",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestDescription",
                table: "Interests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestDescription",
                table: "UserInterest");

            migrationBuilder.DropColumn(
                name: "InterestDescription",
                table: "Interests");
        }
    }
}
