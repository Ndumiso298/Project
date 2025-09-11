using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class abcde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblRequestHeader",
                columns: table => new
                {
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestTotal = table.Column<double>(type: "float", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestHeader", x => x.RequestHeaderId);
                    table.ForeignKey(
                        name: "FK_tblRequestHeader_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRequestDetail",
                columns: table => new
                {
                    RequestDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestDetail", x => x.RequestDetailId);
                    table.ForeignKey(
                        name: "FK_tblRequestDetail_tblFridge_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridge",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRequestDetail_tblRequestHeader_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeader",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetail_FridgeId",
                table: "tblRequestDetail",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetail_RequestHeaderId",
                table: "tblRequestDetail",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeader_ApplicationUserId",
                table: "tblRequestHeader",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRequestDetail");

            migrationBuilder.DropTable(
                name: "tblRequestHeader");
        }
    }
}
