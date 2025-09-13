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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suburbs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Suburbs_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "Suburbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
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
                    EmployeeNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerLiaisonId = table.Column<int>(type: "int", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessRegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VATNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BusinessAddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_CustomerLiaisonId",
                        column: x => x.CustomerLiaisonId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Locations_BusinessAddressId",
                        column: x => x.BusinessAddressId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockControllerId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    EnergyRating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_Employees_StockControllerId",
                        column: x => x.StockControllerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecipientFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Locations_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FridgeAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerLiaisonId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceIntervalMonths = table.Column<int>(type: "int", nullable: false),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextServiceDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StockControllerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_CustomerLiaisonId",
                        column: x => x.CustomerLiaisonId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Employees_StockControllerId",
                        column: x => x.StockControllerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    StockControllerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessingNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Employees_StockControllerId",
                        column: x => x.StockControllerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaultRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false),
                    FaultTechnicianId = table.Column<int>(type: "int", nullable: true),
                    ReportedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FridgeId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceTechnicianId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_FaultRecords_Employees_MaintenanceTechnicianId",
                        column: x => x.MaintenanceTechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultRecords_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultRecords_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceTechnicianId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FridgeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Employees_MaintenanceTechnicianId",
                        column: x => x.MaintenanceTechnicianId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FridgeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeAllocationId = table.Column<int>(type: "int", nullable: false),
                    FaultRecordId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceRecordId = table.Column<int>(type: "int", nullable: true),
                    AssignedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_FridgeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeRequests_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeRequests_FaultRecords_FaultRecordId",
                        column: x => x.FaultRecordId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FridgeRequests_FridgeAllocations_FridgeAllocationId",
                        column: x => x.FridgeAllocationId,
                        principalTable: "FridgeAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeRequests_MaintenanceRecords_MaintenanceRecordId",
                        column: x => x.MaintenanceRecordId,
                        principalTable: "MaintenanceRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { "3", null, "StockController", "STOCKCONTROLLER" },
                    { "4", null, "FaultTechnician", "FAULTTECHNICIAN" },
                    { "5", null, "MaintenanceTechnician", "MAINTENANCETECHNICIAN" },
                    { "6", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "5b9a8eaa-260c-4570-aa0d-1cc62fee0824", "admin@smartchill.com", true, "Collins", "Khosa", null, false, null, "ADMIN@SMARTCHILL.COM", "ADMIN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEBLOy9upQrFWzEeDlPvdVPZ8aESx723F1EFEqv+MQZkVPhvknyomWEL2ZrRq4krZ2Q==", "+27 64 534 7790", true, "234a79d3-a76d-4726-bf1d-fd10fae5c297", false, "admin@smartchill.com" },
                    { "2", 0, "ee2610ca-3e55-4527-83f9-4ab6490e3883", "customersupport@smartchill.com", true, "Andries", "Tatane", null, false, null, "CUSTOMERSUPPORT@SMARTCHILL.COM", "CUSTOMERSUPPORT@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEMibnj7N4KJ1FnucC7a4Ctnf5kRRXrdedF4EZ2y6H9DDu8bOwB5F5DU9LiQDSd3Cyg==", "+27 71 073 7734", true, "7df17a8c-b5e5-4819-aeb0-f93770a8132a", false, "customersupport@smartchill.com" },
                    { "3", 0, "0d100879-c12e-4d23-b031-536c0d6a90aa", "stockcontroller@smartchill.com", true, "Mido", "Macia", null, false, null, "STOCKCONTROLLER@SMARTCHILL.COM", "STOCKCONTROLLER@SMARTCHILL.COM", "AQAAAAIAAYagAAAAED8rHo2FRbhrAsxHeZUI+GFqY3JvYZPBv3FTPHcFYC7XHhKivywzeZpQgs4k3CDcTA==", "+27 66 293 4430", true, "e3ba5e53-ef8e-45d2-bfcc-3e29aa8285bd", false, "stockcontroller@smartchill.com" },
                    { "4", 0, "ebf60d88-9daf-4d81-ae89-12583c56576f", "faulttechnician@smartchill.com", true, "Nathaniel", "Julies", null, false, null, "FAULTTECHNICIAN@SMARTCHILL.COM", "FAULTTECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEPgSlsu8j2l0nYVs79UHDchLmNTAq5C2M1gdydcFqayMD15uiStoITh8J/3a5ZUY4Q==", "+27 79 894 6438", true, "827774bf-ce3e-455a-a312-a486ac213d3e", false, "faulttechnician@smartchill.com" },
                    { "5", 0, "4cc66766-6e56-472f-9429-f6ec94b4e5c6", "maintenancetechnician@smartchill.com", true, "Latiefa", "Freeman", null, false, null, "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "MAINTENANCETECHNICIAN@SMARTCHILL.COM", "AQAAAAIAAYagAAAAEN6DJ20UOqNgchr8zj/Y9qtg/VBliT/65ZiubP1fU43NhWsMS9HMH9AurHEvpjDxhQ==", "+27 61 483 6998", true, "bdf181af-d237-46a9-8787-900705d9fb8b", false, "maintenancetechnician@smartchill.com" },
                    { "6", 0, "950c3c8b-b87d-43f5-ac08-2f9a21c91740", "naterobertson@gmail.com", true, "Nathan", "Robertson", null, false, null, "NATEROBERTSON@GMAIL.COM", "NATEROBERTSON@GMAIL.COM", "AQAAAAIAAYagAAAAEKKZdNsVpArM4Ud2aGSwbMhmWynEAhCWBn3Wxdi1gUC6blDvM9Zu9W1XqeO+knodKw==", "+27 69 174 5946", true, "ead2ff4c-2746-41f3-9569-273fdb1fcfeb", false, "naterobertson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IsDeleted", "Name" },
                values: new object[] { 1, "ZA", false, "South Africa" });

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
                columns: new[] { "Id", "AvailabilityStatus", "CreatedAt", "Discriminator", "EmployeeNumber", "IsActive", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2405), "CustomerSupport", "CS001", true, null, "2" },
                    { 2, "On-site", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2491), "StockController", "SC001", true, null, "3" },
                    { 3, "Available", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2577), "FaultTechnician", "FT001", true, null, "4" },
                    { 4, "Available", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2635), "MaintenanceTechnician", "MT001", true, null, "5" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Code", "CountryId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "GP", 1, false, "Gauteng" },
                    { 2, "WC", 1, false, "Western Cape" },
                    { 3, "KZN", 1, false, "KwaZulu-Natal" },
                    { 4, "EC", 1, false, "Eastern Cape" },
                    { 5, "FS", 1, false, "Free State" },
                    { 6, "LP", 1, false, "Limpopo" },
                    { 7, "MP", 1, false, "Mpumalanga" },
                    { 8, "NW", 1, false, "North West" },
                    { 9, "NC", 1, false, "Northern Cape" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, false, "Johannesburg", 1 },
                    { 2, false, "Cape Town", 2 },
                    { 3, false, "Durban", 3 },
                    { 4, false, "Gqeberha", 4 },
                    { 5, false, "Soweto", 1 },
                    { 6, false, "Bloemfontein", 5 },
                    { 7, false, "Polokwane", 6 },
                    { 8, false, "Mbombela", 7 },
                    { 9, false, "Mahikeng", 8 },
                    { 10, false, "Kimberley", 9 }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CapacityLiters", "Condition", "CreatedAt", "EnergyRating", "ImageUrl", "Manufacturer", "Model", "PurchaseDate", "SerialNumber", "Status", "StockControllerId", "UpdatedAt", "WarrantyExpiryDate" },
                values: new object[,]
                {
                    { 1, 520, "Used - Good", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2806), "B", "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Defy", "DCR520 Commercial Beverage Cooler", new DateTime(2024, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2789), "FRG-2023-001", "In Stock", 2, null, new DateTime(2026, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2801) },
                    { 2, 780, "New", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2815), "A", "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Z2xhc3MlMjBkb29yJTIwZnJpZGdlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", "LG", "LC-321CV Glass Door Merchandiser", new DateTime(2025, 6, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2811), "FRG-2023-002", "In Stock", 2, null, new DateTime(2028, 6, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2813) },
                    { 3, 702, "Used - Excellent", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2821), "A+", "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Hisense", "HC-702D Commercial Display Freezer", new DateTime(2025, 7, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2819), "FRG-2023-003", "Allocated", 2, null, new DateTime(2028, 7, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2820) },
                    { 4, 500, "Needs Repair", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2827), "A+", "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Y29tbWVyY2lhbCUyMGZyZW96ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Samsung", "RR-500M Commercial Series Freezer", new DateTime(2023, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2825), "FRG-2023-004", "Needs Repair", 2, null, new DateTime(2025, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2826) },
                    { 5, 680, "Used - Fair", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2833), "B", "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmV2ZXJhZ2UlMjBjb29sZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Kelvinator", "KCR-680GL Glass Door Beverage Cooler", new DateTime(2022, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2831), "FRG-2023-005", "In Service", 2, null, new DateTime(2024, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2832) },
                    { 6, 600, "Refurbished", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2839), "A", "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8cmV0cm8lMjBmcmlkZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Smeg", "FAB60RCR Retro Commercial Fridge", new DateTime(2025, 5, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2836), "FRG-2023-006", "Allocated", 2, null, new DateTime(2028, 5, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2838) },
                    { 7, 280, "New", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2845), "A++", "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dW5kZXJjb3VudGVyJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", "Bosch", "GIC08A15 Commercial UnderCounter Freezer", new DateTime(2025, 2, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2842), "FRG-2023-007", "In Stock", 2, null, new DateTime(2028, 2, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2844) },
                    { 8, 429, "Used - Excellent", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2851), "A", "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8aWNlJTIwbWFrZXIlMjBmcmlkZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Whirlpool", "WIO429IY Commercial Ice Maker & Beverage Cooler", new DateTime(2024, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2849), "FRG-2023-008", "In Service", 2, null, new DateTime(2027, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2850) },
                    { 9, 836, "Used - Good", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2856), "A+", "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8bXVsdGklMjBkb29yJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", "AEG", "RCB836E4MW Commercial Multi-Door Freezer", new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2854), "FRG-2023-009", "In Stock", 2, null, new DateTime(2028, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2855) },
                    { 10, 920, "New", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2862), "A++", "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8ZnJvc3RmcmVlJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", "Siemens", "KI92RA70 Commercial FrostFree Freezer", new DateTime(2025, 4, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2860), "FRG-2023-010", "In Stock", 2, null, new DateTime(2028, 4, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2861) },
                    { 11, 492, "Faulty", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2868), "C", "https://images.unsplash.com/photo-1571175443880-49e1d1b5b60e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8ZmF1bHR5JTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", "Defy", "DTD492 Commercial Top Mount Freezer", new DateTime(2019, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2865), "FRG-2023-011", "Decommissioned", 2, null, new DateTime(2021, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2866) },
                    { 12, 552, "Used - Good", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2874), "A+", "https://images.unsplash.com/photo-1595428773927-7c241f6f783f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZHJhd2VyJTIwZnJlZXplcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", "LG", "GL-D552CRL Commercial Drawer Freezer", new DateTime(2024, 12, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2871), "FRG-2023-012", "Needs Repair", 2, null, new DateTime(2027, 12, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2873) },
                    { 13, 790, "Used - Excellent", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2879), "A", "https://images.unsplash.com/photo-1595428774223-ef52624120d2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cmVhY2glMjBpbiUyMGZyZWV6ZXJ8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", "Hisense", "HR-790D4 Commercial Reach-In Freezer", new DateTime(2025, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2877), "FRG-2023-013", "In Stock", 2, null, new DateTime(2028, 3, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2878) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRequests",
                columns: new[] { "Id", "CreatedAt", "FridgeId", "IsDeleted", "ProcessedDate", "ProcessingNotes", "Quantity", "Reason", "RequestDate", "Status", "StockControllerId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3480), 5, false, null, null, 24, "Increase stock levels for upcoming summer beverage promotions in Gauteng region.", new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3478), "Pending", 2, null });

            migrationBuilder.InsertData(
                table: "Suburbs",
                columns: new[] { "Id", "CityId", "IsDeleted", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, 1, false, "Sandton", "2196" },
                    { 2, 1, false, "Parkhurst", "2193" },
                    { 3, 2, false, "Sea Point", "8060" },
                    { 4, 2, false, "Claremont", "7735" },
                    { 5, 3, false, "Berea", "4001" },
                    { 6, 4, false, "Summerstrand", "6001" },
                    { 7, 5, false, "Orlando East", "1804" },
                    { 8, 3, false, "Umhlanga", "4319" },
                    { 9, 6, false, "Fichardt Park", "9301" },
                    { 10, 7, false, "Flora Park", "0699" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CreatedAt", "IsDeleted", "SuburbId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Vilakazi Street", "Orlando West", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1972), false, 7, null },
                    { 2, "45 Victoria Road", "Victoria and Alfred Waterfront", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1974), false, 3, null },
                    { 3, "78 Steve Biko Road", "Berea Centre", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1977), false, 5, null },
                    { 4, "12 Main Road", "Sandton City", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1979), false, 1, null },
                    { 5, "8 4th Avenue", "Parkhurst Village", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1980), false, 2, null },
                    { 6, "101 Beach Road", "Beachfront Plaza", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1982), false, 4, null },
                    { 7, "22 Marine Drive", "Umhlanga Rocks", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1984), false, 8, null },
                    { 8, "5 University Way", "Campus Square", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1986), false, 6, null },
                    { 9, "14 Paul Kruger Avenue", "Fichardt Park Mall", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1988), false, 9, null },
                    { 10, "77 Marshall Street", "Flora Park Centre", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(1990), false, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BusinessAddressId", "BusinessEmail", "BusinessName", "BusinessPhoneNumber", "BusinessRegistrationNumber", "BusinessType", "CreatedAt", "CustomerLiaisonId", "IsActive", "UpdatedAt", "UserId", "VATNumber" },
                values: new object[] { 1, 1, "info@boereworspalace.co.za", "Boerewors Palace", "+27 11 555 0101", "REG-1977-001", "Shebeen", new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(2729), 1, true, null, "6", "VAT-650603" });

            migrationBuilder.InsertData(
                table: "FridgeAllocations",
                columns: new[] { "Id", "ActualReturnDate", "AllocationDate", "CreatedAt", "CustomerId", "CustomerLiaisonId", "ExpectedReturnDate", "FridgeId", "IsDeleted", "LastServiceDate", "NextServiceDue", "Notes", "ServiceIntervalMonths", "Status", "StockControllerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3027), new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3042), 1, 1, new DateTime(2026, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3028), 3, false, new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3030), new DateTime(2025, 11, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3031), "High-usage establishment, requires more frequent servicing", 3, "Active", null, new DateTime(2025, 8, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3043) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3047), 1, 1, null, 10, false, null, null, "New customer application under review", 6, "Pending", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "Id", "Carrier", "CustomerId", "DeliveryAddressId", "OrderDate", "OrderStatus", "OrderTotal", "PaymentDate", "PaymentDueDate", "PaymentIntentId", "PaymentStatus", "RecipientFirstName", "RecipientLastName", "SessionId", "ShippingDate", "TrackingNumber" },
                values: new object[] { 1, "Fastway Couriers", 1, 1, new DateTime(2025, 9, 5, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3247), "Completed", 16999.99m, new DateTime(2025, 9, 6, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3258), new DateTime(2025, 9, 11, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3259), null, "Paid", "Nathan", "Robertson", null, new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3255), "TRK123456789" });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CustomerId", "FridgeId", "Price", "Quantity" },
                values: new object[] { 1, 1, 1, 15399.99m, 4 });

            migrationBuilder.InsertData(
                table: "FaultRecords",
                columns: new[] { "Id", "AssignedDate", "CreatedAt", "CustomerId", "Description", "Diagnosis", "FaultTechnicianId", "FridgeAllocationId", "FridgeId", "IsDeleted", "MaintenanceTechnicianId", "Priority", "ReportedById", "ReportedDate", "ResolutionNotes", "ResolvedDate", "Status", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 9, 10, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3361), new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3362), null, "Fridge not cooling properly - temperature reading shows 15°C when set to 4°C", "Preliminary diagnosis suggests possible compressor issue or refrigerant leak", 3, 1, null, false, null, "High", "6", new DateTime(2025, 9, 9, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3360), "Technician dispatched for on-site inspection. Parts may need ordering.", null, "InProgress", new DateTime(2025, 9, 11, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3363) });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "CompletedDate", "CreatedAt", "CustomerConfirmationDate", "CustomerId", "Description", "FridgeAllocationId", "FridgeId", "IsDeleted", "MaintenanceTechnicianId", "ScheduledDate", "ServiceNotes", "Status", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3427), new DateTime(2025, 9, 2, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3429), new DateTime(2025, 9, 6, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3425), null, "Routine preventive maintenance service", 1, null, false, 4, new DateTime(2025, 9, 5, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3423), "Performed comprehensive maintenance: cleaned condenser coils, checked refrigerant levels, calibrated thermostat, inspected door seals, and lubricated moving parts. Fridge is operating at optimal efficiency.", "Completed", new DateTime(2025, 9, 7, 23, 35, 41, 301, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "FridgeId", "OrderHeaderId", "Price", "Quantity" },
                values: new object[] { 1, 1, 1, 15399.99m, 4 });

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
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessAddressId",
                table: "Customers",
                column: "BusinessAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerLiaisonId",
                table: "Customers",
                column: "CustomerLiaisonId");

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
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords",
                column: "CustomerId");

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
                name: "IX_FaultRecords_MaintenanceTechnicianId",
                table: "FaultRecords",
                column: "MaintenanceTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_ReportedById",
                table: "FaultRecords",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_CustomerId",
                table: "FridgeAllocations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_CustomerLiaisonId",
                table: "FridgeAllocations",
                column: "CustomerLiaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_FridgeId",
                table: "FridgeAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_StockControllerId",
                table: "FridgeAllocations",
                column: "StockControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeRequests_AssignedEmployeeId",
                table: "FridgeRequests",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeRequests_CustomerId",
                table: "FridgeRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeRequests_FaultRecordId",
                table: "FridgeRequests",
                column: "FaultRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeRequests_FridgeAllocationId",
                table: "FridgeRequests",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeRequests_MaintenanceRecordId",
                table: "FridgeRequests",
                column: "MaintenanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_StockControllerId",
                table: "Fridges",
                column: "StockControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SuburbId",
                table: "Locations",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_CustomerId",
                table: "MaintenanceRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_FridgeAllocationId",
                table: "MaintenanceRecords",
                column: "FridgeAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_FridgeId",
                table: "MaintenanceRecords",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MaintenanceTechnicianId",
                table: "MaintenanceRecords",
                column: "MaintenanceTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FridgeId",
                table: "OrderDetails",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CustomerId",
                table: "OrderHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_DeliveryAddressId",
                table: "OrderHeaders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_FridgeId",
                table: "PurchaseRequests",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_StockControllerId",
                table: "PurchaseRequests",
                column: "StockControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FridgeId",
                table: "ShoppingCarts",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityId",
                table: "Suburbs",
                column: "CityId");
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
                name: "FridgeRequests");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FaultRecords");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "FridgeAllocations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Suburbs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
