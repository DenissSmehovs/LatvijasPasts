﻿// <auto-generated />
using System;
using LatvijasPasts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LatvijasPasts.Migrations
{
    [DbContext(typeof(LatvijasPastsContext))]
    partial class LatvijasPastsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LatvijasPasts.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faculty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("LatvijasPasts.Models.PersonalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInfo");
                });

            modelBuilder.Entity("LatvijasPasts.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("LatvijasPasts.Models.Education", b =>
                {
                    b.HasOne("LatvijasPasts.Models.PersonalInfo", null)
                        .WithMany("Educations")
                        .HasForeignKey("PersonalInfoId");
                });

            modelBuilder.Entity("LatvijasPasts.Models.WorkExperience", b =>
                {
                    b.HasOne("LatvijasPasts.Models.PersonalInfo", null)
                        .WithMany("WorkExperiences")
                        .HasForeignKey("PersonalInfoId");
                });

            modelBuilder.Entity("LatvijasPasts.Models.PersonalInfo", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}