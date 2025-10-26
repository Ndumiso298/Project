using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class fault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblReplacementRequests");

            migrationBuilder.AddColumn<int>(
                name: "FridgeVisitVisitId",
                table: "tblFaultReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedBy",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "tblFaultReports",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d27436-7a20-4e9a-a3ec-d82faf55e091", "AQAAAAIAAYagAAAAECDwLw8HxF8QZ6vtyc3YQMqYGOMGQRFC4Ljfh68WGx5njpvPIz824zMjqtfyTwvecA==", "2e6f1725-c253-41e4-930f-6bf25b6f2ae2" });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_FridgeVisitVisitId",
                table: "tblFaultReports",
                column: "FridgeVisitVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitVisitId",
                table: "tblFaultReports",
                column: "FridgeVisitVisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitVisitId",
                table: "tblFaultReports");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultReports_FridgeVisitVisitId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "FridgeVisitVisitId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ReportedBy",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "tblFaultReports");

            migrationBuilder.CreateTable(
                name: "tblReplacementRequests",
                columns: table => new
                {
                    ReplacementRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FaultReportId = table.Column<int>(type: "int", nullable: true),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    OldFridgeId = table.Column<int>(type: "int", nullable: false),
                    RespondedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportResponse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReplacementRequests", x => x.ReplacementRequestId);
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblEmployee_RespondedByEmployeeId",
                        column: x => x.RespondedByEmployeeId,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                        column: x => x.FaultReportId,
                        principalTable: "tblFaultReports",
                        principalColumn: "FaultReportId");
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblFridges_OldFridgeId",
                        column: x => x.OldFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5ebeeb3-9e7d-4331-9607-3187844236d2", "AQAAAAIAAYagAAAAEEbJ+YK1eVNTNCtna0CyiOrKUiH22ghqZhdW4osl1vlEltPMOo4kqMcoLSzHIBUKBA==", "d494b649-b729-4eda-81e9-066195cd4812" });

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_CustomerId",
                table: "tblReplacementRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_FaultReportId",
                table: "tblReplacementRequests",
                column: "FaultReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_FridgeInStockId",
                table: "tblReplacementRequests",
                column: "FridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_OldFridgeId",
                table: "tblReplacementRequests",
                column: "OldFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReplacementRequests_RespondedByEmployeeId",
                table: "tblReplacementRequests",
                column: "RespondedByEmployeeId");
        }
    }
}
