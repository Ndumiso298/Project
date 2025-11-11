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
                    { "1", 0, "0111234567", "Johannesburg", "cf221007-1667-42ac-8218-dfa6aaff2cfa", null, "ApplicationUser", "admin@gmail.com", true, "John", true, "Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGxcMWNgpupuJ3Fo0ECCXYrjZAFh3q//7hc5XrxipMZTmCiQRL8YxX21NKg7eDy18g==", null, false, "2000", null, "93537393-f6c3-4b5b-8752-f368d6002873", "Gauteng", "Approved", "123 Admin Street", false, "admin@gmail.com" },
                    { "10", 0, "0148884567", "Rustenburg", "938f1c20-b5e0-4a5d-8070-766084b44853", null, "ApplicationUser", "olivia.martinez@gmail.com", true, "Olivia", true, "Martinez", false, null, "OLIVIA.MARTINEZ@GMAIL.COM", "OLIVIA.MARTINEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMSZ45JDv4+exaNs0NryDio4TzfPY6mHANC3Ab1Ymty5LZ1Z41PGlNfIyTj3KKnoMg==", null, false, "2999", null, "52ef9eec-d3bf-4876-92c6-a66de7902f26", "North West", "Approved", "741 Commercial Ave", false, "olivia.martinez@gmail.com" },
                    { "11", 0, "0315551234", "Durban", "2337b30f-8631-49ba-937b-66529e86823e", null, "ApplicationUser", "emily.wilson@gmail.com", true, "Emily", true, "Wilson", false, null, "EMILY.WILSON@GMAIL.COM", "EMILY.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEBydqbS0ztRwNgva7otCOr3FZOIqaiM8/XHH2uFhd37+7NKIcZJEeNnFSuPbDQGKiA==", null, false, "4001", null, "cf2d4723-66f2-4ad8-9a2e-f7c35275e9ca", "KwaZulu-Natal", "Approved", "789 Support Road", false, "emily.wilson@gmail.com" },
                    { "12", 0, "0124445678", "Pretoria", "ef14aa14-7ad2-4020-8b47-c399d24ce06d", null, "ApplicationUser", "michael.brown@gmail.com", true, "Michael", true, "Brown", false, null, "MICHAEL.BROWN@GMAIL.COM", "MICHAEL.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAENnqeD+pM5gJjBwSBy04AlMgBwJEkYwybFuFq+ZaPvD7P+aHj2grIxE90INcsKnzaQ==", null, false, "0002", null, "048e4fab-2257-489f-8e92-4c08abf65660", "Gauteng", "Approved", "321 Help Street", false, "michael.brown@gmail.com" },
                    { "13", 0, "0113337890", "Johannesburg", "20172b75-88b0-4d4e-aed4-1c61380d002c", null, "ApplicationUser", "david.taylor@gmail.com", true, "David", true, "Taylor", false, null, "DAVID.TAYLOR@GMAIL.COM", "DAVID.TAYLOR@GMAIL.COM", "AQAAAAIAAYagAAAAEGaVqqXVTJJXy/5HxojQHjN2+VStD0OQ4DBO01imeAeVqGZ7OiTgVT+03BSaLzu8Og==", null, false, "2001", null, "f83bcd46-5bf5-4ff8-b9be-26ef0ccdef86", "Gauteng", "Approved", "654 Warehouse Ave", false, "david.taylor@gmail.com" },
                    { "14", 0, "0216667890", "Cape Town", "01981482-614a-4c7f-9fa3-205556f7e9de", null, "ApplicationUser", "sarah.anderson@gmail.com", true, "Sarah", true, "Anderson", false, null, "SARAH.ANDERSON@GMAIL.COM", "SARAH.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAENEVr4Zklg4XOVQhHGOHprNoF3GB9OPzqir82GTu8KaTMHnS0a1EOrlZo75Vo5cOEg==", null, false, "8001", null, "7f7d184c-3fdc-4ebd-9d69-39984e32a14f", "Western Cape", "Approved", "852 Inventory Street", false, "sarah.anderson@gmail.com" },
                    { "15", 0, "0212224567", "Cape Town", "c3c71740-afdf-4730-b339-ff910f981c1d", null, "ApplicationUser", "robert.davis@gmail.com", true, "Robert", true, "Davis", false, null, "ROBERT.DAVIS@GMAIL.COM", "ROBERT.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEEp8+cENsyb1Nsx80nSbYrMOsEutLljHB6In0CoGMgrtxSILZ6Oy9b5fBmmQIbL47Q==", null, false, "8001", null, "cfb5a599-a0c9-421c-ae39-816cea4aed8d", "Western Cape", "Approved", "987 Service Road", false, "robert.davis@gmail.com" },
                    { "16", 0, "0317778901", "Durban", "4396fdca-75ba-4c87-b144-a34cad5e96f9", null, "ApplicationUser", "jennifer.martin@gmail.com", true, "Jennifer", true, "Martin", false, null, "JENNIFER.MARTIN@GMAIL.COM", "JENNIFER.MARTIN@GMAIL.COM", "AQAAAAIAAYagAAAAEANWJmznzlOSJGZTod4/oM7wYqE15ziTt1i/6aJgcBtu28FIRJwbPOwQ2ijYV4RbcQ==", null, false, "4001", null, "7653d95f-d7ce-4e2e-a216-af6c6f537bab", "KwaZulu-Natal", "Approved", "147 Repair Lane", false, "jennifer.martin@gmail.com" },
                    { "17", 0, "0118881234", "Johannesburg", "b1fde62e-1d89-4151-b67b-ae994991a1cd", null, "ApplicationUser", "james.miller@gmail.com", true, "James", true, "Miller", false, null, "JAMES.MILLER@GMAIL.COM", "JAMES.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEDOUCc4K8ASQQoAzHoG5eeXuIiVxRptPbS+A+20D5xI5FHRBOMXbuOg2ZG/CPliV1w==", null, false, "2001", null, "ab516331-63a6-4cf4-ba69-69375e30640b", "Gauteng", "Approved", "258 Fault Street", false, "james.miller@gmail.com" },
                    { "18", 0, "0129994567", "Pretoria", "0e14b7c3-987d-4cc6-a193-3b97e28551be", null, "ApplicationUser", "patricia.white@gmail.com", true, "Patricia", true, "White", false, null, "PATRICIA.WHITE@GMAIL.COM", "PATRICIA.WHITE@GMAIL.COM", "AQAAAAIAAYagAAAAEGYojG4ZALGa+4HwGTulx+9QZIyVSC3Z/7zHELqH67ZGOVmzJfRaRhOfV2soybwmZQ==", null, false, "0002", null, "963a831e-503c-42d2-a4b9-27a88a34045a", "Gauteng", "Approved", "369 Diagnostic Road", false, "patricia.white@gmail.com" },
                    { "2", 0, "0219876543", "Cape Town", "445a32d6-12b7-48bd-90a4-e0b7b400ed3a", null, "ApplicationUser", "sarah.johnson@gmail.com", true, "Sarah", true, "Johnson", false, null, "SARAH.JOHNSON@GMAIL.COM", "SARAH.JOHNSON@GMAIL.COM", "AQAAAAIAAYagAAAAEOoDBcWoSnqyUOTfosdMpI+VpfjL5NsxiPTTvh6UwT7G3UE1sZrlWqxwFlZSSxPb5w==", null, false, "8001", null, "b0230457-e49e-4269-8a4f-6a77e7bd8363", "Western Cape", "Approved", "456 Management Ave", false, "sarah.johnson@gmail.com" },
                    { "21", 0, "0439991234", "East London", "1cd02f9e-9108-493a-8ae3-7c23955fcdb1", null, "ApplicationUser", "william.thomas@gmail.com", true, "William", true, "Thomas", false, null, "WILLIAM.THOMAS@GMAIL.COM", "WILLIAM.THOMAS@GMAIL.COM", "AQAAAAIAAYagAAAAEHwOU+doMySCtOU0QWFL+lQHE87W5/wFK2ww8qJKFklhaUeGljaHi4ruwsXAaqU2pg==", null, false, "5201", null, "3d6b6f34-abf3-4542-90db-f5292b2734ed", "Eastern Cape", "Approved", "852 Enterprise Street", false, "william.thomas@gmail.com" },
                    { "22", 0, "0338885678", "Pietermaritzburg", "28bd9419-8154-4b56-b1c1-0f23281e6d0b", null, "ApplicationUser", "ava.robinson@gmail.com", true, "Ava", true, "Robinson", false, null, "AVA.ROBINSON@GMAIL.COM", "AVA.ROBINSON@GMAIL.COM", "AQAAAAIAAYagAAAAEF/YTXml6kuGUa6w5knOcQeT55JYGG0tYq8WgdZH2D1/JFyvWlCoP+kzJRqzYXXWDA==", null, false, "3201", null, "32e623b6-ed0d-4e9c-ad76-1c2339f3dca1", "KwaZulu-Natal", "Approved", "963 Corporate Road", false, "ava.robinson@gmail.com" },
                    { "23", 0, "0577779012", "Welkom", "fb433ca3-92bc-458f-a2eb-8dffe62eae6f", null, "ApplicationUser", "noah.clark@gmail.com", true, "Noah", true, "Clark", false, null, "NOAH.CLARK@GMAIL.COM", "NOAH.CLARK@GMAIL.COM", "AQAAAAIAAYagAAAAEFyb8uw4KMKTYmZgGAMFr24pgePmv+LZDekeXDBQ1YY3C39BUkm024a1KPS3QtIiQw==", null, false, "9460", null, "1b5f4349-8654-4862-9e0c-1780c0906013", "Free State", "Approved", "159 Business Park", false, "noah.clark@gmail.com" },
                    { "24", 0, "0136663456", "Witbank", "e795177b-910b-4fc7-b6a6-fad5f5c0243c", null, "ApplicationUser", "isabella.rodriguez@gmail.com", true, "Isabella", true, "Rodriguez", false, null, "ISABELLA.RODRIGUEZ@GMAIL.COM", "ISABELLA.RODRIGUEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEJcqqHDRkXAM+SeYyCLraQ31Wf67TraIYaJjbP8cm2Yw6X8qdheXLB/74b024vBXSw==", null, false, "1035", null, "c79c3b19-14bd-43d2-beab-f79fdc301901", "Mpumalanga", "Approved", "753 Industrial Area", false, "isabella.rodriguez@gmail.com" },
                    { "25", 0, "0117772345", "Johannesburg", "b0b6ef56-2a7b-4b94-a19b-45da817508d9", null, "ApplicationUser", "daniel.moore@gmail.com", true, "Daniel", true, "Moore", false, null, "DANIEL.MOORE@GMAIL.COM", "DANIEL.MOORE@GMAIL.COM", "AQAAAAIAAYagAAAAEAFIlfBhGHxGL6yT2wMoLLhi2s1qSFi2EEqsvddJ//KC+yuBLN95FUByuLrT+CqYTw==", null, false, "2001", null, "e810ed42-1639-4eb1-9d13-3736414f0670", "Gauteng", "Approved", "456 Service Lane", false, "daniel.moore@gmail.com" },
                    { "26", 0, "0215556789", "Cape Town", "aca490da-2727-4874-b15d-d8d4758b4339", null, "ApplicationUser", "susan.lee@gmail.com", true, "Susan", true, "Lee", false, null, "SUSAN.LEE@GMAIL.COM", "SUSAN.LEE@GMAIL.COM", "AQAAAAIAAYagAAAAEG5lD+R3BFInjqJLFdI9gRX0c48Nlt2vZhy6SKUavuXsS2sDIfntSG9ky1vp4FSpMQ==", null, false, "8001", null, "cab3f556-2de6-4e1f-a246-70fe7a00a67c", "Western Cape", "Approved", "789 Stock Avenue", false, "susan.lee@gmail.com" },
                    { "3", 0, "0315551234", "Durban", "1fe361cf-703d-400a-8196-30d9a48773a4", null, "ApplicationUser", "mike.wilson@gmail.com", true, "Mike", true, "Wilson", false, null, "MIKE.WILSON@GMAIL.COM", "MIKE.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAECdWbqNl/rju3PkcvnZY6jDWBto9+iRzWMO1mRIOH/FJnvWASFYPlgbQozKaN1IH5A==", null, false, "4001", null, "4ee63b4b-e7ff-4fe1-8d6f-f0c83b136322", "KwaZulu-Natal", "Approved", "789 Customer Road", false, "mike.wilson@gmail.com" },
                    { "4", 0, "0124445678", "Pretoria", "de152ace-2420-46b4-87b9-1e161cfd8626", null, "ApplicationUser", "lisa.brown@gmail.com", true, "Lisa", true, "Brown", false, null, "LISA.BROWN@GMAIL.COM", "LISA.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEEv6buQ+J5Q0xpAJymikijKbRlduacZVYm5paZnbJOctRmVKnfdJ+jpsetWoJsS8Vw==", null, false, "0002", null, "79553f44-3e4b-4c24-8876-93d8b91920a8", "Gauteng", "Approved", "321 Business Street", false, "lisa.brown@gmail.com" },
                    { "5", 0, "0413337890", "Port Elizabeth", "1992272f-5985-43f0-9fee-5d4f4a402c87", null, "ApplicationUser", "david.jackson@gmail.com", true, "David", true, "Jackson", false, null, "DAVID.JACKSON@GMAIL.COM", "DAVID.JACKSON@GMAIL.COM", "AQAAAAIAAYagAAAAEGja5fazGh88bmPpUuo19d9164Zb19pdYvmQYJW3NnnBVWkVjFLuUCbhjoYGAywMRg==", null, false, "6001", null, "09138177-500d-4264-8dd6-be9badf618f4", "Eastern Cape", "Approved", "654 Retail Avenue", false, "david.jackson@gmail.com" },
                    { "6", 0, "0512224567", "Bloemfontein", "9e56a471-b290-4692-96a6-dc0edf1f072d", null, "ApplicationUser", "emma.davis@gmail.com", true, "Emma", true, "Davis", false, null, "EMMA.DAVIS@GMAIL.COM", "EMMA.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEBpmkeGWz3jLsVc81/86E6ecLrYjPTLchSeAJjBZGveqwpD0VnH2bMw6vG6s0OHTWQ==", null, false, "9301", null, "31d38a9d-2b40-4635-8d44-37e6824809c3", "Free State", "Approved", "987 Commerce Road", false, "emma.davis@gmail.com" },
                    { "7", 0, "0131112345", "Nelspruit", "71166a88-0e58-466e-8ad1-c55c521294c8", null, "ApplicationUser", "robert.miller@gmail.com", true, "Robert", true, "Miller", false, null, "ROBERT.MILLER@GMAIL.COM", "ROBERT.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEEl3W+MxzJhIb7muIS+tMZh6wkxlOhJXFQvf2MK7h6ACEVSB+s9RFZEOc92o83ZeEg==", null, false, "1200", null, "abbf8b5c-7171-430e-9296-97595998de79", "Mpumalanga", "Approved", "147 Trade Street", false, "robert.miller@gmail.com" },
                    { "8", 0, "0156667890", "Polokwane", "3903bce8-b84e-4c47-bb8c-33fca8df4e3d", null, "ApplicationUser", "sophia.garcia@gmail.com", true, "Sophia", true, "Garcia", false, null, "SOPHIA.GARCIA@GMAIL.COM", "SOPHIA.GARCIA@GMAIL.COM", "AQAAAAIAAYagAAAAEGy/va4uDB58zPtirO4dINQ0boD4iHOuwpRbaWB4NePE6kiudLx/0PzmXAHj7jXcjA==", null, false, "0700", null, "0cae70b1-9edd-45bd-922b-49444b15d745", "Limpopo", "Approved", "258 Market Lane", false, "sophia.garcia@gmail.com" },
                    { "9", 0, "0537771234", "Kimberley", "9812db87-2320-4671-ae6c-72da2fe211bb", null, "ApplicationUser", "james.anderson@gmail.com", true, "James", true, "Anderson", false, null, "JAMES.ANDERSON@GMAIL.COM", "JAMES.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEN+kIMUY0X0Cafq1g3Ij5mvKhaOr+LGm4QOrF6Uyfbv9ERdQxV7dGaReinrumW/IoQ==", null, false, "8301", null, "85bc1c12-150b-46f4-9d08-49298b01b165", "Northern Cape", "Approved", "369 Industry Road", false, "james.anderson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBusinessInfo",
                columns: new[] { "BusinessID", "Address", "BusinessName", "BusinessType", "City", "Country", "CreatedAt", "Email", "Industry", "LogoData", "LogoPath", "PhoneNumber", "PostalCode", "RegistrationNumber", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "FridgeHub Enterprises", "Fridge Rental", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(966), "info@gmail.com", "Appliance Rental", null, null, "0111234567", "2000", "2024FH001", "www.fridgehub.com" },
                    { 2, "456 Service Road", "Cool Solutions SA", "Appliance Services", "Cape Town", "South Africa", new DateTime(2024, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(971), "admin@coolsolutions.co.za", "Maintenance Services", null, null, "0219876543", "8001", "2023CS002", "www.coolsolutions.co.za" },
                    { 3, "789 Coastal Road", "Fridge Rentals Durban", "Rental Services", "Durban", "South Africa", new DateTime(2025, 5, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(974), "rentals@fridgedurban.co.za", "Appliance Rental", null, null, "0315551234", "4001", "2024FR003", "www.fridgedurban.co.za" },
                    { 4, "321 Capital Avenue", "Pretoria Cooling Systems", "HVAC Services", "Pretoria", "South Africa", new DateTime(2024, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(977), "info@pretoriacooling.co.za", "Cooling Systems", null, null, "0124445678", "0002", "2023PCS004", "www.pretoriacooling.co.za" },
                    { 5, "654 Ocean View", "Eastern Cape Appliances", "Appliance Retail", "Port Elizabeth", "South Africa", new DateTime(2025, 3, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(979), "sales@ecappliances.co.za", "Retail", null, null, "0413337890", "6001", "2024ECA005", "www.ecappliances.co.za" },
                    { 6, "987 Central Street", "Free State Cooling", "Cooling Solutions", "Bloemfontein", "South Africa", new DateTime(2024, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(984), "contact@fscooling.co.za", "HVAC Services", null, null, "0512224567", "9301", "2023FSC006", "www.fscooling.co.za" },
                    { 7, "147 Highlands Road", "Mpumalanga Fridge Rentals", "Rental Services", "Nelspruit", "South Africa", new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(986), "info@mpumalangafridges.co.za", "Appliance Rental", null, null, "0131112345", "1200", "2024MFR007", "www.mpumalangafridges.co.za" },
                    { 8, "258 Bushveld Street", "Limpopo Cooling Experts", "Technical Services", "Polokwane", "South Africa", new DateTime(2024, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(989), "support@limpopocooling.co.za", "Cooling Systems", null, null, "0156667890", "0700", "2023LCE008", "www.limpopocooling.co.za" },
                    { 9, "369 Diamond Road", "Northern Cape Appliances", "Appliance Sales", "Kimberley", "South Africa", new DateTime(2025, 1, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(991), "sales@ncappliances.co.za", "Retail", null, null, "0537771234", "8301", "2024NCA009", "www.ncappliances.co.za" },
                    { 10, "741 Platinum Avenue", "North West Cooling Solutions", "Cooling Services", "Rustenburg", "South Africa", new DateTime(2024, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(994), "info@nwcooling.co.za", "HVAC Services", null, null, "0148884567", "2999", "2023NWC010", "www.nwcooling.co.za" },
                    { 11, "852 Coastal Highway", "KZN Appliance Rentals", "Rental Services", "Pietermaritzburg", "South Africa", new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(997), "rentals@kznappliances.co.za", "Appliance Rental", null, null, "0338885678", "3201", "2024KZNR011", "www.kznappliances.co.za" },
                    { 12, "963 Metro Road", "Gauteng Cooling Systems", "Technical Services", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(999), "service@gautengcooling.co.za", "Cooling Systems", null, null, "0119992345", "2001", "2023GCS012", "www.gautengcooling.co.za" }
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
                    { 1, "Good", 1, "FRG-001-001", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(7949), "Cape Town Storage", 1, null },
                    { 2, "Good", 1, "FRG-001-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(7989), "Johannesburg Main", 1, null },
                    { 3, "Good", 1, "FRG-001-003", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(7993), "Pretoria Facility", 1, null },
                    { 4, "Good", 1, "FRG-001-004", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8009), "Durban Warehouse", 1, null },
                    { 5, "Good", 1, "FRG-001-005", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8013), "Cape Town Storage", 1, null },
                    { 6, "Good", 1, "FRG-001-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8018), "Johannesburg Main", 1, null },
                    { 7, "Good", 1, "FRG-001-007", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8023), "Cape Town Storage", 1, null },
                    { 8, "Excellent", 1, "FRG-001-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8027), "Cape Town Storage", 1, null },
                    { 9, "Very Good", 1, "FRG-001-009", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8031), "Johannesburg Main", 1, null },
                    { 10, "Very Good", 1, "FRG-001-010", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8037), "Port Elizabeth Depot", 1, null },
                    { 11, "Good", 2, "FRG-002-001", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8041), "Port Elizabeth Depot", 1, null },
                    { 12, "Excellent", 2, "FRG-002-002", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8045), "Durban Warehouse", 1, null },
                    { 13, "Very Good", 2, "FRG-002-003", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8050), "Durban Warehouse", 1, null },
                    { 14, "Excellent", 2, "FRG-002-004", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8054), "Pretoria Facility", 1, null },
                    { 15, "Good", 2, "FRG-002-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8111), "Port Elizabeth Depot", 1, null },
                    { 16, "Good", 2, "FRG-002-006", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8123), "Johannesburg Main", 1, null },
                    { 17, "Excellent", 2, "FRG-002-007", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8127), "Durban Warehouse", 1, null },
                    { 18, "Excellent", 2, "FRG-002-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8131), "Cape Town Storage", 1, null },
                    { 19, "Excellent", 2, "FRG-002-009", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8136), "Cape Town Storage", 1, null },
                    { 20, "Excellent", 2, "FRG-002-010", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8140), "Port Elizabeth Depot", 1, null },
                    { 21, "Good", 3, "FRG-003-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8145), "Johannesburg Main", 1, null },
                    { 22, "Good", 3, "FRG-003-002", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8149), "Cape Town Storage", 1, null },
                    { 23, "Excellent", 3, "FRG-003-003", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8153), "Johannesburg Main", 1, null },
                    { 24, "Good", 3, "FRG-003-004", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8157), "Port Elizabeth Depot", 1, null },
                    { 25, "Excellent", 3, "FRG-003-005", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8161), "Pretoria Facility", 1, null },
                    { 26, "Good", 3, "FRG-003-006", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8165), "Durban Warehouse", 1, null },
                    { 27, "Good", 3, "FRG-003-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8169), "Port Elizabeth Depot", 1, null },
                    { 28, "Good", 3, "FRG-003-008", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8173), "Durban Warehouse", 1, null },
                    { 29, "Good", 3, "FRG-003-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8177), "Port Elizabeth Depot", 1, null },
                    { 30, "Excellent", 3, "FRG-003-010", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8218), "Cape Town Storage", 1, null },
                    { 31, "Very Good", 4, "FRG-004-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8235), "Johannesburg Main", 1, null },
                    { 32, "Good", 4, "FRG-004-002", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8239), "Durban Warehouse", 1, null },
                    { 33, "Very Good", 4, "FRG-004-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8244), "Cape Town Storage", 1, null },
                    { 34, "Excellent", 4, "FRG-004-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8249), "Durban Warehouse", 1, null },
                    { 35, "Excellent", 4, "FRG-004-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8253), "Pretoria Facility", 1, null },
                    { 36, "Very Good", 4, "FRG-004-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8257), "Durban Warehouse", 1, null },
                    { 37, "Good", 4, "FRG-004-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8261), "Cape Town Storage", 1, null },
                    { 38, "Excellent", 4, "FRG-004-008", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8265), "Port Elizabeth Depot", 1, null },
                    { 39, "Very Good", 4, "FRG-004-009", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8269), "Cape Town Storage", 1, null },
                    { 40, "Good", 4, "FRG-004-010", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8273), "Pretoria Facility", 1, null },
                    { 41, "Good", 5, "FRG-005-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8278), "Port Elizabeth Depot", 1, null },
                    { 42, "Good", 5, "FRG-005-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8282), "Durban Warehouse", 1, null },
                    { 43, "Good", 5, "FRG-005-003", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8286), "Pretoria Facility", 1, null },
                    { 44, "Good", 5, "FRG-005-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8290), "Cape Town Storage", 1, null },
                    { 45, "Good", 5, "FRG-005-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8294), "Pretoria Facility", 1, null },
                    { 46, "Excellent", 5, "FRG-005-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8298), "Johannesburg Main", 1, null },
                    { 47, "Good", 5, "FRG-005-007", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8302), "Johannesburg Main", 1, null },
                    { 48, "Very Good", 5, "FRG-005-008", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8307), "Durban Warehouse", 1, null },
                    { 49, "Excellent", 5, "FRG-005-009", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8311), "Cape Town Storage", 1, null },
                    { 50, "Good", 5, "FRG-005-010", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8315), "Port Elizabeth Depot", 1, null },
                    { 51, "Good", 6, "FRG-006-001", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8320), "Pretoria Facility", 1, null },
                    { 52, "Good", 6, "FRG-006-002", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8324), "Durban Warehouse", 1, null },
                    { 53, "Good", 6, "FRG-006-003", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8328), "Johannesburg Main", 1, null },
                    { 54, "Good", 6, "FRG-006-004", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8332), "Cape Town Storage", 1, null },
                    { 55, "Excellent", 6, "FRG-006-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8336), "Cape Town Storage", 1, null },
                    { 56, "Very Good", 6, "FRG-006-006", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8340), "Port Elizabeth Depot", 1, null },
                    { 57, "Excellent", 6, "FRG-006-007", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8344), "Durban Warehouse", 1, null },
                    { 58, "Good", 6, "FRG-006-008", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8348), "Port Elizabeth Depot", 1, null },
                    { 59, "Excellent", 6, "FRG-006-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8352), "Cape Town Storage", 1, null },
                    { 60, "Good", 6, "FRG-006-010", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8357), "Port Elizabeth Depot", 1, null },
                    { 61, "Excellent", 7, "FRG-007-001", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8361), "Port Elizabeth Depot", 1, null },
                    { 62, "Very Good", 7, "FRG-007-002", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8365), "Johannesburg Main", 1, null },
                    { 63, "Very Good", 7, "FRG-007-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8369), "Johannesburg Main", 1, null },
                    { 64, "Good", 7, "FRG-007-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8373), "Johannesburg Main", 1, null },
                    { 65, "Good", 7, "FRG-007-005", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8377), "Port Elizabeth Depot", 1, null },
                    { 66, "Good", 7, "FRG-007-006", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8382), "Cape Town Storage", 1, null },
                    { 67, "Excellent", 7, "FRG-007-007", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8386), "Cape Town Storage", 1, null },
                    { 68, "Excellent", 7, "FRG-007-008", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8390), "Port Elizabeth Depot", 1, null },
                    { 69, "Very Good", 7, "FRG-007-009", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8394), "Pretoria Facility", 1, null },
                    { 70, "Good", 7, "FRG-007-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8399), "Durban Warehouse", 1, null },
                    { 71, "Excellent", 8, "FRG-008-001", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8403), "Port Elizabeth Depot", 1, null },
                    { 72, "Excellent", 8, "FRG-008-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8407), "Cape Town Storage", 1, null },
                    { 73, "Very Good", 8, "FRG-008-003", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8411), "Cape Town Storage", 1, null },
                    { 74, "Excellent", 8, "FRG-008-004", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8415), "Cape Town Storage", 1, null },
                    { 75, "Very Good", 8, "FRG-008-005", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8419), "Cape Town Storage", 1, null },
                    { 76, "Excellent", 8, "FRG-008-006", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8423), "Cape Town Storage", 1, null },
                    { 77, "Excellent", 8, "FRG-008-007", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8427), "Pretoria Facility", 1, null },
                    { 78, "Very Good", 8, "FRG-008-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8431), "Cape Town Storage", 1, null },
                    { 79, "Excellent", 8, "FRG-008-009", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8436), "Port Elizabeth Depot", 1, null },
                    { 80, "Very Good", 8, "FRG-008-010", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8440), "Port Elizabeth Depot", 1, null },
                    { 81, "Good", 9, "FRG-009-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8444), "Pretoria Facility", 1, null },
                    { 82, "Good", 9, "FRG-009-002", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8448), "Durban Warehouse", 1, null },
                    { 83, "Good", 9, "FRG-009-003", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8452), "Port Elizabeth Depot", 1, null },
                    { 84, "Excellent", 9, "FRG-009-004", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8456), "Johannesburg Main", 1, null },
                    { 85, "Excellent", 9, "FRG-009-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8460), "Port Elizabeth Depot", 1, null },
                    { 86, "Excellent", 9, "FRG-009-006", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8470), "Durban Warehouse", 1, null },
                    { 87, "Good", 9, "FRG-009-007", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8474), "Durban Warehouse", 1, null },
                    { 88, "Excellent", 9, "FRG-009-008", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8478), "Port Elizabeth Depot", 1, null },
                    { 89, "Good", 9, "FRG-009-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8482), "Durban Warehouse", 1, null },
                    { 90, "Very Good", 9, "FRG-009-010", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8487), "Cape Town Storage", 1, null },
                    { 91, "Excellent", 10, "FRG-010-001", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8491), "Pretoria Facility", 1, null },
                    { 92, "Very Good", 10, "FRG-010-002", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8495), "Durban Warehouse", 1, null },
                    { 93, "Excellent", 10, "FRG-010-003", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8499), "Durban Warehouse", 1, null },
                    { 94, "Excellent", 10, "FRG-010-004", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8503), "Pretoria Facility", 1, null },
                    { 95, "Excellent", 10, "FRG-010-005", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8507), "Durban Warehouse", 1, null },
                    { 96, "Excellent", 10, "FRG-010-006", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8512), "Pretoria Facility", 1, null },
                    { 97, "Excellent", 10, "FRG-010-007", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8516), "Cape Town Storage", 1, null },
                    { 98, "Very Good", 10, "FRG-010-008", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8520), "Johannesburg Main", 1, null },
                    { 99, "Excellent", 10, "FRG-010-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8524), "Port Elizabeth Depot", 1, null },
                    { 100, "Excellent", 10, "FRG-010-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8528), "Cape Town Storage", 1, null },
                    { 101, "Good", 11, "FRG-011-001", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8532), "Cape Town Storage", 1, null },
                    { 102, "Very Good", 11, "FRG-011-002", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8536), "Pretoria Facility", 1, null },
                    { 103, "Excellent", 11, "FRG-011-003", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8541), "Cape Town Storage", 1, null },
                    { 104, "Good", 11, "FRG-011-004", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8545), "Pretoria Facility", 1, null },
                    { 105, "Very Good", 11, "FRG-011-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8549), "Durban Warehouse", 1, null },
                    { 106, "Good", 11, "FRG-011-006", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8553), "Cape Town Storage", 1, null },
                    { 107, "Excellent", 11, "FRG-011-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8557), "Durban Warehouse", 1, null },
                    { 108, "Very Good", 11, "FRG-011-008", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8561), "Pretoria Facility", 1, null },
                    { 109, "Good", 11, "FRG-011-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8565), "Port Elizabeth Depot", 1, null },
                    { 110, "Excellent", 11, "FRG-011-010", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8570), "Cape Town Storage", 1, null },
                    { 111, "Excellent", 12, "FRG-012-001", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8574), "Durban Warehouse", 1, null },
                    { 112, "Good", 12, "FRG-012-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8578), "Johannesburg Main", 1, null },
                    { 113, "Very Good", 12, "FRG-012-003", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8582), "Johannesburg Main", 1, null },
                    { 114, "Good", 12, "FRG-012-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8586), "Johannesburg Main", 1, null },
                    { 115, "Good", 12, "FRG-012-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8590), "Port Elizabeth Depot", 1, null },
                    { 116, "Excellent", 12, "FRG-012-006", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8595), "Pretoria Facility", 1, null },
                    { 117, "Very Good", 12, "FRG-012-007", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8599), "Johannesburg Main", 1, null },
                    { 118, "Good", 12, "FRG-012-008", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8603), "Durban Warehouse", 1, null },
                    { 119, "Excellent", 12, "FRG-012-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8607), "Port Elizabeth Depot", 1, null },
                    { 120, "Good", 12, "FRG-012-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8611), "Pretoria Facility", 1, null },
                    { 121, "Very Good", 13, "FRG-013-001", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8615), "Cape Town Storage", 1, null },
                    { 122, "Good", 13, "FRG-013-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8619), "Durban Warehouse", 1, null },
                    { 123, "Good", 13, "FRG-013-003", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8624), "Johannesburg Main", 1, null },
                    { 124, "Good", 13, "FRG-013-004", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8628), "Durban Warehouse", 1, null },
                    { 125, "Very Good", 13, "FRG-013-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8632), "Johannesburg Main", 1, null },
                    { 126, "Good", 13, "FRG-013-006", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8636), "Durban Warehouse", 1, null },
                    { 127, "Good", 13, "FRG-013-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8640), "Cape Town Storage", 1, null },
                    { 128, "Excellent", 13, "FRG-013-008", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8645), "Johannesburg Main", 1, null },
                    { 129, "Excellent", 13, "FRG-013-009", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8649), "Durban Warehouse", 1, null },
                    { 130, "Good", 13, "FRG-013-010", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8654), "Johannesburg Main", 1, null },
                    { 131, "Very Good", 14, "FRG-014-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8658), "Cape Town Storage", 1, null },
                    { 132, "Good", 14, "FRG-014-002", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8662), "Johannesburg Main", 1, null },
                    { 133, "Good", 14, "FRG-014-003", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8666), "Johannesburg Main", 1, null },
                    { 134, "Excellent", 14, "FRG-014-004", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8670), "Johannesburg Main", 1, null },
                    { 135, "Very Good", 14, "FRG-014-005", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8674), "Pretoria Facility", 1, null },
                    { 136, "Excellent", 14, "FRG-014-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8679), "Johannesburg Main", 1, null },
                    { 137, "Excellent", 14, "FRG-014-007", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8688), "Johannesburg Main", 1, null },
                    { 138, "Good", 14, "FRG-014-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8693), "Durban Warehouse", 1, null },
                    { 139, "Good", 14, "FRG-014-009", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8705), "Cape Town Storage", 1, null },
                    { 140, "Good", 14, "FRG-014-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8709), "Cape Town Storage", 1, null },
                    { 141, "Good", 15, "FRG-015-001", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8714), "Johannesburg Main", 1, null },
                    { 142, "Excellent", 15, "FRG-015-002", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8718), "Cape Town Storage", 1, null },
                    { 143, "Good", 15, "FRG-015-003", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8722), "Cape Town Storage", 1, null },
                    { 144, "Good", 15, "FRG-015-004", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8726), "Cape Town Storage", 1, null },
                    { 145, "Excellent", 15, "FRG-015-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8730), "Pretoria Facility", 1, null },
                    { 146, "Very Good", 15, "FRG-015-006", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8734), "Pretoria Facility", 1, null },
                    { 147, "Good", 15, "FRG-015-007", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8738), "Pretoria Facility", 1, null },
                    { 148, "Good", 15, "FRG-015-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8742), "Durban Warehouse", 1, null },
                    { 149, "Good", 15, "FRG-015-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8746), "Port Elizabeth Depot", 1, null },
                    { 150, "Good", 15, "FRG-015-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8750), "Port Elizabeth Depot", 1, null },
                    { 151, "Very Good", 16, "FRG-016-001", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8755), "Pretoria Facility", 1, null },
                    { 152, "Excellent", 16, "FRG-016-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8759), "Pretoria Facility", 1, null },
                    { 153, "Excellent", 16, "FRG-016-003", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8763), "Cape Town Storage", 1, null },
                    { 154, "Excellent", 16, "FRG-016-004", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8775), "Port Elizabeth Depot", 1, null },
                    { 155, "Excellent", 16, "FRG-016-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8786), "Johannesburg Main", 1, null },
                    { 156, "Good", 16, "FRG-016-006", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8791), "Pretoria Facility", 1, null },
                    { 157, "Good", 16, "FRG-016-007", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8795), "Port Elizabeth Depot", 1, null },
                    { 158, "Excellent", 16, "FRG-016-008", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8799), "Cape Town Storage", 1, null },
                    { 159, "Good", 16, "FRG-016-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8803), "Cape Town Storage", 1, null },
                    { 160, "Good", 16, "FRG-016-010", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8807), "Johannesburg Main", 1, null },
                    { 161, "Very Good", 17, "FRG-017-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8812), "Johannesburg Main", 1, null },
                    { 162, "Excellent", 17, "FRG-017-002", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8816), "Port Elizabeth Depot", 1, null },
                    { 163, "Excellent", 17, "FRG-017-003", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8820), "Durban Warehouse", 1, null },
                    { 164, "Good", 17, "FRG-017-004", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8824), "Johannesburg Main", 1, null },
                    { 165, "Good", 17, "FRG-017-005", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8836), "Durban Warehouse", 1, null },
                    { 166, "Good", 17, "FRG-017-006", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8840), "Durban Warehouse", 1, null },
                    { 167, "Excellent", 17, "FRG-017-007", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8844), "Pretoria Facility", 1, null },
                    { 168, "Excellent", 17, "FRG-017-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8848), "Durban Warehouse", 1, null },
                    { 169, "Good", 17, "FRG-017-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8852), "Durban Warehouse", 1, null },
                    { 170, "Excellent", 17, "FRG-017-010", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8856), "Port Elizabeth Depot", 1, null },
                    { 171, "Excellent", 18, "FRG-018-001", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8861), "Pretoria Facility", 1, null },
                    { 172, "Excellent", 18, "FRG-018-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8865), "Pretoria Facility", 1, null },
                    { 173, "Good", 18, "FRG-018-003", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8869), "Cape Town Storage", 1, null },
                    { 174, "Excellent", 18, "FRG-018-004", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8873), "Pretoria Facility", 1, null },
                    { 175, "Excellent", 18, "FRG-018-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8886), "Johannesburg Main", 1, null },
                    { 176, "Good", 18, "FRG-018-006", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8890), "Cape Town Storage", 1, null },
                    { 177, "Excellent", 18, "FRG-018-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8894), "Pretoria Facility", 1, null },
                    { 178, "Very Good", 18, "FRG-018-008", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8898), "Johannesburg Main", 1, null },
                    { 179, "Excellent", 18, "FRG-018-009", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8902), "Johannesburg Main", 1, null },
                    { 180, "Excellent", 18, "FRG-018-010", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8907), "Port Elizabeth Depot", 1, null },
                    { 181, "Excellent", 19, "FRG-019-001", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8911), "Cape Town Storage", 1, null },
                    { 182, "Good", 19, "FRG-019-002", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8915), "Cape Town Storage", 1, null },
                    { 183, "Very Good", 19, "FRG-019-003", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8919), "Johannesburg Main", 1, null },
                    { 184, "Good", 19, "FRG-019-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8930), "Port Elizabeth Depot", 1, null },
                    { 185, "Good", 19, "FRG-019-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8934), "Johannesburg Main", 1, null },
                    { 186, "Excellent", 19, "FRG-019-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8938), "Johannesburg Main", 1, null },
                    { 187, "Excellent", 19, "FRG-019-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8942), "Cape Town Storage", 1, null },
                    { 188, "Excellent", 19, "FRG-019-008", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8946), "Pretoria Facility", 1, null },
                    { 189, "Good", 19, "FRG-019-009", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8950), "Pretoria Facility", 1, null },
                    { 190, "Good", 19, "FRG-019-010", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8955), "Cape Town Storage", 1, null },
                    { 191, "Excellent", 20, "FRG-020-001", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8959), "Port Elizabeth Depot", 1, null },
                    { 192, "Excellent", 20, "FRG-020-002", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8963), "Pretoria Facility", 1, null },
                    { 193, "Good", 20, "FRG-020-003", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8974), "Johannesburg Main", 1, null },
                    { 194, "Good", 20, "FRG-020-004", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8979), "Port Elizabeth Depot", 1, null },
                    { 195, "Very Good", 20, "FRG-020-005", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8983), "Cape Town Storage", 1, null },
                    { 196, "Excellent", 20, "FRG-020-006", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8987), "Johannesburg Main", 1, null },
                    { 197, "Excellent", 20, "FRG-020-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8991), "Port Elizabeth Depot", 1, null },
                    { 198, "Good", 20, "FRG-020-008", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8995), "Cape Town Storage", 1, null },
                    { 199, "Excellent", 20, "FRG-020-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(8999), "Port Elizabeth Depot", 1, null },
                    { 200, "Very Good", 20, "FRG-020-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9003), "Durban Warehouse", 1, null },
                    { 201, "Excellent", 21, "FRG-021-001", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9007), "Durban Warehouse", 1, null },
                    { 202, "Excellent", 21, "FRG-021-002", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9019), "Cape Town Storage", 1, null },
                    { 203, "Very Good", 21, "FRG-021-003", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9023), "Durban Warehouse", 1, null },
                    { 204, "Good", 21, "FRG-021-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9027), "Pretoria Facility", 1, null },
                    { 205, "Good", 21, "FRG-021-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9041), "Johannesburg Main", 1, null },
                    { 206, "Good", 21, "FRG-021-006", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9045), "Cape Town Storage", 1, null },
                    { 207, "Good", 21, "FRG-021-007", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9049), "Port Elizabeth Depot", 1, null },
                    { 208, "Excellent", 21, "FRG-021-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9053), "Durban Warehouse", 1, null },
                    { 209, "Good", 21, "FRG-021-009", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9064), "Cape Town Storage", 1, null },
                    { 210, "Good", 21, "FRG-021-010", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9069), "Johannesburg Main", 1, null },
                    { 211, "Good", 22, "FRG-022-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9073), "Port Elizabeth Depot", 1, null },
                    { 212, "Excellent", 22, "FRG-022-002", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9077), "Pretoria Facility", 1, null },
                    { 213, "Good", 22, "FRG-022-003", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9081), "Johannesburg Main", 1, null },
                    { 214, "Good", 22, "FRG-022-004", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9085), "Pretoria Facility", 1, null },
                    { 215, "Very Good", 22, "FRG-022-005", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9089), "Durban Warehouse", 1, null },
                    { 216, "Good", 22, "FRG-022-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9094), "Durban Warehouse", 1, null },
                    { 217, "Excellent", 22, "FRG-022-007", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9098), "Johannesburg Main", 1, null },
                    { 218, "Excellent", 22, "FRG-022-008", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9102), "Cape Town Storage", 1, null },
                    { 219, "Good", 22, "FRG-022-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9113), "Durban Warehouse", 1, null },
                    { 220, "Very Good", 22, "FRG-022-010", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9118), "Durban Warehouse", 1, null },
                    { 221, "Good", 23, "FRG-023-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9122), "Pretoria Facility", 1, null },
                    { 222, "Good", 23, "FRG-023-002", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9126), "Durban Warehouse", 1, null },
                    { 223, "Excellent", 23, "FRG-023-003", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9130), "Durban Warehouse", 1, null },
                    { 224, "Very Good", 23, "FRG-023-004", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9134), "Cape Town Storage", 1, null },
                    { 225, "Very Good", 23, "FRG-023-005", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9138), "Port Elizabeth Depot", 1, null },
                    { 226, "Very Good", 23, "FRG-023-006", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9142), "Durban Warehouse", 1, null },
                    { 227, "Excellent", 23, "FRG-023-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9146), "Cape Town Storage", 1, null },
                    { 228, "Good", 23, "FRG-023-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9158), "Port Elizabeth Depot", 1, null },
                    { 229, "Good", 23, "FRG-023-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9162), "Durban Warehouse", 1, null },
                    { 230, "Good", 23, "FRG-023-010", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9166), "Durban Warehouse", 1, null },
                    { 231, "Very Good", 24, "FRG-024-001", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9170), "Port Elizabeth Depot", 1, null },
                    { 232, "Excellent", 24, "FRG-024-002", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9175), "Durban Warehouse", 1, null },
                    { 233, "Excellent", 24, "FRG-024-003", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9179), "Cape Town Storage", 1, null },
                    { 234, "Excellent", 24, "FRG-024-004", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9183), "Johannesburg Main", 1, null },
                    { 235, "Good", 24, "FRG-024-005", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9187), "Durban Warehouse", 1, null },
                    { 236, "Excellent", 24, "FRG-024-006", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9191), "Durban Warehouse", 1, null },
                    { 237, "Excellent", 24, "FRG-024-007", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9195), "Pretoria Facility", 1, null },
                    { 238, "Excellent", 24, "FRG-024-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9199), "Port Elizabeth Depot", 1, null },
                    { 239, "Good", 24, "FRG-024-009", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9203), "Johannesburg Main", 1, null },
                    { 240, "Excellent", 24, "FRG-024-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9207), "Durban Warehouse", 1, null },
                    { 241, "Good", 25, "FRG-025-001", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9211), "Pretoria Facility", 1, null },
                    { 242, "Very Good", 25, "FRG-025-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9216), "Port Elizabeth Depot", 1, null },
                    { 243, "Excellent", 25, "FRG-025-003", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9220), "Cape Town Storage", 1, null },
                    { 244, "Very Good", 25, "FRG-025-004", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9224), "Johannesburg Main", 1, null },
                    { 245, "Good", 25, "FRG-025-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9228), "Durban Warehouse", 1, null },
                    { 246, "Good", 25, "FRG-025-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9239), "Cape Town Storage", 1, null },
                    { 247, "Excellent", 25, "FRG-025-007", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9243), "Pretoria Facility", 1, null },
                    { 248, "Excellent", 25, "FRG-025-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9247), "Durban Warehouse", 1, null },
                    { 249, "Good", 25, "FRG-025-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9251), "Pretoria Facility", 1, null },
                    { 250, "Excellent", 25, "FRG-025-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9255), "Cape Town Storage", 1, null },
                    { 251, "Very Good", 26, "FRG-026-001", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9260), "Johannesburg Main", 1, null },
                    { 252, "Good", 26, "FRG-026-002", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9264), "Durban Warehouse", 1, null },
                    { 253, "Good", 26, "FRG-026-003", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9268), "Port Elizabeth Depot", 1, null },
                    { 254, "Good", 26, "FRG-026-004", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9272), "Pretoria Facility", 1, null },
                    { 255, "Very Good", 26, "FRG-026-005", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9277), "Port Elizabeth Depot", 1, null },
                    { 256, "Good", 26, "FRG-026-006", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9281), "Johannesburg Main", 1, null },
                    { 257, "Good", 26, "FRG-026-007", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9285), "Cape Town Storage", 1, null },
                    { 258, "Excellent", 26, "FRG-026-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9299), "Durban Warehouse", 1, null },
                    { 259, "Excellent", 26, "FRG-026-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9303), "Pretoria Facility", 1, null },
                    { 260, "Excellent", 26, "FRG-026-010", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9308), "Johannesburg Main", 1, null },
                    { 261, "Excellent", 27, "FRG-027-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9312), "Durban Warehouse", 1, null },
                    { 262, "Excellent", 27, "FRG-027-002", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9316), "Cape Town Storage", 1, null },
                    { 263, "Excellent", 27, "FRG-027-003", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9320), "Durban Warehouse", 1, null },
                    { 264, "Good", 27, "FRG-027-004", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9324), "Port Elizabeth Depot", 1, null },
                    { 265, "Excellent", 27, "FRG-027-005", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9328), "Cape Town Storage", 1, null },
                    { 266, "Good", 27, "FRG-027-006", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9332), "Cape Town Storage", 1, null },
                    { 267, "Excellent", 27, "FRG-027-007", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9337), "Port Elizabeth Depot", 1, null },
                    { 268, "Very Good", 27, "FRG-027-008", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9340), "Port Elizabeth Depot", 1, null },
                    { 269, "Excellent", 27, "FRG-027-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9345), "Pretoria Facility", 1, null },
                    { 270, "Excellent", 27, "FRG-027-010", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9350), "Durban Warehouse", 1, null },
                    { 271, "Excellent", 28, "FRG-028-001", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9354), "Durban Warehouse", 1, null },
                    { 272, "Good", 28, "FRG-028-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9358), "Johannesburg Main", 1, null },
                    { 273, "Excellent", 28, "FRG-028-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9362), "Pretoria Facility", 1, null },
                    { 274, "Excellent", 28, "FRG-028-004", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9367), "Port Elizabeth Depot", 1, null },
                    { 275, "Excellent", 28, "FRG-028-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9371), "Durban Warehouse", 1, null },
                    { 276, "Very Good", 28, "FRG-028-006", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9375), "Pretoria Facility", 1, null },
                    { 277, "Excellent", 28, "FRG-028-007", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9380), "Cape Town Storage", 1, null },
                    { 278, "Good", 28, "FRG-028-008", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9384), "Port Elizabeth Depot", 1, null },
                    { 279, "Good", 28, "FRG-028-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9389), "Port Elizabeth Depot", 1, null },
                    { 280, "Good", 28, "FRG-028-010", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9394), "Johannesburg Main", 1, null },
                    { 281, "Good", 29, "FRG-029-001", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9398), "Pretoria Facility", 1, null },
                    { 282, "Very Good", 29, "FRG-029-002", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9402), "Port Elizabeth Depot", 1, null },
                    { 283, "Good", 29, "FRG-029-003", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9407), "Johannesburg Main", 1, null },
                    { 284, "Excellent", 29, "FRG-029-004", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9410), "Durban Warehouse", 1, null },
                    { 285, "Excellent", 29, "FRG-029-005", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9415), "Durban Warehouse", 1, null },
                    { 286, "Good", 29, "FRG-029-006", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9420), "Port Elizabeth Depot", 1, null },
                    { 287, "Very Good", 29, "FRG-029-007", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9424), "Johannesburg Main", 1, null },
                    { 288, "Good", 29, "FRG-029-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9429), "Port Elizabeth Depot", 1, null },
                    { 289, "Excellent", 29, "FRG-029-009", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9433), "Durban Warehouse", 1, null },
                    { 290, "Excellent", 29, "FRG-029-010", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9438), "Pretoria Facility", 1, null },
                    { 291, "Good", 30, "FRG-030-001", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9442), "Johannesburg Main", 1, null },
                    { 292, "Excellent", 30, "FRG-030-002", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9446), "Cape Town Storage", 1, null },
                    { 293, "Good", 30, "FRG-030-003", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9450), "Pretoria Facility", 1, null },
                    { 294, "Excellent", 30, "FRG-030-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9455), "Pretoria Facility", 1, null },
                    { 295, "Excellent", 30, "FRG-030-005", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9459), "Port Elizabeth Depot", 1, null },
                    { 296, "Excellent", 30, "FRG-030-006", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9463), "Durban Warehouse", 1, null },
                    { 297, "Excellent", 30, "FRG-030-007", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9467), "Durban Warehouse", 1, null },
                    { 298, "Good", 30, "FRG-030-008", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9472), "Durban Warehouse", 1, null },
                    { 299, "Excellent", 30, "FRG-030-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9475), "Pretoria Facility", 1, null },
                    { 300, "Good", 30, "FRG-030-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9480), "Pretoria Facility", 1, null },
                    { 301, "Good", 31, "FRG-031-001", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9485), "Durban Warehouse", 1, null },
                    { 302, "Good", 31, "FRG-031-002", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9489), "Durban Warehouse", 1, null },
                    { 303, "Excellent", 31, "FRG-031-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9494), "Port Elizabeth Depot", 1, null },
                    { 304, "Excellent", 31, "FRG-031-004", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9497), "Durban Warehouse", 1, null },
                    { 305, "Very Good", 31, "FRG-031-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9501), "Johannesburg Main", 1, null },
                    { 306, "Good", 31, "FRG-031-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9506), "Johannesburg Main", 1, null },
                    { 307, "Good", 31, "FRG-031-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9515), "Port Elizabeth Depot", 1, null },
                    { 308, "Excellent", 31, "FRG-031-008", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9519), "Durban Warehouse", 1, null },
                    { 309, "Good", 31, "FRG-031-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9523), "Pretoria Facility", 1, null },
                    { 310, "Excellent", 31, "FRG-031-010", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9527), "Pretoria Facility", 1, null },
                    { 311, "Excellent", 32, "FRG-032-001", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9532), "Durban Warehouse", 1, null },
                    { 312, "Good", 32, "FRG-032-002", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9536), "Johannesburg Main", 1, null },
                    { 313, "Excellent", 32, "FRG-032-003", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9539), "Johannesburg Main", 1, null },
                    { 314, "Excellent", 32, "FRG-032-004", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9544), "Cape Town Storage", 1, null },
                    { 315, "Excellent", 32, "FRG-032-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9548), "Cape Town Storage", 1, null },
                    { 316, "Good", 32, "FRG-032-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9552), "Johannesburg Main", 1, null },
                    { 317, "Excellent", 32, "FRG-032-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9556), "Pretoria Facility", 1, null },
                    { 318, "Excellent", 32, "FRG-032-008", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9560), "Durban Warehouse", 1, null },
                    { 319, "Very Good", 32, "FRG-032-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9564), "Cape Town Storage", 1, null },
                    { 320, "Excellent", 32, "FRG-032-010", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9568), "Cape Town Storage", 1, null },
                    { 321, "Good", 33, "FRG-033-001", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9572), "Johannesburg Main", 1, null },
                    { 322, "Very Good", 33, "FRG-033-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9576), "Durban Warehouse", 1, null },
                    { 323, "Good", 33, "FRG-033-003", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9580), "Cape Town Storage", 1, null },
                    { 324, "Excellent", 33, "FRG-033-004", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9584), "Johannesburg Main", 1, null },
                    { 325, "Good", 33, "FRG-033-005", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9588), "Durban Warehouse", 1, null },
                    { 326, "Excellent", 33, "FRG-033-006", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9592), "Port Elizabeth Depot", 1, null },
                    { 327, "Excellent", 33, "FRG-033-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9596), "Durban Warehouse", 1, null },
                    { 328, "Good", 33, "FRG-033-008", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9599), "Port Elizabeth Depot", 1, null },
                    { 329, "Good", 33, "FRG-033-009", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9603), "Port Elizabeth Depot", 1, null },
                    { 330, "Good", 33, "FRG-033-010", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9607), "Johannesburg Main", 1, null },
                    { 331, "Excellent", 34, "FRG-034-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9611), "Pretoria Facility", 1, null },
                    { 332, "Excellent", 34, "FRG-034-002", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9615), "Durban Warehouse", 1, null },
                    { 333, "Good", 34, "FRG-034-003", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9619), "Port Elizabeth Depot", 1, null },
                    { 334, "Good", 34, "FRG-034-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9623), "Cape Town Storage", 1, null },
                    { 335, "Good", 34, "FRG-034-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9627), "Pretoria Facility", 1, null },
                    { 336, "Good", 34, "FRG-034-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9631), "Port Elizabeth Depot", 1, null },
                    { 337, "Good", 34, "FRG-034-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9635), "Port Elizabeth Depot", 1, null },
                    { 338, "Excellent", 34, "FRG-034-008", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9638), "Durban Warehouse", 1, null },
                    { 339, "Excellent", 34, "FRG-034-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9642), "Port Elizabeth Depot", 1, null },
                    { 340, "Excellent", 34, "FRG-034-010", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9646), "Cape Town Storage", 1, null },
                    { 341, "Good", 35, "FRG-035-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9650), "Cape Town Storage", 1, null },
                    { 342, "Excellent", 35, "FRG-035-002", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9654), "Pretoria Facility", 1, null },
                    { 343, "Very Good", 35, "FRG-035-003", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9658), "Cape Town Storage", 1, null },
                    { 344, "Excellent", 35, "FRG-035-004", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9661), "Port Elizabeth Depot", 1, null },
                    { 345, "Very Good", 35, "FRG-035-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9665), "Durban Warehouse", 1, null },
                    { 346, "Very Good", 35, "FRG-035-006", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9669), "Johannesburg Main", 1, null },
                    { 347, "Good", 35, "FRG-035-007", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9673), "Pretoria Facility", 1, null },
                    { 348, "Excellent", 35, "FRG-035-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9677), "Johannesburg Main", 1, null },
                    { 349, "Excellent", 35, "FRG-035-009", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9680), "Port Elizabeth Depot", 1, null },
                    { 350, "Very Good", 35, "FRG-035-010", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9684), "Durban Warehouse", 1, null },
                    { 351, "Excellent", 36, "FRG-036-001", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9688), "Johannesburg Main", 1, null },
                    { 352, "Very Good", 36, "FRG-036-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9692), "Cape Town Storage", 1, null },
                    { 353, "Excellent", 36, "FRG-036-003", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9696), "Cape Town Storage", 1, null },
                    { 354, "Excellent", 36, "FRG-036-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9700), "Pretoria Facility", 1, null },
                    { 355, "Very Good", 36, "FRG-036-005", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9704), "Port Elizabeth Depot", 1, null },
                    { 356, "Good", 36, "FRG-036-006", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9708), "Port Elizabeth Depot", 1, null },
                    { 357, "Excellent", 36, "FRG-036-007", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9712), "Cape Town Storage", 1, null },
                    { 358, "Good", 36, "FRG-036-008", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9715), "Pretoria Facility", 1, null },
                    { 359, "Good", 36, "FRG-036-009", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9719), "Cape Town Storage", 1, null },
                    { 360, "Good", 36, "FRG-036-010", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9723), "Cape Town Storage", 1, null },
                    { 361, "Very Good", 37, "FRG-037-001", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9727), "Durban Warehouse", 1, null },
                    { 362, "Good", 37, "FRG-037-002", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9731), "Johannesburg Main", 1, null },
                    { 363, "Very Good", 37, "FRG-037-003", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9735), "Pretoria Facility", 1, null },
                    { 364, "Excellent", 37, "FRG-037-004", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9739), "Port Elizabeth Depot", 1, null },
                    { 365, "Good", 37, "FRG-037-005", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9742), "Port Elizabeth Depot", 1, null },
                    { 366, "Good", 37, "FRG-037-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9746), "Port Elizabeth Depot", 1, null },
                    { 367, "Good", 37, "FRG-037-007", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9750), "Port Elizabeth Depot", 1, null },
                    { 368, "Good", 37, "FRG-037-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9754), "Durban Warehouse", 1, null },
                    { 369, "Very Good", 37, "FRG-037-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9758), "Johannesburg Main", 1, null },
                    { 370, "Good", 37, "FRG-037-010", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9762), "Cape Town Storage", 1, null },
                    { 371, "Very Good", 38, "FRG-038-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9766), "Durban Warehouse", 1, null },
                    { 372, "Excellent", 38, "FRG-038-002", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9770), "Port Elizabeth Depot", 1, null },
                    { 373, "Very Good", 38, "FRG-038-003", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9774), "Pretoria Facility", 1, null },
                    { 374, "Very Good", 38, "FRG-038-004", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9777), "Cape Town Storage", 1, null },
                    { 375, "Good", 38, "FRG-038-005", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9782), "Johannesburg Main", 1, null },
                    { 376, "Excellent", 38, "FRG-038-006", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9792), "Durban Warehouse", 1, null },
                    { 377, "Good", 38, "FRG-038-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9795), "Cape Town Storage", 1, null },
                    { 378, "Good", 38, "FRG-038-008", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9799), "Pretoria Facility", 1, null },
                    { 379, "Excellent", 38, "FRG-038-009", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9803), "Cape Town Storage", 1, null },
                    { 380, "Very Good", 38, "FRG-038-010", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9807), "Durban Warehouse", 1, null },
                    { 381, "Very Good", 39, "FRG-039-001", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9811), "Port Elizabeth Depot", 1, null },
                    { 382, "Excellent", 39, "FRG-039-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9815), "Durban Warehouse", 1, null },
                    { 383, "Excellent", 39, "FRG-039-003", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9819), "Cape Town Storage", 1, null },
                    { 384, "Excellent", 39, "FRG-039-004", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9823), "Pretoria Facility", 1, null },
                    { 385, "Very Good", 39, "FRG-039-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9827), "Durban Warehouse", 1, null },
                    { 386, "Good", 39, "FRG-039-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9831), "Port Elizabeth Depot", 1, null },
                    { 387, "Excellent", 39, "FRG-039-007", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9835), "Port Elizabeth Depot", 1, null },
                    { 388, "Very Good", 39, "FRG-039-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9839), "Cape Town Storage", 1, null },
                    { 389, "Good", 39, "FRG-039-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9842), "Cape Town Storage", 1, null },
                    { 390, "Very Good", 39, "FRG-039-010", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9846), "Pretoria Facility", 1, null },
                    { 391, "Very Good", 40, "FRG-040-001", false, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9850), "Pretoria Facility", 1, null },
                    { 392, "Good", 40, "FRG-040-002", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9854), "Pretoria Facility", 1, null },
                    { 393, "Good", 40, "FRG-040-003", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9858), "Port Elizabeth Depot", 1, null },
                    { 394, "Good", 40, "FRG-040-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9862), "Johannesburg Main", 1, null },
                    { 395, "Good", 40, "FRG-040-005", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9865), "Durban Warehouse", 1, null },
                    { 396, "Excellent", 40, "FRG-040-006", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9870), "Pretoria Facility", 1, null },
                    { 397, "Good", 40, "FRG-040-007", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9873), "Johannesburg Main", 1, null },
                    { 398, "Good", 40, "FRG-040-008", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9877), "Cape Town Storage", 1, null },
                    { 399, "Excellent", 40, "FRG-040-009", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9881), "Pretoria Facility", 1, null },
                    { 400, "Good", 40, "FRG-040-010", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9911), "Cape Town Storage", 1, null },
                    { 401, "Good", 41, "FRG-041-001", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9916), "Johannesburg Main", 1, null },
                    { 402, "Very Good", 41, "FRG-041-002", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9920), "Cape Town Storage", 1, null },
                    { 403, "Good", 41, "FRG-041-003", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9923), "Port Elizabeth Depot", 1, null },
                    { 404, "Excellent", 41, "FRG-041-004", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9928), "Durban Warehouse", 1, null },
                    { 405, "Excellent", 41, "FRG-041-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9931), "Port Elizabeth Depot", 1, null },
                    { 406, "Very Good", 41, "FRG-041-006", true, new DateTime(2025, 11, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9935), "Durban Warehouse", 1, null },
                    { 407, "Excellent", 41, "FRG-041-007", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9939), "Durban Warehouse", 1, null },
                    { 408, "Good", 41, "FRG-041-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9943), "Durban Warehouse", 1, null },
                    { 409, "Excellent", 41, "FRG-041-009", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9947), "Port Elizabeth Depot", 1, null },
                    { 410, "Very Good", 41, "FRG-041-010", false, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9951), "Cape Town Storage", 1, null },
                    { 411, "Good", 42, "FRG-042-001", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9955), "Johannesburg Main", 1, null },
                    { 412, "Very Good", 42, "FRG-042-002", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9958), "Cape Town Storage", 1, null },
                    { 413, "Excellent", 42, "FRG-042-003", true, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9962), "Port Elizabeth Depot", 1, null },
                    { 414, "Good", 42, "FRG-042-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9966), "Port Elizabeth Depot", 1, null },
                    { 415, "Very Good", 42, "FRG-042-005", true, new DateTime(2025, 6, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9970), "Port Elizabeth Depot", 1, null },
                    { 416, "Excellent", 42, "FRG-042-006", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9974), "Cape Town Storage", 1, null },
                    { 417, "Good", 42, "FRG-042-007", false, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9978), "Cape Town Storage", 1, null },
                    { 418, "Good", 42, "FRG-042-008", true, new DateTime(2025, 9, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9981), "Johannesburg Main", 1, null },
                    { 419, "Very Good", 42, "FRG-042-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9985), "Port Elizabeth Depot", 1, null },
                    { 420, "Excellent", 42, "FRG-042-010", false, new DateTime(2025, 10, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9989), "Cape Town Storage", 1, null },
                    { 421, "Good", 43, "FRG-043-001", true, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9993), "Port Elizabeth Depot", 1, null },
                    { 422, "Good", 43, "FRG-043-002", false, new DateTime(2025, 8, 11, 11, 30, 9, 619, DateTimeKind.Local).AddTicks(9997), "Johannesburg Main", 1, null },
                    { 423, "Good", 43, "FRG-043-003", true, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(1), "Pretoria Facility", 1, null },
                    { 424, "Good", 43, "FRG-043-004", true, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(5), "Johannesburg Main", 1, null },
                    { 425, "Very Good", 43, "FRG-043-005", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(8), "Johannesburg Main", 1, null },
                    { 426, "Good", 43, "FRG-043-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(12), "Johannesburg Main", 1, null },
                    { 427, "Very Good", 43, "FRG-043-007", false, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(16), "Durban Warehouse", 1, null },
                    { 428, "Excellent", 43, "FRG-043-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(20), "Cape Town Storage", 1, null },
                    { 429, "Excellent", 43, "FRG-043-009", true, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(24), "Cape Town Storage", 1, null },
                    { 430, "Good", 43, "FRG-043-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(28), "Cape Town Storage", 1, null },
                    { 431, "Very Good", 44, "FRG-044-001", false, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(32), "Durban Warehouse", 1, null },
                    { 432, "Good", 44, "FRG-044-002", false, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(36), "Pretoria Facility", 1, null },
                    { 433, "Excellent", 44, "FRG-044-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(39), "Durban Warehouse", 1, null },
                    { 434, "Very Good", 44, "FRG-044-004", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(43), "Johannesburg Main", 1, null },
                    { 435, "Excellent", 44, "FRG-044-005", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(47), "Johannesburg Main", 1, null },
                    { 436, "Excellent", 44, "FRG-044-006", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(51), "Cape Town Storage", 1, null },
                    { 437, "Good", 44, "FRG-044-007", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(55), "Pretoria Facility", 1, null },
                    { 438, "Good", 44, "FRG-044-008", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(59), "Johannesburg Main", 1, null },
                    { 439, "Excellent", 44, "FRG-044-009", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(62), "Pretoria Facility", 1, null },
                    { 440, "Good", 44, "FRG-044-010", true, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(66), "Johannesburg Main", 1, null },
                    { 441, "Excellent", 45, "FRG-045-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(70), "Durban Warehouse", 1, null },
                    { 442, "Excellent", 45, "FRG-045-002", true, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(74), "Johannesburg Main", 1, null },
                    { 443, "Very Good", 45, "FRG-045-003", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(78), "Port Elizabeth Depot", 1, null },
                    { 444, "Good", 45, "FRG-045-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(87), "Durban Warehouse", 1, null },
                    { 445, "Good", 45, "FRG-045-005", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(92), "Durban Warehouse", 1, null },
                    { 446, "Good", 45, "FRG-045-006", true, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(96), "Cape Town Storage", 1, null },
                    { 447, "Excellent", 45, "FRG-045-007", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(99), "Johannesburg Main", 1, null },
                    { 448, "Very Good", 45, "FRG-045-008", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(103), "Durban Warehouse", 1, null },
                    { 449, "Very Good", 45, "FRG-045-009", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(107), "Johannesburg Main", 1, null },
                    { 450, "Very Good", 45, "FRG-045-010", true, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(111), "Port Elizabeth Depot", 1, null },
                    { 451, "Very Good", 46, "FRG-046-001", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(115), "Port Elizabeth Depot", 1, null },
                    { 452, "Good", 46, "FRG-046-002", false, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(119), "Cape Town Storage", 1, null },
                    { 453, "Very Good", 46, "FRG-046-003", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(123), "Port Elizabeth Depot", 1, null },
                    { 454, "Good", 46, "FRG-046-004", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(127), "Durban Warehouse", 1, null },
                    { 455, "Very Good", 46, "FRG-046-005", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(130), "Cape Town Storage", 1, null },
                    { 456, "Good", 46, "FRG-046-006", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(134), "Johannesburg Main", 1, null },
                    { 457, "Excellent", 46, "FRG-046-007", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(138), "Cape Town Storage", 1, null },
                    { 458, "Good", 46, "FRG-046-008", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(142), "Durban Warehouse", 1, null },
                    { 459, "Excellent", 46, "FRG-046-009", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(146), "Durban Warehouse", 1, null },
                    { 460, "Very Good", 46, "FRG-046-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(150), "Pretoria Facility", 1, null },
                    { 461, "Very Good", 47, "FRG-047-001", false, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(153), "Cape Town Storage", 1, null },
                    { 462, "Excellent", 47, "FRG-047-002", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(157), "Port Elizabeth Depot", 1, null },
                    { 463, "Excellent", 47, "FRG-047-003", false, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(161), "Port Elizabeth Depot", 1, null },
                    { 464, "Excellent", 47, "FRG-047-004", true, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(165), "Pretoria Facility", 1, null },
                    { 465, "Excellent", 47, "FRG-047-005", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(169), "Cape Town Storage", 1, null },
                    { 466, "Very Good", 47, "FRG-047-006", true, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(173), "Johannesburg Main", 1, null },
                    { 467, "Good", 47, "FRG-047-007", true, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(176), "Johannesburg Main", 1, null },
                    { 468, "Excellent", 47, "FRG-047-008", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(180), "Johannesburg Main", 1, null },
                    { 469, "Good", 47, "FRG-047-009", false, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(184), "Port Elizabeth Depot", 1, null },
                    { 470, "Excellent", 47, "FRG-047-010", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(188), "Port Elizabeth Depot", 1, null },
                    { 471, "Very Good", 48, "FRG-048-001", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(192), "Johannesburg Main", 1, null },
                    { 472, "Very Good", 48, "FRG-048-002", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(196), "Johannesburg Main", 1, null },
                    { 473, "Good", 48, "FRG-048-003", false, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(199), "Port Elizabeth Depot", 1, null },
                    { 474, "Very Good", 48, "FRG-048-004", true, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(203), "Port Elizabeth Depot", 1, null },
                    { 475, "Very Good", 48, "FRG-048-005", false, new DateTime(2025, 6, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(207), "Port Elizabeth Depot", 1, null },
                    { 476, "Good", 48, "FRG-048-006", false, new DateTime(2025, 9, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(211), "Johannesburg Main", 1, null },
                    { 477, "Excellent", 48, "FRG-048-007", true, new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(215), "Port Elizabeth Depot", 1, null },
                    { 478, "Good", 48, "FRG-048-008", true, new DateTime(2025, 8, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(219), "Pretoria Facility", 1, null },
                    { 479, "Excellent", 48, "FRG-048-009", false, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(223), "Cape Town Storage", 1, null },
                    { 480, "Good", 48, "FRG-048-010", true, new DateTime(2025, 7, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(227), "Johannesburg Main", 1, null }
                });

            migrationBuilder.InsertData(
                table: "tblAllocations",
                columns: new[] { "AllocationId", "Count", "CustomerID", "FridgeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 25 },
                    { 2, 1, 7, 21 },
                    { 3, 1, 9, 4 },
                    { 4, 3, 2, 4 },
                    { 5, 1, 12, 34 },
                    { 6, 3, 10, 32 },
                    { 7, 2, 11, 23 },
                    { 8, 1, 9, 25 },
                    { 9, 2, 7, 10 },
                    { 10, 3, 12, 41 },
                    { 11, 1, 10, 3 },
                    { 12, 2, 2, 22 },
                    { 13, 2, 1, 16 },
                    { 14, 3, 4, 18 },
                    { 15, 1, 11, 26 }
                });

            migrationBuilder.InsertData(
                table: "tblFaultReports",
                columns: new[] { "FaultReportId", "CustomerId", "DeclineReason", "Description", "FaultType", "FridgeInStockId", "ImageUrl", "IsRelaunched", "IsReplacementRequested", "OriginalFaultReportId", "Priority", "ReportedDate", "RequestReplacement", "Status" },
                values: new object[,]
                {
                    { 1, 7, null, "Fault description for report 1. Issue requires attention.", "Electrical Issues", 121, "/Images/Faults/fault-1.jpg", false, true, null, "Critical", new DateTime(2025, 10, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3085), false, "Reported" },
                    { 2, 8, null, "Fault description for report 2. Issue requires attention.", "Not Cooling", 86, "/Images/Faults/fault-2.jpg", false, true, null, "Low", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3104), true, "In Progress" },
                    { 3, 8, null, "Fault description for report 3. Issue requires attention.", "Electrical Issues", 13, "/Images/Faults/fault-3.jpg", false, true, null, "Medium", new DateTime(2025, 10, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3108), true, "Declined" },
                    { 4, 9, null, "Fault description for report 4. Issue requires attention.", "Water Leakage", 95, "/Images/Faults/fault-4.jpg", false, true, null, "Medium", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3112), false, "Declined" },
                    { 5, 2, null, "Fault description for report 5. Issue requires attention.", "Strange Noises", 50, "/Images/Faults/fault-5.jpg", false, false, null, "High", new DateTime(2025, 11, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3116), false, "Declined" },
                    { 6, 3, null, "Fault description for report 6. Issue requires attention.", "Electrical Issues", 75, "/Images/Faults/fault-6.jpg", false, true, null, "Critical", new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3121), true, "Resolved" },
                    { 7, 9, null, "Fault description for report 7. Issue requires attention.", "Strange Noises", 81, "/Images/Faults/fault-7.jpg", false, true, null, "Medium", new DateTime(2025, 10, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3125), true, "Reported" },
                    { 8, 8, null, "Fault description for report 8. Issue requires attention.", "Not Cooling", 58, "/Images/Faults/fault-8.jpg", false, false, null, "High", new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3129), true, "Declined" },
                    { 9, 3, null, "Fault description for report 9. Issue requires attention.", "Door Problems", 106, "/Images/Faults/fault-9.jpg", false, false, null, "Low", new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3133), true, "Declined" },
                    { 10, 3, null, "Fault description for report 10. Issue requires attention.", "Water Leakage", 42, "/Images/Faults/fault-10.jpg", false, false, null, "Medium", new DateTime(2025, 10, 30, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3138), true, "In Progress" },
                    { 11, 1, null, "Fault description for report 11. Issue requires attention.", "Electrical Issues", 129, "/Images/Faults/fault-11.jpg", false, false, null, "High", new DateTime(2025, 10, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3143), true, "Resolved" },
                    { 12, 3, null, "Fault description for report 12. Issue requires attention.", "Door Problems", 105, "/Images/Faults/fault-12.jpg", false, true, null, "Low", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3147), true, "Resolved" },
                    { 13, 2, null, "Fault description for report 13. Issue requires attention.", "Water Leakage", 83, "/Images/Faults/fault-13.jpg", false, false, null, "Critical", new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3151), false, "Resolved" },
                    { 14, 11, null, "Fault description for report 14. Issue requires attention.", "Electrical Issues", 109, "/Images/Faults/fault-14.jpg", false, false, null, "Critical", new DateTime(2025, 10, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3155), false, "In Progress" },
                    { 15, 7, null, "Fault description for report 15. Issue requires attention.", "Electrical Issues", 121, "/Images/Faults/fault-15.jpg", false, true, null, "Medium", new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3159), true, "Declined" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestHeaders",
                columns: new[] { "RequestHeaderId", "AdditionalDescription", "AdditionalDocumentPath", "Carrier", "CellNumber", "City", "CustomerID", "DeliveryDate", "EmployeeID", "FirstName", "IsRelaunched", "LastName", "OriginalRequestId", "PaymentDueDate", "PostalCode", "RejectionDate", "RejectionReason", "RequestDate", "RequestTotal", "State", "Status", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, "0124445678", "Johannesburg", 2, null, 10, "Lisa", false, "Brown", null, null, "2592", null, null, new DateTime(2025, 9, 18, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(1211), 1386.0, "Province", "Approved", "163 Business Avenue" },
                    { 2, null, null, null, "0413337890", "Port Elizabeth", 3, new DateTime(2025, 10, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2125), 5, "David", false, "Jackson", null, new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2125), "4654", null, null, new DateTime(2025, 10, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2125), 880.0, "Province", "Closed", "54 Commerce Road" },
                    { 3, null, null, null, "0512224567", "Bloemfontein", 4, null, 10, "Emma", false, "Davis", null, null, "9261", null, null, new DateTime(2025, 9, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2138), 1278.0, "Province", "Approved", "542 Trade Street" },
                    { 4, null, null, null, "0131112345", "Pretoria", 5, new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2144), 8, "Robert", false, "Miller", null, new DateTime(2025, 11, 25, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2144), "9467", null, null, new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2144), 1201.0, "Province", "Closed", "223 Service Road" },
                    { 5, null, null, null, "0156667890", "Port Elizabeth", 6, null, 2, "Sophia", false, "Garcia", null, null, "4674", null, null, new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2149), 619.0, "Province", "Pending", "490 Trade Street" },
                    { 6, null, null, null, "0537771234", "Cape Town", 7, null, 11, "James", false, "Anderson", null, null, "1717", null, null, new DateTime(2025, 10, 20, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2160), 736.0, "Province", "Pending", "600 Business Avenue" },
                    { 7, null, null, null, "0148884567", "Port Elizabeth", 8, new DateTime(2025, 11, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2166), 12, "Olivia", false, "Martinez", null, new DateTime(2025, 12, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2166), "2497", null, null, new DateTime(2025, 11, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2166), 1010.0, "Province", "Shipped", "867 Commerce Road" },
                    { 8, null, null, null, "0439991234", "Pretoria", 9, null, 2, "William", false, "Thomas", null, null, "2657", new DateTime(2025, 9, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2171), "Payment method not approved", new DateTime(2025, 9, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2171), 836.0, "Province", "Rejected", "138 Commerce Road" },
                    { 9, null, null, null, "0338885678", "Cape Town", 10, null, 9, "Ava", false, "Robinson", null, null, "3838", new DateTime(2025, 9, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2177), "Business type not supported", new DateTime(2025, 9, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2177), 732.0, "Province", "Rejected", "47 Service Road" },
                    { 10, null, null, null, "0577779012", "Pretoria", 11, null, 4, "Noah", false, "Clark", null, null, "9984", new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2183), "Business registration not valid", new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2183), 854.0, "Province", "Rejected", "564 Trade Street" },
                    { 11, null, null, null, "0136663456", "Durban", 12, null, 2, "Isabella", false, "Rodriguez", null, null, "6572", new DateTime(2025, 10, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2188), "Credit check failed", new DateTime(2025, 9, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2188), 410.0, "Province", "Rejected", "523 Service Road" },
                    { 12, null, null, null, "0315551234", "Johannesburg", 1, new DateTime(2025, 9, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2193), 9, "Mike", false, "Wilson", null, new DateTime(2025, 10, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2193), "9042", null, null, new DateTime(2025, 9, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2193), 1353.0, "Province", "Shipped", "760 Commerce Road" },
                    { 13, null, null, null, "0124445678", "Durban", 2, new DateTime(2025, 8, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2198), 6, "Lisa", false, "Brown", null, new DateTime(2025, 9, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2198), "2701", null, null, new DateTime(2025, 8, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2198), 968.0, "Province", "Closed", "887 Service Road" },
                    { 14, null, null, null, "0413337890", "Pretoria", 3, new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2203), 6, "David", false, "Jackson", null, new DateTime(2025, 11, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2203), "5735", null, null, new DateTime(2025, 10, 24, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2203), 615.0, "Province", "Shipped", "123 Service Road" },
                    { 15, null, null, null, "0512224567", "Johannesburg", 4, null, 9, "Emma", false, "Davis", null, null, "8259", null, null, new DateTime(2025, 11, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2223), 1281.0, "Province", "Pending", "676 Main Street" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeVisits",
                columns: new[] { "VisitId", "CheckupStatus", "CreatedDate", "CustomerApproval", "Notes", "RequestHeaderId", "Status", "TechnicianName", "VisitDate", "VisitType" },
                values: new object[,]
                {
                    { 1, "Not Started", new DateTime(2025, 10, 21, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2910), "Pending", "Visit notes for service 1. Checkup completed with status: Not Started", 11, "Pending", "Robert Davis", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2910), "Maintenance Check" },
                    { 2, "Failed", new DateTime(2025, 10, 30, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2942), "Pending", "Visit notes for service 2. Checkup completed with status: Failed", 14, "Pending", "Patricia White", new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2942), "Maintenance Check" },
                    { 3, "Passed", new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2946), "Pending", "Visit notes for service 3. Checkup completed with status: Passed", 11, "Pending", "Robert Davis", new DateTime(2025, 10, 28, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2946), "Maintenance Check" },
                    { 4, "Passed", new DateTime(2025, 10, 18, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2950), "Approved", "Visit notes for service 4. Checkup completed with status: Passed", 9, "Pending", "Jennifer Martin", new DateTime(2025, 10, 19, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2950), "Maintenance Check" },
                    { 5, "In Progress", new DateTime(2025, 10, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2953), "Approved", "Visit notes for service 5. Checkup completed with status: In Progress", 2, "Pending", "James Miller", new DateTime(2025, 10, 16, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2953), "Maintenance Check" },
                    { 6, "Not Started", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2958), "Approved", "Visit notes for service 6. Checkup completed with status: Not Started", 12, "Pending", "Patricia White", new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2958), "Maintenance Check" },
                    { 7, "Failed", new DateTime(2025, 10, 24, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2961), "Approved", "Visit notes for service 7. Checkup completed with status: Failed", 15, "Pending", "Patricia White", new DateTime(2025, 10, 25, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2961), "Maintenance Check" },
                    { 8, "Not Started", new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2964), "Pending", "Visit notes for service 8. Checkup completed with status: Not Started", 3, "Pending", "Jennifer Martin", new DateTime(2025, 11, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2964), "Maintenance Check" },
                    { 9, "Not Started", new DateTime(2025, 10, 13, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2968), "Pending", "Visit notes for service 9. Checkup completed with status: Not Started", 9, "Pending", "James Miller", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2968), "Maintenance Check" },
                    { 10, "Passed", new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2972), "Pending", "Visit notes for service 10. Checkup completed with status: Passed", 7, "Pending", "Patricia White", new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2972), "Maintenance Check" },
                    { 11, "In Progress", new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2975), "Approved", "Visit notes for service 11. Checkup completed with status: In Progress", 9, "Pending", "Robert Davis", new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2975), "Maintenance Check" },
                    { 12, "Passed", new DateTime(2025, 11, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2978), "Approved", "Visit notes for service 12. Checkup completed with status: Passed", 6, "Pending", "Robert Davis", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2978), "Maintenance Check" },
                    { 13, "Not Started", new DateTime(2025, 10, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2981), "Pending", "Visit notes for service 13. Checkup completed with status: Not Started", 13, "Pending", "Robert Davis", new DateTime(2025, 10, 16, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2981), "Maintenance Check" },
                    { 14, "In Progress", new DateTime(2025, 10, 28, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2985), "Approved", "Visit notes for service 14. Checkup completed with status: In Progress", 10, "Pending", "Robert Davis", new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2985), "Maintenance Check" },
                    { 15, "Failed", new DateTime(2025, 11, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2988), "Pending", "Visit notes for service 15. Checkup completed with status: Failed", 3, "Pending", "James Miller", new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2988), "Maintenance Check" },
                    { 16, "Not Started", new DateTime(2025, 10, 21, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2993), "Pending", "Visit notes for service 16. Checkup completed with status: Not Started", 11, "Pending", "James Miller", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2993), "Maintenance Check" },
                    { 17, "In Progress", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2997), "Approved", "Visit notes for service 17. Checkup completed with status: In Progress", 3, "Pending", "Robert Davis", new DateTime(2025, 10, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2997), "Maintenance Check" },
                    { 18, "Passed", new DateTime(2025, 11, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3001), "Approved", "Visit notes for service 18. Checkup completed with status: Passed", 3, "Pending", "James Miller", new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3001), "Maintenance Check" },
                    { 19, "Not Started", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3004), "Pending", "Visit notes for service 19. Checkup completed with status: Not Started", 7, "Pending", "Jennifer Martin", new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3004), "Maintenance Check" },
                    { 20, "In Progress", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3007), "Pending", "Visit notes for service 20. Checkup completed with status: In Progress", 14, "Pending", "Jennifer Martin", new DateTime(2025, 10, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3007), "Maintenance Check" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestDetais",
                columns: new[] { "RequestDetailId", "Count", "FridgeId", "Price", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, 1, 33, 505.0, 2 },
                    { 2, 1, 25, 602.0, 3 },
                    { 3, 2, 25, 686.0, 4 },
                    { 4, 2, 18, 711.0, 5 },
                    { 5, 1, 41, 628.0, 6 },
                    { 6, 2, 1, 694.0, 7 },
                    { 7, 3, 9, 633.0, 8 },
                    { 8, 3, 1, 512.0, 9 },
                    { 9, 2, 21, 422.0, 10 },
                    { 10, 1, 23, 505.0, 11 },
                    { 11, 1, 14, 409.0, 12 },
                    { 12, 3, 27, 740.0, 13 },
                    { 13, 2, 47, 427.0, 14 },
                    { 14, 3, 38, 470.0, 15 },
                    { 15, 3, 29, 613.0, 1 },
                    { 16, 2, 12, 430.0, 2 },
                    { 17, 3, 30, 629.0, 3 },
                    { 18, 2, 19, 748.0, 4 },
                    { 19, 2, 3, 517.0, 5 },
                    { 20, 3, 32, 457.0, 6 }
                });

            migrationBuilder.InsertData(
                table: "tblRequestNotes",
                columns: new[] { "RequestNoteId", "CreatedDate", "NoteContent", "NoteType", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 20, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3617), "Note content for request 1. This is an important note regarding the service.", "Administrative", 5 },
                    { 2, new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3634), "Note content for request 2. This is an important note regarding the service.", "Administrative", 2 },
                    { 3, new DateTime(2025, 8, 21, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3637), "Note content for request 3. This is an important note regarding the service.", "Customer", 4 },
                    { 4, new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3639), "Note content for request 4. This is an important note regarding the service.", "Administrative", 8 },
                    { 5, new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3642), "Note content for request 5. This is an important note regarding the service.", "Technical", 5 },
                    { 6, new DateTime(2025, 9, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3645), "Note content for request 6. This is an important note regarding the service.", "Internal", 2 },
                    { 7, new DateTime(2025, 11, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3647), "Note content for request 7. This is an important note regarding the service.", "Internal", 4 },
                    { 8, new DateTime(2025, 8, 19, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3650), "Note content for request 8. This is an important note regarding the service.", "Administrative", 1 },
                    { 9, new DateTime(2025, 9, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3653), "Note content for request 9. This is an important note regarding the service.", "Technical", 8 },
                    { 10, new DateTime(2025, 9, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3656), "Note content for request 10. This is an important note regarding the service.", "Internal", 6 },
                    { 11, new DateTime(2025, 10, 28, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3659), "Note content for request 11. This is an important note regarding the service.", "Internal", 8 },
                    { 12, new DateTime(2025, 10, 20, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3661), "Note content for request 12. This is an important note regarding the service.", "Internal", 11 },
                    { 13, new DateTime(2025, 8, 18, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3664), "Note content for request 13. This is an important note regarding the service.", "Internal", 8 },
                    { 14, new DateTime(2025, 9, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3666), "Note content for request 14. This is an important note regarding the service.", "Administrative", 4 },
                    { 15, new DateTime(2025, 8, 28, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3669), "Note content for request 15. This is an important note regarding the service.", "Administrative", 13 },
                    { 16, new DateTime(2025, 9, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3671), "Note content for request 16. This is an important note regarding the service.", "Internal", 12 },
                    { 17, new DateTime(2025, 10, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3673), "Note content for request 17. This is an important note regarding the service.", "Internal", 4 },
                    { 18, new DateTime(2025, 10, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3683), "Note content for request 18. This is an important note regarding the service.", "Technical", 7 },
                    { 19, new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3686), "Note content for request 19. This is an important note regarding the service.", "Customer", 7 },
                    { 20, new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3688), "Note content for request 20. This is an important note regarding the service.", "Administrative", 5 }
                });

            migrationBuilder.InsertData(
                table: "tblCustomerFridge",
                columns: new[] { "CustomerFridgeId", "AllocatedDate", "CustomerID", "FridgeId", "FridgeInStockId", "RequestDetailId", "ReservedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2541), 1, 15, 335, 11, new DateTime(2025, 9, 18, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2541) },
                    { 2, new DateTime(2025, 10, 24, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2556), 7, 38, 391, 2, new DateTime(2025, 10, 20, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2556) },
                    { 3, null, 5, 45, 289, 14, new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2558) },
                    { 4, null, 8, 30, 179, 16, new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2559) },
                    { 5, new DateTime(2025, 9, 30, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2560), 2, 43, 148, 16, new DateTime(2025, 9, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2560) },
                    { 6, null, 12, 22, 198, 4, new DateTime(2025, 11, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2562) },
                    { 7, new DateTime(2025, 11, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2564), 10, 38, 471, 11, new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2564) },
                    { 8, new DateTime(2025, 10, 30, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2565), 6, 5, 176, 8, new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2565) },
                    { 9, null, 5, 4, 85, 8, new DateTime(2025, 9, 24, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2567) },
                    { 10, new DateTime(2025, 9, 25, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2569), 10, 14, 321, 2, new DateTime(2025, 9, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2569) },
                    { 11, new DateTime(2025, 9, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2570), 11, 29, 357, 6, new DateTime(2025, 9, 19, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2570) },
                    { 12, null, 2, 15, 401, 19, new DateTime(2025, 9, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2571) },
                    { 13, null, 8, 8, 286, 6, new DateTime(2025, 9, 18, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2572) },
                    { 14, new DateTime(2025, 10, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2574), 11, 37, 176, 2, new DateTime(2025, 10, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2574) },
                    { 15, null, 9, 7, 356, 12, new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2575) },
                    { 16, null, 3, 46, 144, 4, new DateTime(2025, 9, 13, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2576) },
                    { 17, null, 3, 11, 226, 3, new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2577) },
                    { 18, new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2579), 4, 15, 117, 17, new DateTime(2025, 10, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2579) },
                    { 19, new DateTime(2025, 10, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2580), 1, 42, 22, 16, new DateTime(2025, 10, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2580) },
                    { 20, new DateTime(2025, 11, 7, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2581), 1, 31, 316, 17, new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2581) },
                    { 21, new DateTime(2025, 10, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2582), 8, 24, 477, 6, new DateTime(2025, 10, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2582) },
                    { 22, null, 7, 33, 358, 11, new DateTime(2025, 10, 3, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2584) },
                    { 23, new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2592), 10, 39, 118, 9, new DateTime(2025, 11, 4, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2592) },
                    { 24, null, 9, 31, 382, 8, new DateTime(2025, 9, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2593) },
                    { 25, new DateTime(2025, 11, 13, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2594), 6, 42, 350, 18, new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(2594) }
                });

            migrationBuilder.InsertData(
                table: "tblFaultTechnicians",
                columns: new[] { "FaultId", "Bookingate", "Completion", "CreatedDate", "CustomerBookingStatus", "FaultDescription", "FaultReportId", "FaultType", "Priority", "RepairStatus", "ReportDate", "ResolutionNotes", "TechnicianAssigned", "VisitId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3230), "Pending", "Fault description for technician assignment 1", 5, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3230), null, "James Miller", 16 },
                    { 2, null, null, new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3251), "Decline", "Fault description for technician assignment 2", 6, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3251), null, "Robert Davis", 1 },
                    { 3, null, null, new DateTime(2025, 10, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3255), "Approved", "Fault description for technician assignment 3", 6, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 15, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3255), "Resolution notes for fault 3", "Patricia White", 5 },
                    { 4, null, null, new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3260), "Pending", "Fault description for technician assignment 4", 5, "Technical Fault", "Medium", "Resolved", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3260), null, "Robert Davis", 12 },
                    { 5, new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3263), null, new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3263), "Pending", "Fault description for technician assignment 5", 11, "Technical Fault", "High", "Not Started", new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3263), "Resolution notes for fault 5", "Jennifer Martin", 14 },
                    { 6, null, null, new DateTime(2025, 10, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3269), "Decline", "Fault description for technician assignment 6", 5, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 23, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3269), null, "Robert Davis", 18 },
                    { 7, new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3273), null, new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3273), "Approved", "Fault description for technician assignment 7", 11, "Technical Fault", "High", "In Progress", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3273), null, "Jennifer Martin", 11 },
                    { 8, null, null, new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3276), "Pending", "Fault description for technician assignment 8", 6, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3276), "Resolution notes for fault 8", "James Miller", 4 },
                    { 9, null, null, new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3281), "Decline", "Fault description for technician assignment 9", 3, "Technical Fault", "Medium", "Scrapped", new DateTime(2025, 11, 9, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3281), null, "Patricia White", 15 },
                    { 10, new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3286), null, new DateTime(2025, 10, 21, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3286), "Approved", "Fault description for technician assignment 10", 14, "Technical Fault", "High", "Not Started", new DateTime(2025, 10, 21, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3286), "Resolution notes for fault 10", "James Miller", 14 },
                    { 11, new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3291), null, new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3291), "Approved", "Fault description for technician assignment 11", 15, "Technical Fault", "Medium", "Not Started", new DateTime(2025, 10, 29, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3291), null, "Jennifer Martin", 20 },
                    { 12, null, null, new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3294), "Pending", "Fault description for technician assignment 12", 4, "Technical Fault", "High", "Not Started", new DateTime(2025, 11, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3294), "Resolution notes for fault 12", "Jennifer Martin", 11 },
                    { 13, null, null, new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3298), "Pending", "Fault description for technician assignment 13", 13, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 26, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3298), null, "Jennifer Martin", 13 },
                    { 14, new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3302), null, new DateTime(2025, 10, 25, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3302), "Pending", "Fault description for technician assignment 14", 9, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 25, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3302), null, "Robert Davis", 13 },
                    { 15, null, null, new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3305), "Approved", "Fault description for technician assignment 15", 13, "Technical Fault", "Medium", "Not Started", new DateTime(2025, 10, 27, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3305), "Resolution notes for fault 15", "James Miller", 2 }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeReplacements",
                columns: new[] { "FridgeReplacementId", "AdditionalNotes", "ApplicationUserId", "CustomerID", "NewFridgeInStockId", "OldFridgeNo", "ReasonForReplacement", "ReplacementDate", "ReplacementStatus", "RequestDate", "VisitId" },
                values: new object[,]
                {
                    { 1, "Additional notes for replacement request 1", "16", 3, 54, "FRG-002-009", "Old Age", new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3382), "Approved", new DateTime(2025, 10, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3382), 2 },
                    { 2, "Additional notes for replacement request 2", "3", 8, 146, "FRG-003-009", "Customer Request", new DateTime(2025, 10, 31, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3416), "Pending", new DateTime(2025, 10, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3416), 4 },
                    { 3, "Additional notes for replacement request 3", "9", 4, 28, "FRG-013-003", "Old Age", new DateTime(2025, 10, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3423), "Pending", new DateTime(2025, 10, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3423), 12 },
                    { 4, "Additional notes for replacement request 4", "11", 3, 46, "FRG-003-009", "Frequent Breakdowns", new DateTime(2025, 11, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3429), "Rejected", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3429), 15 },
                    { 5, "Additional notes for replacement request 5", "23", 1, 10, "FRG-001-009", "Old Age", new DateTime(2025, 10, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3442), "Approved", new DateTime(2025, 9, 19, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3442), 14 },
                    { 6, "Additional notes for replacement request 6", "8", 8, 41, "FRG-010-006", "Customer Request", new DateTime(2025, 11, 1, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3448), "Rejected", new DateTime(2025, 10, 14, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3448), 1 },
                    { 7, "Additional notes for replacement request 7", "11", 10, 127, "FRG-009-007", "Frequent Breakdowns", new DateTime(2025, 10, 20, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3455), "Pending", new DateTime(2025, 10, 13, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3455), 6 },
                    { 8, "Additional notes for replacement request 8", "8", 1, 138, "FRG-008-009", "Fridge Beyond Repair", new DateTime(2025, 11, 19, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3461), "Approved", new DateTime(2025, 11, 8, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3461), 5 },
                    { 9, "Additional notes for replacement request 9", "5", 4, 70, "FRG-014-007", "Old Age", new DateTime(2025, 11, 22, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3466), "Pending", new DateTime(2025, 11, 2, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3466), 10 },
                    { 10, "Additional notes for replacement request 10", "16", 2, 16, "FRG-008-001", "Old Age", new DateTime(2025, 11, 10, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3473), "Rejected", new DateTime(2025, 10, 13, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3473), 15 },
                    { 11, "Additional notes for replacement request 11", "9", 4, 105, "FRG-014-002", "Fridge Beyond Repair", new DateTime(2025, 11, 5, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3479), "Approved", new DateTime(2025, 10, 11, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3479), 4 },
                    { 12, "Additional notes for replacement request 12", "25", 2, 75, "FRG-009-002", "Old Age", new DateTime(2025, 10, 6, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3484), "Pending", new DateTime(2025, 9, 17, 11, 30, 9, 620, DateTimeKind.Local).AddTicks(3484), 9 }
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
