using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class faultUpdatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeclineReason",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblBookingNotifications",
                columns: table => new
                {
                    BookingNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: false),
                    ProposedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBookingNotifications", x => x.BookingNotificationId);
                    table.ForeignKey(
                        name: "FK_tblBookingNotifications_tblFaultTechnicians_FaultTechnicianId",
                        column: x => x.FaultTechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "FaultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerFeedbacks",
                columns: table => new
                {
                    CustomerFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: false),
                    FeedbackMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerFeedbacks", x => x.CustomerFeedbackId);
                    table.ForeignKey(
                        name: "FK_tblCustomerFeedbacks_tblFaultTechnicians_FaultTechnicianId",
                        column: x => x.FaultTechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "FaultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFaultImages",
                columns: table => new
                {
                    FaultImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultReportId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultImages", x => x.FaultImageId);
                    table.ForeignKey(
                        name: "FK_tblFaultImages_tblFaultReports_FaultReportId",
                        column: x => x.FaultReportId,
                        principalTable: "tblFaultReports",
                        principalColumn: "FaultReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRebookingNotifications",
                columns: table => new
                {
                    RebookingNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: false),
                    OriginalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRebookingNotifications", x => x.RebookingNotificationId);
                    table.ForeignKey(
                        name: "FK_tblRebookingNotifications_tblFaultTechnicians_FaultTechnicianId",
                        column: x => x.FaultTechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "FaultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aac0d68b-e5ed-46a4-bcc5-5f8c2d1c437a", "AQAAAAIAAYagAAAAEPV73i+8DDcA5KYYajiPig5CKoQnhoDJGT8ZLKaZU/6n043XVa9fhNxzHYgI84FUPA==", "65400d87-b083-4f00-9c4e-b459142c4648" });

            migrationBuilder.CreateIndex(
                name: "IX_tblBookingNotifications_FaultTechnicianId",
                table: "tblBookingNotifications",
                column: "FaultTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFeedbacks_FaultTechnicianId",
                table: "tblCustomerFeedbacks",
                column: "FaultTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultImages_FaultReportId",
                table: "tblFaultImages",
                column: "FaultReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRebookingNotifications_FaultTechnicianId",
                table: "tblRebookingNotifications",
                column: "FaultTechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBookingNotifications");

            migrationBuilder.DropTable(
                name: "tblCustomerFeedbacks");

            migrationBuilder.DropTable(
                name: "tblFaultImages");

            migrationBuilder.DropTable(
                name: "tblRebookingNotifications");

            migrationBuilder.DropColumn(
                name: "DeclineReason",
                table: "tblFaultTechnicians");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "tblFaultTechnicians");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d57f2c1-041a-43ee-bd65-47f44068ed88", "AQAAAAIAAYagAAAAED/Ia9e1MAgxFIHAl8kjcPRsdrwsAe9NT88PX3tPB30526AJxni7tD6VAzQ7HURIpw==", "773f7787-43a1-46a0-852f-1e501c992beb" });
        }
    }
}
