﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uber2.Persistence;

namespace Uber2.Migrations
{
    [DbContext(typeof(UberDBContext))]
    partial class UberDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Uber2.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isLogged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("secondname")
                        .HasColumnType("TEXT");

                    b.Property<string>("sex")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Uber2.Models.Driver", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFree")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isLogged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("numberPlate")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("secondname")
                        .HasColumnType("TEXT");

                    b.Property<string>("sex")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Uber2.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("clat")
                        .HasColumnType("REAL");

                    b.Property<double>("clng")
                        .HasColumnType("REAL");

                    b.Property<string>("customer")
                        .HasColumnType("TEXT");

                    b.Property<double>("dlat")
                        .HasColumnType("REAL");

                    b.Property<double>("dlng")
                        .HasColumnType("REAL");

                    b.Property<string>("driver")
                        .HasColumnType("TEXT");

                    b.Property<string>("status")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
