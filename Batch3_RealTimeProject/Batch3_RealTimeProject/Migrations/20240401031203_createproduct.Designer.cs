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
    [Migration("20240401031203_createproduct")]
    partial class createproduct
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
                            CategoryDescription = "This is an Action related Book",
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "This is a SciFi related Book",
                            CategoryName = "SciFi"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "This is a History related Book",
                            CategoryName = "History"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryDescription = "This is a Biography related Book",
                            CategoryName = "Biography"
                        });
                });

            modelBuilder.Entity("Batch3_RealTimeProject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Author = "George Takei",
                            CategoryId = 1,
                            Description = "This is an Action related Book",
                            ISBN = "UPC9781603094504",
                            NumberOfPages = 100,
                            Price = 19.989999999999998,
                            Title = "They Called Us Enemy"
                        },
                        new
                        {
                            Id = 102,
                            Author = "H.G. Wells",
                            CategoryId = 2,
                            Description = "This is an SciFi related Book",
                            ISBN = "UPC9781558534209",
                            NumberOfPages = 350,
                            Price = 49.990000000000002,
                            Title = "The War of the Worlds"
                        },
                        new
                        {
                            Id = 103,
                            Author = "Oscar W. Cotton",
                            CategoryId = 3,
                            Description = "This is an History related Book",
                            ISBN = "UPC75398521478",
                            NumberOfPages = 150,
                            Price = 28.0,
                            Title = "The Good Old Days"
                        },
                        new
                        {
                            Id = 104,
                            Author = "Arthur Max",
                            CategoryId = 4,
                            Description = "This is an Biography related Book",
                            ISBN = "UPC2453698741",
                            NumberOfPages = 300,
                            Price = 150.0,
                            Title = "Churchill The Life"
                        });
                });

            modelBuilder.Entity("Batch3_RealTimeProject.Models.Product", b =>
                {
                    b.HasOne("Batch3_RealTimeProject.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
