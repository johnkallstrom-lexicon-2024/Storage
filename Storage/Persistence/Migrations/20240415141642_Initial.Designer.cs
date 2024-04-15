﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storagge.Persistence;

#nullable disable

namespace Storagge.Persistence.Migrations
{
    [DbContext(typeof(StorageDbContext))]
    [Migration("20240415141642_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Storagge.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("int")
                        .HasColumnName("Category");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 4, 15, 16, 16, 42, 235, DateTimeKind.Local).AddTicks(6202))
                        .HasColumnName("OrderDate");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Shelf");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 0,
                            Count = 10,
                            Description = "A boardgame about fighting invading alien ships!",
                            Name = "Under Falling Skies",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 299,
                            Shelf = "A15"
                        },
                        new
                        {
                            Id = 2,
                            Category = 3,
                            Count = 3,
                            Description = "A sturdy pair of hiking boots.",
                            Name = "Hanwag Hiking Boots",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1099,
                            Shelf = "B07"
                        },
                        new
                        {
                            Id = 3,
                            Category = 1,
                            Count = 5,
                            Description = "Great coffee machine.",
                            Name = "Moccamaster",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1499,
                            Shelf = "C19"
                        },
                        new
                        {
                            Id = 4,
                            Category = 2,
                            Count = 15,
                            Description = "An easy to care for plant that fits most homes!",
                            Name = "Monstera Delicsiosa",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 199,
                            Shelf = "D01"
                        },
                        new
                        {
                            Id = 5,
                            Category = 0,
                            Count = 15,
                            Description = "An awesome videogame!",
                            Name = "Zelda: Breath of the Wild",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 699,
                            Shelf = "A08"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
