using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipBetweenAllocatitinCartAndCustomerToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_AspNetUsers_ApplicationUserId",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_tblAllocations_AllocationId",
                table: "tblFridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_AspNetUsers_ApplicationUserId",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestHeaders_ApplicationUserId",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "tblFridgeVisits");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocations_ApplicationUserId",
                table: "tblAllocations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "AllocationId",
                table: "tblFridgeVisits");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "tblAllocations");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "tblRequestHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "tblAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_CustomerID",
                table: "tblAllocations",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestHeaders_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocations_CustomerID",
                table: "tblAllocations");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "tblAllocations");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "tblRequestHeaders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AllocationId",
                table: "tblFridgeVisits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "tblAllocations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_ApplicationUserId",
                table: "tblRequestHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_ApplicationUserId",
                table: "tblAllocations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_AspNetUsers_ApplicationUserId",
                table: "tblAllocations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeVisits_tblAllocations_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId",
                principalTable: "tblAllocations",
                principalColumn: "AllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_AspNetUsers_ApplicationUserId",
                table: "tblRequestHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
