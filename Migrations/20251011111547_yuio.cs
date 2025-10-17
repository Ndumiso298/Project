using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class yuio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeAllocation_tblEmployee_AllocatedByEmployeeId",
                table: "tblFridgeAllocation");

            migrationBuilder.RenameColumn(
                name: "AllocatedByEmployeeId",
                table: "tblFridgeAllocation",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_tblFridgeAllocation_AllocatedByEmployeeId",
                table: "tblFridgeAllocation",
                newName: "IX_tblFridgeAllocation_EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeAllocation_tblEmployee_EmployeeID",
                table: "tblFridgeAllocation",
                column: "EmployeeID",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeAllocation_tblEmployee_EmployeeID",
                table: "tblFridgeAllocation");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "tblFridgeAllocation",
                newName: "AllocatedByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_tblFridgeAllocation_EmployeeID",
                table: "tblFridgeAllocation",
                newName: "IX_tblFridgeAllocation_AllocatedByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeAllocation_tblEmployee_AllocatedByEmployeeId",
                table: "tblFridgeAllocation",
                column: "AllocatedByEmployeeId",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeID");
        }
    }
}
