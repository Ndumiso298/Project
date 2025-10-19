using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingThreeJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomerFridge",
                columns: table => new
                {
                    CustomerFridgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ReservedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerFridge", x => x.CustomerFridgeId);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_CustomerID",
                table: "tblCustomerFridge",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_FridgeInStockId",
                table: "tblCustomerFridge",
                column: "FridgeInStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomerFridge");
        }
    }
}
