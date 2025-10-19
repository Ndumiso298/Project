using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingUpdatedTableForFaltTeckToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedDate",
                table: "tblFaultTechnicians");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "tblFaultTechnicians",
                newName: "Completion");

            migrationBuilder.AddColumn<DateTime>(
                name: "Bookingate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bookingate",
                table: "tblFaultTechnicians");

            migrationBuilder.RenameColumn(
                name: "Completion",
                table: "tblFaultTechnicians",
                newName: "CompletionDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedDate",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
