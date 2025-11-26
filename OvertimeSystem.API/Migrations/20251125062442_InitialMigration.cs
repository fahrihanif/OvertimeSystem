using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_account",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otp = table.Column<long>(type: "bigint", nullable: true),
                    expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_used = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_account", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_account_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_account_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_approved_overtime",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    request_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rate_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total_hours = table.Column<short>(type: "smallint", nullable: false),
                    calculated_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_approved_overtime", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    joined_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_overtime_budget",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    budget_month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    initial_hours = table.Column<short>(type: "smallint", nullable: false),
                    hours_consumed = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_overtime_budget", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_overtime_policy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    policy_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    max_daily_hours = table.Column<int>(type: "int", nullable: false),
                    max_weekly_hours = table.Column<int>(type: "int", nullable: false),
                    weekday_start_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    weekend_start_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    weekend_end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_overtime_policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_overtime_rate",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rate_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    day_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    hour_order = table.Column<int>(type: "int", nullable: false),
                    multiplier = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    base_divisor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_overtime_rate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_overtime_request",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    policy_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    requested_hours = table.Column<short>(type: "smallint", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    request_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_overtime_request", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_role_account_id_role_id",
                table: "tbl_account_role",
                columns: new[] { "account_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employee_nik",
                table: "tbl_employee",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_overtime_budget_employee_id_budget_month",
                table: "tbl_overtime_budget",
                columns: new[] { "employee_id", "budget_month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_account");

            migrationBuilder.DropTable(
                name: "tbl_account_role");

            migrationBuilder.DropTable(
                name: "tbl_approved_overtime");

            migrationBuilder.DropTable(
                name: "tbl_employee");

            migrationBuilder.DropTable(
                name: "tbl_overtime_budget");

            migrationBuilder.DropTable(
                name: "tbl_overtime_policy");

            migrationBuilder.DropTable(
                name: "tbl_overtime_rate");

            migrationBuilder.DropTable(
                name: "tbl_overtime_request");

            migrationBuilder.DropTable(
                name: "tbl_role");
        }
    }
}
