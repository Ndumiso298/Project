using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class initialSeedData : Migration
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
                    { "1", 0, "0111234567", "Johannesburg", "ca13d3e9-97fa-4c83-b779-e71b7ddb59df", null, "ApplicationUser", "admin@gmail.com", true, "John", true, "Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEG9/qLV5gRtPPei60Xp+tIHaPZLgfa4BhUZZJMlAWL+1TK6GJns34ZdgPfH/SHE+CA==", null, false, "2000", null, "573d4277-4aab-42b7-9ea4-02588160c4cd", "Gauteng", "Approved", "123 Admin Street", false, "admin@gmail.com" },
                    { "10", 0, "0148884567", "Rustenburg", "9d57f355-5074-4c28-82d9-263b022bfcac", null, "ApplicationUser", "olivia.martinez@gmail.com", true, "Olivia", true, "Martinez", false, null, "OLIVIA.MARTINEZ@GMAIL.COM", "OLIVIA.MARTINEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMs3a7orkNrSSXd8M8W8NXyCyJig4dipBRX5YhdUQaZLnd+ZWZ/W7Sm3A/l9HbAzbg==", null, false, "2999", null, "aba1b358-47cf-454c-875d-b9805d06b3d7", "North West", "Approved", "741 Commercial Ave", false, "olivia.martinez@gmail.com" },
                    { "11", 0, "0315551234", "Durban", "8be135b5-9c0a-4491-bd69-41bd5e8ba257", null, "ApplicationUser", "emily.wilson@gmail.com", true, "Emily", true, "Wilson", false, null, "EMILY.WILSON@GMAIL.COM", "EMILY.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEGavEAx7oJJ6NoDaTMmz/luHtGl/Jd/4cKVPKtPbZgPdHrpMwH6ZDM7ihDsz4Btj9g==", null, false, "4001", null, "45fe5d70-7da4-42b8-b5a4-0d11d5c7cf38", "KwaZulu-Natal", "Approved", "789 Support Road", false, "emily.wilson@gmail.com" },
                    { "12", 0, "0124445678", "Pretoria", "cb0e6f91-55bd-4e51-b3cf-c4fb5133bfb0", null, "ApplicationUser", "michael.brown@gmail.com", true, "Michael", true, "Brown", false, null, "MICHAEL.BROWN@GMAIL.COM", "MICHAEL.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAELwafBbI7D1Xz6Fklq/5elMHQNWcXG8EL/QK0kpEi4tgX8PJfHZvJXhtSQysXLEd2A==", null, false, "0002", null, "2f5e4df6-9dd0-432d-8be5-31b30645ae08", "Gauteng", "Approved", "321 Help Street", false, "michael.brown@gmail.com" },
                    { "13", 0, "0113337890", "Johannesburg", "9ded089d-d4ff-4b7e-9ffa-5b674b5d8da6", null, "ApplicationUser", "david.taylor@gmail.com", true, "David", true, "Taylor", false, null, "DAVID.TAYLOR@GMAIL.COM", "DAVID.TAYLOR@GMAIL.COM", "AQAAAAIAAYagAAAAEDLm9YsR6QroXN3ZWp4XnWi2AsZEZoLoE8u+Y1Ef1wybFDqg4/QnwWzPLY5c8EWz+w==", null, false, "2001", null, "f39358d2-edf2-4954-af1d-a4c0bd4f5557", "Gauteng", "Approved", "654 Warehouse Ave", false, "david.taylor@gmail.com" },
                    { "14", 0, "0216667890", "Cape Town", "7205e35c-a7e5-441f-a64a-bfbb1b5fd5ae", null, "ApplicationUser", "sarah.anderson@gmail.com", true, "Sarah", true, "Anderson", false, null, "SARAH.ANDERSON@GMAIL.COM", "SARAH.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEDkSccLZEMh+FBD2rC+D7sarm1SYWEe4VRLKOerxCrjUqY14wwalNgw4JkqYDdigJg==", null, false, "8001", null, "220436df-ee3e-43f1-bc18-5411ef4e7051", "Western Cape", "Approved", "852 Inventory Street", false, "sarah.anderson@gmail.com" },
                    { "15", 0, "0212224567", "Cape Town", "63dfe64e-cfe9-4ea6-9aaf-94aaa75e8887", null, "ApplicationUser", "robert.davis@gmail.com", true, "Robert", true, "Davis", false, null, "ROBERT.DAVIS@GMAIL.COM", "ROBERT.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEKeO9xr1KlHxrWl+LyZjWXu7wzUxqr2VNVPnu9CDFCSm1EskDI3AAWwQzyL3HEBkGg==", null, false, "8001", null, "a00304a0-e28e-4779-88d8-33fb03a72cc6", "Western Cape", "Approved", "987 Service Road", false, "robert.davis@gmail.com" },
                    { "16", 0, "0317778901", "Durban", "5e958b3a-0562-413c-9cb1-05a46cc0c98c", null, "ApplicationUser", "jennifer.martin@gmail.com", true, "Jennifer", true, "Martin", false, null, "JENNIFER.MARTIN@GMAIL.COM", "JENNIFER.MARTIN@GMAIL.COM", "AQAAAAIAAYagAAAAEH8QdXsufjBanWDoXRLOcEnrV9H9akmKq/I35zL6u/qCq212mZ5NJxxv8r6jV1djTA==", null, false, "4001", null, "a3bf211b-3aef-4d82-af6a-85b707379cf9", "KwaZulu-Natal", "Approved", "147 Repair Lane", false, "jennifer.martin@gmail.com" },
                    { "17", 0, "0118881234", "Johannesburg", "2380d8b4-9eb9-4ead-b2cc-190b3e68d172", null, "ApplicationUser", "james.miller@gmail.com", true, "James", true, "Miller", false, null, "JAMES.MILLER@GMAIL.COM", "JAMES.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAELzpQ3o+dv5WfGgX7hGQ5NsbpJmb+Wz3HuQZVszdWwlN/QA1yxpQyBapnrs54x1pxg==", null, false, "2001", null, "ee1240cb-1352-4a82-8d80-9275ae336d5c", "Gauteng", "Approved", "258 Fault Street", false, "james.miller@gmail.com" },
                    { "18", 0, "0129994567", "Pretoria", "7043f542-d716-4e54-9408-7b9eea0e2db4", null, "ApplicationUser", "patricia.white@gmail.com", true, "Patricia", true, "White", false, null, "PATRICIA.WHITE@GMAIL.COM", "PATRICIA.WHITE@GMAIL.COM", "AQAAAAIAAYagAAAAEEE4pjyvYh5D19X364nLhSxtOLnk/msfS77Xn+NUi9z4xmPKKIIOk9IJlucIoZ+1FQ==", null, false, "0002", null, "b220b2b6-1bea-4aa1-921a-33d087092436", "Gauteng", "Approved", "369 Diagnostic Road", false, "patricia.white@gmail.com" },
                    { "2", 0, "0219876543", "Cape Town", "27e90c6c-42e4-4838-9fb4-df44aed104e0", null, "ApplicationUser", "sarah.johnson@gmail.com", true, "Sarah", true, "Johnson", false, null, "SARAH.JOHNSON@GMAIL.COM", "SARAH.JOHNSON@GMAIL.COM", "AQAAAAIAAYagAAAAEOj6CaXqvrtJrs14q65ewn6oOCaWT1vfdNy5GxOeF7ugfa4F1HXzxpGKRWNSowrQxQ==", null, false, "8001", null, "8f24bf03-64a4-4bbb-82a6-041cdf4de9f5", "Western Cape", "Approved", "456 Management Ave", false, "sarah.johnson@gmail.com" },
                    { "21", 0, "0439991234", "East London", "f9b40301-84b9-46c6-a6da-e0aec4cdab98", null, "ApplicationUser", "william.thomas@gmail.com", true, "William", true, "Thomas", false, null, "WILLIAM.THOMAS@GMAIL.COM", "WILLIAM.THOMAS@GMAIL.COM", "AQAAAAIAAYagAAAAEK4RFIMs4KQFnre+sglQIYjZud6KymPEszEjnOI0saJ4B5Uv89dzkGj9dl0OVqx7SQ==", null, false, "5201", null, "46582280-ae83-4db7-9d70-f26eb5312261", "Eastern Cape", "Approved", "852 Enterprise Street", false, "william.thomas@gmail.com" },
                    { "22", 0, "0338885678", "Pietermaritzburg", "2258597c-dc91-440f-b82a-67655d305445", null, "ApplicationUser", "ava.robinson@gmail.com", true, "Ava", true, "Robinson", false, null, "AVA.ROBINSON@GMAIL.COM", "AVA.ROBINSON@GMAIL.COM", "AQAAAAIAAYagAAAAELT5joxNi+oKFLnoCu7e23FFj7u2T4P7RdHKCGbqVBu22Ld41NEjDNTRv6yjYhU+Pw==", null, false, "3201", null, "7fb5ae78-f40f-4a9b-9205-9e4fb5819cb9", "KwaZulu-Natal", "Approved", "963 Corporate Road", false, "ava.robinson@gmail.com" },
                    { "23", 0, "0577779012", "Welkom", "0b42b2ed-3268-42b2-8376-df281790b304", null, "ApplicationUser", "noah.clark@gmail.com", true, "Noah", true, "Clark", false, null, "NOAH.CLARK@GMAIL.COM", "NOAH.CLARK@GMAIL.COM", "AQAAAAIAAYagAAAAEB2+M6osaZ0eJ3oHUAyLf734G3epvjjrhnlJUg5U7Q2hrj5F2yJ3lC7bE93uMTY65w==", null, false, "9460", null, "ebc31a23-2c13-401e-92a7-8a407bf76e8f", "Free State", "Approved", "159 Business Park", false, "noah.clark@gmail.com" },
                    { "24", 0, "0136663456", "Witbank", "8a16692d-d6bd-4c4b-9c97-cc0ed076c08b", null, "ApplicationUser", "isabella.rodriguez@gmail.com", true, "Isabella", true, "Rodriguez", false, null, "ISABELLA.RODRIGUEZ@GMAIL.COM", "ISABELLA.RODRIGUEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMOa+45vZDATfb0Nfn3rKqIP3pwVctatpidq/k6rJsAypsP8BV8vwsdKKYS8LHMXEg==", null, false, "1035", null, "253bc849-fc06-42bb-bda6-675a02fdec36", "Mpumalanga", "Approved", "753 Industrial Area", false, "isabella.rodriguez@gmail.com" },
                    { "25", 0, "0117772345", "Johannesburg", "ef9691b8-6391-4fbd-bd2e-31fa1b9b6dbb", null, "ApplicationUser", "daniel.moore@gmail.com", true, "Daniel", true, "Moore", false, null, "DANIEL.MOORE@GMAIL.COM", "DANIEL.MOORE@GMAIL.COM", "AQAAAAIAAYagAAAAEIVE3fDRwkn/7xUaxXwC4pnJhw4ngB/K5IwVdSuXAthMtBL7/2oOn9cMAeYjL7r4zw==", null, false, "2001", null, "40d09bd5-37e9-4792-a4de-0ce4925d192a", "Gauteng", "Approved", "456 Service Lane", false, "daniel.moore@gmail.com" },
                    { "26", 0, "0215556789", "Cape Town", "27f6066f-9f6a-4480-b88a-6d29661b3c6f", null, "ApplicationUser", "susan.lee@gmail.com", true, "Susan", true, "Lee", false, null, "SUSAN.LEE@GMAIL.COM", "SUSAN.LEE@GMAIL.COM", "AQAAAAIAAYagAAAAEBIltLNu7dosQFR5LeJtMi1jJti6/U2eDRA2ha5kCtWuvx8fNgrRR/DD6AjSN0mdpA==", null, false, "8001", null, "f4f19b94-a6f1-4ed4-ad89-3849e413ddb3", "Western Cape", "Approved", "789 Stock Avenue", false, "susan.lee@gmail.com" },
                    { "3", 0, "0315551234", "Durban", "90f5faab-03e3-4cc5-9709-8373dc704dca", null, "ApplicationUser", "mike.wilson@gmail.com", true, "Mike", true, "Wilson", false, null, "MIKE.WILSON@GMAIL.COM", "MIKE.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEPgWxZdVA4gWbTDK6jh6FjAHPv1+XsKPq6dyDwCUAJ/sx4ZZbtoO7/GBKtbl9G1/Yg==", null, false, "4001", null, "ef8d9564-62d0-4e23-9444-ceea57499fc2", "KwaZulu-Natal", "Approved", "789 Customer Road", false, "mike.wilson@gmail.com" },
                    { "4", 0, "0124445678", "Pretoria", "025dca0a-7e32-4e0f-9ac7-d149980ae1ed", null, "ApplicationUser", "lisa.brown@gmail.com", true, "Lisa", true, "Brown", false, null, "LISA.BROWN@GMAIL.COM", "LISA.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAELGpXkg/sDoKLvzCza3t3w6yJsXanXRNNw/GpRrGBFeToJR2WyAXP3VfzCjLiU0DqQ==", null, false, "0002", null, "6b1ba10f-e9ec-467f-8a20-3cc3330f1019", "Gauteng", "Approved", "321 Business Street", false, "lisa.brown@gmail.com" },
                    { "5", 0, "0413337890", "Port Elizabeth", "57179873-7bba-44f1-9f8f-e1307b576ffc", null, "ApplicationUser", "david.jackson@gmail.com", true, "David", true, "Jackson", false, null, "DAVID.JACKSON@GMAIL.COM", "DAVID.JACKSON@GMAIL.COM", "AQAAAAIAAYagAAAAEGCMCWidHRrh4+qTb+n/6twNNBvijXGqOUbf6MCNoFBj1IjSYEeUpKSZM+zWj5Y2Dw==", null, false, "6001", null, "a6aa4c71-2b68-4d19-8b15-5b1bfeb876fb", "Eastern Cape", "Approved", "654 Retail Avenue", false, "david.jackson@gmail.com" },
                    { "6", 0, "0512224567", "Bloemfontein", "5d36b6cc-8860-4a72-b398-8cc293db149b", null, "ApplicationUser", "emma.davis@gmail.com", true, "Emma", true, "Davis", false, null, "EMMA.DAVIS@GMAIL.COM", "EMMA.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEAuWD43xyq/cwxWb9f7Kh7Uae4ku9XKP88eFLB3QcxJZnkSrUaGufn5fzq18wpm+XQ==", null, false, "9301", null, "3e5464ac-6f9f-4f09-a1b3-d64e3fc0a8bd", "Free State", "Approved", "987 Commerce Road", false, "emma.davis@gmail.com" },
                    { "7", 0, "0131112345", "Nelspruit", "3b84ef28-9905-423b-82ad-69ce4699d549", null, "ApplicationUser", "robert.miller@gmail.com", true, "Robert", true, "Miller", false, null, "ROBERT.MILLER@GMAIL.COM", "ROBERT.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEIOAqPDS9HBZ25c+xaDfUfJez8ZMvQzlSIXAczt37KdT0FEXw4ovPzY13B/9YFlx5w==", null, false, "1200", null, "7e5593da-634c-4046-afc7-7233be097a31", "Mpumalanga", "Approved", "147 Trade Street", false, "robert.miller@gmail.com" },
                    { "8", 0, "0156667890", "Polokwane", "ac94ed36-e06b-4786-831c-7e59945f240f", null, "ApplicationUser", "sophia.garcia@gmail.com", true, "Sophia", true, "Garcia", false, null, "SOPHIA.GARCIA@GMAIL.COM", "SOPHIA.GARCIA@GMAIL.COM", "AQAAAAIAAYagAAAAEMkcTyTfm9xXRgkXHLZ9VIBooA6U3Vxi8jYjeb1Ii3BaYxT7He4dOmwLPPc42Fhtpw==", null, false, "0700", null, "a175af65-0836-4343-98f3-ddeb701bc254", "Limpopo", "Approved", "258 Market Lane", false, "sophia.garcia@gmail.com" },
                    { "9", 0, "0537771234", "Kimberley", "fe18f5d5-612b-42ed-b321-907c28cd2b75", null, "ApplicationUser", "james.anderson@gmail.com", true, "James", true, "Anderson", false, null, "JAMES.ANDERSON@GMAIL.COM", "JAMES.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAELHfSYOx5iys2NU6+dPmFRAQtU6HhB6stCtAIzNeLmZIjMyeGqzAle0ZZM6nlfPTcA==", null, false, "8301", null, "b88a60fd-a628-48d2-bbec-e2c1a479ca9e", "Northern Cape", "Approved", "369 Industry Road", false, "james.anderson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBusinessInfo",
                columns: new[] { "BusinessID", "Address", "BusinessName", "BusinessType", "City", "Country", "CreatedAt", "Email", "Industry", "LogoData", "LogoPath", "PhoneNumber", "PostalCode", "RegistrationNumber", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "FridgeHub Enterprises", "Fridge Rental", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6481), "info@gmail.com", "Appliance Rental", null, null, "0111234567", "2000", "2024FH001", "www.fridgehub.com" },
                    { 2, "456 Service Road", "Cool Solutions SA", "Appliance Services", "Cape Town", "South Africa", new DateTime(2024, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6487), "admin@coolsolutions.co.za", "Maintenance Services", null, null, "0219876543", "8001", "2023CS002", "www.coolsolutions.co.za" },
                    { 3, "789 Coastal Road", "Fridge Rentals Durban", "Rental Services", "Durban", "South Africa", new DateTime(2025, 5, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6490), "rentals@fridgedurban.co.za", "Appliance Rental", null, null, "0315551234", "4001", "2024FR003", "www.fridgedurban.co.za" },
                    { 4, "321 Capital Avenue", "Pretoria Cooling Systems", "HVAC Services", "Pretoria", "South Africa", new DateTime(2024, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6493), "info@pretoriacooling.co.za", "Cooling Systems", null, null, "0124445678", "0002", "2023PCS004", "www.pretoriacooling.co.za" },
                    { 5, "654 Ocean View", "Eastern Cape Appliances", "Appliance Retail", "Port Elizabeth", "South Africa", new DateTime(2025, 3, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6495), "sales@ecappliances.co.za", "Retail", null, null, "0413337890", "6001", "2024ECA005", "www.ecappliances.co.za" },
                    { 6, "987 Central Street", "Free State Cooling", "Cooling Solutions", "Bloemfontein", "South Africa", new DateTime(2024, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6497), "contact@fscooling.co.za", "HVAC Services", null, null, "0512224567", "9301", "2023FSC006", "www.fscooling.co.za" },
                    { 7, "147 Highlands Road", "Mpumalanga Fridge Rentals", "Rental Services", "Nelspruit", "South Africa", new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6500), "info@mpumalangafridges.co.za", "Appliance Rental", null, null, "0131112345", "1200", "2024MFR007", "www.mpumalangafridges.co.za" },
                    { 8, "258 Bushveld Street", "Limpopo Cooling Experts", "Technical Services", "Polokwane", "South Africa", new DateTime(2024, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6502), "support@limpopocooling.co.za", "Cooling Systems", null, null, "0156667890", "0700", "2023LCE008", "www.limpopocooling.co.za" },
                    { 9, "369 Diamond Road", "Northern Cape Appliances", "Appliance Sales", "Kimberley", "South Africa", new DateTime(2025, 1, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6505), "sales@ncappliances.co.za", "Retail", null, null, "0537771234", "8301", "2024NCA009", "www.ncappliances.co.za" },
                    { 10, "741 Platinum Avenue", "North West Cooling Solutions", "Cooling Services", "Rustenburg", "South Africa", new DateTime(2024, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6507), "info@nwcooling.co.za", "HVAC Services", null, null, "0148884567", "2999", "2023NWC010", "www.nwcooling.co.za" },
                    { 11, "852 Coastal Highway", "KZN Appliance Rentals", "Rental Services", "Pietermaritzburg", "South Africa", new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6510), "rentals@kznappliances.co.za", "Appliance Rental", null, null, "0338885678", "3201", "2024KZNR011", "www.kznappliances.co.za" },
                    { 12, "963 Metro Road", "Gauteng Cooling Systems", "Technical Services", "Johannesburg", "South Africa", new DateTime(2023, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6512), "service@gautengcooling.co.za", "Cooling Systems", null, null, "0119992345", "2001", "2023GCS012", "www.gautengcooling.co.za" }
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
                columns: new[] { "FridgeInStockId", "Condition", "FridgeId", "FridgeNo", "IsAvailable", "LastMaintenanceDate", "Location", "Quantity", "RequestDetailsRequestDetailId", "Status" },
                values: new object[,]
                {
                    { 1, "Excellent", 1, "FRG-001-001", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2678), "Cape Town Storage", 1, null, "Available" },
                    { 2, "Good", 1, "FRG-001-002", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2724), "Port Elizabeth Depot", 1, null, "Available" },
                    { 3, "Good", 1, "FRG-001-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2729), "Durban Warehouse", 1, null, "Available" },
                    { 4, "Good", 1, "FRG-001-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2733), "Port Elizabeth Depot", 1, null, "Available" },
                    { 5, "Good", 1, "FRG-001-005", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2737), "Johannesburg Main", 1, null, "Available" },
                    { 6, "Excellent", 1, "FRG-001-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2743), "Cape Town Storage", 1, null, "Available" },
                    { 7, "Very Good", 1, "FRG-001-007", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2747), "Port Elizabeth Depot", 1, null, "Available" },
                    { 8, "Good", 1, "FRG-001-008", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2751), "Cape Town Storage", 1, null, "Available" },
                    { 9, "Excellent", 1, "FRG-001-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2755), "Port Elizabeth Depot", 1, null, "Available" },
                    { 10, "Good", 1, "FRG-001-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2761), "Pretoria Facility", 1, null, "Available" },
                    { 11, "Excellent", 2, "FRG-002-001", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2766), "Johannesburg Main", 1, null, "Available" },
                    { 12, "Excellent", 2, "FRG-002-002", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2770), "Port Elizabeth Depot", 1, null, "Available" },
                    { 13, "Good", 2, "FRG-002-003", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2774), "Port Elizabeth Depot", 1, null, "Available" },
                    { 14, "Good", 2, "FRG-002-004", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2778), "Pretoria Facility", 1, null, "Available" },
                    { 15, "Excellent", 2, "FRG-002-005", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2839), "Pretoria Facility", 1, null, "Available" },
                    { 16, "Very Good", 2, "FRG-002-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2851), "Cape Town Storage", 1, null, "Available" },
                    { 17, "Excellent", 2, "FRG-002-007", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2856), "Cape Town Storage", 1, null, "Available" },
                    { 18, "Very Good", 2, "FRG-002-008", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2861), "Port Elizabeth Depot", 1, null, "Available" },
                    { 19, "Excellent", 2, "FRG-002-009", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2865), "Cape Town Storage", 1, null, "Available" },
                    { 20, "Excellent", 2, "FRG-002-010", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2869), "Cape Town Storage", 1, null, "Available" },
                    { 21, "Good", 3, "FRG-003-001", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2873), "Pretoria Facility", 1, null, "Available" },
                    { 22, "Very Good", 3, "FRG-003-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2877), "Port Elizabeth Depot", 1, null, "Available" },
                    { 23, "Good", 3, "FRG-003-003", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2881), "Port Elizabeth Depot", 1, null, "Available" },
                    { 24, "Excellent", 3, "FRG-003-004", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2894), "Port Elizabeth Depot", 1, null, "Available" },
                    { 25, "Good", 3, "FRG-003-005", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2899), "Pretoria Facility", 1, null, "Available" },
                    { 26, "Excellent", 3, "FRG-003-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2903), "Durban Warehouse", 1, null, "Available" },
                    { 27, "Very Good", 3, "FRG-003-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2907), "Durban Warehouse", 1, null, "Available" },
                    { 28, "Very Good", 3, "FRG-003-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2911), "Durban Warehouse", 1, null, "Available" },
                    { 29, "Very Good", 3, "FRG-003-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2915), "Pretoria Facility", 1, null, "Available" },
                    { 30, "Good", 3, "FRG-003-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2968), "Cape Town Storage", 1, null, "Available" },
                    { 31, "Excellent", 4, "FRG-004-001", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2987), "Pretoria Facility", 1, null, "Available" },
                    { 32, "Excellent", 4, "FRG-004-002", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2991), "Port Elizabeth Depot", 1, null, "Available" },
                    { 33, "Good", 4, "FRG-004-003", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(2995), "Pretoria Facility", 1, null, "Available" },
                    { 34, "Excellent", 4, "FRG-004-004", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3000), "Johannesburg Main", 1, null, "Available" },
                    { 35, "Good", 4, "FRG-004-005", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3004), "Durban Warehouse", 1, null, "Available" },
                    { 36, "Excellent", 4, "FRG-004-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3008), "Johannesburg Main", 1, null, "Available" },
                    { 37, "Excellent", 4, "FRG-004-007", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3012), "Port Elizabeth Depot", 1, null, "Available" },
                    { 38, "Excellent", 4, "FRG-004-008", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3017), "Pretoria Facility", 1, null, "Available" },
                    { 39, "Good", 4, "FRG-004-009", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3021), "Pretoria Facility", 1, null, "Available" },
                    { 40, "Excellent", 4, "FRG-004-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3025), "Cape Town Storage", 1, null, "Available" },
                    { 41, "Excellent", 5, "FRG-005-001", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3029), "Durban Warehouse", 1, null, "Available" },
                    { 42, "Good", 5, "FRG-005-002", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3034), "Pretoria Facility", 1, null, "Available" },
                    { 43, "Good", 5, "FRG-005-003", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3038), "Port Elizabeth Depot", 1, null, "Available" },
                    { 44, "Excellent", 5, "FRG-005-004", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3042), "Port Elizabeth Depot", 1, null, "Available" },
                    { 45, "Good", 5, "FRG-005-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3046), "Johannesburg Main", 1, null, "Available" },
                    { 46, "Very Good", 5, "FRG-005-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3050), "Durban Warehouse", 1, null, "Available" },
                    { 47, "Excellent", 5, "FRG-005-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3054), "Pretoria Facility", 1, null, "Available" },
                    { 48, "Good", 5, "FRG-005-008", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3058), "Johannesburg Main", 1, null, "Available" },
                    { 49, "Good", 5, "FRG-005-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3063), "Cape Town Storage", 1, null, "Available" },
                    { 50, "Good", 5, "FRG-005-010", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3067), "Pretoria Facility", 1, null, "Available" },
                    { 51, "Excellent", 6, "FRG-006-001", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3071), "Johannesburg Main", 1, null, "Available" },
                    { 52, "Excellent", 6, "FRG-006-002", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3075), "Durban Warehouse", 1, null, "Available" },
                    { 53, "Excellent", 6, "FRG-006-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3079), "Johannesburg Main", 1, null, "Available" },
                    { 54, "Excellent", 6, "FRG-006-004", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3084), "Durban Warehouse", 1, null, "Available" },
                    { 55, "Excellent", 6, "FRG-006-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3088), "Cape Town Storage", 1, null, "Available" },
                    { 56, "Very Good", 6, "FRG-006-006", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3092), "Cape Town Storage", 1, null, "Available" },
                    { 57, "Good", 6, "FRG-006-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3096), "Pretoria Facility", 1, null, "Available" },
                    { 58, "Excellent", 6, "FRG-006-008", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3100), "Johannesburg Main", 1, null, "Available" },
                    { 59, "Very Good", 6, "FRG-006-009", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3104), "Pretoria Facility", 1, null, "Available" },
                    { 60, "Good", 6, "FRG-006-010", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3109), "Pretoria Facility", 1, null, "Available" },
                    { 61, "Excellent", 7, "FRG-007-001", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3113), "Cape Town Storage", 1, null, "Available" },
                    { 62, "Excellent", 7, "FRG-007-002", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3117), "Port Elizabeth Depot", 1, null, "Available" },
                    { 63, "Very Good", 7, "FRG-007-003", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3121), "Cape Town Storage", 1, null, "Available" },
                    { 64, "Excellent", 7, "FRG-007-004", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3125), "Port Elizabeth Depot", 1, null, "Available" },
                    { 65, "Very Good", 7, "FRG-007-005", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3130), "Cape Town Storage", 1, null, "Available" },
                    { 66, "Excellent", 7, "FRG-007-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3135), "Johannesburg Main", 1, null, "Available" },
                    { 67, "Excellent", 7, "FRG-007-007", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3139), "Durban Warehouse", 1, null, "Available" },
                    { 68, "Excellent", 7, "FRG-007-008", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3143), "Durban Warehouse", 1, null, "Available" },
                    { 69, "Good", 7, "FRG-007-009", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3147), "Port Elizabeth Depot", 1, null, "Available" },
                    { 70, "Good", 7, "FRG-007-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3151), "Durban Warehouse", 1, null, "Available" },
                    { 71, "Very Good", 8, "FRG-008-001", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3155), "Port Elizabeth Depot", 1, null, "Available" },
                    { 72, "Good", 8, "FRG-008-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3159), "Port Elizabeth Depot", 1, null, "Available" },
                    { 73, "Excellent", 8, "FRG-008-003", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3163), "Durban Warehouse", 1, null, "Available" },
                    { 74, "Good", 8, "FRG-008-004", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3167), "Pretoria Facility", 1, null, "Available" },
                    { 75, "Good", 8, "FRG-008-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3179), "Cape Town Storage", 1, null, "Available" },
                    { 76, "Good", 8, "FRG-008-006", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3183), "Pretoria Facility", 1, null, "Available" },
                    { 77, "Excellent", 8, "FRG-008-007", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3187), "Port Elizabeth Depot", 1, null, "Available" },
                    { 78, "Very Good", 8, "FRG-008-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3191), "Port Elizabeth Depot", 1, null, "Available" },
                    { 79, "Good", 8, "FRG-008-009", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3196), "Port Elizabeth Depot", 1, null, "Available" },
                    { 80, "Excellent", 8, "FRG-008-010", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3200), "Pretoria Facility", 1, null, "Available" },
                    { 81, "Good", 9, "FRG-009-001", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3204), "Pretoria Facility", 1, null, "Available" },
                    { 82, "Excellent", 9, "FRG-009-002", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3208), "Durban Warehouse", 1, null, "Available" },
                    { 83, "Good", 9, "FRG-009-003", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3213), "Pretoria Facility", 1, null, "Available" },
                    { 84, "Excellent", 9, "FRG-009-004", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3217), "Durban Warehouse", 1, null, "Available" },
                    { 85, "Very Good", 9, "FRG-009-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3221), "Port Elizabeth Depot", 1, null, "Available" },
                    { 86, "Good", 9, "FRG-009-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3225), "Cape Town Storage", 1, null, "Available" },
                    { 87, "Good", 9, "FRG-009-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3229), "Johannesburg Main", 1, null, "Available" },
                    { 88, "Very Good", 9, "FRG-009-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3233), "Johannesburg Main", 1, null, "Available" },
                    { 89, "Good", 9, "FRG-009-009", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3237), "Johannesburg Main", 1, null, "Available" },
                    { 90, "Good", 9, "FRG-009-010", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3242), "Port Elizabeth Depot", 1, null, "Available" },
                    { 91, "Excellent", 10, "FRG-010-001", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3246), "Pretoria Facility", 1, null, "Available" },
                    { 92, "Very Good", 10, "FRG-010-002", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3250), "Pretoria Facility", 1, null, "Available" },
                    { 93, "Good", 10, "FRG-010-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3254), "Port Elizabeth Depot", 1, null, "Available" },
                    { 94, "Excellent", 10, "FRG-010-004", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3259), "Durban Warehouse", 1, null, "Available" },
                    { 95, "Good", 10, "FRG-010-005", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3263), "Johannesburg Main", 1, null, "Available" },
                    { 96, "Good", 10, "FRG-010-006", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3267), "Cape Town Storage", 1, null, "Available" },
                    { 97, "Excellent", 10, "FRG-010-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3271), "Durban Warehouse", 1, null, "Available" },
                    { 98, "Good", 10, "FRG-010-008", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3275), "Port Elizabeth Depot", 1, null, "Available" },
                    { 99, "Good", 10, "FRG-010-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3279), "Port Elizabeth Depot", 1, null, "Available" },
                    { 100, "Very Good", 10, "FRG-010-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3284), "Durban Warehouse", 1, null, "Available" },
                    { 101, "Good", 11, "FRG-011-001", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3288), "Port Elizabeth Depot", 1, null, "Available" },
                    { 102, "Excellent", 11, "FRG-011-002", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3292), "Port Elizabeth Depot", 1, null, "Available" },
                    { 103, "Good", 11, "FRG-011-003", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3296), "Port Elizabeth Depot", 1, null, "Available" },
                    { 104, "Very Good", 11, "FRG-011-004", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3301), "Pretoria Facility", 1, null, "Available" },
                    { 105, "Excellent", 11, "FRG-011-005", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3305), "Pretoria Facility", 1, null, "Available" },
                    { 106, "Very Good", 11, "FRG-011-006", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3309), "Cape Town Storage", 1, null, "Available" },
                    { 107, "Good", 11, "FRG-011-007", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3313), "Cape Town Storage", 1, null, "Available" },
                    { 108, "Very Good", 11, "FRG-011-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3317), "Pretoria Facility", 1, null, "Available" },
                    { 109, "Excellent", 11, "FRG-011-009", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3321), "Port Elizabeth Depot", 1, null, "Available" },
                    { 110, "Very Good", 11, "FRG-011-010", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3326), "Johannesburg Main", 1, null, "Available" },
                    { 111, "Excellent", 12, "FRG-012-001", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3330), "Durban Warehouse", 1, null, "Available" },
                    { 112, "Excellent", 12, "FRG-012-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3334), "Durban Warehouse", 1, null, "Available" },
                    { 113, "Very Good", 12, "FRG-012-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3338), "Cape Town Storage", 1, null, "Available" },
                    { 114, "Good", 12, "FRG-012-004", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3342), "Durban Warehouse", 1, null, "Available" },
                    { 115, "Excellent", 12, "FRG-012-005", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3347), "Durban Warehouse", 1, null, "Available" },
                    { 116, "Excellent", 12, "FRG-012-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3351), "Cape Town Storage", 1, null, "Available" },
                    { 117, "Very Good", 12, "FRG-012-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3355), "Durban Warehouse", 1, null, "Available" },
                    { 118, "Excellent", 12, "FRG-012-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3360), "Johannesburg Main", 1, null, "Available" },
                    { 119, "Very Good", 12, "FRG-012-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3364), "Pretoria Facility", 1, null, "Available" },
                    { 120, "Good", 12, "FRG-012-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3368), "Cape Town Storage", 1, null, "Available" },
                    { 121, "Good", 13, "FRG-013-001", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3372), "Johannesburg Main", 1, null, "Available" },
                    { 122, "Excellent", 13, "FRG-013-002", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3377), "Cape Town Storage", 1, null, "Available" },
                    { 123, "Good", 13, "FRG-013-003", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3381), "Johannesburg Main", 1, null, "Available" },
                    { 124, "Excellent", 13, "FRG-013-004", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3385), "Johannesburg Main", 1, null, "Available" },
                    { 125, "Excellent", 13, "FRG-013-005", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3389), "Johannesburg Main", 1, null, "Available" },
                    { 126, "Good", 13, "FRG-013-006", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3393), "Durban Warehouse", 1, null, "Available" },
                    { 127, "Very Good", 13, "FRG-013-007", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3397), "Cape Town Storage", 1, null, "Available" },
                    { 128, "Good", 13, "FRG-013-008", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3402), "Port Elizabeth Depot", 1, null, "Available" },
                    { 129, "Good", 13, "FRG-013-009", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3406), "Pretoria Facility", 1, null, "Available" },
                    { 130, "Very Good", 13, "FRG-013-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3420), "Port Elizabeth Depot", 1, null, "Available" },
                    { 131, "Excellent", 14, "FRG-014-001", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3424), "Durban Warehouse", 1, null, "Available" },
                    { 132, "Very Good", 14, "FRG-014-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3428), "Pretoria Facility", 1, null, "Available" },
                    { 133, "Very Good", 14, "FRG-014-003", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3433), "Johannesburg Main", 1, null, "Available" },
                    { 134, "Good", 14, "FRG-014-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3437), "Johannesburg Main", 1, null, "Available" },
                    { 135, "Excellent", 14, "FRG-014-005", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3441), "Port Elizabeth Depot", 1, null, "Available" },
                    { 136, "Excellent", 14, "FRG-014-006", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3445), "Cape Town Storage", 1, null, "Available" },
                    { 137, "Good", 14, "FRG-014-007", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3450), "Cape Town Storage", 1, null, "Available" },
                    { 138, "Excellent", 14, "FRG-014-008", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3454), "Pretoria Facility", 1, null, "Available" },
                    { 139, "Very Good", 14, "FRG-014-009", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3458), "Port Elizabeth Depot", 1, null, "Available" },
                    { 140, "Very Good", 14, "FRG-014-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3463), "Pretoria Facility", 1, null, "Available" },
                    { 141, "Good", 15, "FRG-015-001", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3467), "Pretoria Facility", 1, null, "Available" },
                    { 142, "Excellent", 15, "FRG-015-002", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3471), "Johannesburg Main", 1, null, "Available" },
                    { 143, "Excellent", 15, "FRG-015-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3475), "Port Elizabeth Depot", 1, null, "Available" },
                    { 144, "Excellent", 15, "FRG-015-004", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3479), "Port Elizabeth Depot", 1, null, "Available" },
                    { 145, "Very Good", 15, "FRG-015-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3483), "Pretoria Facility", 1, null, "Available" },
                    { 146, "Excellent", 15, "FRG-015-006", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3488), "Cape Town Storage", 1, null, "Available" },
                    { 147, "Excellent", 15, "FRG-015-007", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3492), "Johannesburg Main", 1, null, "Available" },
                    { 148, "Excellent", 15, "FRG-015-008", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3496), "Cape Town Storage", 1, null, "Available" },
                    { 149, "Excellent", 15, "FRG-015-009", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3500), "Port Elizabeth Depot", 1, null, "Available" },
                    { 150, "Excellent", 15, "FRG-015-010", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3505), "Cape Town Storage", 1, null, "Available" },
                    { 151, "Good", 16, "FRG-016-001", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3509), "Pretoria Facility", 1, null, "Available" },
                    { 152, "Very Good", 16, "FRG-016-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3513), "Cape Town Storage", 1, null, "Available" },
                    { 153, "Excellent", 16, "FRG-016-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3517), "Johannesburg Main", 1, null, "Available" },
                    { 154, "Excellent", 16, "FRG-016-004", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3522), "Cape Town Storage", 1, null, "Available" },
                    { 155, "Excellent", 16, "FRG-016-005", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3526), "Johannesburg Main", 1, null, "Available" },
                    { 156, "Good", 16, "FRG-016-006", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3530), "Pretoria Facility", 1, null, "Available" },
                    { 157, "Excellent", 16, "FRG-016-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3534), "Cape Town Storage", 1, null, "Available" },
                    { 158, "Good", 16, "FRG-016-008", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3538), "Cape Town Storage", 1, null, "Available" },
                    { 159, "Very Good", 16, "FRG-016-009", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3543), "Durban Warehouse", 1, null, "Available" },
                    { 160, "Excellent", 16, "FRG-016-010", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3547), "Johannesburg Main", 1, null, "Available" },
                    { 161, "Good", 17, "FRG-017-001", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3551), "Johannesburg Main", 1, null, "Available" },
                    { 162, "Excellent", 17, "FRG-017-002", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3555), "Cape Town Storage", 1, null, "Available" },
                    { 163, "Very Good", 17, "FRG-017-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3559), "Pretoria Facility", 1, null, "Available" },
                    { 164, "Good", 17, "FRG-017-004", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3564), "Port Elizabeth Depot", 1, null, "Available" },
                    { 165, "Excellent", 17, "FRG-017-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3568), "Johannesburg Main", 1, null, "Available" },
                    { 166, "Excellent", 17, "FRG-017-006", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3572), "Pretoria Facility", 1, null, "Available" },
                    { 167, "Good", 17, "FRG-017-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3576), "Durban Warehouse", 1, null, "Available" },
                    { 168, "Very Good", 17, "FRG-017-008", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3580), "Johannesburg Main", 1, null, "Available" },
                    { 169, "Very Good", 17, "FRG-017-009", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3584), "Pretoria Facility", 1, null, "Available" },
                    { 170, "Excellent", 17, "FRG-017-010", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3588), "Durban Warehouse", 1, null, "Available" },
                    { 171, "Very Good", 18, "FRG-018-001", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3593), "Durban Warehouse", 1, null, "Available" },
                    { 172, "Good", 18, "FRG-018-002", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3597), "Johannesburg Main", 1, null, "Available" },
                    { 173, "Excellent", 18, "FRG-018-003", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3601), "Port Elizabeth Depot", 1, null, "Available" },
                    { 174, "Good", 18, "FRG-018-004", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3606), "Cape Town Storage", 1, null, "Available" },
                    { 175, "Good", 18, "FRG-018-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3610), "Johannesburg Main", 1, null, "Available" },
                    { 176, "Good", 18, "FRG-018-006", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3614), "Port Elizabeth Depot", 1, null, "Available" },
                    { 177, "Good", 18, "FRG-018-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3618), "Cape Town Storage", 1, null, "Available" },
                    { 178, "Excellent", 18, "FRG-018-008", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3622), "Durban Warehouse", 1, null, "Available" },
                    { 179, "Very Good", 18, "FRG-018-009", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3627), "Port Elizabeth Depot", 1, null, "Available" },
                    { 180, "Very Good", 18, "FRG-018-010", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3631), "Johannesburg Main", 1, null, "Available" },
                    { 181, "Good", 19, "FRG-019-001", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3635), "Johannesburg Main", 1, null, "Available" },
                    { 182, "Excellent", 19, "FRG-019-002", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3639), "Pretoria Facility", 1, null, "Available" },
                    { 183, "Very Good", 19, "FRG-019-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3643), "Cape Town Storage", 1, null, "Available" },
                    { 184, "Very Good", 19, "FRG-019-004", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3648), "Pretoria Facility", 1, null, "Available" },
                    { 185, "Excellent", 19, "FRG-019-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3652), "Durban Warehouse", 1, null, "Available" },
                    { 186, "Very Good", 19, "FRG-019-006", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3656), "Port Elizabeth Depot", 1, null, "Available" },
                    { 187, "Good", 19, "FRG-019-007", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3669), "Pretoria Facility", 1, null, "Available" },
                    { 188, "Very Good", 19, "FRG-019-008", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3673), "Cape Town Storage", 1, null, "Available" },
                    { 189, "Excellent", 19, "FRG-019-009", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3677), "Johannesburg Main", 1, null, "Available" },
                    { 190, "Good", 19, "FRG-019-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3681), "Port Elizabeth Depot", 1, null, "Available" },
                    { 191, "Good", 20, "FRG-020-001", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3686), "Port Elizabeth Depot", 1, null, "Available" },
                    { 192, "Good", 20, "FRG-020-002", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3690), "Pretoria Facility", 1, null, "Available" },
                    { 193, "Excellent", 20, "FRG-020-003", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3695), "Cape Town Storage", 1, null, "Available" },
                    { 194, "Good", 20, "FRG-020-004", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3699), "Cape Town Storage", 1, null, "Available" },
                    { 195, "Good", 20, "FRG-020-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3703), "Cape Town Storage", 1, null, "Available" },
                    { 196, "Good", 20, "FRG-020-006", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3707), "Cape Town Storage", 1, null, "Available" },
                    { 197, "Very Good", 20, "FRG-020-007", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3712), "Durban Warehouse", 1, null, "Available" },
                    { 198, "Very Good", 20, "FRG-020-008", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3716), "Port Elizabeth Depot", 1, null, "Available" },
                    { 199, "Excellent", 20, "FRG-020-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3720), "Pretoria Facility", 1, null, "Available" },
                    { 200, "Excellent", 20, "FRG-020-010", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3725), "Port Elizabeth Depot", 1, null, "Available" },
                    { 201, "Excellent", 21, "FRG-021-001", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3729), "Pretoria Facility", 1, null, "Available" },
                    { 202, "Very Good", 21, "FRG-021-002", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3733), "Johannesburg Main", 1, null, "Available" },
                    { 203, "Very Good", 21, "FRG-021-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3738), "Pretoria Facility", 1, null, "Available" },
                    { 204, "Good", 21, "FRG-021-004", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3742), "Port Elizabeth Depot", 1, null, "Available" },
                    { 205, "Good", 21, "FRG-021-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3746), "Johannesburg Main", 1, null, "Available" },
                    { 206, "Good", 21, "FRG-021-006", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3750), "Durban Warehouse", 1, null, "Available" },
                    { 207, "Very Good", 21, "FRG-021-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3754), "Port Elizabeth Depot", 1, null, "Available" },
                    { 208, "Excellent", 21, "FRG-021-008", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3758), "Johannesburg Main", 1, null, "Available" },
                    { 209, "Very Good", 21, "FRG-021-009", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3762), "Johannesburg Main", 1, null, "Available" },
                    { 210, "Very Good", 21, "FRG-021-010", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3766), "Port Elizabeth Depot", 1, null, "Available" },
                    { 211, "Good", 22, "FRG-022-001", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3771), "Durban Warehouse", 1, null, "Available" },
                    { 212, "Excellent", 22, "FRG-022-002", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3775), "Johannesburg Main", 1, null, "Available" },
                    { 213, "Good", 22, "FRG-022-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3779), "Johannesburg Main", 1, null, "Available" },
                    { 214, "Good", 22, "FRG-022-004", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3783), "Port Elizabeth Depot", 1, null, "Available" },
                    { 215, "Excellent", 22, "FRG-022-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3788), "Cape Town Storage", 1, null, "Available" },
                    { 216, "Excellent", 22, "FRG-022-006", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3792), "Durban Warehouse", 1, null, "Available" },
                    { 217, "Very Good", 22, "FRG-022-007", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3796), "Port Elizabeth Depot", 1, null, "Available" },
                    { 218, "Good", 22, "FRG-022-008", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3800), "Cape Town Storage", 1, null, "Available" },
                    { 219, "Very Good", 22, "FRG-022-009", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3804), "Johannesburg Main", 1, null, "Available" },
                    { 220, "Very Good", 22, "FRG-022-010", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3809), "Durban Warehouse", 1, null, "Available" },
                    { 221, "Good", 23, "FRG-023-001", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3813), "Johannesburg Main", 1, null, "Available" },
                    { 222, "Good", 23, "FRG-023-002", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3817), "Port Elizabeth Depot", 1, null, "Available" },
                    { 223, "Excellent", 23, "FRG-023-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3822), "Pretoria Facility", 1, null, "Available" },
                    { 224, "Good", 23, "FRG-023-004", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3826), "Cape Town Storage", 1, null, "Available" },
                    { 225, "Good", 23, "FRG-023-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3830), "Johannesburg Main", 1, null, "Available" },
                    { 226, "Excellent", 23, "FRG-023-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3835), "Port Elizabeth Depot", 1, null, "Available" },
                    { 227, "Very Good", 23, "FRG-023-007", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3839), "Port Elizabeth Depot", 1, null, "Available" },
                    { 228, "Excellent", 23, "FRG-023-008", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3843), "Johannesburg Main", 1, null, "Available" },
                    { 229, "Good", 23, "FRG-023-009", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3847), "Johannesburg Main", 1, null, "Available" },
                    { 230, "Very Good", 23, "FRG-023-010", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3851), "Johannesburg Main", 1, null, "Available" },
                    { 231, "Good", 24, "FRG-024-001", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3855), "Durban Warehouse", 1, null, "Available" },
                    { 232, "Excellent", 24, "FRG-024-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3859), "Port Elizabeth Depot", 1, null, "Available" },
                    { 233, "Excellent", 24, "FRG-024-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3864), "Pretoria Facility", 1, null, "Available" },
                    { 234, "Good", 24, "FRG-024-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3868), "Pretoria Facility", 1, null, "Available" },
                    { 235, "Very Good", 24, "FRG-024-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3872), "Port Elizabeth Depot", 1, null, "Available" },
                    { 236, "Good", 24, "FRG-024-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3877), "Johannesburg Main", 1, null, "Available" },
                    { 237, "Very Good", 24, "FRG-024-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3881), "Pretoria Facility", 1, null, "Available" },
                    { 238, "Excellent", 24, "FRG-024-008", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3885), "Pretoria Facility", 1, null, "Available" },
                    { 239, "Good", 24, "FRG-024-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3889), "Johannesburg Main", 1, null, "Available" },
                    { 240, "Good", 24, "FRG-024-010", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3894), "Durban Warehouse", 1, null, "Available" },
                    { 241, "Excellent", 25, "FRG-025-001", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3898), "Durban Warehouse", 1, null, "Available" },
                    { 242, "Good", 25, "FRG-025-002", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3902), "Cape Town Storage", 1, null, "Available" },
                    { 243, "Very Good", 25, "FRG-025-003", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3906), "Port Elizabeth Depot", 1, null, "Available" },
                    { 244, "Very Good", 25, "FRG-025-004", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3910), "Port Elizabeth Depot", 1, null, "Available" },
                    { 245, "Excellent", 25, "FRG-025-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3914), "Durban Warehouse", 1, null, "Available" },
                    { 246, "Excellent", 25, "FRG-025-006", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3919), "Port Elizabeth Depot", 1, null, "Available" },
                    { 247, "Excellent", 25, "FRG-025-007", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3923), "Port Elizabeth Depot", 1, null, "Available" },
                    { 248, "Excellent", 25, "FRG-025-008", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3927), "Pretoria Facility", 1, null, "Available" },
                    { 249, "Good", 25, "FRG-025-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3932), "Cape Town Storage", 1, null, "Available" },
                    { 250, "Excellent", 25, "FRG-025-010", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3936), "Pretoria Facility", 1, null, "Available" },
                    { 251, "Excellent", 26, "FRG-026-001", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3952), "Johannesburg Main", 1, null, "Available" },
                    { 252, "Good", 26, "FRG-026-002", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3956), "Johannesburg Main", 1, null, "Available" },
                    { 253, "Very Good", 26, "FRG-026-003", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3960), "Cape Town Storage", 1, null, "Available" },
                    { 254, "Good", 26, "FRG-026-004", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3965), "Cape Town Storage", 1, null, "Available" },
                    { 255, "Excellent", 26, "FRG-026-005", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3969), "Johannesburg Main", 1, null, "Available" },
                    { 256, "Excellent", 26, "FRG-026-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3973), "Port Elizabeth Depot", 1, null, "Available" },
                    { 257, "Good", 26, "FRG-026-007", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3977), "Pretoria Facility", 1, null, "Available" },
                    { 258, "Good", 26, "FRG-026-008", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3992), "Durban Warehouse", 1, null, "Available" },
                    { 259, "Excellent", 26, "FRG-026-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(3996), "Johannesburg Main", 1, null, "Available" },
                    { 260, "Excellent", 26, "FRG-026-010", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4000), "Port Elizabeth Depot", 1, null, "Available" },
                    { 261, "Excellent", 27, "FRG-027-001", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4005), "Cape Town Storage", 1, null, "Available" },
                    { 262, "Good", 27, "FRG-027-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4009), "Johannesburg Main", 1, null, "Available" },
                    { 263, "Good", 27, "FRG-027-003", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4013), "Port Elizabeth Depot", 1, null, "Available" },
                    { 264, "Very Good", 27, "FRG-027-004", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4017), "Cape Town Storage", 1, null, "Available" },
                    { 265, "Very Good", 27, "FRG-027-005", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4021), "Cape Town Storage", 1, null, "Available" },
                    { 266, "Good", 27, "FRG-027-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4025), "Johannesburg Main", 1, null, "Available" },
                    { 267, "Very Good", 27, "FRG-027-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4029), "Cape Town Storage", 1, null, "Available" },
                    { 268, "Good", 27, "FRG-027-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4034), "Port Elizabeth Depot", 1, null, "Available" },
                    { 269, "Very Good", 27, "FRG-027-009", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4038), "Port Elizabeth Depot", 1, null, "Available" },
                    { 270, "Good", 27, "FRG-027-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4042), "Port Elizabeth Depot", 1, null, "Available" },
                    { 271, "Excellent", 28, "FRG-028-001", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4047), "Pretoria Facility", 1, null, "Available" },
                    { 272, "Good", 28, "FRG-028-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4051), "Johannesburg Main", 1, null, "Available" },
                    { 273, "Excellent", 28, "FRG-028-003", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4055), "Johannesburg Main", 1, null, "Available" },
                    { 274, "Very Good", 28, "FRG-028-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4060), "Durban Warehouse", 1, null, "Available" },
                    { 275, "Excellent", 28, "FRG-028-005", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4072), "Johannesburg Main", 1, null, "Available" },
                    { 276, "Good", 28, "FRG-028-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4076), "Johannesburg Main", 1, null, "Available" },
                    { 277, "Excellent", 28, "FRG-028-007", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4080), "Port Elizabeth Depot", 1, null, "Available" },
                    { 278, "Excellent", 28, "FRG-028-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4085), "Port Elizabeth Depot", 1, null, "Available" },
                    { 279, "Good", 28, "FRG-028-009", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4089), "Johannesburg Main", 1, null, "Available" },
                    { 280, "Excellent", 28, "FRG-028-010", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4093), "Port Elizabeth Depot", 1, null, "Available" },
                    { 281, "Very Good", 29, "FRG-029-001", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4097), "Port Elizabeth Depot", 1, null, "Available" },
                    { 282, "Good", 29, "FRG-029-002", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4101), "Johannesburg Main", 1, null, "Available" },
                    { 283, "Good", 29, "FRG-029-003", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4112), "Port Elizabeth Depot", 1, null, "Available" },
                    { 284, "Excellent", 29, "FRG-029-004", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4116), "Port Elizabeth Depot", 1, null, "Available" },
                    { 285, "Good", 29, "FRG-029-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4120), "Johannesburg Main", 1, null, "Available" },
                    { 286, "Excellent", 29, "FRG-029-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4124), "Cape Town Storage", 1, null, "Available" },
                    { 287, "Excellent", 29, "FRG-029-007", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4129), "Durban Warehouse", 1, null, "Available" },
                    { 288, "Excellent", 29, "FRG-029-008", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4133), "Cape Town Storage", 1, null, "Available" },
                    { 289, "Good", 29, "FRG-029-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4137), "Johannesburg Main", 1, null, "Available" },
                    { 290, "Good", 29, "FRG-029-010", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4141), "Johannesburg Main", 1, null, "Available" },
                    { 291, "Very Good", 30, "FRG-030-001", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4146), "Johannesburg Main", 1, null, "Available" },
                    { 292, "Excellent", 30, "FRG-030-002", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4150), "Port Elizabeth Depot", 1, null, "Available" },
                    { 293, "Good", 30, "FRG-030-003", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4155), "Port Elizabeth Depot", 1, null, "Available" },
                    { 294, "Excellent", 30, "FRG-030-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4159), "Port Elizabeth Depot", 1, null, "Available" },
                    { 295, "Excellent", 30, "FRG-030-005", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4163), "Port Elizabeth Depot", 1, null, "Available" },
                    { 296, "Good", 30, "FRG-030-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4167), "Port Elizabeth Depot", 1, null, "Available" },
                    { 297, "Good", 30, "FRG-030-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4171), "Port Elizabeth Depot", 1, null, "Available" },
                    { 298, "Excellent", 30, "FRG-030-008", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4176), "Pretoria Facility", 1, null, "Available" },
                    { 299, "Excellent", 30, "FRG-030-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4180), "Johannesburg Main", 1, null, "Available" },
                    { 300, "Good", 30, "FRG-030-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4184), "Port Elizabeth Depot", 1, null, "Available" },
                    { 301, "Good", 31, "FRG-031-001", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4188), "Pretoria Facility", 1, null, "Available" },
                    { 302, "Good", 31, "FRG-031-002", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4193), "Port Elizabeth Depot", 1, null, "Available" },
                    { 303, "Excellent", 31, "FRG-031-003", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4197), "Cape Town Storage", 1, null, "Available" },
                    { 304, "Excellent", 31, "FRG-031-004", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4201), "Cape Town Storage", 1, null, "Available" },
                    { 305, "Excellent", 31, "FRG-031-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4205), "Durban Warehouse", 1, null, "Available" },
                    { 306, "Good", 31, "FRG-031-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4209), "Durban Warehouse", 1, null, "Available" },
                    { 307, "Good", 31, "FRG-031-007", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4214), "Durban Warehouse", 1, null, "Available" },
                    { 308, "Very Good", 31, "FRG-031-008", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4218), "Pretoria Facility", 1, null, "Available" },
                    { 309, "Excellent", 31, "FRG-031-009", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4222), "Johannesburg Main", 1, null, "Available" },
                    { 310, "Good", 31, "FRG-031-010", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4226), "Pretoria Facility", 1, null, "Available" },
                    { 311, "Excellent", 32, "FRG-032-001", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4230), "Durban Warehouse", 1, null, "Available" },
                    { 312, "Excellent", 32, "FRG-032-002", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4234), "Port Elizabeth Depot", 1, null, "Available" },
                    { 313, "Good", 32, "FRG-032-003", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4238), "Pretoria Facility", 1, null, "Available" },
                    { 314, "Excellent", 32, "FRG-032-004", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4243), "Port Elizabeth Depot", 1, null, "Available" },
                    { 315, "Excellent", 32, "FRG-032-005", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4247), "Port Elizabeth Depot", 1, null, "Available" },
                    { 316, "Excellent", 32, "FRG-032-006", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4251), "Pretoria Facility", 1, null, "Available" },
                    { 317, "Excellent", 32, "FRG-032-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4255), "Johannesburg Main", 1, null, "Available" },
                    { 318, "Good", 32, "FRG-032-008", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4259), "Johannesburg Main", 1, null, "Available" },
                    { 319, "Excellent", 32, "FRG-032-009", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4263), "Johannesburg Main", 1, null, "Available" },
                    { 320, "Good", 32, "FRG-032-010", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4268), "Pretoria Facility", 1, null, "Available" },
                    { 321, "Excellent", 33, "FRG-033-001", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4272), "Port Elizabeth Depot", 1, null, "Available" },
                    { 322, "Very Good", 33, "FRG-033-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4276), "Cape Town Storage", 1, null, "Available" },
                    { 323, "Excellent", 33, "FRG-033-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4280), "Johannesburg Main", 1, null, "Available" },
                    { 324, "Very Good", 33, "FRG-033-004", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4284), "Durban Warehouse", 1, null, "Available" },
                    { 325, "Very Good", 33, "FRG-033-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4288), "Pretoria Facility", 1, null, "Available" },
                    { 326, "Very Good", 33, "FRG-033-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4292), "Johannesburg Main", 1, null, "Available" },
                    { 327, "Good", 33, "FRG-033-007", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4296), "Durban Warehouse", 1, null, "Available" },
                    { 328, "Good", 33, "FRG-033-008", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4301), "Cape Town Storage", 1, null, "Available" },
                    { 329, "Excellent", 33, "FRG-033-009", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4305), "Durban Warehouse", 1, null, "Available" },
                    { 330, "Very Good", 33, "FRG-033-010", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4309), "Johannesburg Main", 1, null, "Available" },
                    { 331, "Good", 34, "FRG-034-001", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4314), "Durban Warehouse", 1, null, "Available" },
                    { 332, "Good", 34, "FRG-034-002", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4318), "Port Elizabeth Depot", 1, null, "Available" },
                    { 333, "Very Good", 34, "FRG-034-003", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4330), "Pretoria Facility", 1, null, "Available" },
                    { 334, "Excellent", 34, "FRG-034-004", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4335), "Cape Town Storage", 1, null, "Available" },
                    { 335, "Excellent", 34, "FRG-034-005", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4339), "Cape Town Storage", 1, null, "Available" },
                    { 336, "Good", 34, "FRG-034-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4343), "Port Elizabeth Depot", 1, null, "Available" },
                    { 337, "Very Good", 34, "FRG-034-007", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4347), "Pretoria Facility", 1, null, "Available" },
                    { 338, "Excellent", 34, "FRG-034-008", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4352), "Pretoria Facility", 1, null, "Available" },
                    { 339, "Excellent", 34, "FRG-034-009", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4356), "Pretoria Facility", 1, null, "Available" },
                    { 340, "Excellent", 34, "FRG-034-010", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4360), "Durban Warehouse", 1, null, "Available" },
                    { 341, "Good", 35, "FRG-035-001", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4364), "Port Elizabeth Depot", 1, null, "Available" },
                    { 342, "Excellent", 35, "FRG-035-002", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4368), "Pretoria Facility", 1, null, "Available" },
                    { 343, "Good", 35, "FRG-035-003", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4372), "Port Elizabeth Depot", 1, null, "Available" },
                    { 344, "Good", 35, "FRG-035-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4377), "Johannesburg Main", 1, null, "Available" },
                    { 345, "Good", 35, "FRG-035-005", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4381), "Port Elizabeth Depot", 1, null, "Available" },
                    { 346, "Good", 35, "FRG-035-006", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4392), "Cape Town Storage", 1, null, "Available" },
                    { 347, "Good", 35, "FRG-035-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4402), "Port Elizabeth Depot", 1, null, "Available" },
                    { 348, "Good", 35, "FRG-035-008", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4406), "Durban Warehouse", 1, null, "Available" },
                    { 349, "Very Good", 35, "FRG-035-009", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4410), "Johannesburg Main", 1, null, "Available" },
                    { 350, "Excellent", 35, "FRG-035-010", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4415), "Cape Town Storage", 1, null, "Available" },
                    { 351, "Good", 36, "FRG-036-001", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4419), "Port Elizabeth Depot", 1, null, "Available" },
                    { 352, "Excellent", 36, "FRG-036-002", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4423), "Cape Town Storage", 1, null, "Available" },
                    { 353, "Very Good", 36, "FRG-036-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4427), "Johannesburg Main", 1, null, "Available" },
                    { 354, "Good", 36, "FRG-036-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4432), "Port Elizabeth Depot", 1, null, "Available" },
                    { 355, "Very Good", 36, "FRG-036-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4436), "Durban Warehouse", 1, null, "Available" },
                    { 356, "Excellent", 36, "FRG-036-006", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4440), "Durban Warehouse", 1, null, "Available" },
                    { 357, "Excellent", 36, "FRG-036-007", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4444), "Pretoria Facility", 1, null, "Available" },
                    { 358, "Very Good", 36, "FRG-036-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4448), "Pretoria Facility", 1, null, "Available" },
                    { 359, "Good", 36, "FRG-036-009", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4452), "Port Elizabeth Depot", 1, null, "Available" },
                    { 360, "Good", 36, "FRG-036-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4457), "Durban Warehouse", 1, null, "Available" },
                    { 361, "Good", 37, "FRG-037-001", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4461), "Pretoria Facility", 1, null, "Available" },
                    { 362, "Good", 37, "FRG-037-002", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4465), "Pretoria Facility", 1, null, "Available" },
                    { 363, "Excellent", 37, "FRG-037-003", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4469), "Port Elizabeth Depot", 1, null, "Available" },
                    { 364, "Good", 37, "FRG-037-004", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4473), "Johannesburg Main", 1, null, "Available" },
                    { 365, "Good", 37, "FRG-037-005", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4478), "Pretoria Facility", 1, null, "Available" },
                    { 366, "Excellent", 37, "FRG-037-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4482), "Port Elizabeth Depot", 1, null, "Available" },
                    { 367, "Good", 37, "FRG-037-007", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4486), "Cape Town Storage", 1, null, "Available" },
                    { 368, "Excellent", 37, "FRG-037-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4491), "Johannesburg Main", 1, null, "Available" },
                    { 369, "Very Good", 37, "FRG-037-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4495), "Cape Town Storage", 1, null, "Available" },
                    { 370, "Good", 37, "FRG-037-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4499), "Port Elizabeth Depot", 1, null, "Available" },
                    { 371, "Good", 38, "FRG-038-001", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4503), "Cape Town Storage", 1, null, "Available" },
                    { 372, "Good", 38, "FRG-038-002", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4507), "Port Elizabeth Depot", 1, null, "Available" },
                    { 373, "Excellent", 38, "FRG-038-003", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4511), "Johannesburg Main", 1, null, "Available" },
                    { 374, "Good", 38, "FRG-038-004", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4515), "Durban Warehouse", 1, null, "Available" },
                    { 375, "Very Good", 38, "FRG-038-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4520), "Pretoria Facility", 1, null, "Available" },
                    { 376, "Very Good", 38, "FRG-038-006", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4524), "Durban Warehouse", 1, null, "Available" },
                    { 377, "Very Good", 38, "FRG-038-007", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4528), "Johannesburg Main", 1, null, "Available" },
                    { 378, "Very Good", 38, "FRG-038-008", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4532), "Port Elizabeth Depot", 1, null, "Available" },
                    { 379, "Very Good", 38, "FRG-038-009", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4536), "Port Elizabeth Depot", 1, null, "Available" },
                    { 380, "Good", 38, "FRG-038-010", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4540), "Johannesburg Main", 1, null, "Available" },
                    { 381, "Excellent", 39, "FRG-039-001", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4545), "Durban Warehouse", 1, null, "Available" },
                    { 382, "Excellent", 39, "FRG-039-002", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4549), "Cape Town Storage", 1, null, "Available" },
                    { 383, "Very Good", 39, "FRG-039-003", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4553), "Durban Warehouse", 1, null, "Available" },
                    { 384, "Good", 39, "FRG-039-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4557), "Cape Town Storage", 1, null, "Available" },
                    { 385, "Good", 39, "FRG-039-005", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4562), "Durban Warehouse", 1, null, "Available" },
                    { 386, "Good", 39, "FRG-039-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4566), "Pretoria Facility", 1, null, "Available" },
                    { 387, "Good", 39, "FRG-039-007", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4570), "Port Elizabeth Depot", 1, null, "Available" },
                    { 388, "Good", 39, "FRG-039-008", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4574), "Pretoria Facility", 1, null, "Available" },
                    { 389, "Very Good", 39, "FRG-039-009", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4578), "Pretoria Facility", 1, null, "Available" },
                    { 390, "Excellent", 39, "FRG-039-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4583), "Cape Town Storage", 1, null, "Available" },
                    { 391, "Excellent", 40, "FRG-040-001", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4587), "Durban Warehouse", 1, null, "Available" },
                    { 392, "Excellent", 40, "FRG-040-002", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4592), "Durban Warehouse", 1, null, "Available" },
                    { 393, "Excellent", 40, "FRG-040-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4596), "Cape Town Storage", 1, null, "Available" },
                    { 394, "Very Good", 40, "FRG-040-004", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4600), "Durban Warehouse", 1, null, "Available" },
                    { 395, "Good", 40, "FRG-040-005", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4604), "Cape Town Storage", 1, null, "Available" },
                    { 396, "Very Good", 40, "FRG-040-006", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4608), "Durban Warehouse", 1, null, "Available" },
                    { 397, "Excellent", 40, "FRG-040-007", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4613), "Cape Town Storage", 1, null, "Available" },
                    { 398, "Good", 40, "FRG-040-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4617), "Port Elizabeth Depot", 1, null, "Available" },
                    { 399, "Excellent", 40, "FRG-040-009", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4621), "Durban Warehouse", 1, null, "Available" },
                    { 400, "Excellent", 40, "FRG-040-010", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4625), "Pretoria Facility", 1, null, "Available" },
                    { 401, "Very Good", 41, "FRG-041-001", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4629), "Port Elizabeth Depot", 1, null, "Available" },
                    { 402, "Very Good", 41, "FRG-041-002", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4642), "Cape Town Storage", 1, null, "Available" },
                    { 403, "Excellent", 41, "FRG-041-003", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4646), "Johannesburg Main", 1, null, "Available" },
                    { 404, "Excellent", 41, "FRG-041-004", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4650), "Cape Town Storage", 1, null, "Available" },
                    { 405, "Good", 41, "FRG-041-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4654), "Johannesburg Main", 1, null, "Available" },
                    { 406, "Good", 41, "FRG-041-006", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4658), "Pretoria Facility", 1, null, "Available" },
                    { 407, "Very Good", 41, "FRG-041-007", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4663), "Johannesburg Main", 1, null, "Available" },
                    { 408, "Excellent", 41, "FRG-041-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4667), "Johannesburg Main", 1, null, "Available" },
                    { 409, "Excellent", 41, "FRG-041-009", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4671), "Port Elizabeth Depot", 1, null, "Available" },
                    { 410, "Excellent", 41, "FRG-041-010", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4675), "Durban Warehouse", 1, null, "Available" },
                    { 411, "Very Good", 42, "FRG-042-001", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4685), "Johannesburg Main", 1, null, "Available" },
                    { 412, "Good", 42, "FRG-042-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4689), "Durban Warehouse", 1, null, "Available" },
                    { 413, "Excellent", 42, "FRG-042-003", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4701), "Port Elizabeth Depot", 1, null, "Available" },
                    { 414, "Very Good", 42, "FRG-042-004", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4705), "Cape Town Storage", 1, null, "Available" },
                    { 415, "Very Good", 42, "FRG-042-005", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4710), "Johannesburg Main", 1, null, "Available" },
                    { 416, "Excellent", 42, "FRG-042-006", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4714), "Cape Town Storage", 1, null, "Available" },
                    { 417, "Good", 42, "FRG-042-007", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4718), "Cape Town Storage", 1, null, "Available" },
                    { 418, "Very Good", 42, "FRG-042-008", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4722), "Pretoria Facility", 1, null, "Available" },
                    { 419, "Good", 42, "FRG-042-009", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4726), "Durban Warehouse", 1, null, "Available" },
                    { 420, "Excellent", 42, "FRG-042-010", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4730), "Cape Town Storage", 1, null, "Available" },
                    { 421, "Excellent", 43, "FRG-043-001", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4734), "Johannesburg Main", 1, null, "Available" },
                    { 422, "Excellent", 43, "FRG-043-002", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4739), "Port Elizabeth Depot", 1, null, "Available" },
                    { 423, "Excellent", 43, "FRG-043-003", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4743), "Cape Town Storage", 1, null, "Available" },
                    { 424, "Good", 43, "FRG-043-004", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4747), "Pretoria Facility", 1, null, "Available" },
                    { 425, "Excellent", 43, "FRG-043-005", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4751), "Cape Town Storage", 1, null, "Available" },
                    { 426, "Good", 43, "FRG-043-006", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4755), "Port Elizabeth Depot", 1, null, "Available" },
                    { 427, "Good", 43, "FRG-043-007", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4759), "Durban Warehouse", 1, null, "Available" },
                    { 428, "Excellent", 43, "FRG-043-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4764), "Cape Town Storage", 1, null, "Available" },
                    { 429, "Excellent", 43, "FRG-043-009", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4768), "Pretoria Facility", 1, null, "Available" },
                    { 430, "Excellent", 43, "FRG-043-010", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4772), "Cape Town Storage", 1, null, "Available" },
                    { 431, "Good", 44, "FRG-044-001", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4776), "Johannesburg Main", 1, null, "Available" },
                    { 432, "Excellent", 44, "FRG-044-002", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4780), "Durban Warehouse", 1, null, "Available" },
                    { 433, "Good", 44, "FRG-044-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4785), "Pretoria Facility", 1, null, "Available" },
                    { 434, "Excellent", 44, "FRG-044-004", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4789), "Durban Warehouse", 1, null, "Available" },
                    { 435, "Excellent", 44, "FRG-044-005", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4793), "Johannesburg Main", 1, null, "Available" },
                    { 436, "Good", 44, "FRG-044-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4797), "Pretoria Facility", 1, null, "Available" },
                    { 437, "Excellent", 44, "FRG-044-007", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4801), "Cape Town Storage", 1, null, "Available" },
                    { 438, "Excellent", 44, "FRG-044-008", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4806), "Pretoria Facility", 1, null, "Available" },
                    { 439, "Excellent", 44, "FRG-044-009", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4810), "Durban Warehouse", 1, null, "Available" },
                    { 440, "Good", 44, "FRG-044-010", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4814), "Port Elizabeth Depot", 1, null, "Available" },
                    { 441, "Excellent", 45, "FRG-045-001", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4819), "Cape Town Storage", 1, null, "Available" },
                    { 442, "Excellent", 45, "FRG-045-002", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4823), "Port Elizabeth Depot", 1, null, "Available" },
                    { 443, "Excellent", 45, "FRG-045-003", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4827), "Durban Warehouse", 1, null, "Available" },
                    { 444, "Excellent", 45, "FRG-045-004", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4831), "Cape Town Storage", 1, null, "Available" },
                    { 445, "Good", 45, "FRG-045-005", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4835), "Durban Warehouse", 1, null, "Available" },
                    { 446, "Good", 45, "FRG-045-006", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4840), "Cape Town Storage", 1, null, "Available" },
                    { 447, "Excellent", 45, "FRG-045-007", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4844), "Port Elizabeth Depot", 1, null, "Available" },
                    { 448, "Good", 45, "FRG-045-008", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4848), "Pretoria Facility", 1, null, "Available" },
                    { 449, "Very Good", 45, "FRG-045-009", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4852), "Durban Warehouse", 1, null, "Available" },
                    { 450, "Excellent", 45, "FRG-045-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4856), "Johannesburg Main", 1, null, "Available" },
                    { 451, "Good", 46, "FRG-046-001", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4860), "Cape Town Storage", 1, null, "Available" },
                    { 452, "Good", 46, "FRG-046-002", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4864), "Durban Warehouse", 1, null, "Available" },
                    { 453, "Excellent", 46, "FRG-046-003", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4868), "Durban Warehouse", 1, null, "Available" },
                    { 454, "Very Good", 46, "FRG-046-004", false, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4872), "Cape Town Storage", 1, null, "Available" },
                    { 455, "Good", 46, "FRG-046-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4876), "Durban Warehouse", 1, null, "Available" },
                    { 456, "Good", 46, "FRG-046-006", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4881), "Durban Warehouse", 1, null, "Available" },
                    { 457, "Excellent", 46, "FRG-046-007", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4885), "Port Elizabeth Depot", 1, null, "Available" },
                    { 458, "Good", 46, "FRG-046-008", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4889), "Cape Town Storage", 1, null, "Available" },
                    { 459, "Excellent", 46, "FRG-046-009", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4893), "Cape Town Storage", 1, null, "Available" },
                    { 460, "Excellent", 46, "FRG-046-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4897), "Port Elizabeth Depot", 1, null, "Available" },
                    { 461, "Very Good", 47, "FRG-047-001", false, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4901), "Johannesburg Main", 1, null, "Available" },
                    { 462, "Good", 47, "FRG-047-002", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4905), "Johannesburg Main", 1, null, "Available" },
                    { 463, "Excellent", 47, "FRG-047-003", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4910), "Port Elizabeth Depot", 1, null, "Available" },
                    { 464, "Excellent", 47, "FRG-047-004", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4914), "Pretoria Facility", 1, null, "Available" },
                    { 465, "Good", 47, "FRG-047-005", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4918), "Durban Warehouse", 1, null, "Available" },
                    { 466, "Good", 47, "FRG-047-006", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4922), "Port Elizabeth Depot", 1, null, "Available" },
                    { 467, "Excellent", 47, "FRG-047-007", false, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4926), "Port Elizabeth Depot", 1, null, "Available" },
                    { 468, "Good", 47, "FRG-047-008", true, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4931), "Johannesburg Main", 1, null, "Available" },
                    { 469, "Good", 47, "FRG-047-009", true, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4935), "Port Elizabeth Depot", 1, null, "Available" },
                    { 470, "Excellent", 47, "FRG-047-010", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4939), "Durban Warehouse", 1, null, "Available" },
                    { 471, "Very Good", 48, "FRG-048-001", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4951), "Durban Warehouse", 1, null, "Available" },
                    { 472, "Excellent", 48, "FRG-048-002", true, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4955), "Pretoria Facility", 1, null, "Available" },
                    { 473, "Excellent", 48, "FRG-048-003", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4959), "Durban Warehouse", 1, null, "Available" },
                    { 474, "Good", 48, "FRG-048-004", true, new DateTime(2025, 7, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4963), "Port Elizabeth Depot", 1, null, "Available" },
                    { 475, "Excellent", 48, "FRG-048-005", false, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4973), "Durban Warehouse", 1, null, "Available" },
                    { 476, "Excellent", 48, "FRG-048-006", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4977), "Port Elizabeth Depot", 1, null, "Available" },
                    { 477, "Excellent", 48, "FRG-048-007", false, new DateTime(2025, 6, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4981), "Johannesburg Main", 1, null, "Available" },
                    { 478, "Very Good", 48, "FRG-048-008", true, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4986), "Durban Warehouse", 1, null, "Available" },
                    { 479, "Good", 48, "FRG-048-009", true, new DateTime(2025, 9, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4990), "Pretoria Facility", 1, null, "Available" },
                    { 480, "Excellent", 48, "FRG-048-010", false, new DateTime(2025, 8, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(4994), "Johannesburg Main", 1, null, "Available" }
                });

            migrationBuilder.InsertData(
                table: "tblAllocations",
                columns: new[] { "AllocationId", "Count", "CustomerID", "FridgeId" },
                values: new object[,]
                {
                    { 1, 2, 9, 25 },
                    { 2, 1, 5, 8 },
                    { 3, 3, 1, 46 },
                    { 4, 1, 9, 36 },
                    { 5, 3, 10, 32 },
                    { 6, 3, 10, 4 },
                    { 7, 1, 2, 25 },
                    { 8, 1, 2, 3 },
                    { 9, 1, 5, 4 },
                    { 10, 2, 2, 38 },
                    { 11, 1, 8, 19 },
                    { 12, 3, 1, 26 },
                    { 13, 2, 11, 40 },
                    { 14, 1, 3, 39 },
                    { 15, 3, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "tblFaultReports",
                columns: new[] { "FaultReportId", "CustomerId", "DeclineReason", "Description", "FaultType", "FridgeInStockId", "ImageUrl", "IsRelaunched", "IsReplacementRequested", "OriginalFaultReportId", "Priority", "ReportedDate", "RequestReplacement", "Status" },
                values: new object[,]
                {
                    { 1, 7, null, "Fault description for report 1. Issue requires attention.", "Door Problems", 136, "/Images/Faults/fault-1.jpg", false, true, null, "Low", new DateTime(2025, 9, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8389), false, "Resolved" },
                    { 2, 8, null, "Fault description for report 2. Issue requires attention.", "Electrical Issues", 55, "/Images/Faults/fault-2.jpg", false, true, null, "Low", new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8409), true, "In Progress" },
                    { 3, 3, null, "Fault description for report 3. Issue requires attention.", "Not Cooling", 129, "/Images/Faults/fault-3.jpg", false, false, null, "High", new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8413), false, "In Progress" },
                    { 4, 12, null, "Fault description for report 4. Issue requires attention.", "Not Cooling", 113, "/Images/Faults/fault-4.jpg", false, true, null, "Low", new DateTime(2025, 10, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8417), true, "In Progress" },
                    { 5, 1, null, "Fault description for report 5. Issue requires attention.", "Electrical Issues", 83, "/Images/Faults/fault-5.jpg", false, true, null, "Low", new DateTime(2025, 10, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8422), false, "Reported" },
                    { 6, 9, null, "Fault description for report 6. Issue requires attention.", "Electrical Issues", 67, "/Images/Faults/fault-6.jpg", false, true, null, "Critical", new DateTime(2025, 10, 28, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8426), false, "Reported" },
                    { 7, 10, null, "Fault description for report 7. Issue requires attention.", "Not Cooling", 97, "/Images/Faults/fault-7.jpg", false, true, null, "High", new DateTime(2025, 10, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8431), true, "Resolved" },
                    { 8, 7, null, "Fault description for report 8. Issue requires attention.", "Electrical Issues", 7, "/Images/Faults/fault-8.jpg", false, true, null, "Medium", new DateTime(2025, 10, 12, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8435), true, "Declined" },
                    { 9, 7, null, "Fault description for report 9. Issue requires attention.", "Strange Noises", 52, "/Images/Faults/fault-9.jpg", false, true, null, "Critical", new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8439), false, "Resolved" },
                    { 10, 8, null, "Fault description for report 10. Issue requires attention.", "Water Leakage", 131, "/Images/Faults/fault-10.jpg", false, true, null, "Medium", new DateTime(2025, 10, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8451), false, "Declined" },
                    { 11, 9, null, "Fault description for report 11. Issue requires attention.", "Door Problems", 146, "/Images/Faults/fault-11.jpg", false, false, null, "High", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8456), false, "Resolved" },
                    { 12, 5, null, "Fault description for report 12. Issue requires attention.", "Strange Noises", 56, "/Images/Faults/fault-12.jpg", false, false, null, "Medium", new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8460), false, "Reported" },
                    { 13, 10, null, "Fault description for report 13. Issue requires attention.", "Water Leakage", 57, "/Images/Faults/fault-13.jpg", false, true, null, "Critical", new DateTime(2025, 10, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8464), true, "In Progress" },
                    { 14, 2, null, "Fault description for report 14. Issue requires attention.", "Strange Noises", 61, "/Images/Faults/fault-14.jpg", false, false, null, "Critical", new DateTime(2025, 10, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8468), false, "Reported" },
                    { 15, 4, null, "Fault description for report 15. Issue requires attention.", "Strange Noises", 25, "/Images/Faults/fault-15.jpg", false, false, null, "Low", new DateTime(2025, 11, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8472), true, "Declined" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestHeaders",
                columns: new[] { "RequestHeaderId", "AdditionalDescription", "AdditionalDocumentPath", "Carrier", "CellNumber", "City", "CustomerID", "DeliveryDate", "EmployeeID", "FirstName", "IsRelaunched", "LastName", "OriginalRequestId", "PaymentDueDate", "PostalCode", "RejectionDate", "RejectionReason", "RequestDate", "RequestTotal", "State", "Status", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, "0124445678", "Johannesburg", 2, new DateTime(2025, 10, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6702), 8, "Lisa", false, "Brown", null, new DateTime(2025, 11, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6702), "5022", null, null, new DateTime(2025, 10, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(6702), 1345.0, "Province", "Shipped", "338 Main Street" },
                    { 2, null, null, null, "0413337890", "Johannesburg", 3, new DateTime(2025, 9, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7635), 5, "David", false, "Jackson", null, new DateTime(2025, 10, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7635), "3386", null, null, new DateTime(2025, 9, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7635), 689.0, "Province", "Shipped", "155 Main Street" },
                    { 3, null, null, null, "0512224567", "Cape Town", 4, null, 5, "Emma", false, "Davis", null, null, "1850", new DateTime(2025, 10, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7650), "Credit check failed", new DateTime(2025, 10, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7650), 800.0, "Province", "Rejected", "91 Commerce Road" },
                    { 4, null, null, null, "0131112345", "Durban", 5, null, 11, "Robert", false, "Miller", null, null, "3299", null, null, new DateTime(2025, 8, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7657), 400.0, "Province", "Approved", "785 Service Road" },
                    { 5, null, null, null, "0156667890", "Pretoria", 6, null, 10, "Sophia", false, "Garcia", null, null, "8681", null, null, new DateTime(2025, 10, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7664), 531.0, "Province", "Approved", "468 Trade Street" },
                    { 6, null, null, null, "0537771234", "Port Elizabeth", 7, null, 11, "James", false, "Anderson", null, null, "1293", null, null, new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7676), 914.0, "Province", "Approved", "9 Business Avenue" },
                    { 7, null, null, null, "0148884567", "Durban", 8, new DateTime(2025, 11, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7681), 8, "Olivia", false, "Martinez", null, new DateTime(2025, 12, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7681), "1196", null, null, new DateTime(2025, 11, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7681), 1005.0, "Province", "Shipped", "318 Service Road" },
                    { 8, null, null, null, "0439991234", "Johannesburg", 9, new DateTime(2025, 9, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7697), 6, "William", false, "Thomas", null, new DateTime(2025, 10, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7697), "8806", null, null, new DateTime(2025, 9, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7697), 930.0, "Province", "Shipped", "376 Service Road" },
                    { 9, null, null, null, "0338885678", "Pretoria", 10, new DateTime(2025, 11, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7702), 2, "Ava", false, "Robinson", null, new DateTime(2025, 12, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7702), "4324", null, null, new DateTime(2025, 11, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7702), 1212.0, "Province", "Shipped", "764 Commerce Road" },
                    { 10, null, null, null, "0577779012", "Pretoria", 11, new DateTime(2025, 9, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7708), 3, "Noah", false, "Clark", null, new DateTime(2025, 10, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7708), "3712", null, null, new DateTime(2025, 9, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7708), 550.0, "Province", "Shipped", "520 Service Road" },
                    { 11, null, null, null, "0136663456", "Pretoria", 12, new DateTime(2025, 10, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7714), 7, "Isabella", false, "Rodriguez", null, new DateTime(2025, 11, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7714), "2486", null, null, new DateTime(2025, 10, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7714), 922.0, "Province", "Closed", "108 Service Road" },
                    { 12, null, null, null, "0315551234", "Bloemfontein", 1, new DateTime(2025, 9, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7719), 8, "Mike", false, "Wilson", null, new DateTime(2025, 9, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7719), "7492", null, null, new DateTime(2025, 8, 31, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7719), 1262.0, "Province", "Shipped", "480 Business Avenue" },
                    { 13, null, null, null, "0124445678", "Cape Town", 2, null, 8, "Lisa", false, "Brown", null, null, "2180", new DateTime(2025, 9, 21, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7724), "Payment method not approved", new DateTime(2025, 9, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7724), 1214.0, "Province", "Rejected", "201 Main Street" },
                    { 14, null, null, null, "0413337890", "Cape Town", 3, null, 11, "David", false, "Jackson", null, null, "8044", null, null, new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7737), 1263.0, "Province", "Approved", "678 Trade Street" },
                    { 15, null, null, null, "0512224567", "Cape Town", 4, null, 11, "Emma", false, "Davis", null, null, "4408", new DateTime(2025, 10, 28, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7747), "Business type not supported", new DateTime(2025, 10, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(7747), 1323.0, "Province", "Rejected", "442 Service Road" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeVisits",
                columns: new[] { "VisitId", "CheckupStatus", "CreatedDate", "CustomerApproval", "Notes", "RequestHeaderId", "Status", "TechnicianName", "VisitDate", "VisitType" },
                values: new object[,]
                {
                    { 1, "In Progress", new DateTime(2025, 10, 21, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8210), "Approved", "Visit notes for service 1. Checkup completed with status: In Progress", 10, "Pending", "Patricia White", new DateTime(2025, 10, 22, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8210), "Maintenance Check" },
                    { 2, "Failed", new DateTime(2025, 10, 23, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8242), "Approved", "Visit notes for service 2. Checkup completed with status: Failed", 3, "Pending", "James Miller", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8242), "Maintenance Check" },
                    { 3, "In Progress", new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8246), "Approved", "Visit notes for service 3. Checkup completed with status: In Progress", 13, "Pending", "Robert Davis", new DateTime(2025, 10, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8246), "Maintenance Check" },
                    { 4, "Failed", new DateTime(2025, 10, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8250), "Approved", "Visit notes for service 4. Checkup completed with status: Failed", 1, "Pending", "Robert Davis", new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8250), "Maintenance Check" },
                    { 5, "Not Started", new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8253), "Pending", "Visit notes for service 5. Checkup completed with status: Not Started", 8, "Pending", "Jennifer Martin", new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8253), "Maintenance Check" },
                    { 6, "Passed", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8257), "Pending", "Visit notes for service 6. Checkup completed with status: Passed", 7, "Pending", "Patricia White", new DateTime(2025, 10, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8257), "Maintenance Check" },
                    { 7, "Passed", new DateTime(2025, 11, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8261), "Approved", "Visit notes for service 7. Checkup completed with status: Passed", 9, "Pending", "James Miller", new DateTime(2025, 11, 9, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8261), "Maintenance Check" },
                    { 8, "In Progress", new DateTime(2025, 10, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8264), "Pending", "Visit notes for service 8. Checkup completed with status: In Progress", 11, "Pending", "James Miller", new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8264), "Maintenance Check" },
                    { 9, "In Progress", new DateTime(2025, 10, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8267), "Approved", "Visit notes for service 9. Checkup completed with status: In Progress", 10, "Pending", "Patricia White", new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8267), "Maintenance Check" },
                    { 10, "Passed", new DateTime(2025, 10, 22, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8271), "Pending", "Visit notes for service 10. Checkup completed with status: Passed", 11, "Pending", "Robert Davis", new DateTime(2025, 10, 23, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8271), "Maintenance Check" },
                    { 11, "Not Started", new DateTime(2025, 11, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8282), "Approved", "Visit notes for service 11. Checkup completed with status: Not Started", 12, "Pending", "James Miller", new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8282), "Maintenance Check" },
                    { 12, "In Progress", new DateTime(2025, 10, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8286), "Pending", "Visit notes for service 12. Checkup completed with status: In Progress", 4, "Pending", "Jennifer Martin", new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8286), "Maintenance Check" },
                    { 13, "In Progress", new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8289), "Approved", "Visit notes for service 13. Checkup completed with status: In Progress", 12, "Pending", "Jennifer Martin", new DateTime(2025, 10, 15, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8289), "Maintenance Check" },
                    { 14, "Failed", new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8292), "Approved", "Visit notes for service 14. Checkup completed with status: Failed", 1, "Pending", "James Miller", new DateTime(2025, 10, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8292), "Maintenance Check" },
                    { 15, "In Progress", new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8295), "Pending", "Visit notes for service 15. Checkup completed with status: In Progress", 8, "Pending", "James Miller", new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8295), "Maintenance Check" },
                    { 16, "Passed", new DateTime(2025, 11, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8303), "Pending", "Visit notes for service 16. Checkup completed with status: Passed", 4, "Pending", "James Miller", new DateTime(2025, 11, 9, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8303), "Maintenance Check" },
                    { 17, "Not Started", new DateTime(2025, 10, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8307), "Approved", "Visit notes for service 17. Checkup completed with status: Not Started", 6, "Pending", "Jennifer Martin", new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8307), "Maintenance Check" },
                    { 18, "Passed", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8311), "Approved", "Visit notes for service 18. Checkup completed with status: Passed", 7, "Pending", "Patricia White", new DateTime(2025, 11, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8311), "Maintenance Check" },
                    { 19, "Failed", new DateTime(2025, 11, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8314), "Approved", "Visit notes for service 19. Checkup completed with status: Failed", 4, "Pending", "Robert Davis", new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8314), "Maintenance Check" },
                    { 20, "Failed", new DateTime(2025, 10, 23, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8318), "Approved", "Visit notes for service 20. Checkup completed with status: Failed", 3, "Pending", "Robert Davis", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8318), "Maintenance Check" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestDetais",
                columns: new[] { "RequestDetailId", "Count", "FridgeId", "Price", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, 2, 2, 512.0, 2 },
                    { 2, 3, 42, 601.0, 3 },
                    { 3, 3, 47, 417.0, 4 },
                    { 4, 1, 22, 442.0, 5 },
                    { 5, 1, 9, 449.0, 6 },
                    { 6, 1, 10, 798.0, 7 },
                    { 7, 3, 38, 474.0, 8 },
                    { 8, 2, 12, 457.0, 9 },
                    { 9, 1, 1, 759.0, 10 },
                    { 10, 3, 4, 437.0, 11 },
                    { 11, 2, 30, 756.0, 12 },
                    { 12, 3, 33, 572.0, 13 },
                    { 13, 3, 37, 605.0, 14 },
                    { 14, 2, 13, 652.0, 15 },
                    { 15, 2, 42, 799.0, 1 },
                    { 16, 3, 8, 499.0, 2 },
                    { 17, 3, 32, 716.0, 3 },
                    { 18, 2, 41, 447.0, 4 },
                    { 19, 2, 6, 696.0, 5 },
                    { 20, 1, 36, 642.0, 6 }
                });

            migrationBuilder.InsertData(
                table: "tblRequestNotes",
                columns: new[] { "RequestNoteId", "CreatedDate", "NoteContent", "NoteType", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8855), "Note content for request 1. This is an important note regarding the service.", "Administrative", 14 },
                    { 2, new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8870), "Note content for request 2. This is an important note regarding the service.", "Administrative", 11 },
                    { 3, new DateTime(2025, 10, 22, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8872), "Note content for request 3. This is an important note regarding the service.", "Technical", 11 },
                    { 4, new DateTime(2025, 10, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8875), "Note content for request 4. This is an important note regarding the service.", "Administrative", 7 },
                    { 5, new DateTime(2025, 9, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8877), "Note content for request 5. This is an important note regarding the service.", "Administrative", 4 },
                    { 6, new DateTime(2025, 9, 13, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8881), "Note content for request 6. This is an important note regarding the service.", "Internal", 14 },
                    { 7, new DateTime(2025, 9, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8883), "Note content for request 7. This is an important note regarding the service.", "Administrative", 4 },
                    { 8, new DateTime(2025, 10, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8892), "Note content for request 8. This is an important note regarding the service.", "Administrative", 7 },
                    { 9, new DateTime(2025, 10, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8894), "Note content for request 9. This is an important note regarding the service.", "Customer", 4 },
                    { 10, new DateTime(2025, 8, 15, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8897), "Note content for request 10. This is an important note regarding the service.", "Administrative", 14 },
                    { 11, new DateTime(2025, 9, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8900), "Note content for request 11. This is an important note regarding the service.", "Technical", 12 },
                    { 12, new DateTime(2025, 9, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8902), "Note content for request 12. This is an important note regarding the service.", "Administrative", 6 },
                    { 13, new DateTime(2025, 8, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8905), "Note content for request 13. This is an important note regarding the service.", "Administrative", 12 },
                    { 14, new DateTime(2025, 8, 21, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8908), "Note content for request 14. This is an important note regarding the service.", "Internal", 6 },
                    { 15, new DateTime(2025, 9, 1, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8910), "Note content for request 15. This is an important note regarding the service.", "Technical", 6 },
                    { 16, new DateTime(2025, 10, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8913), "Note content for request 16. This is an important note regarding the service.", "Customer", 7 },
                    { 17, new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8915), "Note content for request 17. This is an important note regarding the service.", "Internal", 5 },
                    { 18, new DateTime(2025, 9, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8918), "Note content for request 18. This is an important note regarding the service.", "Administrative", 6 },
                    { 19, new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8920), "Note content for request 19. This is an important note regarding the service.", "Administrative", 10 },
                    { 20, new DateTime(2025, 9, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8923), "Note content for request 20. This is an important note regarding the service.", "Customer", 10 }
                });

            migrationBuilder.InsertData(
                table: "tblCustomerFridge",
                columns: new[] { "CustomerFridgeId", "AllocatedDate", "CustomerID", "DeclineReason", "FridgeId", "FridgeInStockId", "IsActive", "ReasonForReplacement", "ReplacementDate", "ReplacementFridgeInStockId", "ReplacementNotes", "ReplacementStatus", "RequestDetailId", "ReservedDate", "TechnicianNotes" },
                values: new object[,]
                {
                    { 1, null, 10, null, 10, 31, true, "Frequent breakdowns", new DateTime(2025, 10, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8013), 146, "Unit requires replacement due to age", "Pending", 1, new DateTime(2025, 9, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8013), "Inspected and confirmed replacement needed" },
                    { 2, new DateTime(2025, 11, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8032), 7, null, 20, 477, true, null, null, null, null, null, 16, new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8032), null },
                    { 3, new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8035), 3, null, 2, 98, true, "Frequent breakdowns", new DateTime(2025, 12, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8035), 9, "Unit requires replacement due to age", "Pending", 17, new DateTime(2025, 10, 23, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8035), "Inspected and confirmed replacement needed" },
                    { 4, null, 10, null, 12, 375, true, null, null, null, null, null, 1, new DateTime(2025, 9, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8037), null },
                    { 5, new DateTime(2025, 11, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8039), 3, null, 19, 458, true, null, null, null, null, null, 7, new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8039), null },
                    { 6, new DateTime(2025, 11, 1, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8049), 4, null, 41, 171, true, "Frequent breakdowns", new DateTime(2025, 12, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8049), 381, "Unit requires replacement due to age", "Pending", 14, new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8049), "Inspected and confirmed replacement needed" },
                    { 7, null, 9, null, 6, 194, true, null, null, null, null, null, 19, new DateTime(2025, 9, 23, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8051), null },
                    { 8, null, 3, null, 7, 236, true, null, null, null, null, null, 12, new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8053), null },
                    { 9, null, 5, null, 35, 117, true, null, null, null, null, null, 11, new DateTime(2025, 9, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8055), null },
                    { 10, null, 3, null, 33, 217, true, null, null, null, null, null, 10, new DateTime(2025, 10, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8058), null },
                    { 11, new DateTime(2025, 9, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8060), 4, null, 23, 292, true, null, null, null, null, null, 3, new DateTime(2025, 9, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8060), null },
                    { 12, new DateTime(2025, 10, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8062), 1, null, 10, 266, true, null, null, null, null, null, 8, new DateTime(2025, 10, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8062), null },
                    { 13, null, 7, null, 6, 318, true, "Frequent breakdowns", new DateTime(2026, 1, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8065), 30, "Unit requires replacement due to age", "Pending", 12, new DateTime(2025, 10, 15, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8065), "Inspected and confirmed replacement needed" },
                    { 14, null, 10, null, 30, 71, true, null, null, null, null, null, 3, new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8067), null },
                    { 15, new DateTime(2025, 9, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8068), 7, null, 23, 264, true, "Frequent breakdowns", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8068), 106, "Unit requires replacement due to age", "Pending", 14, new DateTime(2025, 9, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8068), "Inspected and confirmed replacement needed" },
                    { 16, new DateTime(2025, 10, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8077), 8, null, 27, 268, true, null, null, null, null, null, 5, new DateTime(2025, 10, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8077), null },
                    { 17, new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8079), 7, null, 28, 44, true, null, null, null, null, null, 2, new DateTime(2025, 10, 8, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8079), null },
                    { 18, null, 1, null, 44, 245, true, null, null, null, null, null, 18, new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8082), null },
                    { 19, null, 4, null, 41, 119, true, null, null, null, null, null, 11, new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8083), null },
                    { 20, null, 12, null, 47, 86, true, null, null, null, null, null, 14, new DateTime(2025, 9, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8085), null },
                    { 21, null, 9, null, 42, 227, true, null, null, null, null, null, 4, new DateTime(2025, 9, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8087), null },
                    { 22, null, 9, null, 44, 2, true, "Frequent breakdowns", new DateTime(2025, 12, 9, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8088), 137, "Unit requires replacement due to age", "Pending", 16, new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8088), "Inspected and confirmed replacement needed" },
                    { 23, null, 12, null, 32, 92, true, null, null, null, null, null, 11, new DateTime(2025, 10, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8090), null },
                    { 24, new DateTime(2025, 10, 1, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8092), 5, null, 35, 43, true, "Frequent breakdowns", new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8092), 310, "Unit requires replacement due to age", "Pending", 5, new DateTime(2025, 9, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8092), "Inspected and confirmed replacement needed" },
                    { 25, null, 6, null, 10, 13, true, null, null, null, null, null, 1, new DateTime(2025, 9, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8093), null }
                });

            migrationBuilder.InsertData(
                table: "tblFaultTechnicians",
                columns: new[] { "FaultId", "Bookingate", "Completion", "CreatedDate", "CustomerBookingStatus", "FaultDescription", "FaultReportId", "FaultType", "Priority", "RepairStatus", "ReportDate", "ResolutionNotes", "TechnicianAssigned", "VisitId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8547), null, new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8547), "Decline", "Fault description for technician assignment 1", 15, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8547), "Resolution notes for fault 1", "Jennifer Martin", 15 },
                    { 2, new DateTime(2025, 11, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8571), null, new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8571), "Decline", "Fault description for technician assignment 2", 11, "Technical Fault", "Medium", "Not Started", new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8571), null, "Jennifer Martin", 15 },
                    { 3, null, null, new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8576), "Decline", "Fault description for technician assignment 3", 12, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 26, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8576), null, "Jennifer Martin", 2 },
                    { 4, null, null, new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8580), "Approved", "Fault description for technician assignment 4", 4, "Technical Fault", "Medium", "Completed", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8580), "Resolution notes for fault 4", "Patricia White", 14 },
                    { 5, new DateTime(2025, 11, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8584), null, new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8584), "Pending", "Fault description for technician assignment 5", 15, "Technical Fault", "High", "In Progress", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8584), null, "Jennifer Martin", 2 },
                    { 6, null, null, new DateTime(2025, 10, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8588), "Decline", "Fault description for technician assignment 6", 4, "Technical Fault", "Medium", "Scrapped", new DateTime(2025, 10, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8588), null, "James Miller", 7 },
                    { 7, new DateTime(2025, 10, 28, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8591), null, new DateTime(2025, 10, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8591), "Decline", "Fault description for technician assignment 7", 11, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8591), "Resolution notes for fault 7", "Robert Davis", 10 },
                    { 8, null, null, new DateTime(2025, 10, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8596), "Decline", "Fault description for technician assignment 8", 11, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 17, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8596), "Resolution notes for fault 8", "Patricia White", 4 },
                    { 9, null, null, new DateTime(2025, 11, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8600), "Decline", "Fault description for technician assignment 9", 1, "Technical Fault", "Medium", "Completed", new DateTime(2025, 11, 3, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8600), null, "Jennifer Martin", 20 },
                    { 10, null, null, new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8604), "Approved", "Fault description for technician assignment 10", 14, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8604), null, "Jennifer Martin", 7 },
                    { 11, null, null, new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8607), "Decline", "Fault description for technician assignment 11", 13, "Technical Fault", "High", "Resolved", new DateTime(2025, 11, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8607), null, "Jennifer Martin", 5 },
                    { 12, null, null, new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8611), "Decline", "Fault description for technician assignment 12", 9, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8611), "Resolution notes for fault 12", "Patricia White", 3 },
                    { 13, new DateTime(2025, 10, 22, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8621), null, new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8621), "Decline", "Fault description for technician assignment 13", 15, "Technical Fault", "High", "Resolved", new DateTime(2025, 10, 18, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8621), null, "Robert Davis", 16 },
                    { 14, null, null, new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8624), "Pending", "Fault description for technician assignment 14", 11, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8624), "Resolution notes for fault 14", "Robert Davis", 13 },
                    { 15, new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8629), null, new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8629), "Approved", "Fault description for technician assignment 15", 9, "Technical Fault", "Medium", "Not Started", new DateTime(2025, 10, 24, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8629), null, "Robert Davis", 14 }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeReplacements",
                columns: new[] { "FridgeReplacementId", "ActionBy", "ActionDate", "AdditionalNotes", "ApplicationUserId", "ApprovedBy", "CustomerID", "DeclineReason", "NewFridgeInStockId", "OldFridgeNo", "ReasonForReplacement", "ReplacementDate", "ReplacementStatus", "RequestDate", "TechnicianNotes", "VisitId" },
                values: new object[,]
                {
                    { 1, null, null, "Fridge not cooling properly despite multiple repairs.", "10", null, 4, null, null, "FRG-005-003", "Fridge Beyond Repair - Compressor failure", new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8701), "Pending", new DateTime(2025, 10, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8701), "Multiple component failures detected during diagnostic testing.", 20 },
                    { 2, "Sarah Williams", new DateTime(2025, 11, 22, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8733), "Customer complains about high electricity consumption.", "11", "Service Department", 1, "Unit has cosmetic damage caused by customer misuse.", null, "FRG-012-002", "Old Age - Unit over 10 years old with deteriorating performance", new DateTime(2025, 11, 21, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8733), "Rejected", new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8733), "Condenser fan motor seized, causing overheating issues.", 14 },
                    { 3, null, null, "Customer complains about high electricity consumption.", "14", null, 5, null, null, "FRG-001-005", "Frequent Breakdowns - Multiple service calls in last 3 months", new DateTime(2025, 11, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8740), "Pending", new DateTime(2025, 11, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8740), "Main control board fried due to power surge - part discontinued.", 17 },
                    { 4, null, null, "Customer requesting energy efficient replacement model.", "23", null, 2, null, null, "FRG-006-007", "Customer Request - Customer requested upgrade to newer model", new DateTime(2025, 10, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8746), "Pending", new DateTime(2025, 10, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8746), "Evaporator fan motor noisy, replacement part no longer available.", 13 },
                    { 5, "Maria Garcia", new DateTime(2025, 12, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8750), "Interior lighting not working, bulbs already replaced.", "16", "Customer Service", 5, null, 69, "FRG-003-001", "Irreparable Cooling System - Refrigerant leak cannot be fixed", new DateTime(2025, 12, 2, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8750), "Approved", new DateTime(2025, 11, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8750), "Multiple component failures detected during diagnostic testing.", 16 },
                    { 6, "Jennifer Wilson", new DateTime(2025, 9, 30, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8757), "Ice buildup in freezer compartment even after defrosting.", "24", "Technical Support", 10, null, 148, "FRG-011-009", "Electrical Fault - Mainboard failure, replacement parts unavailable", new DateTime(2025, 9, 28, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8757), "Approved", new DateTime(2025, 9, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8757), "Main control board fried due to power surge - part discontinued.", 7 },
                    { 7, "John Smith", new DateTime(2025, 10, 19, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8762), "Unit making loud grinding noise during compressor operation.", "8", "Technical Support", 4, null, 135, "FRG-010-010", "Structural Damage - Internal corrosion affecting performance", new DateTime(2025, 10, 16, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8762), "Approved", new DateTime(2025, 10, 7, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8762), "Main control board fried due to power surge - part discontinued.", 4 },
                    { 8, null, null, "Water leakage from the unit causing floor damage.", "2", null, 6, null, null, "FRG-009-005", "Fridge Beyond Repair - Compressor failure", new DateTime(2025, 11, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8768), "Pending", new DateTime(2025, 10, 20, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8768), "Thermostat calibration off, causing temperature fluctuations.", 13 },
                    { 9, null, null, "Customer requesting energy efficient replacement model.", "11", null, 11, null, null, "FRG-004-010", "Customer Request - Customer requested upgrade to newer model", new DateTime(2025, 11, 4, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8773), "Pending", new DateTime(2025, 10, 14, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8773), "Thermostat calibration off, causing temperature fluctuations.", 13 },
                    { 10, "Robert Miller", new DateTime(2025, 10, 10, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8778), "Display panel malfunctioning, cannot adjust settings.", "13", "Support Team", 12, "Unit still under warranty, repair recommended instead.", null, "FRG-003-007", "Old Age - Unit over 10 years old with deteriorating performance", new DateTime(2025, 10, 6, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8778), "Rejected", new DateTime(2025, 10, 5, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8778), "Condenser fan motor seized, causing overheating issues.", 15 },
                    { 11, "Susan Thomas", new DateTime(2025, 11, 28, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8783), "Customer requesting energy efficient replacement model.", "5", "Manager Office", 2, "Inspection shows unit can be repaired economically.", null, "FRG-014-003", "Irreparable Cooling System - Refrigerant leak cannot be fixed", new DateTime(2025, 11, 27, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8783), "Rejected", new DateTime(2025, 10, 29, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8783), "Refrigerant leak detected in evaporator coils - uneconomical to repair.", 2 },
                    { 12, null, null, "Customer reported inconsistent temperature for several weeks.", "3", null, 5, null, null, "FRG-002-007", "Irreparable Cooling System - Refrigerant leak cannot be fixed", new DateTime(2025, 11, 9, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8788), "Pending", new DateTime(2025, 10, 25, 17, 35, 57, 775, DateTimeKind.Local).AddTicks(8788), "Defrost system malfunction leading to ice accumulation.", 4 }
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
