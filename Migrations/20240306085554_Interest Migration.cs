using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class InterestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parcour",
                table: "Users",
                newName: "Parcours");

            migrationBuilder.CreateTable(
                name: "InterestCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterestName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserMatricule = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_InterestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "InterestCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interests_Users_UserMatricule",
                        column: x => x.UserMatricule,
                        principalTable: "Users",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_CategoryId",
                table: "Interests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserMatricule",
                table: "Interests",
                column: "UserMatricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "InterestCategories");

            migrationBuilder.RenameColumn(
                name: "Parcours",
                table: "Users",
                newName: "Parcour");
        }
    }
}
