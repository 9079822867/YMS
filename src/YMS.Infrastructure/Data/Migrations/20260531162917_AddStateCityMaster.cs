using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStateCityMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "AP", true, "Andhra Pradesh" },
                    { 2, "AR", true, "Arunachal Pradesh" },
                    { 3, "AS", true, "Assam" },
                    { 4, "BR", true, "Bihar" },
                    { 5, "CG", true, "Chhattisgarh" },
                    { 6, "GA", true, "Goa" },
                    { 7, "GJ", true, "Gujarat" },
                    { 8, "HR", true, "Haryana" },
                    { 9, "HP", true, "Himachal Pradesh" },
                    { 10, "JH", true, "Jharkhand" },
                    { 11, "KA", true, "Karnataka" },
                    { 12, "KL", true, "Kerala" },
                    { 13, "MP", true, "Madhya Pradesh" },
                    { 14, "MH", true, "Maharashtra" },
                    { 15, "MN", true, "Manipur" },
                    { 16, "ML", true, "Meghalaya" },
                    { 17, "MZ", true, "Mizoram" },
                    { 18, "NL", true, "Nagaland" },
                    { 19, "OD", true, "Odisha" },
                    { 20, "PB", true, "Punjab" },
                    { 21, "RJ", true, "Rajasthan" },
                    { 22, "SK", true, "Sikkim" },
                    { 23, "TN", true, "Tamil Nadu" },
                    { 24, "TS", true, "Telangana" },
                    { 25, "TR", true, "Tripura" },
                    { 26, "UP", true, "Uttar Pradesh" },
                    { 27, "UK", true, "Uttarakhand" },
                    { 28, "WB", true, "West Bengal" },
                    { 29, "DL", true, "Delhi" },
                    { 30, "JK", true, "Jammu and Kashmir" },
                    { 31, "LA", true, "Ladakh" },
                    { 32, "CH", true, "Chandigarh" },
                    { 33, "PY", true, "Puducherry" },
                    { 34, "AN", true, "Andaman and Nicobar Islands" },
                    { 35, "DN", true, "Dadra and Nagar Haveli and Daman and Diu" },
                    { 36, "LD", true, "Lakshadweep" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 31, 16, 29, 16, 483, DateTimeKind.Utc).AddTicks(8136), "$2a$11$X.lcN/7xlP3o7NGEeS6F1efDAcJCXMc2dUkvWRasR5D3HPAOWIsk6" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 29, 16, 670, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsActive", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, true, "Visakhapatnam", 1 },
                    { 2, true, "Vijayawada", 1 },
                    { 3, true, "Guntur", 1 },
                    { 4, true, "Nellore", 1 },
                    { 5, true, "Tirupati", 1 },
                    { 6, true, "Kakinada", 1 },
                    { 7, true, "Rajahmundry", 1 },
                    { 8, true, "Kurnool", 1 },
                    { 9, true, "Itanagar", 2 },
                    { 10, true, "Naharlagun", 2 },
                    { 11, true, "Pasighat", 2 },
                    { 12, true, "Guwahati", 3 },
                    { 13, true, "Silchar", 3 },
                    { 14, true, "Dibrugarh", 3 },
                    { 15, true, "Jorhat", 3 },
                    { 16, true, "Nagaon", 3 },
                    { 17, true, "Tinsukia", 3 },
                    { 18, true, "Patna", 4 },
                    { 19, true, "Gaya", 4 },
                    { 20, true, "Bhagalpur", 4 },
                    { 21, true, "Muzaffarpur", 4 },
                    { 22, true, "Darbhanga", 4 },
                    { 23, true, "Purnia", 4 },
                    { 24, true, "Raipur", 5 },
                    { 25, true, "Bhilai", 5 },
                    { 26, true, "Bilaspur", 5 },
                    { 27, true, "Korba", 5 },
                    { 28, true, "Durg", 5 },
                    { 29, true, "Raigarh", 5 },
                    { 30, true, "Panaji", 6 },
                    { 31, true, "Margao", 6 },
                    { 32, true, "Vasco da Gama", 6 },
                    { 33, true, "Mapusa", 6 },
                    { 34, true, "Ahmedabad", 7 },
                    { 35, true, "Surat", 7 },
                    { 36, true, "Vadodara", 7 },
                    { 37, true, "Rajkot", 7 },
                    { 38, true, "Bhavnagar", 7 },
                    { 39, true, "Jamnagar", 7 },
                    { 40, true, "Gandhinagar", 7 },
                    { 41, true, "Anand", 7 },
                    { 42, true, "Faridabad", 8 },
                    { 43, true, "Gurugram", 8 },
                    { 44, true, "Panipat", 8 },
                    { 45, true, "Ambala", 8 },
                    { 46, true, "Karnal", 8 },
                    { 47, true, "Hisar", 8 },
                    { 48, true, "Rohtak", 8 },
                    { 49, true, "Sonipat", 8 },
                    { 50, true, "Shimla", 9 },
                    { 51, true, "Solan", 9 },
                    { 52, true, "Dharamshala", 9 },
                    { 53, true, "Mandi", 9 },
                    { 54, true, "Kullu", 9 },
                    { 55, true, "Bilaspur", 9 },
                    { 56, true, "Ranchi", 10 },
                    { 57, true, "Jamshedpur", 10 },
                    { 58, true, "Dhanbad", 10 },
                    { 59, true, "Bokaro", 10 },
                    { 60, true, "Deoghar", 10 },
                    { 61, true, "Hazaribagh", 10 },
                    { 62, true, "Bengaluru", 11 },
                    { 63, true, "Mysuru", 11 },
                    { 64, true, "Hubli", 11 },
                    { 65, true, "Mangaluru", 11 },
                    { 66, true, "Belagavi", 11 },
                    { 67, true, "Kalaburagi", 11 },
                    { 68, true, "Davanagere", 11 },
                    { 69, true, "Ballari", 11 },
                    { 70, true, "Thiruvananthapuram", 12 },
                    { 71, true, "Kochi", 12 },
                    { 72, true, "Kozhikode", 12 },
                    { 73, true, "Thrissur", 12 },
                    { 74, true, "Kollam", 12 },
                    { 75, true, "Kannur", 12 },
                    { 76, true, "Alappuzha", 12 },
                    { 77, true, "Bhopal", 13 },
                    { 78, true, "Indore", 13 },
                    { 79, true, "Jabalpur", 13 },
                    { 80, true, "Gwalior", 13 },
                    { 81, true, "Ujjain", 13 },
                    { 82, true, "Sagar", 13 },
                    { 83, true, "Satna", 13 },
                    { 84, true, "Rewa", 13 },
                    { 85, true, "Mumbai", 14 },
                    { 86, true, "Pune", 14 },
                    { 87, true, "Nagpur", 14 },
                    { 88, true, "Nashik", 14 },
                    { 89, true, "Thane", 14 },
                    { 90, true, "Aurangabad", 14 },
                    { 91, true, "Solapur", 14 },
                    { 92, true, "Kolhapur", 14 },
                    { 93, true, "Amravati", 14 },
                    { 94, true, "Navi Mumbai", 14 },
                    { 95, true, "Imphal", 15 },
                    { 96, true, "Thoubal", 15 },
                    { 97, true, "Bishnupur", 15 },
                    { 98, true, "Shillong", 16 },
                    { 99, true, "Tura", 16 },
                    { 100, true, "Jowai", 16 },
                    { 101, true, "Aizawl", 17 },
                    { 102, true, "Lunglei", 17 },
                    { 103, true, "Champhai", 17 },
                    { 104, true, "Kohima", 18 },
                    { 105, true, "Dimapur", 18 },
                    { 106, true, "Mokokchung", 18 },
                    { 107, true, "Bhubaneswar", 19 },
                    { 108, true, "Cuttack", 19 },
                    { 109, true, "Rourkela", 19 },
                    { 110, true, "Berhampur", 19 },
                    { 111, true, "Sambalpur", 19 },
                    { 112, true, "Puri", 19 },
                    { 113, true, "Ludhiana", 20 },
                    { 114, true, "Amritsar", 20 },
                    { 115, true, "Jalandhar", 20 },
                    { 116, true, "Patiala", 20 },
                    { 117, true, "Bathinda", 20 },
                    { 118, true, "Mohali", 20 },
                    { 119, true, "Hoshiarpur", 20 },
                    { 120, true, "Jaipur", 21 },
                    { 121, true, "Jodhpur", 21 },
                    { 122, true, "Udaipur", 21 },
                    { 123, true, "Kota", 21 },
                    { 124, true, "Ajmer", 21 },
                    { 125, true, "Bikaner", 21 },
                    { 126, true, "Alwar", 21 },
                    { 127, true, "Bhilwara", 21 },
                    { 128, true, "Gangtok", 22 },
                    { 129, true, "Namchi", 22 },
                    { 130, true, "Gyalshing", 22 },
                    { 131, true, "Chennai", 23 },
                    { 132, true, "Coimbatore", 23 },
                    { 133, true, "Madurai", 23 },
                    { 134, true, "Tiruchirappalli", 23 },
                    { 135, true, "Salem", 23 },
                    { 136, true, "Tirunelveli", 23 },
                    { 137, true, "Vellore", 23 },
                    { 138, true, "Erode", 23 },
                    { 139, true, "Hyderabad", 24 },
                    { 140, true, "Warangal", 24 },
                    { 141, true, "Nizamabad", 24 },
                    { 142, true, "Karimnagar", 24 },
                    { 143, true, "Khammam", 24 },
                    { 144, true, "Ramagundam", 24 },
                    { 145, true, "Agartala", 25 },
                    { 146, true, "Udaipur", 25 },
                    { 147, true, "Dharmanagar", 25 },
                    { 148, true, "Lucknow", 26 },
                    { 149, true, "Kanpur", 26 },
                    { 150, true, "Ghaziabad", 26 },
                    { 151, true, "Agra", 26 },
                    { 152, true, "Varanasi", 26 },
                    { 153, true, "Meerut", 26 },
                    { 154, true, "Noida", 26 },
                    { 155, true, "Prayagraj", 26 },
                    { 156, true, "Bareilly", 26 },
                    { 157, true, "Aligarh", 26 },
                    { 158, true, "Dehradun", 27 },
                    { 159, true, "Haridwar", 27 },
                    { 160, true, "Roorkee", 27 },
                    { 161, true, "Haldwani", 27 },
                    { 162, true, "Rishikesh", 27 },
                    { 163, true, "Nainital", 27 },
                    { 164, true, "Kolkata", 28 },
                    { 165, true, "Howrah", 28 },
                    { 166, true, "Durgapur", 28 },
                    { 167, true, "Asansol", 28 },
                    { 168, true, "Siliguri", 28 },
                    { 169, true, "Bardhaman", 28 },
                    { 170, true, "Malda", 28 },
                    { 171, true, "New Delhi", 29 },
                    { 172, true, "Delhi", 29 },
                    { 173, true, "Dwarka", 29 },
                    { 174, true, "Rohini", 29 },
                    { 175, true, "Saket", 29 },
                    { 176, true, "Karol Bagh", 29 },
                    { 177, true, "Srinagar", 30 },
                    { 178, true, "Jammu", 30 },
                    { 179, true, "Anantnag", 30 },
                    { 180, true, "Baramulla", 30 },
                    { 181, true, "Udhampur", 30 },
                    { 182, true, "Leh", 31 },
                    { 183, true, "Kargil", 31 },
                    { 184, true, "Chandigarh", 32 },
                    { 185, true, "Puducherry", 33 },
                    { 186, true, "Karaikal", 33 },
                    { 187, true, "Yanam", 33 },
                    { 188, true, "Port Blair", 34 },
                    { 189, true, "Daman", 35 },
                    { 190, true, "Silvassa", 35 },
                    { 191, true, "Diu", 35 },
                    { 192, true, "Kavaratti", 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId_Name",
                table: "Cities",
                columns: new[] { "StateId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_States_Code",
                table: "States",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 31, 16, 17, 47, 777, DateTimeKind.Utc).AddTicks(6219), "$2a$11$A.8aNhP0MoShZChZ9Ym/vueq/C0JqOY7TRXxrbESk.GDFTgZ4oOD6" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 16, 17, 47, 974, DateTimeKind.Utc).AddTicks(5849));
        }
    }
}
