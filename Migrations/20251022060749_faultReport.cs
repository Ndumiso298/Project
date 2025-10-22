using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class faultReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerID",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFaultTechnicians_FaultTechnicianId",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                table: "tblFaultTechnicians");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "tblFaultReports",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Urgency",
                table: "tblFaultReports",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "ReportDate",
                table: "tblFaultReports",
                newName: "ReportedDate");

            migrationBuilder.RenameColumn(
                name: "FaultTechnicianId",
                table: "tblFaultReports",
                newName: "FridgeVisitId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tblFaultReports",
                newName: "FaultType");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "tblFaultReports",
                newName: "FaultDescription");

            migrationBuilder.RenameIndex(
                name: "IX_tblFaultReports_CustomerID",
                table: "tblFaultReports",
                newName: "IX_tblFaultReports_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_tblFaultReports_FaultTechnicianId",
                table: "tblFaultReports",
                newName: "IX_tblFaultReports_FridgeVisitId");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FaultReportId",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFaultReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1d0e449-bbf8-4d58-8f2e-cec4c83bb7bd", "AQAAAAIAAYagAAAAEASNz8kaSGNdIHAA0yG96q3OcsJTgS02FinBYPgPerA2bDBkVtJepw6k4PcuEond8w==", "5c5f8bf0-60a2-41e6-8797-6406f4fb46e5" });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultTechnicians_FaultReportId",
                table: "tblFaultTechnicians",
                column: "FaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports",
                column: "CustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitId",
                table: "tblFaultReports",
                column: "FridgeVisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultTechnicians_tblFaultReports_FaultReportId",
                table: "tblFaultTechnicians",
                column: "FaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                table: "tblFaultTechnicians",
                column: "VisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitId",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultTechnicians_tblFaultReports_FaultReportId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultTechnicians_FaultReportId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "FaultReportId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "tblFaultReports");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "tblFaultReports",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "ReportedDate",
                table: "tblFaultReports",
                newName: "ReportDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "tblFaultReports",
                newName: "Urgency");

            migrationBuilder.RenameColumn(
                name: "FridgeVisitId",
                table: "tblFaultReports",
                newName: "FaultTechnicianId");

            migrationBuilder.RenameColumn(
                name: "FaultType",
                table: "tblFaultReports",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "FaultDescription",
                table: "tblFaultReports",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_tblFaultReports_CustomerId",
                table: "tblFaultReports",
                newName: "IX_tblFaultReports_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_tblFaultReports_FridgeVisitId",
                table: "tblFaultReports",
                newName: "IX_tblFaultReports_FaultTechnicianId");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "tblFaultReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e008e3cb-7c49-47a5-800c-7d1ee2b413a4", "AQAAAAIAAYagAAAAECyCUBK1Srza3I5lQUPxG9tHgrb2Knnt1xjSqsVrtLKXghgc8QDO1bDMK2QA42Oe+w==", "39a889be-2901-40b5-bd48-98e287e28e47" });

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerID",
                table: "tblFaultReports",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFaultTechnicians_FaultTechnicianId",
                table: "tblFaultReports",
                column: "FaultTechnicianId",
                principalTable: "tblFaultTechnicians",
                principalColumn: "FaultId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                table: "tblFaultTechnicians",
                column: "VisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
