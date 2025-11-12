using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class replacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TechnicianNotes",
                table: "tblFridgeReplacements",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReplacementStatus",
                table: "tblFridgeReplacements",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonForReplacement",
                table: "tblFridgeReplacements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OldFridgeNo",
                table: "tblFridgeReplacements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblFridgeReplacements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "tblFridgeReplacements",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "tblFridgeReplacements",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActionBy",
                table: "tblFridgeReplacements",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScrapped",
                table: "tblFridgeReplacements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ScrappedBy",
                table: "tblFridgeReplacements",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrappedDate",
                table: "tblFridgeReplacements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScrappingReason",
                table: "tblFridgeReplacements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScrapped",
                table: "tblFaultTechnicians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReplacementRequestId",
                table: "tblFaultTechnicians",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrappedDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df63b71-6cd0-4d9c-a7b2-e797009ae6dd", "AQAAAAIAAYagAAAAEHgHvnlqPpuE6rpeX4hXf8T7xrdz6xi0ylL5jdzR47S9fQ+ONKIPI+QESJ6wOqkq1w==", "db10e337-bdcf-46b2-b364-410007d2a81f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3c01ed05-08d2-436b-aca1-9bcabb8fd048", "AQAAAAIAAYagAAAAEEZk/qqJEDhHTUISUC+SOAbA/7DnusEyLaUoMjy9shBzT/YeDopiL9zQVJnXL3W2Bw==", "9ede728e-f491-4820-a089-46095b779919", "495 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "116c2f24-f6cc-48d2-81ba-1a9bdabac0f7", "AQAAAAIAAYagAAAAEBDPCbPALk/97Xte+F4RRX2tRdA9IFXCRbQTai9wL7dQOQDZMJr/iNuY/w0BPqVcKQ==", "459eeb01-08a5-4fb7-bbf0-f523d397deb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce0486d0-7be2-4cde-8fe3-b7040d2714ad", "AQAAAAIAAYagAAAAEGLADUmMI9lHLViQIPEa7cN1G2nBT5MAIr94/Pp0NtjfgbpA88hwwUN3lghcf7fMbg==", "646011e3-23a7-4fa5-b1a5-99d3de121b7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1a1cab4-025e-4c21-ae2c-381a0f1b31e8", "AQAAAAIAAYagAAAAEPWmS34CnUcjmePOZPb3FPECUQWjendRNlATiU1DyUEbcp1Bid/twTtbfAA4WrTLMg==", "07162785-d7d0-4689-9b42-ef721f6c5d0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0771b728-9ace-4b57-b480-ea8e6d5b4a13", "AQAAAAIAAYagAAAAEEQGFW7UYl2Sz3hS+IDxQBGP/gjqc/a0PdsieCXYFqK3TkmLvLKXgrYU8SF/0CCSig==", "2c9e3d43-1d97-4843-b18d-22d955e0a226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41857b45-7010-4eb5-9e30-a51ccfb9b204", "AQAAAAIAAYagAAAAEBiGlhpfsCyl3Rr1AzBa1B15VtxJbaU06jmWS+/RVozzudVBFYyhqwQPXLWd6NZyWA==", "3318d107-da0b-46d3-99f4-6f8e06c25356" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6410cfa5-5e87-4a26-8468-1f59a5aae1a0", "AQAAAAIAAYagAAAAEJHFn9wnRC1E2fh55PJdVLMf6m42Ail/Q51VzJNGOYgXj/XLrbfATZFEZWSxSq8w5w==", "8f984029-e50b-4745-9340-4bcdf75ad17f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "143b2201-fcb2-48ca-ace9-f8bee00f2bc5", "AQAAAAIAAYagAAAAEIAqGkT0gKUh9UEd0j2PgpPB6laBaWKFr1rQegCpw4NTNk4lQEDsVASRzCseAepJwA==", "e1f08453-e5c9-4f6a-880a-f2f2f797005d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae40ae9b-5668-41cc-877e-c8438f0f390b", "AQAAAAIAAYagAAAAEG9EqnaRpnGRVScb4FhdPeCXGwvvX2YZFsl4maOsTc9G4Lxe0BDjzwu2oCf0muvD2Q==", "9a98fd31-9db3-4309-a2b5-500919f94208" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "3ad46228-9979-4ce5-9677-22ce147cfcfc", "AQAAAAIAAYagAAAAEL+4vwrcaFoNS8X5L7jxN4hwMEg6PjY0b/i62GgA7QU80FSsevkvQ7vcrXz3c2iVhA==", "a97086af-3a0e-4741-8101-4d9f7cc19399", "830 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "840872f6-c2d7-4cf2-a848-8cc5bb073600", "AQAAAAIAAYagAAAAEK9g81Xcg4rLsMHNH1ar9BAC708YN/BW6VkqqwAJHdGMx89LseR5Spj+c8/c7Oj16Q==", "34d90d1f-744a-4ae1-a432-202b09b48f70", "201 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "c6245e88-1e49-48f3-ac6e-4b045d5fc5a9", "AQAAAAIAAYagAAAAEIf5XGiLjRdmV2afeazgPz+NnAsqRJosH4TVwWtQx3zEZJEAPFGE0DVIz1fAllbvgw==", "2865d5a3-d0c0-45a3-9a49-a0d36050249f", "796 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "c733d4f2-e4f5-4c43-894a-af417928009e", "AQAAAAIAAYagAAAAEN09mIr/fCsQQ7SyjeJSp4XMwXtkWsYKS3UmFJP/HhYs3dyL1MG52l4NJQhSKXi9gg==", "42dd69df-ec88-45b5-afe8-484c73389a91", "969 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "f8c5982d-c2aa-41e3-87e9-a68926dc4d3b", "AQAAAAIAAYagAAAAEPdtjN3VD1Cqd0G3mqpdQ3QqiMYXDuXLkIGwknvg4elwTLfuK9azXt7FqLeSZibtJg==", "54ab3c90-a636-4010-b8b4-81d60ceb5fe8", "945 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "e1ae5e61-4cdc-4348-95d7-3cddb1bb9833", "AQAAAAIAAYagAAAAEPS7kdJFeHEj0mcaJBjefqyZWeS/1OQkYeAXTC4Aqz7b0SXC7giTN0j9mG8F7KuKRQ==", "fe011323-62b4-4212-a01f-edd2a3e7f64e", "996 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "fc99a989-f4e9-40bb-a0ec-5e305e5ab3c8", "AQAAAAIAAYagAAAAEBEiqOnkhkabnWZNUGWLE4uPDOLzyEkXmbM2sbGveBqV7JZHWjBia3BZ9xWzsIO97g==", "a7fdd51b-850e-4afa-b719-38eb1f850a21", "947 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "96c3620c-9e3c-4bb6-acde-0b9c6075e029", "AQAAAAIAAYagAAAAEDq3LkfyNA9NkZlwawYMagANRpETRkMNbaKBzLlVjlV4hKFtv/5FddlP2BAZopJzoQ==", "a9a78e4e-01df-49b7-be5a-f0f8d4f83edc", "366 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "5bf408d7-e60f-45ef-9756-e0dd7e807677", "AQAAAAIAAYagAAAAEEJGt8KNTsfKvPY4ZVAdtt6R4jxz1uyNaMKPLlaRWTf2aSZ1sdfVZAhpNqxaUhTsYQ==", "9c1f23bb-0da5-41d2-8807-e17c1f6046d1", "630 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9c117e8c-7e92-4e1e-b4c6-0ee5876fb872", "AQAAAAIAAYagAAAAEJ9x9dmth01/0JyXFLie449oOPITUdP4s2tQu1VD2XGKc6k/RAHjTd2xL7kOjorq/g==", "960efa37-1001-42cf-883e-b2f8b5278b11", "241 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "8a5236d4-c86d-4936-a6a9-ee4def9f6839", "AQAAAAIAAYagAAAAELDiWWvnMazGcivLHlwSmN1ncI/sHbzcb69mdjZqXEl4xipnhSOG6iWsOhimHqjo3Q==", "6b2cb26e-3cbd-4a62-8196-53c56639f64c", "713 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFaultTechnicians",
                keyColumn: "FaultId",
                keyValue: 1,
                columns: new[] { "IsScrapped", "ReplacementRequestId", "ScrappedDate" },
                values: new object[] { false, null, null });

            migrationBuilder.UpdateData(
                table: "tblFaultTechnicians",
                keyColumn: "FaultId",
                keyValue: 2,
                columns: new[] { "IsScrapped", "ReplacementRequestId", "ScrappedDate" },
                values: new object[] { false, null, null });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4686), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4690), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4695), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4699), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4705), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4709), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4714), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4723), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4742), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4753), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4758), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4762), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4767), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4799), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4807), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4812), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4834), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4839), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4843), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4848), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4853), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4858), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4862), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4867), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4872), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4877), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4881), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4886), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4897), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4914), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4918), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4923), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4928), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4933), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4942), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4947), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4951), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4956), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4961), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4965), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4969), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4979), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4983), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4988), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4992), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4997), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5001), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5007), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5011), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5016), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5021), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5025), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5030), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5035), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5044), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5049), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5058), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5067), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5084), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5088), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5097), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5102), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5107), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5112), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5117), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5122), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5127), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5131), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5141), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5146), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5150), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeReplacements",
                keyColumn: "FridgeReplacementId",
                keyValue: 1,
                columns: new[] { "IsScrapped", "ScrappedBy", "ScrappedDate", "ScrappingReason" },
                values: new object[] { false, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultTechnicians_ReplacementRequestId",
                table: "tblFaultTechnicians",
                column: "ReplacementRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeReplacements_ReplacementRequestId",
                table: "tblFaultTechnicians",
                column: "ReplacementRequestId",
                principalTable: "tblFridgeReplacements",
                principalColumn: "FridgeReplacementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultTechnicians_tblFridgeReplacements_ReplacementRequestId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultTechnicians_ReplacementRequestId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "IsScrapped",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "ScrappedBy",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "ScrappedDate",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "ScrappingReason",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "IsScrapped",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "ReplacementRequestId",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "ScrappedDate",
                table: "tblFaultTechnicians");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianNotes",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReplacementStatus",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ReasonForReplacement",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "OldFridgeNo",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActionBy",
                table: "tblFridgeReplacements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdeb5fa3-2d73-408c-a2a1-0637bb30828a", "AQAAAAIAAYagAAAAEFVEufXJ5BclyhJCMECE+zosuDXz6lhPDVcG+3LIz39kFOlHM/dBuKRGLN82jSveaA==", "979aaff1-f8c3-45e1-b354-4e1ee8a174df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "e7fa47b8-5928-4a3a-9804-c78de25bde6b", "AQAAAAIAAYagAAAAEJD5S/R5R5zDD+CCmxXNQeap2prBpajkLLFDyAyJpiqNA5nM9W7dBNo5Psr4dJ/6mg==", "473f3fb4-0a9e-43d7-a603-5ef3e9236b52", "260 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a985a6b-4e26-4bad-bc99-2f17815243c8", "AQAAAAIAAYagAAAAEPccBIZHWu6of89DRBnFHwMKT7sR2hTbJzizYW5LJbbtcvJyZuMZ7nDMgWeYlXZnpQ==", "86044642-0871-4434-9caf-61e799503357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e0fa8a9-1891-439e-bc64-5d0722c3e82a", "AQAAAAIAAYagAAAAEKejBcbzR/n9EnzjkSa7ZRfKnYRmjeNti9fyRA4swYjJPo/abzACRF/7ExyMLT5qjQ==", "c61ff405-be36-479a-bcd7-7cc4ebcf770b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a037e420-fc89-4bae-9f41-9d7b752c8dfe", "AQAAAAIAAYagAAAAEMefCBvWpGrSHGgk1v1bYtdQQmBtFlJbOSVt4hpxZs/CdEKrbkma3VgUc45XNCxFxg==", "4e566477-4b95-4c63-8e8f-2cd9f76e49c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ec5f3e4-2104-4e40-a4bf-d777049218d8", "AQAAAAIAAYagAAAAEKNZwuiqOKZzZbUtFigoeUhhhkPlIdRGUyNc8H6Aqcelv36KoSnxZYl3/HdjUETuWQ==", "b3cb34ab-63e6-4d65-9bc5-229f24c0d368" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "306ce273-b100-479f-9bb8-64dfa3334d3f", "AQAAAAIAAYagAAAAEPtgBBj458LrRJU6KgesNmQ3BcC3xzq86M51re+GpNmEvJKb2mR87C4pcFucpjB1MQ==", "ff115373-d8d8-4b34-a0e5-8e525330043f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5c8b634-fe82-4de9-b967-d28253edea70", "AQAAAAIAAYagAAAAEONJ7pjEmIiHSFSwNA/pVWczuyNgwEu+p58LwrvTVd0jjdMXtAtzIjNMQrDlLZUZJw==", "01afb52d-def7-44db-addc-e50374624e6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c96c4bc2-1a96-4980-9168-372d386f8bc3", "AQAAAAIAAYagAAAAEJGmhk8KRAuRVJc+KWVvXJq7g1rwtSxv0HH7MWdiPpNGKDNDUu4RKig4l85BaDU0aA==", "c0a98056-46b8-41d8-ab61-62a2d3ea32d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0590dbd7-062b-4984-86d8-e9c7b517e58c", "AQAAAAIAAYagAAAAEBWOgyxYLPKGGEWDQTbQc0Hy90yBOj+LZGzyKkJ6nPT2Sp9bxEHpKZ33OZ4foEfXcw==", "62dba5c1-edd6-43d2-8b27-95a949f87f0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "8ef2860e-17ac-445d-a907-a044d328a35c", "AQAAAAIAAYagAAAAEPVP2jmC0uvPWbbRa4Z13ddjc+ifHIaPmx6vbw+m9jzCMb7wgrSMUROiCSVczrgaEg==", "00b01849-4680-46e2-aee9-df0e6374c038", "734 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "854fcf9e-10b4-418e-a2b6-140d1490f9d7", "AQAAAAIAAYagAAAAEBgDY8kb3MHcLqK8BrIriidCet7RLE5ExZTKDrmIhdckGIQS3aLZF1djKQbX6oUZ/Q==", "3d94c87e-c5fe-43b3-8977-bfc2f0385e65", "223 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "6ac12499-4827-4eb2-9841-d1dd306d88e0", "AQAAAAIAAYagAAAAENk2RjzB6AyMI3SkUukOBev+3ODqzmEJ6Fj+BdohcvOgsttJTMQ9qnpVkPfwxmgmzw==", "cf1850d9-8d36-4fe5-a96c-3ff56e2e66fc", "692 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "079cb88e-caf1-4280-84af-0b8e98116e82", "AQAAAAIAAYagAAAAEFC8a1Pdy6YSqEXwBaMrCo4H9nsBauJDvXGMHEBynNQxIi935JqdJ6lzSkVmI9FuJA==", "d9898c33-c4cd-4de3-a96d-c1e851e7279f", "188 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9e42f370-6838-4e4e-a1e6-1e7370741a08", "AQAAAAIAAYagAAAAEAEe1SNjuGzo2MgPajTmMMxmHCRcZ8/cB3H6baGViYEjN7fRkvzf2XFGghRaSzNwyw==", "95e3db84-ad1c-439d-9d3a-033bfb93d756", "298 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "cbb44667-15de-4a7b-8166-98fa35edcf65", "AQAAAAIAAYagAAAAEJuYt32+YAx3SToK63tT+u5gIyZsz/wgPom6NMeCNqwJ1ZoIAcgkMbnay8QtdeASDw==", "13d8e505-9805-4d5c-b045-5d483f06d2c5", "834 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "e4d5ddee-4416-4031-aa77-133c21070220", "AQAAAAIAAYagAAAAEAG+ZYLi3leWm+bt0LpuHd5Z0XCYQfrbfgUQxvdTBK+ADw8KcuZFQGQGyoPSWybTrw==", "a5880e5a-74f0-47fb-8e4b-2b98693da4b5", "401 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "7e8381cc-fc6f-42cf-b21b-0335448ec736", "AQAAAAIAAYagAAAAELRZNY1MJ8H93DJPlpaPNakI9Qz4baoJMH1uc5somW0Q4e4YtwRnjSfCI1yTtte2FA==", "455148cd-9363-4d83-b466-402920d41ea2", "389 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "06a1cee6-9474-4f22-a0c7-8173ce4c7247", "AQAAAAIAAYagAAAAEMZWR5rDb78YjlV+Tum3wqi4gQ9v3RTJumiWYjMie8zDD/2Pu+crZEdY7ZXPXpvCJQ==", "08a9f52c-d0ac-4b0b-bb2f-4d032bdd45b7", "514 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9fc553d4-1d52-428c-ac2e-dce40677934b", "AQAAAAIAAYagAAAAECUrz1aotS79aL6XX/9WllmsKUQ8Mvh7AbYLFfgye2YWjeIJvP3FhZplQW282zm7uA==", "d6330e56-b843-4a83-bee9-535ac0ee026e", "487 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "2518a3ec-3c42-4dc1-91ec-41cc58da9d40", "AQAAAAIAAYagAAAAEMYFziseU87AQdjad5R9JHtDv9WKKXf0OmRNpNe9ZkKGBpEPSgryFNy42tgilPwE9w==", "0045326c-1763-4486-95a4-4b552d9e10cb", "968 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7452), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7456), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7461), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7465), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7470), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7475), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7479), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9731), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9764), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9774), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9779), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9784), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9788), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9822), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9830), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9835), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9858), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9863), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9868), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9872), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9877), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9895), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9899), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9904), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9908), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9913), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9917), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9921), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9934), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9952), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9956), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9961), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9966), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9970), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9979), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9983), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9988), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9992), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9997), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(2), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(6), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(15), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(19), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(23), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(28), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(32), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(36), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(41), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(45), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(50), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(54), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(58), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(62), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(67), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(76), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(80), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(89), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(97), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(102) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(107), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(111), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(121), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(125), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(130), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(134), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(140), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(151), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(156), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(160), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(165) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(169), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(174), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(178), "Pretoria Facility" });
        }
    }
}
