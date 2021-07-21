﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToysAndGames.Data;

namespace ToysAndGames.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToysAndGames.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRestriction = 4,
                            Company = "Mattel",
                            Description = "Amazing friend",
                            Name = "Woody",
                            Price = 255m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            AgeRestriction = 10,
                            Company = "Mattel",
                            Description = "Added to your collection",
                            Name = "Venom",
                            Price = 314m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            AgeRestriction = 5,
                            Company = "Mattel",
                            Description = "The best dinosaurus",
                            Name = "Blue",
                            Price = 180m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            AgeRestriction = 12,
                            Company = "Mattel",
                            Description = "I am IronMan",
                            Name = "IronMan",
                            Price = 333m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            AgeRestriction = 3,
                            Company = "Mattel",
                            Description = "Take away from my way",
                            Name = "Jam",
                            Price = 120m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            AgeRestriction = 8,
                            Company = "Mattel",
                            Description = "Your friendly neighbor",
                            Name = "SpiderMan",
                            Price = 452m,
                            ProductTypeId = 1
                        });
                });

            modelBuilder.Entity("ToysAndGames.Data.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Toy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Game"
                        });
                });

            modelBuilder.Entity("ToysAndGames.Data.Product", b =>
                {
                    b.HasOne("ToysAndGames.Data.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });
#pragma warning restore 612, 618
        }
    }
}
