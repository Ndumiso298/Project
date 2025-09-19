using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class adgjlkn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestHeaderId",
                table: "tblAllocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "tblAllocations",
                column: "RequestHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAllocations_tblRequestHeaders_RequestHeaderId",
                table: "tblAllocations",
                column: "RequestHeaderId",
                principalTable: "tblRequestHeaders",
                principalColumn: "RequestHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAllocations_tblRequestHeaders_RequestHeaderId",
                table: "tblAllocations");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "tblAllocations");

            migrationBuilder.DropColumn(
                name: "RequestHeaderId",
                table: "tblAllocations");
        }
    }
}
