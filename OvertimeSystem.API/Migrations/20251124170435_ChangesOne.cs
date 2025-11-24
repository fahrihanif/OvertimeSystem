using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("04917669-77e9-430b-89b2-16a138b3519f"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("10472b50-de7d-487e-b6d4-be5ea6752cb1"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("1127520a-537b-4cd6-93ce-fd1245e63033"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("56ddad2f-b3ee-44bc-a0aa-48e730413f30"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("5beaf7fb-9bb5-4f9c-813e-9c4f918e2425"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("6bf5e03b-6d8c-41a3-a0f9-34f06420c88a"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("9c3384e9-026c-4a54-93c3-c0015e892454"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("b5ccc7c4-f13d-46a5-8e9a-b0aa0925f9af"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("c2eccbb3-28fe-4701-bc37-289a94f57a19"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("cd0a40c2-8b8e-433c-a2e0-5cc4500c5df4"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("d0eb547d-a3b9-4ea2-924e-ab43452ccca3"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("de6afdc4-dc8c-49cf-9083-455926a38986"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("e9f49810-6c8f-44a2-ac94-4dac1fe16565"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("f4b2af86-ac6c-4fda-be04-a997e692aa96"));

            migrationBuilder.InsertData(
                table: "OvertimeRates",
                columns: new[] { "Id", "BaseDivisor", "DayType", "HourOrder", "Multiplier", "RateName" },
                values: new object[,]
                {
                    { new Guid("01e1e8bb-d295-47e8-9bcf-4901194ab389"), 173, "WEEKEND_HOLIDAY", (short)12, 4.0m, "WH Hr 12" },
                    { new Guid("1e6de3d8-4397-4bd9-a634-ea23705f0346"), 173, "WEEKEND_HOLIDAY", (short)4, 2.0m, "WH Hr 4" },
                    { new Guid("241770ff-7e65-4421-a89a-447c1cfb825c"), 173, "WEEKEND_HOLIDAY", (short)7, 2.0m, "WH Hr 7" },
                    { new Guid("327e8bfa-d4c5-414d-b87d-efa1be51d788"), 173, "WEEKEND_HOLIDAY", (short)8, 2.0m, "WH Hr 8" },
                    { new Guid("729428f5-e145-4c94-8197-cd826c141b19"), 173, "NORMAL", (short)2, 2.0m, "WD 2nd+ Hr" },
                    { new Guid("8009ba9a-9546-45d9-b70d-ee518b6f1935"), 173, "WEEKEND_HOLIDAY", (short)11, 4.0m, "WH Hr 11" },
                    { new Guid("88c79f2f-5f46-49e8-b129-e0b2bac2f51c"), 173, "WEEKEND_HOLIDAY", (short)2, 2.0m, "WH Hr 2" },
                    { new Guid("a1b0ab22-346a-4999-b281-c7967c4e2a0a"), 173, "WEEKEND_HOLIDAY", (short)5, 2.0m, "WH Hr 5" },
                    { new Guid("b4a2eb51-fc02-4693-ae92-91c1e213a9e9"), 173, "WEEKEND_HOLIDAY", (short)6, 2.0m, "WH Hr 6" },
                    { new Guid("b8d5cec1-1322-4778-9f86-f82d58b9b94d"), 173, "WEEKEND_HOLIDAY", (short)9, 3.0m, "WH Hr 9" },
                    { new Guid("cc4b5dc1-4897-4e63-8b90-42226d99e665"), 173, "WEEKEND_HOLIDAY", (short)1, 2.0m, "WH Hr 1" },
                    { new Guid("eea400e3-05fc-4953-a03b-dea2e5ae6c9d"), 173, "NORMAL", (short)1, 1.5m, "WD 1st Hr" },
                    { new Guid("f2e301bd-7dc6-4ad2-84a7-77d98ce327bd"), 173, "WEEKEND_HOLIDAY", (short)10, 4.0m, "WH Hr 10" },
                    { new Guid("fcb1ee97-dda1-49f1-a2be-ac62379ebc62"), 173, "WEEKEND_HOLIDAY", (short)3, 2.0m, "WH Hr 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("01e1e8bb-d295-47e8-9bcf-4901194ab389"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("1e6de3d8-4397-4bd9-a634-ea23705f0346"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("241770ff-7e65-4421-a89a-447c1cfb825c"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("327e8bfa-d4c5-414d-b87d-efa1be51d788"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("729428f5-e145-4c94-8197-cd826c141b19"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("8009ba9a-9546-45d9-b70d-ee518b6f1935"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("88c79f2f-5f46-49e8-b129-e0b2bac2f51c"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("a1b0ab22-346a-4999-b281-c7967c4e2a0a"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("b4a2eb51-fc02-4693-ae92-91c1e213a9e9"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("b8d5cec1-1322-4778-9f86-f82d58b9b94d"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("cc4b5dc1-4897-4e63-8b90-42226d99e665"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("eea400e3-05fc-4953-a03b-dea2e5ae6c9d"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("f2e301bd-7dc6-4ad2-84a7-77d98ce327bd"));

            migrationBuilder.DeleteData(
                table: "OvertimeRates",
                keyColumn: "Id",
                keyValue: new Guid("fcb1ee97-dda1-49f1-a2be-ac62379ebc62"));

            migrationBuilder.InsertData(
                table: "OvertimeRates",
                columns: new[] { "Id", "BaseDivisor", "DayType", "HourOrder", "Multiplier", "RateName" },
                values: new object[,]
                {
                    { new Guid("04917669-77e9-430b-89b2-16a138b3519f"), 173, "WEEKEND_HOLIDAY", (short)1, 2.0m, "WH Hr 1" },
                    { new Guid("10472b50-de7d-487e-b6d4-be5ea6752cb1"), 173, "WEEKEND_HOLIDAY", (short)8, 2.0m, "WH Hr 8" },
                    { new Guid("1127520a-537b-4cd6-93ce-fd1245e63033"), 173, "WEEKEND_HOLIDAY", (short)2, 2.0m, "WH Hr 2" },
                    { new Guid("56ddad2f-b3ee-44bc-a0aa-48e730413f30"), 173, "WEEKEND_HOLIDAY", (short)5, 2.0m, "WH Hr 5" },
                    { new Guid("5beaf7fb-9bb5-4f9c-813e-9c4f918e2425"), 173, "WEEKEND_HOLIDAY", (short)9, 3.0m, "WH Hr 9" },
                    { new Guid("6bf5e03b-6d8c-41a3-a0f9-34f06420c88a"), 173, "NORMAL", (short)1, 1.5m, "WD 1st Hr" },
                    { new Guid("9c3384e9-026c-4a54-93c3-c0015e892454"), 173, "WEEKEND_HOLIDAY", (short)10, 4.0m, "WH Hr 10" },
                    { new Guid("b5ccc7c4-f13d-46a5-8e9a-b0aa0925f9af"), 173, "WEEKEND_HOLIDAY", (short)11, 4.0m, "WH Hr 11" },
                    { new Guid("c2eccbb3-28fe-4701-bc37-289a94f57a19"), 173, "WEEKEND_HOLIDAY", (short)6, 2.0m, "WH Hr 6" },
                    { new Guid("cd0a40c2-8b8e-433c-a2e0-5cc4500c5df4"), 173, "NORMAL", (short)2, 2.0m, "WD 2nd+ Hr" },
                    { new Guid("d0eb547d-a3b9-4ea2-924e-ab43452ccca3"), 173, "WEEKEND_HOLIDAY", (short)7, 2.0m, "WH Hr 7" },
                    { new Guid("de6afdc4-dc8c-49cf-9083-455926a38986"), 173, "WEEKEND_HOLIDAY", (short)4, 2.0m, "WH Hr 4" },
                    { new Guid("e9f49810-6c8f-44a2-ac94-4dac1fe16565"), 173, "WEEKEND_HOLIDAY", (short)12, 4.0m, "WH Hr 12" },
                    { new Guid("f4b2af86-ac6c-4fda-be04-a997e692aa96"), 173, "WEEKEND_HOLIDAY", (short)3, 2.0m, "WH Hr 3" }
                });
        }
    }
}
