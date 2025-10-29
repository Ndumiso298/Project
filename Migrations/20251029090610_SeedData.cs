using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert AspNetUsers
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] {
                    "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed",
                    "PhoneNumberConfirmed", "SecurityStamp", "ConcurrencyStamp", "FirstName", "LastName",
                    "CellNumber", "StreetAddress", "City", "State", "PostalCode", "Status", "IsApproved",
                    "PasswordHash", "LockoutEnabled", "TwoFactorEnabled", "AccessFailedCount", "Discriminator"
                },
                values: new object[] {
                    "admin-id-123",
                    "admin@fridgesystem.com",
                    "ADMIN@FRIDGESYSTEM.COM",
                    "admin@fridgesystem.com",
                    "ADMIN@FRIDGESYSTEM.COM",
                    true,
                    true,
                    Guid.NewGuid().ToString("D"),
                    Guid.NewGuid().ToString(),
                    "System",
                    "Administrator",
                    "+27123456789",
                    "123 Admin Street",
                    "Johannesburg",
                    "Gauteng",
                    "2000",
                    "Approved",
                    true,
                    "AQAAAAIAAYagAAAAEDlrw1wBkq7e8vD3HnF3n6J7V8Zk8hF6p7Rq2T1oK1oXvLm6p9W8Y3bHjJfQ2W2p1w==",
                    false,
                    false,
                    0,
                    "ApplicationUser"
                });

            // Insert AspNetRoles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] {
                    "admin-role-id-123",
                    "Admin",
                    "ADMIN",
                    Guid.NewGuid().ToString()
                });

            // Insert AspNetUserRoles
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "admin-id-123", "admin-role-id-123" });

            // Insert Employee
            migrationBuilder.InsertData(
                table: "tblEmployee",
                columns: new[] { "EmployeeID", "ApplicationUserId", "EmployeeNumber" },
                values: new object[] { 1, "admin-id-123", "EMP001" });

            // Insert Fridges (All 20 fridges)
            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] {
                    "FridgeId", "Brand", "Model", "CapacityLiters", "Type", "Description",
                    "RentalPricePerMonth", "ImageUrl", "AvailabilityStatus", "Location"
                },
                values: new object[,]
                {
                    { 1, "Samsung", "RT28A", 250, "Double Door", "Energy efficient fridge with frost-free technology", 450.0, "/Images/Fridges/0f189537-b86b-46ed-88b0-697d64518b86.jpg", "Available", "Durban" },
                    { 2, "LG", "GL-T292", 260, "Top Freezer", "Smart inverter compressor for energy savings", 480.0, "/Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", "Available", "Johannesburg" },
                    { 3, "Hisense", "H370BI", 320, "Bottom Freezer", "Spacious design with humidity control", 520.0, "Images/Fridges/1bde2bd0-9345-4868-bf0e-3a568b75b45d.jpg", "Rented", "Cape Town" },
                    { 4, "Defy", "DAC621", 350, "Combi Fridge", "A+ energy rated with multi-airflow system", 550.0, "Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", "Available", "Pretoria" },
                    { 5, "Whirlpool", "WDE205", 200, "Single Door", "Compact and efficient single door fridge", 400.0, "Images/Fridges/3fab2301-7b43-489c-a5eb-a4a84e146a0c.jpg", "Available", "Durban" },
                    { 6, "Bosch", "KDN42", 350, "Frost Free", "No frost cooling with LED lighting", 600.0, "Images/Fridges/4ff51e2e-eb52-464d-9bd0-9b93671b7b1d.jpg", "Rented", "Port Elizabeth" },
                    { 7, "Smeg", "FAB28", 270, "Retro Style", "Stylish retro fridge with adjustable shelves", 650.0, "Images/Fridges/5f3c62bc-b7a1-4099-8453-0562449c1eba.jpg", "Available", "Johannesburg" },
                    { 8, "Kelvinator", "KRF265", 265, "Top Mount", "Affordable fridge with efficient cooling", 430.0, "Images/Fridges/06d99650-49bb-46a0-9c87-479b064e20cf.jpg", "Available", "Cape Town" },
                    { 9, "Siemens", "KG36N", 360, "Bottom Freezer", "No frost with multi-airflow system", 590.0, "Images/Fridges/6c99da3a-7e53-4a54-a4c2-179ba50f4552.jpg", "Rented", "Pretoria" },
                    { 10, "Haier", "HRF290", 290, "Double Door", "Toughened glass shelves and energy efficient", 470.0, "Images/Fridges/7a5c9f14-43cc-4b88-98a1-2cd4f34b355a.jpg", "Available", "Durban" },
                    { 11, "Hisense", "H310BI", 310, "Top Freezer", "Low noise and efficient compressor", 500.0, "Images/Fridges/7a5ef7b8-7c58-4d8e-bf27-3c1c9a911b45.jpg", "Available", "Bloemfontein" },
                    { 12, "Defy", "DAC700", 420, "Side by Side", "LED display and water dispenser", 700.0, "Images/Fridges/8e2d92bf-c306-4688-89f5-019d76a9539b.jpg", "Rented", "Cape Town" },
                    { 13, "LG", "GL-Q282", 282, "Smart Inverter", "Smart cooling with WiFi control", 530.0, "Images/Fridges/7e4c22d6-9a91-4d0c-83db-95856b2a30f0.jpg", "Available", "Durban" },
                    { 14, "Samsung", "RT34A", 340, "Top Freezer", "Twin cooling system for freshness", 560.0, "Images/Fridges/16eaa25a-e6ad-4584-869f-79c59db95573.jpg", "Rented", "Pretoria" },
                    { 15, "Whirlpool", "WDE520", 500, "Double Door", "High capacity with 6th sense technology", 750.0, "Images/Fridges/33b3ec74-7862-44e1-afa0-4c4a42689a9f.jpg", "Available", "Johannesburg" },
                    { 16, "Bosch", "KDN43", 400, "Frost Free", "Energy efficient and silent operation", 610.0, "Images/Fridges/59a41e73-af93-465b-a5aa-f0d7cf37fe2c.jpg", "Available", "Durban" },
                    { 17, "Smeg", "FAB32", 300, "Retro Style", "Vintage design with modern efficiency", 670.0, "Images/Fridges/be54bce5-b511-4946-8f3a-55ae0a65ec35.jpg", "Rented", "Cape Town" },
                    { 18, "Siemens", "KG39N", 390, "Combi Fridge", "Multi-airflow and easy-clean interior", 620.0, "Images/Fridges/dff205af-9cde-4e97-876d-3b9a603e6459.jpg", "Available", "Johannesburg" },
                    { 19, "Haier", "HRF330", 330, "Bottom Freezer", "Tough build and fast cooling", 500.0, "Images/Fridges/45189b3d-8e97-49b3-8c90-47ec9d6db6b9.jpg", "Available", "Pretoria" },
                    { 20, "Defy", "DAC473", 473, "Side by Side", "Spacious and frost-free design", 720.0, "Images/Fridges/2634148d-20b9-40c2-9849-3566df69f859.jpg", "Rented", "Durban" }
                });

            // Insert FridgeInStocks (All 40 instances)
            migrationBuilder.InsertData(
                table: "tblFridgeInStocks",
                columns: new[] {
                    "FridgeInStockId", "FridgeNo", "LastMaintenanceDate", "Condition", "IsAvailable", "Location", "FridgeId", "Quantity"
                },
                values: new object[,]
                {
                    // Fridge 1
                    { 1, "FRG001", new DateTime(2025, 3, 12), "Excellent", true, "Durban", 1, 0 },
                    { 2, "FRG002", new DateTime(2025, 1, 8), "Good", false, "Durban", 2, 0 },

                    // Fridge 2
                    { 3, "FRG003", new DateTime(2025, 4, 5), "Excellent", true, "Johannesburg", 3, 0 },
                    { 4, "FRG004", new DateTime(2025, 2, 10), "Good", false, "Johannesburg", 4, 0 },

                    // Fridge 3
                    { 5, "FRG005", new DateTime(2025, 5, 20), "Fair", false, "Cape Town", 5, 0 },
                    { 6, "FRG006", new DateTime(2025, 6, 11), "Excellent", true, "Cape Town", 6, 0 },

                    // Fridge 4
                    { 7, "FRG007", new DateTime(2025, 4, 1), "Good", true, "Pretoria", 7, 0 },
                    { 8, "FRG008", new DateTime(2025, 2, 15), "Fair", false, "Pretoria", 8, 0 },

                    // Fridge 5
                    { 9, "FRG009", new DateTime(2025, 1, 30), "Good", true, "Durban", 9, 0 },
                    { 10, "FRG010", new DateTime(2025, 5, 3), "Excellent", true, "Durban", 10, 0 },

                    // Fridge 6
                    { 11, "FRG011", new DateTime(2025, 3, 19), "Good", false, "Port Elizabeth", 11, 0 },
                    { 12, "FRG012", new DateTime(2025, 6, 7), "Excellent", true, "Port Elizabeth", 12, 0 },

                    // Fridge 7
                    { 13, "FRG013", new DateTime(2025, 4, 4), "Excellent", true, "Johannesburg", 14, 0 },
                    { 14, "FRG014", new DateTime(2025, 3, 11), "Fair", false, "Johannesburg", 15, 0 },

                    // Fridge 8
                    { 15, "FRG015", new DateTime(2025, 2, 26), "Good", true, "Cape Town", 16, 0 },
                    { 16, "FRG016", new DateTime(2025, 4, 9), "Excellent", false, "Cape Town", 17, 0 },

                    // Fridge 9
                    { 17, "FRG017", new DateTime(2025, 1, 17), "Good", true, "Pretoria", 18, 0 },
                    { 18, "FRG018", new DateTime(2025, 6, 2), "Excellent", false, "Pretoria", 19, 0 },

                    // Fridge 10
                    { 19, "FRG019", new DateTime(2025, 3, 8), "Fair", false, "Durban", 20, 0 },
                    { 20, "FRG020", new DateTime(2025, 5, 13), "Excellent", true, "Durban", 10, 0 },

                    // Fridge 11
                    { 21, "FRG021", new DateTime(2025, 3, 6), "Excellent", true, "Bloemfontein", 11, 0 },
                    { 22, "FRG022", new DateTime(2025, 2, 18), "Fair", false, "Bloemfontein", 11, 0 },

                    // Fridge 12
                    { 23, "FRG023", new DateTime(2025, 5, 25), "Good", false, "Cape Town", 12, 0 },
                    { 24, "FRG024", new DateTime(2025, 6, 10), "Excellent", true, "Cape Town", 12, 0 },

                    // Fridge 13
                    { 25, "FRG025", new DateTime(2025, 1, 21), "Good", true, "Durban", 13, 0 },
                    { 26, "FRG026", new DateTime(2025, 4, 27), "Fair", false, "Durban", 13, 0 },

                    // Fridge 14
                    { 27, "FRG027", new DateTime(2025, 3, 14), "Excellent", false, "Pretoria", 14, 0 },
                    { 28, "FRG028", new DateTime(2025, 6, 20), "Good", true, "Pretoria", 14, 0 },

                    // Fridge 15
                    { 29, "FRG029", new DateTime(2025, 2, 2), "Excellent", true, "Johannesburg", 15, 0 },
                    { 30, "FRG030", new DateTime(2025, 4, 17), "Fair", false, "Johannesburg", 15, 0 },

                    // Fridge 16
                    { 31, "FRG031", new DateTime(2025, 5, 22), "Excellent", true, "Durban", 16, 0 },
                    { 32, "FRG032", new DateTime(2025, 3, 10), "Good", false, "Durban", 16, 0 },

                    // Fridge 17
                    { 33, "FRG033", new DateTime(2025, 1, 25), "Fair", false, "Cape Town", 17, 0 },
                    { 34, "FRG034", new DateTime(2025, 6, 5), "Excellent", true, "Cape Town", 17, 0 },

                    // Fridge 18
                    { 35, "FRG035", new DateTime(2025, 4, 12), "Good", true, "Johannesburg", 18, 0 },
                    { 36, "FRG036", new DateTime(2025, 2, 28), "Fair", false, "Johannesburg", 18, 0 },

                    // Fridge 19
                    { 37, "FRG037", new DateTime(2025, 5, 30), "Excellent", true, "Pretoria", 19, 0 },
                    { 38, "FRG038", new DateTime(2025, 6, 14), "Good", false, "Pretoria", 19, 0 },

                    // Fridge 20
                    { 39, "FRG039", new DateTime(2025, 1, 9), "Fair", false, "Durban", 20, 0 },
                    { 40, "FRG040", new DateTime(2025, 5, 18), "Excellent", true, "Durban", 20, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete FridgeInStocks in reverse order
            for (int i = 40; i >= 1; i--)
            {
                migrationBuilder.DeleteData(
                    table: "tblFridgeInStocks",
                    keyColumn: "FridgeInStockId",
                    keyValue: i);
            }

            // Delete Fridges in reverse order
            for (int i = 20; i >= 1; i--)
            {
                migrationBuilder.DeleteData(
                    table: "tblFridges",
                    keyColumn: "FridgeId",
                    keyValue: i);
            }

            // Delete Employee
            migrationBuilder.DeleteData(
                table: "tblEmployee",
                keyColumn: "EmployeeID",
                keyValue: 1);

            // Delete AspNetUserRoles
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "admin-id-123", "admin-role-id-123" });

            // Delete AspNetRoles
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id-123");

            // Delete AspNetUsers
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123");
        }
    }
}