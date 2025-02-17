﻿// <auto-generated />
using System;
using Karen_Store.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Karen_Store.Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20250217083354_CartId")]
    partial class CartId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Karen_Store.Domain.Entities.Carts.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("BrowserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Carts.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.HomePage.HomePageImages", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HomePageImage");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.HomePage.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Displayed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.ProductFeatures", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.ProductImages", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsertDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            InsertDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            InsertDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Customer"
                        },
                        new
                        {
                            Id = 4,
                            InsertDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Support"
                        });
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.UserInRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoleId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRole");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Carts.Cart", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Carts.CartItem", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Carts.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Karen_Store.Domain.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Category", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Products.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.ProductFeatures", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Products.Product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.ProductImages", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Products.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.UserInRole", b =>
                {
                    b.HasOne("Karen_Store.Domain.Entities.Users.Role", "Role")
                        .WithMany("UserInRole")
                        .HasForeignKey("RoleId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Karen_Store.Domain.Entities.Users.User", "User")
                        .WithMany("UserInRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Carts.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("ProductFeatures");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("UserInRole");
                });

            modelBuilder.Entity("Karen_Store.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("UserInRole");
                });
#pragma warning restore 612, 618
        }
    }
}
