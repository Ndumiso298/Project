using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedFridgeDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Condition", "CustomerId", "Description", "FridgeNo", "ImageUrl", "LastMaintenanceDate", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 253, "Excellent", null, "Energy-efficient double door fridge with frost-free technology.", "FRG-001", "https://example.com/images/fridge1.jpg", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RT28T", 1200.0, "Double Door" },
                    { 2, "Rented", "LG", 190, "Good", null, "Compact single door fridge ideal for small apartments.", "FRG-002", "https://example.com/images/fridge2.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "GL-B201", 900.0, "Single Door" },
                    { 3, "Available", "Whirlpool", 500, "Excellent", null, "Spacious fridge with advanced cooling technology.", "FRG-003", "https://example.com/images/fridge3.jpg", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "WRT518", 1500.0, "Double Door" },
                    { 4, "Available", "Defy", 350, "Good", null, "Durable fridge with energy-saving features.", "FRG-004", "https://example.com/images/fridge4.jpg", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "DAC700", 1100.0, "Double Door" },
                    { 5, "Rented", "Hisense", 310, "Good", null, "Compact fridge with adjustable shelves.", "FRG-005", "https://example.com/images/fridge5.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "H310BI", 800.0, "Single Door" },
                    { 6, "Available", "Bosch", 420, "Excellent", null, "Premium fridge with no-frost technology.", "FRG-006", "https://example.com/images/fridge6.jpg", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "KDN42", 1600.0, "Double Door" },
                    { 7, "Available", "Kelvinator", 250, "Fair", null, "Affordable fridge with basic features.", "FRG-007", "https://example.com/images/fridge7.jpg", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "KEL250", 700.0, "Single Door" },
                    { 8, "Available", "Smeg", 281, "Excellent", null, "Retro-style fridge with modern cooling.", "FRG-008", "https://example.com/images/fridge8.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "FAB28", 2000.0, "Single Door" },
                    { 9, "Rented", "AEG", 300, "Excellent", null, "Built-in fridge with adjustable compartments.", "FRG-009", "https://example.com/images/fridge9.jpg", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "SKE818", 1800.0, "Single Door" },
                    { 10, "Available", "Panasonic", 347, "Good", null, "Fridge with inverter technology for energy saving.", "FRG-010", "https://example.com/images/fridge10.jpg", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "NR-BL347", 1300.0, "Double Door" },
                    { 11, "Available", "Haier", 565, "Excellent", null, "Large capacity fridge with twin inverter technology.", "FRG-011", "https://example.com/images/fridge11.jpg", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "HRF-619", 2200.0, "Side by Side" },
                    { 12, "Available", "Hitachi", 640, "Excellent", null, "Premium French door fridge with eco-friendly features.", "FRG-012", "https://example.com/images/fridge12.jpg", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "R-WB640", 2500.0, "French Door" },
                    { 13, "Rented", "Electrolux", 370, "Good", null, "Fridge with taste guard deodorizer.", "FRG-013", "https://example.com/images/fridge13.jpg", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "ETB3700", 1400.0, "Top Freezer" },
                    { 14, "Available", "Sharp", 600, "Excellent", null, "Fridge with plasmacluster ion technology.", "FRG-014", "https://example.com/images/fridge14.jpg", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "SJ-GX60", 2300.0, "French Door" },
                    { 15, "Available", "Midea", 400, "Good", null, "Affordable fridge with large freezer compartment.", "FRG-015", "https://example.com/images/fridge15.jpg", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "HD-400", 1000.0, "Double Door" },
                    { 16, "Available", "Gorenje", 326, "Good", null, "Stylish bottom freezer fridge with crisp zone for vegetables.", "FRG-016", "https://example.com/images/fridge16.jpg", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "NRK6192", 1250.0, "Bottom Freezer" },
                    { 17, "Available", "Westinghouse", 528, "Excellent", null, "Family-sized fridge with humidity-controlled crisper.", "FRG-017", "https://example.com/images/fridge17.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "WBE5300", 1700.0, "Top Freezer" },
                    { 18, "Rented", "Fisher & Paykel", 519, "Excellent", null, "Premium French door fridge with active smart technology.", "FRG-018", "https://example.com/images/fridge18.jpg", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RF522", 2400.0, "French Door" },
                    { 19, "Available", "Ariston", 383, "Good", null, "Reliable fridge with antibacterial coating.", "FRG-019", "https://example.com/images/fridge19.jpg", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "MBA3832", 1150.0, "Top Freezer" },
                    { 20, "Available", "Beko", 560, "Excellent", null, "Spacious bottom freezer fridge with NeoFrost cooling.", "FRG-020", "https://example.com/images/fridge20.jpg", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RCNE560", 1850.0, "Bottom Freezer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblFridges",
                keyColumn: "FridgeId",
                keyValue: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "tblFridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
