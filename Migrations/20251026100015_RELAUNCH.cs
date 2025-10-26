using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class RELAUNCH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestHeaderId1",
                table: "tblRequestHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25085bc-d5f2-4ac7-99b0-6cc073975fcb", "AQAAAAIAAYagAAAAEEl3Xx/Htb22X4Ax1uEunmLTjJ4HUZy8Nu9/DqiOBP3Z2ZG/o1CKl6bksxbXzaPdQA==", "dc4179d6-b1c5-4be3-9ff3-62ba4f7d99c9" });

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_RequestHeaderId1",
                table: "tblRequestHeaders",
                column: "RequestHeaderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblRequestHeaders_RequestHeaderId1",
                table: "tblRequestHeaders",
                column: "RequestHeaderId1",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblRequestHeaders_RequestHeaderId1",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestHeaders_RequestHeaderId1",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "RequestHeaderId1",
                table: "tblRequestHeaders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "037ed668-3784-47fc-a016-64ee2fee22f7", "AQAAAAIAAYagAAAAECfgmz3+HWGSmBjnVyjjXf4L8fXQZcRQpn3z1fwtQn8QfqDUud9gp3JvxaUfCw3jzA==", "5587d397-742c-4170-9b82-6f027224a631" });
        }
    }
}
