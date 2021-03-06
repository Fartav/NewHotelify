// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Booking.Models;

namespace Booking.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201031120917_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Booking.Models.AvailableDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreateDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeleteDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifyDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReserveDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ReserveDateEndTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReserveDateStart")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ReserveDateStartTicks")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Booking_AvailableDates");
                });

            modelBuilder.Entity("Booking.Models.ClosedDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreateDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeleteDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EndDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifyDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("StartDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Booking_ClosedDate");
                });

            modelBuilder.Entity("Booking.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreateDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeleteDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<int?>("EventHostId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifyDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int>("MultiReserveLimit")
                        .HasColumnType("int");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.Property<int>("TemporaryReserve")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WorkingShifts")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTimes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventHostId");

                    b.ToTable("Booking_Event");
                });

            modelBuilder.Entity("Booking.Models.Host", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreateDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeleteDateTicks")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<string>("LocationLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifyDateTicks")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Booking_Host");
                });

            modelBuilder.Entity("Booking.Models.ReservedDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreateDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeleteDateTicks")
                        .HasColumnType("bigint");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("IsCanceled")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("IsFinal")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifyDateTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReserveDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ReserveDateEndTicks")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReserveDateStart")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ReserveDateStartTicks")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Booking_Reserves");
                });

            modelBuilder.Entity("Booking.Models.AvailableDates", b =>
                {
                    b.HasOne("Booking.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Booking.Models.ClosedDate", b =>
                {
                    b.HasOne("Booking.Models.Event", "Event")
                        .WithMany("EventClosedDates")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Booking.Models.Event", b =>
                {
                    b.HasOne("Booking.Models.Host", "EventHost")
                        .WithMany()
                        .HasForeignKey("EventHostId");
                });

            modelBuilder.Entity("Booking.Models.ReservedDates", b =>
                {
                    b.HasOne("Booking.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
