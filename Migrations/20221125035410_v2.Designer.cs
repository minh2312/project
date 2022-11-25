﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eProjectClient.Migrations
{
    [DbContext(typeof(MyDB_Context))]
    [Migration("20221125035410_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Brand", b =>
                {
                    b.Property<Guid>("IdBrand")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_brand");

                    b.Property<string>("BrandName")
                        .HasColumnName("brand_name")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.HasKey("IdBrand");

                    b.ToTable("brand");
                });

            modelBuilder.Entity("Data.DataModel.Account", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userId");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnName("birtday");

                    b.Property<bool>("Decentralization")
                        .HasColumnName("decentralization");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnName("fullName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.Property<int>("Phone")
                        .HasColumnName("phone");

                    b.Property<int>("State")
                        .HasColumnName("state");

                    b.Property<string>("UserName")
                        .HasColumnName("userName")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("Data.DataModel.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("category_id");

                    b.Property<string>("CategoryName")
                        .HasColumnName("category_name")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Data.DataModel.Certify", b =>
                {
                    b.Property<Guid>("IdCertify")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_certify");

                    b.Property<string>("CertifyType")
                        .HasColumnName("certify_type")
                        .HasMaxLength(50);

                    b.Property<string>("ImageCertify")
                        .HasColumnName("image_certify");

                    b.HasKey("IdCertify");

                    b.ToTable("certify");
                });

            modelBuilder.Entity("Data.DataModel.Goldk", b =>
                {
                    b.Property<Guid>("GoldTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("goldtype_id");

                    b.Property<float>("GoldRate")
                        .HasColumnName("gold_rate");

                    b.Property<string>("Gold_Crt")
                        .HasColumnName("gold_crt");

                    b.HasKey("GoldTypeId");

                    b.ToTable("goldk");
                });

            modelBuilder.Entity("Data.DataModel.ItemProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("productId");

                    b.Property<Guid>("BrandId")
                        .HasColumnName("brand_id");

                    b.Property<Guid>("Category_id")
                        .HasColumnName("category_id");

                    b.Property<Guid>("CertifyId")
                        .HasColumnName("certify_id");

                    b.Property<DateTime>("CreartTime")
                        .HasColumnName("time");

                    b.Property<string>("Detail")
                        .HasColumnName("detail");

                    b.Property<Guid>("GoldTypeId")
                        .HasColumnName("goldtype_id");

                    b.Property<float>("Gold_Amt")
                        .HasColumnName("gold_amt");

                    b.Property<float?>("Gold_Making")
                        .HasColumnName("gold_making");

                    b.Property<float>("Gold_Rate")
                        .HasColumnName("gold_rate");

                    b.Property<float>("Gold_WT")
                        .HasColumnName("gold_wt");

                    b.Property<string>("Goldk");

                    b.Property<string>("ImageProduct")
                        .HasColumnName("image_product");

                    b.Property<string>("MRP")
                        .HasColumnName("mrp");

                    b.Property<float>("Net_Gold")
                        .HasColumnName("net_gold");

                    b.Property<float>("Other_Making")
                        .HasColumnName("other_making");

                    b.Property<int>("Pairs")
                        .HasColumnName("pairs");

                    b.Property<int>("ProQuality")
                        .HasColumnName("pro_quality");

                    b.Property<string>("ProductName")
                        .HasColumnName("product_name")
                        .HasMaxLength(150);

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<float>("Sale")
                        .HasColumnName("sale");

                    b.Property<float?>("Stone_Making")
                        .HasColumnName("stone_making");

                    b.Property<float>("Stone_WT")
                        .HasColumnName("stone_wt");

                    b.Property<string>("StyleCode")
                        .HasColumnName("style_code");

                    b.Property<float>("Total_Gross_WT")
                        .HasColumnName("total_gross_wt");

                    b.Property<float>("Total_Making")
                        .HasColumnName("total_making");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("Category_id");

                    b.HasIndex("CertifyId");

                    b.ToTable("item_product");
                });

            modelBuilder.Entity("Data.DataModel.Order", b =>
                {
                    b.Property<Guid>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_order");

                    b.Property<Guid>("Account_Id")
                        .HasColumnName("account_id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnName("booking_date");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnName("cancellation_date");

                    b.Property<string>("Note")
                        .HasColumnName("note");

                    b.Property<int>("Phone")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<float>("Total")
                        .HasColumnName("total");

                    b.HasKey("IdOrder");

                    b.HasIndex("Account_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Data.DataModel.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnName("booking_date");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnName("cancellation_date");

                    b.Property<string>("Image")
                        .HasColumnName("image");

                    b.Property<Guid>("Order_Id")
                        .HasColumnName("order_id");

                    b.Property<string>("ProductName")
                        .HasColumnName("product_name")
                        .HasMaxLength(50);

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.Property<float>("Total")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Data.DataModel.ItemProduct", b =>
                {
                    b.HasOne("Data.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.DataModel.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.DataModel.Certify", "Certify")
                        .WithMany()
                        .HasForeignKey("CertifyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.DataModel.Order", b =>
                {
                    b.HasOne("Data.DataModel.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.DataModel.OrderDetail", b =>
                {
                    b.HasOne("Data.DataModel.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}