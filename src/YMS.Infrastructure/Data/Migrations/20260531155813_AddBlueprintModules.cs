using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBlueprintModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Yards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Yards",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Yards",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservePrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    HighestBid = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoldAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuationAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValuationAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    ReportPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    FromYardId = table.Column<int>(type: "int", nullable: false),
                    ToYardId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispatchedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Yards_FromYardId",
                        column: x => x.FromYardId,
                        principalTable: "Yards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Yards_ToYardId",
                        column: x => x.ToYardId,
                        principalTable: "Yards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3188));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3459));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3464));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 31, 15, 58, 11, 900, DateTimeKind.Utc).AddTicks(2789), "$2a$11$P3.NwLROphncCMu9/QYyxuHN4yApCSkO.nT8kRt3AStyW8fS/PB0y" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { 0, new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2985), null, null });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { 0, new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2991), null, null });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { 0, new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2994), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_VehicleId",
                table: "Auctions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_VehicleId",
                table: "Inspections",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VehicleId_DocumentType",
                table: "VehicleDocuments",
                columns: new[] { "VehicleId", "DocumentType" });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_FromYardId",
                table: "VehicleTransfers",
                column: "FromYardId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_Status",
                table: "VehicleTransfers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_ToYardId",
                table: "VehicleTransfers",
                column: "ToYardId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_VehicleId",
                table: "VehicleTransfers",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "VehicleDocuments");

            migrationBuilder.DropTable(
                name: "VehicleTransfers");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Yards");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Yards");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Yards");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 31, 15, 45, 26, 265, DateTimeKind.Utc).AddTicks(8242), "$2a$11$Df7rMDSIdNr5f2j.ehaHHOnVpTtxkq1mmZ.4ukya68E/rHIEV8xYS" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 45, 26, 535, DateTimeKind.Utc).AddTicks(2450));
        }
    }
}
