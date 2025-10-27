using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedBy",
                table: "tblFaultReports");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "tblFaultReports");

            migrationBuilder.RenameColumn(
                name: "RebookingNotificationId",
                table: "tblRebookingNotifications",
                newName: "RebookingId");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "tblFaultImages",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "FaultImageId",
                table: "tblFaultImages",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "CustomerFeedbackId",
                table: "tblCustomerFeedbacks",
                newName: "FeedbackId");

            migrationBuilder.RenameColumn(
                name: "BookingNotificationId",
                table: "tblBookingNotifications",
                newName: "NotificationId");

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblRebookingNotifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultDescription",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerBookingStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblFaultImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblBookingNotifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "002be432-e404-4fa5-91c3-e38c53ee6d17", "AQAAAAIAAYagAAAAEC+XTMhjpSaxUQ1nbNznziXVheU8sitGgvR3d2IhbfIcSou0uVf8PoDGGHvpCKF87A==", "2225381a-4dd1-45c7-b113-8bd3113a3da1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblFaultImages");

            migrationBuilder.RenameColumn(
                name: "RebookingId",
                table: "tblRebookingNotifications",
                newName: "RebookingNotificationId");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "tblFaultImages",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "tblFaultImages",
                newName: "FaultImageId");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "tblCustomerFeedbacks",
                newName: "CustomerFeedbackId");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "tblBookingNotifications",
                newName: "BookingNotificationId");

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblRebookingNotifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RepairStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "tblFaultTechnicians",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "FaultDescription",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerBookingStatus",
                table: "tblFaultTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedBy",
                table: "tblFaultReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "tblFaultReports",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeclineReason",
                table: "tblBookingNotifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin-id-123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aac0d68b-e5ed-46a4-bcc5-5f8c2d1c437a", "AQAAAAIAAYagAAAAEPV73i+8DDcA5KYYajiPig5CKoQnhoDJGT8ZLKaZU/6n043XVa9fhNxzHYgI84FUPA==", "65400d87-b083-4f00-9c4e-b459142c4648" });
        }
    }
}
