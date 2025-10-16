using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class RemovefOREINkEyForFridgeInStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropColumn(
                name: "FridgeInStockId",
                table: "tblRequestDetais");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeInStockId",
                table: "tblRequestDetais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetais",
                column: "FridgeInStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");
        }
    }
}
