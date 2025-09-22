using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddNewMigraition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFaultTechnicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultTechnicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRequestHeaders",
                columns: table => new
                {
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestTotal = table.Column<double>(type: "float", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestHeaders", x => x.RequestHeaderId);
                    table.ForeignKey(
                        name: "FK_tblRequestHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFridges",
                columns: table => new
                {
                    FridgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPricePerMonth = table.Column<double>(type: "float", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridges", x => x.FridgeId);
                    table.ForeignKey(
                        name: "FK_tblFridges_tblCustomerS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblAllocations",
                columns: table => new
                {
                    AllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllocations", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_tblAllocations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId");
                });

            migrationBuilder.CreateTable(
                name: "tblFridgeRequests",
                columns: table => new
                {
                    FridgeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FaultyFridgeId = table.Column<int>(type: "int", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacementFridgeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeRequests", x => x.FridgeRequestId);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblCustomerS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblFridges_FaultyFridgeId",
                        column: x => x.FaultyFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblFridges_ReplacementFridgeId",
                        column: x => x.ReplacementFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId");
                });

            migrationBuilder.CreateTable(
                name: "tblMaintenanceVisits",
                columns: table => new
                {
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    FridgeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaintenanceVisits", x => x.MaintenanceVisitId);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblCustomerS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblFaultTechnicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "TechnicianId");
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId");
                });

            migrationBuilder.CreateTable(
                name: "tblRequestDetais",
                columns: table => new
                {
                    RequestDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestDetais", x => x.RequestDetailId);
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFridgeVisits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    AllocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeVisits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_tblFridgeVisits_tblAllocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "tblAllocations",
                        principalColumn: "AllocationId");
                    table.ForeignKey(
                        name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFaults",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    ReportedByCustomerId = table.Column<int>(type: "int", nullable: true),
                    ResolvedByTechnicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaults", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_tblFaults_tblCustomerS_ReportedByCustomerId",
                        column: x => x.ReportedByCustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFaults_tblFaultTechnicians_ResolvedByTechnicianId",
                        column: x => x.ResolvedByTechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "TechnicianId");
                    table.ForeignKey(
                        name: "FK_tblFaults_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFaults_tblMaintenanceVisits_MaintenanceVisitId",
                        column: x => x.MaintenanceVisitId,
                        principalTable: "tblMaintenanceVisits",
                        principalColumn: "MaintenanceVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMaintenanceRecords",
                columns: table => new
                {
                    MaintenanceRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaintenanceRecords", x => x.MaintenanceRecordId);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblFaultTechnicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblMaintenanceVisits_MaintenanceVisitId",
                        column: x => x.MaintenanceVisitId,
                        principalTable: "tblMaintenanceVisits",
                        principalColumn: "MaintenanceVisitId");
                });

            migrationBuilder.CreateTable(
                name: "tblProcessFaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    ScheduleFault = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProcessFaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProcessFaults_tblFaults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "tblFaults",
                        principalColumn: "FaultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Condition", "CustomerId", "Description", "FridgeNo", "ImageUrl", "LastMaintenanceDate", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 253, "Excellent", null, "Energy-efficient double door fridge with frost-free technology.", "FRG-001", "https://example.com/images/fridge1.jpg", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RT28T", 1200.0, "Double Door" },
                    { 2, "Rented", "LG", 190, "Good", null, "Compact single door fridge ideal for small apartments.", "FRG-002", "https://example.com/images/fridge2.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "GL-B201", 900.0, "Single Door" },
                    { 3, "Available", "Whirlpool", 500, "Excellent", null, "Spacious fridge with advanced cooling technology.", "FRG-003", "https://example.com/images/fridge3.jpg", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "WRT518", 1500.0, "Double Door" },
                    { 4, "Available", "Defy", 350, "Good", null, "Durable fridge with energy-saving features.", "FRG-004", "https://example.com/images/fridge4.jpg", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "DAC700", 1100.0, "Double Door" },
                    { 5, "Rented", "Hisense", 310, "Good", null, "Compact fridge with adjustable shelves.", "FRG-005", "https://example.com/images/fridge5.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "H310BI", 800.0, "Single Door" },
                    { 6, "Available", "Bosch", 420, "Excellent", null, "Premium fridge with no-frost technology.", "FRG-006", "https://example.com/images/fridge6.jpg", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "KDN42", 1600.0, "Double Door" },
                    { 7, "Available", "Kelvinator", 250, "Fair", null, "Affordable fridge with basic features.", "FRG-007", "https://example.com/images/fridge7.jpg", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "KEL250", 700.0, "Single Door" },
                    { 8, "Available", "Smeg", 281, "Excellent", null, "Retro-style fridge with modern cooling.", "FRG-008", "https://example.com/images/fridge8.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "FAB28", 2000.0, "Single Door" },
                    { 9, "Rented", "AEG", 300, "Excellent", null, "Built-in fridge with adjustable compartments.", "FRG-009", "https://example.com/images/fridge9.jpg", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "SKE818", 1800.0, "Single Door" },
                    { 10, "Available", "Panasonic", 347, "Good", null, "Fridge with inverter technology for energy saving.", "FRG-010", "https://example.com/images/fridge10.jpg", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "NR-BL347", 1300.0, "Double Door" },
                    { 11, "Available", "Haier", 565, "Excellent", null, "Large capacity fridge with twin inverter technology.", "FRG-011", "https://example.com/images/fridge11.jpg", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "HRF-619", 2200.0, "Side by Side" },
                    { 12, "Available", "Hitachi", 640, "Excellent", null, "Premium French door fridge with eco-friendly features.", "FRG-012", "https://example.com/images/fridge12.jpg", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "R-WB640", 2500.0, "French Door" },
                    { 13, "Rented", "Electrolux", 370, "Good", null, "Fridge with taste guard deodorizer.", "FRG-013", "https://example.com/images/fridge13.jpg", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "ETB3700", 1400.0, "Top Freezer" },
                    { 14, "Available", "Sharp", 600, "Excellent", null, "Fridge with plasmacluster ion technology.", "FRG-014", "https://example.com/images/fridge14.jpg", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "SJ-GX60", 2300.0, "French Door" },
                    { 15, "Available", "Midea", 400, "Good", null, "Affordable fridge with large freezer compartment.", "FRG-015", "https://example.com/images/fridge15.jpg", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "HD-400", 1000.0, "Double Door" },
                    { 16, "Available", "Gorenje", 326, "Good", null, "Stylish bottom freezer fridge with crisp zone for vegetables.", "FRG-016", "https://example.com/images/fridge16.jpg", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "NRK6192", 1250.0, "Bottom Freezer" },
                    { 17, "Available", "Westinghouse", 528, "Excellent", null, "Family-sized fridge with humidity-controlled crisper.", "FRG-017", "https://example.com/images/fridge17.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "WBE5300", 1700.0, "Top Freezer" },
                    { 18, "Rented", "Fisher & Paykel", 519, "Excellent", null, "Premium French door fridge with active smart technology.", "FRG-018", "https://example.com/images/fridge18.jpg", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RF522", 2400.0, "French Door" },
                    { 19, "Available", "Ariston", 383, "Good", null, "Reliable fridge with antibacterial coating.", "FRG-019", "https://example.com/images/fridge19.jpg", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "MBA3832", 1150.0, "Top Freezer" },
                    { 20, "Available", "Beko", 560, "Excellent", null, "Spacious bottom freezer fridge with NeoFrost cooling.", "FRG-020", "https://example.com/images/fridge20.jpg", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "RCNE560", 1850.0, "Bottom Freezer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_ApplicationUserId",
                table: "tblAllocations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_FridgeId",
                table: "tblAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_RequestHeaderId",
                table: "tblAllocations",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_FridgeId",
                table: "tblFaults",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_MaintenanceVisitId",
                table: "tblFaults",
                column: "MaintenanceVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_ReportedByCustomerId",
                table: "tblFaults",
                column: "ReportedByCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_ResolvedByTechnicianId",
                table: "tblFaults",
                column: "ResolvedByTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_CustomerId",
                table: "tblFridgeRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_FaultyFridgeId",
                table: "tblFridgeRequests",
                column: "FaultyFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeRequests_ReplacementFridgeId",
                table: "tblFridgeRequests",
                column: "ReplacementFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridges_CustomerId",
                table: "tblFridges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_RequestHeaderId",
                table: "tblFridgeVisits",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceRecords_FridgeId",
                table: "tblMaintenanceRecords",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceRecords_MaintenanceVisitId",
                table: "tblMaintenanceRecords",
                column: "MaintenanceVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceRecords_TechnicianId",
                table: "tblMaintenanceRecords",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_CustomerId",
                table: "tblMaintenanceVisits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_FridgeId",
                table: "tblMaintenanceVisits",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_TechnicianId",
                table: "tblMaintenanceVisits",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProcessFaults_FaultId",
                table: "tblProcessFaults",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_ApplicationUserId",
                table: "tblRequestHeaders",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblFridgeRequests");

            migrationBuilder.DropTable(
                name: "tblFridgeVisits");

            migrationBuilder.DropTable(
                name: "tblMaintenanceRecords");

            migrationBuilder.DropTable(
                name: "tblProcessFaults");

            migrationBuilder.DropTable(
                name: "tblRequestDetais");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblAllocations");

            migrationBuilder.DropTable(
                name: "tblFaults");

            migrationBuilder.DropTable(
                name: "tblRequestHeaders");

            migrationBuilder.DropTable(
                name: "tblMaintenanceVisits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblFaultTechnicians");

            migrationBuilder.DropTable(
                name: "tblFridges");

            migrationBuilder.DropTable(
                name: "tblCustomerS");
        }
    }
}
