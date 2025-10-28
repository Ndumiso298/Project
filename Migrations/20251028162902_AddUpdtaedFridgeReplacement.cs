using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdtaedFridgeReplacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFridgeReplacements",
                columns: table => new
                {
                    FridgeReplacementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    FridgeVisitVisitId = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    NewFridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    OldFridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacementStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeReplacements", x => x.FridgeReplacementId);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                        column: x => x.NewFridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId");
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblFridgeVisits_FridgeVisitVisitId",
                        column: x => x.FridgeVisitVisitId,
                        principalTable: "tblFridgeVisits",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_CustomerID",
                table: "tblFridgeReplacements",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_FridgeVisitVisitId",
                table: "tblFridgeReplacements",
                column: "FridgeVisitVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_NewFridgeInStockId",
                table: "tblFridgeReplacements",
                column: "NewFridgeInStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFridgeReplacements");
        }
    }
}
