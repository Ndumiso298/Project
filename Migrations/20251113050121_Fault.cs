using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Fault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFaultAssignments",
                columns: table => new
                {
                    FaultAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultReportId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultAssignments", x => x.FaultAssignmentId);
                    table.ForeignKey(
                        name: "FK_tblFaultAssignments_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFaultAssignments_tblFaultReports_FaultReportId",
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
                values: new object[] { "ce4de4af-5dd5-4d11-a875-888c6c8e313c", "AQAAAAIAAYagAAAAEGaHM2b+0xiPSlJk1c1Cd/J7+uwNngdi18FZvAd70RK93VJWFZcvdk0JAvqB1KhPbQ==", "a6f8e31c-08ec-4d0f-adbd-b8a493fda8fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "0c1ff320-8c25-4c26-90e0-87301726d79c", "AQAAAAIAAYagAAAAEPTjbr9hKq67LUyR9PrUEH7TUQEagPdwmcLgoCDquXXJbm7Fae8UI3D7nWf66GhtYA==", "d68da35c-bc8e-4323-a22b-fd9b1afeb51e", "369 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34968ab5-3996-46c4-83f2-cecee15e8fba", "AQAAAAIAAYagAAAAEEYiQe6HFWoO9+b+oLS5fkZxnSW1m0rSpiajZrDiqD4+2eQBnevdUZCkny6cjAiYjw==", "fb0db2e7-cf5d-450a-9ee4-a406f97eaa81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df334615-1a28-4515-bc66-a621600df297", "AQAAAAIAAYagAAAAEFVDQgI1MUHHt3FJV+F0/7mI0Rol/W/gIvgtgvpADFnTY3Ph5VEWGHydciOwCRvAAA==", "d6794aa2-9992-4fe9-9b0b-00abd08fabc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca68953-5017-418e-9b39-dadd0b868a8b", "AQAAAAIAAYagAAAAEAl8DmEC5lbFWpSV7Cahrb+bMjgpqRen/5yDM8+HO4r+2y7+U2k/t9/wiD/s9VlUpg==", "9818a1da-be9b-4b44-8ecf-c6e108726f28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fe8a697-6879-478e-bd51-f1b79809a229", "AQAAAAIAAYagAAAAEJ7gazk8FnRqqmKsDj5GbDmt15k+gySXDKY7lfV24E2Mu0HSVlYAgtWyydK+hvf0Uw==", "b90e8b54-e44d-45bd-80a2-c9776928a459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60617895-927c-4399-87a2-e529b062d7d5", "AQAAAAIAAYagAAAAEA0KCRRE6cJae/suELv/kQSma7pd9GqpsYCMIKsSGX1w/k4f6m6MpOyTwirXmma7oA==", "29024c6c-65b1-4a05-8442-46bb0a396412" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97211723-06ff-4c6b-a50b-a59e7550632a", "AQAAAAIAAYagAAAAEBKWYUuRTRUswszMjOy6NDKorExoQGR2L2PP3lId2USmdrcRfe11AMVMl8aVVmqD+g==", "cd85c6be-b2a6-4d3b-8fd7-1509264be781" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36e7ee1f-89e1-47b2-bb5c-e1d185af3e5f", "AQAAAAIAAYagAAAAEE1JIN/V5WKDi4HJOusCH+qt57OG5zeoSe2++mWyzp1eVmhNvz2n+XOfbjjhrAyvXQ==", "8f15c54c-3f0a-4939-98bc-3776e1dbde0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3abbc17-d044-45b8-b0f8-5063d1a8ba83", "AQAAAAIAAYagAAAAEA0yBnywkFolXLlBAgyw/ql6scloGREokicmzNes7lhF3if+ZOdknlgOsEShgzea+g==", "70418101-fad0-46c8-8b87-70536cdf6384" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "9db1ebc1-5b2a-46e1-b2c7-28b82a776929", "AQAAAAIAAYagAAAAECt3eMf1+Igic5EyrS8V7/3y87S3olEW9opzIEet4TSwVKXmbcRiLVsNns6dpjG4jQ==", "b2417599-5c0a-4d62-97c5-3a61c7f167fb", "699 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "a3b51c40-7a34-4591-a588-f15e5903b4d9", "AQAAAAIAAYagAAAAEEV4eosSJyG8tZVgJePd/Gb2fGh8w8oUZO2ZVNUCPCVqkgiRWXF41nQWNKiEELxHSw==", "5f3f596d-9f0b-4b5b-8900-9bbc5ce85d8f", "925 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "67c12ce1-4e29-4f20-8607-b250e650826e", "AQAAAAIAAYagAAAAEJ9XBuTmqdjlrkokvjZGnrZ79k3JKZHWGH8L3mbaVb2xsX4Uzaokr/lfFQ31uMCw7w==", "1fa7f653-1b76-48cb-8c54-ef99150bfacd", "385 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "4a31052e-c23f-4599-9f39-a6016361944b", "AQAAAAIAAYagAAAAEFpiWV9GElnNbSsKYoAFV2GMxJwkwBA386pzwqJTmU66XmX1Geb7MCzstgiwI0dg6g==", "a087f823-9d5f-4236-a690-2d092da45b95", "182 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "89685394-5d27-49de-b8d9-df48875d4e5f", "AQAAAAIAAYagAAAAEIRb7uf9ErcFU7zqWjp+Bj1sQ2ydYTX0brPHEc1DEgLcm/v05Y+ZycTE/dgEBVE8FA==", "26e680a7-8006-4a96-baea-595b9e10bc93", "244 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "99f64d59-c4a2-444f-9dd4-9b9995abc8a6", "AQAAAAIAAYagAAAAEMy/JxuTxp/QTzqAU5T4xGvFJsQcTDEx8I6VoJNKYRQEvBqNjzhshGRdto9V/VxrUg==", "913e174e-3f19-44d6-a436-904ceb8b41f6", "694 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "400a1344-87a7-47f4-a1ca-c3b0e3d4b9e6", "AQAAAAIAAYagAAAAEPIVIh3kM8yG222N6hmvMy+Ju55iyLBxhTHafKjb2bOeyr/cyHtRk50FmPcjr/waRw==", "4edbae9b-dccb-4a9b-a937-ebb0ef0a8fe4", "176 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "a3069b7a-f42a-42db-8474-0339c4df07b5", "AQAAAAIAAYagAAAAEA83lqJEN04MtQhd94H8GGybWvzKiLpl3pXk18r9J7dTELMHD+RL+rR6ReEmKmQZ2Q==", "95e2325a-cad2-467d-9cae-3cbab3a14f15", "341 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "97d4458f-0697-4318-84d5-2ba47a82b463", "AQAAAAIAAYagAAAAEFf6MjZHcC3NzEXQSzmgiU0WmQRop2mYTfoefPNkwqAFd6QSRh6BnzEBizYAyfpzLQ==", "a9b378c2-7b0f-4566-83d1-776e7bf0817c", "575 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "807f1543-2008-4d6f-bb14-2384afa903f1", "AQAAAAIAAYagAAAAEMK9Owz5XC59rkeX+pG6BZThWO0dWZkTsQV7U4qCaxjTiSXyD3kRKDdHtNLfla2wzQ==", "b2002159-2aa4-49ae-bc3e-264990997292", "527 Business Street" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "61c89db6-dfc4-4d78-a74d-6f9dd55d6a90", "AQAAAAIAAYagAAAAEImbqvFB8SFBufJIYtzDLD+VHkp7yI6zhL2xFhTxZNfDJrqJlXjR9Ccf4Cv2RtEW9Q==", "d9e79648-fddf-4aaf-bbdd-d079b69057dc", "934 Business Street" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9411), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9448), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9454), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9458), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 9, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9468), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 7,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9472), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 8,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 8, 13, 7, 1, 19, 580, DateTimeKind.Local).AddTicks(9507), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3324), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3356), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 11,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3365), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 12,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3370), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 13,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3374), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 14,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 15,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3413), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 16,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3425), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 17,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3430), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3450), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 19,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3455), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 20,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3459), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 21,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3464), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3469), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3473), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3478), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3483), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3487), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 27,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3492), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 28,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3497), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 29,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3501), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 30,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3513), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 31,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3530), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3534), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3538), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3544), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3549), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3553), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3558), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3562), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 39,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3567), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 40,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3571) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3576), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 42,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3580), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 43,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3585), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3589), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3593), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3598), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3602), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", false, new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3607), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 49,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3611), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 50,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3616), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 51,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 52,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3625), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 53,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3630), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3634), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3639), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3643), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 57,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3648), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 58,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3653), "Johannesburg Main Warehouse", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 59,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3657), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 60,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3662), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 61,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3666), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3694), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 65,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3699), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 66,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3704), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 67,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3709), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 68,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3714), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 69,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3718), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3723), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3727), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3732), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3737), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3747), "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3752), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 9, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3756), "Port Elizabeth Depot", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3761), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 6, 13, 7, 1, 19, 581, DateTimeKind.Local).AddTicks(3771) });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultAssignments_EmployeeId",
                table: "tblFaultAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultAssignments_FaultReportId",
                table: "tblFaultAssignments",
                column: "FaultReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFaultAssignments");

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
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 1,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2493), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 2,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2560), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 3,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2567), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 4,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2572), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 5,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 6,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2583), "Pretoria Facility" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(2591), "Durban Distribution", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 9,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4091), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 10,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4122), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", true, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4135), "Johannesburg Main Warehouse", "Available" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4199), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 18,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4221), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4237), "Johannesburg Main Warehouse", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 22,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4242), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 23,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4247), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 24,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4252), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 25,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4257), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 26,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4262), "Cape Town Storage" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4277), "Cape Town Storage" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4306), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 32,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4311), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 33,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4316), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 34,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4321), "Pretoria Facility", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 35,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4326), "Port Elizabeth Depot" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 36,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4330), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 37,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4335), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 38,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4339), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 41,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4353), "Port Elizabeth Depot" });

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
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4362), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 44,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4367), "Pretoria Facility" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 45,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4371), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 46,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Excellent", true, new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4376), "Pretoria Facility", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 47,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4380), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 48,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Good", true, new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4385), "Port Elizabeth Depot", "Available" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Excellent", new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4407), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 54,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4426), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 55,
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4430), "Port Elizabeth Depot", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 56,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4435), "Pretoria Facility" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4448), "Pretoria Facility", "Available" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4457), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 62,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4462) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 63,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4466) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 64,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4471), "Port Elizabeth Depot" });

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
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4486), "Durban Distribution" });

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
                columns: new[] { "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { true, new DateTime(2025, 9, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4495), "Cape Town Storage", "Available" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 70,
                columns: new[] { "Condition", "LastMaintenanceDate", "Location" },
                values: new object[] { "Very Good", new DateTime(2025, 7, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4499), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 71,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4504), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 72,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 4, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4508), "Johannesburg Main Warehouse" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 73,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4514), "Cape Town Storage", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 74,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Excellent", new DateTime(2025, 8, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 75,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Status" },
                values: new object[] { "Good", false, new DateTime(2025, 11, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4523), "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 76,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4528), "Durban Distribution" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 77,
                columns: new[] { "Condition", "IsAvailable", "LastMaintenanceDate", "Location", "Status" },
                values: new object[] { "Very Good", false, new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4532), "Durban Distribution", "Maintenance" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 78,
                columns: new[] { "LastMaintenanceDate", "Location" },
                values: new object[] { new DateTime(2025, 10, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4537), "Cape Town Storage" });

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 79,
                column: "LastMaintenanceDate",
                value: new DateTime(2025, 5, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "tblFridgeInStocks",
                keyColumn: "FridgeInStockId",
                keyValue: 80,
                columns: new[] { "Condition", "LastMaintenanceDate" },
                values: new object[] { "Very Good", new DateTime(2025, 6, 12, 23, 53, 46, 696, DateTimeKind.Local).AddTicks(4546) });
        }
    }
}
