using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class ExtendedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_ClosedDate");

            migrationBuilder.CreateTable(
                name: "Booking_ClosedDates",
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
                    table.PrimaryKey("PK_Booking_ClosedDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_ClosedDates_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_EntityType",
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
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Event_Extension",
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
                    Price = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Event_Extension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Event_Extension_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Host_Extention",
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
                    Adress = table.Column<string>(nullable: true),
                    HostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Host_Extention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Host_Extention_Booking_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Booking_Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiMedia_Type",
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
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiMedia_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidenceType",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Entities",
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
                    EntityName = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    EntityTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Entities_Booking_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Booking_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Entities_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Booking_Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiMedia",
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
                    Path = table.Column<string>(nullable: true),
                    MultiMediaTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiMedia_MultiMedia_Type_MultiMediaTypeId",
                        column: x => x.MultiMediaTypeId,
                        principalTable: "MultiMedia_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiMedia_Usage",
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
                    TableId = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    MultiMediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiMedia_Usage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiMedia_Usage_MultiMedia_MultiMediaId",
                        column: x => x.MultiMediaId,
                        principalTable: "MultiMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residence",
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
                    Name = table.Column<string>(nullable: true),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MultiMediaId = table.Column<int>(nullable: true),
                    ResidenceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residence_MultiMedia_MultiMediaId",
                        column: x => x.MultiMediaId,
                        principalTable: "MultiMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Residence_ResidenceType_ResidenceTypeId",
                        column: x => x.ResidenceTypeId,
                        principalTable: "ResidenceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residence_Room",
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
                    Name = table.Column<string>(nullable: true),
                    ResidenceId = table.Column<int>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    HasDinner = table.Column<bool>(nullable: false),
                    HasBreakfast = table.Column<bool>(nullable: false),
                    HasLunch = table.Column<bool>(nullable: false),
                    MultiMediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residence_Room_MultiMedia_MultiMediaId",
                        column: x => x.MultiMediaId,
                        principalTable: "MultiMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Residence_Room_Residence_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClosedDates_EventId",
                table: "Booking_ClosedDates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Entities_EntityTypeId",
                table: "Booking_Entities",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Entities_EventId",
                table: "Booking_Entities",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Event_Extension_EventId",
                table: "Booking_Event_Extension",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Host_Extention_HostId",
                table: "Booking_Host_Extention",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiMedia_MultiMediaTypeId",
                table: "MultiMedia",
                column: "MultiMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiMedia_Usage_MultiMediaId",
                table: "MultiMedia_Usage",
                column: "MultiMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_MultiMediaId",
                table: "Residence",
                column: "MultiMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_ResidenceTypeId",
                table: "Residence",
                column: "ResidenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_Room_MultiMediaId",
                table: "Residence_Room",
                column: "MultiMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_Room_ResidenceId",
                table: "Residence_Room",
                column: "ResidenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_ClosedDates");

            migrationBuilder.DropTable(
                name: "Booking_Entities");

            migrationBuilder.DropTable(
                name: "Booking_Event_Extension");

            migrationBuilder.DropTable(
                name: "Booking_Host_Extention");

            migrationBuilder.DropTable(
                name: "MultiMedia_Usage");

            migrationBuilder.DropTable(
                name: "Residence_Room");

            migrationBuilder.DropTable(
                name: "Booking_EntityType");

            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DropTable(
                name: "MultiMedia");

            migrationBuilder.DropTable(
                name: "ResidenceType");

            migrationBuilder.DropTable(
                name: "MultiMedia_Type");

            migrationBuilder.CreateTable(
                name: "Booking_ClosedDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClosedDate_EventId",
                table: "Booking_ClosedDate",
                column: "EventId");
        }
    }
}
