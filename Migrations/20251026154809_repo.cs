using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class repo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b76e5bc8-fed9-43bf-83a7-763a1827ea3d", "AQAAAAIAAYagAAAAEMVWClD7Hdvn67QiP1zvFIz8KnsDJ+VS379D/TlZAUlLkIROwbixxL+e9opsdYDxBQ==", "b807fde1-2897-4848-8595-fa6cf0171127" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tblFaultTechnicians");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85cf7c03-8581-4a93-8abf-42ae587bdf50", "AQAAAAIAAYagAAAAELiIP1kYmTt8fQxNVfhlf/KZ/6rXTplSxO3gDpMbuuWVHHidmnRGpiy/tNKRIpxCnA==", "5235a2c1-13e1-48a5-9c8f-711f25d25bda" });
        }
    }
}
