using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class UserInterestForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterestCategories_Users_UserId",
                table: "UserInterestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserInterests",
                newName: "Matricule");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                newName: "IX_UserInterests_Matricule");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserInterestCategories",
                newName: "Matricule");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterestCategories_UserId",
                table: "UserInterestCategories",
                newName: "IX_UserInterestCategories_Matricule");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterestCategories_Users_Matricule",
                table: "UserInterestCategories",
                column: "Matricule",
                principalTable: "Users",
                principalColumn: "Matricule",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Users_Matricule",
                table: "UserInterests",
                column: "Matricule",
                principalTable: "Users",
                principalColumn: "Matricule",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterestCategories_Users_Matricule",
                table: "UserInterestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Users_Matricule",
                table: "UserInterests");

            migrationBuilder.RenameColumn(
                name: "Matricule",
                table: "UserInterests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterests_Matricule",
                table: "UserInterests",
                newName: "IX_UserInterests_UserId");

            migrationBuilder.RenameColumn(
                name: "Matricule",
                table: "UserInterestCategories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterestCategories_Matricule",
                table: "UserInterestCategories",
                newName: "IX_UserInterestCategories_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterestCategories_Users_UserId",
                table: "UserInterestCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Matricule",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Matricule",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
