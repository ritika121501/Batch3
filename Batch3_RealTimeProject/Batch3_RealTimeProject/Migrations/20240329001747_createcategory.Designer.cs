﻿// <auto-generated />
using Batch3_RealTimeProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Batch3_RealTimeProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240329001747_createcategory")]
    partial class createcategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Batch3_RealTimeProject.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "this is an action related book",
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "this is an SciFi related book",
                            CategoryName = "SciFi"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "this is an History related book",
                            CategoryName = "History"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
