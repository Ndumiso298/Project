using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class faultcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85cf7c03-8581-4a93-8abf-42ae587bdf50", "AQAAAAIAAYagAAAAELiIP1kYmTt8fQxNVfhlf/KZ/6rXTplSxO3gDpMbuuWVHHidmnRGpiy/tNKRIpxCnA==", "5235a2c1-13e1-48a5-9c8f-711f25d25bda" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "570f60e5-25eb-4ec5-a15c-0bc2dd048d3b", "AQAAAAIAAYagAAAAEFwvqCwK7zrSH6Ucicy0Qaa5U6V5pXd/Mx0l/Gekk4czrspFmxMFfzSnefKh53rnQw==", "c5df09c8-1e55-4141-b8b4-fe00d33e77aa" });
        }
    }
}
