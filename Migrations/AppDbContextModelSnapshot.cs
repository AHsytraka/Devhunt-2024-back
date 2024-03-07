﻿// <auto-generated />
using System;
using Devhunt_2024_back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devhunt_2024_back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Devhunt_2024_back.Models.Admin", b =>
                {
                    b.Property<string>("Matricule")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Matricule");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.AgendaTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TaskEnd")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TaskStart")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("Matricule");

                    b.ToTable("AgendaTasks");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Groupe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matiere")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Parcours")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prof")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Salle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TaskEnd")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TaskStart")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.FileUpload.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagepath")
                        .HasColumnType("TEXT");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ts")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("Devhunt_2024_back.Models.Professor", b =>
                {
                    b.Property<string>("Matricule")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Matricule");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Professors")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
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
                    b.Property<int>("UInterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InterestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UInterestId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Matricule");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterestCategory", b =>
                {
                    b.Property<int>("UCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UCategoryId");

                    b.HasIndex("Matricule");

                    b.ToTable("UserInterestCategories");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.AgendaTask", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Matricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.Interest", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.InterestCategory", "InterestCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterestCategory");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterest", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.InterestCategory", "InterestCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devhunt_2024_back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Matricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterestCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Devhunt_2024_back.Models.UserInterestCategory", b =>
                {
                    b.HasOne("Devhunt_2024_back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Matricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
