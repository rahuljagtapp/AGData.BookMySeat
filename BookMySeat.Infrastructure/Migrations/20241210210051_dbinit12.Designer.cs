﻿// <auto-generated />
using System;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AGData.BookMySeat.Infrastructure.Migrations
{
    [DbContext(typeof(SeatBookingDbcontext))]
    [Migration("20241210210051_dbinit12")]
    partial class dbinit12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.BookingRecord", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ResourceId");

                    b.ToTable("BookingRecords");
                });

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourceCategorey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ResourceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.Visitor", b =>
                {
                    b.Property<Guid>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HostEmployee")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("HostEmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VisitorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitorId");

                    b.HasIndex("HostEmployeeId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.BookingRecord", b =>
                {
                    b.HasOne("AGData.BookMySeat.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AGData.BookMySeat.Domain.Entities.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGData.BookMySeat.Domain.Entities.Visitor", b =>
                {
                    b.HasOne("AGData.BookMySeat.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("HostEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
