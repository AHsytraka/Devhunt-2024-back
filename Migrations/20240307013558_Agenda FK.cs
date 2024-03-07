using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class AgendaFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_Matricule",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Matricule",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Matricule",
                table: "Courses",
                column: "Matricule");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_Matricule",
                table: "Courses",
                column: "Matricule",
                principalTable: "Users",
                principalColumn: "Matricule",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
