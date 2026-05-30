using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterItems", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.InsertData(
                table: "MasterItems",
                columns: new[] { "Id", "Category", "CreatedAt", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(984), true, false, "Andhra Pradesh", 0, null },
                    { 2, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(992), true, false, "Arunachal Pradesh", 1, null },
                    { 3, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(997), true, false, "Assam", 2, null },
                    { 4, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1001), true, false, "Bihar", 3, null },
                    { 5, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1004), true, false, "Chhattisgarh", 4, null },
                    { 6, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1017), true, false, "Goa", 5, null },
                    { 7, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1021), true, false, "Gujarat", 6, null },
                    { 8, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1023), true, false, "Haryana", 7, null },
                    { 9, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1027), true, false, "Himachal Pradesh", 8, null },
                    { 10, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1031), true, false, "Jharkhand", 9, null },
                    { 11, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1035), true, false, "Karnataka", 10, null },
                    { 12, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1037), true, false, "Kerala", 11, null },
                    { 13, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1040), true, false, "Madhya Pradesh", 12, null },
                    { 14, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1042), true, false, "Maharashtra", 13, null },
                    { 15, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1045), true, false, "Manipur", 14, null },
                    { 16, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1048), true, false, "Meghalaya", 15, null },
                    { 17, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1051), true, false, "Mizoram", 16, null },
                    { 18, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1055), true, false, "Nagaland", 17, null },
                    { 19, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1058), true, false, "Odisha", 18, null },
                    { 20, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1061), true, false, "Punjab", 19, null },
                    { 21, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1064), true, false, "Rajasthan", 20, null },
                    { 22, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1067), true, false, "Sikkim", 21, null },
                    { 23, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1069), true, false, "Tamil Nadu", 22, null },
                    { 24, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1082), true, false, "Telangana", 23, null },
                    { 25, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1085), true, false, "Tripura", 24, null },
                    { 26, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1088), true, false, "Uttar Pradesh", 25, null },
                    { 27, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1091), true, false, "Uttarakhand", 26, null },
                    { 28, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1094), true, false, "West Bengal", 27, null },
                    { 29, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1097), true, false, "Delhi", 28, null },
                    { 30, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1120), true, false, "Jammu and Kashmir", 29, null },
                    { 31, "State", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1124), true, false, "Ladakh", 30, null },
                    { 32, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1150), true, false, "Car", 0, null },
                    { 33, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1154), true, false, "Bike", 1, null },
                    { 34, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1158), true, false, "Truck", 2, null },
                    { 35, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1161), true, false, "Bus", 3, null },
                    { 36, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1164), true, false, "Auto", 4, null },
                    { 37, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1167), true, false, "Van", 5, null },
                    { 38, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1169), true, false, "Tractor", 6, null },
                    { 39, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1172), true, false, "SUV", 7, null },
                    { 40, "VehicleType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1175), true, false, "Other", 8, null },
                    { 41, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1186), true, false, "Running", 0, null },
                    { 42, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1189), true, false, "Red/Idle", 1, null },
                    { 43, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1192), true, false, "Auctioned", 2, null },
                    { 44, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1195), true, false, "Released", 3, null },
                    { 45, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1198), true, false, "Sold", 4, null },
                    { 46, "RunningStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1201), true, false, "Scrap", 5, null },
                    { 47, "KeyStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1210), true, false, "Yes", 0, null },
                    { 48, "KeyStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1213), true, false, "No", 1, null },
                    { 49, "KeyStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1217), true, false, "Duplicate Key", 2, null },
                    { 50, "KeyStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1220), true, false, "Missing", 3, null },
                    { 51, "RcStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1229), true, false, "Submitted", 0, null },
                    { 52, "RcStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1232), true, false, "Pending", 1, null },
                    { 53, "RcStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1235), true, false, "Not Available", 2, null },
                    { 54, "RcStatus", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1239), true, false, "Duplicate", 3, null },
                    { 55, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1247), true, false, "Petrol", 0, null },
                    { 56, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1250), true, false, "Diesel", 1, null },
                    { 57, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1253), true, false, "CNG", 2, null },
                    { 58, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1256), true, false, "Electric", 3, null },
                    { 59, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1368), true, false, "Hybrid", 4, null },
                    { 60, "FuelType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1372), true, false, "LPG", 5, null },
                    { 61, "TransmissionType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1381), true, false, "Manual", 0, null },
                    { 62, "TransmissionType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1385), true, false, "Automatic", 1, null },
                    { 63, "TransmissionType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1388), true, false, "CVT", 2, null },
                    { 64, "TransmissionType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1392), true, false, "AMT", 3, null },
                    { 65, "TransmissionType", new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1395), true, false, "DCT", 4, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 9, 5, 31, 937, DateTimeKind.Utc).AddTicks(7200), "$2a$11$zvEquDJvS.IqjMqq8H4p5uwJ/uXrPQW50l6YJWt9XcxXqKDvcY5lm" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(898));

            migrationBuilder.CreateIndex(
                name: "IX_MasterItems_Category_Name",
                table: "MasterItems",
                columns: new[] { "Category", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterItems");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 27, 8, 39, 29, 390, DateTimeKind.Utc).AddTicks(7262), "$2a$11$kKf4d5pknfKYKw6oB0Q2K.usXeub0W7aeJYV/2ly9W0U6iEXKgUSW" });

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9078));
        }
    }
}
