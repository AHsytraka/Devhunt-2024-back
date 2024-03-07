using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class CourseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Groupe",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Matiere",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Parcours",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Prof",
                table: "AgendaTasks");

            migrationBuilder.DropColumn(
                name: "Salle",
                table: "AgendaTasks");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    TaskDate = table.Column<string>(type: "TEXT", nullable: false),
                    TaskStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    TaskEnd = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Matiere = table.Column<string>(type: "TEXT", nullable: false),
                    Prof = table.Column<string>(type: "TEXT", nullable: false),
                    Parcours = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false),
                    Salle = table.Column<string>(type: "TEXT", nullable: false),
                    Groupe = table.Column<string>(type: "TEXT", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Users_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Users",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Matricule",
                table: "Courses",
                column: "Matricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Groupe",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matiere",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parcours",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prof",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salle",
                table: "AgendaTasks",
                type: "TEXT",
                nullable: true);
        }
    }
}
