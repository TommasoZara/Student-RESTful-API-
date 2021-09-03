﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210903213421_Inheritance")]
    partial class Inheritance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("API.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfTest")
                        .HasColumnType("TEXT");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Exam");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfTest = new DateTime(2021, 9, 10, 8, 20, 0, 0, DateTimeKind.Unspecified),
                            DurationMinutes = 60,
                            Topic = "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI"
                        });
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("API.Entities.Instructor", b =>
                {
                    b.HasBaseType("API.Entities.User");

                    b.Property<string>("Course")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.ToTable("Instructor");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1969, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "InstructorName",
                            LastName = "InstructorLastName",
                            Nationality = "ITA",
                            Password = "A8CE55AB5C4CAFCF959B534FF5BB8DCF",
                            Username = "Prof1",
                            Course = "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI",
                            HireDate = new DateTime(1999, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("API.Entities.Student", b =>
                {
                    b.HasBaseType("API.Entities.User");

                    b.Property<string>("College")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasGraduated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentCode")
                        .HasColumnType("INTEGER");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1999, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tommaso",
                            LastName = "Zarantonello",
                            Nationality = "ITA",
                            Password = "F8C2475361C649AF0F3BF7C2E2AA5160",
                            Username = "Tom",
                            College = "Unimi",
                            HasGraduated = false,
                            StudentCode = 12345
                        });
                });

            modelBuilder.Entity("API.Entities.Exam", b =>
                {
                    b.HasOne("API.Entities.Instructor", null)
                        .WithMany("Exams")
                        .HasForeignKey("InstructorId");

                    b.HasOne("API.Entities.Student", null)
                        .WithMany("Exams")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("API.Entities.Instructor", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("API.Entities.Instructor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Student", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("API.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Instructor", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("API.Entities.Student", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
