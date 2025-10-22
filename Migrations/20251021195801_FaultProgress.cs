using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FaultProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualRepairTime",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedRepairTime",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RepairCost",
                table: "tblFaultTechnicians",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblFaultReports",
                columns: table => new
                {
                    FaultReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urgency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultReports", x => x.FaultReportId);
                    table.ForeignKey(
                        name: "FK_tblFaultReports_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFaultReports_tblFaultTechnicians_FaultTechnicianId",
                        column: x => x.FaultTechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "FaultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b4b5a96-7173-439d-946b-31ed96d64818", "AQAAAAIAAYagAAAAEJswj6SRKPzLNhcntSf1TP9ZKMV1hspwTqO0AA6tHarYUKYr9B6AHMtxMDzOwJyOjQ==", "bc99a90b-3fa5-417a-b99d-007e6acca356" });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_CustomerID",
                table: "tblFaultReports",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_FaultTechnicianId",
                table: "tblFaultReports",
                column: "FaultTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_FridgeInStockId",
                table: "tblFaultReports",
                column: "FridgeInStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ActualRepairTime",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "EstimatedRepairTime",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "tblAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cb49037-e10d-4f6c-9178-c080e6497ccf", "AQAAAAIAAYagAAAAEAX+7/D0OxRGayk4zBpVKz7f2DqGYeZJE3dlW/mqxmcaSB7YRzMiHNYSFVP+9LAJzg==", "2011129e-5e59-4e82-b591-c8405469ed82" });
        }
    }
}
