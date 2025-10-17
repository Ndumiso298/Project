using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddFridgeInStockReferenctoRequestDatails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblFridges_FridgeId",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblEmployee_EmployeeID",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblRequestDetais_RequestDetailId",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblFridges_FridgeId",
                table: "tblAllocations",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblEmployee_EmployeeID",
                table: "tblRequestFridgeAssignments",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestFridgeAssignments",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblRequestDetais_RequestDetailId",
                table: "tblRequestFridgeAssignments",
                column: "RequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblFridges_FridgeId",
                table: "tblAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblEmployee_EmployeeID",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblRequestDetais_RequestDetailId",
                table: "tblRequestFridgeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestDetais_FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.DropColumn(
                name: "FridgeInStockId",
                table: "tblRequestDetais");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblCustomer_CustomerID",
                table: "tblAllocations",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblFridges_FridgeId",
                table: "tblAllocations",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblEmployee_EmployeeID",
                table: "tblRequestFridgeAssignments",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblFridgeInStocks_FridgeInStockId",
                table: "tblRequestFridgeAssignments",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestFridgeAssignments_tblRequestDetais_RequestDetailId",
                table: "tblRequestFridgeAssignments",
                column: "RequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
