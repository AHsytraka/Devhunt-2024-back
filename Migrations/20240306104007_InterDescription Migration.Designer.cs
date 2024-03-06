﻿// <auto-generated />
using Devhunt_2024_back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240306104007_InterDescription Migration")]
    partial class InterDescriptionMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Devhunt_2024_back.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("InterestId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.InterestCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("InterestCategories");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.User", b =>
                {
                    b.Property<string>("Matricule")
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Parcours")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Matricule");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserMatricule")
                        .HasColumnType("TEXT");

                    b.HasKey("InterestId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserMatricule");

                    b.ToTable("UserInterest");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterestCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserMatricule")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.HasIndex("UserMatricule");

                    b.ToTable("UserInterestCategory");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.Interest", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.InterestCategory", "InterestCategor")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterestCategor");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterest", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.InterestCategory", "InterestCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devhunt_2024_back.Models.User", null)
                        .WithMany("InterestList")
                        .HasForeignKey("UserMatricule");

                    b.Navigation("InterestCategory");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterestCategory", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.User", null)
                        .WithMany("InterestCategories")
                        .HasForeignKey("UserMatricule");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.User", b =>
                {
                    b.Navigation("InterestCategories");

                    b.Navigation("InterestList");
                });
#pragma warning restore 612, 618
        }
    }
}
