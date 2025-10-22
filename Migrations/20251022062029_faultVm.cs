using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class faultVm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e9de03a-b48c-4929-961f-1ca3a2e09f5b", "AQAAAAIAAYagAAAAEOlUSPjYdyl0gQ+RQyayHZVyUu2j0hWuhC3B4IAwSBsjVOjcfCoAAteFTb9QO5a+QQ==", "eb9bfddc-6b38-4ced-9c7c-533b9fa63ae8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1d0e449-bbf8-4d58-8f2e-cec4c83bb7bd", "AQAAAAIAAYagAAAAEASNz8kaSGNdIHAA0yG96q3OcsJTgS02FinBYPgPerA2bDBkVtJepw6k4PcuEond8w==", "5c5f8bf0-60a2-41e6-8797-6406f4fb46e5" });
        }
    }
}
