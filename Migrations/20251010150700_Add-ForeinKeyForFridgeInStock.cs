using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddForeinKeyForFridgeInStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeInStockId",
                table: "tblRequestDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetails",
                column: "FridgeInStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetails",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetails");

            migrationBuilder.DropColumn(
                name: "FridgeInStockId",
                table: "tblRequestDetails");
        }
    }
}
