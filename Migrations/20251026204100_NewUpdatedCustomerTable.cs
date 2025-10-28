using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdatedCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RequestDetailId",
                table: "tblCustomerFridge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_RequestDetailId",
                table: "tblCustomerFridge",
                column: "RequestDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge",
                column: "RequestDetailId",
                principalTable: "tblRequestDetais",
                principalColumn: "RequestDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                table: "tblCustomerFridge");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerFridge_RequestDetailId",
                table: "tblCustomerFridge");

            migrationBuilder.DropColumn(
                name: "RequestDetailId",
                table: "tblCustomerFridge");

            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
