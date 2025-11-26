using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OvertimeSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsAndCardinality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_overtime_request_employee_id",
                table: "tbl_overtime_request",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_overtime_request_policy_id",
                table: "tbl_overtime_request",
                column: "policy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employee_manager_id",
                table: "tbl_employee",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approved_overtime_rate_id",
                table: "tbl_approved_overtime",
                column: "rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approved_overtime_request_id",
                table: "tbl_approved_overtime",
                column: "request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_role_role_id",
                table: "tbl_account_role",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_account_tbl_employee_employee_id",
                table: "tbl_account",
                column: "employee_id",
                principalTable: "tbl_employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_account_role_tbl_account_account_id",
                table: "tbl_account_role",
                column: "account_id",
                principalTable: "tbl_account",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_account_role_tbl_role_role_id",
                table: "tbl_account_role",
                column: "role_id",
                principalTable: "tbl_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_approved_overtime_tbl_overtime_rate_rate_id",
                table: "tbl_approved_overtime",
                column: "rate_id",
                principalTable: "tbl_overtime_rate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_approved_overtime_tbl_overtime_request_request_id",
                table: "tbl_approved_overtime",
                column: "request_id",
                principalTable: "tbl_overtime_request",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_employee_tbl_employee_manager_id",
                table: "tbl_employee",
                column: "manager_id",
                principalTable: "tbl_employee",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_overtime_budget_tbl_employee_employee_id",
                table: "tbl_overtime_budget",
                column: "employee_id",
                principalTable: "tbl_employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_overtime_request_tbl_employee_employee_id",
                table: "tbl_overtime_request",
                column: "employee_id",
                principalTable: "tbl_employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_overtime_request_tbl_overtime_policy_policy_id",
                table: "tbl_overtime_request",
                column: "policy_id",
                principalTable: "tbl_overtime_policy",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_account_tbl_employee_employee_id",
                table: "tbl_account");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_account_role_tbl_account_account_id",
                table: "tbl_account_role");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_account_role_tbl_role_role_id",
                table: "tbl_account_role");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_approved_overtime_tbl_overtime_rate_rate_id",
                table: "tbl_approved_overtime");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_approved_overtime_tbl_overtime_request_request_id",
                table: "tbl_approved_overtime");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_employee_tbl_employee_manager_id",
                table: "tbl_employee");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_overtime_budget_tbl_employee_employee_id",
                table: "tbl_overtime_budget");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_overtime_request_tbl_employee_employee_id",
                table: "tbl_overtime_request");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_overtime_request_tbl_overtime_policy_policy_id",
                table: "tbl_overtime_request");

            migrationBuilder.DropIndex(
                name: "IX_tbl_overtime_request_employee_id",
                table: "tbl_overtime_request");

            migrationBuilder.DropIndex(
                name: "IX_tbl_overtime_request_policy_id",
                table: "tbl_overtime_request");

            migrationBuilder.DropIndex(
                name: "IX_tbl_employee_manager_id",
                table: "tbl_employee");

            migrationBuilder.DropIndex(
                name: "IX_tbl_approved_overtime_rate_id",
                table: "tbl_approved_overtime");

            migrationBuilder.DropIndex(
                name: "IX_tbl_approved_overtime_request_id",
                table: "tbl_approved_overtime");

            migrationBuilder.DropIndex(
                name: "IX_tbl_account_role_role_id",
                table: "tbl_account_role");
        }
    }
}
