using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3b3243c-265b-4f13-93bf-c9f654c5c6bf", new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(461), "AQAAAAIAAYagAAAAEO+21TPap4MEUU8zTNCPKwDN0pKIybIw0JwiB4ot7AeqxeT5EANHINkLdHMoR46b3A==", "1e8aa302-97fd-4d92-80f2-2721d2a302de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2adf488b-bc9a-46f1-8af3-0a45caaccd62", new DateTime(2025, 9, 23, 14, 24, 49, 334, DateTimeKind.Utc).AddTicks(9572), "AQAAAAIAAYagAAAAEFno3l4WHB5akL1ZHZtxvXBfEUzSmo//kCTa0a1sIR9IUhhYx+kXzKXGIPQ7UT7mpQ==", "171c7326-9b24-46a8-867f-87e3fbdee4f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32d804f8-3cbb-447f-bf4b-498d237db4fe", new DateTime(2025, 9, 23, 14, 24, 49, 415, DateTimeKind.Utc).AddTicks(4406), "AQAAAAIAAYagAAAAEBnYAnTdnoZCHNGJCc22xUAGOXcz8St7lMiMpY4BwBXdrkMTf8S6qPDqDdEP7ExpmQ==", "c788bd33-61b0-4efd-906b-763a0e2485ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72cdc9de-869f-4868-9ca0-b237061724e9", new DateTime(2025, 9, 23, 14, 24, 49, 502, DateTimeKind.Utc).AddTicks(334), "AQAAAAIAAYagAAAAEC6ISoRlCQ8saUXR8PicarkwgJT1nQTaG47TZaviMgsbN0H8i2RiRfEFNE7BwxubGA==", "6c9044f9-c717-49eb-b00b-a5dfeb95e7a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce3da151-57ff-4a3e-9474-6708f84abeea", new DateTime(2025, 9, 23, 14, 24, 49, 589, DateTimeKind.Utc).AddTicks(3803), "AQAAAAIAAYagAAAAEOcxPpi+ndRewDzBx2zdnYBbU+BJHJg957DpbC6XwVL1nn9rx5ppkNUcgZT68F63BQ==", "e3b6771f-e55f-44e2-9183-e71740f947a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ecbd799-32f7-4bd9-91fc-15099c6be840", new DateTime(2025, 9, 23, 14, 24, 49, 683, DateTimeKind.Utc).AddTicks(2932), "AQAAAAIAAYagAAAAEMPxsbg8MABZQBJKQiyjClkc7+oshfaWtEr/sMcN/eERAcNMgAF/HFPKM5AVhcw8vA==", "179f5d3a-f782-49d7-9c66-470a61f5769e" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 788, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 14, 24, 49, 255, DateTimeKind.Utc).AddTicks(371));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "860df6ec-f63a-44f0-ab78-225f4455de1d", new DateTime(2025, 9, 23, 9, 50, 37, 374, DateTimeKind.Utc).AddTicks(7416), "AQAAAAIAAYagAAAAEP8t2JaOVd1EHpUhVAjjppjYhPDHvc6yaOOfvg8t6CAoMT3ZUtjW81mlheeGXrOddA==", "84e769b7-bdf2-4d74-90dc-d06c54102b70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebf5a590-a6c6-41fe-94e4-ba87ae5810bc", new DateTime(2025, 9, 23, 9, 50, 37, 423, DateTimeKind.Utc).AddTicks(1926), "AQAAAAIAAYagAAAAEOAf24zgJ9VDtSdrc399UrRk8fjEF0Pds6dvS7/gqDxjohShHp34E/6MPaakr0xhBw==", "57859401-e55e-46af-85da-baade504fc2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee848032-372b-454c-9e0b-3255872bb74f", new DateTime(2025, 9, 23, 9, 50, 37, 471, DateTimeKind.Utc).AddTicks(3035), "AQAAAAIAAYagAAAAECqpezPBuv0ENyhPUP29g+iJQxLl3zLlF0yuMKyV4uKZVyRFBZjvvj5ArqdAwpmF0w==", "bbd11c86-8a69-4746-91f3-e5b8e055262a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f008fdb-ffda-4e4f-909e-e13cbd7b65ca", new DateTime(2025, 9, 23, 9, 50, 37, 519, DateTimeKind.Utc).AddTicks(1645), "AQAAAAIAAYagAAAAEGgDF+lp6Yq2A+OXm6yZpF3sZEsRCo49BF6RLqiltS8jiSyjV5U8D267lD+r5E2C9g==", "4cbfc0ad-2fda-47b1-afcd-c5b1e9ab8b1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18f09338-7ddc-441b-982b-f2ee5b95f1f2", new DateTime(2025, 9, 23, 9, 50, 37, 566, DateTimeKind.Utc).AddTicks(7778), "AQAAAAIAAYagAAAAEBLy7smkVbNU9xxbZrTzF1+nUJ20GWWtdlBHJHopLXVzUvX1crgVA1JAFdoM2hzNFA==", "163a9266-d076-4731-b9bb-ddc4d098cb9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d09bc1-29e1-49b9-b1d8-5451cb043c06", new DateTime(2025, 9, 23, 9, 50, 37, 614, DateTimeKind.Utc).AddTicks(3399), "AQAAAAIAAYagAAAAEGyWwpSyVIXP2VnxK5uw0+VJ+qT94SO6P8Kkkyy+jpztg54jVV/DJ/aLqasYCmDBvA==", "ad4af275-190c-429f-acde-37deb1bc9139" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 9, 50, 37, 662, DateTimeKind.Utc).AddTicks(4547));

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
    }
}
