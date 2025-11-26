using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DefaultRateAndPolicyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_overtime_policy",
                columns: new[] { "id", "is_active", "max_daily_hours", "max_weekly_hours", "policy_name", "weekday_start_time", "weekend_end_time", "weekend_start_time" },
                values: new object[] { new Guid("a0000000-0000-0000-0000-000000000001"), true, 4, 18, "Standard", new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "tbl_overtime_rate",
                columns: new[] { "id", "base_divisor", "day_type", "hour_order", "multiplier", "rate_name" },
                values: new object[,]
                {
                    { new Guid("06c93357-eddf-48ee-90c9-448ee1508289"), 173, "WEEKEND_HOLIDAY", 10, 4.0m, "WH Hr 10" },
                    { new Guid("2f4df0c8-b0fc-4262-9021-dcd72370e1e2"), 173, "WEEKEND_HOLIDAY", 2, 2.0m, "WH Hr 2" },
                    { new Guid("3e755ce3-f7a1-44b8-8fb3-dd4e79f32080"), 173, "WEEKEND_HOLIDAY", 1, 2.0m, "WH Hr 1" },
                    { new Guid("42341d1c-6fec-4a2e-b91a-7cba3404a14b"), 173, "WEEKEND_HOLIDAY", 6, 2.0m, "WH Hr 6" },
                    { new Guid("47965aa1-5ab5-46f9-9d0f-2c346fa5e140"), 173, "WEEKEND_HOLIDAY", 8, 2.0m, "WH Hr 8" },
                    { new Guid("520112fd-9460-46ed-b5fb-ae36385e197e"), 173, "WEEKEND_HOLIDAY", 4, 2.0m, "WH Hr 4" },
                    { new Guid("5ef2a883-d36a-4780-af9b-97892fb90409"), 173, "WEEKEND_HOLIDAY", 7, 2.0m, "WH Hr 7" },
                    { new Guid("6d8a23d2-b479-4869-9fa6-608b91d93534"), 173, "WEEKEND_HOLIDAY", 3, 2.0m, "WH Hr 3" },
                    { new Guid("890a8818-d874-42e7-8c6c-3ef341dbe5bd"), 173, "WEEKEND_HOLIDAY", 12, 4.0m, "WH Hr 12" },
                    { new Guid("a2b7ab11-ac75-4697-a1b6-688273e33f45"), 173, "NORMAL", 2, 2.0m, "WD 2nd+ Hr" },
                    { new Guid("a68ab98b-04a1-4328-8bc2-1dee00cef5fc"), 173, "NORMAL", 1, 1.5m, "WD 1st Hr" },
                    { new Guid("c5e12625-cd58-44b6-bc2d-885078dab00e"), 173, "WEEKEND_HOLIDAY", 5, 2.0m, "WH Hr 5" },
                    { new Guid("d34bbe1a-27eb-4ff8-be02-b1a1f2d9383d"), 173, "WEEKEND_HOLIDAY", 11, 4.0m, "WH Hr 11" },
                    { new Guid("dc7faf56-8c64-4786-a9ee-6d5988023c33"), 173, "WEEKEND_HOLIDAY", 9, 3.0m, "WD Hr 9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_overtime_policy",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("06c93357-eddf-48ee-90c9-448ee1508289"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("2f4df0c8-b0fc-4262-9021-dcd72370e1e2"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("3e755ce3-f7a1-44b8-8fb3-dd4e79f32080"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("42341d1c-6fec-4a2e-b91a-7cba3404a14b"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("47965aa1-5ab5-46f9-9d0f-2c346fa5e140"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("520112fd-9460-46ed-b5fb-ae36385e197e"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("5ef2a883-d36a-4780-af9b-97892fb90409"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("6d8a23d2-b479-4869-9fa6-608b91d93534"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("890a8818-d874-42e7-8c6c-3ef341dbe5bd"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("a2b7ab11-ac75-4697-a1b6-688273e33f45"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("a68ab98b-04a1-4328-8bc2-1dee00cef5fc"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("c5e12625-cd58-44b6-bc2d-885078dab00e"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("d34bbe1a-27eb-4ff8-be02-b1a1f2d9383d"));

            migrationBuilder.DeleteData(
                table: "tbl_overtime_rate",
                keyColumn: "id",
                keyValue: new Guid("dc7faf56-8c64-4786-a9ee-6d5988023c33"));
        }
    }
}
