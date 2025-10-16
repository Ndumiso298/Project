using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class NullableEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "tblRequestHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_EmployeeID",
                table: "tblRequestHeaders",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                table: "tblRequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_tblRequestHeaders_EmployeeID",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "tblRequestHeaders");
        }
    }
}
