using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleExitRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleExitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    ExitReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverIdProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtpAttempts = table.Column<int>(type: "int", nullable: false),
                    OtpVerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GatePassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleExitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleExitRequests_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleExitRequests_Status",
                table: "VehicleExitRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleExitRequests_VehicleId",
                table: "VehicleExitRequests",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleExitRequests");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 9, 14, 9, 300, DateTimeKind.Utc).AddTicks(6828), "$2a$11$tY4Cn815bxyEPYx1/XCEJukCFRj1u2oRxT0h8SdSkCtomK3.58GEm" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 14, 9, 499, DateTimeKind.Utc).AddTicks(6777));
        }
    }
}
