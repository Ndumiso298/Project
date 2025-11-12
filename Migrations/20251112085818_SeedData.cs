using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
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
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "tblBusinessInfo",
                columns: table => new
                {
                    BusinessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBusinessInfo", x => x.BusinessID);
                });

            migrationBuilder.CreateTable(
                name: "tblFridges",
                columns: table => new
                {
                    FridgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityLiters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPricePerMonth = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridges", x => x.FridgeId);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessDocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessDocumentData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_tblCustomer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_tblEmployee_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAllocations",
                columns: table => new
                {
                    AllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllocations", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRequestHeaders",
                columns: table => new
                {
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
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
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalDocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRelaunched = table.Column<bool>(type: "bit", nullable: false),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    OriginalRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestHeaders", x => x.RequestHeaderId);
                    table.ForeignKey(
                        name: "FK_tblRequestHeaders_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestHeaders_tblEmployee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "tblFridgeVisits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerApproval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckupStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    VisitType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeVisits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_tblFridgeVisits_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestDetais_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRequestNotes",
                columns: table => new
                {
                    RequestNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false),
                    NoteType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestNotes", x => x.RequestNoteId);
                    table.ForeignKey(
                        name: "FK_tblRequestNotes_tblRequestHeaders_RequestHeaderId",
                        column: x => x.RequestHeaderId,
                        principalTable: "tblRequestHeaders",
                        principalColumn: "RequestHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblFridgeInStocks",
                columns: table => new
                {
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDetailsRequestDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeInStocks", x => x.FridgeInStockId);
                    table.ForeignKey(
                        name: "FK_tblFridgeInStocks_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeInStocks_tblRequestDetais_RequestDetailsRequestDetailId",
                        column: x => x.RequestDetailsRequestDetailId,
                        principalTable: "tblRequestDetais",
                        principalColumn: "RequestDetailId");
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerFridge",
                columns: table => new
                {
                    CustomerFridgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ReservedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RequestDetailId = table.Column<int>(type: "int", nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForReplacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacementNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacementFridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    ReplacementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerFridge", x => x.CustomerFridgeId);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridgeInStocks_ReplacementFridgeInStockId",
                        column: x => x.ReplacementFridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId");
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                        column: x => x.RequestDetailId,
                        principalTable: "tblRequestDetais",
                        principalColumn: "RequestDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblFaultReports",
                columns: table => new
                {
                    FaultReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    FaultType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestReplacement = table.Column<bool>(type: "bit", nullable: false),
                    IsReplacementRequested = table.Column<bool>(type: "bit", nullable: false),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRelaunched = table.Column<bool>(type: "bit", nullable: false),
                    OriginalFaultReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultReports", x => x.FaultReportId);
                    table.ForeignKey(
                        name: "FK_tblFaultReports_tblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_tblFaultReports_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId");
                });

            migrationBuilder.CreateTable(
                name: "tblFridgeReplacements",
                columns: table => new
                {
                    FridgeReplacementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OldFridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacementStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NewFridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeReplacements", x => x.FridgeReplacementId);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblFridgeInStocks_NewFridgeInStockId",
                        column: x => x.NewFridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_tblFridgeVisits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "tblFridgeVisits",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblFaultTechnicians",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: true),
                    FaultType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TechnicianAssigned = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerBookingStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bookingate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaultReportId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultTechnicians", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_tblFaultTechnicians_tblFaultReports_FaultReportId",
                        column: x => x.FaultReportId,
                        principalTable: "tblFaultReports",
                        principalColumn: "FaultReportId");
                    table.ForeignKey(
                        name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "tblFridgeVisits",
                        principalColumn: "VisitId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Customer", "CUSTOMER" },
                    { "3", null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { "4", null, "StockController", "STOCKCONTROLLER" },
                    { "5", null, "MaintenanceTech", "MAINTENANCETECH" },
                    { "6", null, "FaultTech", "FAULTTECH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CellNumber", "City", "ConcurrencyStamp", "DeclinedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsApproved", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "RejectionReason", "SecurityStamp", "State", "Status", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0111234567", "Johannesburg", "bdeb5fa3-2d73-408c-a2a1-0637bb30828a", null, "ApplicationUser", "admin@gmail.com", true, "John", true, "Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFVEufXJ5BclyhJCMECE+zosuDXz6lhPDVcG+3LIz39kFOlHM/dBuKRGLN82jSveaA==", null, false, "2000", null, "979aaff1-f8c3-45e1-b354-4e1ee8a174df", "Gauteng", "Approved", "123 Admin Street", false, "admin@gmail.com" },
                    { "10", 0, "0148884567", "Rustenburg", "e7fa47b8-5928-4a3a-9804-c78de25bde6b", null, "ApplicationUser", "olivia.martinez@gmail.com", true, "Olivia", true, "Martinez", false, null, "OLIVIA.MARTINEZ@GMAIL.COM", "OLIVIA.MARTINEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEJD5S/R5R5zDD+CCmxXNQeap2prBpajkLLFDyAyJpiqNA5nM9W7dBNo5Psr4dJ/6mg==", null, false, "2999", null, "473f3fb4-0a9e-43d7-a603-5ef3e9236b52", "North West", "Approved", "260 Business Street", false, "olivia.martinez@gmail.com" },
                    { "11", 0, "0315551234", "Durban", "5a985a6b-4e26-4bad-bc99-2f17815243c8", null, "ApplicationUser", "emily.wilson@gmail.com", true, "Emily", true, "Wilson", false, null, "EMILY.WILSON@GMAIL.COM", "EMILY.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEPccBIZHWu6of89DRBnFHwMKT7sR2hTbJzizYW5LJbbtcvJyZuMZ7nDMgWeYlXZnpQ==", null, false, "4001", null, "86044642-0871-4434-9caf-61e799503357", "KwaZulu-Natal", "Approved", "789 Support Road", false, "emily.wilson@gmail.com" },
                    { "12", 0, "0124445678", "Pretoria", "3e0fa8a9-1891-439e-bc64-5d0722c3e82a", null, "ApplicationUser", "michael.brown@gmail.com", true, "Michael", true, "Brown", false, null, "MICHAEL.BROWN@GMAIL.COM", "MICHAEL.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEKejBcbzR/n9EnzjkSa7ZRfKnYRmjeNti9fyRA4swYjJPo/abzACRF/7ExyMLT5qjQ==", null, false, "0002", null, "c61ff405-be36-479a-bcd7-7cc4ebcf770b", "Gauteng", "Approved", "321 Help Street", false, "michael.brown@gmail.com" },
                    { "13", 0, "0113337890", "Johannesburg", "a037e420-fc89-4bae-9f41-9d7b752c8dfe", null, "ApplicationUser", "david.taylor@gmail.com", true, "David", true, "Taylor", false, null, "DAVID.TAYLOR@GMAIL.COM", "DAVID.TAYLOR@GMAIL.COM", "AQAAAAIAAYagAAAAEMefCBvWpGrSHGgk1v1bYtdQQmBtFlJbOSVt4hpxZs/CdEKrbkma3VgUc45XNCxFxg==", null, false, "2001", null, "4e566477-4b95-4c63-8e8f-2cd9f76e49c3", "Gauteng", "Approved", "654 Warehouse Ave", false, "david.taylor@gmail.com" },
                    { "14", 0, "0216667890", "Cape Town", "9ec5f3e4-2104-4e40-a4bf-d777049218d8", null, "ApplicationUser", "sarah.anderson@gmail.com", true, "Sarah", true, "Anderson", false, null, "SARAH.ANDERSON@GMAIL.COM", "SARAH.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEKNZwuiqOKZzZbUtFigoeUhhhkPlIdRGUyNc8H6Aqcelv36KoSnxZYl3/HdjUETuWQ==", null, false, "8001", null, "b3cb34ab-63e6-4d65-9bc5-229f24c0d368", "Western Cape", "Approved", "852 Inventory Street", false, "sarah.anderson@gmail.com" },
                    { "15", 0, "0212224567", "Cape Town", "306ce273-b100-479f-9bb8-64dfa3334d3f", null, "ApplicationUser", "robert.davis@gmail.com", true, "Robert", true, "Davis", false, null, "ROBERT.DAVIS@GMAIL.COM", "ROBERT.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEPtgBBj458LrRJU6KgesNmQ3BcC3xzq86M51re+GpNmEvJKb2mR87C4pcFucpjB1MQ==", null, false, "8001", null, "ff115373-d8d8-4b34-a0e5-8e525330043f", "Western Cape", "Approved", "987 Service Road", false, "robert.davis@gmail.com" },
                    { "16", 0, "0317778901", "Durban", "a5c8b634-fe82-4de9-b967-d28253edea70", null, "ApplicationUser", "jennifer.martin@gmail.com", true, "Jennifer", true, "Martin", false, null, "JENNIFER.MARTIN@GMAIL.COM", "JENNIFER.MARTIN@GMAIL.COM", "AQAAAAIAAYagAAAAEONJ7pjEmIiHSFSwNA/pVWczuyNgwEu+p58LwrvTVd0jjdMXtAtzIjNMQrDlLZUZJw==", null, false, "4001", null, "01afb52d-def7-44db-addc-e50374624e6d", "KwaZulu-Natal", "Approved", "147 Repair Lane", false, "jennifer.martin@gmail.com" },
                    { "17", 0, "0118881234", "Johannesburg", "c96c4bc2-1a96-4980-9168-372d386f8bc3", null, "ApplicationUser", "james.miller@gmail.com", true, "James", true, "Miller", false, null, "JAMES.MILLER@GMAIL.COM", "JAMES.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEJGmhk8KRAuRVJc+KWVvXJq7g1rwtSxv0HH7MWdiPpNGKDNDUu4RKig4l85BaDU0aA==", null, false, "2001", null, "c0a98056-46b8-41d8-ab61-62a2d3ea32d7", "Gauteng", "Approved", "258 Fault Street", false, "james.miller@gmail.com" },
                    { "18", 0, "0129994567", "Pretoria", "0590dbd7-062b-4984-86d8-e9c7b517e58c", null, "ApplicationUser", "patricia.white@gmail.com", true, "Patricia", true, "White", false, null, "PATRICIA.WHITE@GMAIL.COM", "PATRICIA.WHITE@GMAIL.COM", "AQAAAAIAAYagAAAAEBWOgyxYLPKGGEWDQTbQc0Hy90yBOj+LZGzyKkJ6nPT2Sp9bxEHpKZ33OZ4foEfXcw==", null, false, "0002", null, "62dba5c1-edd6-43d2-8b27-95a949f87f0f", "Gauteng", "Approved", "369 Diagnostic Road", false, "patricia.white@gmail.com" },
                    { "21", 0, "0439991234", "East London", "8ef2860e-17ac-445d-a907-a044d328a35c", null, "ApplicationUser", "william.thomas@gmail.com", true, "William", true, "Thomas", false, null, "WILLIAM.THOMAS@GMAIL.COM", "WILLIAM.THOMAS@GMAIL.COM", "AQAAAAIAAYagAAAAEPVP2jmC0uvPWbbRa4Z13ddjc+ifHIaPmx6vbw+m9jzCMb7wgrSMUROiCSVczrgaEg==", null, false, "5201", null, "00b01849-4680-46e2-aee9-df0e6374c038", "Eastern Cape", "Approved", "734 Business Street", false, "william.thomas@gmail.com" },
                    { "22", 0, "0338885678", "Pietermaritzburg", "854fcf9e-10b4-418e-a2b6-140d1490f9d7", null, "ApplicationUser", "ava.robinson@gmail.com", true, "Ava", true, "Robinson", false, null, "AVA.ROBINSON@GMAIL.COM", "AVA.ROBINSON@GMAIL.COM", "AQAAAAIAAYagAAAAEBgDY8kb3MHcLqK8BrIriidCet7RLE5ExZTKDrmIhdckGIQS3aLZF1djKQbX6oUZ/Q==", null, false, "3201", null, "3d94c87e-c5fe-43b3-8977-bfc2f0385e65", "KwaZulu-Natal", "Approved", "223 Business Street", false, "ava.robinson@gmail.com" },
                    { "23", 0, "0577779012", "Welkom", "6ac12499-4827-4eb2-9841-d1dd306d88e0", null, "ApplicationUser", "noah.clark@gmail.com", true, "Noah", true, "Clark", false, null, "NOAH.CLARK@GMAIL.COM", "NOAH.CLARK@GMAIL.COM", "AQAAAAIAAYagAAAAENk2RjzB6AyMI3SkUukOBev+3ODqzmEJ6Fj+BdohcvOgsttJTMQ9qnpVkPfwxmgmzw==", null, false, "9460", null, "cf1850d9-8d36-4fe5-a96c-3ff56e2e66fc", "Free State", "Approved", "692 Business Street", false, "noah.clark@gmail.com" },
                    { "24", 0, "0136663456", "Witbank", "079cb88e-caf1-4280-84af-0b8e98116e82", null, "ApplicationUser", "isabella.rodriguez@gmail.com", true, "Isabella", true, "Rodriguez", false, null, "ISABELLA.RODRIGUEZ@GMAIL.COM", "ISABELLA.RODRIGUEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEFC8a1Pdy6YSqEXwBaMrCo4H9nsBauJDvXGMHEBynNQxIi935JqdJ6lzSkVmI9FuJA==", null, false, "1035", null, "d9898c33-c4cd-4de3-a96d-c1e851e7279f", "Gauteng", "Approved", "188 Business Street", false, "isabella.rodriguez@gmail.com" },
                    { "3", 0, "0315551234", "Durban", "9e42f370-6838-4e4e-a1e6-1e7370741a08", null, "ApplicationUser", "mike.wilson@gmail.com", true, "Mike", true, "Wilson", false, null, "MIKE.WILSON@GMAIL.COM", "MIKE.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEAEe1SNjuGzo2MgPajTmMMxmHCRcZ8/cB3H6baGViYEjN7fRkvzf2XFGghRaSzNwyw==", null, false, "4001", null, "95e3db84-ad1c-439d-9d3a-033bfb93d756", "KwaZulu-Natal", "Approved", "298 Business Street", false, "mike.wilson@gmail.com" },
                    { "4", 0, "0124445678", "Pretoria", "cbb44667-15de-4a7b-8166-98fa35edcf65", null, "ApplicationUser", "lisa.brown@gmail.com", true, "Lisa", true, "Brown", false, null, "LISA.BROWN@GMAIL.COM", "LISA.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEJuYt32+YAx3SToK63tT+u5gIyZsz/wgPom6NMeCNqwJ1ZoIAcgkMbnay8QtdeASDw==", null, false, "0002", null, "13d8e505-9805-4d5c-b045-5d483f06d2c5", "Gauteng", "Approved", "834 Business Street", false, "lisa.brown@gmail.com" },
                    { "5", 0, "0413337890", "Port Elizabeth", "e4d5ddee-4416-4031-aa77-133c21070220", null, "ApplicationUser", "david.jackson@gmail.com", true, "David", true, "Jackson", false, null, "DAVID.JACKSON@GMAIL.COM", "DAVID.JACKSON@GMAIL.COM", "AQAAAAIAAYagAAAAEAG+ZYLi3leWm+bt0LpuHd5Z0XCYQfrbfgUQxvdTBK+ADw8KcuZFQGQGyoPSWybTrw==", null, false, "6001", null, "a5880e5a-74f0-47fb-8e4b-2b98693da4b5", "Eastern Cape", "Approved", "401 Business Street", false, "david.jackson@gmail.com" },
                    { "6", 0, "0512224567", "Bloemfontein", "7e8381cc-fc6f-42cf-b21b-0335448ec736", null, "ApplicationUser", "emma.davis@gmail.com", true, "Emma", true, "Davis", false, null, "EMMA.DAVIS@GMAIL.COM", "EMMA.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAELRZNY1MJ8H93DJPlpaPNakI9Qz4baoJMH1uc5somW0Q4e4YtwRnjSfCI1yTtte2FA==", null, false, "9301", null, "455148cd-9363-4d83-b466-402920d41ea2", "Free State", "Approved", "389 Business Street", false, "emma.davis@gmail.com" },
                    { "7", 0, "0131112345", "Nelspruit", "06a1cee6-9474-4f22-a0c7-8173ce4c7247", null, "ApplicationUser", "robert.miller@gmail.com", true, "Robert", true, "Miller", false, null, "ROBERT.MILLER@GMAIL.COM", "ROBERT.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEMZWR5rDb78YjlV+Tum3wqi4gQ9v3RTJumiWYjMie8zDD/2Pu+crZEdY7ZXPXpvCJQ==", null, false, "1200", null, "08a9f52c-d0ac-4b0b-bb2f-4d032bdd45b7", "Mpumalanga", "Approved", "514 Business Street", false, "robert.miller@gmail.com" },
                    { "8", 0, "0156667890", "Polokwane", "9fc553d4-1d52-428c-ac2e-dce40677934b", null, "ApplicationUser", "sophia.garcia@gmail.com", true, "Sophia", true, "Garcia", false, null, "SOPHIA.GARCIA@GMAIL.COM", "SOPHIA.GARCIA@GMAIL.COM", "AQAAAAIAAYagAAAAECUrz1aotS79aL6XX/9WllmsKUQ8Mvh7AbYLFfgye2YWjeIJvP3FhZplQW282zm7uA==", null, false, "0700", null, "d6330e56-b843-4a83-bee9-535ac0ee026e", "Limpopo", "Approved", "487 Business Street", false, "sophia.garcia@gmail.com" },
                    { "9", 0, "0537771234", "Kimberley", "2518a3ec-3c42-4dc1-91ec-41cc58da9d40", null, "ApplicationUser", "james.anderson@gmail.com", true, "James", true, "Anderson", false, null, "JAMES.ANDERSON@GMAIL.COM", "JAMES.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEMYFziseU87AQdjad5R9JHtDv9WKKXf0OmRNpNe9ZkKGBpEPSgryFNy42tgilPwE9w==", null, false, "8301", null, "0045326c-1763-4486-95a4-4b552d9e10cb", "Northern Cape", "Approved", "968 Business Street", false, "james.anderson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBusinessInfo",
                columns: new[] { "BusinessID", "Address", "BusinessName", "BusinessType", "City", "Country", "CreatedAt", "Email", "Industry", "LogoData", "LogoPath", "PhoneNumber", "PostalCode", "RegistrationNumber", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "FridgeHub Enterprises", "Fridge Rental", "Johannesburg", "South Africa", new DateTime(2023, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9229), "info@gmail.com", "Appliance Rental", null, null, "0111234567", "2000", "2024FH001", "www.fridgehub.com" },
                    { 2, "456 Service Road", "Cool Solutions SA", "Appliance Services", "Cape Town", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9234), "admin@coolsolutions.co.za", "Maintenance Services", null, null, "0219876543", "8001", "2023CS002", "www.coolsolutions.co.za" },
                    { 3, "789 Coastal Road", "Fridge Rentals Durban", "Rental Services", "Durban", "South Africa", new DateTime(2025, 5, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9238), "rentals@fridgedurban.co.za", "Appliance Rental", null, null, "0315551234", "4001", "2024FR003", "www.fridgedurban.co.za" }
                });

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Description", "ImageUrl", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 250, "Energy efficient fridge with frost-free technology and digital inverter compressor", "/Images/Fridges/fridge1.jpg", "Durban", "RT28A", 450.0, "Double Door" },
                    { 2, "Available", "LG", 260, "Smart inverter compressor for energy savings with multi-air flow system", "/Images/Fridges/fridge2.jpg", "Johannesburg", "GL-T292", 480.0, "Top Freezer" },
                    { 3, "Rented", "Hisense", 320, "Spacious design with humidity control and LED lighting", "/Images/Fridges/fridge3.jpg", "Cape Town", "H370BI", 520.0, "Bottom Freezer" },
                    { 4, "Available", "Defy", 350, "A+ energy rated with multi-airflow system and glass shelves", "/Images/Fridges/fridge4.jpg", "Pretoria", "DAC621", 550.0, "Combi Fridge" },
                    { 5, "Available", "Whirlpool", 200, "Compact and efficient single door fridge perfect for small spaces", "/Images/Fridges/fridge5.jpg", "Durban", "WDE205", 400.0, "Single Door" },
                    { 6, "Rented", "Bosch", 350, "No frost cooling with LED lighting and VitaFresh technology", "/Images/Fridges/fridge6.jpg", "Port Elizabeth", "KDN42", 600.0, "Frost Free" },
                    { 7, "Available", "Smeg", 270, "Stylish retro fridge with adjustable shelves and modern cooling", "/Images/Fridges/fridge7.jpg", "Johannesburg", "FAB28", 650.0, "Retro Style" },
                    { 8, "Available", "Kelvinator", 265, "Affordable fridge with efficient cooling and durable design", "/Images/Fridges/fridge8.jpg", "Cape Town", "KRF265", 430.0, "Top Mount" },
                    { 9, "Rented", "Siemens", 360, "No frost with multi-airflow system and hyperFresh technology", "/Images/Fridges/fridge9.jpg", "Pretoria", "KG36N", 590.0, "Bottom Freezer" },
                    { 10, "Available", "Haier", 290, "Toughened glass shelves and energy efficient with HCS technology", "/Images/Fridges/fridge10.jpg", "Durban", "HRF290", 470.0, "Double Door" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "10" },
                    { "3", "11" },
                    { "3", "12" },
                    { "4", "13" },
                    { "4", "14" },
                    { "5", "15" },
                    { "5", "16" },
                    { "6", "17" },
                    { "6", "18" },
                    { "2", "21" },
                    { "2", "22" },
                    { "2", "23" },
                    { "2", "24" },
                    { "2", "3" },
                    { "2", "4" },
                    { "2", "5" },
                    { "2", "6" },
                    { "2", "7" },
                    { "2", "8" },
                    { "2", "9" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "CustomerID", "ApplicationUserId", "BusinessDocumentData", "BusinessDocumentPath", "CustomerNumber" },
                values: new object[,]
                {
                    { 1, "3", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/business-license.pdf", "CUST001" },
                    { 2, "4", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/tax-certificate.pdf", "CUST002" },
                    { 3, "5", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/registration-document.pdf", "CUST003" },
                    { 4, "6", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/business-permit.pdf", "CUST004" },
                    { 5, "7", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/trade-license.pdf", "CUST005" },
                    { 6, "8", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/certificate.pdf", "CUST006" },
                    { 7, "9", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/business-registration.pdf", "CUST007" },
                    { 8, "10", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/compliance-doc.pdf", "CUST008" },
                    { 9, "21", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/operating-license.pdf", "CUST009" },
                    { 10, "22", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/business-permit.pdf", "CUST010" },
                    { 11, "23", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/certificate.pdf", "CUST011" },
                    { 12, "24", new byte[] { 37, 80, 68, 70, 45, 49, 46, 52, 10, 37, 226, 227, 207, 211, 10, 49, 32, 48, 32, 111, 98, 106, 10, 60, 60, 47, 84, 121, 112, 101 }, "/docs/registration-document.pdf", "CUST012" }
                });

            migrationBuilder.InsertData(
                table: "tblEmployee",
                columns: new[] { "EmployeeID", "ApplicationUserId", "EmployeeNumber" },
                values: new object[,]
                {
                    { 1, "1", "EMP001" },
                    { 2, "11", "EMP002" },
                    { 3, "12", "EMP003" },
                    { 4, "13", "EMP004" },
                    { 5, "14", "EMP005" },
                    { 6, "15", "EMP006" },
                    { 7, "16", "EMP007" },
                    { 8, "17", "EMP008" },
                    { 9, "18", "EMP009" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeInStocks",
                columns: new[] { "FridgeInStockId", "Condition", "FridgeId", "FridgeNo", "IsAvailable", "LastMaintenanceDate", "Location", "Quantity", "RequestDetailsRequestDetailId", "Status" },
                values: new object[,]
                {
                    { 1, "Excellent", 1, "FRG-001-001", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7400), "Durban Distribution", 1, null, "Available" },
                    { 2, "Good", 1, "FRG-001-002", true, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7452), "Durban Distribution", 1, null, "Available" },
                    { 3, "Excellent", 1, "FRG-001-003", true, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7456), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 4, "Good", 1, "FRG-001-004", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7461), "Cape Town Storage", 1, null, "Available" },
                    { 5, "Good", 1, "FRG-001-005", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7465), "Durban Distribution", 1, null, "Maintenance" },
                    { 6, "Good", 1, "FRG-001-006", true, new DateTime(2025, 11, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7470), "Port Elizabeth Depot", 1, null, "Available" },
                    { 7, "Good", 1, "FRG-001-007", false, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7475), "Durban Distribution", 1, null, "Maintenance" },
                    { 8, "Very Good", 1, "FRG-001-008", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(7479), "Cape Town Storage", 1, null, "Available" },
                    { 9, "Very Good", 2, "FRG-002-001", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9731), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 10, "Excellent", 2, "FRG-002-002", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9764), "Port Elizabeth Depot", 1, null, "Available" },
                    { 11, "Excellent", 2, "FRG-002-003", true, new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9774), "Cape Town Storage", 1, null, "Available" },
                    { 12, "Very Good", 2, "FRG-002-004", true, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9779), "Port Elizabeth Depot", 1, null, "Available" },
                    { 13, "Good", 2, "FRG-002-005", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9784), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 14, "Very Good", 2, "FRG-002-006", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9788), "Pretoria Facility", 1, null, "Available" },
                    { 15, "Very Good", 2, "FRG-002-007", false, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9822), "Port Elizabeth Depot", 1, null, "Maintenance" },
                    { 16, "Very Good", 2, "FRG-002-008", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9830), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 17, "Good", 3, "FRG-003-001", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9835), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 18, "Good", 3, "FRG-003-002", false, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9858), "Durban Distribution", 1, null, "Maintenance" },
                    { 19, "Good", 3, "FRG-003-003", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9863), "Port Elizabeth Depot", 1, null, "Available" },
                    { 20, "Excellent", 3, "FRG-003-004", false, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9868), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 21, "Very Good", 3, "FRG-003-005", true, new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9872), "Durban Distribution", 1, null, "Available" },
                    { 22, "Good", 3, "FRG-003-006", true, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9877), "Durban Distribution", 1, null, "Available" },
                    { 23, "Very Good", 3, "FRG-003-007", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9895), "Port Elizabeth Depot", 1, null, "Available" },
                    { 24, "Very Good", 3, "FRG-003-008", true, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9899), "Pretoria Facility", 1, null, "Available" },
                    { 25, "Excellent", 4, "FRG-004-001", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9904), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 26, "Very Good", 4, "FRG-004-002", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9908), "Cape Town Storage", 1, null, "Maintenance" },
                    { 27, "Excellent", 4, "FRG-004-003", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9913), "Durban Distribution", 1, null, "Available" },
                    { 28, "Very Good", 4, "FRG-004-004", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9917), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 29, "Good", 4, "FRG-004-005", true, new DateTime(2025, 7, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9921), "Durban Distribution", 1, null, "Available" },
                    { 30, "Very Good", 4, "FRG-004-006", false, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9934), "Pretoria Facility", 1, null, "Maintenance" },
                    { 31, "Very Good", 4, "FRG-004-007", true, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9952), "Cape Town Storage", 1, null, "Available" },
                    { 32, "Excellent", 4, "FRG-004-008", false, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9956), "Cape Town Storage", 1, null, "Maintenance" },
                    { 33, "Excellent", 5, "FRG-005-001", true, new DateTime(2025, 11, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9961), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 34, "Good", 5, "FRG-005-002", false, new DateTime(2025, 5, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9966), "Port Elizabeth Depot", 1, null, "Maintenance" },
                    { 35, "Excellent", 5, "FRG-005-003", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9970), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 36, "Excellent", 5, "FRG-005-004", true, new DateTime(2025, 10, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9975), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 37, "Very Good", 5, "FRG-005-005", false, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9979), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 38, "Excellent", 5, "FRG-005-006", true, new DateTime(2025, 6, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9983), "Pretoria Facility", 1, null, "Available" },
                    { 39, "Excellent", 5, "FRG-005-007", true, new DateTime(2025, 4, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9988), "Port Elizabeth Depot", 1, null, "Available" },
                    { 40, "Good", 5, "FRG-005-008", true, new DateTime(2025, 8, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9992), "Durban Distribution", 1, null, "Available" },
                    { 41, "Excellent", 6, "FRG-006-001", false, new DateTime(2025, 9, 12, 10, 58, 17, 951, DateTimeKind.Local).AddTicks(9997), "Durban Distribution", 1, null, "Maintenance" },
                    { 42, "Excellent", 6, "FRG-006-002", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(2), "Cape Town Storage", 1, null, "Available" },
                    { 43, "Very Good", 6, "FRG-006-003", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(6), "Durban Distribution", 1, null, "Available" },
                    { 44, "Very Good", 6, "FRG-006-004", true, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(10), "Pretoria Facility", 1, null, "Available" },
                    { 45, "Very Good", 6, "FRG-006-005", true, new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(15), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 46, "Excellent", 6, "FRG-006-006", false, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(19), "Cape Town Storage", 1, null, "Maintenance" },
                    { 47, "Excellent", 6, "FRG-006-007", false, new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(23), "Cape Town Storage", 1, null, "Maintenance" },
                    { 48, "Good", 6, "FRG-006-008", true, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(28), "Durban Distribution", 1, null, "Available" },
                    { 49, "Excellent", 7, "FRG-007-001", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(32), "Port Elizabeth Depot", 1, null, "Available" },
                    { 50, "Very Good", 7, "FRG-007-002", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(36), "Cape Town Storage", 1, null, "Available" },
                    { 51, "Very Good", 7, "FRG-007-003", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(41), "Cape Town Storage", 1, null, "Available" },
                    { 52, "Very Good", 7, "FRG-007-004", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(45), "Durban Distribution", 1, null, "Available" },
                    { 53, "Good", 7, "FRG-007-005", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(50), "Cape Town Storage", 1, null, "Available" },
                    { 54, "Excellent", 7, "FRG-007-006", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(54), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 55, "Excellent", 7, "FRG-007-007", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(58), "Pretoria Facility", 1, null, "Available" },
                    { 56, "Very Good", 7, "FRG-007-008", false, new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(62), "Johannesburg Main Warehouse", 1, null, "Maintenance" },
                    { 57, "Excellent", 8, "FRG-008-001", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(67), "Pretoria Facility", 1, null, "Available" },
                    { 58, "Very Good", 8, "FRG-008-002", true, new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(71), "Durban Distribution", 1, null, "Available" },
                    { 59, "Very Good", 8, "FRG-008-003", false, new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(76), "Pretoria Facility", 1, null, "Maintenance" },
                    { 60, "Good", 8, "FRG-008-004", true, new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(80), "Cape Town Storage", 1, null, "Available" },
                    { 61, "Good", 8, "FRG-008-005", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(84), "Pretoria Facility", 1, null, "Available" },
                    { 62, "Very Good", 8, "FRG-008-006", true, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(89), "Port Elizabeth Depot", 1, null, "Available" },
                    { 63, "Good", 8, "FRG-008-007", true, new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(93), "Durban Distribution", 1, null, "Available" },
                    { 64, "Excellent", 8, "FRG-008-008", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(97), "Cape Town Storage", 1, null, "Available" },
                    { 65, "Excellent", 9, "FRG-009-001", true, new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(102), "Pretoria Facility", 1, null, "Available" },
                    { 66, "Good", 9, "FRG-009-002", true, new DateTime(2025, 5, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(107), "Durban Distribution", 1, null, "Available" },
                    { 67, "Excellent", 9, "FRG-009-003", false, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(111), "Cape Town Storage", 1, null, "Maintenance" },
                    { 68, "Very Good", 9, "FRG-009-004", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(116), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 69, "Very Good", 9, "FRG-009-005", false, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(121), "Port Elizabeth Depot", 1, null, "Maintenance" },
                    { 70, "Very Good", 9, "FRG-009-006", true, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(125), "Johannesburg Main Warehouse", 1, null, "Available" },
                    { 71, "Excellent", 9, "FRG-009-007", false, new DateTime(2025, 4, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(130), "Port Elizabeth Depot", 1, null, "Maintenance" },
                    { 72, "Excellent", 9, "FRG-009-008", false, new DateTime(2025, 7, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(134), "Cape Town Storage", 1, null, "Maintenance" },
                    { 73, "Good", 10, "FRG-010-001", false, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(140), "Durban Distribution", 1, null, "Maintenance" },
                    { 74, "Excellent", 10, "FRG-010-002", true, new DateTime(2025, 9, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(151), "Port Elizabeth Depot", 1, null, "Available" },
                    { 75, "Very Good", 10, "FRG-010-003", true, new DateTime(2025, 11, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(156), "Cape Town Storage", 1, null, "Available" },
                    { 76, "Excellent", 10, "FRG-010-004", false, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(160), "Port Elizabeth Depot", 1, null, "Maintenance" },
                    { 77, "Good", 10, "FRG-010-005", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(165), "Cape Town Storage", 1, null, "Available" },
                    { 78, "Very Good", 10, "FRG-010-006", true, new DateTime(2025, 10, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(169), "Pretoria Facility", 1, null, "Available" },
                    { 79, "Excellent", 10, "FRG-010-007", true, new DateTime(2025, 8, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(174), "Durban Distribution", 1, null, "Available" },
                    { 80, "Good", 10, "FRG-010-008", true, new DateTime(2025, 6, 12, 10, 58, 17, 952, DateTimeKind.Local).AddTicks(178), "Pretoria Facility", 1, null, "Available" }
                });

            migrationBuilder.InsertData(
                table: "tblAllocations",
                columns: new[] { "AllocationId", "Count", "CustomerID", "FridgeId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 1, 5 },
                    { 3, 2, 3, 4 },
                    { 4, 1, 3, 7 },
                    { 5, 1, 3, 8 },
                    { 6, 1, 4, 3 },
                    { 7, 1, 4, 6 },
                    { 8, 1, 4, 9 }
                });

            migrationBuilder.InsertData(
                table: "tblFaultReports",
                columns: new[] { "FaultReportId", "CustomerId", "DeclineReason", "Description", "FaultType", "FridgeInStockId", "ImageUrl", "IsRelaunched", "IsReplacementRequested", "OriginalFaultReportId", "Priority", "ReportedDate", "RequestReplacement", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, "Fridge not maintaining temperature. Food items spoiling. Compressor running but not cooling properly.", "Not Cooling", 5, "/Images/Faults/fault-1.jpg", false, false, null, "Critical", new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3301), false, "Resolved" },
                    { 2, 3, null, "Loud grinding noise coming from compressor area. Noise occurs every 15 minutes during cooling cycle.", "Strange Noises", 29, "/Images/Faults/fault-2.jpg", false, true, null, "High", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3319), true, "In Progress" },
                    { 3, 4, null, "Water pooling under fridge. Leak appears to be coming from defrost drain tube. Ice buildup in freezer compartment.", "Water Leakage", 33, "/Images/Faults/fault-3.jpg", false, false, null, "Medium", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3323), false, "Resolved" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestHeaders",
                columns: new[] { "RequestHeaderId", "AdditionalDescription", "AdditionalDocumentPath", "Carrier", "CellNumber", "City", "CustomerID", "DeliveryDate", "EmployeeID", "FirstName", "IsRelaunched", "IsReplacement", "LastName", "OriginalRequestId", "PaymentDueDate", "PostalCode", "RejectionDate", "RejectionReason", "RequestDate", "RequestTotal", "State", "Status", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, "0315551234", "Port Elizabeth", 1, null, 2, "Mike", false, false, "Wilson", null, null, "6001", null, null, new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(1543), 1350.0, "Eastern Cape", "Pending", "857 Trade Street" },
                    { 2, null, null, null, "0124445678", "Johannesburg", 2, null, 3, "Lisa", false, false, "Brown", null, null, "2000", new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558), "Required additional verification documents", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558), 980.0, "Gauteng", "Rejected", "642 Commerce Road" },
                    { 3, null, null, null, "0413337890", "Johannesburg", 3, new DateTime(2025, 11, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), 4, "David", false, false, "Jackson", null, new DateTime(2025, 12, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), "2001", null, null, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), 2200.0, "Gauteng", "Shipped", "358 Commerce Road" },
                    { 4, null, null, null, "0512224567", "Bloemfontein", 4, null, 5, "Emma", false, false, "Davis", null, null, "9301", null, null, new DateTime(2025, 8, 19, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2578), 1650.0, "Free State", "Approved", "720 Trade Street" },
                    { 5, null, null, null, "0131112345", "Durban", 5, null, 6, "Robert", false, false, "Miller", null, null, "4001", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584), "Credit check failed", new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584), 1200.0, "KwaZulu-Natal", "Rejected", "653 Business Avenue" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeVisits",
                columns: new[] { "VisitId", "CheckupStatus", "CreatedDate", "CustomerApproval", "Notes", "RequestHeaderId", "Status", "TechnicianName", "VisitDate", "VisitType" },
                values: new object[,]
                {
                    { 1, "Passed", new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132), "Approved", "Routine maintenance completed. Checked compressor, condenser coils, and door seals. All components functioning normally.", 3, "Completed", "Jennifer Martin", new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132), "Maintenance Check" },
                    { 2, "Passed", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161), "Approved", "Customer reported temperature fluctuations. Found faulty thermostat. Replaced thermostat and recalibrated temperature settings.", 1, "Completed", "Jennifer Martin", new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161), "Repair" },
                    { 3, "Passed", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164), "Approved", "Quarterly preventive maintenance. Cleaned condenser coils, checked refrigerant levels, and verified door seal integrity.", 4, "Completed", "James Miller", new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164), "Preventive Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestDetais",
                columns: new[] { "RequestDetailId", "Count", "FridgeId", "Price", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, 2, 1, 900.0, 1 },
                    { 2, 1, 5, 450.0, 1 },
                    { 3, 1, 2, 480.0, 2 },
                    { 4, 1, 10, 500.0, 2 },
                    { 5, 2, 4, 1100.0, 3 },
                    { 6, 1, 7, 650.0, 3 },
                    { 7, 1, 8, 450.0, 3 },
                    { 8, 1, 3, 520.0, 4 },
                    { 9, 1, 6, 600.0, 4 },
                    { 10, 1, 9, 530.0, 4 },
                    { 11, 3, 1, 1200.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "tblRequestNotes",
                columns: new[] { "RequestNoteId", "CreatedDate", "NoteContent", "NoteType", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3817), "Customer called to confirm delivery address. Confirmed business hours for delivery between 9 AM - 4 PM.", "Customer", 1 },
                    { 2, new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3832), "Additional business registration documents requested. Customer to email copies by end of week.", "Administrative", 2 },
                    { 3, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3836), "Installation completed successfully. Customer trained on temperature settings and basic maintenance.", "Technical", 3 },
                    { 4, new DateTime(2025, 8, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3838), "Credit application approved. Standard rental agreement terms applied.", "Internal", 4 }
                });

            migrationBuilder.InsertData(
                table: "tblCustomerFridge",
                columns: new[] { "CustomerFridgeId", "AllocatedDate", "CustomerID", "DeclineReason", "FridgeId", "FridgeInStockId", "IsActive", "ReasonForReplacement", "ReplacementDate", "ReplacementFridgeInStockId", "ReplacementNotes", "ReplacementStatus", "RequestDetailId", "ReservedDate", "TechnicianNotes" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2961), 1, null, 1, 5, true, null, null, null, null, null, 1, new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2961), null },
                    { 2, new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2978), 1, null, 5, 41, true, null, null, null, null, null, 2, new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2978), null },
                    { 3, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), 3, null, 4, 29, true, null, null, null, null, null, 5, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), null },
                    { 4, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), 3, null, 7, 53, true, null, null, null, null, null, 6, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), null },
                    { 5, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), 3, null, 8, 61, true, null, null, null, null, null, 7, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), null }
                });

            migrationBuilder.InsertData(
                table: "tblFaultTechnicians",
                columns: new[] { "FaultId", "Bookingate", "Completion", "CreatedDate", "CustomerBookingStatus", "FaultDescription", "FaultReportId", "FaultType", "Priority", "RepairStatus", "ReportDate", "ResolutionNotes", "TechnicianAssigned", "VisitId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), null, new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), "Approved", "Diagnosed faulty compressor relay. Replaced relay and tested system. Temperature now stable at 4°C.", 1, "Not Cooling", "Critical", "Completed", new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), "Compressor relay replacement completed successfully. System cooling efficiently.", "Jennifer Martin", 2 },
                    { 2, new DateTime(2025, 11, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), null, new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), "Approved", "Identified worn compressor mounts causing vibration noise. Requires compressor replacement.", 2, "Strange Noises", "High", "In Progress", new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), "Compressor mounts worn beyond repair. Replacement scheduled for next week.", "James Miller", 1 }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeReplacements",
                columns: new[] { "FridgeReplacementId", "ActionBy", "ActionDate", "AdditionalNotes", "ApplicationUserId", "ApprovedBy", "CustomerID", "DeclineReason", "NewFridgeInStockId", "OldFridgeNo", "ReasonForReplacement", "ReplacementDate", "ReplacementStatus", "RequestDate", "TechnicianNotes", "VisitId" },
                values: new object[] { 1, "James Miller", new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), "Customer approved replacement with similar capacity model. Old unit has served 7 years.", "3", "Emily Wilson", 3, null, 30, "FRG-004-005", "Compressor failure beyond economical repair", new DateTime(2025, 11, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), "Approved", new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), "Compressor seized due to refrigerant leak. Repair cost exceeds 70% of replacement value.", 1 });

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
                name: "IX_tblAllocations_CustomerID",
                table: "tblAllocations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllocations_FridgeId",
                table: "tblAllocations",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_ApplicationUserId",
                table: "tblCustomer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_CustomerID",
                table: "tblCustomerFridge",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_FridgeId",
                table: "tblCustomerFridge",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_FridgeInStockId",
                table: "tblCustomerFridge",
                column: "FridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_ReplacementFridgeInStockId",
                table: "tblCustomerFridge",
                column: "ReplacementFridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerFridge_RequestDetailId",
                table: "tblCustomerFridge",
                column: "RequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_ApplicationUserId",
                table: "tblEmployee",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_CustomerId",
                table: "tblFaultReports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultReports_FridgeInStockId",
                table: "tblFaultReports",
                column: "FridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultTechnicians_FaultReportId",
                table: "tblFaultTechnicians",
                column: "FaultReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFaultTechnicians_VisitId",
                table: "tblFaultTechnicians",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeInStocks_FridgeId",
                table: "tblFridgeInStocks",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeInStocks_RequestDetailsRequestDetailId",
                table: "tblFridgeInStocks",
                column: "RequestDetailsRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_ApplicationUserId",
                table: "tblFridgeReplacements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_CustomerID",
                table: "tblFridgeReplacements",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_NewFridgeInStockId",
                table: "tblFridgeReplacements",
                column: "NewFridgeInStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeReplacements_VisitId",
                table: "tblFridgeReplacements",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFridgeVisits_RequestHeaderId",
                table: "tblFridgeVisits",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_FridgeId",
                table: "tblRequestDetais",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestDetais_RequestHeaderId",
                table: "tblRequestDetais",
                column: "RequestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_CustomerID",
                table: "tblRequestHeaders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestHeaders_EmployeeID",
                table: "tblRequestHeaders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestNotes_RequestHeaderId",
                table: "tblRequestNotes",
                column: "RequestHeaderId");
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
                name: "tblAllocations");

            migrationBuilder.DropTable(
                name: "tblBusinessInfo");

            migrationBuilder.DropTable(
                name: "tblCustomerFridge");

            migrationBuilder.DropTable(
                name: "tblFaultTechnicians");

            migrationBuilder.DropTable(
                name: "tblFridgeReplacements");

            migrationBuilder.DropTable(
                name: "tblRequestNotes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblFaultReports");

            migrationBuilder.DropTable(
                name: "tblFridgeVisits");

            migrationBuilder.DropTable(
                name: "tblFridgeInStocks");

            migrationBuilder.DropTable(
                name: "tblRequestDetais");

            migrationBuilder.DropTable(
                name: "tblFridges");

            migrationBuilder.DropTable(
                name: "tblRequestHeaders");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblEmployee");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
