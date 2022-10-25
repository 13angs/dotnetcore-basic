﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using product_sv.Models;

#nullable disable

namespace MsRabbitmq.ProductSv.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("product_sv.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ProductId");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}