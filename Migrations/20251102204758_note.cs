using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFaultReports_OriginalFaultReportId",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                table: "tblFaultReports");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultReports_OriginalFaultReportId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "tblFaultReports");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tblFridgeVisits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblFridgeVisits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitType",
                table: "tblFridgeVisits",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianAssigned",
                table: "tblFaultTechnicians",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "tblFaultTechnicians",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FaultDescription",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerBookingStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "tblFaultTechnicians",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tblFaultReports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "tblFaultReports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FridgeInStockId",
                table: "tblFaultReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "tblFaultReports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                table: "tblFaultReports",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tblFridgeVisits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblFridgeVisits");

            migrationBuilder.DropColumn(
                name: "VisitType",
                table: "tblFridgeVisits");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "tblFaultTechnicians");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianAssigned",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultDescription",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerBookingStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FridgeInStockId",
                table: "tblFaultReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_OriginalFaultReportId",
                table: "tblFaultReports",
                column: "OriginalFaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFaultReports_OriginalFaultReportId",
                table: "tblFaultReports",
                column: "OriginalFaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                table: "tblFaultReports",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
