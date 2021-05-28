using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Booking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking_Host",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    CreateDateTicks = table.Column<long>(nullable: true),
                    ModifyDateTicks = table.Column<long>(nullable: true),
                    DeleteDateTicks = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    LocationLink = table.Column<string>(nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Host", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    CreateDateTicks = table.Column<long>(nullable: true),
                    ModifyDateTicks = table.Column<long>(nullable: true),
                    DeleteDateTicks = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    EventHostId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    WorkingShifts = table.Column<int>(nullable: false),
                    WorkingTimes = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    MultiReserveLimit = table.Column<int>(nullable: false),
                    TemporaryReserve = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Event_Booking_Host_EventHostId",
                        column: x => x.EventHostId,
                        principalTable: "Booking_Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_AvailableDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    CreateDateTicks = table.Column<long>(nullable: true),
                    ModifyDateTicks = table.Column<long>(nullable: true),
                    DeleteDateTicks = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    ReserveDateStart = table.Column<DateTime>(nullable: false),
                    ReserveDateEnd = table.Column<DateTime>(nullable: false),
                    ReserveDateStartTicks = table.Column<long>(nullable: true),
                    ReserveDateEndTicks = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_AvailableDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_AvailableDates_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_ClosedDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    CreateDateTicks = table.Column<long>(nullable: true),
                    ModifyDateTicks = table.Column<long>(nullable: true),
                    DeleteDateTicks = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDateTicks = table.Column<long>(nullable: true),
                    EndDateTicks = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_ClosedDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_ClosedDate_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    CreateDateTicks = table.Column<long>(nullable: true),
                    ModifyDateTicks = table.Column<long>(nullable: true),
                    DeleteDateTicks = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ReserveDateStart = table.Column<DateTime>(nullable: false),
                    ReserveDateEnd = table.Column<DateTime>(nullable: false),
                    ReserveDateStartTicks = table.Column<long>(nullable: true),
                    ReserveDateEndTicks = table.Column<long>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    IsCanceled = table.Column<int>(nullable: false),
                    IsFinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Reserves_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AvailableDates_EventId",
                table: "Booking_AvailableDates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClosedDate_EventId",
                table: "Booking_ClosedDate",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Event_EventHostId",
                table: "Booking_Event",
                column: "EventHostId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Reserves_EventId",
                table: "Booking_Reserves",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_AvailableDates");

            migrationBuilder.DropTable(
                name: "Booking_ClosedDate");

            migrationBuilder.DropTable(
                name: "Booking_Reserves");

            migrationBuilder.DropTable(
                name: "Booking_Event");

            migrationBuilder.DropTable(
                name: "Booking_Host");
        }
    }
}
