using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class replacements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tblFaultReports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblFaultReports",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFaultReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianNotes",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 1,
                column: "TechnicianNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 2,
                column: "TechnicianNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblFaultReports",
                keyColumn: "FaultReportId",
                keyValue: 3,
                column: "TechnicianNotes",
                value: null);

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1005), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1011), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1015), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1019), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1024), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1034), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1043), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1062), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1066), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1071), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1076), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1108), "Cape Town Storage" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1122), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1147), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1152), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1161), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1171), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1175), "Port Elizabeth Depot" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1189), "Durban Distribution" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1198), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1211), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1231), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1236), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1241), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1246), "Pretoria Facility" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1255) });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1265), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1269), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1274) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1278), "Johannesburg Main Warehouse" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1288), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1293), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1297), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1302), "Maintenance" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1322), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1327), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1331), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1336), "Available" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1345), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1349), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1354), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1358), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1363), "Pretoria Facility" });

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
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1381), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1385), "Johannesburg Main Warehouse" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1395), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1400), "Available" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1409), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1413), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1418));

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1426), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1432), "Cape Town Storage" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1442), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1446), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1451), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1455), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 7, 12, 16, 1, 53, 461, DateTimeKind.Local).AddTicks(1465), "Durban Distribution", "Maintenance" });

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports",
                column: "CustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "TechnicianNotes",
                table: "tblFaultReports");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tblFaultReports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFaultReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4634), "Durban Distribution" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4690), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4695), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4699), "Cape Town Storage" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4709), "Pretoria Facility" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4742), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4753), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4762), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4767), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4799), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4807), "Johannesburg Main Warehouse" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4834), "Cape Town Storage" });

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
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4848), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4853));

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4862), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4867), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4872), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4877), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4881), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4886), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4897), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4914), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4918), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4928), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4933), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4942), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4947), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4951), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4961), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4965), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4969), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4974), "Available" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4983), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4988), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4992), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(4997), "Johannesburg Main Warehouse", "Available" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5007), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { false, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5011), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5016), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5021), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5025), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5030), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5035), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5039), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5044), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5049), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5058), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5062), "Durban Distribution" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5071), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5084), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5088), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5093), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5097), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5107), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5112), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5117), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5122), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5127), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5131), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 10, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5136), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5141), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 15, 38, 9, 545, DateTimeKind.Local).AddTicks(5150), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblCustomer_CustomerId",
                table: "tblFaultReports",
                column: "CustomerId",
                principalTable: "tblCustomer",
                principalColumn: "CustomerID");
        }
    }
}
