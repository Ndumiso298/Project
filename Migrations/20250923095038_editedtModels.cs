using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class editedtModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "860df6ec-f63a-44f0-ab78-225f4455de1d", new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7416), 1, "AQAAAAIAAYagAAAAEP8t2JaOVd1EHpUhVAjjppjYhPDHvc6yaOOfvg8t6CAoMT3ZUtjW81mlheeGXrOddA==", "84e769b7-bdf2-4d74-90dc-d06c54102b70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebf5a590-a6c6-41fe-94e4-ba87ae5810bc", new DateTime(2025, 9, 23, 9, 50, 37, 423, DateTimeKind.Utc).AddTicks(1926), 2, "AQAAAAIAAYagAAAAEOAf24zgJ9VDtSdrc399UrRk8fjEF0Pds6dvS7/gqDxjohShHp34E/6MPaakr0xhBw==", "57859401-e55e-46af-85da-baade504fc2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee848032-372b-454c-9e0b-3255872bb74f", new DateTime(2025, 9, 23, 9, 50, 37, 471, DateTimeKind.Utc).AddTicks(3035), 3, "AQAAAAIAAYagAAAAECqpezPBuv0ENyhPUP29g+iJQxLl3zLlF0yuMKyV4uKZVyRFBZjvvj5ArqdAwpmF0w==", "bbd11c86-8a69-4746-91f3-e5b8e055262a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f008fdb-ffda-4e4f-909e-e13cbd7b65ca", new DateTime(2025, 9, 23, 9, 50, 37, 519, DateTimeKind.Utc).AddTicks(1645), 4, "AQAAAAIAAYagAAAAEGgDF+lp6Yq2A+OXm6yZpF3sZEsRCo49BF6RLqiltS8jiSyjV5U8D267lD+r5E2C9g==", "4cbfc0ad-2fda-47b1-afcd-c5b1e9ab8b1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18f09338-7ddc-441b-982b-f2ee5b95f1f2", new DateTime(2025, 9, 23, 9, 50, 37, 566, DateTimeKind.Utc).AddTicks(7778), 5, "AQAAAAIAAYagAAAAEBLy7smkVbNU9xxbZrTzF1+nUJ20GWWtdlBHJHopLXVzUvX1crgVA1JAFdoM2hzNFA==", "163a9266-d076-4731-b9bb-ddc4d098cb9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CustomerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d09bc1-29e1-49b9-b1d8-5451cb043c06", new DateTime(2025, 9, 23, 9, 50, 37, 614, DateTimeKind.Utc).AddTicks(3399), 1, "AQAAAAIAAYagAAAAEGyWwpSyVIXP2VnxK5uw0+VJ+qT94SO6P8Kkkyy+jpztg54jVV/DJ/aLqasYCmDBvA==", "ad4af275-190c-429f-acde-37deb1bc9139" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CustomerLiaisonId" },
                values: new object[] { new DateTime(2025, 9, 23, 9, 50, 37, 662, DateTimeKind.Utc).AddTicks(4547), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7343));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a49fb43-2b6c-4c1f-994d-f6601efee470", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9825), null, "AQAAAAIAAYagAAAAEDL6EoGeJ2W3jw1xVeYr0Poq47dsJODl2bCfQ8JUu7y+PQe6O4AcBE/GHQPZ34s9Nw==", "1c9e3b16-9a6c-45ee-8b1a-ee069d0ca868" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23fe5346-5fc4-4f61-b9f9-cb8eabeb1a46", new DateTime(2025, 9, 23, 9, 15, 23, 475, DateTimeKind.Utc).AddTicks(5502), null, "AQAAAAIAAYagAAAAEC9yoEbzT7QKChUX2dGgmOCrVGVgZBPQKAb235lLFzWW89qW8dCVFi91irXnZGn76w==", "0e14b18a-9832-49d4-81eb-cdc5aa81cd29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c20102bf-16e0-473a-9a63-698fe8425675", new DateTime(2025, 9, 23, 9, 15, 23, 552, DateTimeKind.Utc).AddTicks(5321), null, "AQAAAAIAAYagAAAAEHfusF7p3ALRYnic6g/UwXzZ0ODoLHENzik8BbQVU1DopqNCCQMlGX7vRFH5amYhCA==", "0c4bb951-31b7-4270-abc4-6ae71d83bdd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02d04e7a-3a99-4ffc-bd0d-fcc3a59c691f", new DateTime(2025, 9, 23, 9, 15, 23, 638, DateTimeKind.Utc).AddTicks(3147), null, "AQAAAAIAAYagAAAAEDvDmixQplSjmczmdL3kDSFjSq7hfXaJ8J1OvHeCwTsTKnGGvI6oCCLbPwyE+gUKog==", "36377c0e-b7c3-4600-8fda-323509aa7a61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "EmployeeId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4027681-16d2-412a-80a9-0c0109b53c7b", new DateTime(2025, 9, 23, 9, 15, 23, 720, DateTimeKind.Utc).AddTicks(6355), null, "AQAAAAIAAYagAAAAEObevbDW3ACZBQ9nlXx8XPTfpFIGH/zhAxbRAqTxujsRhc+Hby3EASY1aDu00QoW9A==", "6fbec418-a1ca-4d0f-918f-b34579208393" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CustomerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d8b2cae-2fa1-49ab-aeda-d832c2af6966", new DateTime(2025, 9, 23, 9, 15, 23, 803, DateTimeKind.Utc).AddTicks(3567), null, "AQAAAAIAAYagAAAAEIbrP1K5aXuEeTA7FgVMwtwAFql28Aqhs+qkEPqEor0OJbt5ULTIl8YhSpGcpmtnPg==", "779f809f-dcb9-4d84-86b1-2b8a6c29d405" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CustomerLiaisonId" },
                values: new object[] { new DateTime(2025, 9, 23, 9, 15, 23, 885, DateTimeKind.Utc).AddTicks(372), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9620));
        }
    }
}
