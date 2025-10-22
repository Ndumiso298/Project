using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FaultUpdat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2772fd55-e4af-456e-ae82-de1e771ff1c0", "AQAAAAIAAYagAAAAEGUmlPbm3F8Xc8H7kI/dAv54PwD7tpZyPrdiU31yMfn/MUX04udVLlHS23MjK/erGg==", "2ff29ac7-43f6-477b-8c01-a1298d0160e3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b512e34-1ef0-4966-aca5-3b2a427d4ac2", "AQAAAAIAAYagAAAAEI6ovNc2v9FjXo1e2DMc3AIMgbeWIZ2Nk6vehfL4u0Vsmt3jmgtdw8xVOh+ryQjzlw==", "c8e26866-1d16-474b-9570-8dcc2a26b838" });
        }
    }
}
