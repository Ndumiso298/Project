using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class faults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "570f60e5-25eb-4ec5-a15c-0bc2dd048d3b", "AQAAAAIAAYagAAAAEFwvqCwK7zrSH6Ucicy0Qaa5U6V5pXd/Mx0l/Gekk4czrspFmxMFfzSnefKh53rnQw==", "c5df09c8-1e55-4141-b8b4-fe00d33e77aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d27436-7a20-4e9a-a3ec-d82faf55e091", "AQAAAAIAAYagAAAAECDwLw8HxF8QZ6vtyc3YQMqYGOMGQRFC4Ljfh68WGx5njpvPIz824zMjqtfyTwvecA==", "2e6f1725-c253-41e4-930f-6bf25b6f2ae2" });
        }
    }
}
