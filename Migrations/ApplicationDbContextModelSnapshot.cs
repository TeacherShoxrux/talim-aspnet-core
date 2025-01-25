﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Talim.Data;

#nullable disable

namespace talim_aspnet_core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Talim.Data.Entity.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<string>("ContentText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ThemeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Views")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Talim.Data.Entity.ContentImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<int>("ContentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("ContentImages");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("EducationTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EducationTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("EducationDirections");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EducationType");
                });

            modelBuilder.Entity("Talim.Data.Entity.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("char(64)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("Talim.Data.Entity.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Talim.Data.Entity.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("EducationDirectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EducationDirectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Talim.Data.Entity.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Talim.Data.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Talim.Data.Entity.Content", b =>
                {
                    b.HasOne("Talim.Data.Entity.Theme", "Theme")
                        .WithMany("Contents")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("Contents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.ContentImage", b =>
                {
                    b.HasOne("Talim.Data.Entity.Content", "Content")
                        .WithMany("ContentImages")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("ContentImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationDirection", b =>
                {
                    b.HasOne("Talim.Data.Entity.EducationType", "EducationType")
                        .WithMany("EducationDirections")
                        .HasForeignKey("EducationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("EducationDirections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationType", b =>
                {
                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("EducationTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.Password", b =>
                {
                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithOne("Password")
                        .HasForeignKey("Talim.Data.Entity.Password", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.Session", b =>
                {
                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithOne("Session")
                        .HasForeignKey("Talim.Data.Entity.Session", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.Subject", b =>
                {
                    b.HasOne("Talim.Data.Entity.EducationDirection", "EducationDirection")
                        .WithMany("Subjects")
                        .HasForeignKey("EducationDirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("Subjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationDirection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.Theme", b =>
                {
                    b.HasOne("Talim.Data.Entity.Subject", "Subject")
                        .WithMany("Themes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talim.Data.Entity.User", "User")
                        .WithMany("Themes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Talim.Data.Entity.Content", b =>
                {
                    b.Navigation("ContentImages");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationDirection", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Talim.Data.Entity.EducationType", b =>
                {
                    b.Navigation("EducationDirections");
                });

            modelBuilder.Entity("Talim.Data.Entity.Subject", b =>
                {
                    b.Navigation("Themes");
                });

            modelBuilder.Entity("Talim.Data.Entity.Theme", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("Talim.Data.Entity.User", b =>
                {
                    b.Navigation("ContentImages");

                    b.Navigation("Contents");

                    b.Navigation("EducationDirections");

                    b.Navigation("EducationTypes");

                    b.Navigation("Password");

                    b.Navigation("Session");

                    b.Navigation("Subjects");

                    b.Navigation("Themes");
                });
#pragma warning restore 612, 618
        }
    }
}
