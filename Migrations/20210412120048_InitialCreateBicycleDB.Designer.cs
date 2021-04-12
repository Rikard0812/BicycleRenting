﻿// <auto-generated />
using System;
using BicycleRenting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BicycleRenting.Migrations
{
    [DbContext(typeof(BicycleDbContext))]
    [Migration("20210412120048_InitialCreateBicycleDB")]
    partial class InitialCreateBicycleDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BicycleRenting.Models.Bicycle", b =>
                {
                    b.Property<Guid>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandBicycleBrand")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("BicycleId");

                    b.HasIndex("BrandBicycleBrand");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("BicycleRenting.Models.Brand", b =>
                {
                    b.Property<string>("BicycleBrand")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BicycleBrand");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("BicycleRenting.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BicycleRenting.Models.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BicycleReservation", b =>
                {
                    b.Property<Guid>("BicyclesBicycleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationsReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BicyclesBicycleId", "ReservationsReservationId");

                    b.HasIndex("ReservationsReservationId");

                    b.ToTable("BicycleReservation");
                });

            modelBuilder.Entity("BicycleRenting.Models.Bicycle", b =>
                {
                    b.HasOne("BicycleRenting.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandBicycleBrand");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("BicycleRenting.Models.Reservation", b =>
                {
                    b.HasOne("BicycleRenting.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BicycleReservation", b =>
                {
                    b.HasOne("BicycleRenting.Models.Bicycle", null)
                        .WithMany()
                        .HasForeignKey("BicyclesBicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BicycleRenting.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BicycleRenting.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
