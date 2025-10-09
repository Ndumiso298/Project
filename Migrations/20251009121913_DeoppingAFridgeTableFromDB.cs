using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class DeoppingAFridgeTableFromDB : Migration
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
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders");

            migrationBuilder.DropTable(
                name: "tblFridgeRequests");

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
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID",
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
                name: "FK_tblRequestDetais_tblFridges_FridgeId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                table: "tblRequestDetais");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders");

            migrationBuilder.CreateTable(
                name: "tblFridgeRequests",
                columns: table => new
                {
                    FridgeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FaultyFridgeId = table.Column<int>(type: "int", nullable: false),
                    ReplacementFridgeId = table.Column<int>(type: "int", nullable: true),
                    CapacityRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeRequests", x => x.FridgeRequestId);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblFridges_FaultyFridgeId",
                        column: x => x.FaultyFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblFridges_ReplacementFridgeId",
                        column: x => x.ReplacementFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_CustomerId",
                table: "tblFridgeRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_FaultyFridgeId",
                table: "tblFridgeRequests",
                column: "FaultyFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_ReplacementFridgeId",
                table: "tblFridgeRequests",
                column: "ReplacementFridgeId");

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
                name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
