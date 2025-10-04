using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfilePictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProfilePictureContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessDocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "FridgeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EnergyRating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MonthlyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HasGlassDoor = table.Column<bool>(type: "bit", nullable: false),
                    HasDigitalDisplay = table.Column<bool>(type: "bit", nullable: false),
                    HasLock = table.Column<bool>(type: "bit", nullable: false),
                    IsFrostFree = table.Column<bool>(type: "bit", nullable: false),
                    ServiceIntervalMonths = table.Column<int>(type: "int", nullable: false),
                    WarrantyPeriodMonths = table.Column<int>(type: "int", nullable: false),
                    MinimumStockLevel = table.Column<int>(type: "int", nullable: false),
                    ReorderQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperatingHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    EmployeeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkLocationId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Employees_Locations_WorkLocationId",
                        column: x => x.WorkLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OperatingHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AlternativePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TradingLocationId = table.Column<int>(type: "int", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTermsDays = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditStatus = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BusinessDocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclinedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Locations_TradingLocationId",
                        column: x => x.TradingLocationId,
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FridgeModelId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WarrantyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextServiceDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalServiceCount = table.Column<int>(type: "int", nullable: false),
                    LastFaultDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Fridges_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fridges_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false),
                    FridgeModelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EstimatedUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: false),
                    QuantityReceived = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
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
                name: "AllocationRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllocationRequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeModelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentalDurationMonths = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocationRequestDetails_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocationRequestHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ReplacingAllocationId = table.Column<int>(type: "int", nullable: true),
                    ReplacingFridgeId = table.Column<int>(type: "int", nullable: true),
                    RelatedFaultRecordId = table.Column<int>(type: "int", nullable: true),
                    IsUrgentReplacement = table.Column<bool>(type: "bit", nullable: false),
                    ReplacementReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryLocationId = table.Column<int>(type: "int", nullable: true),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PreferredDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_AllocationRequestHeaders_Fridges_ReplacingFridgeId",
                        column: x => x.ReplacingFridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllocationRequestHeaders_Locations_DeliveryLocationId",
                        column: x => x.DeliveryLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FridgeAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AllocatedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProcessedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    DeliveryLocationId = table.Column<int>(type: "int", nullable: true),
                    AllocationRequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    ReplacementRequestHeaderId = table.Column<int>(type: "int", nullable: true),
                    ReplacedAllocationId = table.Column<int>(type: "int", nullable: true),
                    AllocationStatus = table.Column<int>(type: "int", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MonthlyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_AllocationRequestHeaders_AllocationRequestHeaderId",
                        column: x => x.AllocationRequestHeaderId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_AllocationRequestHeaders_ReplacementRequestHeaderId",
                        column: x => x.ReplacementRequestHeaderId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_AllocatedByEmployeeId",
                        column: x => x.AllocatedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_ProcessedByEmployeeId",
                        column: x => x.ProcessedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_FridgeAllocations_ReplacedAllocationId",
                        column: x => x.ReplacedAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Locations_DeliveryLocationId",
                        column: x => x.DeliveryLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FaultRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    FaultLocationId = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: true),
                    ReportedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    PartsReplaced = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FaultPhotosUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResolutionPhotosUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocumentationUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResolutionDetails = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RequiresReplacement = table.Column<bool>(type: "bit", nullable: false),
                    ReplacementRecommended = table.Column<bool>(type: "bit", nullable: false),
                    ReplacementRequestId = table.Column<int>(type: "int", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LaborHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WarrantyCovered = table.Column<bool>(type: "bit", nullable: false),
                    CustomerBilled = table.Column<bool>(type: "bit", nullable: false),
                    CustomerInformed = table.Column<bool>(type: "bit", nullable: false),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaultRecords_AllocationRequestHeaders_ReplacementRequestId",
                        column: x => x.ReplacementRequestId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_AspNetUsers_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecords_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_Employees_AssignedTechnicianId",
                        column: x => x.AssignedTechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id");
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AllocationId = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecklistCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ChecklistNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ConditionRating = table.Column<int>(type: "int", nullable: true),
                    TemperatureReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FaultsFound = table.Column<bool>(type: "bit", nullable: false),
                    ReplacementRecommended = table.Column<bool>(type: "bit", nullable: false),
                    ReplacementReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaintenancePerformed = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceDetails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FollowUpRequired = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextServiceDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerRating = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_FridgeAllocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceVisits_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FaultRecordMaintenanceVisit",
                columns: table => new
                {
                    CreatedFaultsId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceVisitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecordMaintenanceVisit", x => new { x.CreatedFaultsId, x.MaintenanceVisitsId });
                    table.ForeignKey(
                        name: "FK_FaultRecordMaintenanceVisit_FaultRecords_CreatedFaultsId",
                        column: x => x.CreatedFaultsId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecordMaintenanceVisit_MaintenanceVisits_MaintenanceVisitsId",
                        column: x => x.MaintenanceVisitsId,
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
                    ServiceNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin_role_id", "admin_concurrency_stamp", "Administrator", "ADMINISTRATOR" },
                    { "customer_role_id", "customer_concurrency_stamp", "Customer", "CUSTOMER" },
                    { "customer_support_role_id", "customer_support_concurrency_stamp", "CustomerSupport", "CUSTOMERSUPPORT" },
                    { "fault_technician_role_id", "fault_technician_concurrency_stamp", "FaultTechnician", "FAULTTECHNICIAN" },
                    { "maintenance_technician_role_id", "maintenance_technician_concurrency_stamp", "MaintenanceTechnician", "MAINTENANCETECHNICIAN" },
                    { "stock_controller_role_id", "stock_controller_concurrency_stamp", "StockController", "STOCKCONTROLLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BusinessDocumentPath", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "DOB", "Email", "EmailConfirmed", "FirstName", "IsApproved", "IsDeleted", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureContentType", "ProfilePictureData", "ProfilePictureUrl", "RejectionReason", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d", 0, null, "d0e1f2a3-5b67-4c8d-9e0f-1a2b3c4d5e6f", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "naterobertson@gmail.com", true, "Nathan", false, false, null, "Robertson", null, true, null, "NATEROBERTSON@GMAIL.COM", "NATEROBERTSON@GMAIL.COM", "AQAAAAIAAYagAAAAEBNX/94VxAPgZaJ/z2xiwMgkLZSIxV948K2Qm8xuhwKAcfoYWym6CMKeKFp9dGYc+g==", "+27691745946", true, null, null, null, null, "c9d0e1f2-4a56-4b7c-8d9e-0f1a2b3c4d5f", false, null, "", "naterobertson@gmail.com" },
                    { "b5a771e9-2f8b-437a-9d0e-7f8b901cde12", 0, null, "c3d456f7-a8b0-4c1d-9e2f-3a4b5c6d7e8f", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customersupport@smartchill.com", true, "Andries", false, false, null, "Tatane", null, true, null, "CUSTOMERSUPPORT@SMARTCHILL.COM", "CUSTOMERSUPPORT@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEJCYyOYrt4DQxf2S2oQNQcsnBrk62cJ0lD/TO9jyPjZPSPjNtr8bfJJdAiurSLXCoA==", "+27710737734", true, null, null, null, null, "d2c345e6-f7a8-4b0c-9d1e-2f3a4b5c6d7e", false, null, "", "customersupport@smartchill.com" },
                    { "c6d882fa-47b9-448b-a9e0-8f9b012d3e45", 0, null, "d5f789ab-c0de-4e1f-9a2b-7c8d9e0f1234", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(1999, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "stockcontroller@smartchill.com", true, "Mido", false, false, null, "Macia", null, true, null, "STOCKCONTROLLER@SMARTCHILL.COM", "STOCKCONTROLLER@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEPkY/rStc/I5dEJC7Tf4f7K5BmZtnGp9BJoEcgkBakMTiCv+1+uqMSwUiq3Dd41qUw==", "+27662934430", true, null, null, null, null, "f4e678a9-b0c1-4d3e-9f5a-6b7c8d9e0f12", false, null, "", "stockcontroller@smartchill.com" },
                    { "d7e9930b-58c0-459c-ba1f-9a0a123b4c56", 0, null, "f7a9bcde-1e23-4f3a-9c4d-1e5f6a7b8c9d", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(1983, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "faulttechnician@smartchill.com", true, "Nathaniel", false, false, null, "Julies", null, true, null, "FAULTTECHNICIAN@SMARTCHILL.COM", "FAULTTECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEPJec7Z6Whl567yC7vG6SRzw1P4CRoYlLsCD9wNlEE5wia0ld5fAEHYu514lO+Sgww==", "+27798946438", true, null, null, null, null, "e6f89abc-0d12-4f2e-8b3c-0d4e5f6a7b8c", false, null, "", "faulttechnician@smartchill.com" },
                    { "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1", 0, null, "a1b234c5-d6e7-4f8a-9b0c-1d2e3f4a5b6c", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@smartchill.com", true, "Collins", false, false, null, "Khosa", null, true, null, "ADMIN@SMARTCHILL.COM", "ADMIN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEPnCBNS4PQrj9JjSqAy+/nbTPMO96RWdfTCFgw3szc75Ya9qzppIj5hExCx+939AXA==", "+27645347790", true, null, null, null, null, "c1fa9012-34b5-4c6d-8e7f-56a7890bc123", false, null, "", "admin@smartchill.com" },
                    { "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e", 0, null, "b8c9d0e1-3f45-4a6b-9f7c-8d9e0f1a2b3c", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(1978, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maintenancetechnician@smartchill.com", true, "Latiefa", false, false, null, "Freeman", null, true, null, "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEOxQsf/HgOCUTxhc1O53mdHCWfG9mD2jlehUVSxCJEzz9Qo4+oExWujRWPfMwu9IQA==", "+27614836998", true, null, null, null, null, "a7b8c9d0-2f34-4e5a-9f6b-7c8d9e0f1a2b", false, null, "", "maintenancetechnician@smartchill.com" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "CapacityLiters", "Color", "CreatedAt", "CreatedBy", "Description", "Dimensions", "EnergyRating", "HasDigitalDisplay", "HasGlassDoor", "HasLock", "ImageUrl", "IsFrostFree", "Manufacturer", "MinimumStockLevel", "ModelCode", "ModelName", "MonthlyRentalPrice", "PurchasePrice", "ReorderQuantity", "ServiceIntervalMonths", "Status", "Type", "UpdatedAt", "UpdatedBy", "WarrantyPeriodMonths" },
                values: new object[,]
                {
                    { 1, 100, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Compact upright fridge ideal for limited-space spaza shops.", "85×55×60", "A", false, false, true, "/images/fridges/defy-compact-100l.jpg", true, "Defy", 3, "DEF-C100", "Compact 100L", 299.00m, 3499.00m, 5, 6, 0, 0, null, null, 24 },
                    { 2, 150, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Sturdy chest freezer for high-volume frozen storage.", "85×70×60", "B", false, false, false, "/images/fridges/defy-chest-150l.jpg", false, "Defy", 2, "DEF-CF150", "Classic Chest 150L", 319.00m, 3899.00m, 4, 12, 0, 1, null, null, 36 },
                    { 3, 200, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Vertical freezer with adjustable shelves and frost-free tech.", "170×58×60", "B", true, false, true, "/images/fridges/hisense-upright-freezer-200l.jpg", true, "Hisense", 2, "HIS-UF200", "Upright Freezer 200L", 429.00m, 4999.00m, 3, 12, 0, 2, null, null, 36 },
                    { 4, 200, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Glass-fronted display fridge with internal LED lighting.", "180×58×60", "A+", false, true, true, "/images/fridges/galaxy-display-200l.jpg", true, "Galaxy", 2, "GAL-DF200", "Display Chiller 200L", 499.00m, 5499.00m, 3, 6, 0, 3, null, null, 24 },
                    { 5, 120, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Slim beverage cooler for cans and bottles display.", "90×50×60", "A", false, true, true, "/images/fridges/lg-beverage-120l.jpg", true, "LG", 3, "LG-BC120", "Beverage Cooler 120L", 389.00m, 4299.00m, 5, 6, 0, 4, null, null, 24 },
                    { 6, 120, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Under-counter fridge perfect for back-bar integration.", "82×60×57", "A", false, false, true, "/images/fridges/defy-undercounter-120l.jpg", true, "Defy", 3, "DEF-UC120", "Undercounter 120L", 349.00m, 4299.00m, 5, 6, 0, 5, null, null, 24 },
                    { 7, 100, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Under-counter freezer module for compact storage.", "82×60×57", "B", false, false, true, "/images/fridges/lg-undercounter-freezer-100l.jpg", true, "LG", 2, "LG-UCF100", "Undercounter Freezer 100L", 369.00m, 4299.00m, 3, 12, 0, 6, null, null, 36 },
                    { 8, 50, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Temperature-controlled wine cooler with glass door.", "85×50×60", "A", true, true, false, "/images/fridges/kic-wine-50l.jpg", true, "KIC", 1, "KIC-WC50", "Wine Cooler 50L", 519.00m, 5799.00m, 2, 6, 0, 7, null, null, 24 },
                    { 9, 300, "Grey", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Combined fridge-freezer with separate temperature zones.", "175×70×65", "A+", true, false, true, "/images/fridges/samsung-combi-300l.jpg", true, "Samsung", 1, "SAM-CBF300", "Combi 300L", 599.00m, 6499.00m, 2, 6, 0, 8, null, null, 24 },
                    { 10, 0, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "High-capacity ice maker, up to 50kg daily output.", "85×60×60", "B", true, false, false, "/images/fridges/kic-ice-maker-50kg.jpg", true, "KIC", 1, "KIC-IM50", "Ice Maker Pro", 799.00m, 8999.00m, 1, 12, 0, 9, null, null, 36 },
                    { 11, 80, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Slim bottle cooler with glass door, ideal for display.", "82×43×58", "A", false, true, true, "/images/fridges/hisense-bottle-80l.jpg", true, "Hisense", 4, "HIS-BC80", "Bottle Cooler 80L", 289.00m, 3299.00m, 6, 6, 0, 10, null, null, 24 },
                    { 12, 250, "Grey", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "High-capacity upright fridge for beverage storage.", "175×70×68", "A+", true, false, true, "/images/fridges/samsung-upright-250l.jpg", true, "Samsung", 2, "SAM-UF250", "Upright Fridge 250L", 599.00m, 6499.00m, 4, 6, 0, 0, null, null, 24 },
                    { 13, 300, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Large chest freezer for bulk frozen inventory.", "90×85×65", "B", false, false, true, "/images/fridges/whirlpool-chest-300l.jpg", false, "Whirlpool", 1, "WHR-CF300", "Chest Freezer 300L", 489.00m, 5599.00m, 2, 12, 0, 1, null, null, 36 },
                    { 14, 350, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Extra-large glass display fridge for retail aisles.", "190×80×70", "A+", false, true, true, "/images/fridges/bosch-display-350l.jpg", true, "Bosch", 1, "BOS-GDF350", "Glass Display 350L", 799.00m, 8999.00m, 2, 6, 0, 3, null, null, 24 },
                    { 15, 150, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Medium-size beverage cooler with fan-forced cooling.", "150×60×60", "A", false, true, true, "/images/fridges/kelvinator-beverage-150l.jpg", true, "Kelvinator", 2, "KEL-BC150", "Beverage Cooler 150L", 519.00m, 5799.00m, 4, 6, 0, 4, null, null, 24 },
                    { 16, 100, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Compact under-counter fridge for limited space.", "82×60×57", "A", false, false, true, "/images/fridges/rh-undercounter-100l.jpg", true, "Russell Hobbs", 3, "RH-UC100", "UnderCounter 100L", 319.00m, 3799.00m, 5, 6, 0, 5, null, null, 24 },
                    { 17, 120, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Under-counter freezer for back-bar deployment.", "82×60×57", "B", false, false, true, "/images/fridges/hisense-undercounter-freezer-120l.jpg", true, "Hisense", 2, "HIS-UCF120", "UnderCounter Freezer 120L", 399.00m, 4599.00m, 3, 12, 0, 6, null, null, 36 },
                    { 18, 70, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Stylish wine cooler with precise temperature control.", "85×50×60", "A", true, true, false, "/images/fridges/defy-wine-70l.jpg", true, "Defy", 1, "DEF-WC70", "Wine Cooler 70L", 579.00m, 6299.00m, 2, 6, 0, 7, null, null, 24 },
                    { 19, 450, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Large combi fridge-freezer with water dispenser.", "179×91×76", "A+", true, false, true, "/images/fridges/lg-combi-450l.jpg", true, "LG", 1, "LG-CBF450", "Combi 450L", 1099.00m, 11999.00m, 2, 6, 0, 8, null, null, 24 },
                    { 20, 90, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Bottle cooler with glass door and internal LED.", "90×50×60", "A", false, true, true, "/images/fridges/whirlpool-bottle-90l.jpg", true, "Whirlpool", 4, "WHR-BC90", "Bottle Cooler 90L", 329.00m, 3899.00m, 6, 6, 0, 10, null, null, 24 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Capacity", "City", "ContactEmail", "ContactPerson", "ContactPhone", "Country", "CreatedAt", "CreatedBy", "IsDeleted", "LocationCode", "LocationType", "Name", "OperatingHours", "PostalCode", "Province", "StreetAddress", "Suburb", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 60, "Paarl", "sophie@paarlspaza.co.za", "Sophie van der Merwe", "+27 21 865 1234", "South Africa", new DateTime(2024, 1, 15, 8, 0, 0, 0, DateTimeKind.Utc), "System", false, "PAARL-SPZ", 5, "Paarl Spaza Shop", "08:00 – 20:00", "7646", "Western Cape", "12 Voortrekker Road", "Paarl", null, null },
                    { 2, 80, "East London", "sipho@bereaconvenience.co.za", "Sipho Mkhize", "+27 43 743 5567", "South Africa", new DateTime(2024, 1, 16, 9, 0, 0, 0, DateTimeKind.Utc), "System", false, "BEREA-CSV", 5, "Berea Convenience Store", "07:00 – 21:00", "5241", "Eastern Cape", "45 Mitchell Street", "Berea", null, null },
                    { 3, 40, "Johannesburg", "thabo@yeovilleshebeen.co.za", "Thabo Khumalo", "+27 11 482 3344", "South Africa", new DateTime(2024, 1, 17, 10, 0, 0, 0, DateTimeKind.Utc), "System", false, "YEOV-SHB", 5, "Yeoville Shebeen", "10:00 – 23:00", "2198", "Gauteng", "88 Goble Road", "Yeoville", null, null },
                    { 4, 200, "Pretoria", "cw@campusdepot.example.com", "Claire van Wyk", "+27 12 420 5000", "South Africa", new DateTime(2024, 1, 18, 11, 0, 0, 0, DateTimeKind.Utc), "System", false, "HATF-DEPOT", 0, "Hatfield Campus Depot", "08:00 – 17:00", "0028", "Gauteng", "15 Jan Shoba Street", "Hatfield", null, null },
                    { 5, 300, "Durban", "lindiwe@distmorningside.co.za", "Lindiwe Dlamini", "+27 31 577 8900", "South Africa", new DateTime(2024, 1, 19, 12, 0, 0, 0, DateTimeKind.Utc), "System", false, "MORN-HUB", 0, "Morningside Distribution Hub", "07:00 – 18:00", "4001", "KwaZulu-Natal", "247 Florida Road", "Morningside", null, null },
                    { 6, 250, "Potchefstroom", "jan@potchdepot.co.za", "Jan van der Merwe", "+27 18 299 4000", "South Africa", new DateTime(2024, 1, 20, 13, 0, 0, 0, DateTimeKind.Utc), "System", false, "POTCH-DEP", 0, "Potchefstroom Depot", "08:30 – 17:30", "2531", "North West", "88 Kerk Street", "Potchefstroom", null, null },
                    { 7, 100, "Bloemfontein", "nokuthula@arcadiaservice.co.za", "Nokuthula Mokoena", "+27 51 432 2100", "South Africa", new DateTime(2024, 1, 21, 14, 0, 0, 0, DateTimeKind.Utc), "System", false, "ARCA-SVC", 2, "Arcadia Service Centre", "09:00 – 17:00", "9301", "Free State", "22 Beatrix Street", "Arcadia", null, null },
                    { 8, 400, "Cape Town", "peter@newlandswhs.co.za", "Peter Adams", "+27 21 650 1234", "South Africa", new DateTime(2024, 1, 22, 15, 0, 0, 0, DateTimeKind.Utc), "System", false, "NEWL-WHS", 0, "Newlands Central Warehouse", "08:00 – 18:00", "7700", "Western Cape", "45 Colinton Road", "Newlands", null, null },
                    { 9, 45, "Dullstroom", "mpho@dullstroomspaza.co.za", "Mpho Khumalo", "+27 13 253 4021", "South Africa", new DateTime(2024, 1, 23, 16, 0, 0, 0, DateTimeKind.Utc), "System", false, "DULL-SPZ", 5, "Dullstroom Spaza Shop", "08:00 – 19:00", "1110", "Mpumalanga", "1 Kerk Street", "Dullstroom", null, null },
                    { 10, 150, "Kimberley", "cheryl.schroeder@mandela.ac.za", "Cheryl Schröder", "+27 53 831 9000", "South Africa", new DateTime(2024, 1, 24, 17, 0, 0, 0, DateTimeKind.Utc), "System", false, "KIMB-SUP", 6, "Kimberley Supplier Yard", "07:30 – 16:30", "8301", "Northern Cape", "12 Schröder Street", "Kimberley", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "customer_role_id", "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d" },
                    { "customer_support_role_id", "b5a771e9-2f8b-437a-9d0e-7f8b901cde12" },
                    { "stock_controller_role_id", "c6d882fa-47b9-448b-a9e0-8f9b012d3e45" },
                    { "fault_technician_role_id", "d7e9930b-58c0-459c-ba1f-9a0a123b4c56" },
                    { "admin_role_id", "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1" },
                    { "maintenance_technician_role_id", "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AvailabilityStatus", "EmployeeNumber", "EmployeeType", "IsDeleted", "UserId", "WorkEmail", "WorkLocationId", "WorkPhone" },
                values: new object[,]
                {
                    { 1, 0, "EMP00001", 0, false, "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1", "admin@smartchill.com", 6, "+27645347790" },
                    { 2, 0, "EMP00002", 1, false, "b5a771e9-2f8b-437a-9d0e-7f8b901cde12", "customersupport@smartchill.com", 10, "+27710737734" },
                    { 3, 0, "EMP00003", 2, false, "c6d882fa-47b9-448b-a9e0-8f9b012d3e45", "stockcontroller@smartchill.com", 2, "+27662934430" },
                    { 4, 0, "EMP00004", 3, false, "d7e9930b-58c0-459c-ba1f-9a0a123b4c56", "faulttechnician@smartchill.com", 5, "+27798946438" },
                    { 5, 0, "EMP00005", 4, false, "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e", "maintenancetechnician@smartchill.com", 5, "+27614836998" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountStatus", "AlternativePhone", "AssignedEmployeeId", "BusinessDocumentPath", "BusinessEmail", "BusinessName", "BusinessPhoneNumber", "BusinessType", "City", "CreditLimit", "CreditStatus", "CustomerSince", "DeclinedAt", "DiscountRate", "IsDeleted", "LocationId", "OperatingHours", "OutstandingBalance", "PaymentTermsDays", "PostalCode", "Province", "RegistrationNumber", "RejectionReason", "StreetAddress", "Suburb", "TradingLocationId", "UserId", "VATNumber" },
                values: new object[] { 1, 1, "+27836549871", 2, null, "orders@boereworspalace.co.za", "Boerewors Palace", "+27218765432", 1, "Paarl", 50000.00m, 1, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.00m, false, null, "Mon-Fri: 7:00-18:00, Sat: 7:00-14:00, Sun: Closed", 1250.50m, 30, "7646", "Western Cape", "2024/123456/07", null, "12 Voortrekker Road", "Paarl", 1, "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d", "4871253690" });

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestDetails_AllocationRequestHeaderId",
                table: "AllocationRequestDetails",
                column: "AllocationRequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestDetails_FridgeModelId",
                table: "AllocationRequestDetails",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_CustomerId",
                table: "AllocationRequestHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_DeliveryLocationId",
                table: "AllocationRequestHeaders",
                column: "DeliveryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_RelatedFaultRecordId",
                table: "AllocationRequestHeaders",
                column: "RelatedFaultRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_ReplacingAllocationId",
                table: "AllocationRequestHeaders",
                column: "ReplacingAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationRequestHeaders_ReplacingFridgeId",
                table: "AllocationRequestHeaders",
                column: "ReplacingFridgeId");

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
                name: "IX_Customers_AssignedEmployeeId",
                table: "Customers",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TradingLocationId",
                table: "Customers",
                column: "TradingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkLocationId",
                table: "Employees",
                column: "WorkLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecordMaintenanceVisit_MaintenanceVisitsId",
                table: "FaultRecordMaintenanceVisit",
                column: "MaintenanceVisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_AssignedTechnicianId",
                table: "FaultRecords",
                column: "AssignedTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FaultLocationId",
                table: "FaultRecords",
                column: "FaultLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FridgeAllocationId",
                table: "FaultRecords",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_FridgeId",
                table: "FaultRecords",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_ReplacementRequestId",
                table: "FaultRecords",
                column: "ReplacementRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_ReportedById",
                table: "FaultRecords",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_AllocatedByEmployeeId",
                table: "FridgeAllocations",
                column: "AllocatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_AllocationRequestHeaderId",
                table: "FridgeAllocations",
                column: "AllocationRequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_CustomerId",
                table: "FridgeAllocations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_DeliveryLocationId",
                table: "FridgeAllocations",
                column: "DeliveryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_FridgeId",
                table: "FridgeAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ProcessedByEmployeeId",
                table: "FridgeAllocations",
                column: "ProcessedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ReplacedAllocationId",
                table: "FridgeAllocations",
                column: "ReplacedAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_ReplacementRequestHeaderId",
                table: "FridgeAllocations",
                column: "ReplacementRequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_CustomerId",
                table: "Fridges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_EmployeeId",
                table: "Fridges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_FridgeModelId",
                table: "Fridges",
                column: "FridgeModelId");

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
                name: "IX_PurchaseRequestItems_FridgeModelId",
                table: "PurchaseRequestItems",
                column: "FridgeModelId");

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
                name: "FK_AllocationRequestDetails_AllocationRequestHeaders_AllocationRequestHeaderId",
                table: "AllocationRequestDetails",
                column: "AllocationRequestHeaderId",
                principalTable: "AllocationRequestHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllocationRequestHeaders_FaultRecords_RelatedFaultRecordId",
                table: "AllocationRequestHeaders",
                column: "RelatedFaultRecordId",
                principalTable: "FaultRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocationRequestHeaders_FridgeAllocations_ReplacingAllocationId",
                table: "AllocationRequestHeaders",
                column: "ReplacingAllocationId",
                principalTable: "FridgeAllocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AllocationRequestHeaders_ReplacementRequestId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_AllocationRequestHeaders_AllocationRequestHeaderId",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_AllocationRequestHeaders_ReplacementRequestHeaderId",
                table: "FridgeAllocations");

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
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MaintenanceVisits");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "AllocationRequestHeaders");

            migrationBuilder.DropTable(
                name: "FaultRecords");

            migrationBuilder.DropTable(
                name: "FridgeAllocations");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FridgeModels");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
