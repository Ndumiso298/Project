using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class abcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "tblCustomerFridge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerFridge_FridgeId",
                table: "tblCustomerFridge");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "tblCustomerFridge");
        }
    }
}
