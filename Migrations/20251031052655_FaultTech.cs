using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FaultTech : Migration
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
                name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.AddColumn<string>(
                name: "FaultType",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);

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
                name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                table: "tblCustomerFridge",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                table: "tblCustomerFridge",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge",
                column: "RequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                table: "tblFridgeReplacements",
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
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
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
                name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                table: "tblFridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "FaultType",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "tblFaultTechnicians");

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
                name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                table: "tblCustomerFridge",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                table: "tblCustomerFridge",
                column: "FridgeInStockId",
                principalTable: "tblFridgeInStocks",
                principalColumn: "FridgeInStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge",
                column: "RequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                table: "tblFridgeReplacements",
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
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId",
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
