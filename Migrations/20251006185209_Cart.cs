using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "tblFridges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 1,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 2,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 3,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 4,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 5,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 6,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 7,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 8,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 9,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 10,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 11,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 12,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 13,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 14,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 15,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 16,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 17,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 18,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 19,
                column: "IsRented",
                value: false);

            migrationBuilder.UpdateData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 20,
                column: "IsRented",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "tblFridges");
        }
    }
}
