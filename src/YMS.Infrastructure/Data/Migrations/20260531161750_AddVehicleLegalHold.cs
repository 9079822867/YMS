using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleLegalHold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLegalHold",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLegalHold",
                table: "Vehicles");

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
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Yards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 31, 15, 58, 12, 96, DateTimeKind.Utc).AddTicks(2994));
        }
    }
}
