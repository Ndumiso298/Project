using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerAndEmployeetblToDBForNomarlizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaults_tblCustomerS_ReportedByCustomerId",
                table: "tblFaults");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeRequests_tblCustomerS_CustomerId",
                table: "tblFridgeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridges_tblCustomerS_CustomerId",
                table: "tblFridges");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMaintenanceVisits_tblCustomerS_CustomerId",
                table: "tblMaintenanceVisits");

            migrationBuilder.DropIndex(
                name: "IX_tblFridges_CustomerId",
                table: "tblFridges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCustomerS",
                table: "tblCustomerS");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "BusinessDocumentData",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BusinessDocumentPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "tblCustomerS");

            migrationBuilder.DropColumn(
                name: "CustomerNote",
                table: "tblCustomerS");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblCustomerS");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tblCustomerS");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "tblCustomerS");

            migrationBuilder.RenameTable(
                name: "tblCustomerS",
                newName: "tblCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblCustomer",
                newName: "CustomerID");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "tblCustomer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "BusinessDocumentData",
                table: "tblCustomer",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessDocumentPath",
                table: "tblCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                table: "tblCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCustomer",
                table: "tblCustomer",
                column: "CustomerID");

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployee_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_ApplicationUserId",
                table: "tblCustomer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_UserId",
                table: "tblEmployee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaults_tblCustomer_ReportedByCustomerId",
                table: "tblFaults",
                column: "ReportedByCustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeRequests_tblCustomer_CustomerId",
                table: "tblFridgeRequests",
                column: "CustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMaintenanceVisits_tblCustomer_CustomerId",
                table: "tblMaintenanceVisits",
                column: "CustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                table: "tblCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFaults_tblCustomer_ReportedByCustomerId",
                table: "tblFaults");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeRequests_tblCustomer_CustomerId",
                table: "tblFridgeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMaintenanceVisits_tblCustomer_CustomerId",
                table: "tblMaintenanceVisits");

            migrationBuilder.DropTable(
                name: "tblEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCustomer",
                table: "tblCustomer");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomer_ApplicationUserId",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "BusinessDocumentData",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "BusinessDocumentPath",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "tblCustomer");

            migrationBuilder.RenameTable(
                name: "tblCustomer",
                newName: "tblCustomerS");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "tblCustomerS",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "tblFridges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BusinessDocumentData",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessDocumentPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tblCustomerS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerNote",
                table: "tblCustomerS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblCustomerS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tblCustomerS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "tblCustomerS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCustomerS",
                table: "tblCustomerS",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 1,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 2,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 3,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 4,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 5,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 6,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 7,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 8,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 9,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 10,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 11,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 12,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 13,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 14,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 15,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 16,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 17,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 18,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 19,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 20,
                column: "CustomerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_tblFridges_CustomerId",
                table: "tblFridges",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaults_tblCustomerS_ReportedByCustomerId",
                table: "tblFaults",
                column: "ReportedByCustomerId",
                principalTable: "tblCustomerS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeRequests_tblCustomerS_CustomerId",
                table: "tblFridgeRequests",
                column: "CustomerId",
                principalTable: "tblCustomerS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridges_tblCustomerS_CustomerId",
                table: "tblFridges",
                column: "CustomerId",
                principalTable: "tblCustomerS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMaintenanceVisits_tblCustomerS_CustomerId",
                table: "tblMaintenanceVisits",
                column: "CustomerId",
                principalTable: "tblCustomerS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
