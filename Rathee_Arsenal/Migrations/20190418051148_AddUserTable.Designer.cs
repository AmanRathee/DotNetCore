﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rathee_Arsenal.Data;

namespace Rathee_Arsenal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190418051148_AddUserTable")]
    partial class AddUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("OrderPlacedAt");

                    b.Property<decimal>("OrderTotal");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("WeaponId");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("WeaponId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number");

                    b.Property<Guid>("ShoppingCartId");

                    b.Property<int?>("WeaponId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("WeaponId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.User", b =>
                {
                    b.Property<Guid>("UserUid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserUid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rathee_Arsenal.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rathee_Arsenal.Model.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("InStock");

                    b.Property<bool>("IsTrending");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("WeaponId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.OrderDetail", b =>
                {
                    b.HasOne("Rathee_Arsenal.Data.Model.Order", "Order")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rathee_Arsenal.Model.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rathee_Arsenal.Data.Model.ShoppingCartItem", b =>
                {
                    b.HasOne("Rathee_Arsenal.Model.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("Rathee_Arsenal.Model.Weapon", b =>
                {
                    b.HasOne("Rathee_Arsenal.Model.Category", "Category")
                        .WithMany("Weapons")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
