using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_UserId",
                table: "tblEmployee");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployee_UserId",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "AvailabilityStatus",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "tblEmployee");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblEmployee",
                newName: "EmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNumber",
                table: "tblEmployee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "tblEmployee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployee_ApplicationUserId",
                table: "tblEmployee");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "tblEmployee",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNumber",
                table: "tblEmployee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "tblEmployee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityStatus",
                table: "tblEmployee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "tblEmployee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "tblEmployee",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblEmployee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "tblEmployee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "tblEmployee",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "tblEmployee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_UserId",
                table: "tblEmployee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_AspNetUsers_UserId",
                table: "tblEmployee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
