using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class sdfghj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123");

            migrationBuilder.AddColumn<int>(
                name: "RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeInStocks_RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks",
                column: "RequestDetailsRequestDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeInStocks_tblRequestDetais_RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks",
                column: "RequestDetailsRequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeInStocks_tblRequestDetais_RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeInStocks_RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks");

            migrationBuilder.DropColumn(
                name: "RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CellNumber", "City", "ConcurrencyStamp", "DeclinedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsApproved", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "RejectionReason", "SecurityStamp", "State", "Status", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-id-123", 0, "+27123456789", "Johannesburg", "52d4ecca-8084-43d4-b5bd-6877cb80ad51", null, "ApplicationUser", "admin@fridgesystem.com", true, "System", true, "Administrator", false, null, "ADMIN@FRIDGESYSTEM.COM", "ADMIN@FRIDGESYSTEM.COM", "AQAAAAIAAYagAAAAELeo5PnhUnIxOmWaZP87ahT0SKHEev7tIzllMd7N7+QOJlVrMotpJog4u5efzgVUwQ==", null, true, "2000", null, "7beeca44-87aa-4726-9a98-0ae0043ccc64", "Gauteng", "Approved", "123 Admin Street", false, "admin@fridgesystem.com" });
        }
    }
}
