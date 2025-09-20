using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class adgjlkn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FridgeAllocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "FridgeAllocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblRequestHeaders_RequestHeaderId",
                table: "FridgeAllocations",
                column: "Id",
                principalTable: "RequestHeaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblRequestHeaders_RequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FridgeAllocations");
        }
    }
}
