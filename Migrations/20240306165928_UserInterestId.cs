using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class UserInterestId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterestCategories",
                table: "UserInterestCategories");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "UserInterests",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "UInterestId",
                table: "UserInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "UserInterestCategories",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "UCategoryId",
                table: "UserInterestCategories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                column: "UInterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterestCategories",
                table: "UserInterestCategories",
                column: "UCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterestCategories",
                table: "UserInterestCategories");

            migrationBuilder.DropColumn(
                name: "UInterestId",
                table: "UserInterests");

            migrationBuilder.DropColumn(
                name: "UCategoryId",
                table: "UserInterestCategories");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "UserInterests",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "UserInterestCategories",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterestCategories",
                table: "UserInterestCategories",
                column: "CategoryId");
        }
    }
}
