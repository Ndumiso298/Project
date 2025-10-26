using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddReplacementSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReplacement",
                table: "tblRequestHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OriginalFaultReportId",
                table: "tblRequestHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResolvedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsReplacementRequested",
                table: "tblFaultReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d57f2c1-041a-43ee-bd65-47f44068ed88", "AQAAAAIAAYagAAAAED/Ia9e1MAgxFIHAl8kjcPRsdrwsAe9NT88PX3tPB30526AJxni7tD6VAzQ7HURIpw==", "773f7787-43a1-46a0-852f-1e501c992beb" });

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_OriginalFaultReportId",
                table: "tblRequestHeaders",
                column: "OriginalFaultReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblFaultReports_OriginalFaultReportId",
                table: "tblRequestHeaders",
                column: "OriginalFaultReportId",
                principalTable: "tblFaultReports",
                principalColumn: "FaultReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblFaultReports_OriginalFaultReportId",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestHeaders_OriginalFaultReportId",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "IsReplacement",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "OriginalFaultReportId",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "IsReplacementRequested",
                table: "tblFaultReports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResolvedDate",
                table: "tblFaultReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbf42ee3-a721-4760-8c0f-3b096e91c9da", "AQAAAAIAAYagAAAAENW2KXEsmMrB0Urp5iNrQVwII32wMOPrMMTQX24fG2QFTca17lec6vP6qFT9FudbNA==", "0e88c37b-3498-452d-98f1-fe85d2159af5" });
        }
    }
}
