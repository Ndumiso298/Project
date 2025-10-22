using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FaultUpda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RejectReason",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "AllocationDate",
                table: "tblAllocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02547ec1-9b93-44c3-883d-0124f735692d", "AQAAAAIAAYagAAAAEBsvhgAKxRuQWIm7gSzPtOS1Qmx4ImWDEMbyrgMY3ePoBZ1ZGIKSKM+rBk81upch9g==", "44b22977-ac77-4c18-a013-221b71332249" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllocationDate",
                table: "tblAllocations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "RejectReason",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2772fd55-e4af-456e-ae82-de1e771ff1c0", "AQAAAAIAAYagAAAAEGUmlPbm3F8Xc8H7kI/dAv54PwD7tpZyPrdiU31yMfn/MUX04udVLlHS23MjK/erGg==", "2ff29ac7-43f6-477b-8c01-a1298d0160e3" });
        }
    }
}
