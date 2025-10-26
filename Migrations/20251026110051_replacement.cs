using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class replacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                table: "tblReplacementRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "tblReplacementRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FaultReportId",
                table: "tblReplacementRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OldFridgeId",
                table: "tblReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespondedByEmployeeId",
                table: "tblReplacementRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "tblReplacementRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportResponse",
                table: "tblReplacementRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5ebeeb3-9e7d-4331-9607-3187844236d2", "AQAAAAIAAYagAAAAEEbJ+YK1eVNTNCtna0CyiOrKUiH22ghqZhdW4osl1vlEltPMOo4kqMcoLSzHIBUKBA==", "d494b649-b729-4eda-81e9-066195cd4812" });

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_OldFridgeId",
                table: "tblReplacementRequests",
                column: "OldFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_RespondedByEmployeeId",
                table: "tblReplacementRequests",
                column: "RespondedByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReplacementRequests_tblEmployee_RespondedByEmployeeId",
                table: "tblReplacementRequests",
                column: "RespondedByEmployeeId",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                table: "tblReplacementRequests",
                column: "FaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReplacementRequests_tblFridges_OldFridgeId",
                table: "tblReplacementRequests",
                column: "OldFridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReplacementRequests_tblEmployee_RespondedByEmployeeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                table: "tblReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblReplacementRequests_tblFridges_OldFridgeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_tblReplacementRequests_OldFridgeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_tblReplacementRequests_RespondedByEmployeeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropColumn(
                name: "OldFridgeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropColumn(
                name: "RespondedByEmployeeId",
                table: "tblReplacementRequests");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "tblReplacementRequests");

            migrationBuilder.DropColumn(
                name: "SupportResponse",
                table: "tblReplacementRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "tblReplacementRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "FaultReportId",
                table: "tblReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25085bc-d5f2-4ac7-99b0-6cc073975fcb", "AQAAAAIAAYagAAAAEEl3Xx/Htb22X4Ax1uEunmLTjJ4HUZy8Nu9/DqiOBP3Z2ZG/o1CKl6bksxbXzaPdQA==", "dc4179d6-b1c5-4be3-9ff3-62ba4f7d99c9" });

            migrationBuilder.AddForeignKey(
                name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                table: "tblReplacementRequests",
                column: "FaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
