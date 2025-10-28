using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class RemovingFridgeInStockFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CellNumber", "City", "ConcurrencyStamp", "DeclinedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsApproved", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "RejectionReason", "SecurityStamp", "State", "Status", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-id-123", 0, "+27123456789", "Johannesburg", "52d4ecca-8084-43d4-b5bd-6877cb80ad51", null, "ApplicationUser", "admin@fridgesystem.com", true, "System", true, "Administrator", false, null, "ADMIN@FRIDGESYSTEM.COM", "ADMIN@FRIDGESYSTEM.COM", "AQAAAAIAAYagAAAAELeo5PnhUnIxOmWaZP87ahT0SKHEev7tIzllMd7N7+QOJlVrMotpJog4u5efzgVUwQ==", null, true, "2000", null, "7beeca44-87aa-4726-9a98-0ae0043ccc64", "Gauteng", "Approved", "123 Admin Street", false, "admin@fridgesystem.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123");

            migrationBuilder.InsertData(
                table: "tblFridgeInStocks",
                columns: new[] { "FridgeInStockId", "Condition", "FridgeId", "FridgeNo", "IsAvailable", "LastMaintenanceDate", "Location", "Quantity" },
                values: new object[,]
                {
                    { 1, "Excellent", 1, "FRG001", true, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 2, "Good", 1, "FRG002", false, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 3, "Excellent", 2, "FRG003", true, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 4, "Good", 2, "FRG004", false, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 5, "Fair", 3, "FRG005", false, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 6, "Excellent", 3, "FRG006", true, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 7, "Good", 4, "FRG007", true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 8, "Fair", 4, "FRG008", false, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 9, "Good", 5, "FRG009", true, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 10, "Excellent", 5, "FRG010", true, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 11, "Good", 6, "FRG011", false, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Elizabeth", 0 },
                    { 12, "Excellent", 6, "FRG012", true, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Elizabeth", 0 },
                    { 13, "Excellent", 7, "FRG013", true, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 14, "Fair", 7, "FRG014", false, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 15, "Good", 8, "FRG015", true, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 16, "Excellent", 8, "FRG016", false, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 17, "Good", 9, "FRG017", true, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 18, "Excellent", 9, "FRG018", false, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 19, "Fair", 10, "FRG019", false, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 20, "Excellent", 10, "FRG020", true, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 21, "Excellent", 11, "FRG021", true, new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloemfontein", 0 },
                    { 22, "Fair", 11, "FRG022", false, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloemfontein", 0 },
                    { 23, "Good", 12, "FRG023", false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 24, "Excellent", 12, "FRG024", true, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 25, "Good", 13, "FRG025", true, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 26, "Fair", 13, "FRG026", false, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 27, "Excellent", 14, "FRG027", false, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 28, "Good", 14, "FRG028", true, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 29, "Excellent", 15, "FRG029", true, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 30, "Fair", 15, "FRG030", false, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 31, "Excellent", 16, "FRG031", true, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 32, "Good", 16, "FRG032", false, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 33, "Fair", 17, "FRG033", false, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 34, "Excellent", 17, "FRG034", true, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 0 },
                    { 35, "Good", 18, "FRG035", true, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 36, "Fair", 18, "FRG036", false, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 0 },
                    { 37, "Excellent", 19, "FRG037", true, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 38, "Good", 19, "FRG038", false, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 0 },
                    { 39, "Fair", 20, "FRG039", false, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 },
                    { 40, "Excellent", 20, "FRG040", true, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 0 }
                });
        }
    }
}
