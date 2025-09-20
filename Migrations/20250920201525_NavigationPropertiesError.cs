using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class NavigationPropertiesError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_Customers_ReportedByCustomerId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_FridgeAllocations_Id",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_tblFaultTechnicians_ResolvedByTechnicianId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_AspNetUsers_ApplicationUserId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_RequestHeaders_Id",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecords_FridgeAllocations_Id",
                table: "MaintenanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecords_tblFaultTechnicians_TechnicianId",
                table: "MaintenanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceVisits_FridgeAllocations_Id",
                table: "MaintenanceVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceVisits_tblFaultTechnicians_TechnicianId",
                table: "MaintenanceVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetail_FridgeAllocations_Id",
                table: "RequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetail_RequestHeaders_Id",
                table: "RequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHeaders_AspNetUsers_ApplicationUserId",
                table: "RequestHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeRequests_Customers_CustomerId",
                table: "tblFridgeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeRequests_FridgeAllocations_FaultyFridgeId",
                table: "tblFridgeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeRequests_FridgeAllocations_ReplacementFridgeId",
                table: "tblFridgeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFridgeVisits_FridgeAllocations_AllocationId",
                table: "tblFridgeVisits");

            migrationBuilder.DropTable(
                name: "tblFaultTechnicians");

            migrationBuilder.DropTable(
                name: "tblProcessFaults");

            migrationBuilder.DropIndex(
                name: "IX_RequestHeaders_ApplicationUserId",
                table: "RequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_ApplicationUserId",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_Id",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_Id",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_ReportedByCustomerId",
                table: "FaultRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFridgeVisits",
                table: "tblFridgeVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFridgeRequests",
                table: "tblFridgeRequests");

            migrationBuilder.DropIndex(
                name: "IX_tblFridgeRequests_FaultyFridgeId",
                table: "tblFridgeRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDetail",
                table: "RequestDetail");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RequestHeaders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "AvailabilityStatus",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "RentalPricePerMonth",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerNote",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CapacityRequirement",
                table: "tblFridgeRequests");

            migrationBuilder.DropColumn(
                name: "IssueDescription",
                table: "tblFridgeRequests");

            migrationBuilder.DropColumn(
                name: "PreferredModel",
                table: "tblFridgeRequests");

            migrationBuilder.DropColumn(
                name: "TechnicianNotes",
                table: "tblFridgeRequests");

            migrationBuilder.RenameTable(
                name: "tblFridgeVisits",
                newName: "FridgeVisits");

            migrationBuilder.RenameTable(
                name: "tblFridgeRequests",
                newName: "ReplacementRequests");

            migrationBuilder.RenameTable(
                name: "RequestDetail",
                newName: "RequestDetails");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "RequestHeaders",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaintenanceVisits",
                newName: "FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceVisits_Id",
                table: "MaintenanceVisits",
                newName: "IX_MaintenanceVisits_FridgeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaintenanceRecords",
                newName: "FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecords_Id",
                table: "MaintenanceRecords",
                newName: "IX_MaintenanceRecords_FridgeId");

            migrationBuilder.RenameColumn(
                name: "LastMaintenanceDate",
                table: "FridgeAllocations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CapacityLiters",
                table: "FridgeAllocations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AllocationId",
                table: "FridgeAllocations",
                newName: "ServiceIntervalMonths");

            migrationBuilder.RenameColumn(
                name: "ResolvedByTechnicianId",
                table: "FaultRecords",
                newName: "FaultTechnicianId");

            migrationBuilder.RenameColumn(
                name: "ResolvedAt",
                table: "FaultRecords",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ReportedByCustomerId",
                table: "FaultRecords",
                newName: "CustomerRating");

            migrationBuilder.RenameColumn(
                name: "ReportedAt",
                table: "FaultRecords",
                newName: "ReportedDate");

            migrationBuilder.RenameIndex(
                name: "IX_FaultRecords_ResolvedByTechnicianId",
                table: "FaultRecords",
                newName: "IX_FaultRecords_FaultTechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "FridgeVisits",
                newName: "IX_FridgeVisits_AllocationId");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "ReplacementRequests",
                newName: "RequestedDate");

            migrationBuilder.RenameColumn(
                name: "ReplacementFridgeId",
                table: "ReplacementRequests",
                newName: "MaintenanceRecordId");

            migrationBuilder.RenameColumn(
                name: "FaultyFridgeId",
                table: "ReplacementRequests",
                newName: "RequestType");

            migrationBuilder.RenameIndex(
                name: "IX_tblFridgeRequests_ReplacementFridgeId",
                table: "ReplacementRequests",
                newName: "IX_ReplacementRequests_MaintenanceRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_tblFridgeRequests_CustomerId",
                table: "ReplacementRequests",
                newName: "IX_ReplacementRequests_CustomerId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RequestDetails",
                newName: "RequestHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetail_Id",
                table: "RequestDetails",
                newName: "IX_RequestDetails_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestTotal",
                table: "RequestHeaders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "RequestHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "RequestHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FridgeFaultId",
                table: "MaintenanceVisits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceIntervalMonths",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AllocatedById",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AllocationDate",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FridgeAllocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastServiceDate",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextServiceDue",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "FridgeAllocations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessedById",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestHeaderId",
                table: "FridgeAllocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FridgeAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "FaultRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcknowledgedDate",
                table: "FaultRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "FaultRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "FaultRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FaultRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "CustomerCharged",
                table: "FaultRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFeedback",
                table: "FaultRecords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "FaultRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FaultRecords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "FaultRecords",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaultPhotoUrl",
                table: "FaultRecords",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridgeAllocationId",
                table: "FaultRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "FaultRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FaultRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PartsUsed",
                table: "FaultRecords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "FaultRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RepairCost",
                table: "FaultRecords",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedById",
                table: "FaultRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolutionNotes",
                table: "FaultRecords",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolutionPhotoUrl",
                table: "FaultRecords",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "FaultRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "FaultRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedDate",
                table: "FaultRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WarrantyCovered",
                table: "FaultRecords",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhoneNumber",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BusinessType",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomerLiaisonId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TradingName",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ReplacementRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "ReplacementRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedEmployeeId",
                table: "ReplacementRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ReplacementRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FaultRecordId",
                table: "ReplacementRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridgeAllocationId",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReplacementRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ReplacementRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "ReplacementRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseNotes",
                table: "ReplacementRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ReplacementRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "RequestDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "RequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeVisits",
                table: "FridgeVisits",
                column: "FridgeVisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReplacementRequests",
                table: "ReplacementRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDetails",
                table: "RequestDetails",
                column: "RequestDetailId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceAreaRadius = table.Column<int>(type: "int", nullable: true),
                    StorageCapacity = table.Column<int>(type: "int", nullable: true),
                    CurrentOccupancy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fridges_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fridges_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedById = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    CustomReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    RequiredByDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedTotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedById = table.Column<int>(type: "int", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Employees_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EstimatedUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: false),
                    QuantityReceived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CapacityLiters", "Condition", "CustomerId", "Description", "EmployeeId", "ImageUrl", "LastMaintenanceDate", "Location", "LocationId", "Manufacturer", "Model", "RentalPricePerMonth", "SerialNumber", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 253, 0, null, "Energy-efficient double door fridge with frost-free technology.", null, "https://example.com/images/fridge1.jpg", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Samsung", "RT28T", 1200.00m, "FRG-001", 0, "Double Door" },
                    { 2, 190, 1, null, "Compact single door fridge ideal for small apartments.", null, "https://example.com/images/fridge2.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "LG", "GL-B201", 900.00m, "FRG-002", 1, "Single Door" },
                    { 3, 500, 0, null, "Spacious fridge with advanced cooling technology.", null, "https://example.com/images/fridge3.jpg", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Whirlpool", "WRT518", 1500.00m, "FRG-003", 0, "Double Door" },
                    { 4, 350, 1, null, "Durable fridge with energy-saving features.", null, "https://example.com/images/fridge4.jpg", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Defy", "DAC700", 1100.00m, "FRG-004", 0, "Double Door" },
                    { 5, 310, 0, null, "Compact fridge with adjustable shelves.", null, "https://example.com/images/fridge5.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Hisense", "H310BI", 800.00m, "FRG-005", 0, "Single Door" },
                    { 6, 420, 1, null, "Premium fridge with no-frost technology.", null, "https://example.com/images/fridge6.jpg", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Bosch", "KDN42", 1600.00m, "FRG-006", 0, "Double Door" },
                    { 7, 250, 2, null, "Affordable fridge with basic features.", null, "https://example.com/images/fridge7.jpg", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Kelvinator", "KEL250", 700.00m, "FRG-007", 0, "Single Door" },
                    { 8, 281, 0, null, "Retro-style fridge with modern cooling.", null, "https://example.com/images/fridge8.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Smeg", "FAB28", 2000.00m, "FRG-008", 0, "Single Door" },
                    { 9, 300, 0, null, "Built-in fridge with adjustable compartments.", null, "https://example.com/images/fridge9.jpg", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "AEG", "SKE818", 1800.00m, "FRG-009", 0, "Single Door" },
                    { 10, 347, 0, null, "Fridge with inverter technology for energy saving.", null, "https://example.com/images/fridge10.jpg", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Panasonic", "NR-BL347", 1300.00m, "FRG-010", 0, "Double Door" },
                    { 11, 565, 0, null, "Large capacity fridge with twin inverter technology.", null, "https://example.com/images/fridge11.jpg", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Haier", "HRF-619", 2200.00m, "FRG-011", 0, "Side by Side" },
                    { 12, 640, 0, null, "Premium French door fridge with eco-friendly features.", null, "https://example.com/images/fridge12.jpg", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Hitachi", "R-WB640", 2500.00m, "FRG-012", 0, "French Door" },
                    { 13, 370, 1, null, "Fridge with taste guard deodorizer.", null, "https://example.com/images/fridge13.jpg", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Electrolux", "ETB3700", 1400.00m, "FRG-013", 1, "Top Freezer" },
                    { 14, 600, 0, null, "Fridge with plasmacluster ion technology.", null, "https://example.com/images/fridge14.jpg", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Sharp", "SJ-GX60", 2300.00m, "FRG-014", 0, "French Door" },
                    { 15, 400, 1, null, "Affordable fridge with large freezer compartment.", null, "https://example.com/images/fridge15.jpg", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Midea", "HD-400", 1000.00m, "FRG-015", 0, "Double Door" },
                    { 16, 326, 1, null, "Stylish bottom freezer fridge with crisp zone for vegetables.", null, "https://example.com/images/fridge16.jpg", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Gorenje", "NRK6192", 1250.00m, "FRG-016", 0, "Bottom Freezer" },
                    { 17, 528, 1, null, "Family-sized fridge with humidity-controlled crisper.", null, "https://example.com/images/fridge17.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Westinghouse", "WBE5300", 1700.00m, "FRG-017", 0, "Top Freezer" },
                    { 18, 519, 1, null, "Premium French door fridge with active smart technology.", null, "https://example.com/images/fridge18.jpg", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Fisher & Paykel", "RF522", 2400.00m, "FRG-018", 1, "French Door" },
                    { 19, 383, 1, null, "Reliable fridge with antibacterial coating.", null, "https://example.com/images/fridge19.jpg", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Ariston", "MBA3832", 1150.00m, "FRG-019", 0, "Top Freezer" },
                    { 20, 560, 0, null, "Spacious bottom freezer fridge with NeoFrost cooling.", null, "https://example.com/images/fridge20.jpg", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "Beko", "RCNE560", 1850.00m, "FRG-020", 0, "Bottom Freezer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeaders_CustomerId",
                table: "RequestHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_FridgeFaultId",
                table: "MaintenanceVisits",
                column: "FridgeFaultId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_AllocatedById",
                table: "FridgeAllocations",
                column: "AllocatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_FridgeId",
                table: "FridgeAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ProcessedById",
                table: "FridgeAllocations",
                column: "ProcessedById");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_RequestHeaderId",
                table: "FridgeAllocations",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FridgeAllocationId",
                table: "FaultRecords",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FridgeId",
                table: "FaultRecords",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_ReportedById",
                table: "FaultRecords",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerLiaisonId",
                table: "Customers",
                column: "CustomerLiaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_AssignedEmployeeId",
                table: "ReplacementRequests",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_FaultRecordId",
                table: "ReplacementRequests",
                column: "FaultRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_FridgeAllocationId",
                table: "ReplacementRequests",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_CustomerId",
                table: "Fridges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_EmployeeId",
                table: "Fridges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_LocationId",
                table: "Fridges",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_FridgeId",
                table: "PurchaseRequestItems",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_PurchaseRequestId",
                table: "PurchaseRequestItems",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_ApprovedById",
                table: "PurchaseRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_RequestedById",
                table: "PurchaseRequests",
                column: "RequestedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employees_CustomerLiaisonId",
                table: "Customers",
                column: "CustomerLiaisonId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_ReportedById",
                table: "FaultRecords",
                column: "ReportedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_Customers_CustomerId",
                table: "FaultRecords",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_Employees_FaultTechnicianId",
                table: "FaultRecords",
                column: "FaultTechnicianId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_FridgeAllocations_FridgeAllocationId",
                table: "FaultRecords",
                column: "FridgeAllocationId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_Fridges_FridgeId",
                table: "FaultRecords",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerId",
                table: "FridgeAllocations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Employees_AllocatedById",
                table: "FridgeAllocations",
                column: "AllocatedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Employees_ProcessedById",
                table: "FridgeAllocations",
                column: "ProcessedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Fridges_FridgeId",
                table: "FridgeAllocations",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_RequestHeaders_RequestHeaderId",
                table: "FridgeAllocations",
                column: "RequestHeaderId",
                principalTable: "RequestHeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeVisits_FridgeAllocations_AllocationId",
                table: "FridgeVisits",
                column: "AllocationId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecords_Employees_TechnicianId",
                table: "MaintenanceRecords",
                column: "TechnicianId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecords_Fridges_FridgeId",
                table: "MaintenanceRecords",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceVisits_Employees_TechnicianId",
                table: "MaintenanceVisits",
                column: "TechnicianId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceVisits_FaultRecords_FridgeFaultId",
                table: "MaintenanceVisits",
                column: "FridgeFaultId",
                principalTable: "FaultRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceVisits_Fridges_FridgeId",
                table: "MaintenanceVisits",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Customers_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Employees_AssignedEmployeeId",
                table: "ReplacementRequests",
                column: "AssignedEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_FaultRecords_FaultRecordId",
                table: "ReplacementRequests",
                column: "FaultRecordId",
                principalTable: "FaultRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_FridgeAllocations_FridgeAllocationId",
                table: "ReplacementRequests",
                column: "FridgeAllocationId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_MaintenanceRecords_MaintenanceRecordId",
                table: "ReplacementRequests",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecords",
                principalColumn: "MaintenanceRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Fridges_Id",
                table: "RequestDetails",
                column: "Id",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_RequestHeaders_Id",
                table: "RequestDetails",
                column: "Id",
                principalTable: "RequestHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHeaders_Customers_CustomerId",
                table: "RequestHeaders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employees_CustomerLiaisonId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_ReportedById",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_Customers_CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_Employees_FaultTechnicianId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_FridgeAllocations_FridgeAllocationId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_Fridges_FridgeId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Employees_AllocatedById",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Employees_ProcessedById",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Fridges_FridgeId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_RequestHeaders_RequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeVisits_FridgeAllocations_AllocationId",
                table: "FridgeVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecords_Employees_TechnicianId",
                table: "MaintenanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecords_Fridges_FridgeId",
                table: "MaintenanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceVisits_Employees_TechnicianId",
                table: "MaintenanceVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceVisits_FaultRecords_FridgeFaultId",
                table: "MaintenanceVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceVisits_Fridges_FridgeId",
                table: "MaintenanceVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Customers_CustomerId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Employees_AssignedEmployeeId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_FaultRecords_FaultRecordId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_FridgeAllocations_FridgeAllocationId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_MaintenanceRecords_MaintenanceRecordId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Fridges_Id",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_RequestHeaders_Id",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHeaders_Customers_CustomerId",
                table: "RequestHeaders");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_RequestHeaders_CustomerId",
                table: "RequestHeaders");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceVisits_FridgeFaultId",
                table: "MaintenanceVisits");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_AllocatedById",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_FridgeId",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_ProcessedById",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FridgeAllocations_RequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_FridgeAllocationId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_FridgeId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_ReportedById",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerLiaisonId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocationId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDetails",
                table: "RequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReplacementRequests",
                table: "ReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReplacementRequests_AssignedEmployeeId",
                table: "ReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReplacementRequests_FaultRecordId",
                table: "ReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReplacementRequests_FridgeAllocationId",
                table: "ReplacementRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeVisits",
                table: "FridgeVisits");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "RequestHeaders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "RequestHeaders");

            migrationBuilder.DropColumn(
                name: "FridgeFaultId",
                table: "MaintenanceVisits");

            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "AllocatedById",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "AllocationDate",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "LastServiceDate",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "NextServiceDue",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "ProcessedById",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "RequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FridgeAllocations");

            migrationBuilder.DropColumn(
                name: "AcknowledgedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "CustomerCharged",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "CustomerFeedback",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FaultPhotoUrl",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FridgeAllocationId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "PartsUsed",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ReportedById",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ResolutionNotes",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ResolutionPhotoUrl",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "StartedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "WarrantyCovered",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessPhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerLiaisonId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TradingName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "AssignedEmployeeId",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "FaultRecordId",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "FridgeAllocationId",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "ResponseNotes",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ReplacementRequests");

            migrationBuilder.RenameTable(
                name: "RequestDetails",
                newName: "RequestDetail");

            migrationBuilder.RenameTable(
                name: "ReplacementRequests",
                newName: "tblFridgeRequests");

            migrationBuilder.RenameTable(
                name: "FridgeVisits",
                newName: "tblFridgeVisits");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "RequestHeaders",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "FridgeId",
                table: "MaintenanceVisits",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceVisits_FridgeId",
                table: "MaintenanceVisits",
                newName: "IX_MaintenanceVisits_Id");

            migrationBuilder.RenameColumn(
                name: "FridgeId",
                table: "MaintenanceRecords",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecords_FridgeId",
                table: "MaintenanceRecords",
                newName: "IX_MaintenanceRecords_Id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "FridgeAllocations",
                newName: "CapacityLiters");

            migrationBuilder.RenameColumn(
                name: "ServiceIntervalMonths",
                table: "FridgeAllocations",
                newName: "AllocationId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "FridgeAllocations",
                newName: "LastMaintenanceDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "FaultRecords",
                newName: "ResolvedAt");

            migrationBuilder.RenameColumn(
                name: "ReportedDate",
                table: "FaultRecords",
                newName: "ReportedAt");

            migrationBuilder.RenameColumn(
                name: "FaultTechnicianId",
                table: "FaultRecords",
                newName: "ResolvedByTechnicianId");

            migrationBuilder.RenameColumn(
                name: "CustomerRating",
                table: "FaultRecords",
                newName: "ReportedByCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FaultRecords_FaultTechnicianId",
                table: "FaultRecords",
                newName: "IX_FaultRecords_ResolvedByTechnicianId");

            migrationBuilder.RenameColumn(
                name: "RequestHeaderId",
                table: "RequestDetail",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetails_Id",
                table: "RequestDetail",
                newName: "IX_RequestDetail_Id");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "tblFridgeRequests",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "RequestType",
                table: "tblFridgeRequests",
                newName: "FaultyFridgeId");

            migrationBuilder.RenameColumn(
                name: "MaintenanceRecordId",
                table: "tblFridgeRequests",
                newName: "ReplacementFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplacementRequests_MaintenanceRecordId",
                table: "tblFridgeRequests",
                newName: "IX_tblFridgeRequests_ReplacementFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplacementRequests_CustomerId",
                table: "tblFridgeRequests",
                newName: "IX_tblFridgeRequests_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeVisits_AllocationId",
                table: "tblFridgeVisits",
                newName: "IX_tblFridgeVisits_AllocationId");

            migrationBuilder.AlterColumn<double>(
                name: "RequestTotal",
                table: "RequestHeaders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RequestHeaders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "FridgeAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AllocationId",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "FridgeAllocations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityStatus",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RentalPricePerMonth",
                table: "FridgeAllocations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FridgeAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FaultRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FaultRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "FaultRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "FaultRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerNote",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "RequestDetail",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tblFridgeRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tblFridgeRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapacityRequirement",
                table: "tblFridgeRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IssueDescription",
                table: "tblFridgeRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredModel",
                table: "tblFridgeRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TechnicianNotes",
                table: "tblFridgeRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDetail",
                table: "RequestDetail",
                column: "RequestDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFridgeRequests",
                table: "tblFridgeRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFridgeVisits",
                table: "tblFridgeVisits",
                column: "FridgeVisitId");

            migrationBuilder.CreateTable(
                name: "tblFaultTechnicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultTechnicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "tblProcessFaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduleFault = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProcessFaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProcessFaults_FaultRecords_Id",
                        column: x => x.Id,
                        principalTable: "FaultRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeaders_ApplicationUserId",
                table: "RequestHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ApplicationUserId",
                table: "FridgeAllocations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_Id",
                table: "FridgeAllocations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_Id",
                table: "FaultRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_ReportedByCustomerId",
                table: "FaultRecords",
                column: "ReportedByCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_FaultyFridgeId",
                table: "tblFridgeRequests",
                column: "FaultyFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProcessFaults_Id",
                table: "tblProcessFaults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_Customers_ReportedByCustomerId",
                table: "FaultRecords",
                column: "ReportedByCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_FridgeAllocations_Id",
                table: "FaultRecords",
                column: "Id",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_tblFaultTechnicians_ResolvedByTechnicianId",
                table: "FaultRecords",
                column: "ResolvedByTechnicianId",
                principalTable: "tblFaultTechnicians",
                principalColumn: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_AspNetUsers_ApplicationUserId",
                table: "FridgeAllocations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerId",
                table: "FridgeAllocations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_RequestHeaders_Id",
                table: "FridgeAllocations",
                column: "Id",
                principalTable: "RequestHeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecords_FridgeAllocations_Id",
                table: "MaintenanceRecords",
                column: "Id",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecords_tblFaultTechnicians_TechnicianId",
                table: "MaintenanceRecords",
                column: "TechnicianId",
                principalTable: "tblFaultTechnicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceVisits_FridgeAllocations_Id",
                table: "MaintenanceVisits",
                column: "Id",
                principalTable: "FridgeAllocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceVisits_tblFaultTechnicians_TechnicianId",
                table: "MaintenanceVisits",
                column: "TechnicianId",
                principalTable: "tblFaultTechnicians",
                principalColumn: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetail_FridgeAllocations_Id",
                table: "RequestDetail",
                column: "Id",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetail_RequestHeaders_Id",
                table: "RequestDetail",
                column: "Id",
                principalTable: "RequestHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHeaders_AspNetUsers_ApplicationUserId",
                table: "RequestHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeRequests_Customers_CustomerId",
                table: "tblFridgeRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeRequests_FridgeAllocations_FaultyFridgeId",
                table: "tblFridgeRequests",
                column: "FaultyFridgeId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeRequests_FridgeAllocations_ReplacementFridgeId",
                table: "tblFridgeRequests",
                column: "ReplacementFridgeId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFridgeVisits_FridgeAllocations_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
