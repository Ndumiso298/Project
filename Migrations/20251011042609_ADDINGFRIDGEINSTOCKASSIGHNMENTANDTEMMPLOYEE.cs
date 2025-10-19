using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ADDINGFRIDGEINSTOCKASSIGHNMENTANDTEMMPLOYEE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblRequestFridgeAssignments",
                columns: table => new
                {
                    RequestFridgeAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDetailId = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestFridgeAssignments", x => x.RequestFridgeAssignmentId);
                    table.ForeignKey(
                        name: "FK_tblRequestFridgeAssignments_tblEmployee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestFridgeAssignments_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestFridgeAssignments_tblRequestDetais_RequestDetailId",
                        column: x => x.RequestDetailId,
                        principalTable: "tblRequestDetais",
                        principalColumn: "RequestDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestFridgeAssignments_EmployeeID",
                table: "tblRequestFridgeAssignments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestFridgeAssignments_FridgeInStockId",
                table: "tblRequestFridgeAssignments",
                column: "FridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestFridgeAssignments_RequestDetailId",
                table: "tblRequestFridgeAssignments",
                column: "RequestDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRequestFridgeAssignments");
        }
    }
}
