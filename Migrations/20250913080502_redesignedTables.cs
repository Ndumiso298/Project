using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class redesignedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6fa8536-7bfc-4d42-a2b6-31c50e07be67", "AQAAAAIAAYagAAAAEL+iZZ730uyuwUjOwe/v4zHoCgz3aWlD0pziWU/0Iyq2TcAeqOvUnl+5SNZyMk+x6g==", "b8440a2e-c8d8-4d4b-9a10-9491c1c08706" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9058c6e6-01bc-429f-ad8a-dee9c77915f0", "AQAAAAIAAYagAAAAEMndaosA1dkmw2eT82TAmm7TGMcxQqCn+f8iFWBs/RJdoQJnN7Wq765xSp94BDoINw==", "51cdc108-1363-4b7d-82af-02a81f2022bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b78b4ce-cccb-44db-9311-b42954badad7", "AQAAAAIAAYagAAAAEF6OX/mpW+LfRpk/oEMCPC00S/oru8SY/M+HlAjIbEyAzRRV0INEWL9zZsUbybCqRQ==", "a05f7e10-cfe0-42b5-8033-9490d8730919" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3948cd1-d6f4-4295-b45d-2597d0c46fb5", "AQAAAAIAAYagAAAAEALq8ESRxSMicYEa9t4Lq3sQ8xtfhX7L6MWr1w55kdVa/bYtWflu4zFAki0hvJF6Yg==", "1f5390c3-332e-4f0b-8214-80e3d358d9f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b17174f0-70e7-4b4a-9243-f557d5ad0efc", "AQAAAAIAAYagAAAAEGLZPeLp2ANlBefb1tSE+ybkwSMpMVTjWG9JMJxdOLb/ZLnLPToblLL4HUX92wvn4A==", "2007f6ac-1423-4966-b091-057bc8aa38d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2275222c-7677-4225-94e1-797931100ffe", "AQAAAAIAAYagAAAAEDugtLFdt6BHfHkPgG8zWvS5cULX4IrLQaKqJSJNN1KNqdaswi2wRCGS8W8a5+H+zQ==", "5055ec7c-c6d4-44fc-9c3a-8b45d139c6ac" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmployeeType" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7341), "CustomerSupport" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EmployeeType" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7437), "StockController" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EmployeeType" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7492), "FaultTechnician" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EmployeeType" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7581), "MaintenanceTechnician" });

            migrationBuilder.UpdateData(
                table: "FaultRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedDate", "CreatedAt", "ReportedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8257), new DateTime(2025, 9, 10, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 9, 10, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8256), new DateTime(2025, 9, 12, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "FridgeAllocations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AllocationDate", "CreatedAt", "ExpectedReturnDate", "LastServiceDate", "NextServiceDue", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8020), new DateTime(2025, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8038), new DateTime(2026, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8022), new DateTime(2025, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8023), new DateTime(2025, 11, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8024), new DateTime(2025, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "FridgeAllocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7700), "Images/Fridges/beverage-cooler-886lt-double-door-sliding.jpg", new DateTime(2024, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7685), new DateTime(2026, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7708), "Images/Fridges/single-glass-door-freezer-carbon-edition-.jpg", new DateTime(2025, 6, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7706), new DateTime(2028, 6, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7712), "Images/Fridges/beverage-cooler-730l-2-door-swing-door-.jpg", new DateTime(2025, 7, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7711), new DateTime(2028, 7, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7711) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7717), "Images/Fridges/za-t-style-french-door-see-thru-door-rf71db975012fa-543388220.avif", new DateTime(2023, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7715), new DateTime(2025, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7723), "Images/Fridges/single-glass-door-freezer-carbon-edition-.jpg", new DateTime(2022, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7722), new DateTime(2024, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7727), "Images/Fridges/za-rs90f-f-hub-rs90f64a2ffa-545559499.avif", new DateTime(2025, 5, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7726), new DateTime(2028, 5, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7732), "Images/Fridges/display-unit-fridge-salvadore-csunk-azelio-1200mm-.jpg", new DateTime(2025, 2, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7729), new DateTime(2028, 2, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7731) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7732), "Images/Fridges/juice-dispenser-3-bowl.jpg", new DateTime(2024, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7734), new DateTime(2027, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7738), "Images/Fridges/wall-chiller-35m-single-glaze-unit.jpg", new DateTime(2025, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7737), new DateTime(2028, 8, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7738) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7742), "Images/Fridges/double-glass-door-freezer-carbon-edition-.jpg", new DateTime(2025, 4, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7741), new DateTime(2028, 4, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7741) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7746), "Images/Fridges/za-4-door-french-door-beverage-center-rf29bb8600mtfa-533983040.avif", new DateTime(2019, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7744), new DateTime(2021, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7745) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7895), "Images/Fridges/wall-chiller-35m-single-glaze-unit.jpg", new DateTime(2024, 12, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7893), new DateTime(2027, 12, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7900), "Images/Fridges/upright-freezer-double-solid-ssteel-hinged-door-shd1140f.jpg", new DateTime(2025, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7899), new DateTime(2028, 3, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "CreatedAt", "CustomerConfirmationDate", "ScheduledDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8319), new DateTime(2025, 9, 3, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8321), new DateTime(2025, 9, 7, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8317), new DateTime(2025, 9, 6, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8311), new DateTime(2025, 9, 8, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "OrderHeaders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "PaymentDate", "PaymentDueDate", "ShippingDate" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8155), new DateTime(2025, 9, 7, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8175), new DateTime(2025, 9, 12, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8175), new DateTime(2025, 9, 8, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "PurchaseRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RequestDate" },
                values: new object[] { new DateTime(2025, 9, 10, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8362), new DateTime(2025, 9, 10, 8, 5, 0, 989, DateTimeKind.Utc).AddTicks(8360) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b9a8eaa-260c-4570-aa0d-1cc62fee0824", "AQAAAAIAAYagAAAAEBLOy9upQrFWzEeDlPvdVPZ8aESx723F1EFEqv+MQZkVPhvknyomWEL2ZrRq4krZ2Q==", "234a79d3-a76d-4726-bf1d-fd10fae5c297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee2610ca-3e55-4527-83f9-4ab6490e3883", "AQAAAAIAAYagAAAAEMibnj7N4KJ1FnucC7a4Ctnf5kRRXrdedF4EZ2y6H9DDu8bOwB5F5DU9LiQDSd3Cyg==", "7df17a8c-b5e5-4819-aeb0-f93770a8132a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d100879-c12e-4d23-b031-536c0d6a90aa", "AQAAAAIAAYagAAAAED8rHo2FRbhrAsxHeZUI+GFqY3JvYZPBv3FTPHcFYC7XHhKivywzeZpQgs4k3CDcTA==", "e3ba5e53-ef8e-45d2-bfcc-3e29aa8285bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebf60d88-9daf-4d81-ae89-12583c56576f", "AQAAAAIAAYagAAAAEPgSlsu8j2l0nYVs79UHDchLmNTAq5C2M1gdydcFqayMD15uiStoITh8J/3a5ZUY4Q==", "827774bf-ce3e-455a-a312-a486ac213d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cc66766-6e56-472f-9429-f6ec94b4e5c6", "AQAAAAIAAYagAAAAEN6DJ20UOqNgchr8zj/Y9qtg/VBliT/65ZiubP1fU43NhWsMS9HMH9AurHEvpjDxhQ==", "bdf181af-d237-46a9-8787-900705d9fb8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "950c3c8b-b87d-43f5-ac08-2f9a21c91740", "AQAAAAIAAYagAAAAEKKZdNsVpArM4Ud2aGSwbMhmWynEAhCWBn3Wxdi1gUC6blDvM9Zu9W1XqeO+knodKw==", "ead2ff4c-2746-41f3-9569-273fdb1fcfeb" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "FaultRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedDate", "CreatedAt", "ReportedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 10, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3361), new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3362), new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3360), new DateTime(2025, 9, 11, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3363) });

            migrationBuilder.UpdateData(
                table: "FridgeAllocations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AllocationDate", "CreatedAt", "ExpectedReturnDate", "LastServiceDate", "NextServiceDue", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3027), new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3042), new DateTime(2026, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3028), new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3030), new DateTime(2025, 11, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3031), new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3043) });

            migrationBuilder.UpdateData(
                table: "FridgeAllocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2806), "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2024, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2789), new DateTime(2026, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2815), "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Z2xhc3MlMjBkb29yJTIwZnJpZGdlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 6, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2811), new DateTime(2028, 6, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2821), "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 7, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2819), new DateTime(2028, 7, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2827), "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2023, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2825), new DateTime(2025, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2826) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2833), "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmV2ZXJhZ2UlMjBjb29sZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2022, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2831), new DateTime(2024, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2832) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2839), "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8cmV0cm8lMjBmcmlkZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 5, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2836), new DateTime(2028, 5, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2845), "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dW5kZXJjb3VudGVyJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 2, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2842), new DateTime(2028, 2, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2851), "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8aWNlJTIwbWFrZXIlMjBmcmlkZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2024, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2849), new DateTime(2027, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2856), "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8bXVsdGklMjBkb29yJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2854), new DateTime(2028, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2862), "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8ZnJvc3RmcmVlJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 4, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2860), new DateTime(2028, 4, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2861) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2868), "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8ZmF1bHR5JTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2019, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2865), new DateTime(2021, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2874), "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZHJhd2VyJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2024, 12, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2871), new DateTime(2027, 12, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageUrl", "PurchaseDate", "WarrantyExpiryDate" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2879), "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cmVhY2glMjBpbiUyMGZyZWV6ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", new DateTime(2025, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2877), new DateTime(2028, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "CreatedAt", "CustomerConfirmationDate", "ScheduledDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3427), new DateTime(2025, 9, 2, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3429), new DateTime(2025, 9, 6, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3425), new DateTime(2025, 9, 5, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3423), new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "OrderHeaders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "PaymentDate", "PaymentDueDate", "ShippingDate" },
                values: new object[] { new DateTime(2025, 9, 5, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3247), new DateTime(2025, 9, 6, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3258), new DateTime(2025, 9, 11, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3259), new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "PurchaseRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RequestDate" },
                values: new object[] { new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3480), new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3478) });
        }
    }
}
