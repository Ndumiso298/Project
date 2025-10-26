using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class requestReplacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblReplacementRequests",
                columns: table => new
                {
                    ReplacementRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultReportId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_tblReplacementRequests_tblFaultReports_FaultReportId",
                        column: x => x.FaultReportId,
                        principalTable: "tblFaultReports",
                        principalColumn: "FaultReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReplacementRequests_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d2bb2d-6ae2-4a3d-82e4-b398f9d357d8", "AQAAAAIAAYagAAAAEMvJJ0GYXEkwjQnhO3VtNpSkExayElF6CgcJXpuXfFn0Tpf1BqGnxPLkaETuTphy9w==", "1d9b5df8-5117-4fbd-8023-baff66065d5f" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblReplacementRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a317e4ce-fd65-4669-a570-01f147d8042b", "AQAAAAIAAYagAAAAEPN2eBXr1haE1IHOuVfLh0nZjX9E/8CEFTFVyBUa7syA/aASDMe0TaVgzWcZR9q5oQ==", "aa5562f3-47f2-4aa0-b13d-17fb23dcb148" });
        }
    }
}
