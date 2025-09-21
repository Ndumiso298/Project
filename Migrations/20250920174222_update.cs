using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestHeaderId",
                table: "tblAllocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblFridgeVisits",
                columns: table => new
                {
                    FridgeVisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllocationId = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeVisits", x => x.FridgeVisitId);
                    table.ForeignKey(
                        name: "FK_tblFridgeVisits_tblAllocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "tblAllocations",
                        principalColumn: "AllocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "tblAllocations",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId");

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

            migrationBuilder.DropTable(
                name: "tblFridgeVisits");

            migrationBuilder.DropIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "tblAllocations");

            migrationBuilder.DropColumn(
                name: "RequestHeaderId",
                table: "tblAllocations");
        }
    }
}
