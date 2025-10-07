using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ghjkj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeInStocks_FridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.RenameColumn(
                name: "FridgeId",
                table: "tblFridgeInStocks",
                newName: "FridgelId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityStatus",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FridgeNo",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMaintenanceDate",
                table: "tblFridges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridgeModelFridgeId",
                table: "tblFridgeInStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeInStocks_FridgeModelFridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeModelFridgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeModelFridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeModelFridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeModelFridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeInStocks_FridgeModelFridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropColumn(
                name: "AvailabilityStatus",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "FridgeNo",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "LastMaintenanceDate",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "tblFridges");

            migrationBuilder.DropColumn(
                name: "FridgeModelFridgeId",
                table: "tblFridgeInStocks");

            migrationBuilder.RenameColumn(
                name: "FridgelId",
                table: "tblFridgeInStocks",
                newName: "FridgeId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeInStocks_FridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeId",
                principalTable: "tblFridges",
                principalColumn: "FridgeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
