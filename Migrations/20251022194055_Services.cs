using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "015f8b73-3696-4837-a572-90501eb5408e", "AQAAAAIAAYagAAAAEP8D0/H7d8WoLTs/mVwEF+Z2azSDQvFH/y8qRMJXYTT/7irsRGqbcJci+16VHLH8YQ==", "134d0af1-00de-40a7-bb25-02eaaaa23cf7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "tblFaultReports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc55720f-8601-4a09-bd19-8bb1b5c278f4", "AQAAAAIAAYagAAAAEHDdnbq9gAMnc5/5ThoI5BbamV/MijYictIYbKRm2KFms24WuBbKEMwf1GCzN3S5ZQ==", "0d73d822-60e6-4310-8bd6-83fa0ce685a1" });
        }
    }
}
