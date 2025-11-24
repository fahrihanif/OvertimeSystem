using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<long>(type: "bigint", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OvertimePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxDailyHours = table.Column<short>(type: "smallint", nullable: false),
                    MaxWeeklyHours = table.Column<short>(type: "smallint", nullable: false),
                    WeekdayStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WeekendStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WeekendEndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HourOrder = table.Column<short>(type: "smallint", nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    BaseDivisor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otp = table.Column<short>(type: "smallint", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeBudgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitialHours = table.Column<short>(type: "smallint", nullable: false),
                    HoursConsumed = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvertimeBudgets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RequestedHours = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvertimeRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OvertimeRequests_OvertimePolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "OvertimePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedOvertime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalHours = table.Column<short>(type: "smallint", nullable: false),
                    CalculatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedOvertime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovedOvertime_OvertimeRates_RateId",
                        column: x => x.RateId,
                        principalTable: "OvertimeRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovedOvertime_OvertimeRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "OvertimeRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OvertimePolicies",
                columns: new[] { "Id", "IsActive", "MaxDailyHours", "MaxWeeklyHours", "PolicyName", "WeekdayStartTime", "WeekendEndTime", "WeekendStartTime" },
                values: new object[] { new Guid("a0000000-0000-0000-0000-000000000001"), true, (short)4, (short)18, "Standard Labor Law Compliance", new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "OvertimeRates",
                columns: new[] { "Id", "BaseDivisor", "DayType", "HourOrder", "Multiplier", "RateName" },
                values: new object[,]
                {
                    { new Guid("06d0d3b0-9664-4007-b156-cc9e44d3de3a"), 173, "WEEKEND_HOLIDAY", (short)10, 4.0m, "WH Hr 10" },
                    { new Guid("10472b87-d994-4b63-845c-22386efde689"), 173, "WEEKEND_HOLIDAY", (short)9, 3.0m, "WH Hr 9" },
                    { new Guid("114e0833-ac28-49fa-b0af-acdcd6b2bb1f"), 173, "WEEKEND_HOLIDAY", (short)11, 4.0m, "WH Hr 11" },
                    { new Guid("16c6d00d-7410-4b71-b29c-c906a0ee9ace"), 173, "WEEKEND_HOLIDAY", (short)8, 2.0m, "WH Hr 8" },
                    { new Guid("21b52e6b-f31c-4c00-b4e9-8249340f8149"), 173, "WEEKEND_HOLIDAY", (short)3, 2.0m, "WH Hr 3" },
                    { new Guid("43860f9a-9c7c-4dce-95bc-a7da51161e12"), 173, "NORMAL", (short)2, 2.0m, "WD 2nd+ Hr" },
                    { new Guid("623cf23a-0ea4-4912-b42e-446928912b2d"), 173, "WEEKEND_HOLIDAY", (short)7, 2.0m, "WH Hr 7" },
                    { new Guid("76ec3585-044f-4b72-ad4b-d1f51e784314"), 173, "WEEKEND_HOLIDAY", (short)2, 2.0m, "WH Hr 2" },
                    { new Guid("8f5124c6-88dc-4ccd-846a-17667ccf0367"), 173, "WEEKEND_HOLIDAY", (short)12, 4.0m, "WH Hr 12" },
                    { new Guid("a270a553-d92f-43ea-8e8b-d9253625abac"), 173, "WEEKEND_HOLIDAY", (short)6, 2.0m, "WH Hr 6" },
                    { new Guid("abf99de4-240d-4ea0-a044-1296386bde37"), 173, "NORMAL", (short)1, 1.5m, "WD 1st Hr" },
                    { new Guid("abfa5f7e-ce1b-4421-bbf5-828be729cdc1"), 173, "WEEKEND_HOLIDAY", (short)5, 2.0m, "WH Hr 5" },
                    { new Guid("ba5071e3-fbf0-440e-a238-66c0811ac6de"), 173, "WEEKEND_HOLIDAY", (short)4, 2.0m, "WH Hr 4" },
                    { new Guid("bc759a71-b3a7-4549-82d0-ee5ea9f863b9"), 173, "WEEKEND_HOLIDAY", (short)1, 2.0m, "WH Hr 1" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Employee" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Manager" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_AccountId_RoleId",
                table: "AccountRoles",
                columns: new[] { "AccountId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeId",
                table: "Accounts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedOvertime_RateId",
                table: "ApprovedOvertime",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedOvertime_RequestId",
                table: "ApprovedOvertime",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Nik",
                table: "Employees",
                column: "Nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeBudgets_EmployeeId_BudgetMonth",
                table: "OvertimeBudgets",
                columns: new[] { "EmployeeId", "BudgetMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeRequests_EmployeeId",
                table: "OvertimeRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeRequests_PolicyId",
                table: "OvertimeRequests",
                column: "PolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "ApprovedOvertime");

            migrationBuilder.DropTable(
                name: "OvertimeBudgets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "OvertimeRates");

            migrationBuilder.DropTable(
                name: "OvertimeRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OvertimePolicies");
        }
    }
}
