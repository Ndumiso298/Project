using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class addedTerms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e008e3cb-7c49-47a5-800c-7d1ee2b413a4", "AQAAAAIAAYagAAAAECyCUBK1Srza3I5lQUPxG9tHgrb2Knnt1xjSqsVrtLKXghgc8QDO1bDMK2QA42Oe+w==", "39a889be-2901-40b5-bd48-98e287e28e47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a76d4aaa-fa31-4b7e-ad04-2990700f7aaa", "AQAAAAIAAYagAAAAECaD7V3Hep5NQfUx/pqLbSMJ8ZNsDLx3oz7rePBwCohImPNOOiCq7pC3Aso0TDeSXw==", "e222c4a9-4f07-476e-bd86-786cb5eee0e4" });
        }
    }
}
