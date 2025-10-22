using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RejectReason",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "tblAllocations",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a76d4aaa-fa31-4b7e-ad04-2990700f7aaa", "AQAAAAIAAYagAAAAECaD7V3Hep5NQfUx/pqLbSMJ8ZNsDLx3oz7rePBwCohImPNOOiCq7pC3Aso0TDeSXw==", "e222c4a9-4f07-476e-bd86-786cb5eee0e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "tblAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "RejectReason",
                table: "tblAllocations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02547ec1-9b93-44c3-883d-0124f735692d", "AQAAAAIAAYagAAAAEBsvhgAKxRuQWIm7gSzPtOS1Qmx4ImWDEMbyrgMY3ePoBZ1ZGIKSKM+rBk81upch9g==", "44b22977-ac77-4c18-a013-221b71332249" });
        }
    }
}
