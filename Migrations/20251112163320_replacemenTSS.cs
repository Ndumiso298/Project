using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class replacemenTSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a02c77-b280-424d-ae70-16b3c301e6b6", "AQAAAAIAAYagAAAAEMIRDKOLRZb7C5321PLSLKtehrpq7XDrVjwnoVjqHs/9dxBVEdERAJRvk74EAotVyQ==", "721d02f0-b589-496b-b036-509fc9df6a44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "839ff175-d7c7-45ba-b8fd-fc9d6d497610", "AQAAAAIAAYagAAAAEO49F7wmi+Z870Z5akeEbLNFlY/ktU8nVr/YAHQcVcwUNMjSOxspiw1qn+FjOZWEmw==", "25dd6478-d5b1-49e4-a199-6fd5c8c64ada", "711 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "213395b7-ad5e-4431-b3d6-61be7b832697", "AQAAAAIAAYagAAAAEBS5yEcDDw3gF0j7fQny7Zb1vJviTjIsxklujz7lM5u7bVvJ8sIceK98jwsWWn45eA==", "2c7fd9d7-6b92-4d5c-89ca-27e1f4dec5bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "009306d1-abe5-4ead-83b6-fc365d648ab1", "AQAAAAIAAYagAAAAEOvQQlMaB7QTCBPyCni67XIiaf/xcN1CP8zWoARrzP8wPHAAOvryYvIlxSvn+a/veg==", "6c508602-7031-410e-b703-ac27c61b9643" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "beadab7e-fd80-47a5-b049-3836be738d8a", "AQAAAAIAAYagAAAAEPl3LekjTE7t75Ypnthl0gfShL521CIxBEqkDmHi5BtK2VSJjkcVgvT3t2egPma+Ww==", "e0cf8007-aa89-427e-813d-c53d8ca593b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3a15988-3d8c-4cc4-940b-6b2f3aef8e38", "AQAAAAIAAYagAAAAEIpiXCJaDRzQfK71QYgx9nWYTl1k24qJ+5u9jUWUuMlOjJy9TafzCpqxGBpQlnCZ2Q==", "8d9d996d-71e7-4804-9cd7-c42e826fab7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc504158-33cd-44dd-b440-a8e8785be800", "AQAAAAIAAYagAAAAEMuVVAk/FnLm1LbXXSlflh0tnwtLWChHQ6RQNYwPuxHGwo27PQ05zjS64vf08US8TQ==", "55da6959-eb60-423d-a7ed-342473a2f9e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85182b15-0f0f-44bb-b3d5-941549e9f115", "AQAAAAIAAYagAAAAEFHW83+zn9VkBZfU2bhYKVLfOPaR07S+agQkfjSitFj7HqnkdTl72WGhVyUdv9mJOQ==", "4898cde5-2790-443b-af76-f3a5dd4b761c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "629d55a3-48c4-4b50-af47-d7d2c7cc52d0", "AQAAAAIAAYagAAAAEHIq44PARrG69ZTV/6jDN1o2h52y6+nSQtrB0ou4X2frDmnCOO+FrLGYG+rtd0D3nw==", "0a7cd993-e177-4a03-98f0-f84be15180eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58488a62-f73f-4c17-bd79-5d85836eb3a2", "AQAAAAIAAYagAAAAEFkJImYOeV6piT2FzNVrJtGAAc8B0PVTWU5VMrMrnQVuIFZbFuR9nYLJsxuCmusI5w==", "2e0e8a94-3662-4019-8686-e8459a632a31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "db0ebc31-8840-4826-b004-cbd1ac38f6b2", "AQAAAAIAAYagAAAAEANRlVB4IsFgESaau3wvh709hfyQkEazvUT5CS+6ugkuvuHmnTwsoYXOL/5k+xbzLQ==", "0d463ae9-a32a-4092-8585-8b9f840bb707", "737 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "68d8c959-1c57-4141-955f-8df028e99ba6", "AQAAAAIAAYagAAAAEOZjYMhpexcT17GdXwdHj8RsZt1Q9mNeFRwPCfNGYwYqJkcMoeXisDXN8erD7oGzUg==", "bafe828b-e0a5-41f3-9a8b-0eeaece37c1a", "632 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "eff56792-b5bb-4c60-8186-44862d7137b9", "AQAAAAIAAYagAAAAEJWPPtnA3pqi3fNaHx6USxul5GlQZQJQKmghrZNZQ3YDoOiY7MMPIa+w1XpBrU4cPA==", "d002fc52-8847-459c-9f39-acd3dadbdbbd", "980 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "a9a70a18-61de-42d5-bff1-0168a31f02a5", "AQAAAAIAAYagAAAAEEea0VS48X3s1RMpKCeYKwrXH69n2t5CCzvFgm4XipY9dfPAnit/GZ0mLrA8athWIA==", "a3885b7c-f722-4ea1-90f8-9333c629aa47", "669 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3cb6a456-e491-4430-8324-04b4e830b375", "AQAAAAIAAYagAAAAEDXcEqRpCuOlFnJHNiwQjkx5O7fA7m1tGjtOsSRzeXyNXlBuQUh6jETEY92nPAR4BQ==", "2b7786ce-6194-4074-ae76-8cd9873e2421", "201 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "ad3b2ad9-7401-4376-b944-c20a2417675b", "AQAAAAIAAYagAAAAEB3r6IjBiL0tlr7tH+srxebxZf/FEAfEVkmjjThcs+IFJ6EQqLkAr0byCpHAhZ05pg==", "5383ac32-9320-4ae8-b52c-84e4e48a4324", "545 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4e648aac-6e6f-41e7-b209-8bb09c11e429", "AQAAAAIAAYagAAAAEId1VjwzsyNiihBTV/6iFYG6xnrtr6xRtKFEbY0VoyRfFe4qVxGroGLsNINHDJoQ8Q==", "cdc4b114-6552-4548-8702-45deec688e27", "148 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "58ee8fe8-5ea4-4d7f-a09a-f33cd6b3576b", "AQAAAAIAAYagAAAAEO4ZIyNDF/b7QYBbo1DGjLTpir2sm0FaU6UrV09n/h5+1crZkElF0LkeXJdWGhNs6w==", "fbc61121-3988-4d19-8bb5-ec5a32b62108", "760 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9356d53a-8df7-42c5-adc8-843af8e23064", "AQAAAAIAAYagAAAAEMnaJKG+nLjX8gzYwUhdxwaTzlvPCTm/05ARr/IUbaBeQH5qyqzbDGwKZxSGsmNZeg==", "720afb43-11a7-4a36-a16d-5c56da7efa6e", "239 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "723e4f3d-e91f-4f9e-9f3b-b48613c474df", "AQAAAAIAAYagAAAAEDS3x6x8iZ2ZiFdF65u+m4LlSwK/rZKTBz+Pq2uNfa5wCdNaKF4FfG1YyZDnW1Wltw==", "28efde7f-8e38-48b1-a783-a5d915cfdec1", "425 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3faabe46-2e67-460f-a3c7-c18c7b8689c1", "AQAAAAIAAYagAAAAEKGkoCMxYIGPsdCqYiFqjPkUwtwuoYiV8yMEQPhSEm8ev1NcR/lahIEYunPGsMdDow==", "6869e34c-b2f3-4705-a8ef-e6698eeaacaa", "907 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 1,
                column: "ClosedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 2,
                column: "ClosedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 3,
                column: "ClosedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7037), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7071), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7076), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7081), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7098), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7107), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8419), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8447), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8456), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8460), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8465), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8654), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8662), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8667), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8688), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8693), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8698), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8703), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8707), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8712), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8717), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8721), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8726), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8731), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8736), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8740), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8752), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8774), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8778), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8783), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8788), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8792), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8797), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8801), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8806), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8810), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8833), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8837), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8842), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8846), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8851), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8855), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8860), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8864), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8868), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8873), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8877), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8881), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8886), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8890), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8899), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8904), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8908), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8912), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8916), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8921), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8925), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8930), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8934), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8939), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8944), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8948), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8953), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8957), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8961), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8966), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8976), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8980), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8984), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8988), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8997), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(9001), "Cape Town Storage" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "tblFaultReports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b756b1eb-dd1e-46f7-86e1-5af67aa8305f", "AQAAAAIAAYagAAAAEDuXF466V7ZUSS/LGfS58tVOxxTRsDldiUvJq3vMMU6EkHP1MDcguyZnjAlOjYmTAQ==", "c7de6fda-bf4c-438b-8848-7f613824e318" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9d879701-3d07-4510-95ae-a3109d518e2a", "AQAAAAIAAYagAAAAEP9NW6weR7/sDFCt6YAo3g9Qz+LnVnIwsP9LaDflrQHk03hN0c5GzGCBFavADolvkQ==", "731735d9-f492-41c3-bfc2-3c135fabcec9", "173 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8664ddf-4ecf-4b3b-9a1a-839d50dad4b5", "AQAAAAIAAYagAAAAEG2cZJvVeHqGJJQBj64M/flQrbM1wZ+UNPEe0s3Kmcmeuj/3iE80kG4OV3fzxOwW9Q==", "39001bf6-f619-4b75-a7e3-e3373c837806" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a87c46d-a343-4db8-88b4-20c921fc8bd5", "AQAAAAIAAYagAAAAEE/ym9x9b3H3zU2OKLFYTgHwL+O+Df0hEC+MDNxURNsUGToWAZzDNYspEzDzKw832A==", "1e91fc7e-244b-4aef-876c-f5c19dce67b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8322d880-fe77-4506-b668-2794fef78346", "AQAAAAIAAYagAAAAEPk6iDPKHJC/PJHJJMBmwuEGjGEeP4ZtqIB2vPvajglpWfddTF1mKPg1VXVZVVLzTQ==", "145b4e39-eb28-4d10-83c9-cb43e1b618cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4449d70e-4eda-4e2f-b150-3452ee451736", "AQAAAAIAAYagAAAAEIPLXmesRyRjWfUsGJJzQHUQUjheL06rSWJfr8FBMs9TvQcXmsqTr5lPsypOiHkRjw==", "e9c5e0e2-d98f-4494-b942-9b34bc3eb772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "922d1858-15f4-44bf-ab90-912226b5d361", "AQAAAAIAAYagAAAAEOgwOVul0QRGimlGWCKV4SndEGV6xjQ/eKVws76t2LpyQUlH4lk0a9gjDdghtuCt7g==", "9420eb2d-a7ce-4f9d-9497-e18b8d35ee0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17fe7648-e4b3-49f7-a792-af5088e47590", "AQAAAAIAAYagAAAAENHUGJWnktHPcJeDlGk0qcu9/WP+n/2b95Qh6hxcvV4tKWW8Viwv8sDiBhCDYbFmdw==", "bf04d130-605a-4ca0-b9f3-2cd26811a171" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ee810f8-0d63-4be1-ad34-4c370731a0e1", "AQAAAAIAAYagAAAAEHVU94Jrrn/+wt1aVk9KfHdL5A5fpmUN5jYKULbk9el4gcsUH6s1G2fcQ1vAtEtnPw==", "e9ebc3ed-65d4-49be-b941-44a5ba0651f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b1f2a8d-4d2d-4f0c-af77-d605cfd97707", "AQAAAAIAAYagAAAAEMKHKhwRGvu2CU+9Dhbnb0EPhahloRmEyHbSdxWtYMZ6QqIAnzYaKHWCnDLozvjtUw==", "2b95da39-c815-4c64-8002-55116db03a42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "546ad491-b13e-49de-a3e3-c596cf09a70f", "AQAAAAIAAYagAAAAEH6GJApupOT9sIQEIpv4kueWr5yYYir+1PsL7quhjGnxGVEaLagLAnEcmkt8gH/K1Q==", "7ca5097e-74d6-420c-a496-d1f187ae994d", "379 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4b35a2dc-5db4-441b-8ecf-ead0673dc32b", "AQAAAAIAAYagAAAAEMO2rTdfvK/DSA7Ixu205ccJvwS6viqkRa0pVXx/L+j0d63HbaoH4P7N+gEUf8UO/A==", "5e351cfe-2da3-4615-a625-fb962e89dd93", "784 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3af0d82b-97e9-449d-bc64-591835dd885e", "AQAAAAIAAYagAAAAEOU/hhQMY+56Cnvvcqawembw/N/9W7yqnOVLDI8Rs0F5xR295d7kq9AXNQ7WEIegAw==", "8d74e62d-562a-476f-8b07-503304e51ad5", "609 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3aa276dd-60a2-4376-8e4c-254a97794875", "AQAAAAIAAYagAAAAEKJl5Q4pNgQRhsBFNoEt1XL7X+3Silbx45lvcKP8sTZhCJjZW1Zb6BZ7TpHVNrmzlg==", "b48343b5-527a-4f87-808a-92a446bb02d3", "369 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "d6a36af6-68e1-4e84-9150-69b15778affd", "AQAAAAIAAYagAAAAENgc72XmvWAuZaa/om3tA7TXm7jP4l6IbD25++UY5A+nTVJtWuCC1E7GSbl/xbCnMQ==", "e4126dac-a4bb-4107-8927-ce2d9edc79fa", "875 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "eb78237c-f5f9-4a54-8c2a-e9697a5b2f20", "AQAAAAIAAYagAAAAECkPNZaevv2xpavEO7KgFu+1PEi3QEPYEK+1CTsPZUXCMIZqZLKTqzjFMDeo7DztCg==", "74b4b8ab-19e2-4acd-8338-e3edd02bc468", "946 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9107c926-52b3-4d8e-af4a-5b2e0f36359a", "AQAAAAIAAYagAAAAECZs3k7mYzeOWGmaq0oL71KScCFe2R20YzhRgT2y1wE/qfe31y79E1mby0295mGbYw==", "5d03ec7f-9d24-4ff0-9d34-bc10c5b572b7", "907 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "d79089b7-c822-49ab-a09c-defbb0124988", "AQAAAAIAAYagAAAAEGRXvrntmo2Fh6cPpS6MYy43g/2ynY/BgH5tX4cEg8kijwDvfIQ0KP/lyfbH8oRLTw==", "522d0df2-0b75-46a9-b288-5e0605bde756", "232 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "ff7a2a85-e27f-48e6-8667-e697c4ab5b98", "AQAAAAIAAYagAAAAEMm7xFZSGl5jhVpT9sUtihFG5uCwSl9PzinV7zDH3vV/Y12hYPXfMKhWdq+jczPo0w==", "5d96f023-be0b-4a6d-a4db-917a2e04a1ac", "255 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "bea0b87d-c592-4d58-b7d6-39b7136f8e1f", "AQAAAAIAAYagAAAAEKTusdTEYm9EHIdvdl9HQJE8QxX0qxjfSDXvt20SGbZRJFSMS85YRQUL9/CsjIjk+g==", "69a4774c-2c18-4e86-aad8-c3c6c9e79a6f", "998 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "74cd6e63-65a1-4f2d-bb20-24dd86123097", "AQAAAAIAAYagAAAAEDCUENDUWV/nT+KUqhfoVD7AdgpPV6rT1ALhiz6azFe0TbIbkqH5a+VECS/oE+jEFw==", "cd23d5f8-3c6e-4e6d-898d-fe2ccb5465f4", "200 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8824), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8864), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8871), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8875), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8880) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8885), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 4, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8894), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2173), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2213), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2247), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2252), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2257), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2261) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2298), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2306), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2311), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2330), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2335), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2340), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2345), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2350), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2355), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2360), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2365), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2370), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2375), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2380), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2384), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2398), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2419), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2424), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2429), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2433), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2438), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2443), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2447), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2452), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2456), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2466), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2470), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2474), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2479), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2483), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2488), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2492), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2497), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2502), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2506), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2511), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2515), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2520), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2524), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2534), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2538), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2543), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2547), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2552), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2557), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2561), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2566), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2570), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2582), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2587), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2592), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2596), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2600), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2605), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2609), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2620), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2625), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2629), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2634), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2643), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2648), "Durban Distribution" });
        }
    }
}
