using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
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
                    RequestDetailId = table.Column<int>(type: "int", nullable: false)
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
                    VisitId = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    NewFridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    OldFridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacementStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeReplacements", x => x.FridgeReplacementId);
                    table.ForeignKey(
                        name: "FK_tblFridgeReplacements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { "1", 0, "0111234567", "Johannesburg", "14aef516-b916-4aa4-b80f-1aa446e8d215", null, "ApplicationUser", "admin@gmail.com", true, "John", true, "Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENebnSyk+PuK5kon0zoiV2f6jA3JeMglSCd1BpMrmuhNB/pXmvpwuinTuetd5IELrQ==", null, false, "2000", null, "ec884ea3-0363-4116-b037-7fe065341df3", "Gauteng", "Approved", "123 Admin Street", false, "admin@gmail.com" },
                    { "10", 0, "0148884567", "Rustenburg", "8115eb73-1731-4a54-ad65-53d14860323f", null, "ApplicationUser", "olivia.martinez@gmail.com", true, "Olivia", true, "Martinez", false, null, "OLIVIA.MARTINEZ@GMAIL.COM", "OLIVIA.MARTINEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEHs4Q9ENIWhqNCxJZ46DZmiD3nBtAhUMxCFoPJ5gMHks65sDkX3z2T6LOw+n0V9sfg==", null, false, "2999", null, "54778b14-c0e0-4f2f-a7df-f599ee540b35", "North West", "Approved", "741 Commercial Ave", false, "olivia.martinez@gmail.com" },
                    { "11", 0, "0315551234", "Durban", "0b271645-fee6-40d1-a3bb-298fcbb8ffab", null, "ApplicationUser", "emily.wilson@gmail.com", true, "Emily", true, "Wilson", false, null, "EMILY.WILSON@GMAIL.COM", "EMILY.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEGLzq4QYRo+lixgaX9sMZTp413PuXFBG8Jwj8zIUxNWUSKlcj8l3iHE/76bqoJCEmw==", null, false, "4001", null, "f82fcaaf-aea1-428c-9fd9-dfdaf286a2a3", "KwaZulu-Natal", "Approved", "789 Support Road", false, "emily.wilson@gmail.com" },
                    { "12", 0, "0124445678", "Pretoria", "f3b7bdc3-2d79-4cf9-9145-5991f9f481cb", null, "ApplicationUser", "michael.brown@gmail.com", true, "Michael", true, "Brown", false, null, "MICHAEL.BROWN@GMAIL.COM", "MICHAEL.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEP9nZztID4QfmCGiu8rZYBMhfPszSmnzX1NPHTYWa3BZt0JjpTNsAu2FkaeMv5N81Q==", null, false, "0002", null, "a7d4bedd-cf7f-47c5-adf8-38028d73143a", "Gauteng", "Approved", "321 Help Street", false, "michael.brown@gmail.com" },
                    { "13", 0, "0113337890", "Johannesburg", "7d81bd78-a95d-401f-82f4-984eed9269a6", null, "ApplicationUser", "david.taylor@gmail.com", true, "David", true, "Taylor", false, null, "DAVID.TAYLOR@GMAIL.COM", "DAVID.TAYLOR@GMAIL.COM", "AQAAAAIAAYagAAAAELOJ2KVATAS5rfpfIQ9R5M5lMgyT/gDn1DvJXxNVeMDIEpAe4ZLC5PY7jfsBq6vQOQ==", null, false, "2001", null, "e012ff2b-3b09-48ff-b6a9-9729d3af40b9", "Gauteng", "Approved", "654 Warehouse Ave", false, "david.taylor@gmail.com" },
                    { "14", 0, "0216667890", "Cape Town", "905e1f8a-0ab0-42c8-988b-8666a13952aa", null, "ApplicationUser", "sarah.anderson@gmail.com", true, "Sarah", true, "Anderson", false, null, "SARAH.ANDERSON@GMAIL.COM", "SARAH.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEEK4ZP59iJNH14qS2aqQz1uGg9KHXrMpfMFp57mDfZsBpBFuh32OIqO+tAAgxaDR1A==", null, false, "8001", null, "e09828bb-8328-4b0d-8d2b-650733a2c836", "Western Cape", "Approved", "852 Inventory Street", false, "sarah.anderson@gmail.com" },
                    { "15", 0, "0212224567", "Cape Town", "75303422-5892-4148-ae9e-d5126be6547a", null, "ApplicationUser", "robert.davis@gmail.com", true, "Robert", true, "Davis", false, null, "ROBERT.DAVIS@GMAIL.COM", "ROBERT.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEMFM4WS9WfwtyE0zf6qw5NuklOPkIAaCUghB3HfEZZR2OWCeWtJA6zwjVjeZ+DHMIA==", null, false, "8001", null, "0f0b9835-6f5d-4ab0-bd0f-0f313585d6a3", "Western Cape", "Approved", "987 Service Road", false, "robert.davis@gmail.com" },
                    { "16", 0, "0317778901", "Durban", "17e7be01-0ca2-49bd-b8e1-08656ed1e1b8", null, "ApplicationUser", "jennifer.martin@gmail.com", true, "Jennifer", true, "Martin", false, null, "JENNIFER.MARTIN@GMAIL.COM", "JENNIFER.MARTIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFQhnoURfNzKHVBTI7ZeXLJBHJvujp0DDlKyzqGR4bjkC1aVUiAmDcyDBJLlYrNYKQ==", null, false, "4001", null, "e9f09c95-90f9-46ec-8823-c37bc929622d", "KwaZulu-Natal", "Approved", "147 Repair Lane", false, "jennifer.martin@gmail.com" },
                    { "17", 0, "0118881234", "Johannesburg", "585daca8-26b9-4d3b-8213-5a1c8241d7ae", null, "ApplicationUser", "james.miller@gmail.com", true, "James", true, "Miller", false, null, "JAMES.MILLER@GMAIL.COM", "JAMES.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEOGWImjG0fwjA5kmOaeZN0YgL/Es+FUxF4KQMaLvrhjyIJPLONFYvMx7/20c8nFSMA==", null, false, "2001", null, "ee36fe2d-361d-46c9-a093-342ccfe8537e", "Gauteng", "Approved", "258 Fault Street", false, "james.miller@gmail.com" },
                    { "18", 0, "0129994567", "Pretoria", "5435828a-58d4-47d5-8b43-9a9a4631ad44", null, "ApplicationUser", "patricia.white@gmail.com", true, "Patricia", true, "White", false, null, "PATRICIA.WHITE@GMAIL.COM", "PATRICIA.WHITE@GMAIL.COM", "AQAAAAIAAYagAAAAEDWHru8+LpO0DOPpfu+iHSVv7bjQHnIhMIDwr88phYepBN8Ax5K9JUU1KFBkZI5HJw==", null, false, "0002", null, "52f74e5e-6b7d-40a3-bee7-c5c792490864", "Gauteng", "Approved", "369 Diagnostic Road", false, "patricia.white@gmail.com" },
                    { "2", 0, "0219876543", "Cape Town", "30047f0d-4d66-4bcc-b44b-5fcbe1b1419e", null, "ApplicationUser", "sarah.johnson@gmail.com", true, "Sarah", true, "Johnson", false, null, "SARAH.JOHNSON@GMAIL.COM", "SARAH.JOHNSON@GMAIL.COM", "AQAAAAIAAYagAAAAEE5WMxm1On3fkSPm5HgzU+/4zWs+PCTbM6ZWlab0yQyCKaWPM24hYsyZgNf04H2TlA==", null, false, "8001", null, "573c10df-f09b-42bc-8f86-fe3bba78523c", "Western Cape", "Approved", "456 Management Ave", false, "sarah.johnson@gmail.com" },
                    { "21", 0, "0439991234", "East London", "64db4a84-0f89-4401-80dc-ed6d4a506230", null, "ApplicationUser", "william.thomas@gmail.com", true, "William", true, "Thomas", false, null, "WILLIAM.THOMAS@GMAIL.COM", "WILLIAM.THOMAS@GMAIL.COM", "AQAAAAIAAYagAAAAEFMP7HAozyp1dF0IcX8l74FRQNmI9lhGNR7tIq6dfa+8tk7tIDCWfdVtBI7/D6SfKQ==", null, false, "5201", null, "0e102f49-6a57-4667-928e-f6b56ef159fb", "Eastern Cape", "Approved", "852 Enterprise Street", false, "william.thomas@gmail.com" },
                    { "22", 0, "0338885678", "Pietermaritzburg", "1ae7fc29-3dc7-4a02-a2fe-925a1fc112d8", null, "ApplicationUser", "ava.robinson@gmail.com", true, "Ava", true, "Robinson", false, null, "AVA.ROBINSON@GMAIL.COM", "AVA.ROBINSON@GMAIL.COM", "AQAAAAIAAYagAAAAEGV8p1DCI0h1li6F/rxPOD2DWcgRBr4Z5GF+BEvSDinEn1cNBMa32PpJNnVhYxFPwQ==", null, false, "3201", null, "c26e31fe-669a-4f18-822f-9861653cd391", "KwaZulu-Natal", "Approved", "963 Corporate Road", false, "ava.robinson@gmail.com" },
                    { "23", 0, "0577779012", "Welkom", "4bf0704c-2f13-4052-bc19-27bf39711588", null, "ApplicationUser", "noah.clark@gmail.com", true, "Noah", true, "Clark", false, null, "NOAH.CLARK@GMAIL.COM", "NOAH.CLARK@GMAIL.COM", "AQAAAAIAAYagAAAAEN4fkuDSdwqhfSS6BL51liTP6KIb0Il47DTCsdrC2dJxCNXT9iB/AjlvU0i/jYwxyQ==", null, false, "9460", null, "d8e9a9dc-564a-4b03-97a3-d8e72e22aabb", "Free State", "Approved", "159 Business Park", false, "noah.clark@gmail.com" },
                    { "24", 0, "0136663456", "Witbank", "23043d3c-c979-43e8-befc-aaaf3059477a", null, "ApplicationUser", "isabella.rodriguez@gmail.com", true, "Isabella", true, "Rodriguez", false, null, "ISABELLA.RODRIGUEZ@GMAIL.COM", "ISABELLA.RODRIGUEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMd4qXZZAi/2XxBtelz14VWF8MEeKiMNErIXmMwwZ4nYFmfGRFfRheYp4LNSPa5CfQ==", null, false, "1035", null, "9760c81f-a0d8-4aa4-aa36-591d2c767a70", "Mpumalanga", "Approved", "753 Industrial Area", false, "isabella.rodriguez@gmail.com" },
                    { "25", 0, "0117772345", "Johannesburg", "22e488d1-e498-41ca-bf47-ce59d984d654", null, "ApplicationUser", "daniel.moore@gmail.com", true, "Daniel", true, "Moore", false, null, "DANIEL.MOORE@GMAIL.COM", "DANIEL.MOORE@GMAIL.COM", "AQAAAAIAAYagAAAAEH3sV32FORp2cVNTrpS0X8PJe5oFp1+3kX0DSOJdR9hVVN35oOWlg/Yipvn9YwmD5g==", null, false, "2001", null, "4c84d27c-2308-47f9-97de-a991fed485b0", "Gauteng", "Approved", "456 Service Lane", false, "daniel.moore@gmail.com" },
                    { "26", 0, "0215556789", "Cape Town", "cd1934db-937a-44be-8d73-15aa5b0edf9e", null, "ApplicationUser", "susan.lee@gmail.com", true, "Susan", true, "Lee", false, null, "SUSAN.LEE@GMAIL.COM", "SUSAN.LEE@GMAIL.COM", "AQAAAAIAAYagAAAAECYsU8uZB/V7xYoKmWC3V9ON+7GOx1xIuTRGTHHOERnl3uBKOy+liP8T+iCrjFLLKQ==", null, false, "8001", null, "1fc9619a-880c-4f30-b4d6-82a838533bfe", "Western Cape", "Approved", "789 Stock Avenue", false, "susan.lee@gmail.com" },
                    { "3", 0, "0315551234", "Durban", "21759a6d-c372-4773-967e-52a3737e7a07", null, "ApplicationUser", "mike.wilson@gmail.com", true, "Mike", true, "Wilson", false, null, "MIKE.WILSON@GMAIL.COM", "MIKE.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEOiuz1v/rzK+AjYQrb+QlFlcqiSVQDZAn5vYrG173IFkbJEvxVN9En6IG3ua3ut1QQ==", null, false, "4001", null, "95e33ea0-41d1-44f0-9931-9b1ff1201416", "KwaZulu-Natal", "Approved", "789 Customer Road", false, "mike.wilson@gmail.com" },
                    { "4", 0, "0124445678", "Pretoria", "38912588-85ee-430b-8eb0-57e740239591", null, "ApplicationUser", "lisa.brown@gmail.com", true, "Lisa", true, "Brown", false, null, "LISA.BROWN@GMAIL.COM", "LISA.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEH9wCv3QIO0hRsppVFUDWGTqWTyNNrjqdEAgQtW6G/d1PA19MvrICfC4GekF+qZ4cQ==", null, false, "0002", null, "1231e87c-cabd-4d49-932b-e09a85f78f69", "Gauteng", "Approved", "321 Business Street", false, "lisa.brown@gmail.com" },
                    { "5", 0, "0413337890", "Port Elizabeth", "52afb843-bbab-4e13-9d88-167f6e3d4a0a", null, "ApplicationUser", "david.jackson@gmail.com", true, "David", true, "Jackson", false, null, "DAVID.JACKSON@GMAIL.COM", "DAVID.JACKSON@GMAIL.COM", "AQAAAAIAAYagAAAAEPbO9OgtypIFanlWtF6jFecu3Q1+C0NB0Rk4M9QhNnHj4G5YRRtAXxOV+At9Fco3Gg==", null, false, "6001", null, "3b0902ee-5465-4c38-8a64-31849f429e22", "Eastern Cape", "Approved", "654 Retail Avenue", false, "david.jackson@gmail.com" },
                    { "6", 0, "0512224567", "Bloemfontein", "ba0b9896-e3f4-45aa-8cdf-a8fbe0fd98c7", null, "ApplicationUser", "emma.davis@gmail.com", true, "Emma", true, "Davis", false, null, "EMMA.DAVIS@GMAIL.COM", "EMMA.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEKDrzu78hQl9CAwOUAdfpqmFOFBtQsM9oOGGhLvf/nQPuZ7lM9sOmBe2e0f0DC1cwg==", null, false, "9301", null, "f7a64005-f327-4fe4-a022-21c14f086174", "Free State", "Approved", "987 Commerce Road", false, "emma.davis@gmail.com" },
                    { "7", 0, "0131112345", "Nelspruit", "3ea48748-30f3-4f25-9546-eaa63ba79055", null, "ApplicationUser", "robert.miller@gmail.com", true, "Robert", true, "Miller", false, null, "ROBERT.MILLER@GMAIL.COM", "ROBERT.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEJww3XB1wYr8et1GWbf9Fx9zs7RlBKJgGqJsOuYKHvLpkdO2EhYWPn3jDy9rs1Jl5A==", null, false, "1200", null, "02e6ebf7-0d58-4ad2-b90a-211ae9112a4e", "Mpumalanga", "Approved", "147 Trade Street", false, "robert.miller@gmail.com" },
                    { "8", 0, "0156667890", "Polokwane", "51d835b7-2c4a-4f39-9cf2-c70a63697987", null, "ApplicationUser", "sophia.garcia@gmail.com", true, "Sophia", true, "Garcia", false, null, "SOPHIA.GARCIA@GMAIL.COM", "SOPHIA.GARCIA@GMAIL.COM", "AQAAAAIAAYagAAAAENgGRLP8YxZo1MMAGOVI7sKJb0Z5jEmX1eka/fZTl6eFSExCW5qIdzUQpadrIriVew==", null, false, "0700", null, "51309301-7a99-4160-8332-f03b9a3aa8aa", "Limpopo", "Approved", "258 Market Lane", false, "sophia.garcia@gmail.com" },
                    { "9", 0, "0537771234", "Kimberley", "4efe4b33-f230-4ed9-93ca-920814513e88", null, "ApplicationUser", "james.anderson@gmail.com", true, "James", true, "Anderson", false, null, "JAMES.ANDERSON@GMAIL.COM", "JAMES.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAELPGKieTf05YUA77/JMEx6Oe2URxn1bp4Xlj1qsxrXaZ6ihFa9fdGEgPBFe2f1D/2g==", null, false, "8301", null, "6738e4a9-1cb6-4b98-a283-70ca4cb92477", "Northern Cape", "Approved", "369 Industry Road", false, "james.anderson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBusinessInfo",
                columns: new[] { "BusinessID", "Address", "BusinessName", "BusinessType", "City", "Country", "CreatedAt", "Email", "Industry", "LogoData", "LogoPath", "PhoneNumber", "PostalCode", "RegistrationNumber", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "FridgeHub Enterprises", "Fridge Rental", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(163), "info@gmail.com", "Appliance Rental", null, null, "0111234567", "2000", "2024FH001", "www.fridgehub.com" },
                    { 2, "456 Service Road", "Cool Solutions SA", "Appliance Services", "Cape Town", "South Africa", new DateTime(2024, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(168), "admin@coolsolutions.co.za", "Maintenance Services", null, null, "0219876543", "8001", "2023CS002", "www.coolsolutions.co.za" },
                    { 3, "789 Coastal Road", "Fridge Rentals Durban", "Rental Services", "Durban", "South Africa", new DateTime(2025, 5, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(172), "rentals@fridgedurban.co.za", "Appliance Rental", null, null, "0315551234", "4001", "2024FR003", "www.fridgedurban.co.za" },
                    { 4, "321 Capital Avenue", "Pretoria Cooling Systems", "HVAC Services", "Pretoria", "South Africa", new DateTime(2024, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(174), "info@pretoriacooling.co.za", "Cooling Systems", null, null, "0124445678", "0002", "2023PCS004", "www.pretoriacooling.co.za" },
                    { 5, "654 Ocean View", "Eastern Cape Appliances", "Appliance Retail", "Port Elizabeth", "South Africa", new DateTime(2025, 3, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(177), "sales@ecappliances.co.za", "Retail", null, null, "0413337890", "6001", "2024ECA005", "www.ecappliances.co.za" },
                    { 6, "987 Central Street", "Free State Cooling", "Cooling Solutions", "Bloemfontein", "South Africa", new DateTime(2024, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(180), "contact@fscooling.co.za", "HVAC Services", null, null, "0512224567", "9301", "2023FSC006", "www.fscooling.co.za" },
                    { 7, "147 Highlands Road", "Mpumalanga Fridge Rentals", "Rental Services", "Nelspruit", "South Africa", new DateTime(2025, 7, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(182), "info@mpumalangafridges.co.za", "Appliance Rental", null, null, "0131112345", "1200", "2024MFR007", "www.mpumalangafridges.co.za" },
                    { 8, "258 Bushveld Street", "Limpopo Cooling Experts", "Technical Services", "Polokwane", "South Africa", new DateTime(2024, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(185), "support@limpopocooling.co.za", "Cooling Systems", null, null, "0156667890", "0700", "2023LCE008", "www.limpopocooling.co.za" },
                    { 9, "369 Diamond Road", "Northern Cape Appliances", "Appliance Sales", "Kimberley", "South Africa", new DateTime(2025, 1, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(187), "sales@ncappliances.co.za", "Retail", null, null, "0537771234", "8301", "2024NCA009", "www.ncappliances.co.za" },
                    { 10, "741 Platinum Avenue", "North West Cooling Solutions", "Cooling Services", "Rustenburg", "South Africa", new DateTime(2024, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(190), "info@nwcooling.co.za", "HVAC Services", null, null, "0148884567", "2999", "2023NWC010", "www.nwcooling.co.za" },
                    { 11, "852 Coastal Highway", "KZN Appliance Rentals", "Rental Services", "Pietermaritzburg", "South Africa", new DateTime(2025, 8, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(192), "rentals@kznappliances.co.za", "Appliance Rental", null, null, "0338885678", "3201", "2024KZNR011", "www.kznappliances.co.za" },
                    { 12, "963 Metro Road", "Gauteng Cooling Systems", "Technical Services", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(195), "service@gautengcooling.co.za", "Cooling Systems", null, null, "0119992345", "2001", "2023GCS012", "www.gautengcooling.co.za" }
                });

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Description", "ImageUrl", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 250, "Energy efficient fridge with frost-free technology", "/Images/Fridges/fridge1.jpg", "Durban", "RT28A", 450.0, "Double Door" },
                    { 2, "Available", "LG", 260, "Smart inverter compressor for energy savings", "/Images/Fridges/fridge2.jpg", "Johannesburg", "GL-T292", 480.0, "Top Freezer" },
                    { 3, "Rented", "Hisense", 320, "Spacious design with humidity control", "/Images/Fridges/fridge3.jpg", "Cape Town", "H370BI", 520.0, "Bottom Freezer" },
                    { 4, "Available", "Defy", 350, "A+ energy rated with multi-airflow system", "/Images/Fridges/fridge4.jpg", "Pretoria", "DAC621", 550.0, "Combi Fridge" },
                    { 5, "Available", "Whirlpool", 200, "Compact and efficient single door fridge", "/Images/Fridges/fridge5.jpg", "Durban", "WDE205", 400.0, "Single Door" },
                    { 6, "Rented", "Bosch", 350, "No frost cooling with LED lighting", "/Images/Fridges/fridge6.jpg", "Port Elizabeth", "KDN42", 600.0, "Frost Free" },
                    { 7, "Available", "Smeg", 270, "Stylish retro fridge with adjustable shelves", "/Images/Fridges/fridge7.jpg", "Johannesburg", "FAB28", 650.0, "Retro Style" },
                    { 8, "Available", "Kelvinator", 265, "Affordable fridge with efficient cooling", "/Images/Fridges/fridge8.jpg", "Cape Town", "KRF265", 430.0, "Top Mount" },
                    { 9, "Rented", "Siemens", 360, "No frost with multi-airflow system", "/Images/Fridges/fridge9.jpg", "Pretoria", "KG36N", 590.0, "Bottom Freezer" },
                    { 10, "Available", "Haier", 290, "Toughened glass shelves and energy efficient", "/Images/Fridges/fridge10.jpg", "Durban", "HRF290", 470.0, "Double Door" },
                    { 11, "Available", "Hisense", 310, "Low noise and efficient compressor", "/Images/Fridges/fridge11.jpg", "Bloemfontein", "H310BI", 500.0, "Top Freezer" },
                    { 12, "Rented", "Defy", 420, "LED display and water dispenser", "/Images/Fridges/fridge12.jpg", "Cape Town", "DAC700", 700.0, "Side by Side" },
                    { 13, "Available", "LG", 282, "Smart cooling with WiFi control", "/Images/Fridges/fridge13.jpg", "Durban", "GL-Q282", 530.0, "Smart Inverter" },
                    { 14, "Rented", "Samsung", 340, "Twin cooling system for freshness", "/Images/Fridges/fridge14.jpg", "Pretoria", "RT34A", 560.0, "Top Freezer" },
                    { 15, "Available", "Whirlpool", 500, "High capacity with 6th sense technology", "/Images/Fridges/fridge15.jpg", "Johannesburg", "WDE520", 750.0, "Double Door" },
                    { 16, "Available", "Samsung", 380, "Flexible storage with external water dispenser", "/Images/Fridges/fridge16.jpg", "Cape Town", "RT38A", 680.0, "French Door" },
                    { 17, "Available", "LG", 422, "Door cooling+ technology for even cooling", "/Images/Fridges/fridge17.jpg", "Durban", "GL-B422", 620.0, "Bottom Freezer" },
                    { 18, "Rented", "Hisense", 450, "Premium cooling with smart features", "/Images/Fridges/fridge18.jpg", "Johannesburg", "H450BI", 720.0, "Side by Side" },
                    { 19, "Available", "Defy", 520, "Large capacity with eco-friendly refrigerant", "/Images/Fridges/fridge19.jpg", "Pretoria", "DAC800", 580.0, "Double Door" },
                    { 20, "Available", "Whirlpool", 350, "6th sense technology with adaptive cooling", "/Images/Fridges/fridge20.jpg", "Port Elizabeth", "WDE350", 520.0, "Top Freezer" },
                    { 21, "Rented", "Bosch", 540, "VitaFresh technology for longer freshness", "/Images/Fridges/fridge21.jpg", "Cape Town", "KDN56", 780.0, "Frost Free" },
                    { 22, "Available", "Smeg", 320, "50s style retro design with modern features", "/Images/Fridges/fridge22.jpg", "Johannesburg", "FAB32", 850.0, "Retro Style" },
                    { 23, "Available", "Kelvinator", 320, "Energy efficient with glass shelves", "/Images/Fridges/fridge23.jpg", "Durban", "KRF320", 460.0, "Top Mount" },
                    { 24, "Rented", "Siemens", 410, "NoFrost technology with hyperFresh", "/Images/Fridges/fridge24.jpg", "Pretoria", "KG49", 690.0, "Bottom Freezer" },
                    { 25, "Available", "Haier", 520, "Triple cooling system with humidity control", "/Images/Fridges/fridge25.jpg", "Cape Town", "HRF520", 720.0, "French Door" },
                    { 26, "Available", "Hisense", 280, "Compact design perfect for small spaces", "/Images/Fridges/fridge26.jpg", "Bloemfontein", "H280BI", 380.0, "Single Door" },
                    { 27, "Rented", "Defy", 300, "Economical and reliable performance", "/Images/Fridges/fridge27.jpg", "Durban", "DAC300", 420.0, "Top Freezer" },
                    { 28, "Available", "LG", 282, "Smart inverter with door cooling", "/Images/Fridges/fridge28.jpg", "Johannesburg", "GL-S282", 490.0, "Single Door" },
                    { 29, "Available", "Samsung", 220, "Compact fridge with digital inverter", "/Images/Fridges/fridge29.jpg", "Pretoria", "RT22A", 410.0, "Single Door" },
                    { 30, "Rented", "Whirlpool", 280, "6th sense technology in compact size", "/Images/Fridges/fridge30.jpg", "Cape Town", "WDE280", 440.0, "Top Freezer" },
                    { 31, "Available", "Bosch", 320, "VitaFresh pro for optimal food storage", "/Images/Fridges/fridge31.jpg", "Durban", "KDN32", 580.0, "Frost Free" },
                    { 32, "Available", "Smeg", 500, "Large capacity retro fridge", "/Images/Fridges/fridge32.jpg", "Johannesburg", "FAB50", 920.0, "Retro Style" },
                    { 33, "Rented", "Kelvinator", 400, "Spacious design with efficient cooling", "/Images/Fridges/fridge33.jpg", "Pretoria", "KRF400", 540.0, "Bottom Freezer" },
                    { 34, "Available", "Siemens", 385, "hyperFresh plus with NoFrost", "/Images/Fridges/fridge34.jpg", "Cape Town", "KG42", 670.0, "Bottom Freezer" },
                    { 35, "Available", "Haier", 380, "Triple cooling with HCS technology", "/Images/Fridges/fridge35.jpg", "Durban", "HRF380", 590.0, "Double Door" },
                    { 36, "Rented", "Hisense", 520, "Smart cooling with WiFi connectivity", "/Images/Fridges/fridge36.jpg", "Johannesburg", "H520BI", 780.0, "French Door" },
                    { 37, "Available", "Defy", 450, "Water and ice dispenser with LED display", "/Images/Fridges/fridge37.jpg", "Pretoria", "DAC450", 650.0, "Side by Side" },
                    { 38, "Available", "LG", 422, "InstaView door-in-door technology", "/Images/Fridges/fridge38.jpg", "Cape Town", "GL-F422", 820.0, "French Door" },
                    { 39, "Rented", "Samsung", 450, "Twin cooling plus with metal cooling", "/Images/Fridges/fridge39.jpg", "Durban", "RT45A", 760.0, "French Door" },
                    { 40, "Available", "Whirlpool", 600, "Large capacity with 6th sense dual cool", "/Images/Fridges/fridge40.jpg", "Johannesburg", "WDE600", 880.0, "French Door" },
                    { 41, "Available", "Bosch", 635, "VitaFresh pro with dual compressors", "/Images/Fridges/fridge41.jpg", "Pretoria", "KDN86", 950.0, "Side by Side" },
                    { 42, "Rented", "Smeg", 360, "Classic design with modern features", "/Images/Fridges/fridge42.jpg", "Cape Town", "FAB36", 780.0, "Retro Style" },
                    { 43, "Available", "Kelvinator", 280, "Compact and energy efficient", "/Images/Fridges/fridge43.jpg", "Durban", "KRF280", 420.0, "Top Mount" },
                    { 44, "Available", "Siemens", 530, "hyperFresh with perfect results", "/Images/Fridges/fridge44.jpg", "Johannesburg", "KG56", 740.0, "Bottom Freezer" },
                    { 45, "Rented", "Haier", 260, "Compact design with HCS technology", "/Images/Fridges/fridge45.jpg", "Pretoria", "HRF260", 380.0, "Single Door" },
                    { 46, "Available", "Hisense", 380, "Smart features with efficient cooling", "/Images/Fridges/fridge46.jpg", "Cape Town", "H380BI", 550.0, "Bottom Freezer" },
                    { 47, "Available", "Defy", 550, "Premium cooling with advanced features", "/Images/Fridges/fridge47.jpg", "Durban", "DAC550", 720.0, "French Door" },
                    { 48, "Rented", "LG", 422, "Door cooling+ with linear cooling", "/Images/Fridges/fridge48.jpg", "Johannesburg", "GL-M422", 680.0, "Bottom Freezer" }
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
                    { "1", "2" },
                    { "2", "21" },
                    { "2", "22" },
                    { "2", "23" },
                    { "2", "24" },
                    { "3", "25" },
                    { "4", "26" },
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
                    { 2, "2", "EMP002" },
                    { 3, "11", "EMP003" },
                    { 4, "12", "EMP004" },
                    { 5, "13", "EMP005" },
                    { 6, "14", "EMP006" },
                    { 7, "15", "EMP007" },
                    { 8, "16", "EMP008" },
                    { 9, "17", "EMP009" },
                    { 10, "18", "EMP010" },
                    { 11, "25", "EMP011" },
                    { 12, "26", "EMP012" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeInStocks",
                columns: new[] { "FridgeInStockId", "Condition", "FridgeId", "FridgeNo", "IsAvailable", "LastMaintenanceDate", "Location", "Quantity", "RequestDetailsRequestDetailId" },
                values: new object[,]
                {
                    { 1, "Excellent", 1, "FRG-001-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7143), "Durban Warehouse", 1, null },
                    { 2, "Good", 1, "FRG-001-002", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7237), "Cape Town Storage", 1, null },
                    { 3, "Very Good", 1, "FRG-001-003", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7269), "Durban Warehouse", 1, null },
                    { 4, "Excellent", 1, "FRG-001-004", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7278), "Johannesburg Main", 1, null },
                    { 5, "Good", 1, "FRG-001-005", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7282), "Port Elizabeth Depot", 1, null },
                    { 6, "Good", 1, "FRG-001-006", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7289), "Pretoria Facility", 1, null },
                    { 7, "Good", 1, "FRG-001-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7293), "Cape Town Storage", 1, null },
                    { 8, "Good", 1, "FRG-001-008", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7298), "Johannesburg Main", 1, null },
                    { 9, "Good", 1, "FRG-001-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7302), "Johannesburg Main", 1, null },
                    { 10, "Excellent", 1, "FRG-001-010", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7308), "Johannesburg Main", 1, null },
                    { 11, "Good", 2, "FRG-002-001", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7313), "Johannesburg Main", 1, null },
                    { 12, "Very Good", 2, "FRG-002-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7317), "Johannesburg Main", 1, null },
                    { 13, "Good", 2, "FRG-002-003", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7322), "Durban Warehouse", 1, null },
                    { 14, "Good", 2, "FRG-002-004", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7326), "Durban Warehouse", 1, null },
                    { 15, "Very Good", 2, "FRG-002-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7384), "Johannesburg Main", 1, null },
                    { 16, "Very Good", 2, "FRG-002-006", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7398), "Johannesburg Main", 1, null },
                    { 17, "Very Good", 2, "FRG-002-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7403), "Cape Town Storage", 1, null },
                    { 18, "Good", 2, "FRG-002-008", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7408), "Pretoria Facility", 1, null },
                    { 19, "Excellent", 2, "FRG-002-009", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7413), "Durban Warehouse", 1, null },
                    { 20, "Excellent", 2, "FRG-002-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7417), "Pretoria Facility", 1, null },
                    { 21, "Excellent", 3, "FRG-003-001", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7422), "Johannesburg Main", 1, null },
                    { 22, "Excellent", 3, "FRG-003-002", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7426), "Port Elizabeth Depot", 1, null },
                    { 23, "Excellent", 3, "FRG-003-003", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7430), "Pretoria Facility", 1, null },
                    { 24, "Excellent", 3, "FRG-003-004", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7434), "Port Elizabeth Depot", 1, null },
                    { 25, "Good", 3, "FRG-003-005", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7439), "Pretoria Facility", 1, null },
                    { 26, "Very Good", 3, "FRG-003-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7443), "Port Elizabeth Depot", 1, null },
                    { 27, "Good", 3, "FRG-003-007", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7447), "Durban Warehouse", 1, null },
                    { 28, "Excellent", 3, "FRG-003-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7452), "Port Elizabeth Depot", 1, null },
                    { 29, "Excellent", 3, "FRG-003-009", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7456), "Cape Town Storage", 1, null },
                    { 30, "Excellent", 3, "FRG-003-010", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7483), "Cape Town Storage", 1, null },
                    { 31, "Very Good", 4, "FRG-004-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7508), "Johannesburg Main", 1, null },
                    { 32, "Excellent", 4, "FRG-004-002", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7513), "Johannesburg Main", 1, null },
                    { 33, "Good", 4, "FRG-004-003", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7517), "Durban Warehouse", 1, null },
                    { 34, "Good", 4, "FRG-004-004", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7522), "Durban Warehouse", 1, null },
                    { 35, "Very Good", 4, "FRG-004-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7526), "Johannesburg Main", 1, null },
                    { 36, "Excellent", 4, "FRG-004-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7530), "Pretoria Facility", 1, null },
                    { 37, "Excellent", 4, "FRG-004-007", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7535), "Johannesburg Main", 1, null },
                    { 38, "Good", 4, "FRG-004-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7539), "Durban Warehouse", 1, null },
                    { 39, "Excellent", 4, "FRG-004-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7544), "Cape Town Storage", 1, null },
                    { 40, "Good", 4, "FRG-004-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7548), "Cape Town Storage", 1, null },
                    { 41, "Good", 5, "FRG-005-001", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7552), "Port Elizabeth Depot", 1, null },
                    { 42, "Very Good", 5, "FRG-005-002", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7556), "Cape Town Storage", 1, null },
                    { 43, "Excellent", 5, "FRG-005-003", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7561), "Pretoria Facility", 1, null },
                    { 44, "Good", 5, "FRG-005-004", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7565), "Cape Town Storage", 1, null },
                    { 45, "Very Good", 5, "FRG-005-005", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7569), "Port Elizabeth Depot", 1, null },
                    { 46, "Good", 5, "FRG-005-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7573), "Pretoria Facility", 1, null },
                    { 47, "Good", 5, "FRG-005-007", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7578), "Durban Warehouse", 1, null },
                    { 48, "Good", 5, "FRG-005-008", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7582), "Port Elizabeth Depot", 1, null },
                    { 49, "Very Good", 5, "FRG-005-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7586), "Durban Warehouse", 1, null },
                    { 50, "Excellent", 5, "FRG-005-010", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7591), "Johannesburg Main", 1, null },
                    { 51, "Good", 6, "FRG-006-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7608), "Cape Town Storage", 1, null },
                    { 52, "Excellent", 6, "FRG-006-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7612), "Port Elizabeth Depot", 1, null },
                    { 53, "Good", 6, "FRG-006-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7616), "Cape Town Storage", 1, null },
                    { 54, "Excellent", 6, "FRG-006-004", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7620), "Pretoria Facility", 1, null },
                    { 55, "Excellent", 6, "FRG-006-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7625), "Durban Warehouse", 1, null },
                    { 56, "Good", 6, "FRG-006-006", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7629), "Port Elizabeth Depot", 1, null },
                    { 57, "Excellent", 6, "FRG-006-007", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7633), "Pretoria Facility", 1, null },
                    { 58, "Excellent", 6, "FRG-006-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7637), "Cape Town Storage", 1, null },
                    { 59, "Good", 6, "FRG-006-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7642), "Johannesburg Main", 1, null },
                    { 60, "Good", 6, "FRG-006-010", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7646), "Durban Warehouse", 1, null },
                    { 61, "Good", 7, "FRG-007-001", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7651), "Durban Warehouse", 1, null },
                    { 62, "Excellent", 7, "FRG-007-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7655), "Pretoria Facility", 1, null },
                    { 63, "Excellent", 7, "FRG-007-003", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7659), "Johannesburg Main", 1, null },
                    { 64, "Excellent", 7, "FRG-007-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7663), "Durban Warehouse", 1, null },
                    { 65, "Excellent", 7, "FRG-007-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7668), "Pretoria Facility", 1, null },
                    { 66, "Excellent", 7, "FRG-007-006", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7673), "Durban Warehouse", 1, null },
                    { 67, "Excellent", 7, "FRG-007-007", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7677), "Pretoria Facility", 1, null },
                    { 68, "Excellent", 7, "FRG-007-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7682), "Johannesburg Main", 1, null },
                    { 69, "Excellent", 7, "FRG-007-009", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7686), "Port Elizabeth Depot", 1, null },
                    { 70, "Excellent", 7, "FRG-007-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7690), "Cape Town Storage", 1, null },
                    { 71, "Very Good", 8, "FRG-008-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7695), "Cape Town Storage", 1, null },
                    { 72, "Very Good", 8, "FRG-008-002", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7699), "Pretoria Facility", 1, null },
                    { 73, "Good", 8, "FRG-008-003", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7703), "Cape Town Storage", 1, null },
                    { 74, "Good", 8, "FRG-008-004", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7707), "Johannesburg Main", 1, null },
                    { 75, "Good", 8, "FRG-008-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7712), "Cape Town Storage", 1, null },
                    { 76, "Good", 8, "FRG-008-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7716), "Pretoria Facility", 1, null },
                    { 77, "Excellent", 8, "FRG-008-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7720), "Pretoria Facility", 1, null },
                    { 78, "Good", 8, "FRG-008-008", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7725), "Port Elizabeth Depot", 1, null },
                    { 79, "Very Good", 8, "FRG-008-009", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7729), "Port Elizabeth Depot", 1, null },
                    { 80, "Good", 8, "FRG-008-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7734), "Johannesburg Main", 1, null },
                    { 81, "Good", 9, "FRG-009-001", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7738), "Durban Warehouse", 1, null },
                    { 82, "Excellent", 9, "FRG-009-002", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7742), "Port Elizabeth Depot", 1, null },
                    { 83, "Very Good", 9, "FRG-009-003", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7747), "Cape Town Storage", 1, null },
                    { 84, "Excellent", 9, "FRG-009-004", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7751), "Durban Warehouse", 1, null },
                    { 85, "Excellent", 9, "FRG-009-005", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7755), "Durban Warehouse", 1, null },
                    { 86, "Excellent", 9, "FRG-009-006", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7760), "Port Elizabeth Depot", 1, null },
                    { 87, "Very Good", 9, "FRG-009-007", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7765), "Durban Warehouse", 1, null },
                    { 88, "Excellent", 9, "FRG-009-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7769), "Durban Warehouse", 1, null },
                    { 89, "Good", 9, "FRG-009-009", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7773), "Cape Town Storage", 1, null },
                    { 90, "Good", 9, "FRG-009-010", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7777), "Johannesburg Main", 1, null },
                    { 91, "Good", 10, "FRG-010-001", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7782), "Durban Warehouse", 1, null },
                    { 92, "Excellent", 10, "FRG-010-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7787), "Johannesburg Main", 1, null },
                    { 93, "Very Good", 10, "FRG-010-003", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7791), "Johannesburg Main", 1, null },
                    { 94, "Excellent", 10, "FRG-010-004", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7795), "Port Elizabeth Depot", 1, null },
                    { 95, "Very Good", 10, "FRG-010-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7799), "Johannesburg Main", 1, null },
                    { 96, "Good", 10, "FRG-010-006", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7804), "Cape Town Storage", 1, null },
                    { 97, "Excellent", 10, "FRG-010-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7808), "Cape Town Storage", 1, null },
                    { 98, "Good", 10, "FRG-010-008", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7812), "Pretoria Facility", 1, null },
                    { 99, "Excellent", 10, "FRG-010-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7816), "Johannesburg Main", 1, null },
                    { 100, "Good", 10, "FRG-010-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7821), "Port Elizabeth Depot", 1, null },
                    { 101, "Good", 11, "FRG-011-001", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7825), "Cape Town Storage", 1, null },
                    { 102, "Good", 11, "FRG-011-002", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7830), "Johannesburg Main", 1, null },
                    { 103, "Excellent", 11, "FRG-011-003", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7834), "Johannesburg Main", 1, null },
                    { 104, "Very Good", 11, "FRG-011-004", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7838), "Durban Warehouse", 1, null },
                    { 105, "Very Good", 11, "FRG-011-005", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7843), "Durban Warehouse", 1, null },
                    { 106, "Excellent", 11, "FRG-011-006", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7847), "Pretoria Facility", 1, null },
                    { 107, "Excellent", 11, "FRG-011-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7851), "Pretoria Facility", 1, null },
                    { 108, "Very Good", 11, "FRG-011-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7855), "Johannesburg Main", 1, null },
                    { 109, "Very Good", 11, "FRG-011-009", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7860), "Port Elizabeth Depot", 1, null },
                    { 110, "Good", 11, "FRG-011-010", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7870), "Johannesburg Main", 1, null },
                    { 111, "Excellent", 12, "FRG-012-001", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7875), "Johannesburg Main", 1, null },
                    { 112, "Very Good", 12, "FRG-012-002", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7880), "Durban Warehouse", 1, null },
                    { 113, "Good", 12, "FRG-012-003", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7884), "Johannesburg Main", 1, null },
                    { 114, "Good", 12, "FRG-012-004", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7888), "Johannesburg Main", 1, null },
                    { 115, "Excellent", 12, "FRG-012-005", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7892), "Cape Town Storage", 1, null },
                    { 116, "Good", 12, "FRG-012-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7897), "Port Elizabeth Depot", 1, null },
                    { 117, "Good", 12, "FRG-012-007", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7901), "Cape Town Storage", 1, null },
                    { 118, "Good", 12, "FRG-012-008", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7906), "Cape Town Storage", 1, null },
                    { 119, "Good", 12, "FRG-012-009", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7910), "Pretoria Facility", 1, null },
                    { 120, "Excellent", 12, "FRG-012-010", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7914), "Port Elizabeth Depot", 1, null },
                    { 121, "Good", 13, "FRG-013-001", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7919), "Cape Town Storage", 1, null },
                    { 122, "Excellent", 13, "FRG-013-002", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7923), "Durban Warehouse", 1, null },
                    { 123, "Good", 13, "FRG-013-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7927), "Port Elizabeth Depot", 1, null },
                    { 124, "Good", 13, "FRG-013-004", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7932), "Johannesburg Main", 1, null },
                    { 125, "Very Good", 13, "FRG-013-005", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7936), "Pretoria Facility", 1, null },
                    { 126, "Excellent", 13, "FRG-013-006", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7940), "Port Elizabeth Depot", 1, null },
                    { 127, "Very Good", 13, "FRG-013-007", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7944), "Johannesburg Main", 1, null },
                    { 128, "Very Good", 13, "FRG-013-008", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7948), "Johannesburg Main", 1, null },
                    { 129, "Good", 13, "FRG-013-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7953), "Durban Warehouse", 1, null },
                    { 130, "Very Good", 13, "FRG-013-010", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7958), "Pretoria Facility", 1, null },
                    { 131, "Good", 14, "FRG-014-001", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7962), "Johannesburg Main", 1, null },
                    { 132, "Very Good", 14, "FRG-014-002", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7967), "Pretoria Facility", 1, null },
                    { 133, "Good", 14, "FRG-014-003", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7971), "Port Elizabeth Depot", 1, null },
                    { 134, "Good", 14, "FRG-014-004", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7975), "Pretoria Facility", 1, null },
                    { 135, "Excellent", 14, "FRG-014-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7979), "Durban Warehouse", 1, null },
                    { 136, "Good", 14, "FRG-014-006", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7984), "Cape Town Storage", 1, null },
                    { 137, "Very Good", 14, "FRG-014-007", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7988), "Johannesburg Main", 1, null },
                    { 138, "Good", 14, "FRG-014-008", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7992), "Port Elizabeth Depot", 1, null },
                    { 139, "Good", 14, "FRG-014-009", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(7997), "Johannesburg Main", 1, null },
                    { 140, "Excellent", 14, "FRG-014-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8001), "Durban Warehouse", 1, null },
                    { 141, "Excellent", 15, "FRG-015-001", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8006), "Durban Warehouse", 1, null },
                    { 142, "Good", 15, "FRG-015-002", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8010), "Johannesburg Main", 1, null },
                    { 143, "Good", 15, "FRG-015-003", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8014), "Johannesburg Main", 1, null },
                    { 144, "Good", 15, "FRG-015-004", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8019), "Durban Warehouse", 1, null },
                    { 145, "Excellent", 15, "FRG-015-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8023), "Pretoria Facility", 1, null },
                    { 146, "Good", 15, "FRG-015-006", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8027), "Port Elizabeth Depot", 1, null },
                    { 147, "Good", 15, "FRG-015-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8032), "Pretoria Facility", 1, null },
                    { 148, "Good", 15, "FRG-015-008", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8036), "Durban Warehouse", 1, null },
                    { 149, "Very Good", 15, "FRG-015-009", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8040), "Cape Town Storage", 1, null },
                    { 150, "Excellent", 15, "FRG-015-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8045), "Durban Warehouse", 1, null },
                    { 151, "Good", 16, "FRG-016-001", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8049), "Cape Town Storage", 1, null },
                    { 152, "Very Good", 16, "FRG-016-002", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8054), "Durban Warehouse", 1, null },
                    { 153, "Good", 16, "FRG-016-003", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8058), "Cape Town Storage", 1, null },
                    { 154, "Excellent", 16, "FRG-016-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8063), "Johannesburg Main", 1, null },
                    { 155, "Good", 16, "FRG-016-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8067), "Durban Warehouse", 1, null },
                    { 156, "Excellent", 16, "FRG-016-006", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8071), "Pretoria Facility", 1, null },
                    { 157, "Excellent", 16, "FRG-016-007", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8075), "Port Elizabeth Depot", 1, null },
                    { 158, "Good", 16, "FRG-016-008", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8079), "Johannesburg Main", 1, null },
                    { 159, "Very Good", 16, "FRG-016-009", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8084), "Port Elizabeth Depot", 1, null },
                    { 160, "Good", 16, "FRG-016-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8088), "Cape Town Storage", 1, null },
                    { 161, "Good", 17, "FRG-017-001", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8100), "Port Elizabeth Depot", 1, null },
                    { 162, "Good", 17, "FRG-017-002", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8105), "Durban Warehouse", 1, null },
                    { 163, "Good", 17, "FRG-017-003", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8117), "Pretoria Facility", 1, null },
                    { 164, "Excellent", 17, "FRG-017-004", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8121), "Pretoria Facility", 1, null },
                    { 165, "Good", 17, "FRG-017-005", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8126), "Cape Town Storage", 1, null },
                    { 166, "Good", 17, "FRG-017-006", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8130), "Cape Town Storage", 1, null },
                    { 167, "Good", 17, "FRG-017-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8134), "Pretoria Facility", 1, null },
                    { 168, "Very Good", 17, "FRG-017-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8138), "Port Elizabeth Depot", 1, null },
                    { 169, "Good", 17, "FRG-017-009", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8142), "Pretoria Facility", 1, null },
                    { 170, "Excellent", 17, "FRG-017-010", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8147), "Port Elizabeth Depot", 1, null },
                    { 171, "Excellent", 18, "FRG-018-001", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8151), "Pretoria Facility", 1, null },
                    { 172, "Good", 18, "FRG-018-002", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8156), "Johannesburg Main", 1, null },
                    { 173, "Very Good", 18, "FRG-018-003", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8160), "Johannesburg Main", 1, null },
                    { 174, "Very Good", 18, "FRG-018-004", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8164), "Johannesburg Main", 1, null },
                    { 175, "Excellent", 18, "FRG-018-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8168), "Durban Warehouse", 1, null },
                    { 176, "Good", 18, "FRG-018-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8172), "Cape Town Storage", 1, null },
                    { 177, "Good", 18, "FRG-018-007", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8177), "Durban Warehouse", 1, null },
                    { 178, "Excellent", 18, "FRG-018-008", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8189), "Pretoria Facility", 1, null },
                    { 179, "Good", 18, "FRG-018-009", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8200), "Durban Warehouse", 1, null },
                    { 180, "Good", 18, "FRG-018-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8205), "Durban Warehouse", 1, null },
                    { 181, "Excellent", 19, "FRG-019-001", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8209), "Durban Warehouse", 1, null },
                    { 182, "Good", 19, "FRG-019-002", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8213), "Johannesburg Main", 1, null },
                    { 183, "Excellent", 19, "FRG-019-003", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8218), "Pretoria Facility", 1, null },
                    { 184, "Good", 19, "FRG-019-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8222), "Cape Town Storage", 1, null },
                    { 185, "Good", 19, "FRG-019-005", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8226), "Johannesburg Main", 1, null },
                    { 186, "Very Good", 19, "FRG-019-006", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8231), "Durban Warehouse", 1, null },
                    { 187, "Good", 19, "FRG-019-007", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8235), "Port Elizabeth Depot", 1, null },
                    { 188, "Very Good", 19, "FRG-019-008", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8239), "Port Elizabeth Depot", 1, null },
                    { 189, "Excellent", 19, "FRG-019-009", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8251), "Pretoria Facility", 1, null },
                    { 190, "Very Good", 19, "FRG-019-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8256), "Durban Warehouse", 1, null },
                    { 191, "Excellent", 20, "FRG-020-001", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8260), "Durban Warehouse", 1, null },
                    { 192, "Excellent", 20, "FRG-020-002", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8265), "Durban Warehouse", 1, null },
                    { 193, "Good", 20, "FRG-020-003", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8269), "Durban Warehouse", 1, null },
                    { 194, "Excellent", 20, "FRG-020-004", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8273), "Durban Warehouse", 1, null },
                    { 195, "Good", 20, "FRG-020-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8278), "Pretoria Facility", 1, null },
                    { 196, "Very Good", 20, "FRG-020-006", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8282), "Pretoria Facility", 1, null },
                    { 197, "Good", 20, "FRG-020-007", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8286), "Johannesburg Main", 1, null },
                    { 198, "Very Good", 20, "FRG-020-008", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8291), "Johannesburg Main", 1, null },
                    { 199, "Good", 20, "FRG-020-009", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8302), "Durban Warehouse", 1, null },
                    { 200, "Good", 20, "FRG-020-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8306), "Pretoria Facility", 1, null },
                    { 201, "Excellent", 21, "FRG-021-001", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8311), "Cape Town Storage", 1, null },
                    { 202, "Excellent", 21, "FRG-021-002", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8315), "Port Elizabeth Depot", 1, null },
                    { 203, "Excellent", 21, "FRG-021-003", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8319), "Johannesburg Main", 1, null },
                    { 204, "Good", 21, "FRG-021-004", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8324), "Port Elizabeth Depot", 1, null },
                    { 205, "Good", 21, "FRG-021-005", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8328), "Johannesburg Main", 1, null },
                    { 206, "Excellent", 21, "FRG-021-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8333), "Durban Warehouse", 1, null },
                    { 207, "Excellent", 21, "FRG-021-007", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8345), "Port Elizabeth Depot", 1, null },
                    { 208, "Excellent", 21, "FRG-021-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8349), "Port Elizabeth Depot", 1, null },
                    { 209, "Very Good", 21, "FRG-021-009", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8354), "Cape Town Storage", 1, null },
                    { 210, "Excellent", 21, "FRG-021-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8358), "Pretoria Facility", 1, null },
                    { 211, "Very Good", 22, "FRG-022-001", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8362), "Pretoria Facility", 1, null },
                    { 212, "Good", 22, "FRG-022-002", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8366), "Durban Warehouse", 1, null },
                    { 213, "Very Good", 22, "FRG-022-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8371), "Cape Town Storage", 1, null },
                    { 214, "Good", 22, "FRG-022-004", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8375), "Port Elizabeth Depot", 1, null },
                    { 215, "Good", 22, "FRG-022-005", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8379), "Cape Town Storage", 1, null },
                    { 216, "Excellent", 22, "FRG-022-006", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8384), "Pretoria Facility", 1, null },
                    { 217, "Excellent", 22, "FRG-022-007", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8396), "Johannesburg Main", 1, null },
                    { 218, "Very Good", 22, "FRG-022-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8400), "Cape Town Storage", 1, null },
                    { 219, "Very Good", 22, "FRG-022-009", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8404), "Johannesburg Main", 1, null },
                    { 220, "Excellent", 22, "FRG-022-010", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8409), "Johannesburg Main", 1, null },
                    { 221, "Excellent", 23, "FRG-023-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8413), "Pretoria Facility", 1, null },
                    { 222, "Good", 23, "FRG-023-002", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8417), "Port Elizabeth Depot", 1, null },
                    { 223, "Good", 23, "FRG-023-003", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8421), "Durban Warehouse", 1, null },
                    { 224, "Very Good", 23, "FRG-023-004", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8426), "Durban Warehouse", 1, null },
                    { 225, "Good", 23, "FRG-023-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8430), "Cape Town Storage", 1, null },
                    { 226, "Good", 23, "FRG-023-006", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8442), "Durban Warehouse", 1, null },
                    { 227, "Excellent", 23, "FRG-023-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8446), "Cape Town Storage", 1, null },
                    { 228, "Excellent", 23, "FRG-023-008", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8451), "Port Elizabeth Depot", 1, null },
                    { 229, "Good", 23, "FRG-023-009", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8455), "Durban Warehouse", 1, null },
                    { 230, "Excellent", 23, "FRG-023-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8465), "Cape Town Storage", 1, null },
                    { 231, "Very Good", 24, "FRG-024-001", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8470), "Johannesburg Main", 1, null },
                    { 232, "Very Good", 24, "FRG-024-002", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8475), "Cape Town Storage", 1, null },
                    { 233, "Excellent", 24, "FRG-024-003", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8487), "Port Elizabeth Depot", 1, null },
                    { 234, "Excellent", 24, "FRG-024-004", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8491), "Pretoria Facility", 1, null },
                    { 235, "Very Good", 24, "FRG-024-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8496), "Cape Town Storage", 1, null },
                    { 236, "Good", 24, "FRG-024-006", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8500), "Pretoria Facility", 1, null },
                    { 237, "Good", 24, "FRG-024-007", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8504), "Durban Warehouse", 1, null },
                    { 238, "Good", 24, "FRG-024-008", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8509), "Johannesburg Main", 1, null },
                    { 239, "Good", 24, "FRG-024-009", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8513), "Durban Warehouse", 1, null },
                    { 240, "Good", 24, "FRG-024-010", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8517), "Pretoria Facility", 1, null },
                    { 241, "Excellent", 25, "FRG-025-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8521), "Cape Town Storage", 1, null },
                    { 242, "Excellent", 25, "FRG-025-002", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8526), "Cape Town Storage", 1, null },
                    { 243, "Excellent", 25, "FRG-025-003", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8537), "Pretoria Facility", 1, null },
                    { 244, "Excellent", 25, "FRG-025-004", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8542), "Cape Town Storage", 1, null },
                    { 245, "Good", 25, "FRG-025-005", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8546), "Cape Town Storage", 1, null },
                    { 246, "Excellent", 25, "FRG-025-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8550), "Cape Town Storage", 1, null },
                    { 247, "Good", 25, "FRG-025-007", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8554), "Pretoria Facility", 1, null },
                    { 248, "Excellent", 25, "FRG-025-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8558), "Port Elizabeth Depot", 1, null },
                    { 249, "Excellent", 25, "FRG-025-009", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8563), "Durban Warehouse", 1, null },
                    { 250, "Excellent", 25, "FRG-025-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8567), "Port Elizabeth Depot", 1, null },
                    { 251, "Excellent", 26, "FRG-026-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8572), "Port Elizabeth Depot", 1, null },
                    { 252, "Good", 26, "FRG-026-002", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8586), "Pretoria Facility", 1, null },
                    { 253, "Excellent", 26, "FRG-026-003", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8590), "Johannesburg Main", 1, null },
                    { 254, "Excellent", 26, "FRG-026-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8594), "Cape Town Storage", 1, null },
                    { 255, "Excellent", 26, "FRG-026-005", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8598), "Cape Town Storage", 1, null },
                    { 256, "Very Good", 26, "FRG-026-006", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8603), "Pretoria Facility", 1, null },
                    { 257, "Excellent", 26, "FRG-026-007", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8607), "Cape Town Storage", 1, null },
                    { 258, "Good", 26, "FRG-026-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8613), "Pretoria Facility", 1, null },
                    { 259, "Very Good", 26, "FRG-026-009", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8618), "Cape Town Storage", 1, null },
                    { 260, "Good", 26, "FRG-026-010", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8622), "Pretoria Facility", 1, null },
                    { 261, "Good", 27, "FRG-027-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8626), "Johannesburg Main", 1, null },
                    { 262, "Excellent", 27, "FRG-027-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8631), "Port Elizabeth Depot", 1, null },
                    { 263, "Excellent", 27, "FRG-027-003", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8635), "Pretoria Facility", 1, null },
                    { 264, "Excellent", 27, "FRG-027-004", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8645), "Johannesburg Main", 1, null },
                    { 265, "Very Good", 27, "FRG-027-005", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8649), "Durban Warehouse", 1, null },
                    { 266, "Excellent", 27, "FRG-027-006", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8661), "Johannesburg Main", 1, null },
                    { 267, "Very Good", 27, "FRG-027-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8665), "Port Elizabeth Depot", 1, null },
                    { 268, "Good", 27, "FRG-027-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8669), "Pretoria Facility", 1, null },
                    { 269, "Very Good", 27, "FRG-027-009", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8673), "Durban Warehouse", 1, null },
                    { 270, "Good", 27, "FRG-027-010", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8678), "Johannesburg Main", 1, null },
                    { 271, "Excellent", 28, "FRG-028-001", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8682), "Cape Town Storage", 1, null },
                    { 272, "Excellent", 28, "FRG-028-002", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8686), "Johannesburg Main", 1, null },
                    { 273, "Good", 28, "FRG-028-003", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8691), "Johannesburg Main", 1, null },
                    { 274, "Excellent", 28, "FRG-028-004", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8695), "Durban Warehouse", 1, null },
                    { 275, "Very Good", 28, "FRG-028-005", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8699), "Cape Town Storage", 1, null },
                    { 276, "Excellent", 28, "FRG-028-006", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8704), "Durban Warehouse", 1, null },
                    { 277, "Good", 28, "FRG-028-007", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8709), "Port Elizabeth Depot", 1, null },
                    { 278, "Good", 28, "FRG-028-008", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8714), "Durban Warehouse", 1, null },
                    { 279, "Excellent", 28, "FRG-028-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8718), "Pretoria Facility", 1, null },
                    { 280, "Excellent", 28, "FRG-028-010", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8723), "Durban Warehouse", 1, null },
                    { 281, "Good", 29, "FRG-029-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8727), "Johannesburg Main", 1, null },
                    { 282, "Good", 29, "FRG-029-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8731), "Port Elizabeth Depot", 1, null },
                    { 283, "Excellent", 29, "FRG-029-003", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8736), "Pretoria Facility", 1, null },
                    { 284, "Very Good", 29, "FRG-029-004", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8741), "Port Elizabeth Depot", 1, null },
                    { 285, "Good", 29, "FRG-029-005", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8745), "Cape Town Storage", 1, null },
                    { 286, "Excellent", 29, "FRG-029-006", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8750), "Pretoria Facility", 1, null },
                    { 287, "Good", 29, "FRG-029-007", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8754), "Johannesburg Main", 1, null },
                    { 288, "Good", 29, "FRG-029-008", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8759), "Cape Town Storage", 1, null },
                    { 289, "Good", 29, "FRG-029-009", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8763), "Pretoria Facility", 1, null },
                    { 290, "Very Good", 29, "FRG-029-010", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8768), "Johannesburg Main", 1, null },
                    { 291, "Good", 30, "FRG-030-001", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8773), "Pretoria Facility", 1, null },
                    { 292, "Good", 30, "FRG-030-002", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8777), "Port Elizabeth Depot", 1, null },
                    { 293, "Good", 30, "FRG-030-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8782), "Cape Town Storage", 1, null },
                    { 294, "Good", 30, "FRG-030-004", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8787), "Johannesburg Main", 1, null },
                    { 295, "Good", 30, "FRG-030-005", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8791), "Durban Warehouse", 1, null },
                    { 296, "Excellent", 30, "FRG-030-006", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8795), "Durban Warehouse", 1, null },
                    { 297, "Excellent", 30, "FRG-030-007", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8800), "Durban Warehouse", 1, null },
                    { 298, "Good", 30, "FRG-030-008", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8804), "Johannesburg Main", 1, null },
                    { 299, "Good", 30, "FRG-030-009", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8809), "Pretoria Facility", 1, null },
                    { 300, "Very Good", 30, "FRG-030-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8814), "Durban Warehouse", 1, null },
                    { 301, "Excellent", 31, "FRG-031-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8819), "Durban Warehouse", 1, null },
                    { 302, "Very Good", 31, "FRG-031-002", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8823), "Port Elizabeth Depot", 1, null },
                    { 303, "Good", 31, "FRG-031-003", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8828), "Pretoria Facility", 1, null },
                    { 304, "Excellent", 31, "FRG-031-004", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8832), "Cape Town Storage", 1, null },
                    { 305, "Very Good", 31, "FRG-031-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8836), "Port Elizabeth Depot", 1, null },
                    { 306, "Good", 31, "FRG-031-006", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8841), "Cape Town Storage", 1, null },
                    { 307, "Good", 31, "FRG-031-007", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8845), "Johannesburg Main", 1, null },
                    { 308, "Good", 31, "FRG-031-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8850), "Johannesburg Main", 1, null },
                    { 309, "Good", 31, "FRG-031-009", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8854), "Cape Town Storage", 1, null },
                    { 310, "Good", 31, "FRG-031-010", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8859), "Port Elizabeth Depot", 1, null },
                    { 311, "Good", 32, "FRG-032-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8863), "Cape Town Storage", 1, null },
                    { 312, "Excellent", 32, "FRG-032-002", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8868), "Johannesburg Main", 1, null },
                    { 313, "Excellent", 32, "FRG-032-003", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8872), "Port Elizabeth Depot", 1, null },
                    { 314, "Good", 32, "FRG-032-004", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8877), "Pretoria Facility", 1, null },
                    { 315, "Good", 32, "FRG-032-005", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8881), "Durban Warehouse", 1, null },
                    { 316, "Very Good", 32, "FRG-032-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8886), "Cape Town Storage", 1, null },
                    { 317, "Good", 32, "FRG-032-007", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8890), "Durban Warehouse", 1, null },
                    { 318, "Excellent", 32, "FRG-032-008", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8895), "Johannesburg Main", 1, null },
                    { 319, "Very Good", 32, "FRG-032-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8899), "Durban Warehouse", 1, null },
                    { 320, "Good", 32, "FRG-032-010", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8903), "Cape Town Storage", 1, null },
                    { 321, "Very Good", 33, "FRG-033-001", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8908), "Durban Warehouse", 1, null },
                    { 322, "Good", 33, "FRG-033-002", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8912), "Durban Warehouse", 1, null },
                    { 323, "Good", 33, "FRG-033-003", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8916), "Port Elizabeth Depot", 1, null },
                    { 324, "Good", 33, "FRG-033-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8920), "Cape Town Storage", 1, null },
                    { 325, "Very Good", 33, "FRG-033-005", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8925), "Cape Town Storage", 1, null },
                    { 326, "Good", 33, "FRG-033-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8929), "Cape Town Storage", 1, null },
                    { 327, "Excellent", 33, "FRG-033-007", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8933), "Cape Town Storage", 1, null },
                    { 328, "Good", 33, "FRG-033-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8937), "Pretoria Facility", 1, null },
                    { 329, "Good", 33, "FRG-033-009", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8941), "Durban Warehouse", 1, null },
                    { 330, "Good", 33, "FRG-033-010", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8945), "Johannesburg Main", 1, null },
                    { 331, "Excellent", 34, "FRG-034-001", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8950), "Durban Warehouse", 1, null },
                    { 332, "Excellent", 34, "FRG-034-002", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8960), "Johannesburg Main", 1, null },
                    { 333, "Very Good", 34, "FRG-034-003", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8965), "Pretoria Facility", 1, null },
                    { 334, "Excellent", 34, "FRG-034-004", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8969), "Johannesburg Main", 1, null },
                    { 335, "Excellent", 34, "FRG-034-005", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8974), "Johannesburg Main", 1, null },
                    { 336, "Very Good", 34, "FRG-034-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8978), "Pretoria Facility", 1, null },
                    { 337, "Excellent", 34, "FRG-034-007", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8982), "Johannesburg Main", 1, null },
                    { 338, "Good", 34, "FRG-034-008", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8986), "Durban Warehouse", 1, null },
                    { 339, "Good", 34, "FRG-034-009", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8990), "Port Elizabeth Depot", 1, null },
                    { 340, "Excellent", 34, "FRG-034-010", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8995), "Pretoria Facility", 1, null },
                    { 341, "Excellent", 35, "FRG-035-001", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(8999), "Pretoria Facility", 1, null },
                    { 342, "Excellent", 35, "FRG-035-002", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9003), "Durban Warehouse", 1, null },
                    { 343, "Good", 35, "FRG-035-003", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9007), "Cape Town Storage", 1, null },
                    { 344, "Good", 35, "FRG-035-004", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9011), "Johannesburg Main", 1, null },
                    { 345, "Good", 35, "FRG-035-005", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9015), "Port Elizabeth Depot", 1, null },
                    { 346, "Good", 35, "FRG-035-006", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9019), "Port Elizabeth Depot", 1, null },
                    { 347, "Very Good", 35, "FRG-035-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9023), "Durban Warehouse", 1, null },
                    { 348, "Good", 35, "FRG-035-008", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9027), "Pretoria Facility", 1, null },
                    { 349, "Very Good", 35, "FRG-035-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9031), "Johannesburg Main", 1, null },
                    { 350, "Good", 35, "FRG-035-010", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9035), "Durban Warehouse", 1, null },
                    { 351, "Good", 36, "FRG-036-001", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9039), "Durban Warehouse", 1, null },
                    { 352, "Very Good", 36, "FRG-036-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9043), "Cape Town Storage", 1, null },
                    { 353, "Very Good", 36, "FRG-036-003", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9047), "Port Elizabeth Depot", 1, null },
                    { 354, "Good", 36, "FRG-036-004", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9051), "Johannesburg Main", 1, null },
                    { 355, "Good", 36, "FRG-036-005", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9055), "Johannesburg Main", 1, null },
                    { 356, "Good", 36, "FRG-036-006", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9059), "Port Elizabeth Depot", 1, null },
                    { 357, "Very Good", 36, "FRG-036-007", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9063), "Pretoria Facility", 1, null },
                    { 358, "Excellent", 36, "FRG-036-008", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9067), "Pretoria Facility", 1, null },
                    { 359, "Excellent", 36, "FRG-036-009", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9071), "Pretoria Facility", 1, null },
                    { 360, "Excellent", 36, "FRG-036-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9075), "Cape Town Storage", 1, null },
                    { 361, "Good", 37, "FRG-037-001", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9079), "Pretoria Facility", 1, null },
                    { 362, "Excellent", 37, "FRG-037-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9083), "Port Elizabeth Depot", 1, null },
                    { 363, "Good", 37, "FRG-037-003", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9087), "Cape Town Storage", 1, null },
                    { 364, "Good", 37, "FRG-037-004", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9091), "Cape Town Storage", 1, null },
                    { 365, "Good", 37, "FRG-037-005", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9095), "Port Elizabeth Depot", 1, null },
                    { 366, "Very Good", 37, "FRG-037-006", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9099), "Port Elizabeth Depot", 1, null },
                    { 367, "Good", 37, "FRG-037-007", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9103), "Pretoria Facility", 1, null },
                    { 368, "Good", 37, "FRG-037-008", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9107), "Cape Town Storage", 1, null },
                    { 369, "Excellent", 37, "FRG-037-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9111), "Johannesburg Main", 1, null },
                    { 370, "Excellent", 37, "FRG-037-010", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9115), "Durban Warehouse", 1, null },
                    { 371, "Good", 38, "FRG-038-001", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9119), "Cape Town Storage", 1, null },
                    { 372, "Very Good", 38, "FRG-038-002", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9123), "Pretoria Facility", 1, null },
                    { 373, "Good", 38, "FRG-038-003", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9127), "Cape Town Storage", 1, null },
                    { 374, "Excellent", 38, "FRG-038-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9131), "Port Elizabeth Depot", 1, null },
                    { 375, "Excellent", 38, "FRG-038-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9135), "Pretoria Facility", 1, null },
                    { 376, "Good", 38, "FRG-038-006", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9139), "Cape Town Storage", 1, null },
                    { 377, "Very Good", 38, "FRG-038-007", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9143), "Johannesburg Main", 1, null },
                    { 378, "Good", 38, "FRG-038-008", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9147), "Durban Warehouse", 1, null },
                    { 379, "Good", 38, "FRG-038-009", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9151), "Port Elizabeth Depot", 1, null },
                    { 380, "Excellent", 38, "FRG-038-010", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9155), "Pretoria Facility", 1, null },
                    { 381, "Good", 39, "FRG-039-001", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9159), "Pretoria Facility", 1, null },
                    { 382, "Good", 39, "FRG-039-002", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9163), "Pretoria Facility", 1, null },
                    { 383, "Good", 39, "FRG-039-003", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9167), "Johannesburg Main", 1, null },
                    { 384, "Excellent", 39, "FRG-039-004", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9171), "Durban Warehouse", 1, null },
                    { 385, "Good", 39, "FRG-039-005", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9175), "Cape Town Storage", 1, null },
                    { 386, "Very Good", 39, "FRG-039-006", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9179), "Pretoria Facility", 1, null },
                    { 387, "Excellent", 39, "FRG-039-007", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9183), "Durban Warehouse", 1, null },
                    { 388, "Excellent", 39, "FRG-039-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9187), "Cape Town Storage", 1, null },
                    { 389, "Excellent", 39, "FRG-039-009", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9191), "Johannesburg Main", 1, null },
                    { 390, "Good", 39, "FRG-039-010", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9195), "Pretoria Facility", 1, null },
                    { 391, "Very Good", 40, "FRG-040-001", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9199), "Port Elizabeth Depot", 1, null },
                    { 392, "Very Good", 40, "FRG-040-002", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9203), "Cape Town Storage", 1, null },
                    { 393, "Good", 40, "FRG-040-003", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9207), "Pretoria Facility", 1, null },
                    { 394, "Excellent", 40, "FRG-040-004", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9211), "Durban Warehouse", 1, null },
                    { 395, "Good", 40, "FRG-040-005", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9216), "Cape Town Storage", 1, null },
                    { 396, "Excellent", 40, "FRG-040-006", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9220), "Port Elizabeth Depot", 1, null },
                    { 397, "Excellent", 40, "FRG-040-007", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9224), "Durban Warehouse", 1, null },
                    { 398, "Good", 40, "FRG-040-008", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9228), "Durban Warehouse", 1, null },
                    { 399, "Good", 40, "FRG-040-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9232), "Johannesburg Main", 1, null },
                    { 400, "Excellent", 40, "FRG-040-010", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9243), "Johannesburg Main", 1, null },
                    { 401, "Very Good", 41, "FRG-041-001", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9247), "Pretoria Facility", 1, null },
                    { 402, "Very Good", 41, "FRG-041-002", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9251), "Johannesburg Main", 1, null },
                    { 403, "Very Good", 41, "FRG-041-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9255), "Pretoria Facility", 1, null },
                    { 404, "Good", 41, "FRG-041-004", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9259), "Pretoria Facility", 1, null },
                    { 405, "Excellent", 41, "FRG-041-005", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9263), "Durban Warehouse", 1, null },
                    { 406, "Good", 41, "FRG-041-006", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9267), "Pretoria Facility", 1, null },
                    { 407, "Very Good", 41, "FRG-041-007", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9271), "Pretoria Facility", 1, null },
                    { 408, "Good", 41, "FRG-041-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9275), "Pretoria Facility", 1, null },
                    { 409, "Excellent", 41, "FRG-041-009", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9279), "Johannesburg Main", 1, null },
                    { 410, "Very Good", 41, "FRG-041-010", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9284), "Pretoria Facility", 1, null },
                    { 411, "Good", 42, "FRG-042-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9288), "Johannesburg Main", 1, null },
                    { 412, "Good", 42, "FRG-042-002", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9292), "Cape Town Storage", 1, null },
                    { 413, "Very Good", 42, "FRG-042-003", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9296), "Cape Town Storage", 1, null },
                    { 414, "Good", 42, "FRG-042-004", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9300), "Durban Warehouse", 1, null },
                    { 415, "Excellent", 42, "FRG-042-005", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9304), "Johannesburg Main", 1, null },
                    { 416, "Very Good", 42, "FRG-042-006", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9308), "Johannesburg Main", 1, null },
                    { 417, "Excellent", 42, "FRG-042-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9312), "Cape Town Storage", 1, null },
                    { 418, "Excellent", 42, "FRG-042-008", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9316), "Johannesburg Main", 1, null },
                    { 419, "Good", 42, "FRG-042-009", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9320), "Cape Town Storage", 1, null },
                    { 420, "Very Good", 42, "FRG-042-010", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9324), "Durban Warehouse", 1, null },
                    { 421, "Excellent", 43, "FRG-043-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9328), "Port Elizabeth Depot", 1, null },
                    { 422, "Good", 43, "FRG-043-002", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9332), "Cape Town Storage", 1, null },
                    { 423, "Excellent", 43, "FRG-043-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9336), "Port Elizabeth Depot", 1, null },
                    { 424, "Very Good", 43, "FRG-043-004", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9340), "Durban Warehouse", 1, null },
                    { 425, "Good", 43, "FRG-043-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9344), "Johannesburg Main", 1, null },
                    { 426, "Excellent", 43, "FRG-043-006", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9348), "Cape Town Storage", 1, null },
                    { 427, "Excellent", 43, "FRG-043-007", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9353), "Pretoria Facility", 1, null },
                    { 428, "Very Good", 43, "FRG-043-008", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9357), "Johannesburg Main", 1, null },
                    { 429, "Good", 43, "FRG-043-009", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9361), "Port Elizabeth Depot", 1, null },
                    { 430, "Good", 43, "FRG-043-010", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9365), "Pretoria Facility", 1, null },
                    { 431, "Excellent", 44, "FRG-044-001", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9369), "Cape Town Storage", 1, null },
                    { 432, "Excellent", 44, "FRG-044-002", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9373), "Pretoria Facility", 1, null },
                    { 433, "Very Good", 44, "FRG-044-003", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9377), "Port Elizabeth Depot", 1, null },
                    { 434, "Excellent", 44, "FRG-044-004", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9381), "Pretoria Facility", 1, null },
                    { 435, "Good", 44, "FRG-044-005", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9385), "Cape Town Storage", 1, null },
                    { 436, "Good", 44, "FRG-044-006", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9389), "Pretoria Facility", 1, null },
                    { 437, "Excellent", 44, "FRG-044-007", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9393), "Cape Town Storage", 1, null },
                    { 438, "Good", 44, "FRG-044-008", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9397), "Johannesburg Main", 1, null },
                    { 439, "Good", 44, "FRG-044-009", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9401), "Durban Warehouse", 1, null },
                    { 440, "Good", 44, "FRG-044-010", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9405), "Port Elizabeth Depot", 1, null },
                    { 441, "Excellent", 45, "FRG-045-001", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9409), "Johannesburg Main", 1, null },
                    { 442, "Good", 45, "FRG-045-002", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9413), "Johannesburg Main", 1, null },
                    { 443, "Excellent", 45, "FRG-045-003", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9417), "Cape Town Storage", 1, null },
                    { 444, "Excellent", 45, "FRG-045-004", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9421), "Port Elizabeth Depot", 1, null },
                    { 445, "Good", 45, "FRG-045-005", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9425), "Port Elizabeth Depot", 1, null },
                    { 446, "Very Good", 45, "FRG-045-006", true, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9429), "Port Elizabeth Depot", 1, null },
                    { 447, "Good", 45, "FRG-045-007", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9433), "Cape Town Storage", 1, null },
                    { 448, "Excellent", 45, "FRG-045-008", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9437), "Pretoria Facility", 1, null },
                    { 449, "Good", 45, "FRG-045-009", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9441), "Pretoria Facility", 1, null },
                    { 450, "Very Good", 45, "FRG-045-010", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9445), "Cape Town Storage", 1, null },
                    { 451, "Good", 46, "FRG-046-001", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9449), "Pretoria Facility", 1, null },
                    { 452, "Excellent", 46, "FRG-046-002", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9453), "Johannesburg Main", 1, null },
                    { 453, "Excellent", 46, "FRG-046-003", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9457), "Cape Town Storage", 1, null },
                    { 454, "Excellent", 46, "FRG-046-004", false, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9461), "Port Elizabeth Depot", 1, null },
                    { 455, "Good", 46, "FRG-046-005", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9466), "Durban Warehouse", 1, null },
                    { 456, "Excellent", 46, "FRG-046-006", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9470), "Durban Warehouse", 1, null },
                    { 457, "Very Good", 46, "FRG-046-007", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9474), "Port Elizabeth Depot", 1, null },
                    { 458, "Good", 46, "FRG-046-008", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9478), "Johannesburg Main", 1, null },
                    { 459, "Good", 46, "FRG-046-009", false, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9482), "Cape Town Storage", 1, null },
                    { 460, "Very Good", 46, "FRG-046-010", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9486), "Johannesburg Main", 1, null },
                    { 461, "Excellent", 47, "FRG-047-001", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9490), "Pretoria Facility", 1, null },
                    { 462, "Good", 47, "FRG-047-002", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9494), "Durban Warehouse", 1, null },
                    { 463, "Excellent", 47, "FRG-047-003", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9498), "Port Elizabeth Depot", 1, null },
                    { 464, "Very Good", 47, "FRG-047-004", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9502), "Pretoria Facility", 1, null },
                    { 465, "Excellent", 47, "FRG-047-005", false, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9506), "Cape Town Storage", 1, null },
                    { 466, "Good", 47, "FRG-047-006", false, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9510), "Durban Warehouse", 1, null },
                    { 467, "Good", 47, "FRG-047-007", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9514), "Cape Town Storage", 1, null },
                    { 468, "Excellent", 47, "FRG-047-008", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9518), "Johannesburg Main", 1, null },
                    { 469, "Very Good", 47, "FRG-047-009", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9528), "Durban Warehouse", 1, null },
                    { 470, "Excellent", 47, "FRG-047-010", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9533), "Durban Warehouse", 1, null },
                    { 471, "Very Good", 48, "FRG-048-001", true, new DateTime(2025, 8, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9537), "Johannesburg Main", 1, null },
                    { 472, "Excellent", 48, "FRG-048-002", true, new DateTime(2025, 10, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9541), "Durban Warehouse", 1, null },
                    { 473, "Excellent", 48, "FRG-048-003", false, new DateTime(2025, 6, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9545), "Johannesburg Main", 1, null },
                    { 474, "Excellent", 48, "FRG-048-004", true, new DateTime(2025, 11, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9549), "Durban Warehouse", 1, null },
                    { 475, "Good", 48, "FRG-048-005", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9553), "Cape Town Storage", 1, null },
                    { 476, "Very Good", 48, "FRG-048-006", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9557), "Cape Town Storage", 1, null },
                    { 477, "Excellent", 48, "FRG-048-007", false, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9561), "Cape Town Storage", 1, null },
                    { 478, "Excellent", 48, "FRG-048-008", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9565), "Pretoria Facility", 1, null },
                    { 479, "Good", 48, "FRG-048-009", true, new DateTime(2025, 9, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9569), "Durban Warehouse", 1, null },
                    { 480, "Excellent", 48, "FRG-048-010", true, new DateTime(2025, 7, 11, 11, 4, 11, 703, DateTimeKind.Local).AddTicks(9573), "Port Elizabeth Depot", 1, null }
                });

            migrationBuilder.InsertData(
                table: "tblAllocations",
                columns: new[] { "AllocationId", "Count", "CustomerID", "FridgeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 18 },
                    { 2, 2, 10, 47 },
                    { 3, 1, 7, 22 },
                    { 4, 1, 7, 32 },
                    { 5, 1, 9, 36 },
                    { 6, 2, 1, 20 },
                    { 7, 1, 7, 22 },
                    { 8, 2, 5, 6 },
                    { 9, 1, 2, 30 },
                    { 10, 3, 11, 5 },
                    { 11, 3, 12, 10 },
                    { 12, 1, 4, 45 },
                    { 13, 2, 8, 14 },
                    { 14, 2, 12, 40 },
                    { 15, 1, 6, 29 }
                });

            migrationBuilder.InsertData(
                table: "tblFaultReports",
                columns: new[] { "FaultReportId", "CustomerId", "DeclineReason", "Description", "FaultType", "FridgeInStockId", "ImageUrl", "IsRelaunched", "IsReplacementRequested", "OriginalFaultReportId", "Priority", "ReportedDate", "RequestReplacement", "Status" },
                values: new object[,]
                {
                    { 1, 9, null, "Fault description for report 1. Issue requires attention.", "Water Leakage", 85, "/Images/Faults/fault-1.jpg", false, false, null, "Critical", new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1699), true, "In Progress" },
                    { 2, 10, null, "Fault description for report 2. Issue requires attention.", "Electrical Issues", 77, "/Images/Faults/fault-2.jpg", false, false, null, "Low", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1719), true, "Reported" },
                    { 3, 11, null, "Fault description for report 3. Issue requires attention.", "Electrical Issues", 69, "/Images/Faults/fault-3.jpg", false, false, null, "High", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1724), false, "In Progress" },
                    { 4, 3, null, "Fault description for report 4. Issue requires attention.", "Strange Noises", 106, "/Images/Faults/fault-4.jpg", false, true, null, "Low", new DateTime(2025, 10, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1728), false, "Reported" },
                    { 5, 9, null, "Fault description for report 5. Issue requires attention.", "Water Leakage", 39, "/Images/Faults/fault-5.jpg", false, true, null, "Medium", new DateTime(2025, 10, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1732), false, "Resolved" },
                    { 6, 2, null, "Fault description for report 6. Issue requires attention.", "Electrical Issues", 47, "/Images/Faults/fault-6.jpg", false, true, null, "Low", new DateTime(2025, 9, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1737), false, "In Progress" },
                    { 7, 12, null, "Fault description for report 7. Issue requires attention.", "Door Problems", 104, "/Images/Faults/fault-7.jpg", false, true, null, "Medium", new DateTime(2025, 10, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1741), true, "Reported" },
                    { 8, 12, null, "Fault description for report 8. Issue requires attention.", "Strange Noises", 129, "/Images/Faults/fault-8.jpg", false, true, null, "High", new DateTime(2025, 10, 20, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1745), true, "Reported" },
                    { 9, 2, null, "Fault description for report 9. Issue requires attention.", "Door Problems", 89, "/Images/Faults/fault-9.jpg", false, true, null, "High", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1749), true, "Declined" },
                    { 10, 7, null, "Fault description for report 10. Issue requires attention.", "Strange Noises", 80, "/Images/Faults/fault-10.jpg", false, false, null, "Low", new DateTime(2025, 10, 12, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1754), true, "Reported" },
                    { 11, 3, null, "Fault description for report 11. Issue requires attention.", "Not Cooling", 139, "/Images/Faults/fault-11.jpg", false, false, null, "Critical", new DateTime(2025, 10, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1758), false, "Reported" },
                    { 12, 12, null, "Fault description for report 12. Issue requires attention.", "Strange Noises", 108, "/Images/Faults/fault-12.jpg", false, true, null, "Medium", new DateTime(2025, 10, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1763), false, "Reported" },
                    { 13, 2, null, "Fault description for report 13. Issue requires attention.", "Electrical Issues", 150, "/Images/Faults/fault-13.jpg", false, false, null, "Low", new DateTime(2025, 10, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1767), false, "Resolved" },
                    { 14, 1, null, "Fault description for report 14. Issue requires attention.", "Strange Noises", 50, "/Images/Faults/fault-14.jpg", false, true, null, "High", new DateTime(2025, 10, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1771), true, "Declined" },
                    { 15, 8, null, "Fault description for report 15. Issue requires attention.", "Strange Noises", 18, "/Images/Faults/fault-15.jpg", false, true, null, "Critical", new DateTime(2025, 11, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1775), true, "Resolved" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestHeaders",
                columns: new[] { "RequestHeaderId", "AdditionalDescription", "AdditionalDocumentPath", "Carrier", "CellNumber", "City", "CustomerID", "DeliveryDate", "EmployeeID", "FirstName", "IsRelaunched", "LastName", "OriginalRequestId", "PaymentDueDate", "PostalCode", "RejectionDate", "RejectionReason", "RequestDate", "RequestTotal", "State", "Status", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, "0593562404", "Pretoria", 2, null, 12, "Customer1", false, "LastName1", null, null, "2197", null, null, new DateTime(2025, 8, 21, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(269), 678.0, "Province", "Approved", "296 Main Street" },
                    { 2, null, null, null, "0515331717", "Cape Town", 3, null, 2, "Customer2", false, "LastName2", null, null, "6826", null, null, new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(938), 892.0, "Province", "Approved", "533 Service Road" },
                    { 3, null, null, null, "0353621158", "Durban", 4, new DateTime(2025, 10, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(951), 12, "Customer3", false, "LastName3", null, new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(951), "8446", null, null, new DateTime(2025, 10, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(951), 1305.0, "Province", "Shipped", "505 Service Road" },
                    { 4, null, null, null, "0149406231", "Johannesburg", 5, null, 10, "Customer4", false, "LastName4", null, null, "2819", null, null, new DateTime(2025, 8, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(961), 1014.0, "Province", "Pending", "706 Service Road" },
                    { 5, null, null, null, "0983501609", "Durban", 6, null, 2, "Customer5", false, "LastName5", null, null, "4527", null, null, new DateTime(2025, 9, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(970), 1329.0, "Province", "Approved", "658 Service Road" },
                    { 6, null, null, null, "0339412082", "Johannesburg", 7, null, 8, "Customer6", false, "LastName6", null, null, "8066", null, null, new DateTime(2025, 9, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(990), 1211.0, "Province", "Approved", "944 Commerce Road" },
                    { 7, null, null, null, "0558657658", "Port Elizabeth", 8, null, 12, "Customer7", false, "LastName7", null, null, "4010", null, null, new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1007), 627.0, "Province", "Pending", "556 Main Street" },
                    { 8, null, null, null, "0849840381", "Johannesburg", 9, null, 8, "Customer8", false, "LastName8", null, null, "3549", new DateTime(2025, 10, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1016), "Incomplete business documentation provided", new DateTime(2025, 10, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1016), 1301.0, "Province", "Rejected", "71 Business Avenue" },
                    { 9, null, null, null, "0587805290", "Durban", 10, new DateTime(2025, 9, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1026), 3, "Customer9", false, "LastName9", null, new DateTime(2025, 9, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1026), "7067", null, null, new DateTime(2025, 8, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1026), 652.0, "Province", "Shipped", "672 Trade Street" },
                    { 10, null, null, null, "0252604306", "Johannesburg", 11, new DateTime(2025, 8, 19, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1034), 4, "Customer10", false, "LastName10", null, new DateTime(2025, 9, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1034), "3593", null, null, new DateTime(2025, 8, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1034), 1342.0, "Province", "Closed", "38 Trade Street" },
                    { 11, null, null, null, "0842616112", "Port Elizabeth", 12, new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1043), 9, "Customer11", false, "LastName11", null, new DateTime(2025, 11, 20, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1043), "6045", null, null, new DateTime(2025, 10, 21, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1043), 1201.0, "Province", "Shipped", "226 Main Street" },
                    { 12, null, null, null, "0824352236", "Johannesburg", 1, new DateTime(2025, 10, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1051), 9, "Customer12", false, "LastName12", null, new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1051), "3204", null, null, new DateTime(2025, 10, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1051), 1225.0, "Province", "Closed", "882 Commerce Road" },
                    { 13, null, null, null, "0371098818", "Cape Town", 2, null, 9, "Customer13", false, "LastName13", null, null, "9920", null, null, new DateTime(2025, 8, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1060), 419.0, "Province", "Approved", "98 Business Avenue" },
                    { 14, null, null, null, "0899310059", "Johannesburg", 3, null, 6, "Customer14", false, "LastName14", null, null, "8682", null, null, new DateTime(2025, 8, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1068), 1433.0, "Province", "Approved", "747 Trade Street" },
                    { 15, null, null, null, "0356954042", "Port Elizabeth", 4, new DateTime(2025, 10, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1077), 4, "Customer15", false, "LastName15", null, new DateTime(2025, 11, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1077), "7278", null, null, new DateTime(2025, 10, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1077), 683.0, "Province", "Shipped", "708 Commerce Road" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeVisits",
                columns: new[] { "VisitId", "CheckupStatus", "CreatedDate", "CustomerApproval", "Notes", "RequestHeaderId", "Status", "TechnicianName", "VisitDate", "VisitType" },
                values: new object[,]
                {
                    { 1, "Not Started", new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1528), "Approved", "Visit notes for service 1. Checkup completed with status: Not Started", 4, "Pending", "Jennifer Martin", new DateTime(2025, 10, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1528), "Maintenance Check" },
                    { 2, "Failed", new DateTime(2025, 10, 21, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1557), "Approved", "Visit notes for service 2. Checkup completed with status: Failed", 14, "Pending", "Patricia White", new DateTime(2025, 10, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1557), "Maintenance Check" },
                    { 3, "Not Started", new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1561), "Pending", "Visit notes for service 3. Checkup completed with status: Not Started", 10, "Pending", "Jennifer Martin", new DateTime(2025, 11, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1561), "Maintenance Check" },
                    { 4, "Not Started", new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1565), "Pending", "Visit notes for service 4. Checkup completed with status: Not Started", 1, "Pending", "Jennifer Martin", new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1565), "Maintenance Check" },
                    { 5, "Passed", new DateTime(2025, 11, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1568), "Approved", "Visit notes for service 5. Checkup completed with status: Passed", 13, "Pending", "James Miller", new DateTime(2025, 11, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1568), "Maintenance Check" },
                    { 6, "Not Started", new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1572), "Pending", "Visit notes for service 6. Checkup completed with status: Not Started", 5, "Pending", "Patricia White", new DateTime(2025, 10, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1572), "Maintenance Check" },
                    { 7, "Passed", new DateTime(2025, 10, 12, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1575), "Pending", "Visit notes for service 7. Checkup completed with status: Passed", 3, "Pending", "James Miller", new DateTime(2025, 10, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1575), "Maintenance Check" },
                    { 8, "Passed", new DateTime(2025, 10, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1579), "Pending", "Visit notes for service 8. Checkup completed with status: Passed", 9, "Pending", "James Miller", new DateTime(2025, 10, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1579), "Maintenance Check" },
                    { 9, "In Progress", new DateTime(2025, 10, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1582), "Pending", "Visit notes for service 9. Checkup completed with status: In Progress", 4, "Pending", "Patricia White", new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1582), "Maintenance Check" },
                    { 10, "Not Started", new DateTime(2025, 10, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1586), "Pending", "Visit notes for service 10. Checkup completed with status: Not Started", 8, "Pending", "Patricia White", new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1586), "Maintenance Check" },
                    { 11, "Not Started", new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1589), "Approved", "Visit notes for service 11. Checkup completed with status: Not Started", 4, "Pending", "James Miller", new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1589), "Maintenance Check" },
                    { 12, "Not Started", new DateTime(2025, 10, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1593), "Pending", "Visit notes for service 12. Checkup completed with status: Not Started", 7, "Pending", "Patricia White", new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1593), "Maintenance Check" },
                    { 13, "Not Started", new DateTime(2025, 11, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1596), "Approved", "Visit notes for service 13. Checkup completed with status: Not Started", 6, "Pending", "Jennifer Martin", new DateTime(2025, 11, 7, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1596), "Maintenance Check" },
                    { 14, "In Progress", new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1599), "Pending", "Visit notes for service 14. Checkup completed with status: In Progress", 14, "Pending", "Patricia White", new DateTime(2025, 10, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1599), "Maintenance Check" },
                    { 15, "Not Started", new DateTime(2025, 11, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1602), "Pending", "Visit notes for service 15. Checkup completed with status: Not Started", 12, "Pending", "Jennifer Martin", new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1602), "Maintenance Check" },
                    { 16, "Not Started", new DateTime(2025, 10, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1608), "Pending", "Visit notes for service 16. Checkup completed with status: Not Started", 3, "Pending", "Jennifer Martin", new DateTime(2025, 10, 23, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1608), "Maintenance Check" },
                    { 17, "Failed", new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1612), "Approved", "Visit notes for service 17. Checkup completed with status: Failed", 9, "Pending", "Jennifer Martin", new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1612), "Maintenance Check" },
                    { 18, "In Progress", new DateTime(2025, 10, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1616), "Pending", "Visit notes for service 18. Checkup completed with status: In Progress", 15, "Pending", "Jennifer Martin", new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1616), "Maintenance Check" },
                    { 19, "In Progress", new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1619), "Pending", "Visit notes for service 19. Checkup completed with status: In Progress", 8, "Pending", "Robert Davis", new DateTime(2025, 10, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1619), "Maintenance Check" },
                    { 20, "In Progress", new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1622), "Approved", "Visit notes for service 20. Checkup completed with status: In Progress", 13, "Pending", "Jennifer Martin", new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1622), "Maintenance Check" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestDetais",
                columns: new[] { "RequestDetailId", "Count", "FridgeId", "Price", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, 1, 20, 510.0, 2 },
                    { 2, 3, 46, 653.0, 3 },
                    { 3, 3, 29, 444.0, 4 },
                    { 4, 3, 36, 546.0, 5 },
                    { 5, 2, 11, 668.0, 6 },
                    { 6, 2, 34, 774.0, 7 },
                    { 7, 1, 18, 447.0, 8 },
                    { 8, 3, 40, 762.0, 9 },
                    { 9, 2, 46, 425.0, 10 },
                    { 10, 1, 14, 569.0, 11 },
                    { 11, 2, 24, 409.0, 12 },
                    { 12, 3, 9, 504.0, 13 },
                    { 13, 1, 2, 667.0, 14 },
                    { 14, 1, 26, 793.0, 15 },
                    { 15, 2, 32, 456.0, 1 },
                    { 16, 2, 21, 427.0, 2 },
                    { 17, 3, 6, 631.0, 3 },
                    { 18, 2, 6, 724.0, 4 },
                    { 19, 2, 18, 753.0, 5 },
                    { 20, 3, 25, 767.0, 6 }
                });

            migrationBuilder.InsertData(
                table: "tblRequestNotes",
                columns: new[] { "RequestNoteId", "CreatedDate", "NoteContent", "NoteType", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 5, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2174), "Note content for request 1. This is an important note regarding the service.", "Internal", 12 },
                    { 2, new DateTime(2025, 8, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2188), "Note content for request 2. This is an important note regarding the service.", "Customer", 15 },
                    { 3, new DateTime(2025, 9, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2190), "Note content for request 3. This is an important note regarding the service.", "Internal", 15 },
                    { 4, new DateTime(2025, 9, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2193), "Note content for request 4. This is an important note regarding the service.", "Customer", 3 },
                    { 5, new DateTime(2025, 9, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2195), "Note content for request 5. This is an important note regarding the service.", "Technical", 15 },
                    { 6, new DateTime(2025, 8, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2199), "Note content for request 6. This is an important note regarding the service.", "Customer", 15 },
                    { 7, new DateTime(2025, 11, 6, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2201), "Note content for request 7. This is an important note regarding the service.", "Internal", 14 },
                    { 8, new DateTime(2025, 10, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2204), "Note content for request 8. This is an important note regarding the service.", "Technical", 7 },
                    { 9, new DateTime(2025, 9, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2206), "Note content for request 9. This is an important note regarding the service.", "Administrative", 13 },
                    { 10, new DateTime(2025, 8, 19, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2210), "Note content for request 10. This is an important note regarding the service.", "Technical", 13 },
                    { 11, new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2213), "Note content for request 11. This is an important note regarding the service.", "Administrative", 8 },
                    { 12, new DateTime(2025, 10, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2215), "Note content for request 12. This is an important note regarding the service.", "Administrative", 15 },
                    { 13, new DateTime(2025, 9, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2218), "Note content for request 13. This is an important note regarding the service.", "Customer", 2 },
                    { 14, new DateTime(2025, 9, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2220), "Note content for request 14. This is an important note regarding the service.", "Internal", 14 },
                    { 15, new DateTime(2025, 10, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2223), "Note content for request 15. This is an important note regarding the service.", "Technical", 10 },
                    { 16, new DateTime(2025, 8, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2225), "Note content for request 16. This is an important note regarding the service.", "Administrative", 4 },
                    { 17, new DateTime(2025, 9, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2228), "Note content for request 17. This is an important note regarding the service.", "Technical", 8 },
                    { 18, new DateTime(2025, 9, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2231), "Note content for request 18. This is an important note regarding the service.", "Technical", 15 },
                    { 19, new DateTime(2025, 10, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2234), "Note content for request 19. This is an important note regarding the service.", "Internal", 3 },
                    { 20, new DateTime(2025, 9, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2236), "Note content for request 20. This is an important note regarding the service.", "Customer", 14 }
                });

            migrationBuilder.InsertData(
                table: "tblCustomerFridge",
                columns: new[] { "CustomerFridgeId", "AllocatedDate", "CustomerID", "FridgeId", "FridgeInStockId", "RequestDetailId", "ReservedDate" },
                values: new object[,]
                {
                    { 1, null, 2, 33, 371, 17, new DateTime(2025, 10, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1376) },
                    { 2, new DateTime(2025, 11, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1388), 1, 8, 55, 6, new DateTime(2025, 11, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1388) },
                    { 3, null, 7, 44, 382, 18, new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1401) },
                    { 4, new DateTime(2025, 9, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1402), 1, 25, 47, 5, new DateTime(2025, 9, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1402) },
                    { 5, new DateTime(2025, 9, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1403), 2, 36, 184, 4, new DateTime(2025, 9, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1403) },
                    { 6, null, 12, 4, 379, 18, new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1406) },
                    { 7, new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1407), 8, 3, 117, 6, new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1407) },
                    { 8, new DateTime(2025, 11, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1408), 2, 4, 335, 18, new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1408) },
                    { 9, new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1409), 8, 16, 373, 16, new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1409) },
                    { 10, new DateTime(2025, 11, 7, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1411), 10, 47, 275, 18, new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1411) },
                    { 11, new DateTime(2025, 9, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1413), 6, 20, 210, 11, new DateTime(2025, 9, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1413) },
                    { 12, null, 10, 28, 161, 7, new DateTime(2025, 9, 15, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1414) },
                    { 13, null, 11, 9, 133, 14, new DateTime(2025, 9, 20, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1415) },
                    { 14, new DateTime(2025, 11, 11, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1416), 1, 25, 246, 13, new DateTime(2025, 11, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1416) },
                    { 15, new DateTime(2025, 9, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1418), 1, 21, 326, 17, new DateTime(2025, 9, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1418) },
                    { 16, null, 4, 23, 4, 11, new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1419) },
                    { 17, null, 1, 26, 257, 12, new DateTime(2025, 10, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1420) },
                    { 18, null, 12, 3, 364, 9, new DateTime(2025, 9, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1422) },
                    { 19, new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1423), 9, 9, 393, 5, new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1423) },
                    { 20, new DateTime(2025, 10, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1424), 7, 39, 91, 4, new DateTime(2025, 10, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1424) },
                    { 21, new DateTime(2025, 9, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1425), 4, 41, 142, 9, new DateTime(2025, 9, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1425) },
                    { 22, null, 2, 18, 13, 10, new DateTime(2025, 10, 19, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1426) },
                    { 23, null, 5, 30, 15, 16, new DateTime(2025, 11, 9, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1428) },
                    { 24, null, 3, 1, 102, 7, new DateTime(2025, 9, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1429) },
                    { 25, new DateTime(2025, 9, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1430), 5, 12, 242, 11, new DateTime(2025, 9, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1430) }
                });

            migrationBuilder.InsertData(
                table: "tblFaultTechnicians",
                columns: new[] { "FaultId", "Bookingate", "Completion", "CreatedDate", "CustomerBookingStatus", "FaultDescription", "FaultReportId", "FaultType", "Priority", "RepairStatus", "ReportDate", "ResolutionNotes", "TechnicianAssigned", "VisitId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 10, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1841), "Decline", "Fault description for technician assignment 1", 9, "Technical Fault", "Medium", "Scrapped", new DateTime(2025, 10, 26, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1841), null, "Patricia White", 3 },
                    { 2, null, null, new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1866), "Pending", "Fault description for technician assignment 2", 13, "Technical Fault", "Medium", "Completed", new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1866), "Resolution notes for fault 2", "James Miller", 9 },
                    { 3, new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1878), null, new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1878), "Decline", "Fault description for technician assignment 3", 12, "Technical Fault", "High", "Resolved", new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1878), "Resolution notes for fault 3", "Robert Davis", 9 },
                    { 4, null, null, new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1883), "Approved", "Fault description for technician assignment 4", 4, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1883), "Resolution notes for fault 4", "Jennifer Martin", 13 },
                    { 5, new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1888), null, new DateTime(2025, 10, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1888), "Decline", "Fault description for technician assignment 5", 2, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 18, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1888), "Resolution notes for fault 5", "Patricia White", 11 },
                    { 6, null, null, new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1893), "Decline", "Fault description for technician assignment 6", 1, "Technical Fault", "Medium", "Completed", new DateTime(2025, 10, 14, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1893), "Resolution notes for fault 6", "Patricia White", 5 },
                    { 7, null, null, new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1898), "Approved", "Fault description for technician assignment 7", 8, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1898), null, "James Miller", 20 },
                    { 8, new DateTime(2025, 11, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1901), null, new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1901), "Pending", "Fault description for technician assignment 8", 12, "Technical Fault", "Medium", "Resolved", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1901), null, "James Miller", 9 },
                    { 9, null, null, new DateTime(2025, 11, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1905), "Approved", "Fault description for technician assignment 9", 14, "Technical Fault", "Medium", "Resolved", new DateTime(2025, 11, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1905), null, "Robert Davis", 18 },
                    { 10, new DateTime(2025, 11, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1909), null, new DateTime(2025, 11, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1909), "Approved", "Fault description for technician assignment 10", 3, "Technical Fault", "High", "Resolved", new DateTime(2025, 11, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1909), "Resolution notes for fault 10", "Patricia White", 3 },
                    { 11, null, null, new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1914), "Pending", "Fault description for technician assignment 11", 6, "Technical Fault", "Medium", "Completed", new DateTime(2025, 10, 30, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1914), "Resolution notes for fault 11", "James Miller", 11 },
                    { 12, new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1919), null, new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1919), "Decline", "Fault description for technician assignment 12", 13, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 24, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1919), "Resolution notes for fault 12", "James Miller", 14 },
                    { 13, null, null, new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1923), "Decline", "Fault description for technician assignment 13", 6, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 25, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1923), null, "Patricia White", 14 },
                    { 14, new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1926), null, new DateTime(2025, 10, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1926), "Pending", "Fault description for technician assignment 14", 11, "Technical Fault", "Medium", "Scrapped", new DateTime(2025, 10, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1926), null, "Robert Davis", 13 },
                    { 15, new DateTime(2025, 11, 7, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1930), null, new DateTime(2025, 11, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1930), "Approved", "Fault description for technician assignment 15", 6, "Technical Fault", "High", "Completed", new DateTime(2025, 11, 3, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1930), null, "Patricia White", 1 }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeReplacements",
                columns: new[] { "FridgeReplacementId", "AdditionalNotes", "ApplicationUserId", "CustomerID", "NewFridgeInStockId", "OldFridgeNo", "ReasonForReplacement", "ReplacementDate", "ReplacementStatus", "RequestDate", "VisitId" },
                values: new object[,]
                {
                    { 1, "Additional notes for replacement request 1", "15", 7, 76, "FRG-009-004", "Frequent Breakdowns", new DateTime(2025, 12, 4, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1997), "Rejected", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(1997), 1 },
                    { 2, "Additional notes for replacement request 2", "7", 8, 53, "FRG-003-008", "Old Age", new DateTime(2025, 11, 21, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2027), "Pending", new DateTime(2025, 11, 8, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2027), 8 },
                    { 3, "Additional notes for replacement request 3", "14", 4, 130, "FRG-001-010", "Old Age", new DateTime(2025, 10, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2033), "Approved", new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2033), 6 },
                    { 4, "Additional notes for replacement request 4", "3", 8, 5, "FRG-011-008", "Fridge Beyond Repair", new DateTime(2025, 11, 2, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2039), "Approved", new DateTime(2025, 10, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2039), 20 },
                    { 5, "Additional notes for replacement request 5", "24", 12, 111, "FRG-015-001", "Customer Request", new DateTime(2025, 9, 19, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2045), "Pending", new DateTime(2025, 9, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2045), 18 },
                    { 6, "Additional notes for replacement request 6", "16", 12, 86, "FRG-013-005", "Customer Request", new DateTime(2025, 11, 13, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2052), "Rejected", new DateTime(2025, 11, 1, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2052), 4 },
                    { 7, "Additional notes for replacement request 7", "3", 8, 45, "FRG-012-005", "Customer Request", new DateTime(2025, 10, 16, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2057), "Rejected", new DateTime(2025, 9, 21, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2057), 2 },
                    { 8, "Additional notes for replacement request 8", "25", 10, 118, "FRG-014-002", "Frequent Breakdowns", new DateTime(2025, 10, 28, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2069), "Approved", new DateTime(2025, 9, 29, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2069), 3 },
                    { 9, "Additional notes for replacement request 9", "12", 10, 50, "FRG-007-005", "Fridge Beyond Repair", new DateTime(2025, 11, 17, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2075), "Rejected", new DateTime(2025, 10, 31, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2075), 20 },
                    { 10, "Additional notes for replacement request 10", "2", 3, 16, "FRG-012-008", "Old Age", new DateTime(2025, 11, 22, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2082), "Pending", new DateTime(2025, 11, 7, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2082), 6 },
                    { 11, "Additional notes for replacement request 11", "4", 12, 36, "FRG-009-006", "Frequent Breakdowns", new DateTime(2025, 11, 9, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2088), "Approved", new DateTime(2025, 10, 12, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2088), 17 },
                    { 12, "Additional notes for replacement request 12", "25", 7, 39, "FRG-009-005", "Fridge Beyond Repair", new DateTime(2025, 10, 10, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2094), "Pending", new DateTime(2025, 9, 27, 11, 4, 11, 704, DateTimeKind.Local).AddTicks(2094), 15 }
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
