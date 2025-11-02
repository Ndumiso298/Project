using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class RelaunchRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalDescription",
                table: "tblRequestHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalDocumentPath",
                table: "tblRequestHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRelaunched",
                table: "tblRequestHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OriginalRequestId",
                table: "tblRequestHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectionDate",
                table: "tblRequestHeaders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "tblRequestHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalDescription",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "AdditionalDocumentPath",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "IsRelaunched",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "OriginalRequestId",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "RejectionDate",
                table: "tblRequestHeaders");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "tblRequestHeaders");
        }
    }
}
