﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using perdidog.Data;

#nullable disable

namespace perdidog.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250108053334_Updated id")]
    partial class Updatedid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("perdidog.Models.Domain.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dog"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Snake"
                        });
                });

            modelBuilder.Entity("perdidog.Models.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("perdidog.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("perdidog.Models.Domain.LostPet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("GenderId");

                    b.ToTable("LostPet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeId = 2,
                            GenderId = 1,
                            IsActive = true,
                            Name = "Cabezon",
                            ReportDate = new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2783)
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeId = 1,
                            GenderId = 2,
                            IsActive = true,
                            Name = "Cabezona",
                            ReportDate = new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2842)
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeId = 1,
                            GenderId = 1,
                            IsActive = true,
                            Name = "Lucky",
                            ReportDate = new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2846)
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeId = 2,
                            GenderId = 1,
                            IsActive = true,
                            Name = "",
                            ReportDate = new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2848)
                        });
                });

            modelBuilder.Entity("perdidog.Models.Domain.LostPet", b =>
                {
                    b.HasOne("perdidog.Models.Domain.AnimalType", "AnimalType")
                        .WithMany()
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("perdidog.Models.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalType");

                    b.Navigation("Gender");
                });
#pragma warning restore 612, 618
        }
    }
}
