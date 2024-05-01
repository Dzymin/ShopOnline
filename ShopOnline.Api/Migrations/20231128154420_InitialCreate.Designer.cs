﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopOnline.Api.Data;

#nullable disable

namespace ShopOnline.Api.Migrations
{
    [DbContext(typeof(ShopOnlineDbContext))]
    [Migration("20231128154420_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopOnline.Api.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("cart");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer")
                        .HasColumnName("cart_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("cart_item");
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                            ImageUrl = "/Images/Beauty/Beauty1.png",
                            Name = "Glossier - Beauty Kit",
                            Price = 100m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A kit provided by Curology, containing skin care products",
                            ImageUrl = "/Images/Beauty/Beauty2.png",
                            Name = "Curology - Skin Care Kit",
                            Price = 50m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "A kit provided by Curology, containing skin care products",
                            ImageUrl = "/Images/Beauty/Beauty3.png",
                            Name = "Cocooil - Organic Coconut Oil",
                            Price = 20m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                            ImageUrl = "/Images/Beauty/Beauty4.png",
                            Name = "Schwarzkopf - Hair Care and Skin Care Kit",
                            Price = 50m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Skin Care Kit, containing skin care and hair care products",
                            ImageUrl = "/Images/Beauty/Beauty5.png",
                            Name = "Skin Care Kit",
                            Price = 30m,
                            Quantity = 85
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Air Pods - in-ear wireless headphones",
                            ImageUrl = "/Images/Electronic/Electronics1.png",
                            Name = "Air Pods",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "On-ear Golden Headphones - these headphones are not wireless",
                            ImageUrl = "/Images/Electronic/Electronics2.png",
                            Name = "On-ear Golden Headphones",
                            Price = 40m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "On-ear Black Headphones - these headphones are not wireless",
                            ImageUrl = "/Images/Electronic/Electronics3.png",
                            Name = "On-ear Black Headphones",
                            Price = 40m,
                            Quantity = 300
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                            ImageUrl = "/Images/Electronic/Electronic4.png",
                            Name = "Sennheiser Digital Camera with Tripod",
                            Price = 600m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "Canon Digital Camera - High quality digital camera provided by Canon",
                            ImageUrl = "/Images/Electronic/Electronic5.png",
                            Name = "Canon Digital Camera",
                            Price = 500m,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Gameboy - Provided by Nintendo",
                            ImageUrl = "/Images/Electronic/technology6.png",
                            Name = "Nintendo Gameboy",
                            Price = 100m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            Description = "Very comfortable black leather office chair",
                            ImageUrl = "/Images/Furniture/Furniture1.png",
                            Name = "Black Leather Office Chair",
                            Price = 50m,
                            Quantity = 212
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            Description = "Very comfortable pink leather office chair",
                            ImageUrl = "/Images/Furniture/Furniture2.png",
                            Name = "Pink Leather Office Chair",
                            Price = 50m,
                            Quantity = 112
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Very comfortable lounge chair",
                            ImageUrl = "/Images/Furniture/Furniture3.png",
                            Name = "Lounge Chair",
                            Price = 70m,
                            Quantity = 90
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            Description = "Very comfortable Silver lounge chair",
                            ImageUrl = "/Images/Furniture/Furniture4.png",
                            Name = "Silver Lounge Chair",
                            Price = 120m,
                            Quantity = 95
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            Description = "White and blue Porcelain Table Lamp",
                            ImageUrl = "/Images/Furniture/Furniture6.png",
                            Name = "Porcelain Table Lamp",
                            Price = 15m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 2,
                            Description = "Office Table Lamp",
                            ImageUrl = "/Images/Furniture/Furniture7.png",
                            Name = "Office Table Lamp",
                            Price = 20m,
                            Quantity = 73
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "Comfortable Puma Sneakers in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes1.png",
                            Name = "Puma Sneakers",
                            Price = 100m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Description = "Colorful trainsers - available in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes2.png",
                            Name = "Colorful Trainers",
                            Price = 150m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Blue Nike Trainers - available in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes3.png",
                            Name = "Blue Nike Trainers",
                            Price = 200m,
                            Quantity = 70
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            Description = "Colorful Hummel Trainers - available in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes4.png",
                            Name = "Colorful Hummel Trainers",
                            Price = 120m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            Description = "Red Nike Trainers - available in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes5.png",
                            Name = "Red Nike Trainers",
                            Price = 200m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 4,
                            Description = "Birkenstock Sandles - available in most sizes",
                            ImageUrl = "/Images/Shoes/Shoes6.png",
                            Name = "Birkenstock Sandles",
                            Price = 50m,
                            Quantity = 150
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("product_category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Beauty"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Furniture"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shoes"
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Username = "Bob"
                        },
                        new
                        {
                            Id = 2,
                            Username = "Sarah"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
