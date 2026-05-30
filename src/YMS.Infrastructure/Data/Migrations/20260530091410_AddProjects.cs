using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AssignedUserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ProjectId",
                table: "Vehicles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AssignedUserId",
                table: "Projects",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Projects_ProjectId",
                table: "Vehicles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Projects_ProjectId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ProjectId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Vehicles");

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

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "MasterItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 9, 5, 32, 204, DateTimeKind.Utc).AddTicks(1395));

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
        }
    }
}
