using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FaultUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b512e34-1ef0-4966-aca5-3b2a427d4ac2", "AQAAAAIAAYagAAAAEI6ovNc2v9FjXo1e2DMc3AIMgbeWIZ2Nk6vehfL4u0Vsmt3jmgtdw8xVOh+ryQjzlw==", "c8e26866-1d16-474b-9570-8dcc2a26b838" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b4b5a96-7173-439d-946b-31ed96d64818", "AQAAAAIAAYagAAAAEJswj6SRKPzLNhcntSf1TP9ZKMV1hspwTqO0AA6tHarYUKYr9B6AHMtxMDzOwJyOjQ==", "bc99a90b-3fa5-417a-b99d-007e6acca356" });
        }
    }
}
