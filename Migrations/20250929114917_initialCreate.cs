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
                name: "FridgeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MonthlyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EnergyRating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Voltage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PowerConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TemperatureRange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HasGlassDoor = table.Column<bool>(type: "bit", nullable: false),
                    HasDigitalDisplay = table.Column<bool>(type: "bit", nullable: false),
                    HasLock = table.Column<bool>(type: "bit", nullable: false),
                    IsFrostFree = table.Column<bool>(type: "bit", nullable: false),
                    ServiceIntervalMonths = table.Column<int>(type: "int", nullable: false),
                    WarrantyPeriodMonths = table.Column<int>(type: "int", nullable: false),
                    MinimumStockLevel = table.Column<int>(type: "int", nullable: false),
                    ReorderQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsScrapped = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
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
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
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
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    LockoutEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        principalColumn: "Id");
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
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    EmploymentType = table.Column<int>(type: "int", nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkLocationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AssignedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TradingName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AlternativePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTermsDays = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreditStatus = table.Column<int>(type: "int", nullable: false),
                    CustomerSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                        name: "FK_Customers_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
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
                    RequestNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryLocationId = table.Column<int>(type: "int", nullable: false),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PreferredDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
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
                        name: "FK_AllocationRequestHeaders_Locations_DeliveryLocationId",
                        column: x => x.DeliveryLocationId,
                        principalTable: "Locations",
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
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WarrantyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextServiceDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalServiceCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsScrapped = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    FridgeModelId = table.Column<int>(type: "int", nullable: false),
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
                    SpecialRequirements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocationRequestDetails_AllocationRequestHeaders_AllocationRequestHeaderId",
                        column: x => x.AllocationRequestHeaderId,
                        principalTable: "AllocationRequestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocationRequestDetails_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
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
                    AllocatedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProcessedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    DeliveryLocationId = table.Column<int>(type: "int", nullable: false),
                    AllocationRequestHeaderId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MonthlyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
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
                        name: "FK_FridgeAllocations_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Locations_DeliveryLocationId",
                        column: x => x.DeliveryLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaultRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FaultLocationId = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: true),
                    ReportedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcknowledgedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStartedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicalDiagnosis = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RootCause = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResolutionDetails = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LaborHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartsReplaced = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsWarrantyClaim = table.Column<bool>(type: "bit", nullable: false),
                    WarrantyApproved = table.Column<bool>(type: "bit", nullable: true),
                    CustomerBilled = table.Column<bool>(type: "bit", nullable: false),
                    BillingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerInformed = table.Column<bool>(type: "bit", nullable: false),
                    CustomerNotifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerSatisfactionRating = table.Column<int>(type: "int", nullable: true),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FaultPhotosUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResolutionPhotosUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocumentationUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecords", x => x.Id);
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
                    VisitType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    AllocationId = table.Column<int>(type: "int", nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsChecklistCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ChecklistNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ActualStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConditionRating = table.Column<int>(type: "int", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_MaintenanceVisits_Employees_TechnicianId",
                        column: x => x.TechnicianId,
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaultRecordMaintenanceVisit",
                columns: table => new
                {
                    FaultRecordsId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceVisitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecordMaintenanceVisit", x => new { x.FaultRecordsId, x.MaintenanceVisitsId });
                    table.ForeignKey(
                        name: "FK_FaultRecordMaintenanceVisit_FaultRecords_FaultRecordsId",
                        column: x => x.FaultRecordsId,
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
                    ServiceType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ServiceNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    CustomerId = table.Column<int>(type: "int", nullable: true),
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
                    ReplacementFridgeId = table.Column<int>(type: "int", nullable: true),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaultyFridgeReturned = table.Column<bool>(type: "bit", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_ReplacementRequests_Fridges_ReplacementFridgeId",
                        column: x => x.ReplacementFridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id");
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
                    { "admin_role_id", "admin_concurrency_stamp", "Administrator", "ADMINISTRATOR" },
                    { "customer_role_id", "customer_concurrency_stamp", "Customer", "CUSTOMER" },
                    { "customer_support_role_id", "customer_support_concurrency_stamp", "CustomerSupport", "CUSTOMERSUPPORT" },
                    { "fault_technician_role_id", "fault_technician_concurrency_stamp", "FaultTechnician", "FAULTTECHNICIAN" },
                    { "maintenance_technician_role_id", "maintenance_technician_concurrency_stamp", "MaintenanceTechnician", "MAINTENANCETECHNICIAN" },
                    { "stock_controller_role_id", "stock_controller_concurrency_stamp", "StockController", "STOCKCONTROLLER" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "CapacityLiters", "Color", "CreatedAt", "CreatedBy", "Description", "Dimensions", "EnergyRating", "HasDigitalDisplay", "HasGlassDoor", "HasLock", "ImageUrl", "IsActive", "IsFrostFree", "IsScrapped", "Manufacturer", "MinimumStockLevel", "ModelCode", "ModelName", "ModifiedAt", "ModifiedBy", "MonthlyRentalPrice", "PowerConsumption", "PurchasePrice", "ReorderQuantity", "ServiceIntervalMonths", "TemperatureRange", "Type", "Voltage", "WarrantyPeriodMonths", "WeightKg" },
                values: new object[,]
                {
                    { 1, 100, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Compact upright fridge perfect for small businesses with limited space. Energy efficient and reliable.", "85×55×60", "A", false, false, true, "/images/fridges/defy-compact-100l.jpg", true, true, false, "Defy", 3, "DEF-C100", "Compact 100L", null, null, 299.00m, 180m, 3499.00m, 5, 6, "2°C to 8°C", 0, "220-240V", 24, 45m },
                    { 2, 150, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Reliable commercial fridge with digital temperature control and robust construction.", "90×60×65", "A+", true, false, true, "/images/fridges/lg-business-cool-150l.jpg", true, true, false, "LG", 2, "LG-BC150", "Business Cool 150L", null, null, 399.00m, 210m, 4599.00m, 4, 6, "1°C to 10°C", 0, "220-240V", 36, 52m },
                    { 3, 120, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Budget-friendly frost-free fridge ideal for small retail spaces and startups.", "88×58×62", "B", false, false, true, "/images/fridges/hisense-frostfree-120l.jpg", true, true, false, "Hisense", 4, "HIS-FF120", "FrostFree 120L", null, null, 259.00m, 195m, 2999.00m, 6, 6, "3°C to 8°C", 0, "220-240V", 24, 48m },
                    { 4, 180, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Medium capacity commercial fridge with digital controls and efficient cooling.", "95×65×68", "A+", true, false, true, "/images/fridges/samsung-commercial-180l.jpg", true, true, false, "Samsung", 2, "SAM-C180", "Commercial 180L", null, null, 449.00m, 225m, 5199.00m, 4, 6, "0°C to 8°C", 0, "220-240V", 36, 58m },
                    { 5, 150, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Energy-efficient chest freezer perfect for frozen goods storage in small businesses.", "85×55×80", "A", false, false, true, "/images/fridges/kic-chest-150l.jpg", true, false, false, "KIC", 3, "KIC-SC150", "Small Chest 150L", null, null, 279.00m, 190m, 3299.00m, 5, 6, "-18°C to -25°C", 1, "220-240V", 24, 42m },
                    { 6, 280, "Black Glass", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Professional glass door display fridge perfect for bars and restaurants showcasing beverages.", "185×65×70", "A", true, true, true, "/images/fridges/bartech-glass-display-280l.jpg", true, true, false, "Bartech", 2, "BAR-GD280", "Glass Display 280L", null, null, 699.00m, 320m, 7899.00m, 3, 4, "2°C to 6°C", 3, "220-240V", 24, 95m },
                    { 7, 150, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Professional undercounter fridge built for commercial kitchens with stainless steel construction.", "85×60×70", "A+", true, false, true, "/images/fridges/foster-undercounter-150l.jpg", true, true, false, "Foster", 2, "FOS-UC150", "Undercounter 150L", null, null, 549.00m, 280m, 6299.00m, 3, 4, "1°C to 7°C", 5, "220-240V", 36, 68m },
                    { 8, 200, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Dedicated beverage cooler with multiple shelves, perfect for canned drinks and bottles.", "85×60×65", "A", true, true, true, "/images/fridges/true-beverage-200l.jpg", true, true, false, "True", 2, "TRU-BC200", "Beverage Cooler 200L", null, null, 499.00m, 240m, 5799.00m, 4, 6, "3°C to 8°C", 4, "220-240V", 24, 55m },
                    { 9, 25, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Commercial ice maker producing up to 25kg of ice per day, essential for bars and restaurants.", "75×55×65", "A", true, false, false, "/images/fridges/hoshizaki-ice-maker.jpg", true, true, false, "Hoshizaki", 1, "HOS-IM25", "Ice Maker Pro", null, null, 429.00m, 180m, 4899.00m, 2, 3, "N/A", 9, "220-240V", 24, 48m },
                    { 10, 120, "Black Glass", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Dual-zone wine cooler with precise temperature control for red and white wines.", "85×60×60", "A+", true, true, true, "/images/fridges/perlick-wine-cooler.jpg", true, true, false, "Perlick", 1, "PER-WC120", "Wine Cooler 120L", null, null, 399.00m, 160m, 4599.00m, 2, 6, "5°C to 18°C", 7, "220-240V", 36, 52m },
                    { 11, 500, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Large multi-deck display fridge for supermarkets with excellent product visibility.", "200×120×80", "A+", true, true, true, "/images/fridges/hussmann-multideck-500l.jpg", true, true, false, "Hussmann", 1, "HUS-MD500", "Multi-Deck 500L", null, null, 1199.00m, 580m, 13999.00m, 2, 3, "2°C to 6°C", 3, "220-240V", 24, 220m },
                    { 12, 350, "Glass Door", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "High-capacity bottle cooler designed for liquor stores and large bars.", "190×70×75", "A", true, true, true, "/images/fridges/beverage-air-bottle-350l.jpg", true, true, false, "Beverage-Air", 1, "BEV-BC350", "Bottle Cooler 350L", null, null, 849.00m, 420m, 9899.00m, 2, 4, "3°C to 7°C", 10, "220-240V", 24, 125m },
                    { 13, 400, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Professional combination fridge-freezer unit for commercial kitchens and hotels.", "185×80×75", "A+", true, false, true, "/images/fridges/traulsen-combi-400l.jpg", true, true, false, "Traulsen", 1, "TRA-C400", "Combi 400L", null, null, 999.00m, 480m, 11599.00m, 2, 3, "-18°C to 5°C", 8, "220-240V", 36, 145m },
                    { 14, 300, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Large upright freezer with multiple shelves for organized frozen storage.", "180×70×70", "A", true, false, true, "/images/fridges/victory-upright-freezer-300l.jpg", true, true, false, "Victory", 2, "VIC-UF300", "Upright Freezer 300L", null, null, 599.00m, 350m, 6999.00m, 3, 6, "-18°C to -25°C", 2, "220-240V", 24, 98m },
                    { 15, 1000, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Modular walk-in cooler system for large-scale storage in supermarkets and hotels.", "240×200×220", "A+", true, false, true, "/images/fridges/norlake-walk-in.jpg", true, true, false, "Nor-Lake", 0, "NOR-WIC1000", "Walk-In Cooler", null, null, 2499.00m, 1200m, 28999.00m, 1, 2, "1°C to 4°C", 0, "380V", 24, 450m },
                    { 16, 250, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Specialized undercounter fridge with roll-down door for pizza restaurants.", "85×75×70", "A", true, false, true, "/images/fridges/delfield-pizza-prep.jpg", true, true, false, "Delfield", 1, "DEL-PP250", "Pizza Prep 250L", null, null, 549.00m, 280m, 6399.00m, 2, 4, "1°C to 5°C", 5, "220-240V", 24, 72m },
                    { 17, 150, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Undercounter drawer freezer for easy access in commercial kitchens.", "85×60×70", "A+", true, false, true, "/images/fridges/avantco-drawer-freezer.jpg", true, true, false, "Avantco", 1, "AVA-DF150", "Drawer Freezer 150L", null, null, 479.00m, 260m, 5599.00m, 2, 4, "-18°C to -22°C", 6, "220-240V", 24, 65m },
                    { 18, 180, "Black", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Compact beverage center with glass door and adjustable shelving.", "85×55×60", "A", true, true, true, "/images/fridges/summit-beverage-center.jpg", true, true, false, "Summit", 2, "SUM-BC180", "Beverage Center 180L", null, null, 429.00m, 220m, 4999.00m, 3, 6, "3°C to 8°C", 4, "220-240V", 24, 58m },
                    { 19, 100, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Specialized kegerator for draft beer systems in bars and restaurants.", "90×55×60", "A", true, true, true, "/images/fridges/edgestar-kegerator.jpg", true, true, false, "EdgeStar", 1, "EDG-K100", "Kegerator 100L", null, null, 599.00m, 180m, 6999.00m, 2, 3, "2°C to 6°C", 4, "220-240V", 24, 52m },
                    { 20, 140, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Portable dual-zone fridge-freezer combination for flexible commercial use.", "95×55×65", "A", true, false, false, "/images/fridges/whynter-dual-zone.jpg", true, true, false, "Whynter", 2, "WHY-DZ140", "Dual Zone 140L", null, null, 399.00m, 200m, 4699.00m, 3, 6, "-18°C to 10°C", 8, "220-240V", 24, 48m },
                    { 21, 350, "Stainless Steel", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Professional-grade upright fridge with advanced temperature management.", "190×75×75", "A+", true, false, true, "/images/fridges/frigidaire-professional-350l.jpg", true, true, false, "Frigidaire", 1, "FRI-P350", "Professional 350L", null, null, 799.00m, 380m, 9299.00m, 2, 4, "0°C to 7°C", 0, "220-240V", 36, 110m },
                    { 22, 200, "White", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Reliable commercial fridge with robust construction and energy efficiency.", "92×65×68", "A", true, false, true, "/images/fridges/kelvinator-commercial-200l.jpg", true, true, false, "Kelvinator", 3, "KEL-C200", "Commercial 200L", null, null, 379.00m, 240m, 4399.00m, 4, 6, "2°C to 8°C", 0, "220-240V", 24, 62m },
                    { 23, 130, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Economical and eco-friendly fridge with low power consumption.", "86×56×62", "A++", false, false, true, "/images/fridges/midea-ecocool-130l.jpg", true, true, false, "Midea", 4, "MID-EC130", "EcoCool 130L", null, null, 229.00m, 150m, 2699.00m, 6, 6, "3°C to 8°C", 0, "220-240V", 24, 46m },
                    { 24, 250, "Silver", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Advanced inverter technology fridge with precise temperature control and quiet operation.", "170×60×65", "A++", true, false, true, "/images/fridges/panasonic-inverter-250l.jpg", true, true, false, "Panasonic", 2, "PAN-I250", "Inverter 250L", null, null, 549.00m, 200m, 6399.00m, 3, 6, "0°C to 8°C", 0, "220-240V", 36, 68m },
                    { 25, 180, "Cream", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Stylish retro-design fridge perfect for boutique hotels and premium bars.", "125×60×65", "A+", false, false, true, "/images/fridges/smeg-retro-180l.jpg", true, true, false, "Smeg", 1, "SME-R180", "Retro 180L", null, null, 699.00m, 220m, 7999.00m, 2, 6, "2°C to 8°C", 0, "220-240V", 24, 58m }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "CreatedAt", "CreatedBy", "IsActive", "ModifiedAt", "ModifiedBy", "PostalCode", "Province", "Suburb" },
                values: new object[,]
                {
                    { 1, "12 Voortrekker Road", null, "Paarl", "South Africa", new DateTime(2024, 1, 15, 8, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "7646", "Western Cape", "Paarl" },
                    { 2, "45 Mitchell Street", null, "East London", "South Africa", new DateTime(2024, 1, 16, 9, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "5241", "Eastern Cape", "Berea" },
                    { 3, "88 Goble Road", "Unit 5", "Johannesburg", "South Africa", new DateTime(2024, 1, 17, 10, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "2198", "Gauteng", "Yeoville" },
                    { 4, "15 Jan Shoba Street", null, "Pretoria", "South Africa", new DateTime(2024, 1, 18, 11, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "0028", "Gauteng", "Hatfield" },
                    { 5, "247 Florida Road", null, "Durban", "South Africa", new DateTime(2024, 1, 19, 12, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "4001", "KwaZulu-Natal", "Morningside" },
                    { 6, "88 Kerk Street", null, "Potchefstroom", "South Africa", new DateTime(2024, 1, 20, 13, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "2531", "North West", "Potchefstroom" },
                    { 7, "22 Beatrix Street", null, "Bloemfontein", "South Africa", new DateTime(2024, 1, 21, 14, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "9301", "Free State", "Arcadia" },
                    { 8, "45 Colinton Road", null, "Cape Town", "South Africa", new DateTime(2024, 1, 22, 15, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "7700", "Western Cape", "Newlands" },
                    { 9, "1 Kerk Street", null, "Dullstroom", "South Africa", new DateTime(2024, 1, 23, 16, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "1110", "Mpumalanga", "Dullstroom" },
                    { 10, "12 Schröder Street", null, "Kimberley", "South Africa", new DateTime(2024, 1, 24, 17, 0, 0, 0, DateTimeKind.Utc), "System", true, null, null, "8301", "Northern Cape", "Kimberley" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountStatus", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "CustomerId", "DOB", "Email", "EmailConfirmed", "EmployeeId", "FailedLoginAttempts", "FirstName", "IsActive", "IsEmailVerified", "IsPhoneVerified", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LocationId", "LockoutEnabled", "LockoutEnd", "LockoutEndDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 1, "1b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "admin@smartchill.com", true, 1, 0, "Collins", true, true, true, null, "Khosa", null, 6, true, null, null, "ADMIN@SMARTCHILL.COM", "ADMIN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEC49uuNxXXoCcTXxkO9GmRv9Jz+E6cbTQoVBPoFcr9+L977JCzJDPRmOCW9SSW9jyw==", "+27645347790", true, null, "1b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "admin@smartchill.com" },
                    { "2", 0, 1, "2b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "customersupport@smartchill.com", true, 2, 0, "Andries", true, true, true, null, "Tatane", null, 10, true, null, null, "CUSTOMERSUPPORT@SMARTCHILL.COM", "CUSTOMERSUPPORT@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEE3rLZWl1k1LKukpPaX8Z5s3h13n0PUijXvaKvB+Sq7f6d0liN5td44hMBNHZ25prA==", "+27710737734", true, null, "2b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "customersupport@smartchill.com" },
                    { "3", 0, 1, "3b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "stockcontroller@smartchill.com", true, 3, 0, "Mido", true, true, true, null, "Macia", null, 2, true, null, null, "STOCKCONTROLLER@SMARTCHILL.COM", "STOCKCONTROLLER@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEBeWGdj2q05lprgHqV5DSKoJwTfu3m036UbwFznfQ72lkQ+boElmG9oha1DvPa4Fbg==", "+27662934430", true, null, "3b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "stockcontroller@smartchill.com" },
                    { "4", 0, 1, "4b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "faulttechnician@smartchill.com", true, 4, 0, "Nathaniel", true, true, true, null, "Julies", null, 5, true, null, null, "FAULTTECHNICIAN@SMARTCHILL.COM", "FAULTTECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEJvZgYSv/3PP+7+nSjByuXdCtO/usPVGop/QFwhtN963A3/FNg6bjO7iNPC2nq5ZHw==", "+27798946438", true, null, "4b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "faulttechnician@smartchill.com" },
                    { "5", 0, 1, "5b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "maintenancetechnician@smartchill.com", true, 5, 0, "Latiefa", true, true, true, null, "Freeman", null, 5, true, null, null, "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEJi0G3lY69bFoqrnXds1xFBCid4BOJuNtuvoLSBtGZbJdHVGwrHiIbf89nrCdDgHaw==", "+27614836998", true, null, "5b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "maintenancetechnician@smartchill.com" },
                    { "6", 0, 1, "6b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", 1, null, "naterobertson@gmail.com", true, null, 0, "Nathan", true, true, true, null, "Robertson", null, 1, true, null, null, "NATEROBERTSON@GMAIL.COM", "NATEROBERTSON@GMAIL.COM", "AQAAAAIAAYagAAAAEFq/PoeA3ZcTwiVBo/XHzZlpVWhTaz11oX8IZRU9evqC6BaAswH68CrUCCpnr7/a9w==", "+27691745946", true, null, "6b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a", false, null, null, "naterobertson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin_role_id", "1" },
                    { "customer_support_role_id", "2" },
                    { "stock_controller_role_id", "3" },
                    { "fault_technician_role_id", "4" },
                    { "maintenance_technician_role_id", "5" },
                    { "customer_role_id", "6" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AvailabilityStatus", "CreatedAt", "CreatedBy", "EmployeeNumber", "EmployeeType", "EmploymentType", "IsActive", "UpdatedAt", "UpdatedBy", "UserId", "WorkEmail", "WorkLocationId", "WorkPhone" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "EMP00001", "Administrator", 0, true, null, "", "1", "admin@smartchill.com", 6, "+27645347790" },
                    { 2, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "EMP00002", "CustomerSupport", 0, true, null, "", "2", "customersupport@smartchill.com", 10, "+27710737734" },
                    { 3, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "EMP00003", "StockController", 0, true, null, "", "3", "stockcontroller@smartchill.com", 2, "+27662934430" },
                    { 4, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "EMP00004", "FaultTechnician", 0, true, null, "", "4", "faulttechnician@smartchill.com", 5, "+27798946438" },
                    { 5, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "EMP00005", "MaintenanceTechnician", 0, true, null, "", "5", "maintenancetechnician@smartchill.com", 5, "+27614836998" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AlternativePhone", "AssignedEmployeeId", "BusinessEmail", "BusinessPhoneNumber", "BusinessType", "City", "CreatedAt", "CreatedBy", "CreditLimit", "CreditStatus", "CurrentBalance", "CustomerSince", "DiscountRate", "IsActive", "LocationId", "OperatingHours", "PaymentTermsDays", "PostalCode", "Province", "RegistrationNumber", "Suburb", "TradingName", "UpdatedAt", "UpdatedBy", "UserId", "VATNumber" },
                values: new object[] { 1, "12 Voortrekker Road", null, "+27836549871", 2, "orders@boereworspalace.co.za", "+27218765432", 1, "Paarl", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", 50000.00m, 0, 1250.50m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.00m, true, 1, "Mon-Fri: 7:00-18:00, Sat: 7:00-14:00, Sun: Closed", 30, "7646", "Western Cape", "2024/123456/07", "Paarl", "Boerewors Palace", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "6", "4871253690" });

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
                name: "IX_Customers_AssignedEmployeeId",
                table: "Customers",
                column: "AssignedEmployeeId");

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
                name: "IX_MaintenanceVisits_TechnicianId",
                table: "MaintenanceVisits",
                column: "TechnicianId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_ReplacementFridgeId",
                table: "ReplacementRequests",
                column: "ReplacementFridgeId");
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
