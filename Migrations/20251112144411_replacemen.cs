using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class replacemen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaultReportId",
                table: "tblFridgeReplacements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InProgressDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReplacementRequestId",
                table: "tblFaultReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrappedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblFaultComments",
                columns: table => new
                {
                    FaultCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultReportId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsInternalNote = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultComments", x => x.FaultCommentId);
                    table.ForeignKey(
                        name: "FK_tblFaultComments_tblFaultReports_FaultReportId",
                        column: x => x.FaultReportId,
                        principalTable: "tblFaultReports",
                        principalColumn: "FaultReportId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 1,
                columns: new[] { "AssignedDate", "InProgressDate", "ReplacementRequestId", "ResolvedDate", "ScrappedDate" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 2,
                columns: new[] { "AssignedDate", "InProgressDate", "ReplacementRequestId", "ResolvedDate", "ScrappedDate" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 3,
                columns: new[] { "AssignedDate", "InProgressDate", "ReplacementRequestId", "ResolvedDate", "ScrappedDate" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8824), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8871), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8880), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8885), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8890), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 10, 12, 16, 44, 10, 165, DateTimeKind.Local).AddTicks(8894), "Durban Distribution" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2213), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2247), "Port Elizabeth Depot", "Maintenance" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2261), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2298) });

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
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2330), "Durban Distribution" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2345), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2350), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2355), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2365), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2380), "Cape Town Storage" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2398), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2419), "Durban Distribution" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2429), "Durban Distribution" });

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
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2443), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2447), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2452), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2456));

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2466), "Pretoria Facility", "Available" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2474), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2479), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2483), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2488), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2492), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2497), "Pretoria Facility" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2506), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2511) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2515), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2520), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2524), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2529), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2534), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2538), "Port Elizabeth Depot", "Maintenance" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2547), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2552), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2557), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2561), "Cape Town Storage", "Maintenance" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2570), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2587), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 7, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2592), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2596), "Cape Town Storage" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2609), "Johannesburg Main Warehouse", "Maintenance" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2625), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2629), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 4, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2634), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2639), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 16, 44, 10, 166, DateTimeKind.Local).AddTicks(2648), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeReplacements",
                keyColumn: "FridgeReplacementId",
                keyValue: 1,
                column: "FaultReportId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_FaultReportId",
                table: "tblFridgeReplacements",
                column: "FaultReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_ReplacementRequestId",
                table: "tblFaultReports",
                column: "ReplacementRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultComments_FaultReportId",
                table: "tblFaultComments",
                column: "FaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeReplacements_ReplacementRequestId",
                table: "tblFaultReports",
                column: "ReplacementRequestId",
                principalTable: "tblFridgeReplacements",
                principalColumn: "FridgeReplacementId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeReplacements_tblFaultReports_FaultReportId",
                table: "tblFridgeReplacements",
                column: "FaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeReplacements_ReplacementRequestId",
                table: "tblFaultReports");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeReplacements_tblFaultReports_FaultReportId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropTable(
                name: "tblFaultComments");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeReplacements_FaultReportId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultReports_ReplacementRequestId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "FaultReportId",
                table: "tblFridgeReplacements");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "InProgressDate",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ReplacementRequestId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ScrappedDate",
                table: "tblFaultReports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "604a40f0-08c9-4b02-9701-5eedc32939b5", "AQAAAAIAAYagAAAAEDtPSKNR0lZ9CwHSvolWVXDEtnbkL4IO5ejPtYRZ7/hnCstf1OWOnWwl/kV7GlbnQw==", "cf251cc6-dbcf-43d5-b001-c11237eb165c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "fa640db1-5380-44de-b6cd-171a6b22fb27", "AQAAAAIAAYagAAAAEHfwZ9e98v3MjHIZIXN3Q8jjkEfDqoZE2flyCNClXplCV8Cv5obK8ZzenMoRBOPEYg==", "b368ef38-464b-4a8b-8008-7ba4fa6e4f52", "348 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50d5cf6e-d614-402b-b75e-04a7e9e740df", "AQAAAAIAAYagAAAAELBYaDMDbNdDgqrCDyXMbahesGLzV8WlxscKD9H10EGVMKwmgWkzor+zYstvqEPZ9w==", "9b67548c-8966-4fdd-b917-dcb6771990be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1502c9ca-c62c-4cd8-949a-b027896e8394", "AQAAAAIAAYagAAAAEPlEvv0LrR4U9eA3ji3gMPhvhWdLoKH1FOGazJu1Un54C4oSDf2jBJE65nPz9xnYcg==", "d36a06ad-2f06-4ad3-9f84-bce2bf3a2758" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f167559-dc08-4648-9784-295e2d9ebdfa", "AQAAAAIAAYagAAAAELP+eNFgABV/O5MoyPcssNKBcsEaui+qUMdV/6iJxhHLOTsrLiHgIs8uYYGME2UkhQ==", "601e4144-e575-42b7-9506-2523cdf4cf9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77aa44e-02a0-492c-a77d-ff55be4442d4", "AQAAAAIAAYagAAAAEG1aJMXSH4MTSM9GaBLfF9g504T0LYkqpW5+dNMGwUFrwfCLl642vzCH9+h7UAXfBQ==", "c821a9b0-34b2-41fb-8869-42a0c44ac613" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ca04a9-72c9-44da-ae04-5036fffea1e1", "AQAAAAIAAYagAAAAEFbUQZzXciy/EBQpX1wLDsGHWsJOEur77aV7B0nwojdC6ggMvwUGacBQdxuyN7gwzA==", "e1cf0915-e866-4882-8d1c-772936d64edd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45dcec9c-cf69-4932-aca8-2895cc04ad1a", "AQAAAAIAAYagAAAAEAWW3M9RQrlx50dKbTjmPShMnRBE9AxfX1JQerx99ROAmJ/W/UkHoPrVt/72l9Hutw==", "ce19297d-fa63-4c93-92ce-9aef49b669a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e1ec102-fd9c-4c95-997d-566d0528daba", "AQAAAAIAAYagAAAAENn/X//oAaV0sa29eKB1LCt16MdejKusKoDSBIgjQ/5Ihum7/0enEJo4jTxuKPYROg==", "51ded0e1-5a79-4a19-808e-719696e38dd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ee86f99-a04d-425d-912c-e3a5e3972cb2", "AQAAAAIAAYagAAAAED+5sOONljZUeJsHbQBWYLaV/quwUh3AxJabLZG2NM253EbLG1GmnBamjk7BnNCB9A==", "78993a2a-74ea-49bd-af6b-81e92e747516" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "f212f244-38c5-4e72-8f69-f35d4d7ca7cd", "AQAAAAIAAYagAAAAEKxiSNFr/NBX72Hdgj6lC801rgCOENp1yJ5wgxl99Elpmkox6D+vs69exaHHGrg3WQ==", "37d0112d-7e01-4c8b-a587-55881c6cf1c0", "985 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "5a84bc36-6c23-41cc-868a-67a84c909e71", "AQAAAAIAAYagAAAAEB7a6F+kfJouesybNowCYPf0LU0fpNOydBJCDBzvMk/ytKGjU+nUdpAkT96W2fzbJA==", "4427b5d6-d5a2-41e0-bbed-613e1e8676d3", "873 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "e4e95f65-8602-4ac3-930f-dbecc5bb7471", "AQAAAAIAAYagAAAAELDN4O3YT3XHfztOWjTrkJXmF/Wqq3A/Lo6HXmkD7rKlk2z6C+D58W8aBtWHunDfTw==", "1dd3254e-fdb5-49f1-a453-6c5ff61e6a32", "184 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "d5fe0990-3029-48be-81a1-53ebb27a5593", "AQAAAAIAAYagAAAAEDid31YVkVzHo8JHJrOvy97/LdKpxyk79HHMN8umqlfkMweisMdLSKL5jtuAafx8ng==", "4033eba5-f554-42eb-bf59-bcff25d435ce", "201 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "480a7279-fc84-41c8-b5e2-faa34813f258", "AQAAAAIAAYagAAAAEEW/3xnmykZa3i7utH6iMW5WF7kmaiWCHAcPQU20ytAt7ihDB+kKe9bYZNa/pdzAjQ==", "894caf29-3f33-434c-9c1d-aed514b03a9e", "778 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "b761051a-898f-4a4e-b0f1-3ba7a2da8504", "AQAAAAIAAYagAAAAEE7iQZPUY+nOEOguHAQZsTQmSHo0lTmqR60UOWa53tVG6/CjqmqSpcgXmzrTu99HjA==", "d2b602e9-79f2-4b27-ae26-b45dbc31568a", "765 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "1aae1c65-30da-4ad3-8a12-45402a2e6448", "AQAAAAIAAYagAAAAEN9foGtx6yqmW1fmtJJxum9JPNks7ptsjKYzF1WbvNHLId2LFAGBNKSJEuKwRKXRtA==", "843f11be-c03a-46f8-b807-b067d38e12c9", "933 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4b7fe30e-4e01-4307-ad23-1ebc515e0ce6", "AQAAAAIAAYagAAAAEPGNii8n6r4U5KCvcr0l0zlGneilIln2r3X1DeEAuhaqYt6YvhJhp655rODjnMlftA==", "0ed96b09-4f5c-4fd5-af21-364ecba8d16f", "522 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "e677e8f2-6bf5-4795-8831-d5bee7e86a05", "AQAAAAIAAYagAAAAEHIbcJj5ioUtbpTY+s/BthcAgw5uHY9x2IWXdyDbBimX4Z+zT1CMZxJ3m8bTklJ1/A==", "a4623367-ef64-4a9b-b3fc-060e0bf58b1a", "226 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "f82ef5a2-d183-4f95-a604-3ff2131d28f5", "AQAAAAIAAYagAAAAEIuhcyj0z763vOd1o03Bjuryr8uB/2YNXdMrquKtMYEI6ZrCJbcSIAGrWatDCuVKXQ==", "eb7e8bee-ae7c-40be-99fc-e7955e1523d3", "381 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4c17956b-f348-4466-a4d0-c091627ab03e", "AQAAAAIAAYagAAAAEDsTVJzVVC4YlUgB6IZP0CQp4HmRysZZFhZcd1fTnB/GuyMCM0rPKX2rnq3bmzzykw==", "c024d545-3f78-4b4a-aead-876e2f9d57f2", "975 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(950), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1011), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1019), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1024), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1029), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1034), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1043), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1052), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1062), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1066), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1076), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1118), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1147), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1152), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1157), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1161), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1166), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1171), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1175), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1180), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1184), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1189), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1193), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1198), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1211), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1236), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1241), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1246), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1251), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1255));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1260), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1265), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1269), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1283), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1288), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1293), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1297), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1302), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1313), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1318), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1322), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1327), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1331), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1336) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1340), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1345), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1349), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1354), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1358), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1363), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1368), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1372), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1376), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1381), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1385), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1390), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1395), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1404), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1409), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1413), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1418), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1422), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1426), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1432) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1437), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1442), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1446), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1451), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1455), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1465), "Maintenance" });
        }
    }
}
