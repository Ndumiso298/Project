using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerLiaisonId = table.Column<int>(type: "int", nullable: true),
                    TradingName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Employees_CustomerLiaisonId",
                        column: x => x.CustomerLiaisonId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocationRequestHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationRequestHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocationRequestHeaders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RentalPricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WarrantyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnergyRating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ServiceIntervalMonths = table.Column<int>(type: "int", nullable: false),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextServiceDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocationRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocationRequestDetails_AllocationRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocationRequestDetails_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FridgeAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AllocatedById = table.Column<int>(type: "int", nullable: false),
                    ProcessedById = table.Column<int>(type: "int", nullable: false),
                    AllocationLocationId = table.Column<int>(type: "int", nullable: false),
                    AllocationRequestHeaderId = table.Column<int>(type: "int", nullable: true),
                    StoredPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_AllocationRequestHeaders_AllocationRequestHeaderId",
                        column: x => x.AllocationRequestHeaderId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_AllocatedById",
                        column: x => x.AllocatedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_ProcessedById",
                        column: x => x.ProcessedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Locations_AllocationLocationId",
                        column: x => x.AllocationLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    QuantityReceived = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaultRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: true),
                    ReportedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: true),
                    FaultLocationId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcknowledgedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RepairCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartsReplaced = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WarrantyCovered = table.Column<bool>(type: "bit", nullable: true),
                    CustomerCharged = table.Column<bool>(type: "bit", nullable: false),
                    CustomerRating = table.Column<int>(type: "int", nullable: true),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FaultPhotoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResolutionPhotoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaultRecords_AspNetUsers_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_Employees_FaultTechnicianId",
                        column: x => x.FaultTechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecords_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecords_Locations_FaultLocationId",
                        column: x => x.FaultLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: true),
                    AllocationId = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: true),
                    IsChecklistCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ChecklistNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ActualStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FridgeConditionRating = table.Column<int>(type: "int", nullable: true),
                    TemperatureReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IssuesFound = table.Column<bool>(type: "bit", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaintenancePerformed = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceDetails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PartsReplaced = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FollowUpRequired = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CustomerNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerRating = table.Column<int>(type: "int", nullable: true),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Employees_AssignedTechnicianId",
                        column: x => x.AssignedTechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_FridgeAllocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaultRecordMaintenanceVisit",
                columns: table => new
                {
                    FaultRecordsId = table.Column<int>(type: "int", nullable: false),
                    RelatedMaintenanceVisitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecordMaintenanceVisit", x => new { x.FaultRecordsId, x.RelatedMaintenanceVisitsId });
                    table.ForeignKey(
                        name: "FK_FaultRecordMaintenanceVisit_FaultRecords_FaultRecordsId",
                        column: x => x.FaultRecordsId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecordMaintenanceVisit_MaintenanceVisits_RelatedMaintenanceVisitsId",
                        column: x => x.RelatedMaintenanceVisitsId,
                        principalTable: "MaintenanceVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ServiceNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartsUsed = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsWarrantyClaim = table.Column<bool>(type: "bit", nullable: false),
                    WarrantyReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Employees_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_MaintenanceVisits_MaintenanceVisitId",
                        column: x => x.MaintenanceVisitId,
                        principalTable: "MaintenanceVisits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReplacementRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false),
                    FaultRecordId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceRecordId = table.Column<int>(type: "int", nullable: true),
                    AssignedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_FaultRecords_FaultRecordId",
                        column: x => x.FaultRecordId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_MaintenanceRecords_MaintenanceRecordId",
                        column: x => x.MaintenanceRecordId,
                        principalTable: "MaintenanceRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Administrator", "ADMINISTRATOR" },
                    { "2", null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { "3", null, "StockController", "STOCKCONTROLLER" },
                    { "4", null, "FaultTechnician", "FAULTTECHNICIAN" },
                    { "5", null, "MaintenanceTechnician", "MAINTENANCETECHNICIAN" },
                    { "6", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "CreatedAt", "IsActive", "Name", "PostalCode", "Province", "Suburb", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "Corner of 5th Ave", "Johannesburg", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9499), true, "Boerewors Palace", "2001", "Gauteng", "CBD", null },
                    { 2, "123 Main Road", "Unit 4", "Gqeberha", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9593), true, "SmartChill Warehouse - Gqeberha", "6070", "Eastern Cape", "Walmer", null },
                    { 3, "10 Rivonia Road", "Floor 3", "Johannesburg", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9597), true, "SmartChill Warehouse - Johannesburg", "2196", "Gauteng", "Sandton", null },
                    { 4, "55 Industria Road", null, "Cape Town", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9601), true, "SmartChill Warehouse - Cape Town", "7460", "Western Cape", "Epping", null },
                    { 5, "18 Workshop Avenue", null, "Durban", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9605), true, "SmartChill Service Center", "3610", "KwaZulu-Natal", "Pinetown", null },
                    { 6, "22 Nelson Mandela Drive", "Suite 101", "Bloemfontein", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9608), true, "SmartChill Regional Office - Bloemfontein", "9301", "Free State", "Westdene", null },
                    { 7, "7 Lowveld Street", null, "Mbombela", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9611), true, "SmartChill Depot - Nelspruit", "1201", "Mpumalanga", "Riverside", null },
                    { 8, "89 Market Street", null, "Polokwane", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9614), true, "SmartChill Showroom - Polokwane", "0700", "Limpopo", "Flora Park", null },
                    { 9, "14 Platinum Drive", null, "Rustenburg", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9617), true, "SmartChill Satellite Office - Rustenburg", "0299", "North West", "Bo-dorp", null },
                    { 10, "5 Diamond Road", "Block B", "Kimberley", "South Africa", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9620), true, "SmartChill Support Hub - Kimberley", "8301", "Northern Cape", "Monument Heights", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CustomerId", "DOB", "Email", "EmailConfirmed", "EmployeeId", "FirstName", "IsActive", "LastName", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "2a49fb43-2b6c-4c1f-994d-f6601efee470", new DateTime(2025, 9, 23, 9, 15, 23, 396, DateTimeKind.Utc).AddTicks(9825), null, null, "admin@smartchill.com", true, null, "Collins", true, "Khosa", 6, false, null, "ADMIN@SMARTCHILL.COM", "ADMIN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEDL6EoGeJ2W3jw1xVeYr0Poq47dsJODl2bCfQ8JUu7y+PQe6O4AcBE/GHQPZ34s9Nw==", "+27 64 534 7790", true, null, "1c9e3b16-9a6c-45ee-8b1a-ee069d0ca868", false, null, "admin@smartchill.com" },
                    { "2", 0, "23fe5346-5fc4-4f61-b9f9-cb8eabeb1a46", new DateTime(2025, 9, 23, 9, 15, 23, 475, DateTimeKind.Utc).AddTicks(5502), null, null, "customersupport@smartchill.com", true, null, "Andries", true, "Tatane", 10, false, null, "CUSTOMERSUPPORT@SMARTCHILL.COM", "CUSTOMERSUPPORT@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEC9yoEbzT7QKChUX2dGgmOCrVGVgZBPQKAb235lLFzWW89qW8dCVFi91irXnZGn76w==", "+27 71 073 7734", true, null, "0e14b18a-9832-49d4-81eb-cdc5aa81cd29", false, null, "customersupport@smartchill.com" },
                    { "3", 0, "c20102bf-16e0-473a-9a63-698fe8425675", new DateTime(2025, 9, 23, 9, 15, 23, 552, DateTimeKind.Utc).AddTicks(5321), null, null, "stockcontroller@smartchill.com", true, null, "Mido", true, "Macia", 2, false, null, "STOCKCONTROLLER@SMARTCHILL.COM", "STOCKCONTROLLER@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEHfusF7p3ALRYnic6g/UwXzZ0ODoLHENzik8BbQVU1DopqNCCQMlGX7vRFH5amYhCA==", "+27 66 293 4430", true, null, "0c4bb951-31b7-4270-abc4-6ae71d83bdd0", false, null, "stockcontroller@smartchill.com" },
                    { "4", 0, "02d04e7a-3a99-4ffc-bd0d-fcc3a59c691f", new DateTime(2025, 9, 23, 9, 15, 23, 638, DateTimeKind.Utc).AddTicks(3147), null, null, "faulttechnician@smartchill.com", true, null, "Nathaniel", true, "Julies", 5, false, null, "FAULTTECHNICIAN@SMARTCHILL.COM", "FAULTTECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEDvDmixQplSjmczmdL3kDSFjSq7hfXaJ8J1OvHeCwTsTKnGGvI6oCCLbPwyE+gUKog==", "+27 79 894 6438", true, null, "36377c0e-b7c3-4600-8fda-323509aa7a61", false, null, "faulttechnician@smartchill.com" },
                    { "5", 0, "a4027681-16d2-412a-80a9-0c0109b53c7b", new DateTime(2025, 9, 23, 9, 15, 23, 720, DateTimeKind.Utc).AddTicks(6355), null, null, "maintenancetechnician@smartchill.com", true, null, "Latiefa", true, "Freeman", 5, false, null, "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEObevbDW3ACZBQ9nlXx8XPTfpFIGH/zhAxbRAqTxujsRhc+Hby3EASY1aDu00QoW9A==", "+27 61 483 6998", true, null, "6fbec418-a1ca-4d0f-918f-b34579208393", false, null, "maintenancetechnician@smartchill.com" },
                    { "6", 0, "7d8b2cae-2fa1-49ab-aeda-d832c2af6966", new DateTime(2025, 9, 23, 9, 15, 23, 803, DateTimeKind.Utc).AddTicks(3567), null, null, "naterobertson@gmail.com", true, null, "Nathan", true, "Robertson", 1, false, null, "NATEROBERTSON@GMAIL.COM", "NATEROBERTSON@GMAIL.COM", "AQAAAAIAAYagAAAAEIbrP1K5aXuEeTA7FgVMwtwAFql28Aqhs+qkEPqEor0OJbt5ULTIl8YhSpGcpmtnPg==", "+27 69 174 5946", true, null, "779f809f-dcb9-4d84-86b1-2b8a6c29d405", false, null, "naterobertson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CapacityLiters", "Color", "Condition", "CreatedDate", "CustomerId", "Description", "Dimensions", "EmployeeId", "EnergyRating", "ImageUrl", "IsActive", "LastMaintenanceDate", "LastServiceDate", "LocationId", "Manufacturer", "Model", "ModifiedDate", "NextServiceDue", "PurchaseDate", "PurchasePrice", "RentalPricePerMonth", "SerialNumber", "ServiceIntervalMonths", "Status", "Type", "WarrantyExpiryDate", "Weight" },
                values: new object[,]
                {
                    { 1, 290, "Stainless Steel", 0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Commercial beverage fridge with glass door, perfect for beer and drinks display.", "180×70×70cm", null, "A+", "https://images.unsplash.com/photo-1629367494173-c78a56567877", true, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Samsung", "RB29F", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000.00m, 1500.00m, "SAM-BEER-001", 6, 0, "Double Door Commercial", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.5m },
                    { 2, 420, "Black", 1, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Large capacity glass door fridge for bar use, ideal for beverage storage.", "190×80×75cm", null, "A", "https://images.unsplash.com/photo-1579389083078-4e7018379f7e", true, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "LG", "GL-D422CL", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.00m, 1800.00m, "LG-BAR-202", 6, 1, "Glass Door Display", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.0m },
                    { 3, 638, "Silver", 2, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Large capacity reach-in fridge for high-volume shebeen operations.", "200×90×85cm", null, "B", "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91", true, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Hisense", "QR638W", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000.00m, 2200.00m, "HIS-SHEB-303", 6, 3, "Commercial Reach-In", new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.0m },
                    { 4, 388, "White", 0, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Upright freezer with multiple shelves, perfect for frozen goods in spaza shops.", "170×65×65cm", null, "A+", "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19", true, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Defy", "FF388", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9500.00m, 1200.00m, "DEFY-SPAZA-404", 6, 0, "Upright Freezer", new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0m },
                    { 5, 270, "Silver", 1, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Energy-efficient chest freezer for bulk frozen food storage.", "140×75×85cm", null, "A", "https://images.unsplash.com/photo-1631549916768-4119c9ff7ac5", true, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Snapper", "CUF270", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7000.00m, 950.00m, "SNAP-SPAZA-505", 6, 1, "Chest Freezer", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.0m },
                    { 6, 450, "Silver", 0, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Spacious double door fridge with separate freezer compartment.", "175×70×70cm", null, "A+", "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5", true, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Kelvinator", "KFR450", new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11000.00m, 1300.00m, "KELV-SPAZA-606", 6, 0, "Double Door Fridge", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0m },
                    { 7, 780, "Stainless Steel", 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Large French door commercial fridge with ice maker, perfect for high-volume establishments.", "185×95×80cm", null, "A++", "https://images.unsplash.com/photo-1598301257982-0cf01499abb2", true, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "LG", "LFXS28566", new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000.00m, 2500.00m, "LG-SHEB-707", 6, 4, "French Door Commercial", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.0m },
                    { 8, 385, "White", 2, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reliable top mount freezer fridge for small spaza shops.", "170×65×65cm", null, "B", "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5", true, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Samsung", "RT38K", new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000.00m, 1100.00m, "SAM-SPAZA-808", 6, 3, "Top Mount Freezer", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.0m },
                    { 9, 392, "Black", 0, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Commercial double door fridge with digital temperature control.", "180×70×70cm", null, "A+", "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91", true, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Defy", "DDT392", new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000.00m, 1600.00m, "DEFY-SHEB-909", 6, 0, "Double Door Commercial", new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0m },
                    { 10, 550, "Stainless Steel", 1, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heavy-duty commercial reach-in fridge for bars and shebeens.", "190×80×75cm", null, "A", "https://images.unsplash.com/photo-1629367494173-c78a56567877", true, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Snapper", "CRF550", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000.00m, 1900.00m, "SNAP-SHEB-1010", 6, 1, "Commercial Reach-In", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0m },
                    { 11, 472, "Silver", 0, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bottom freezer fridge with ample storage for spaza shops.", "175×70×70cm", null, "A+", "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19", true, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "LG", "GN-B472SLC", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 11500.00m, 1400.00m, "LG-SPAZA-1111", 6, 0, "Bottom Freezer", new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.0m },
                    { 12, 260, "Black", 1, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact bar fridge perfect for small shebeens or as additional storage.", "85×55×55cm", null, "A", "https://images.unsplash.com/photo-1579389083078-4e7018379f7e", true, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "Samsung", "BRB260", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6800.00m, 850.00m, "SAM-SHEB-1212", 6, 5, "Bar Fridge", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0m },
                    { 13, 420, "Stainless Steel", 2, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium fridge with advanced cooling technology for spaza shops.", "180×70×70cm", null, "A", "https://images.unsplash.com/photo-1598301257982-0cf01499abb2", true, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, "Defy", "PLT420", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14000.00m, 1700.00m, "DEFY-SPAZA-1313", 6, 2, "Platinum Series", new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.0m },
                    { 14, 718, "Silver", 1, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Extra large reach-in fridge for high-capacity shebeen operations.", "200×90×85cm", null, "B", "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91", true, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, "Hisense", "QR718W", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000.00m, 2400.00m, "HIS-SHEB-1414", 6, 7, "Commercial Reach-In", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 115.0m },
                    { 15, 300, "White", 0, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Economical single door fridge for small spaza shops.", "150×60×60cm", null, "A", "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5", true, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "Kelvinator", "KFR300", new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7800.00m, 950.00m, "KELV-SPAZA-1515", 6, 0, "Single Door", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0m },
                    { 16, 200, "Black", 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact beverage cooler for bars and shebeens.", "90×50×50cm", null, "A", "https://images.unsplash.com/photo-1629367494173-c78a56567877", true, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Snapper", "BVF200", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6500.00m, 800.00m, "SNAP-SHEB-1616", 6, 6, "Beverage Cooler", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.0m },
                    { 17, 502, "Stainless Steel", 0, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Glass door display fridge for spaza shops to showcase products.", "185×75×75cm", null, "A+", "https://images.unsplash.com/photo-1579389083078-4e7018379f7e", true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "LG", "GL-L502CL", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14500.00m, 1750.00m, "LG-SPAZA-1717", 6, 0, "Glass Door Display", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0m },
                    { 18, 330, "Black", 1, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Commercial double door fridge with digital display and precise temperature control.", "180×70×70cm", null, "A+", "https://images.unsplash.com/photo-1598301257982-0cf01499abb2", true, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Samsung", "RB33T", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13500.00m, 1650.00m, "SAM-SHEB-1818", 6, 1, "Double Door Commercial", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.0m },
                    { 19, 250, "White", 0, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact top mount freezer fridge for small spaza shop operations.", "160×65×65cm", null, "A", "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19", true, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Defy", "FFT250", new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8200.00m, 1000.00m, "DEFY-SPAZA-1919", 6, 0, "Top Mount Freezer", new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0m },
                    { 20, 828, "Silver", 1, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Extra large commercial reach-in fridge for high-volume shebeen operations.", "210×95×90cm", null, "B", "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91", true, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Hisense", "QR828W", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21000.00m, 2600.00m, "HIS-SHEB-2020", 6, 8, "Commercial Reach-In", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.0m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" },
                    { "5", "5" },
                    { "6", "6" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AvailabilityStatus", "CreatedAt", "EmployeeNumber", "EmployeeType", "IsActive", "LocationId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS001", "CustomerSupport", true, null, null, "2" },
                    { 2, 1, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC001", "StockController", true, null, null, "3" },
                    { 3, 0, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FT001", "FaultTechnician", true, null, null, "4" },
                    { 4, 0, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MT001", "MaintenanceTechnician", true, null, null, "5" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "BusinessEmail", "BusinessPhoneNumber", "BusinessType", "City", "CreatedAt", "CustomerLiaisonId", "IsActive", "LocationId", "PostalCode", "Province", "TradingName", "UpdatedAt", "UserId" },
                values: new object[] { 1, "123 Main Street", "Corner of 5th Ave", "info@boereworspalace.co.za", "+27 11 555 0101", 2, "Johannesburg", new DateTime(2025, 9, 23, 9, 15, 23, 885, DateTimeKind.Utc).AddTicks(372), 1, true, 1, "2001", "Gauteng", "Boerewors Palace", null, "6" });

            migrationBuilder.InsertData(
                table: "PurchaseRequests",
                columns: new[] { "Id", "ApprovalDate", "ApprovalNotes", "ApprovedBudget", "ApprovedById", "CreatedAt", "CustomReason", "EstimatedTotalCost", "Reason", "RequestDate", "RequestedById", "RequiredByDate", "Status", "UpdatedAt", "Urgency" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2025, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), null, 24000.00m, 0, new DateTime(2025, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), 2, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2 },
                    { 2, null, null, null, null, new DateTime(2025, 8, 20, 9, 15, 0, 0, DateTimeKind.Utc), "Compressor failure in multiple units", 5000.00m, 2, new DateTime(2025, 8, 20, 9, 15, 0, 0, DateTimeKind.Utc), 2, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestDetails_FridgeId",
                table: "AllocationRequestDetails",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestDetails_RequestHeaderId",
                table: "AllocationRequestDetails",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_CustomerId",
                table: "AllocationRequestHeaders",
                column: "CustomerId");

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
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecordMaintenanceVisit_RelatedMaintenanceVisitsId",
                table: "FaultRecordMaintenanceVisit",
                column: "RelatedMaintenanceVisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FaultLocationId",
                table: "FaultRecords",
                column: "FaultLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FaultTechnicianId",
                table: "FaultRecords",
                column: "FaultTechnicianId");

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
                name: "IX_FridgeAllocations_AllocatedById",
                table: "FridgeAllocations",
                column: "AllocatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_AllocationLocationId",
                table: "FridgeAllocations",
                column: "AllocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_AllocationRequestHeaderId",
                table: "FridgeAllocations",
                column: "AllocationRequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_CustomerId",
                table: "FridgeAllocations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_FridgeId",
                table: "FridgeAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ProcessedById",
                table: "FridgeAllocations",
                column: "ProcessedById");

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
                name: "IX_MaintenanceRecords_FridgeId",
                table: "MaintenanceRecords",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MaintenanceVisitId",
                table: "MaintenanceRecords",
                column: "MaintenanceVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_TechnicianId",
                table: "MaintenanceRecords",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_AllocationId",
                table: "MaintenanceVisits",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_AssignedTechnicianId",
                table: "MaintenanceVisits",
                column: "AssignedTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_CustomerId",
                table: "MaintenanceVisits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_FridgeId",
                table: "MaintenanceVisits",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVisits_LocationId",
                table: "MaintenanceVisits",
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

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_AssignedEmployeeId",
                table: "ReplacementRequests",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_FaultRecordId",
                table: "ReplacementRequests",
                column: "FaultRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_FridgeAllocationId",
                table: "ReplacementRequests",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_MaintenanceRecordId",
                table: "ReplacementRequests",
                column: "MaintenanceRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocationRequestDetails");

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
                name: "FaultRecordMaintenanceVisit");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "ReplacementRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "FaultRecords");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "MaintenanceVisits");

            migrationBuilder.DropTable(
                name: "FridgeAllocations");

            migrationBuilder.DropTable(
                name: "AllocationRequestHeaders");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
