using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    YardId = table.Column<int>(type: "int", nullable: false),
                    LoanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepoDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturingYear = table.Column<int>(type: "int", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RunningStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RcStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyreCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdometerReading = table.Column<int>(type: "int", nullable: true),
                    InsuranceAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ParkingCharges = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TowingCharges = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MiscCharges = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Yards_YardId",
                        column: x => x.YardId,
                        principalTable: "Yards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ReportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ContactPerson", "CreatedAt", "Email", "IsActive", "IsDeleted", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "HDFC Manager", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8963), "hdfc@yms.com", true, false, "HDFC Bank", "9000000001", null },
                    { 2, "ICICI Manager", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8980), "icici@yms.com", true, false, "ICICI Bank", "9000000002", null },
                    { 3, "Axis Manager", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(8983), "axis@yms.com", true, false, "Axis Bank", "9000000003", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "IsDeleted", "LastLogin", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2026, 5, 27, 8, 39, 29, 390, DateTimeKind.Utc).AddTicks(7262), "admin@yms.com", "Admin User", true, false, null, "$2a$11$kKf4d5pknfKYKw6oB0Q2K.usXeub0W7aeJYV/2ly9W0U6iEXKgUSW", "Admin", null });

            migrationBuilder.InsertData(
                table: "Yards",
                columns: new[] { "Id", "Address", "City", "ContactNumber", "CreatedAt", "IsActive", "IsDeleted", "ManagerName", "Name", "State", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Andheri West", "Mumbai", "9111111111", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9070), true, false, "Ravi Kumar", "Mumbai Yard", "Maharashtra", null },
                    { 2, "Kharadi", "Pune", "9222222222", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9075), true, false, "Suresh Patil", "Pune Yard", "Maharashtra", null },
                    { 3, "Malviya Nagar", "Jaipur", "9333333333", new DateTime(2026, 5, 27, 8, 39, 29, 632, DateTimeKind.Utc).AddTicks(9078), true, false, "Ramesh Sharma", "Jaipur Yard", "Rajasthan", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_VehicleId",
                table: "Reports",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_YardId",
                table: "Vehicles",
                column: "YardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Yards");
        }
    }
}
