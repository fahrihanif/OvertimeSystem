using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DefaultRoleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_role",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Employee" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Manager" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_role",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "tbl_role",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "tbl_role",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));
        }
    }
}
