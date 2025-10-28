using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingFridgeassighnmentallation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropTable(
                name: "tblRequestFridgeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropColumn(
                name: "FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.CreateTable(
                name: "tblFridgeAllocation",
                columns: table => new
                {
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    FridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocatedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeAllocation", x => x.FridgeAllocationId);
                    table.ForeignKey(
                        name: "FK_tblFridgeAllocation_tblEmployee_AllocatedByEmployeeId",
                        column: x => x.AllocatedByEmployeeId,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_tblFridgeAllocation_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeAllocation_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeAllocation_AllocatedByEmployeeId",
                table: "tblFridgeAllocation",
                column: "AllocatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeAllocation_FridgeInStockId",
                table: "tblFridgeAllocation",
                column: "FridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeAllocation_RequestHeaderId",
                table: "tblFridgeAllocation",
                column: "RequestHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFridgeAllocation");

            migrationBuilder.AddColumn<int>(
                name: "FridgeInStockId",
                table: "tblRequestDetais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblRequestFridgeAssignments",
                columns: table => new
                {
                    RequestFridgeAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    RequestDetailId = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetais",
                column: "FridgeInStockId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");
        }
    }
}
