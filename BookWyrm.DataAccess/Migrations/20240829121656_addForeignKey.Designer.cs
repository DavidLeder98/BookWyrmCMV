﻿// <auto-generated />
using BookWyrm.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookWyrm.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240829121656_addForeignKey")]
    partial class addForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookWyrm.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Combat"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Spellcasting"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Bestiary"
                        });
                });

            modelBuilder.Entity("BookWyrm.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Gandalor Toadbottom",
                            CategoryId = 2,
                            Description = "Learn the fundamentals of cantrips with this beginner-friendly guide. Perfect for aspiring wizards looking to master simple spells and impress friends at parties. No prior experience needed!",
                            ISBN = "987-0-420-70457-0",
                            Price = 240.0,
                            Title = "Cantrips for Beginners"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Gawb Lynnhunter",
                            CategoryId = 1,
                            Description = "A straightforward manual on goblin slaying for those new to adventuring. Packed with practical tips, tricks, and safety advice to keep you alive and victorious in the heat of battle.",
                            ISBN = "987-0-911-80085-0",
                            Price = 29.0,
                            Title = "Goblin Slaying for Dummies"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Rudolf the Armless",
                            CategoryId = 3,
                            Description = "An essential safety manual for aspiring dragon tamers, written by a seasoned expert. Discover the dos and don'ts of dealing with dragons while avoiding the common pitfalls that might cost you an arm and a leg.",
                            ISBN = "987-0-777-11701-0",
                            Price = 69.0,
                            Title = "A Dragon Tamer's Safety Guide"
                        });
                });

            modelBuilder.Entity("BookWyrm.Models.ProductModel", b =>
                {
                    b.HasOne("BookWyrm.Models.CategoryModel", "Category")
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
