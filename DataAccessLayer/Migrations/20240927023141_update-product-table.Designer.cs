﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240927023141_update-product-table")]
    partial class updateproducttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccessLayer.Entities.Category", b =>
                {
                    b.Property<Guid?>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BuyingPrice")
                        .HasColumnType("float");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ProductAddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
