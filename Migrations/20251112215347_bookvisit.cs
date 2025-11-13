using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class bookvisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlot",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c424b1ad-9df3-406e-a48e-c727cde6866a", "AQAAAAIAAYagAAAAEJAN+oaA7AR3q8aXMk/u9ikbUdPlUFxRyNh2N8pf8G2iSDgLoSx8rgzLbV1i9HIMIg==", "2add020a-a533-437d-a201-9bb1295aa282" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "7fed40bb-40de-4943-8dd1-035d4be254e4", "AQAAAAIAAYagAAAAED312uxwoS25F31NkdAv2yv9jO5atBJ27USC6j/fUtTmKbxBXOlOM7BCqvKoO9BFWA==", "33e165ac-b5d8-4e94-add4-28cc131853b7", "380 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3594fae8-2056-4465-a7f2-65e0985aed50", "AQAAAAIAAYagAAAAEP3yYEjKJIx60vViTxoFyvn8cC/TwMh6nV5bO9tpPuWUh3FVJheiLIB3RKr55bfqfg==", "897b82bb-dd6a-4a79-9e4c-cd913c10bf52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84ef4956-a4a6-4b57-95ad-fcf59b643a96", "AQAAAAIAAYagAAAAEMT4DwK/IxTvuUb8V58n8RqENV+OyUajFP910gVauMzUMPwbOimTtzI7iafdbz89Wg==", "af6ec02b-d59b-491b-85c1-c42240f8541e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d780afe-f055-4c08-be8a-15c2e62f2bdf", "AQAAAAIAAYagAAAAEIAcJjEReSvMVNcw+dmCaNcZwMqEq622Ti7TVn0L4/7/vpVr+I8JrmaTScU+fjrgLA==", "e5ea16ef-cc45-405b-b828-2b9e4ccb766d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea3d1849-c7bf-4432-83a3-e333a263d583", "AQAAAAIAAYagAAAAEB/fHvwnUx9zF23n1JItO0zjOca+qO2U8s4JJulLIuDJ33QZnpsYKC5PcLUdBR4/Tg==", "1bf9f35e-a412-4ef5-8214-89d19867408a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6475d6a-2c69-465e-b882-7dc644362eb4", "AQAAAAIAAYagAAAAENisMAFdnq9UlLbWQf+Bh78hVTUk8bPQ10ESTzWNXlvBQec6VgQt6+CenwkU0JpH0Q==", "b87657da-2d44-4788-8d16-38b3f7b155bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1583c507-12a0-438e-88c7-9714e44c68c5", "AQAAAAIAAYagAAAAEOKOKOz6tjmm0Dr0Bexy3YeQSq0N74YRXYHoaRPEtVDZPkOziZVWuud9QfJcelRGzw==", "995cf4d8-20df-4902-b9d4-fea358b9bc54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97bc8fb7-043e-478a-a7a0-c28694fa49fd", "AQAAAAIAAYagAAAAEJ8R2QrpGNSb7Ops0L4/r74qfZ74fYsdPW/tpuCzgRPsdWAYfuRl7u5UHgFbWs+Ttg==", "b7bd3efb-da03-4ac5-b274-5917a93f4177" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e6508cd-d620-43cf-aee2-ee2b622555e4", "AQAAAAIAAYagAAAAEGzgda9kOl0emrsxmltlsXcPkTbIDYnTZiy7uQ7NpE2fCQm3rymUX5xWjYx38fSzxA==", "21cf16a6-02c6-4937-b965-dc9b44bf47e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4594e662-6210-435e-afe2-1432906c396a", "AQAAAAIAAYagAAAAEGUTZ9xIuKUuDJTkNRF1Hxu/xZxzbRuiL3UXL1cnDN+9in8d93PLEmk7U6VPwGJs0Q==", "ac54f2f5-86b6-4390-9ac7-84199109b818", "675 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "967b35ab-58f5-406a-901e-fae61ec32550", "AQAAAAIAAYagAAAAEBdt8EyDY22mceJb5A8lSW8hMrtfmSuRAP5VdEfRkePxUjaXgAiQS3MsOUQ32lQqSQ==", "a04c1b04-1bb5-41a6-9a04-8cd5d0fba51f", "400 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "dece3335-e3f3-46ca-bac3-4563b874f460", "AQAAAAIAAYagAAAAELu3BaQuCKfflp4whnXKOeleNi6P2WC/s79KaKlKHfJQT9OnB31SpJ3vYBbOGdKmqA==", "f7c297fe-0449-4c44-a51f-2733ff4e1545", "478 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "fba1f363-bdbf-42f4-855f-a573ce1f34b4", "AQAAAAIAAYagAAAAELKXwfNcO0wZvE7Jt2+/IFh8P//fBQdIeSHQDkLVR3y9Vh/xKFWurZqGKrIjMh6apg==", "d5dd245f-0b86-479c-b79a-b6910718a5bf", "125 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "604f4bd6-1892-4f21-88a0-435748e09f61", "AQAAAAIAAYagAAAAEFhvb4Cmzcl75mzoTW3NXRz07BqA+MXJIeTtnl73LhEgcSY/ejLItJzLHe2XQGfTog==", "7460c3f7-105c-4fb8-82e3-37374b5d1a8d", "447 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "eb748441-e472-40cb-8353-37c32fcadd1a", "AQAAAAIAAYagAAAAEGmB5V6m1B8rJaK3sYngeH68Wc3krvVnv20JIXOXYxf1ml7RmfnNW/ca8m98URj0sA==", "460c9902-0c1c-4379-b55c-d789ab643b92", "376 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "ee598923-08d8-4e6b-a086-a94920e3f538", "AQAAAAIAAYagAAAAEB5sNszTOR99uGdUJWtN/gMj8uGkd14lzViCLWjOdPWAx/ZAJrpJXlt0K6lBASIiag==", "d84a9963-d5f3-4b33-914b-9735b509b788", "883 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "0b8abff2-c4d6-482c-a8e5-46e39bf8b188", "AQAAAAIAAYagAAAAEMy+eBKqvNn/JAXFyHg2D0GzCJm7IjfUL5/FP+9s3rKMBL/aQq90uENkKwKxNjvN2A==", "febc2b38-f373-42ee-8915-4113c65bb9fc", "592 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "76b80931-025c-4ca7-8545-29dc99c10c3f", "AQAAAAIAAYagAAAAEM6ePjadtVHJJa6CK6Jqtu7jvvpH3Wn2ADcxKszjEaYxLvdUuj1Eu0jHNq9TnkDqfg==", "5504275b-e56c-48a3-9f65-0816a8124d9e", "227 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "23195e4b-32f5-4c9f-95bc-8c1e73101ad6", "AQAAAAIAAYagAAAAECcfcmmdlWcZgROCxZUz0LSIZOkee23f69oxoKVm8cUN9rgwlXXPl9bYcALDcHGyUw==", "1508965d-d0ed-4b11-8720-f0ae0a483c39", "600 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "d432f4f4-22bc-4707-a9e3-1039c2f57857", "AQAAAAIAAYagAAAAEE8Vazmt1jzK4dNG7g0VSR5ridCLyKLqCj150qIHqEk+vCYQ28ioJztWlFqdl1AgyQ==", "1851ae36-153c-4341-b83f-b61139851350", "282 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFaultTechnicians",
                keyColumn: "FaultId",
                keyValue: 1,
                columns: new[] { "ScheduledDate", "Status", "TimeSlot" },
                values: new object[] { null, "", null });

            migrationBuilder.UpdateData(
                table: "tblFaultTechnicians",
                keyColumn: "FaultId",
                keyValue: 2,
                columns: new[] { "ScheduledDate", "Status", "TimeSlot" },
                values: new object[] { null, "", null });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2493), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2560), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2572), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2576), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2583), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2587), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2591), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4091), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4122), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4130), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4135), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4139), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4185), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4194), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4199), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4221), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4227), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4232), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4237), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4247), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4252), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4257), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4262), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4267), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4272), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4277), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4289), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4311), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4316), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4321), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4326), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4344), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4349), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4353), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4358), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4362), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4367), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4376), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4380), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4385), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4389), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4394), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4398) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4403), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4407), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4430), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4439), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4444), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4448), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4453), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4457), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4462), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4466), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4471), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4476), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4481), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4486), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4490), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4495), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4504), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4508), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4514), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4523), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4528), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4532), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4537), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4542), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4546) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "TimeSlot",
                table: "tblFaultTechnicians");

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
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7037), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7071), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7081), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7085), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7098), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7102), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(7107), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8419), "Cape Town Storage" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8456), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8460), "Port Elizabeth Depot" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8654), "Pretoria Facility" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8667), "Maintenance" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8693), "Cape Town Storage" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8703), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8707) });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8717), "Johannesburg Main Warehouse", "Available" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8726), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8731), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8736), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8740), "Johannesburg Main Warehouse" });

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
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8774), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8783), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8788), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8806), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8810), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8815), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8846) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8851), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8855), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8860), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8864), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8868), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8873) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8877), "Durban Distribution" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8890), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8894) });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8904), "Port Elizabeth Depot", "Available" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8912), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8916), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8921), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8925), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8930), "Cape Town Storage" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8939), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8944), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8948), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8957) });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8966), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8971), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 7, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8980), "Port Elizabeth Depot", "Available" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 10, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8988), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8993), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 4, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(8997), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 18, 33, 19, 122, DateTimeKind.Local).AddTicks(9001) });
        }
    }
}
