using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeVisits_FridgeVisitVisitId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeReplacements_FridgeVisitVisitId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "FridgeVisitVisitId",
                table: "tblFridgeReplacements");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_VisitId",
                table: "tblFridgeReplacements",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                table: "tblFridgeReplacements",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                table: "tblFridgeReplacements",
                column: "NewFridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeVisits_VisitId",
                table: "tblFridgeReplacements",
                column: "VisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeVisits_VisitId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeReplacements_VisitId",
                table: "tblFridgeReplacements");

            migrationBuilder.AddColumn<int>(
                name: "FridgeVisitVisitId",
                table: "tblFridgeReplacements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_FridgeVisitVisitId",
                table: "tblFridgeReplacements",
                column: "FridgeVisitVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                table: "tblFridgeReplacements",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                table: "tblFridgeReplacements",
                column: "NewFridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblFridgeVisits_FridgeVisitVisitId",
                table: "tblFridgeReplacements",
                column: "FridgeVisitVisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
