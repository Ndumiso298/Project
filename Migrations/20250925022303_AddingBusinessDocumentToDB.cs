using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingBusinessDocumentToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BusinessDocumentPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessDocumentPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "AspNetUsers");

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
    }
}
