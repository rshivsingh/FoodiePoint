﻿// <auto-generated />
using System;
using EmptyDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmptyDemo.Migrations
{
    [DbContext(typeof(FoodiePointDBContext))]
    [Migration("20210909072631_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmptyDemo.Models.CategoryList", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Dessert"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Ice Cream"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Pizza"
                        });
                });

            modelBuilder.Entity("EmptyDemo.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("categoryListCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("categoryListCategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CategoryId = 1,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Apple Pie",
                            Price = 200
                        },
                        new
                        {
                            ItemId = 2,
                            CategoryId = 1,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Almond Malai Kulfi",
                            Price = 150
                        },
                        new
                        {
                            ItemId = 3,
                            CategoryId = 1,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Lemon Tart",
                            Price = 200
                        },
                        new
                        {
                            ItemId = 4,
                            CategoryId = 3,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Neapolitan Pizza",
                            Price = 200
                        },
                        new
                        {
                            ItemId = 5,
                            CategoryId = 3,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Sicilian Pizza",
                            Price = 150
                        },
                        new
                        {
                            ItemId = 6,
                            CategoryId = 3,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Detroit Pizza",
                            Price = 200
                        },
                        new
                        {
                            ItemId = 7,
                            CategoryId = 2,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Ben & Jerry's Chocolate Brownie Fudge",
                            Price = 200
                        },
                        new
                        {
                            ItemId = 8,
                            CategoryId = 2,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Häagen-Dazs Vanilla",
                            Price = 150
                        },
                        new
                        {
                            ItemId = 9,
                            CategoryId = 2,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                            ItemName = "Dove Mint Chocolate Chip Ice Cream",
                            Price = 200
                        });
                });

            modelBuilder.Entity("EmptyDemo.Models.Item", b =>
                {
                    b.HasOne("EmptyDemo.Models.CategoryList", "categoryList")
                        .WithMany("CategoryItems")
                        .HasForeignKey("categoryListCategoryId");

                    b.Navigation("categoryList");
                });

            modelBuilder.Entity("EmptyDemo.Models.CategoryList", b =>
                {
                    b.Navigation("CategoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}
