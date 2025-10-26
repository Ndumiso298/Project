using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class rep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "tblFaultReports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbf42ee3-a721-4760-8c0f-3b096e91c9da", "AQAAAAIAAYagAAAAENW2KXEsmMrB0Urp5iNrQVwII32wMOPrMMTQX24fG2QFTca17lec6vP6qFT9FudbNA==", "0e88c37b-3498-452d-98f1-fe85d2159af5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b76e5bc8-fed9-43bf-83a7-763a1827ea3d", "AQAAAAIAAYagAAAAEMVWClD7Hdvn67QiP1zvFIz8KnsDJ+VS379D/TlZAUlLkIROwbixxL+e9opsdYDxBQ==", "b807fde1-2897-4848-8595-fa6cf0171127" });
        }
    }
}
