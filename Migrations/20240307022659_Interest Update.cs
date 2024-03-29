﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    /// <inheritdoc />
    public partial class InterestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Matricule);
                });

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
                    Groupe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

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

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Titre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Professors = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
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
                    InterestDescription = table.Column<string>(type: "TEXT", nullable: false),
                    WebSite = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "AgendaTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    TaskDate = table.Column<string>(type: "TEXT", nullable: false),
                    TaskStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    TaskEnd = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_AgendaTasks_Users_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Users",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestCategories",
                columns: table => new
                {
                    UCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestCategories", x => x.UCategoryId);
                    table.ForeignKey(
                        name: "FK_UserInterestCategories_Users_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Users",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UInterestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterestName = table.Column<string>(type: "TEXT", nullable: false),
                    InterestDescription = table.Column<string>(type: "TEXT", nullable: false),
                    WebSite = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.UInterestId);
                    table.ForeignKey(
                        name: "FK_UserInterests_InterestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "InterestCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Users",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaTasks_Matricule",
                table: "AgendaTasks",
                column: "Matricule");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_CategoryId",
                table: "Interests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestCategories_Matricule",
                table: "UserInterestCategories",
                column: "Matricule");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_CategoryId",
                table: "UserInterests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_Matricule",
                table: "UserInterests",
                column: "Matricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AgendaTasks");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "UserInterestCategories");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "InterestCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
