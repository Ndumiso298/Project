using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataTypestoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocation_tblFridge_FridgeId1",
                table: "tblAllocation");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocation_FridgeId1",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "City",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "FridgeId1",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "State",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblAllocation");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "tblAllocation");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "tblAllocation",
                newName: "Count");

            migrationBuilder.AlterColumn<double>(
                name: "RentalPricePerMonth",
                table: "tblFridge",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "FridgeId",
                table: "tblAllocation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 1,
                column: "RentalPricePerMonth",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 2,
                column: "RentalPricePerMonth",
                value: 900.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 3,
                column: "RentalPricePerMonth",
                value: 1500.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 4,
                column: "RentalPricePerMonth",
                value: 1100.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 5,
                column: "RentalPricePerMonth",
                value: 800.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 6,
                column: "RentalPricePerMonth",
                value: 1600.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 7,
                column: "RentalPricePerMonth",
                value: 700.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 8,
                column: "RentalPricePerMonth",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 9,
                column: "RentalPricePerMonth",
                value: 1800.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 10,
                column: "RentalPricePerMonth",
                value: 1300.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 11,
                column: "RentalPricePerMonth",
                value: 2200.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 12,
                column: "RentalPricePerMonth",
                value: 2500.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 13,
                column: "RentalPricePerMonth",
                value: 1400.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 14,
                column: "RentalPricePerMonth",
                value: 2300.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 15,
                column: "RentalPricePerMonth",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 16,
                column: "RentalPricePerMonth",
                value: 1250.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 17,
                column: "RentalPricePerMonth",
                value: 1700.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 18,
                column: "RentalPricePerMonth",
                value: 2400.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 19,
                column: "RentalPricePerMonth",
                value: 1150.0);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 20,
                column: "RentalPricePerMonth",
                value: 1850.0);

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocation_FridgeId",
                table: "tblAllocation",
                column: "FridgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocation_tblFridge_FridgeId",
                table: "tblAllocation",
                column: "FridgeId",
                principalTable: "tblFridge",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocation_tblFridge_FridgeId",
                table: "tblAllocation");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocation_FridgeId",
                table: "tblAllocation");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "tblAllocation",
                newName: "Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "RentalPricePerMonth",
                table: "tblFridge",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "FridgeId",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "tblAllocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FridgeId1",
                table: "tblAllocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "tblAllocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "tblAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 1,
                column: "RentalPricePerMonth",
                value: 1200.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 2,
                column: "RentalPricePerMonth",
                value: 900.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 3,
                column: "RentalPricePerMonth",
                value: 1500.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 4,
                column: "RentalPricePerMonth",
                value: 1100.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 5,
                column: "RentalPricePerMonth",
                value: 800.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 6,
                column: "RentalPricePerMonth",
                value: 1600.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 7,
                column: "RentalPricePerMonth",
                value: 700.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 8,
                column: "RentalPricePerMonth",
                value: 2000.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 9,
                column: "RentalPricePerMonth",
                value: 1800.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 10,
                column: "RentalPricePerMonth",
                value: 1300.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 11,
                column: "RentalPricePerMonth",
                value: 2200.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 12,
                column: "RentalPricePerMonth",
                value: 2500.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 13,
                column: "RentalPricePerMonth",
                value: 1400.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 14,
                column: "RentalPricePerMonth",
                value: 2300.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 15,
                column: "RentalPricePerMonth",
                value: 1000.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 16,
                column: "RentalPricePerMonth",
                value: 1250.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 17,
                column: "RentalPricePerMonth",
                value: 1700.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 18,
                column: "RentalPricePerMonth",
                value: 2400.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 19,
                column: "RentalPricePerMonth",
                value: 1150.00m);

            migrationBuilder.UpdateData(
                table: "tblFridge",
                keyColumn: "FridgeId",
                keyValue: 20,
                column: "RentalPricePerMonth",
                value: 1850.00m);

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocation_FridgeId1",
                table: "tblAllocation",
                column: "FridgeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocation_tblFridge_FridgeId1",
                table: "tblAllocation",
                column: "FridgeId1",
                principalTable: "tblFridge",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
