using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class addedLocationTable : Migration
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
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessDocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclinedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "FridgeModel",
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
                    table.PrimaryKey("PK_FridgeModel", x => x.Id);
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
                name: "tblLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_tblLocations", x => x.Id);
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
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_tblEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblLocations_WorkLocationId",
                        column: x => x.WorkLocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblSuppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_tblSuppliers_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCustomerS_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCustomerS_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseRequests",
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPurchaseRequests_tblEmployees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblPurchaseRequests_tblEmployees_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "tblEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPurchaseRequests_tblSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "tblSuppliers",
                        principalColumn: "SupplierId");
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    FridgeModelId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridges", x => x.FridgeId);
                    table.ForeignKey(
                        name: "FK_tblFridges_FridgeModel_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFridges_tblCustomerS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFridges_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFridges_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseRequestItems",
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
                    table.PrimaryKey("PK_tblPurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPurchaseRequestItems_FridgeModel_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPurchaseRequestItems_tblPurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "tblPurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllocations", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_tblAllocations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblEmployees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeRequests_tblFridges_FaultyFridgeId",
                        column: x => x.FaultyFridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
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
                    FridgeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaintenanceVisits", x => x.MaintenanceVisitId);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblCustomerS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomerS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_tblMaintenanceVisits_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
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
                    Price = table.Column<double>(type: "float", nullable: false),
                    FridgeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestDetais", x => x.RequestDetailId);
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_FridgeModel_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                    ResolvedByTechnicianId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_tblFaults_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFaults_tblLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFaults_tblMaintenanceVisits_MaintenanceVisitId",
                        column: x => x.MaintenanceVisitId,
                        principalTable: "tblMaintenanceVisits",
                        principalColumn: "MaintenanceVisitId",
                        onDelete: ReferentialAction.Restrict);
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
                    MaintenanceVisitId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaintenanceRecords", x => x.MaintenanceRecordId);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblFaultTechnicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "tblFaultTechnicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMaintenanceRecords_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "Brand", "CapacityLiters", "Condition", "CustomerId", "Description", "EmployeeId", "FridgeModelId", "FridgeNo", "ImageUrl", "LastMaintenanceDate", "Location", "LocationId", "Model", "RentalPricePerMonth", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Samsung", 253, "Excellent", null, "Energy-efficient double door fridge with frost-free technology.", null, null, "FRG-001", "https://example.com/images/fridge1.jpg", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "RT28T", 1200.0, "Available", "Double Door" },
                    { 2, "LG", 190, "Good", null, "Compact single door fridge ideal for small apartments.", null, null, "FRG-002", "https://example.com/images/fridge2.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "GL-B201", 900.0, "Rented", "Single Door" },
                    { 3, "Whirlpool", 500, "Excellent", null, "Spacious fridge with advanced cooling technology.", null, null, "FRG-003", "https://example.com/images/fridge3.jpg", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "WRT518", 1500.0, "Available", "Double Door" },
                    { 4, "Defy", 350, "Good", null, "Durable fridge with energy-saving features.", null, null, "FRG-004", "https://example.com/images/fridge4.jpg", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "DAC700", 1100.0, "Available", "Double Door" },
                    { 5, "Hisense", 310, "Good", null, "Compact fridge with adjustable shelves.", null, null, "FRG-005", "https://example.com/images/fridge5.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "H310BI", 800.0, "Rented", "Single Door" },
                    { 6, "Bosch", 420, "Excellent", null, "Premium fridge with no-frost technology.", null, null, "FRG-006", "https://example.com/images/fridge6.jpg", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "KDN42", 1600.0, "Available", "Double Door" },
                    { 7, "Kelvinator", 250, "Fair", null, "Affordable fridge with basic features.", null, null, "FRG-007", "https://example.com/images/fridge7.jpg", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "KEL250", 700.0, "Available", "Single Door" },
                    { 8, "Smeg", 281, "Excellent", null, "Retro-style fridge with modern cooling.", null, null, "FRG-008", "https://example.com/images/fridge8.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "FAB28", 2000.0, "Available", "Single Door" },
                    { 9, "AEG", 300, "Excellent", null, "Built-in fridge with adjustable compartments.", null, null, "FRG-009", "https://example.com/images/fridge9.jpg", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "SKE818", 1800.0, "Rented", "Single Door" },
                    { 10, "Panasonic", 347, "Good", null, "Fridge with inverter technology for energy saving.", null, null, "FRG-010", "https://example.com/images/fridge10.jpg", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "NR-BL347", 1300.0, "Available", "Double Door" },
                    { 11, "Haier", 565, "Excellent", null, "Large capacity fridge with twin inverter technology.", null, null, "FRG-011", "https://example.com/images/fridge11.jpg", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "HRF-619", 2200.0, "Available", "Side by Side" },
                    { 12, "Hitachi", 640, "Excellent", null, "Premium French door fridge with eco-friendly features.", null, null, "FRG-012", "https://example.com/images/fridge12.jpg", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "R-WB640", 2500.0, "Available", "French Door" },
                    { 13, "Electrolux", 370, "Good", null, "Fridge with taste guard deodorizer.", null, null, "FRG-013", "https://example.com/images/fridge13.jpg", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "ETB3700", 1400.0, "Rented", "Top Freezer" },
                    { 14, "Sharp", 600, "Excellent", null, "Fridge with plasmacluster ion technology.", null, null, "FRG-014", "https://example.com/images/fridge14.jpg", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "SJ-GX60", 2300.0, "Available", "French Door" },
                    { 15, "Midea", 400, "Good", null, "Affordable fridge with large freezer compartment.", null, null, "FRG-015", "https://example.com/images/fridge15.jpg", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "HD-400", 1000.0, "Available", "Double Door" },
                    { 16, "Gorenje", 326, "Good", null, "Stylish bottom freezer fridge with crisp zone for vegetables.", null, null, "FRG-016", "https://example.com/images/fridge16.jpg", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "NRK6192", 1250.0, "Available", "Bottom Freezer" },
                    { 17, "Westinghouse", 528, "Excellent", null, "Family-sized fridge with humidity-controlled crisper.", null, null, "FRG-017", "https://example.com/images/fridge17.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "WBE5300", 1700.0, "Available", "Top Freezer" },
                    { 18, "Fisher & Paykel", 519, "Excellent", null, "Premium French door fridge with active smart technology.", null, null, "FRG-018", "https://example.com/images/fridge18.jpg", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "RF522", 2400.0, "Rented", "French Door" },
                    { 19, "Ariston", 383, "Good", null, "Reliable fridge with antibacterial coating.", null, null, "FRG-019", "https://example.com/images/fridge19.jpg", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "MBA3832", 1150.0, "Available", "Top Freezer" },
                    { 20, "Beko", 560, "Excellent", null, "Spacious bottom freezer fridge with NeoFrost cooling.", null, null, "FRG-020", "https://example.com/images/fridge20.jpg", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", null, "RCNE560", 1850.0, "Available", "Bottom Freezer" }
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
                name: "IX_tblAllocations_EmployeeId",
                table: "tblAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_EmployeeId1",
                table: "tblAllocations",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_FridgeId",
                table: "tblAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_LocationId",
                table: "tblAllocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerS_EmployeeId",
                table: "tblCustomerS",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerS_LocationId",
                table: "tblCustomerS",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_UserId",
                table: "tblEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_WorkLocationId",
                table: "tblEmployees",
                column: "WorkLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_EmployeeId",
                table: "tblFaults",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_FridgeId",
                table: "tblFaults",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaults_LocationId",
                table: "tblFaults",
                column: "LocationId");

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
                name: "IX_tblFridges_EmployeeId",
                table: "tblFridges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridges_FridgeModelId",
                table: "tblFridges",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridges_LocationId",
                table: "tblFridges",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_AllocationId",
                table: "tblFridgeVisits",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_RequestHeaderId",
                table: "tblFridgeVisits",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceRecords_EmployeeId",
                table: "tblMaintenanceRecords",
                column: "EmployeeId");

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
                name: "IX_tblMaintenanceVisits_EmployeeId",
                table: "tblMaintenanceVisits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_FridgeId",
                table: "tblMaintenanceVisits",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_LocationId",
                table: "tblMaintenanceVisits",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaintenanceVisits_TechnicianId",
                table: "tblMaintenanceVisits",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProcessFaults_FaultId",
                table: "tblProcessFaults",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseRequestItems_FridgeModelId",
                table: "tblPurchaseRequestItems",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseRequestItems_PurchaseRequestId",
                table: "tblPurchaseRequestItems",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseRequests_ApprovedById",
                table: "tblPurchaseRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseRequests_RequestedById",
                table: "tblPurchaseRequests",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseRequests_SupplierId",
                table: "tblPurchaseRequests",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeModelId",
                table: "tblRequestDetais",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_ApplicationUserId",
                table: "tblRequestHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSuppliers_LocationId",
                table: "tblSuppliers",
                column: "LocationId");
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
                name: "tblPurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "tblRequestDetais");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblAllocations");

            migrationBuilder.DropTable(
                name: "tblFaults");

            migrationBuilder.DropTable(
                name: "tblPurchaseRequests");

            migrationBuilder.DropTable(
                name: "tblRequestHeaders");

            migrationBuilder.DropTable(
                name: "tblMaintenanceVisits");

            migrationBuilder.DropTable(
                name: "tblSuppliers");

            migrationBuilder.DropTable(
                name: "tblFaultTechnicians");

            migrationBuilder.DropTable(
                name: "tblFridges");

            migrationBuilder.DropTable(
                name: "FridgeModel");

            migrationBuilder.DropTable(
                name: "tblCustomerS");

            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblLocations");
        }
    }
}
