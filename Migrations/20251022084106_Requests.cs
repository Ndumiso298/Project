using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Requests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitId",
                table: "tblFaultReports");

            migrationBuilder.DropIndex(
                name: "IX_tblFaultReports_FridgeVisitId",
                table: "tblFaultReports");

            migrationBuilder.RenameColumn(
                name: "FridgeVisitId",
                table: "tblFaultReports",
                newName: "OriginalFaultReportId");

            migrationBuilder.RenameColumn(
                name: "FaultDescription",
                table: "tblFaultReports",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "FridgeInStockId",
                table: "tblFaultReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFaultReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeclineReason",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRelaunched",
                table: "tblFaultReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequestReplacement",
                table: "tblFaultReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc55720f-8601-4a09-bd19-8bb1b5c278f4", "AQAAAAIAAYagAAAAEHDdnbq9gAMnc5/5ThoI5BbamV/MijYictIYbKRm2KFms24WuBbKEMwf1GCzN3S5ZQ==", "0d73d822-60e6-4310-8bd6-83fa0ce685a1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclineReason",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "IsRelaunched",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "RequestReplacement",
                table: "tblFaultReports");

            migrationBuilder.RenameColumn(
                name: "OriginalFaultReportId",
                table: "tblFaultReports",
                newName: "FridgeVisitId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tblFaultReports",
                newName: "FaultDescription");

            migrationBuilder.AlterColumn<int>(
                name: "FridgeInStockId",
                table: "tblFaultReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFaultReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e9de03a-b48c-4929-961f-1ca3a2e09f5b", "AQAAAAIAAYagAAAAEOlUSPjYdyl0gQ+RQyayHZVyUu2j0hWuhC3B4IAwSBsjVOjcfCoAAteFTb9QO5a+QQ==", "eb9bfddc-6b38-4ced-9c7c-533b9fa63ae8" });

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_FridgeVisitId",
                table: "tblFaultReports",
                column: "FridgeVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFaultReports_tblFridgeVisits_FridgeVisitId",
                table: "tblFaultReports",
                column: "FridgeVisitId",
                principalTable: "tblFridgeVisits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
