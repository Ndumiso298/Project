using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedingFridgeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Description", "ImageUrl", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 250, "Energy efficient fridge with frost-free technology", "/images/samsung_rt28a.jpg", "Durban", "RT28A", 450.0, "Double Door" },
                    { 2, "Available", "LG", 260, "Smart inverter compressor for energy savings", "/images/lg_glt292.jpg", "Johannesburg", "GL-T292", 480.0, "Top Freezer" },
                    { 3, "Rented", "Hisense", 320, "Spacious design with humidity control", "/images/hisense_h370bi.jpg", "Cape Town", "H370BI", 520.0, "Bottom Freezer" },
                    { 4, "Available", "Defy", 350, "A+ energy rated with multi-airflow system", "/images/defy_dac621.jpg", "Pretoria", "DAC621", 550.0, "Combi Fridge" },
                    { 5, "Available", "Whirlpool", 200, "Compact and efficient single door fridge", "/images/whirlpool_wde205.jpg", "Durban", "WDE205", 400.0, "Single Door" },
                    { 6, "Rented", "Bosch", 350, "No frost cooling with LED lighting", "/images/bosch_kdn42.jpg", "Port Elizabeth", "KDN42", 600.0, "Frost Free" },
                    { 7, "Available", "Smeg", 270, "Stylish retro fridge with adjustable shelves", "/images/smeg_fab28.jpg", "Johannesburg", "FAB28", 650.0, "Retro Style" },
                    { 8, "Available", "Kelvinator", 265, "Affordable fridge with efficient cooling", "/images/kelvinator_krf265.jpg", "Cape Town", "KRF265", 430.0, "Top Mount" },
                    { 9, "Rented", "Siemens", 360, "No frost with multi-airflow system", "/images/siemens_kg36n.jpg", "Pretoria", "KG36N", 590.0, "Bottom Freezer" },
                    { 10, "Available", "Haier", 290, "Toughened glass shelves and energy efficient", "/images/haier_hrf290.jpg", "Durban", "HRF290", 470.0, "Double Door" },
                    { 11, "Available", "Hisense", 310, "Low noise and efficient compressor", "/images/hisense_h310bi.jpg", "Bloemfontein", "H310BI", 500.0, "Top Freezer" },
                    { 12, "Rented", "Defy", 420, "LED display and water dispenser", "/images/defy_dac700.jpg", "Cape Town", "DAC700", 700.0, "Side by Side" },
                    { 13, "Available", "LG", 282, "Smart cooling with WiFi control", "/images/lg_glq282.jpg", "Durban", "GL-Q282", 530.0, "Smart Inverter" },
                    { 14, "Rented", "Samsung", 340, "Twin cooling system for freshness", "/images/samsung_rt34a.jpg", "Pretoria", "RT34A", 560.0, "Top Freezer" },
                    { 15, "Available", "Whirlpool", 500, "High capacity with 6th sense technology", "/images/whirlpool_wde520.jpg", "Johannesburg", "WDE520", 750.0, "Double Door" },
                    { 16, "Available", "Bosch", 400, "Energy efficient and silent operation", "/images/bosch_kdn43.jpg", "Durban", "KDN43", 610.0, "Frost Free" },
                    { 17, "Rented", "Smeg", 300, "Vintage design with modern efficiency", "/images/smeg_fab32.jpg", "Cape Town", "FAB32", 670.0, "Retro Style" },
                    { 18, "Available", "Siemens", 390, "Multi-airflow and easy-clean interior", "/images/siemens_kg39n.jpg", "Johannesburg", "KG39N", 620.0, "Combi Fridge" },
                    { 19, "Available", "Haier", 330, "Tough build and fast cooling", "/images/haier_hrf330.jpg", "Pretoria", "HRF330", 500.0, "Bottom Freezer" },
                    { 20, "Rented", "Defy", 473, "Spacious and frost-free design", "/images/defy_dac473.jpg", "Durban", "DAC473", 720.0, "Side by Side" }
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
        }
    }
}
