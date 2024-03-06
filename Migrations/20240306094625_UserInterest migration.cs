using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class UserInterestmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Parcours = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Facebook = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterestName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "UserInterest",
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
                    table.PrimaryKey("PK_UserInterest", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_UserInterest_InterestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "InterestCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterest_Users_UserMatricule",
                        column: x => x.UserMatricule,
                        principalTable: "Users",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateTable(
                name: "UserInterestCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    UserMatricule = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_UserInterestCategory_Users_UserMatricule",
                        column: x => x.UserMatricule,
                        principalTable: "Users",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_CategoryId",
                table: "Interests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_CategoryId",
                table: "UserInterest",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_UserMatricule",
                table: "UserInterest",
                column: "UserMatricule");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestCategory_UserMatricule",
                table: "UserInterestCategory",
                column: "UserMatricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "UserInterest");

            migrationBuilder.DropTable(
                name: "UserInterestCategory");

            migrationBuilder.DropTable(
                name: "InterestCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
