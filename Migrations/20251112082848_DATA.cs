using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class DATA : Migration
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAllocations_tblFridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "tblFridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblFridgeInStocks_FridgeInStockId",
                        column: x => x.FridgeInStockId,
                        principalTable: "tblFridgeInStocks",
                        principalColumn: "FridgeInStockId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerFridge_tblRequestDetais_RequestDetailId",
                        column: x => x.RequestDetailId,
                        principalTable: "tblRequestDetais",
                        principalColumn: "RequestDetailId",
                        onDelete: ReferentialAction.Cascade);
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
                    { "1", 0, "0111234567", "Johannesburg", "dea7b11e-4c75-4380-9f1f-210f52821a4a", null, "ApplicationUser", "admin@gmail.com", true, "John", true, "Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKqec9MrsLgu4wsuxk2dDIh6NYJJYfBpIr4cAQy1yANsSSuTVV2QNhJhRRuq15Bb3A==", null, false, "2000", null, "c593158b-cb34-4288-bad8-9eecdf581a34", "Gauteng", "Approved", "123 Admin Street", false, "admin@gmail.com" },
                    { "10", 0, "0148884567", "Rustenburg", "587f5038-b765-4c3c-ade5-442c9d5a1f4f", null, "ApplicationUser", "olivia.martinez@gmail.com", true, "Olivia", true, "Martinez", false, null, "OLIVIA.MARTINEZ@GMAIL.COM", "OLIVIA.MARTINEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEItD/dGzNzf/OJ8uUVOr+e3JxERdUHIkciCV/JL3FTZbYmfIkEFe97KSrgHSCVHEug==", null, false, "2999", null, "7a956e84-fdfc-4489-8746-95a61458b08c", "North West", "Approved", "741 Commercial Ave", false, "olivia.martinez@gmail.com" },
                    { "11", 0, "0315551234", "Durban", "65bc0fdf-316b-4fe6-9829-248c4e47535e", null, "ApplicationUser", "emily.wilson@gmail.com", true, "Emily", true, "Wilson", false, null, "EMILY.WILSON@GMAIL.COM", "EMILY.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEDYPEsejSG3oEkKs4nwy34zQu9lUFd7rAArZDIZCRyvSshA4o5ofm5YBIiApLqmPyQ==", null, false, "4001", null, "54fdaea5-021a-44bc-bfc7-2b089cca3d17", "KwaZulu-Natal", "Approved", "789 Support Road", false, "emily.wilson@gmail.com" },
                    { "12", 0, "0124445678", "Pretoria", "d9bd7e83-97d2-42b9-8083-7ba0781846eb", null, "ApplicationUser", "michael.brown@gmail.com", true, "Michael", true, "Brown", false, null, "MICHAEL.BROWN@GMAIL.COM", "MICHAEL.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAECgJ/QDIwRllVUZyP0FP/MG7VQUt6+z5spvYZXSfItE/ym4P3eHTZJJ6KCW03Pb/xg==", null, false, "0002", null, "7fe5d564-8af3-4200-b6d4-3da216aa06c9", "Gauteng", "Approved", "321 Help Street", false, "michael.brown@gmail.com" },
                    { "13", 0, "0113337890", "Johannesburg", "409ec9a0-836b-498d-b795-7fb97c0e1036", null, "ApplicationUser", "david.taylor@gmail.com", true, "David", true, "Taylor", false, null, "DAVID.TAYLOR@GMAIL.COM", "DAVID.TAYLOR@GMAIL.COM", "AQAAAAIAAYagAAAAEEgXfPWwLIJt+zWSFv848KjkdySmk3dknSfLO+6h5GGVB6cZDyucv0MzKhehafYxAA==", null, false, "2001", null, "3328a7b9-393b-4cf9-b7ef-6281d9887a5a", "Gauteng", "Approved", "654 Warehouse Ave", false, "david.taylor@gmail.com" },
                    { "14", 0, "0216667890", "Cape Town", "cefe35a9-bf38-4273-88f3-bcab183df9d1", null, "ApplicationUser", "sarah.anderson@gmail.com", true, "Sarah", true, "Anderson", false, null, "SARAH.ANDERSON@GMAIL.COM", "SARAH.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAEEGqQgp4xurYOSBgiSN0Kp8vC5mQNdlvH8YDiAKy+HpzdoQ/eAhiGY8J4JgD6YO+Ag==", null, false, "8001", null, "3466fc58-adff-4c45-b509-9753f9f4770c", "Western Cape", "Approved", "852 Inventory Street", false, "sarah.anderson@gmail.com" },
                    { "15", 0, "0212224567", "Cape Town", "08b4fb37-7657-4f0f-ad80-801e6d176a71", null, "ApplicationUser", "robert.davis@gmail.com", true, "Robert", true, "Davis", false, null, "ROBERT.DAVIS@GMAIL.COM", "ROBERT.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEN6d+LLRrqwrloyJgLw2iklHxK4myNNVBnlKNmnwEirXrUA2JVbs/wIas9UL2E38Xg==", null, false, "8001", null, "29c44d92-eef8-4a07-99cb-ac93271447e1", "Western Cape", "Approved", "987 Service Road", false, "robert.davis@gmail.com" },
                    { "16", 0, "0317778901", "Durban", "3f51c61d-a8f9-4152-aafc-ab99cb683276", null, "ApplicationUser", "jennifer.martin@gmail.com", true, "Jennifer", true, "Martin", false, null, "JENNIFER.MARTIN@GMAIL.COM", "JENNIFER.MARTIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBy1yfJy/NIZb3Ukw6PTwkykSTB+cltMGtmI3lQPqk1Amsh9l1G/ZgOZNZfhlAYbCg==", null, false, "4001", null, "99ae0e2a-7ec4-4ddf-b9cc-0986863b14b1", "KwaZulu-Natal", "Approved", "147 Repair Lane", false, "jennifer.martin@gmail.com" },
                    { "17", 0, "0118881234", "Johannesburg", "83d2f232-4ce9-411f-9f2c-82358b8ecbc2", null, "ApplicationUser", "james.miller@gmail.com", true, "James", true, "Miller", false, null, "JAMES.MILLER@GMAIL.COM", "JAMES.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEMhJz+LLoKEuhZYq8/QjLJItRmwZMokMQUnsu9jcr3aihLGY7q/MZ5j7tzyVzlxMcA==", null, false, "2001", null, "6e3d3d9e-7ec6-470c-b000-0192cee9830e", "Gauteng", "Approved", "258 Fault Street", false, "james.miller@gmail.com" },
                    { "18", 0, "0129994567", "Pretoria", "7fb4104a-f8a8-4f6a-8dcb-d9cb29256380", null, "ApplicationUser", "patricia.white@gmail.com", true, "Patricia", true, "White", false, null, "PATRICIA.WHITE@GMAIL.COM", "PATRICIA.WHITE@GMAIL.COM", "AQAAAAIAAYagAAAAEISdygAYQkH2DlWmrakvoNE7iXioFfY2KMx0OE4ya/ELG7lUyHkTzNuTSmTVpCRLuw==", null, false, "0002", null, "be2a261d-895a-4715-ae92-6b735ca26dee", "Gauteng", "Approved", "369 Diagnostic Road", false, "patricia.white@gmail.com" },
                    { "2", 0, "0219876543", "Cape Town", "f6fc9592-5797-48c3-aa54-b18d2e57ad91", null, "ApplicationUser", "sarah.johnson@gmail.com", true, "Sarah", true, "Johnson", false, null, "SARAH.JOHNSON@GMAIL.COM", "SARAH.JOHNSON@GMAIL.COM", "AQAAAAIAAYagAAAAELPsl1b0GfN8qbVlUflvEOdSn+hiywgv6wjcQyf7QPzrMV+YtetlWzxXqZrvrwdSGA==", null, false, "8001", null, "cd496a2a-d3b8-49fa-9180-0fe82ab045de", "Western Cape", "Approved", "456 Management Ave", false, "sarah.johnson@gmail.com" },
                    { "21", 0, "0439991234", "East London", "1bd645de-5274-424b-852d-2581bd55e8b8", null, "ApplicationUser", "william.thomas@gmail.com", true, "William", true, "Thomas", false, null, "WILLIAM.THOMAS@GMAIL.COM", "WILLIAM.THOMAS@GMAIL.COM", "AQAAAAIAAYagAAAAEEqlVv7Sx8P+STNdkbMAAsp5MFj8Kue/lJfqvQwU9SkObMdBuSIlU4TvcbLGTmIPag==", null, false, "5201", null, "58a981ae-c5a4-4a0a-8b6a-cf6f69cbb403", "Eastern Cape", "Approved", "852 Enterprise Street", false, "william.thomas@gmail.com" },
                    { "22", 0, "0338885678", "Pietermaritzburg", "c655d0a2-ec00-4b2b-b651-4e888b9c201f", null, "ApplicationUser", "ava.robinson@gmail.com", true, "Ava", true, "Robinson", false, null, "AVA.ROBINSON@GMAIL.COM", "AVA.ROBINSON@GMAIL.COM", "AQAAAAIAAYagAAAAEKmSXFG0sb3a7I5fY7nNUPPkc4+bZ9Veh7gFUbkahre5MPRSu7kZNuNmIAWw0BNxtA==", null, false, "3201", null, "34a22014-9c65-4bc4-8fd3-a0540b34a338", "KwaZulu-Natal", "Approved", "963 Corporate Road", false, "ava.robinson@gmail.com" },
                    { "23", 0, "0577779012", "Welkom", "7163c96d-f266-475f-949a-f650334fd502", null, "ApplicationUser", "noah.clark@gmail.com", true, "Noah", true, "Clark", false, null, "NOAH.CLARK@GMAIL.COM", "NOAH.CLARK@GMAIL.COM", "AQAAAAIAAYagAAAAEMTohiPqUD8nzWQkjeKj0DjdbfjxoiK8yDq1n2FK4db9dJPefVe26VLqj2K5FwOdXQ==", null, false, "9460", null, "4143a003-f71a-4953-b8bc-c4fde2232d26", "Free State", "Approved", "159 Business Park", false, "noah.clark@gmail.com" },
                    { "24", 0, "0136663456", "Witbank", "68ed9196-8dac-46b2-a3ca-772f32ee40a7", null, "ApplicationUser", "isabella.rodriguez@gmail.com", true, "Isabella", true, "Rodriguez", false, null, "ISABELLA.RODRIGUEZ@GMAIL.COM", "ISABELLA.RODRIGUEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEKbdXTPKWQfEQhkP4qYe8dryO2Pw9sPoeW/L1zKNfCkMVWaG4eAAtOndhgdf31oLcQ==", null, false, "1035", null, "389c747d-f091-4517-a2f7-f4ec500f1133", "Mpumalanga", "Approved", "753 Industrial Area", false, "isabella.rodriguez@gmail.com" },
                    { "25", 0, "0117772345", "Johannesburg", "c54b4fd1-ca8c-44c0-aa1d-0ee5210d72cd", null, "ApplicationUser", "daniel.moore@gmail.com", true, "Daniel", true, "Moore", false, null, "DANIEL.MOORE@GMAIL.COM", "DANIEL.MOORE@GMAIL.COM", "AQAAAAIAAYagAAAAEJ3VE/VrpNj6HmFqCqUam3Zy6yyVqsTbYQEggdVRYSwJuDlrgsIfUYfEviO9Ntl9Vg==", null, false, "2001", null, "103e4d4c-82c5-4254-90a3-dd7edfb0e59c", "Gauteng", "Approved", "456 Service Lane", false, "daniel.moore@gmail.com" },
                    { "26", 0, "0215556789", "Cape Town", "f3031d6e-92de-4997-995b-882999ca95c1", null, "ApplicationUser", "susan.lee@gmail.com", true, "Susan", true, "Lee", false, null, "SUSAN.LEE@GMAIL.COM", "SUSAN.LEE@GMAIL.COM", "AQAAAAIAAYagAAAAEBiO3KStK/4rjoCpXqm/Un+G3bQ3pF0Y1JPFKQyLHziR60o8+y/34L+304d+4N+d8w==", null, false, "8001", null, "a30aa5c6-93b1-4d29-9ad3-f449b27b06c4", "Western Cape", "Approved", "789 Stock Avenue", false, "susan.lee@gmail.com" },
                    { "3", 0, "0315551234", "Durban", "563ae4d1-2d48-44e4-9c09-b15f1c7f34ff", null, "ApplicationUser", "mike.wilson@gmail.com", true, "Mike", true, "Wilson", false, null, "MIKE.WILSON@GMAIL.COM", "MIKE.WILSON@GMAIL.COM", "AQAAAAIAAYagAAAAEE57QMYWc8FkaIifrQ1gqZe/EJOluq42rnf9Ty9z3i9vRs3/Nik9/bs5Xft6Hidy7w==", null, false, "4001", null, "9c9b992b-aa81-4f16-96d1-583aae5bd63d", "KwaZulu-Natal", "Approved", "789 Customer Road", false, "mike.wilson@gmail.com" },
                    { "4", 0, "0124445678", "Pretoria", "f2c27b52-2db1-43ad-bb6b-06eda61b0d0c", null, "ApplicationUser", "lisa.brown@gmail.com", true, "Lisa", true, "Brown", false, null, "LISA.BROWN@GMAIL.COM", "LISA.BROWN@GMAIL.COM", "AQAAAAIAAYagAAAAEOsYq061pN8NwfajQ2hkK4/LIS0Qg3a4884ma3wWRz80tIoXSIvACEGCnQVX0EQNcQ==", null, false, "0002", null, "27a4ed2a-3b5d-44e7-8a72-344e23ae7706", "Gauteng", "Approved", "321 Business Street", false, "lisa.brown@gmail.com" },
                    { "5", 0, "0413337890", "Port Elizabeth", "c09a67ac-29a6-4652-b71e-edc3bf03d4b0", null, "ApplicationUser", "david.jackson@gmail.com", true, "David", true, "Jackson", false, null, "DAVID.JACKSON@GMAIL.COM", "DAVID.JACKSON@GMAIL.COM", "AQAAAAIAAYagAAAAEKYI30ZgzZBGTEo28R1vDiNOFhES7s8c4qwYBEGHD381/QsbLdsyB67DSG9P3++G9w==", null, false, "6001", null, "57afb144-055c-4967-b76e-2202fd04a3ff", "Eastern Cape", "Approved", "654 Retail Avenue", false, "david.jackson@gmail.com" },
                    { "6", 0, "0512224567", "Bloemfontein", "d898f080-e66b-4250-a266-1d88dfa0a358", null, "ApplicationUser", "emma.davis@gmail.com", true, "Emma", true, "Davis", false, null, "EMMA.DAVIS@GMAIL.COM", "EMMA.DAVIS@GMAIL.COM", "AQAAAAIAAYagAAAAEAbkFBeIGvsIS0NQVvldHTS4Xd/sLd4B5IpZ1HFr+v1EgMjBW5jCWAyT+7wJhtaHKQ==", null, false, "9301", null, "6519c86c-21a2-4973-9668-e5b46f8c4b2d", "Free State", "Approved", "987 Commerce Road", false, "emma.davis@gmail.com" },
                    { "7", 0, "0131112345", "Nelspruit", "3fb8c047-f281-4a7b-9a90-d7ed2008355b", null, "ApplicationUser", "robert.miller@gmail.com", true, "Robert", true, "Miller", false, null, "ROBERT.MILLER@GMAIL.COM", "ROBERT.MILLER@GMAIL.COM", "AQAAAAIAAYagAAAAEBfs4j9KcNsAsyVLleAQdrfQgq+KXzlDPpcVRO6xk+btLJGkIrYyLCO8gkVEOkqVQg==", null, false, "1200", null, "e24826c8-211f-4ede-813b-b35c0df5f2c9", "Mpumalanga", "Approved", "147 Trade Street", false, "robert.miller@gmail.com" },
                    { "8", 0, "0156667890", "Polokwane", "b5b627c7-0cd5-47fe-9541-ba81aaa2e18f", null, "ApplicationUser", "sophia.garcia@gmail.com", true, "Sophia", true, "Garcia", false, null, "SOPHIA.GARCIA@GMAIL.COM", "SOPHIA.GARCIA@GMAIL.COM", "AQAAAAIAAYagAAAAEIteYEsKfvggZPN0J4Bcs6y1EF1Ysrap4nnjgT3MK8uaGMUomCW695Vil/GuPhKSVw==", null, false, "0700", null, "7846fb0a-dbcc-415b-a72a-617290bfdc4b", "Limpopo", "Approved", "258 Market Lane", false, "sophia.garcia@gmail.com" },
                    { "9", 0, "0537771234", "Kimberley", "477626fb-d2b5-4f1b-8365-e612a3cc3849", null, "ApplicationUser", "james.anderson@gmail.com", true, "James", true, "Anderson", false, null, "JAMES.ANDERSON@GMAIL.COM", "JAMES.ANDERSON@GMAIL.COM", "AQAAAAIAAYagAAAAELPLfZn5TkLuPQzudMF8AUEs5CrZevMecjvSsxxdPmoRSHMY759L31f/zl5d4ejEjg==", null, false, "8301", null, "83cacf5f-aadf-42a5-823b-67f7cba0be49", "Northern Cape", "Approved", "369 Industry Road", false, "james.anderson@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBusinessInfo",
                columns: new[] { "BusinessID", "Address", "BusinessName", "BusinessType", "City", "Country", "CreatedAt", "Email", "Industry", "LogoData", "LogoPath", "PhoneNumber", "PostalCode", "RegistrationNumber", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "FridgeHub Enterprises", "Fridge Rental", "Johannesburg", "South Africa", new DateTime(2023, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9229), "info@gmail.com", "Appliance Rental", null, null, "0111234567", "2000", "2024FH001", "www.fridgehub.com" },
                    { 2, "456 Service Road", "Cool Solutions SA", "Appliance Services", "Cape Town", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9234), "admin@coolsolutions.co.za", "Maintenance Services", null, null, "0219876543", "8001", "2023CS002", "www.coolsolutions.co.za" },
                    { 3, "789 Coastal Road", "Fridge Rentals Durban", "Rental Services", "Durban", "South Africa", new DateTime(2025, 5, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9238), "rentals@fridgedurban.co.za", "Appliance Rental", null, null, "0315551234", "4001", "2024FR003", "www.fridgedurban.co.za" },
                    { 4, "321 Capital Avenue", "Pretoria Cooling Systems", "HVAC Services", "Pretoria", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9243), "info@pretoriacooling.co.za", "Cooling Systems", null, null, "0124445678", "0002", "2023PCS004", "www.pretoriacooling.co.za" },
                    { 5, "654 Ocean View", "Eastern Cape Appliances", "Appliance Retail", "Port Elizabeth", "South Africa", new DateTime(2025, 3, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9246), "sales@ecappliances.co.za", "Retail", null, null, "0413337890", "6001", "2024ECA005", "www.ecappliances.co.za" },
                    { 6, "987 Central Street", "Free State Cooling", "Cooling Solutions", "Bloemfontein", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9249), "contact@fscooling.co.za", "HVAC Services", null, null, "0512224567", "9301", "2023FSC006", "www.fscooling.co.za" },
                    { 7, "147 Highlands Road", "Mpumalanga Fridge Rentals", "Rental Services", "Nelspruit", "South Africa", new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9251), "info@mpumalangafridges.co.za", "Appliance Rental", null, null, "0131112345", "1200", "2024MFR007", "www.mpumalangafridges.co.za" },
                    { 8, "258 Bushveld Street", "Limpopo Cooling Experts", "Technical Services", "Polokwane", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9254), "support@limpopocooling.co.za", "Cooling Systems", null, null, "0156667890", "0700", "2023LCE008", "www.limpopocooling.co.za" },
                    { 9, "369 Diamond Road", "Northern Cape Appliances", "Appliance Sales", "Kimberley", "South Africa", new DateTime(2025, 1, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9256), "sales@ncappliances.co.za", "Retail", null, null, "0537771234", "8301", "2024NCA009", "www.ncappliances.co.za" },
                    { 10, "741 Platinum Avenue", "North West Cooling Solutions", "Cooling Services", "Rustenburg", "South Africa", new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9258), "info@nwcooling.co.za", "HVAC Services", null, null, "0148884567", "2999", "2023NWC010", "www.nwcooling.co.za" },
                    { 11, "852 Coastal Highway", "KZN Appliance Rentals", "Rental Services", "Pietermaritzburg", "South Africa", new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9261), "rentals@kznappliances.co.za", "Appliance Rental", null, null, "0338885678", "3201", "2024KZNR011", "www.kznappliances.co.za" },
                    { 12, "963 Metro Road", "Gauteng Cooling Systems", "Technical Services", "Johannesburg", "South Africa", new DateTime(2023, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9263), "service@gautengcooling.co.za", "Cooling Systems", null, null, "0119992345", "2001", "2023GCS012", "www.gautengcooling.co.za" }
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
                    { 1, "Very Good", 1, "FRG-001-001", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6380), "Johannesburg Main", 1, null, "Available" },
                    { 2, "Good", 1, "FRG-001-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6427), "Cape Town Storage", 1, null, "Available" },
                    { 3, "Very Good", 1, "FRG-001-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6431), "Durban Warehouse", 1, null, "Available" },
                    { 4, "Excellent", 1, "FRG-001-004", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6435), "Cape Town Storage", 1, null, "Available" },
                    { 5, "Good", 1, "FRG-001-005", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6439), "Port Elizabeth Depot", 1, null, "Available" },
                    { 6, "Good", 1, "FRG-001-006", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6447), "Cape Town Storage", 1, null, "Available" },
                    { 7, "Very Good", 1, "FRG-001-007", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6451), "Durban Warehouse", 1, null, "Available" },
                    { 8, "Excellent", 1, "FRG-001-008", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6455), "Durban Warehouse", 1, null, "Available" },
                    { 9, "Good", 1, "FRG-001-009", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6459), "Pretoria Facility", 1, null, "Available" },
                    { 10, "Very Good", 1, "FRG-001-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6465), "Port Elizabeth Depot", 1, null, "Available" },
                    { 11, "Very Good", 2, "FRG-002-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6469), "Johannesburg Main", 1, null, "Available" },
                    { 12, "Very Good", 2, "FRG-002-002", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6474), "Johannesburg Main", 1, null, "Available" },
                    { 13, "Excellent", 2, "FRG-002-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6478), "Port Elizabeth Depot", 1, null, "Available" },
                    { 14, "Very Good", 2, "FRG-002-004", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6482), "Durban Warehouse", 1, null, "Available" },
                    { 15, "Good", 2, "FRG-002-005", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6519), "Port Elizabeth Depot", 1, null, "Available" },
                    { 16, "Excellent", 2, "FRG-002-006", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6530), "Johannesburg Main", 1, null, "Available" },
                    { 17, "Very Good", 2, "FRG-002-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6535), "Pretoria Facility", 1, null, "Available" },
                    { 18, "Excellent", 2, "FRG-002-008", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6540), "Johannesburg Main", 1, null, "Available" },
                    { 19, "Excellent", 2, "FRG-002-009", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6544), "Cape Town Storage", 1, null, "Available" },
                    { 20, "Excellent", 2, "FRG-002-010", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6548), "Port Elizabeth Depot", 1, null, "Available" },
                    { 21, "Good", 3, "FRG-003-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6552), "Cape Town Storage", 1, null, "Available" },
                    { 22, "Very Good", 3, "FRG-003-002", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6556), "Johannesburg Main", 1, null, "Available" },
                    { 23, "Excellent", 3, "FRG-003-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6560), "Pretoria Facility", 1, null, "Available" },
                    { 24, "Very Good", 3, "FRG-003-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6564), "Johannesburg Main", 1, null, "Available" },
                    { 25, "Excellent", 3, "FRG-003-005", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6568), "Cape Town Storage", 1, null, "Available" },
                    { 26, "Good", 3, "FRG-003-006", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6571), "Cape Town Storage", 1, null, "Available" },
                    { 27, "Excellent", 3, "FRG-003-007", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6587), "Durban Warehouse", 1, null, "Available" },
                    { 28, "Excellent", 3, "FRG-003-008", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6599), "Cape Town Storage", 1, null, "Available" },
                    { 29, "Excellent", 3, "FRG-003-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6603), "Cape Town Storage", 1, null, "Available" },
                    { 30, "Good", 3, "FRG-003-010", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6631), "Pretoria Facility", 1, null, "Available" },
                    { 31, "Excellent", 4, "FRG-004-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6648), "Pretoria Facility", 1, null, "Available" },
                    { 32, "Excellent", 4, "FRG-004-002", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6652), "Cape Town Storage", 1, null, "Available" },
                    { 33, "Excellent", 4, "FRG-004-003", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6656), "Port Elizabeth Depot", 1, null, "Available" },
                    { 34, "Excellent", 4, "FRG-004-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6661), "Port Elizabeth Depot", 1, null, "Available" },
                    { 35, "Excellent", 4, "FRG-004-005", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6665), "Johannesburg Main", 1, null, "Available" },
                    { 36, "Excellent", 4, "FRG-004-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6669), "Port Elizabeth Depot", 1, null, "Available" },
                    { 37, "Excellent", 4, "FRG-004-007", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6674), "Johannesburg Main", 1, null, "Available" },
                    { 38, "Good", 4, "FRG-004-008", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6678), "Cape Town Storage", 1, null, "Available" },
                    { 39, "Excellent", 4, "FRG-004-009", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6682), "Pretoria Facility", 1, null, "Available" },
                    { 40, "Good", 4, "FRG-004-010", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6686), "Durban Warehouse", 1, null, "Available" },
                    { 41, "Good", 5, "FRG-005-001", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6690), "Durban Warehouse", 1, null, "Available" },
                    { 42, "Good", 5, "FRG-005-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6694), "Durban Warehouse", 1, null, "Available" },
                    { 43, "Good", 5, "FRG-005-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6698), "Johannesburg Main", 1, null, "Available" },
                    { 44, "Very Good", 5, "FRG-005-004", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6703), "Johannesburg Main", 1, null, "Available" },
                    { 45, "Good", 5, "FRG-005-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6707), "Pretoria Facility", 1, null, "Available" },
                    { 46, "Good", 5, "FRG-005-006", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6711), "Durban Warehouse", 1, null, "Available" },
                    { 47, "Good", 5, "FRG-005-007", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6715), "Durban Warehouse", 1, null, "Available" },
                    { 48, "Very Good", 5, "FRG-005-008", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6719), "Durban Warehouse", 1, null, "Available" },
                    { 49, "Very Good", 5, "FRG-005-009", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6723), "Durban Warehouse", 1, null, "Available" },
                    { 50, "Excellent", 5, "FRG-005-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6728), "Pretoria Facility", 1, null, "Available" },
                    { 51, "Very Good", 6, "FRG-006-001", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6765), "Cape Town Storage", 1, null, "Available" },
                    { 52, "Very Good", 6, "FRG-006-002", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6770), "Johannesburg Main", 1, null, "Available" },
                    { 53, "Good", 6, "FRG-006-003", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6774), "Durban Warehouse", 1, null, "Available" },
                    { 54, "Very Good", 6, "FRG-006-004", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6778), "Durban Warehouse", 1, null, "Available" },
                    { 55, "Excellent", 6, "FRG-006-005", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6782), "Durban Warehouse", 1, null, "Available" },
                    { 56, "Excellent", 6, "FRG-006-006", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6786), "Johannesburg Main", 1, null, "Available" },
                    { 57, "Very Good", 6, "FRG-006-007", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6790), "Port Elizabeth Depot", 1, null, "Available" },
                    { 58, "Excellent", 6, "FRG-006-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6794), "Pretoria Facility", 1, null, "Available" },
                    { 59, "Very Good", 6, "FRG-006-009", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6798), "Port Elizabeth Depot", 1, null, "Available" },
                    { 60, "Good", 6, "FRG-006-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6802), "Cape Town Storage", 1, null, "Available" },
                    { 61, "Good", 7, "FRG-007-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6806), "Pretoria Facility", 1, null, "Available" },
                    { 62, "Good", 7, "FRG-007-002", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6810), "Durban Warehouse", 1, null, "Available" },
                    { 63, "Very Good", 7, "FRG-007-003", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6814), "Port Elizabeth Depot", 1, null, "Available" },
                    { 64, "Excellent", 7, "FRG-007-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6819), "Pretoria Facility", 1, null, "Available" },
                    { 65, "Good", 7, "FRG-007-005", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6823), "Johannesburg Main", 1, null, "Available" },
                    { 66, "Excellent", 7, "FRG-007-006", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6829), "Durban Warehouse", 1, null, "Available" },
                    { 67, "Good", 7, "FRG-007-007", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6833), "Port Elizabeth Depot", 1, null, "Available" },
                    { 68, "Good", 7, "FRG-007-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6837), "Cape Town Storage", 1, null, "Available" },
                    { 69, "Good", 7, "FRG-007-009", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6841), "Port Elizabeth Depot", 1, null, "Available" },
                    { 70, "Excellent", 7, "FRG-007-010", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6845), "Port Elizabeth Depot", 1, null, "Available" },
                    { 71, "Very Good", 8, "FRG-008-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6849), "Durban Warehouse", 1, null, "Available" },
                    { 72, "Excellent", 8, "FRG-008-002", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6853), "Johannesburg Main", 1, null, "Available" },
                    { 73, "Excellent", 8, "FRG-008-003", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6858), "Cape Town Storage", 1, null, "Available" },
                    { 74, "Very Good", 8, "FRG-008-004", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6862), "Cape Town Storage", 1, null, "Available" },
                    { 75, "Very Good", 8, "FRG-008-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6866), "Johannesburg Main", 1, null, "Available" },
                    { 76, "Excellent", 8, "FRG-008-006", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6870), "Pretoria Facility", 1, null, "Available" },
                    { 77, "Good", 8, "FRG-008-007", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6874), "Cape Town Storage", 1, null, "Available" },
                    { 78, "Excellent", 8, "FRG-008-008", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6878), "Johannesburg Main", 1, null, "Available" },
                    { 79, "Good", 8, "FRG-008-009", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6882), "Johannesburg Main", 1, null, "Available" },
                    { 80, "Very Good", 8, "FRG-008-010", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6886), "Johannesburg Main", 1, null, "Available" },
                    { 81, "Good", 9, "FRG-009-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6890), "Port Elizabeth Depot", 1, null, "Available" },
                    { 82, "Good", 9, "FRG-009-002", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6894), "Cape Town Storage", 1, null, "Available" },
                    { 83, "Excellent", 9, "FRG-009-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6898), "Pretoria Facility", 1, null, "Available" },
                    { 84, "Excellent", 9, "FRG-009-004", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6902), "Johannesburg Main", 1, null, "Available" },
                    { 85, "Good", 9, "FRG-009-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6906), "Port Elizabeth Depot", 1, null, "Available" },
                    { 86, "Good", 9, "FRG-009-006", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6910), "Durban Warehouse", 1, null, "Available" },
                    { 87, "Excellent", 9, "FRG-009-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6914), "Durban Warehouse", 1, null, "Available" },
                    { 88, "Good", 9, "FRG-009-008", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6918), "Johannesburg Main", 1, null, "Available" },
                    { 89, "Excellent", 9, "FRG-009-009", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6922), "Port Elizabeth Depot", 1, null, "Available" },
                    { 90, "Excellent", 9, "FRG-009-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6927), "Durban Warehouse", 1, null, "Available" },
                    { 91, "Good", 10, "FRG-010-001", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6931), "Durban Warehouse", 1, null, "Available" },
                    { 92, "Excellent", 10, "FRG-010-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6935), "Cape Town Storage", 1, null, "Available" },
                    { 93, "Excellent", 10, "FRG-010-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6939), "Pretoria Facility", 1, null, "Available" },
                    { 94, "Very Good", 10, "FRG-010-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6944), "Johannesburg Main", 1, null, "Available" },
                    { 95, "Good", 10, "FRG-010-005", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6949), "Port Elizabeth Depot", 1, null, "Available" },
                    { 96, "Good", 10, "FRG-010-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6953), "Cape Town Storage", 1, null, "Available" },
                    { 97, "Excellent", 10, "FRG-010-007", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6957), "Pretoria Facility", 1, null, "Available" },
                    { 98, "Excellent", 10, "FRG-010-008", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6962), "Cape Town Storage", 1, null, "Available" },
                    { 99, "Good", 10, "FRG-010-009", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6966), "Cape Town Storage", 1, null, "Available" },
                    { 100, "Excellent", 10, "FRG-010-010", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6970), "Pretoria Facility", 1, null, "Available" },
                    { 101, "Excellent", 11, "FRG-011-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6975), "Port Elizabeth Depot", 1, null, "Available" },
                    { 102, "Excellent", 11, "FRG-011-002", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6979), "Port Elizabeth Depot", 1, null, "Available" },
                    { 103, "Excellent", 11, "FRG-011-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6984), "Port Elizabeth Depot", 1, null, "Available" },
                    { 104, "Excellent", 11, "FRG-011-004", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6988), "Durban Warehouse", 1, null, "Available" },
                    { 105, "Excellent", 11, "FRG-011-005", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6992), "Johannesburg Main", 1, null, "Available" },
                    { 106, "Good", 11, "FRG-011-006", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(6996), "Durban Warehouse", 1, null, "Available" },
                    { 107, "Good", 11, "FRG-011-007", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7008), "Pretoria Facility", 1, null, "Available" },
                    { 108, "Good", 11, "FRG-011-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7013), "Johannesburg Main", 1, null, "Available" },
                    { 109, "Good", 11, "FRG-011-009", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7017), "Johannesburg Main", 1, null, "Available" },
                    { 110, "Excellent", 11, "FRG-011-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7021), "Port Elizabeth Depot", 1, null, "Available" },
                    { 111, "Excellent", 12, "FRG-012-001", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7026), "Pretoria Facility", 1, null, "Available" },
                    { 112, "Very Good", 12, "FRG-012-002", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7029), "Pretoria Facility", 1, null, "Available" },
                    { 113, "Very Good", 12, "FRG-012-003", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7034), "Pretoria Facility", 1, null, "Available" },
                    { 114, "Good", 12, "FRG-012-004", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7038), "Cape Town Storage", 1, null, "Available" },
                    { 115, "Good", 12, "FRG-012-005", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7043), "Johannesburg Main", 1, null, "Available" },
                    { 116, "Good", 12, "FRG-012-006", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7047), "Johannesburg Main", 1, null, "Available" },
                    { 117, "Excellent", 12, "FRG-012-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7052), "Cape Town Storage", 1, null, "Available" },
                    { 118, "Excellent", 12, "FRG-012-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7056), "Durban Warehouse", 1, null, "Available" },
                    { 119, "Good", 12, "FRG-012-009", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7060), "Durban Warehouse", 1, null, "Available" },
                    { 120, "Very Good", 12, "FRG-012-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7064), "Johannesburg Main", 1, null, "Available" },
                    { 121, "Very Good", 13, "FRG-013-001", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7069), "Pretoria Facility", 1, null, "Available" },
                    { 122, "Excellent", 13, "FRG-013-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7074), "Johannesburg Main", 1, null, "Available" },
                    { 123, "Excellent", 13, "FRG-013-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7078), "Cape Town Storage", 1, null, "Available" },
                    { 124, "Good", 13, "FRG-013-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7082), "Cape Town Storage", 1, null, "Available" },
                    { 125, "Good", 13, "FRG-013-005", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7086), "Port Elizabeth Depot", 1, null, "Available" },
                    { 126, "Excellent", 13, "FRG-013-006", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7091), "Durban Warehouse", 1, null, "Available" },
                    { 127, "Good", 13, "FRG-013-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7095), "Port Elizabeth Depot", 1, null, "Available" },
                    { 128, "Excellent", 13, "FRG-013-008", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7099), "Durban Warehouse", 1, null, "Available" },
                    { 129, "Excellent", 13, "FRG-013-009", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7103), "Port Elizabeth Depot", 1, null, "Available" },
                    { 130, "Good", 13, "FRG-013-010", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7108), "Port Elizabeth Depot", 1, null, "Available" },
                    { 131, "Good", 14, "FRG-014-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7113), "Cape Town Storage", 1, null, "Available" },
                    { 132, "Good", 14, "FRG-014-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7117), "Cape Town Storage", 1, null, "Available" },
                    { 133, "Excellent", 14, "FRG-014-003", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7121), "Johannesburg Main", 1, null, "Available" },
                    { 134, "Good", 14, "FRG-014-004", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7125), "Pretoria Facility", 1, null, "Available" },
                    { 135, "Good", 14, "FRG-014-005", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7129), "Pretoria Facility", 1, null, "Available" },
                    { 136, "Good", 14, "FRG-014-006", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7134), "Cape Town Storage", 1, null, "Available" },
                    { 137, "Good", 14, "FRG-014-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7138), "Cape Town Storage", 1, null, "Available" },
                    { 138, "Good", 14, "FRG-014-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7142), "Cape Town Storage", 1, null, "Available" },
                    { 139, "Excellent", 14, "FRG-014-009", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7146), "Port Elizabeth Depot", 1, null, "Available" },
                    { 140, "Good", 14, "FRG-014-010", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7150), "Pretoria Facility", 1, null, "Available" },
                    { 141, "Good", 15, "FRG-015-001", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7154), "Cape Town Storage", 1, null, "Available" },
                    { 142, "Good", 15, "FRG-015-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7158), "Port Elizabeth Depot", 1, null, "Available" },
                    { 143, "Good", 15, "FRG-015-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7161), "Pretoria Facility", 1, null, "Available" },
                    { 144, "Excellent", 15, "FRG-015-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7166), "Port Elizabeth Depot", 1, null, "Available" },
                    { 145, "Good", 15, "FRG-015-005", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7170), "Port Elizabeth Depot", 1, null, "Available" },
                    { 146, "Good", 15, "FRG-015-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7174), "Johannesburg Main", 1, null, "Available" },
                    { 147, "Excellent", 15, "FRG-015-007", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7178), "Pretoria Facility", 1, null, "Available" },
                    { 148, "Very Good", 15, "FRG-015-008", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7182), "Port Elizabeth Depot", 1, null, "Available" },
                    { 149, "Very Good", 15, "FRG-015-009", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7186), "Johannesburg Main", 1, null, "Available" },
                    { 150, "Excellent", 15, "FRG-015-010", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7191), "Johannesburg Main", 1, null, "Available" },
                    { 151, "Very Good", 16, "FRG-016-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7195), "Port Elizabeth Depot", 1, null, "Available" },
                    { 152, "Very Good", 16, "FRG-016-002", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7200), "Johannesburg Main", 1, null, "Available" },
                    { 153, "Very Good", 16, "FRG-016-003", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7203), "Durban Warehouse", 1, null, "Available" },
                    { 154, "Good", 16, "FRG-016-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7208), "Durban Warehouse", 1, null, "Available" },
                    { 155, "Very Good", 16, "FRG-016-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7217), "Johannesburg Main", 1, null, "Available" },
                    { 156, "Good", 16, "FRG-016-006", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7222), "Pretoria Facility", 1, null, "Available" },
                    { 157, "Excellent", 16, "FRG-016-007", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7226), "Durban Warehouse", 1, null, "Available" },
                    { 158, "Excellent", 16, "FRG-016-008", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7230), "Johannesburg Main", 1, null, "Available" },
                    { 159, "Excellent", 16, "FRG-016-009", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7233), "Durban Warehouse", 1, null, "Available" },
                    { 160, "Excellent", 16, "FRG-016-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7237), "Durban Warehouse", 1, null, "Available" },
                    { 161, "Excellent", 17, "FRG-017-001", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7241), "Johannesburg Main", 1, null, "Available" },
                    { 162, "Very Good", 17, "FRG-017-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7245), "Cape Town Storage", 1, null, "Available" },
                    { 163, "Excellent", 17, "FRG-017-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7249), "Pretoria Facility", 1, null, "Available" },
                    { 164, "Good", 17, "FRG-017-004", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7253), "Port Elizabeth Depot", 1, null, "Available" },
                    { 165, "Excellent", 17, "FRG-017-005", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7256), "Durban Warehouse", 1, null, "Available" },
                    { 166, "Excellent", 17, "FRG-017-006", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7260), "Durban Warehouse", 1, null, "Available" },
                    { 167, "Excellent", 17, "FRG-017-007", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7264), "Johannesburg Main", 1, null, "Available" },
                    { 168, "Very Good", 17, "FRG-017-008", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7377), "Port Elizabeth Depot", 1, null, "Available" },
                    { 169, "Good", 17, "FRG-017-009", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7382), "Durban Warehouse", 1, null, "Available" },
                    { 170, "Excellent", 17, "FRG-017-010", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7386), "Pretoria Facility", 1, null, "Available" },
                    { 171, "Excellent", 18, "FRG-018-001", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7390), "Pretoria Facility", 1, null, "Available" },
                    { 172, "Excellent", 18, "FRG-018-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7394), "Johannesburg Main", 1, null, "Available" },
                    { 173, "Very Good", 18, "FRG-018-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7397), "Johannesburg Main", 1, null, "Available" },
                    { 174, "Excellent", 18, "FRG-018-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7401), "Durban Warehouse", 1, null, "Available" },
                    { 175, "Good", 18, "FRG-018-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7405), "Johannesburg Main", 1, null, "Available" },
                    { 176, "Excellent", 18, "FRG-018-006", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7409), "Johannesburg Main", 1, null, "Available" },
                    { 177, "Good", 18, "FRG-018-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7413), "Durban Warehouse", 1, null, "Available" },
                    { 178, "Very Good", 18, "FRG-018-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7416), "Port Elizabeth Depot", 1, null, "Available" },
                    { 179, "Excellent", 18, "FRG-018-009", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7420), "Port Elizabeth Depot", 1, null, "Available" },
                    { 180, "Very Good", 18, "FRG-018-010", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7424), "Port Elizabeth Depot", 1, null, "Available" },
                    { 181, "Excellent", 19, "FRG-019-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7428), "Port Elizabeth Depot", 1, null, "Available" },
                    { 182, "Good", 19, "FRG-019-002", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7432), "Cape Town Storage", 1, null, "Available" },
                    { 183, "Good", 19, "FRG-019-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7436), "Pretoria Facility", 1, null, "Available" },
                    { 184, "Excellent", 19, "FRG-019-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7440), "Durban Warehouse", 1, null, "Available" },
                    { 185, "Good", 19, "FRG-019-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7443), "Cape Town Storage", 1, null, "Available" },
                    { 186, "Excellent", 19, "FRG-019-006", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7447), "Pretoria Facility", 1, null, "Available" },
                    { 187, "Very Good", 19, "FRG-019-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7451), "Johannesburg Main", 1, null, "Available" },
                    { 188, "Good", 19, "FRG-019-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7455), "Cape Town Storage", 1, null, "Available" },
                    { 189, "Very Good", 19, "FRG-019-009", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7458), "Johannesburg Main", 1, null, "Available" },
                    { 190, "Good", 19, "FRG-019-010", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7462), "Pretoria Facility", 1, null, "Available" },
                    { 191, "Excellent", 20, "FRG-020-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7466), "Cape Town Storage", 1, null, "Available" },
                    { 192, "Good", 20, "FRG-020-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7470), "Pretoria Facility", 1, null, "Available" },
                    { 193, "Excellent", 20, "FRG-020-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7474), "Pretoria Facility", 1, null, "Available" },
                    { 194, "Excellent", 20, "FRG-020-004", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7478), "Durban Warehouse", 1, null, "Available" },
                    { 195, "Good", 20, "FRG-020-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7481), "Port Elizabeth Depot", 1, null, "Available" },
                    { 196, "Excellent", 20, "FRG-020-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7485), "Port Elizabeth Depot", 1, null, "Available" },
                    { 197, "Very Good", 20, "FRG-020-007", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7489), "Johannesburg Main", 1, null, "Available" },
                    { 198, "Excellent", 20, "FRG-020-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7493), "Port Elizabeth Depot", 1, null, "Available" },
                    { 199, "Good", 20, "FRG-020-009", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7496), "Johannesburg Main", 1, null, "Available" },
                    { 200, "Excellent", 20, "FRG-020-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7500), "Durban Warehouse", 1, null, "Available" },
                    { 201, "Excellent", 21, "FRG-021-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7504), "Cape Town Storage", 1, null, "Available" },
                    { 202, "Excellent", 21, "FRG-021-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7508), "Pretoria Facility", 1, null, "Available" },
                    { 203, "Good", 21, "FRG-021-003", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7512), "Pretoria Facility", 1, null, "Available" },
                    { 204, "Excellent", 21, "FRG-021-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7516), "Durban Warehouse", 1, null, "Available" },
                    { 205, "Very Good", 21, "FRG-021-005", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7519), "Port Elizabeth Depot", 1, null, "Available" },
                    { 206, "Very Good", 21, "FRG-021-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7523), "Johannesburg Main", 1, null, "Available" },
                    { 207, "Very Good", 21, "FRG-021-007", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7527), "Johannesburg Main", 1, null, "Available" },
                    { 208, "Very Good", 21, "FRG-021-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7531), "Pretoria Facility", 1, null, "Available" },
                    { 209, "Very Good", 21, "FRG-021-009", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7534), "Pretoria Facility", 1, null, "Available" },
                    { 210, "Good", 21, "FRG-021-010", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7538), "Johannesburg Main", 1, null, "Available" },
                    { 211, "Excellent", 22, "FRG-022-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7542), "Cape Town Storage", 1, null, "Available" },
                    { 212, "Good", 22, "FRG-022-002", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7546), "Port Elizabeth Depot", 1, null, "Available" },
                    { 213, "Good", 22, "FRG-022-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7550), "Durban Warehouse", 1, null, "Available" },
                    { 214, "Excellent", 22, "FRG-022-004", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7553), "Port Elizabeth Depot", 1, null, "Available" },
                    { 215, "Good", 22, "FRG-022-005", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7557), "Pretoria Facility", 1, null, "Available" },
                    { 216, "Excellent", 22, "FRG-022-006", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7561), "Pretoria Facility", 1, null, "Available" },
                    { 217, "Very Good", 22, "FRG-022-007", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7565), "Pretoria Facility", 1, null, "Available" },
                    { 218, "Good", 22, "FRG-022-008", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7569), "Durban Warehouse", 1, null, "Available" },
                    { 219, "Good", 22, "FRG-022-009", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7579), "Durban Warehouse", 1, null, "Available" },
                    { 220, "Good", 22, "FRG-022-010", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7582), "Port Elizabeth Depot", 1, null, "Available" },
                    { 221, "Excellent", 23, "FRG-023-001", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7587), "Johannesburg Main", 1, null, "Available" },
                    { 222, "Excellent", 23, "FRG-023-002", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7591), "Cape Town Storage", 1, null, "Available" },
                    { 223, "Very Good", 23, "FRG-023-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7594), "Pretoria Facility", 1, null, "Available" },
                    { 224, "Good", 23, "FRG-023-004", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7598), "Johannesburg Main", 1, null, "Available" },
                    { 225, "Good", 23, "FRG-023-005", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7602), "Johannesburg Main", 1, null, "Available" },
                    { 226, "Excellent", 23, "FRG-023-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7605), "Durban Warehouse", 1, null, "Available" },
                    { 227, "Good", 23, "FRG-023-007", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7609), "Cape Town Storage", 1, null, "Available" },
                    { 228, "Excellent", 23, "FRG-023-008", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7613), "Pretoria Facility", 1, null, "Available" },
                    { 229, "Good", 23, "FRG-023-009", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7616), "Johannesburg Main", 1, null, "Available" },
                    { 230, "Good", 23, "FRG-023-010", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7620), "Johannesburg Main", 1, null, "Available" },
                    { 231, "Good", 24, "FRG-024-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7624), "Johannesburg Main", 1, null, "Available" },
                    { 232, "Good", 24, "FRG-024-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7628), "Pretoria Facility", 1, null, "Available" },
                    { 233, "Good", 24, "FRG-024-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7632), "Johannesburg Main", 1, null, "Available" },
                    { 234, "Excellent", 24, "FRG-024-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7635), "Cape Town Storage", 1, null, "Available" },
                    { 235, "Good", 24, "FRG-024-005", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7639), "Pretoria Facility", 1, null, "Available" },
                    { 236, "Excellent", 24, "FRG-024-006", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7643), "Pretoria Facility", 1, null, "Available" },
                    { 237, "Good", 24, "FRG-024-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7646), "Cape Town Storage", 1, null, "Available" },
                    { 238, "Excellent", 24, "FRG-024-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7650), "Pretoria Facility", 1, null, "Available" },
                    { 239, "Very Good", 24, "FRG-024-009", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7654), "Cape Town Storage", 1, null, "Available" },
                    { 240, "Good", 24, "FRG-024-010", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7658), "Cape Town Storage", 1, null, "Available" },
                    { 241, "Good", 25, "FRG-025-001", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7661), "Durban Warehouse", 1, null, "Available" },
                    { 242, "Good", 25, "FRG-025-002", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7665), "Cape Town Storage", 1, null, "Available" },
                    { 243, "Good", 25, "FRG-025-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7669), "Pretoria Facility", 1, null, "Available" },
                    { 244, "Good", 25, "FRG-025-004", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7673), "Cape Town Storage", 1, null, "Available" },
                    { 245, "Very Good", 25, "FRG-025-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7676), "Pretoria Facility", 1, null, "Available" },
                    { 246, "Excellent", 25, "FRG-025-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7680), "Durban Warehouse", 1, null, "Available" },
                    { 247, "Good", 25, "FRG-025-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7684), "Cape Town Storage", 1, null, "Available" },
                    { 248, "Very Good", 25, "FRG-025-008", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7688), "Johannesburg Main", 1, null, "Available" },
                    { 249, "Good", 25, "FRG-025-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7692), "Durban Warehouse", 1, null, "Available" },
                    { 250, "Very Good", 25, "FRG-025-010", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7695), "Pretoria Facility", 1, null, "Available" },
                    { 251, "Good", 26, "FRG-026-001", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7699), "Pretoria Facility", 1, null, "Available" },
                    { 252, "Good", 26, "FRG-026-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7703), "Durban Warehouse", 1, null, "Available" },
                    { 253, "Excellent", 26, "FRG-026-003", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7707), "Cape Town Storage", 1, null, "Available" },
                    { 254, "Excellent", 26, "FRG-026-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7711), "Durban Warehouse", 1, null, "Available" },
                    { 255, "Very Good", 26, "FRG-026-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7715), "Cape Town Storage", 1, null, "Available" },
                    { 256, "Good", 26, "FRG-026-006", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7719), "Cape Town Storage", 1, null, "Available" },
                    { 257, "Good", 26, "FRG-026-007", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7723), "Cape Town Storage", 1, null, "Available" },
                    { 258, "Very Good", 26, "FRG-026-008", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7735), "Johannesburg Main", 1, null, "Available" },
                    { 259, "Very Good", 26, "FRG-026-009", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7739), "Cape Town Storage", 1, null, "Available" },
                    { 260, "Excellent", 26, "FRG-026-010", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7743), "Johannesburg Main", 1, null, "Available" },
                    { 261, "Excellent", 27, "FRG-027-001", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7746), "Pretoria Facility", 1, null, "Available" },
                    { 262, "Good", 27, "FRG-027-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7750), "Durban Warehouse", 1, null, "Available" },
                    { 263, "Excellent", 27, "FRG-027-003", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7754), "Durban Warehouse", 1, null, "Available" },
                    { 264, "Excellent", 27, "FRG-027-004", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7758), "Pretoria Facility", 1, null, "Available" },
                    { 265, "Excellent", 27, "FRG-027-005", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7761), "Pretoria Facility", 1, null, "Available" },
                    { 266, "Good", 27, "FRG-027-006", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7765), "Pretoria Facility", 1, null, "Available" },
                    { 267, "Good", 27, "FRG-027-007", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7768), "Johannesburg Main", 1, null, "Available" },
                    { 268, "Very Good", 27, "FRG-027-008", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7772), "Port Elizabeth Depot", 1, null, "Available" },
                    { 269, "Good", 27, "FRG-027-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7776), "Cape Town Storage", 1, null, "Available" },
                    { 270, "Excellent", 27, "FRG-027-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7780), "Pretoria Facility", 1, null, "Available" },
                    { 271, "Good", 28, "FRG-028-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7784), "Johannesburg Main", 1, null, "Available" },
                    { 272, "Good", 28, "FRG-028-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7787), "Durban Warehouse", 1, null, "Available" },
                    { 273, "Good", 28, "FRG-028-003", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7791), "Durban Warehouse", 1, null, "Available" },
                    { 274, "Good", 28, "FRG-028-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7795), "Port Elizabeth Depot", 1, null, "Available" },
                    { 275, "Excellent", 28, "FRG-028-005", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7799), "Pretoria Facility", 1, null, "Available" },
                    { 276, "Very Good", 28, "FRG-028-006", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7802), "Port Elizabeth Depot", 1, null, "Available" },
                    { 277, "Very Good", 28, "FRG-028-007", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7806), "Pretoria Facility", 1, null, "Available" },
                    { 278, "Good", 28, "FRG-028-008", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7810), "Pretoria Facility", 1, null, "Available" },
                    { 279, "Good", 28, "FRG-028-009", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7814), "Cape Town Storage", 1, null, "Available" },
                    { 280, "Very Good", 28, "FRG-028-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7817), "Port Elizabeth Depot", 1, null, "Available" },
                    { 281, "Very Good", 29, "FRG-029-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7821), "Port Elizabeth Depot", 1, null, "Available" },
                    { 282, "Excellent", 29, "FRG-029-002", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7825), "Cape Town Storage", 1, null, "Available" },
                    { 283, "Good", 29, "FRG-029-003", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7829), "Durban Warehouse", 1, null, "Available" },
                    { 284, "Very Good", 29, "FRG-029-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7833), "Johannesburg Main", 1, null, "Available" },
                    { 285, "Excellent", 29, "FRG-029-005", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7837), "Port Elizabeth Depot", 1, null, "Available" },
                    { 286, "Good", 29, "FRG-029-006", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7840), "Cape Town Storage", 1, null, "Available" },
                    { 287, "Excellent", 29, "FRG-029-007", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7844), "Pretoria Facility", 1, null, "Available" },
                    { 288, "Excellent", 29, "FRG-029-008", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7848), "Durban Warehouse", 1, null, "Available" },
                    { 289, "Very Good", 29, "FRG-029-009", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7852), "Johannesburg Main", 1, null, "Available" },
                    { 290, "Good", 29, "FRG-029-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7856), "Pretoria Facility", 1, null, "Available" },
                    { 291, "Very Good", 30, "FRG-030-001", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7860), "Port Elizabeth Depot", 1, null, "Available" },
                    { 292, "Very Good", 30, "FRG-030-002", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7863), "Cape Town Storage", 1, null, "Available" },
                    { 293, "Good", 30, "FRG-030-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7867), "Johannesburg Main", 1, null, "Available" },
                    { 294, "Excellent", 30, "FRG-030-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7871), "Pretoria Facility", 1, null, "Available" },
                    { 295, "Good", 30, "FRG-030-005", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7875), "Johannesburg Main", 1, null, "Available" },
                    { 296, "Good", 30, "FRG-030-006", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7879), "Pretoria Facility", 1, null, "Available" },
                    { 297, "Very Good", 30, "FRG-030-007", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7882), "Cape Town Storage", 1, null, "Available" },
                    { 298, "Excellent", 30, "FRG-030-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7887), "Durban Warehouse", 1, null, "Available" },
                    { 299, "Excellent", 30, "FRG-030-009", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7890), "Durban Warehouse", 1, null, "Available" },
                    { 300, "Good", 30, "FRG-030-010", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7894), "Cape Town Storage", 1, null, "Available" },
                    { 301, "Excellent", 31, "FRG-031-001", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7898), "Pretoria Facility", 1, null, "Available" },
                    { 302, "Excellent", 31, "FRG-031-002", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7902), "Johannesburg Main", 1, null, "Available" },
                    { 303, "Excellent", 31, "FRG-031-003", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7905), "Pretoria Facility", 1, null, "Available" },
                    { 304, "Very Good", 31, "FRG-031-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7909), "Pretoria Facility", 1, null, "Available" },
                    { 305, "Excellent", 31, "FRG-031-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7913), "Durban Warehouse", 1, null, "Available" },
                    { 306, "Good", 31, "FRG-031-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7917), "Johannesburg Main", 1, null, "Available" },
                    { 307, "Good", 31, "FRG-031-007", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7920), "Cape Town Storage", 1, null, "Available" },
                    { 308, "Excellent", 31, "FRG-031-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7924), "Port Elizabeth Depot", 1, null, "Available" },
                    { 309, "Good", 31, "FRG-031-009", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7928), "Port Elizabeth Depot", 1, null, "Available" },
                    { 310, "Good", 31, "FRG-031-010", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7932), "Durban Warehouse", 1, null, "Available" },
                    { 311, "Very Good", 32, "FRG-032-001", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7936), "Durban Warehouse", 1, null, "Available" },
                    { 312, "Good", 32, "FRG-032-002", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7940), "Johannesburg Main", 1, null, "Available" },
                    { 313, "Excellent", 32, "FRG-032-003", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7943), "Port Elizabeth Depot", 1, null, "Available" },
                    { 314, "Good", 32, "FRG-032-004", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7947), "Cape Town Storage", 1, null, "Available" },
                    { 315, "Good", 32, "FRG-032-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7958), "Durban Warehouse", 1, null, "Available" },
                    { 316, "Excellent", 32, "FRG-032-006", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7962), "Pretoria Facility", 1, null, "Available" },
                    { 317, "Very Good", 32, "FRG-032-007", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7966), "Durban Warehouse", 1, null, "Available" },
                    { 318, "Good", 32, "FRG-032-008", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7969), "Durban Warehouse", 1, null, "Available" },
                    { 319, "Good", 32, "FRG-032-009", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7973), "Johannesburg Main", 1, null, "Available" },
                    { 320, "Good", 32, "FRG-032-010", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7977), "Durban Warehouse", 1, null, "Available" },
                    { 321, "Excellent", 33, "FRG-033-001", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7981), "Pretoria Facility", 1, null, "Available" },
                    { 322, "Excellent", 33, "FRG-033-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7985), "Cape Town Storage", 1, null, "Available" },
                    { 323, "Good", 33, "FRG-033-003", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7988), "Cape Town Storage", 1, null, "Available" },
                    { 324, "Very Good", 33, "FRG-033-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7992), "Cape Town Storage", 1, null, "Available" },
                    { 325, "Good", 33, "FRG-033-005", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(7996), "Cape Town Storage", 1, null, "Available" },
                    { 326, "Good", 33, "FRG-033-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8000), "Durban Warehouse", 1, null, "Available" },
                    { 327, "Excellent", 33, "FRG-033-007", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8003), "Johannesburg Main", 1, null, "Available" },
                    { 328, "Good", 33, "FRG-033-008", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8007), "Durban Warehouse", 1, null, "Available" },
                    { 329, "Good", 33, "FRG-033-009", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8011), "Johannesburg Main", 1, null, "Available" },
                    { 330, "Good", 33, "FRG-033-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8015), "Johannesburg Main", 1, null, "Available" },
                    { 331, "Excellent", 34, "FRG-034-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8019), "Pretoria Facility", 1, null, "Available" },
                    { 332, "Good", 34, "FRG-034-002", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8022), "Port Elizabeth Depot", 1, null, "Available" },
                    { 333, "Very Good", 34, "FRG-034-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8026), "Durban Warehouse", 1, null, "Available" },
                    { 334, "Excellent", 34, "FRG-034-004", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8030), "Cape Town Storage", 1, null, "Available" },
                    { 335, "Very Good", 34, "FRG-034-005", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8034), "Port Elizabeth Depot", 1, null, "Available" },
                    { 336, "Excellent", 34, "FRG-034-006", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8037), "Port Elizabeth Depot", 1, null, "Available" },
                    { 337, "Excellent", 34, "FRG-034-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8041), "Durban Warehouse", 1, null, "Available" },
                    { 338, "Excellent", 34, "FRG-034-008", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8045), "Cape Town Storage", 1, null, "Available" },
                    { 339, "Excellent", 34, "FRG-034-009", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8049), "Johannesburg Main", 1, null, "Available" },
                    { 340, "Very Good", 34, "FRG-034-010", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8053), "Durban Warehouse", 1, null, "Available" },
                    { 341, "Excellent", 35, "FRG-035-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8057), "Johannesburg Main", 1, null, "Available" },
                    { 342, "Good", 35, "FRG-035-002", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8060), "Pretoria Facility", 1, null, "Available" },
                    { 343, "Good", 35, "FRG-035-003", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8064), "Pretoria Facility", 1, null, "Available" },
                    { 344, "Good", 35, "FRG-035-004", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8068), "Durban Warehouse", 1, null, "Available" },
                    { 345, "Excellent", 35, "FRG-035-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8072), "Durban Warehouse", 1, null, "Available" },
                    { 346, "Good", 35, "FRG-035-006", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8075), "Pretoria Facility", 1, null, "Available" },
                    { 347, "Good", 35, "FRG-035-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8079), "Cape Town Storage", 1, null, "Available" },
                    { 348, "Good", 35, "FRG-035-008", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8083), "Port Elizabeth Depot", 1, null, "Available" },
                    { 349, "Excellent", 35, "FRG-035-009", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8087), "Port Elizabeth Depot", 1, null, "Available" },
                    { 350, "Excellent", 35, "FRG-035-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8091), "Cape Town Storage", 1, null, "Available" },
                    { 351, "Excellent", 36, "FRG-036-001", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8094), "Cape Town Storage", 1, null, "Available" },
                    { 352, "Excellent", 36, "FRG-036-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8098), "Pretoria Facility", 1, null, "Available" },
                    { 353, "Excellent", 36, "FRG-036-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8102), "Cape Town Storage", 1, null, "Available" },
                    { 354, "Excellent", 36, "FRG-036-004", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8105), "Durban Warehouse", 1, null, "Available" },
                    { 355, "Good", 36, "FRG-036-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8109), "Johannesburg Main", 1, null, "Available" },
                    { 356, "Excellent", 36, "FRG-036-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8113), "Johannesburg Main", 1, null, "Available" },
                    { 357, "Excellent", 36, "FRG-036-007", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8117), "Port Elizabeth Depot", 1, null, "Available" },
                    { 358, "Good", 36, "FRG-036-008", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8121), "Durban Warehouse", 1, null, "Available" },
                    { 359, "Good", 36, "FRG-036-009", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8124), "Port Elizabeth Depot", 1, null, "Available" },
                    { 360, "Good", 36, "FRG-036-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8128), "Cape Town Storage", 1, null, "Available" },
                    { 361, "Very Good", 37, "FRG-037-001", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8132), "Durban Warehouse", 1, null, "Available" },
                    { 362, "Very Good", 37, "FRG-037-002", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8136), "Pretoria Facility", 1, null, "Available" },
                    { 363, "Excellent", 37, "FRG-037-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8139), "Pretoria Facility", 1, null, "Available" },
                    { 364, "Excellent", 37, "FRG-037-004", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8143), "Johannesburg Main", 1, null, "Available" },
                    { 365, "Good", 37, "FRG-037-005", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8147), "Pretoria Facility", 1, null, "Available" },
                    { 366, "Good", 37, "FRG-037-006", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8151), "Durban Warehouse", 1, null, "Available" },
                    { 367, "Good", 37, "FRG-037-007", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8154), "Cape Town Storage", 1, null, "Available" },
                    { 368, "Excellent", 37, "FRG-037-008", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8158), "Pretoria Facility", 1, null, "Available" },
                    { 369, "Excellent", 37, "FRG-037-009", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8162), "Johannesburg Main", 1, null, "Available" },
                    { 370, "Good", 37, "FRG-037-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8166), "Johannesburg Main", 1, null, "Available" },
                    { 371, "Good", 38, "FRG-038-001", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8169), "Durban Warehouse", 1, null, "Available" },
                    { 372, "Good", 38, "FRG-038-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8173), "Johannesburg Main", 1, null, "Available" },
                    { 373, "Excellent", 38, "FRG-038-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8177), "Pretoria Facility", 1, null, "Available" },
                    { 374, "Very Good", 38, "FRG-038-004", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8181), "Port Elizabeth Depot", 1, null, "Available" },
                    { 375, "Excellent", 38, "FRG-038-005", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8184), "Pretoria Facility", 1, null, "Available" },
                    { 376, "Excellent", 38, "FRG-038-006", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8188), "Durban Warehouse", 1, null, "Available" },
                    { 377, "Good", 38, "FRG-038-007", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8192), "Johannesburg Main", 1, null, "Available" },
                    { 378, "Good", 38, "FRG-038-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8196), "Port Elizabeth Depot", 1, null, "Available" },
                    { 379, "Good", 38, "FRG-038-009", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8206), "Johannesburg Main", 1, null, "Available" },
                    { 380, "Good", 38, "FRG-038-010", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8210), "Cape Town Storage", 1, null, "Available" },
                    { 381, "Good", 39, "FRG-039-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8214), "Port Elizabeth Depot", 1, null, "Available" },
                    { 382, "Good", 39, "FRG-039-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8217), "Port Elizabeth Depot", 1, null, "Available" },
                    { 383, "Excellent", 39, "FRG-039-003", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8221), "Cape Town Storage", 1, null, "Available" },
                    { 384, "Very Good", 39, "FRG-039-004", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8225), "Johannesburg Main", 1, null, "Available" },
                    { 385, "Good", 39, "FRG-039-005", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8228), "Cape Town Storage", 1, null, "Available" },
                    { 386, "Good", 39, "FRG-039-006", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8232), "Port Elizabeth Depot", 1, null, "Available" },
                    { 387, "Good", 39, "FRG-039-007", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8236), "Pretoria Facility", 1, null, "Available" },
                    { 388, "Very Good", 39, "FRG-039-008", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8240), "Pretoria Facility", 1, null, "Available" },
                    { 389, "Excellent", 39, "FRG-039-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8244), "Durban Warehouse", 1, null, "Available" },
                    { 390, "Good", 39, "FRG-039-010", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8248), "Johannesburg Main", 1, null, "Available" },
                    { 391, "Excellent", 40, "FRG-040-001", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8251), "Johannesburg Main", 1, null, "Available" },
                    { 392, "Good", 40, "FRG-040-002", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8255), "Johannesburg Main", 1, null, "Available" },
                    { 393, "Good", 40, "FRG-040-003", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8259), "Pretoria Facility", 1, null, "Available" },
                    { 394, "Good", 40, "FRG-040-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8263), "Cape Town Storage", 1, null, "Available" },
                    { 395, "Good", 40, "FRG-040-005", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8266), "Pretoria Facility", 1, null, "Available" },
                    { 396, "Good", 40, "FRG-040-006", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8270), "Pretoria Facility", 1, null, "Available" },
                    { 397, "Excellent", 40, "FRG-040-007", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8274), "Johannesburg Main", 1, null, "Available" },
                    { 398, "Excellent", 40, "FRG-040-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8278), "Johannesburg Main", 1, null, "Available" },
                    { 399, "Very Good", 40, "FRG-040-009", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8281), "Port Elizabeth Depot", 1, null, "Available" },
                    { 400, "Excellent", 40, "FRG-040-010", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8285), "Port Elizabeth Depot", 1, null, "Available" },
                    { 401, "Good", 41, "FRG-041-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8289), "Port Elizabeth Depot", 1, null, "Available" },
                    { 402, "Excellent", 41, "FRG-041-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8293), "Cape Town Storage", 1, null, "Available" },
                    { 403, "Excellent", 41, "FRG-041-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8297), "Durban Warehouse", 1, null, "Available" },
                    { 404, "Excellent", 41, "FRG-041-004", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8301), "Cape Town Storage", 1, null, "Available" },
                    { 405, "Excellent", 41, "FRG-041-005", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8305), "Johannesburg Main", 1, null, "Available" },
                    { 406, "Very Good", 41, "FRG-041-006", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8308), "Johannesburg Main", 1, null, "Available" },
                    { 407, "Very Good", 41, "FRG-041-007", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8312), "Cape Town Storage", 1, null, "Available" },
                    { 408, "Good", 41, "FRG-041-008", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8316), "Cape Town Storage", 1, null, "Available" },
                    { 409, "Good", 41, "FRG-041-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8320), "Cape Town Storage", 1, null, "Available" },
                    { 410, "Good", 41, "FRG-041-010", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8323), "Cape Town Storage", 1, null, "Available" },
                    { 411, "Excellent", 42, "FRG-042-001", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8327), "Port Elizabeth Depot", 1, null, "Available" },
                    { 412, "Excellent", 42, "FRG-042-002", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8331), "Johannesburg Main", 1, null, "Available" },
                    { 413, "Good", 42, "FRG-042-003", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8335), "Pretoria Facility", 1, null, "Available" },
                    { 414, "Excellent", 42, "FRG-042-004", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8338), "Pretoria Facility", 1, null, "Available" },
                    { 415, "Excellent", 42, "FRG-042-005", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8342), "Port Elizabeth Depot", 1, null, "Available" },
                    { 416, "Good", 42, "FRG-042-006", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8346), "Johannesburg Main", 1, null, "Available" },
                    { 417, "Excellent", 42, "FRG-042-007", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8350), "Johannesburg Main", 1, null, "Available" },
                    { 418, "Good", 42, "FRG-042-008", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8353), "Port Elizabeth Depot", 1, null, "Available" },
                    { 419, "Very Good", 42, "FRG-042-009", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8357), "Cape Town Storage", 1, null, "Available" },
                    { 420, "Excellent", 42, "FRG-042-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8361), "Johannesburg Main", 1, null, "Available" },
                    { 421, "Excellent", 43, "FRG-043-001", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8365), "Johannesburg Main", 1, null, "Available" },
                    { 422, "Excellent", 43, "FRG-043-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8369), "Pretoria Facility", 1, null, "Available" },
                    { 423, "Good", 43, "FRG-043-003", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8372), "Durban Warehouse", 1, null, "Available" },
                    { 424, "Good", 43, "FRG-043-004", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8376), "Port Elizabeth Depot", 1, null, "Available" },
                    { 425, "Excellent", 43, "FRG-043-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8380), "Port Elizabeth Depot", 1, null, "Available" },
                    { 426, "Very Good", 43, "FRG-043-006", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8383), "Port Elizabeth Depot", 1, null, "Available" },
                    { 427, "Very Good", 43, "FRG-043-007", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8387), "Pretoria Facility", 1, null, "Available" },
                    { 428, "Good", 43, "FRG-043-008", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8391), "Port Elizabeth Depot", 1, null, "Available" },
                    { 429, "Excellent", 43, "FRG-043-009", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8395), "Cape Town Storage", 1, null, "Available" },
                    { 430, "Very Good", 43, "FRG-043-010", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8399), "Pretoria Facility", 1, null, "Available" },
                    { 431, "Good", 44, "FRG-044-001", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8403), "Pretoria Facility", 1, null, "Available" },
                    { 432, "Excellent", 44, "FRG-044-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8406), "Cape Town Storage", 1, null, "Available" },
                    { 433, "Good", 44, "FRG-044-003", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8410), "Durban Warehouse", 1, null, "Available" },
                    { 434, "Good", 44, "FRG-044-004", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8414), "Johannesburg Main", 1, null, "Available" },
                    { 435, "Very Good", 44, "FRG-044-005", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8418), "Johannesburg Main", 1, null, "Available" },
                    { 436, "Excellent", 44, "FRG-044-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8422), "Johannesburg Main", 1, null, "Available" },
                    { 437, "Good", 44, "FRG-044-007", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8425), "Pretoria Facility", 1, null, "Available" },
                    { 438, "Good", 44, "FRG-044-008", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8429), "Johannesburg Main", 1, null, "Available" },
                    { 439, "Excellent", 44, "FRG-044-009", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8433), "Pretoria Facility", 1, null, "Available" },
                    { 440, "Very Good", 44, "FRG-044-010", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8437), "Durban Warehouse", 1, null, "Available" },
                    { 441, "Good", 45, "FRG-045-001", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8441), "Port Elizabeth Depot", 1, null, "Available" },
                    { 442, "Very Good", 45, "FRG-045-002", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8444), "Johannesburg Main", 1, null, "Available" },
                    { 443, "Excellent", 45, "FRG-045-003", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8454), "Pretoria Facility", 1, null, "Available" },
                    { 444, "Good", 45, "FRG-045-004", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8458), "Johannesburg Main", 1, null, "Available" },
                    { 445, "Good", 45, "FRG-045-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8461), "Johannesburg Main", 1, null, "Available" },
                    { 446, "Excellent", 45, "FRG-045-006", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8465), "Durban Warehouse", 1, null, "Available" },
                    { 447, "Excellent", 45, "FRG-045-007", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8469), "Johannesburg Main", 1, null, "Available" },
                    { 448, "Good", 45, "FRG-045-008", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8473), "Cape Town Storage", 1, null, "Available" },
                    { 449, "Excellent", 45, "FRG-045-009", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8477), "Johannesburg Main", 1, null, "Available" },
                    { 450, "Excellent", 45, "FRG-045-010", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8480), "Durban Warehouse", 1, null, "Available" },
                    { 451, "Good", 46, "FRG-046-001", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8484), "Cape Town Storage", 1, null, "Available" },
                    { 452, "Good", 46, "FRG-046-002", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8488), "Port Elizabeth Depot", 1, null, "Available" },
                    { 453, "Excellent", 46, "FRG-046-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8492), "Johannesburg Main", 1, null, "Available" },
                    { 454, "Excellent", 46, "FRG-046-004", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8495), "Port Elizabeth Depot", 1, null, "Available" },
                    { 455, "Good", 46, "FRG-046-005", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8499), "Durban Warehouse", 1, null, "Available" },
                    { 456, "Good", 46, "FRG-046-006", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8503), "Pretoria Facility", 1, null, "Available" },
                    { 457, "Good", 46, "FRG-046-007", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8507), "Johannesburg Main", 1, null, "Available" },
                    { 458, "Excellent", 46, "FRG-046-008", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8511), "Port Elizabeth Depot", 1, null, "Available" },
                    { 459, "Excellent", 46, "FRG-046-009", true, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8514), "Pretoria Facility", 1, null, "Available" },
                    { 460, "Excellent", 46, "FRG-046-010", true, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8518), "Cape Town Storage", 1, null, "Available" },
                    { 461, "Very Good", 47, "FRG-047-001", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8522), "Johannesburg Main", 1, null, "Available" },
                    { 462, "Very Good", 47, "FRG-047-002", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8526), "Pretoria Facility", 1, null, "Available" },
                    { 463, "Good", 47, "FRG-047-003", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8530), "Port Elizabeth Depot", 1, null, "Available" },
                    { 464, "Good", 47, "FRG-047-004", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8533), "Cape Town Storage", 1, null, "Available" },
                    { 465, "Good", 47, "FRG-047-005", false, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8537), "Pretoria Facility", 1, null, "Available" },
                    { 466, "Very Good", 47, "FRG-047-006", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8541), "Cape Town Storage", 1, null, "Available" },
                    { 467, "Good", 47, "FRG-047-007", false, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8545), "Johannesburg Main", 1, null, "Available" },
                    { 468, "Excellent", 47, "FRG-047-008", true, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8548), "Durban Warehouse", 1, null, "Available" },
                    { 469, "Very Good", 47, "FRG-047-009", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8552), "Johannesburg Main", 1, null, "Available" },
                    { 470, "Excellent", 47, "FRG-047-010", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8556), "Pretoria Facility", 1, null, "Available" },
                    { 471, "Excellent", 48, "FRG-048-001", false, new DateTime(2025, 8, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8560), "Pretoria Facility", 1, null, "Available" },
                    { 472, "Excellent", 48, "FRG-048-002", false, new DateTime(2025, 7, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8563), "Johannesburg Main", 1, null, "Available" },
                    { 473, "Excellent", 48, "FRG-048-003", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8567), "Durban Warehouse", 1, null, "Available" },
                    { 474, "Very Good", 48, "FRG-048-004", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8571), "Johannesburg Main", 1, null, "Available" },
                    { 475, "Very Good", 48, "FRG-048-005", true, new DateTime(2025, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8574), "Durban Warehouse", 1, null, "Available" },
                    { 476, "Excellent", 48, "FRG-048-006", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8578), "Durban Warehouse", 1, null, "Available" },
                    { 477, "Excellent", 48, "FRG-048-007", true, new DateTime(2025, 10, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8582), "Pretoria Facility", 1, null, "Available" },
                    { 478, "Good", 48, "FRG-048-008", true, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8586), "Cape Town Storage", 1, null, "Available" },
                    { 479, "Good", 48, "FRG-048-009", false, new DateTime(2025, 9, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8590), "Cape Town Storage", 1, null, "Available" },
                    { 480, "Good", 48, "FRG-048-010", false, new DateTime(2025, 6, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(8593), "Johannesburg Main", 1, null, "Available" }
                });

            migrationBuilder.InsertData(
                table: "tblAllocations",
                columns: new[] { "AllocationId", "Count", "CustomerID", "FridgeId" },
                values: new object[,]
                {
                    { 1, 3, 3, 36 },
                    { 2, 3, 5, 45 },
                    { 3, 1, 7, 7 },
                    { 4, 3, 8, 32 },
                    { 5, 3, 7, 22 },
                    { 6, 1, 12, 28 },
                    { 7, 2, 11, 9 },
                    { 8, 3, 5, 7 },
                    { 9, 1, 7, 8 },
                    { 10, 3, 5, 48 },
                    { 11, 1, 5, 4 },
                    { 12, 1, 8, 47 },
                    { 13, 2, 8, 32 },
                    { 14, 2, 4, 23 },
                    { 15, 2, 4, 37 }
                });

            migrationBuilder.InsertData(
                table: "tblFaultReports",
                columns: new[] { "FaultReportId", "CustomerId", "DeclineReason", "Description", "FaultType", "FridgeInStockId", "ImageUrl", "IsRelaunched", "IsReplacementRequested", "OriginalFaultReportId", "Priority", "ReportedDate", "RequestReplacement", "Status" },
                values: new object[,]
                {
                    { 1, 6, null, "Fault description for report 1. Issue requires attention.", "Not Cooling", 101, "/Images/Faults/fault-1.jpg", false, false, null, "Critical", new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3301), true, "Resolved" },
                    { 2, 7, null, "Fault description for report 2. Issue requires attention.", "Strange Noises", 68, "/Images/Faults/fault-2.jpg", false, false, null, "Medium", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3319), true, "In Progress" },
                    { 3, 8, null, "Fault description for report 3. Issue requires attention.", "Water Leakage", 127, "/Images/Faults/fault-3.jpg", false, false, null, "Low", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3323), true, "Resolved" },
                    { 4, 9, null, "Fault description for report 4. Issue requires attention.", "Strange Noises", 127, "/Images/Faults/fault-4.jpg", false, true, null, "Medium", new DateTime(2025, 10, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3327), true, "In Progress" },
                    { 5, 6, null, "Fault description for report 5. Issue requires attention.", "Not Cooling", 13, "/Images/Faults/fault-5.jpg", false, false, null, "High", new DateTime(2025, 10, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3331), false, "In Progress" },
                    { 6, 4, null, "Fault description for report 6. Issue requires attention.", "Strange Noises", 113, "/Images/Faults/fault-6.jpg", false, false, null, "Low", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3336), false, "In Progress" },
                    { 7, 6, null, "Fault description for report 7. Issue requires attention.", "Water Leakage", 76, "/Images/Faults/fault-7.jpg", false, false, null, "Critical", new DateTime(2025, 10, 13, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3340), false, "Reported" },
                    { 8, 8, null, "Fault description for report 8. Issue requires attention.", "Not Cooling", 5, "/Images/Faults/fault-8.jpg", false, true, null, "High", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3344), false, "Reported" },
                    { 9, 9, null, "Fault description for report 9. Issue requires attention.", "Door Problems", 23, "/Images/Faults/fault-9.jpg", false, false, null, "High", new DateTime(2025, 10, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3348), false, "In Progress" },
                    { 10, 6, null, "Fault description for report 10. Issue requires attention.", "Not Cooling", 146, "/Images/Faults/fault-10.jpg", false, false, null, "Critical", new DateTime(2025, 10, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3352), false, "In Progress" },
                    { 11, 7, null, "Fault description for report 11. Issue requires attention.", "Door Problems", 89, "/Images/Faults/fault-11.jpg", false, false, null, "Medium", new DateTime(2025, 10, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3357), true, "Reported" },
                    { 12, 2, null, "Fault description for report 12. Issue requires attention.", "Electrical Issues", 59, "/Images/Faults/fault-12.jpg", false, true, null, "Medium", new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), true, "In Progress" },
                    { 13, 3, null, "Fault description for report 13. Issue requires attention.", "Electrical Issues", 59, "/Images/Faults/fault-13.jpg", false, false, null, "High", new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), false, "Resolved" },
                    { 14, 11, null, "Fault description for report 14. Issue requires attention.", "Water Leakage", 58, "/Images/Faults/fault-14.jpg", false, false, null, "High", new DateTime(2025, 10, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3369), true, "In Progress" },
                    { 15, 11, null, "Fault description for report 15. Issue requires attention.", "Electrical Issues", 107, "/Images/Faults/fault-15.jpg", false, true, null, "High", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3373), true, "Declined" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestHeaders",
                columns: new[] { "RequestHeaderId", "AdditionalDescription", "AdditionalDocumentPath", "Carrier", "CellNumber", "City", "CustomerID", "DeliveryDate", "EmployeeID", "FirstName", "IsRelaunched", "IsReplacement", "LastName", "OriginalRequestId", "PaymentDueDate", "PostalCode", "RejectionDate", "RejectionReason", "RequestDate", "RequestTotal", "State", "Status", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, "0124445678", "Port Elizabeth", 2, null, 2, "Lisa", false, false, "Brown", null, null, "1434", null, null, new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(1543), 459.0, "Province", "Pending", "857 Trade Street" },
                    { 2, null, null, null, "0413337890", "Johannesburg", 3, null, 9, "David", false, false, "Jackson", null, null, "4644", new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558), "Required additional verification documents", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558), 1082.0, "Province", "Rejected", "642 Commerce Road" },
                    { 3, null, null, null, "0512224567", "Johannesburg", 4, new DateTime(2025, 11, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), 7, "Emma", false, false, "Davis", null, new DateTime(2025, 12, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), "7183", null, null, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), 1111.0, "Province", "Shipped", "358 Commerce Road" },
                    { 4, null, null, null, "0131112345", "Bloemfontein", 5, null, 12, "Robert", false, false, "Miller", null, null, "7884", null, null, new DateTime(2025, 8, 19, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2578), 902.0, "Province", "Approved", "720 Trade Street" },
                    { 5, null, null, null, "0156667890", "Durban", 6, null, 5, "Sophia", false, false, "Garcia", null, null, "4939", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584), "Credit check failed", new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584), 1012.0, "Province", "Rejected", "653 Business Avenue" },
                    { 6, null, null, null, "0537771234", "Johannesburg", 7, null, 9, "James", false, false, "Anderson", null, null, "7787", null, null, new DateTime(2025, 9, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2600), 473.0, "Province", "Approved", "368 Service Road" },
                    { 7, null, null, null, "0148884567", "Bloemfontein", 8, null, 5, "Olivia", false, false, "Martinez", null, null, "1992", null, null, new DateTime(2025, 9, 24, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2605), 676.0, "Province", "Approved", "88 Trade Street" },
                    { 8, null, null, null, "0439991234", "Cape Town", 9, null, 1, "William", false, false, "Thomas", null, null, "1554", new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2610), "Required additional verification documents", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2610), 973.0, "Province", "Rejected", "239 Business Avenue" },
                    { 9, null, null, null, "0338885678", "Pretoria", 10, null, 11, "Ava", false, false, "Robinson", null, null, "4770", null, null, new DateTime(2025, 8, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2615), 632.0, "Province", "Pending", "160 Main Street" },
                    { 10, null, null, null, "0577779012", "Bloemfontein", 11, null, 11, "Noah", false, false, "Clark", null, null, "6353", new DateTime(2025, 10, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2621), "Business type not supported", new DateTime(2025, 9, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2621), 546.0, "Province", "Rejected", "806 Service Road" },
                    { 11, null, null, null, "0136663456", "Port Elizabeth", 12, null, 5, "Isabella", false, false, "Rodriguez", null, null, "7733", null, null, new DateTime(2025, 9, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2626), 1482.0, "Province", "Approved", "279 Service Road" },
                    { 12, null, null, null, "0315551234", "Bloemfontein", 1, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2631), 8, "Mike", false, false, "Wilson", null, new DateTime(2025, 12, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2631), "7530", null, null, new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2631), 1383.0, "Province", "Closed", "434 Service Road" },
                    { 13, null, null, null, "0124445678", "Pretoria", 2, null, 7, "Lisa", false, false, "Brown", null, null, "2495", null, null, new DateTime(2025, 9, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2636), 1366.0, "Province", "Pending", "391 Business Avenue" },
                    { 14, null, null, null, "0413337890", "Cape Town", 3, new DateTime(2025, 11, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2641), 7, "David", false, false, "Jackson", null, new DateTime(2025, 11, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2641), "4451", null, null, new DateTime(2025, 10, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2641), 609.0, "Province", "Closed", "974 Commerce Road" },
                    { 15, null, null, null, "0512224567", "Port Elizabeth", 4, null, 11, "Emma", false, false, "Davis", null, null, "2199", new DateTime(2025, 9, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2655), "Business registration not valid", new DateTime(2025, 9, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2655), 1453.0, "Province", "Rejected", "960 Commerce Road" }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeVisits",
                columns: new[] { "VisitId", "CheckupStatus", "CreatedDate", "CustomerApproval", "Notes", "RequestHeaderId", "Status", "TechnicianName", "VisitDate", "VisitType" },
                values: new object[,]
                {
                    { 1, "Not Started", new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132), "Approved", "Visit notes for service 1. Checkup completed with status: Not Started", 2, "Pending", "Jennifer Martin", new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132), "Maintenance Check" },
                    { 2, "Failed", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161), "Approved", "Visit notes for service 2. Checkup completed with status: Failed", 13, "Pending", "Jennifer Martin", new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161), "Maintenance Check" },
                    { 3, "Failed", new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164), "Approved", "Visit notes for service 3. Checkup completed with status: Failed", 14, "Pending", "James Miller", new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164), "Maintenance Check" },
                    { 4, "In Progress", new DateTime(2025, 11, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3168), "Approved", "Visit notes for service 4. Checkup completed with status: In Progress", 2, "Pending", "James Miller", new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3168), "Maintenance Check" },
                    { 5, "Failed", new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3171), "Pending", "Visit notes for service 5. Checkup completed with status: Failed", 13, "Pending", "Patricia White", new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3171), "Maintenance Check" },
                    { 6, "Passed", new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3175), "Approved", "Visit notes for service 6. Checkup completed with status: Passed", 1, "Pending", "Patricia White", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3175), "Maintenance Check" },
                    { 7, "Passed", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3178), "Pending", "Visit notes for service 7. Checkup completed with status: Passed", 4, "Pending", "Jennifer Martin", new DateTime(2025, 11, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3178), "Maintenance Check" },
                    { 8, "Not Started", new DateTime(2025, 10, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3181), "Pending", "Visit notes for service 8. Checkup completed with status: Not Started", 1, "Pending", "Patricia White", new DateTime(2025, 10, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3181), "Maintenance Check" },
                    { 9, "In Progress", new DateTime(2025, 10, 24, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3184), "Approved", "Visit notes for service 9. Checkup completed with status: In Progress", 10, "Pending", "Patricia White", new DateTime(2025, 10, 25, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3184), "Maintenance Check" },
                    { 10, "Failed", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3188), "Approved", "Visit notes for service 10. Checkup completed with status: Failed", 11, "Pending", "James Miller", new DateTime(2025, 10, 18, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3188), "Maintenance Check" },
                    { 11, "Not Started", new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3191), "Pending", "Visit notes for service 11. Checkup completed with status: Not Started", 3, "Pending", "James Miller", new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3191), "Maintenance Check" },
                    { 12, "In Progress", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3195), "Approved", "Visit notes for service 12. Checkup completed with status: In Progress", 7, "Pending", "Jennifer Martin", new DateTime(2025, 11, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3195), "Maintenance Check" },
                    { 13, "Passed", new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3198), "Pending", "Visit notes for service 13. Checkup completed with status: Passed", 2, "Pending", "Jennifer Martin", new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3198), "Maintenance Check" },
                    { 14, "In Progress", new DateTime(2025, 10, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3201), "Approved", "Visit notes for service 14. Checkup completed with status: In Progress", 6, "Pending", "James Miller", new DateTime(2025, 10, 29, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3201), "Maintenance Check" },
                    { 15, "In Progress", new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3205), "Approved", "Visit notes for service 15. Checkup completed with status: In Progress", 4, "Pending", "Jennifer Martin", new DateTime(2025, 10, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3205), "Maintenance Check" },
                    { 16, "Not Started", new DateTime(2025, 11, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3210), "Approved", "Visit notes for service 16. Checkup completed with status: Not Started", 4, "Pending", "James Miller", new DateTime(2025, 11, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3210), "Maintenance Check" },
                    { 17, "Not Started", new DateTime(2025, 10, 24, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3213), "Pending", "Visit notes for service 17. Checkup completed with status: Not Started", 12, "Pending", "Jennifer Martin", new DateTime(2025, 10, 25, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3213), "Maintenance Check" },
                    { 18, "In Progress", new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3217), "Pending", "Visit notes for service 18. Checkup completed with status: In Progress", 9, "Pending", "Robert Davis", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3217), "Maintenance Check" },
                    { 19, "In Progress", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3220), "Pending", "Visit notes for service 19. Checkup completed with status: In Progress", 15, "Pending", "James Miller", new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3220), "Maintenance Check" },
                    { 20, "Not Started", new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3223), "Pending", "Visit notes for service 20. Checkup completed with status: Not Started", 6, "Pending", "Robert Davis", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3223), "Maintenance Check" }
                });

            migrationBuilder.InsertData(
                table: "tblRequestDetais",
                columns: new[] { "RequestDetailId", "Count", "FridgeId", "Price", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, 1, 29, 402.0, 2 },
                    { 2, 1, 5, 727.0, 3 },
                    { 3, 1, 25, 606.0, 4 },
                    { 4, 3, 37, 593.0, 5 },
                    { 5, 1, 34, 771.0, 6 },
                    { 6, 3, 9, 704.0, 7 },
                    { 7, 3, 23, 678.0, 8 },
                    { 8, 1, 10, 588.0, 9 },
                    { 9, 1, 23, 642.0, 10 },
                    { 10, 1, 14, 601.0, 11 },
                    { 11, 2, 7, 590.0, 12 },
                    { 12, 2, 27, 508.0, 13 },
                    { 13, 3, 23, 471.0, 14 },
                    { 14, 1, 6, 772.0, 15 },
                    { 15, 1, 38, 724.0, 1 },
                    { 16, 3, 5, 571.0, 2 },
                    { 17, 1, 33, 547.0, 3 },
                    { 18, 1, 39, 528.0, 4 },
                    { 19, 2, 32, 413.0, 5 },
                    { 20, 3, 14, 748.0, 6 }
                });

            migrationBuilder.InsertData(
                table: "tblRequestNotes",
                columns: new[] { "RequestNoteId", "CreatedDate", "NoteContent", "NoteType", "RequestHeaderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3817), "Note content for request 1. This is an important note regarding the service.", "Customer", 5 },
                    { 2, new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3832), "Note content for request 2. This is an important note regarding the service.", "Technical", 4 },
                    { 3, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3836), "Note content for request 3. This is an important note regarding the service.", "Administrative", 5 },
                    { 4, new DateTime(2025, 8, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3838), "Note content for request 4. This is an important note regarding the service.", "Internal", 8 },
                    { 5, new DateTime(2025, 10, 19, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3841), "Note content for request 5. This is an important note regarding the service.", "Customer", 8 },
                    { 6, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3844), "Note content for request 6. This is an important note regarding the service.", "Technical", 11 },
                    { 7, new DateTime(2025, 9, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3847), "Note content for request 7. This is an important note regarding the service.", "Technical", 1 },
                    { 8, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3849), "Note content for request 8. This is an important note regarding the service.", "Internal", 13 },
                    { 9, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3852), "Note content for request 9. This is an important note regarding the service.", "Internal", 1 },
                    { 10, new DateTime(2025, 9, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3855), "Note content for request 10. This is an important note regarding the service.", "Customer", 6 },
                    { 11, new DateTime(2025, 10, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3858), "Note content for request 11. This is an important note regarding the service.", "Customer", 2 },
                    { 12, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3860), "Note content for request 12. This is an important note regarding the service.", "Administrative", 9 },
                    { 13, new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3863), "Note content for request 13. This is an important note regarding the service.", "Internal", 9 },
                    { 14, new DateTime(2025, 10, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3865), "Note content for request 14. This is an important note regarding the service.", "Administrative", 11 },
                    { 15, new DateTime(2025, 8, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3867), "Note content for request 15. This is an important note regarding the service.", "Customer", 8 },
                    { 16, new DateTime(2025, 8, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3870), "Note content for request 16. This is an important note regarding the service.", "Internal", 3 },
                    { 17, new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3872), "Note content for request 17. This is an important note regarding the service.", "Customer", 15 },
                    { 18, new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3875), "Note content for request 18. This is an important note regarding the service.", "Administrative", 8 },
                    { 19, new DateTime(2025, 8, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3878), "Note content for request 19. This is an important note regarding the service.", "Internal", 7 },
                    { 20, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3881), "Note content for request 20. This is an important note regarding the service.", "Administrative", 9 }
                });

            migrationBuilder.InsertData(
                table: "tblCustomerFridge",
                columns: new[] { "CustomerFridgeId", "AllocatedDate", "CustomerID", "DeclineReason", "FridgeId", "FridgeInStockId", "IsActive", "ReasonForReplacement", "ReplacementDate", "ReplacementFridgeInStockId", "ReplacementNotes", "ReplacementStatus", "RequestDetailId", "ReservedDate", "TechnicianNotes" },
                values: new object[,]
                {
                    { 1, null, 4, null, 4, 181, true, null, null, null, null, null, 1, new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2961), null },
                    { 2, null, 11, null, 28, 391, true, null, null, null, null, null, 15, new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2978), null },
                    { 3, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), 8, null, 25, 221, true, null, null, null, null, null, 20, new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), null },
                    { 4, null, 1, null, 18, 407, true, "Frequent breakdowns", new DateTime(2025, 11, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), 66, "Unit requires replacement due to age", "Pending", 1, new DateTime(2025, 9, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), "Inspected and confirmed replacement needed" },
                    { 5, new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), 6, null, 36, 420, true, "Frequent breakdowns", new DateTime(2025, 12, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), 258, "Unit requires replacement due to age", "Pending", 18, new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), "Inspected and confirmed replacement needed" },
                    { 6, null, 12, null, 47, 476, true, "Frequent breakdowns", new DateTime(2025, 11, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2998), 452, "Unit requires replacement due to age", "Pending", 3, new DateTime(2025, 9, 18, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2998), "Inspected and confirmed replacement needed" },
                    { 7, null, 7, null, 14, 356, true, null, null, null, null, null, 15, new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3000), null },
                    { 8, new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3001), 12, null, 17, 159, true, null, null, null, null, null, 13, new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3001), null },
                    { 9, new DateTime(2025, 10, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3003), 10, null, 46, 84, true, null, null, null, null, null, 3, new DateTime(2025, 9, 29, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3003), null },
                    { 10, null, 10, null, 17, 99, true, null, null, null, null, null, 12, new DateTime(2025, 10, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3005), null },
                    { 11, null, 6, null, 34, 260, true, null, null, null, null, null, 8, new DateTime(2025, 10, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3007), null },
                    { 12, null, 7, null, 3, 417, true, "Frequent breakdowns", new DateTime(2026, 1, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3009), 470, "Unit requires replacement due to age", "Pending", 18, new DateTime(2025, 11, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3009), "Inspected and confirmed replacement needed" },
                    { 13, null, 1, null, 6, 181, true, null, null, null, null, null, 1, new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3011), null },
                    { 14, null, 2, null, 28, 398, true, "Frequent breakdowns", new DateTime(2026, 1, 25, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3012), 426, "Unit requires replacement due to age", "Pending", 2, new DateTime(2025, 11, 11, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3012), "Inspected and confirmed replacement needed" },
                    { 15, null, 3, null, 25, 437, true, null, null, null, null, null, 3, new DateTime(2025, 9, 24, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3014), null },
                    { 16, null, 11, null, 13, 296, true, null, null, null, null, null, 1, new DateTime(2025, 10, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3015), null },
                    { 17, null, 2, null, 5, 302, true, null, null, null, null, null, 14, new DateTime(2025, 9, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3017), null },
                    { 18, null, 5, null, 34, 256, true, null, null, null, null, null, 6, new DateTime(2025, 9, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3019), null },
                    { 19, new DateTime(2025, 11, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3021), 5, null, 42, 304, true, null, null, null, null, null, 12, new DateTime(2025, 11, 11, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3021), null },
                    { 20, new DateTime(2025, 10, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3023), 3, null, 2, 156, true, "Frequent breakdowns", new DateTime(2025, 12, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3023), 376, "Unit requires replacement due to age", "Pending", 16, new DateTime(2025, 10, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3023), "Inspected and confirmed replacement needed" },
                    { 21, null, 11, null, 3, 42, true, null, null, null, null, null, 14, new DateTime(2025, 10, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3025), null },
                    { 22, null, 10, null, 48, 170, true, null, null, null, null, null, 2, new DateTime(2025, 10, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3026), null },
                    { 23, null, 2, null, 7, 328, true, null, null, null, null, null, 9, new DateTime(2025, 9, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3028), null },
                    { 24, new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3029), 12, null, 4, 112, true, null, null, null, null, null, 15, new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3029), null },
                    { 25, null, 1, null, 17, 430, true, null, null, null, null, null, 16, new DateTime(2025, 10, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3031), null }
                });

            migrationBuilder.InsertData(
                table: "tblFaultTechnicians",
                columns: new[] { "FaultId", "Bookingate", "Completion", "CreatedDate", "CustomerBookingStatus", "FaultDescription", "FaultReportId", "FaultType", "Priority", "RepairStatus", "ReportDate", "ResolutionNotes", "TechnicianAssigned", "VisitId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3447), "Approved", "Fault description for technician assignment 1", 2, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3447), null, "James Miller", 2 },
                    { 2, new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3472), null, new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3472), "Pending", "Fault description for technician assignment 2", 7, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3472), null, "Patricia White", 11 },
                    { 3, new DateTime(2025, 10, 29, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3480), null, new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3480), "Decline", "Fault description for technician assignment 3", 4, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3480), "Resolution notes for fault 3", "Patricia White", 14 },
                    { 4, null, null, new DateTime(2025, 10, 18, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3485), "Pending", "Fault description for technician assignment 4", 13, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 18, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3485), null, "Robert Davis", 5 },
                    { 5, null, null, new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3489), "Decline", "Fault description for technician assignment 5", 4, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3489), "Resolution notes for fault 5", "Patricia White", 17 },
                    { 6, new DateTime(2025, 10, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3494), null, new DateTime(2025, 10, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3494), "Decline", "Fault description for technician assignment 6", 1, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3494), "Resolution notes for fault 6", "Jennifer Martin", 6 },
                    { 7, new DateTime(2025, 11, 13, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3498), null, new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3498), "Decline", "Fault description for technician assignment 7", 4, "Technical Fault", "High", "Completed", new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3498), null, "Robert Davis", 18 },
                    { 8, new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3502), null, new DateTime(2025, 10, 25, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3502), "Approved", "Fault description for technician assignment 8", 15, "Technical Fault", "Medium", "Scrapped", new DateTime(2025, 10, 25, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3502), "Resolution notes for fault 8", "Jennifer Martin", 13 },
                    { 9, null, null, new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3506), "Pending", "Fault description for technician assignment 9", 2, "Technical Fault", "High", "Scrapped", new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3506), null, "Jennifer Martin", 2 },
                    { 10, null, null, new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3511), "Approved", "Fault description for technician assignment 10", 7, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3511), "Resolution notes for fault 10", "Jennifer Martin", 20 },
                    { 11, null, null, new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3516), "Decline", "Fault description for technician assignment 11", 8, "Technical Fault", "High", "In Progress", new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3516), null, "James Miller", 15 },
                    { 12, new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3519), null, new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3519), "Pending", "Fault description for technician assignment 12", 2, "Technical Fault", "High", "Completed", new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3519), null, "Robert Davis", 2 },
                    { 13, new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3523), null, new DateTime(2025, 11, 5, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3523), "Decline", "Fault description for technician assignment 13", 8, "Technical Fault", "High", "In Progress", new DateTime(2025, 11, 5, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3523), null, "Jennifer Martin", 13 },
                    { 14, new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3526), null, new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3526), "Approved", "Fault description for technician assignment 14", 10, "Technical Fault", "Medium", "Resolved", new DateTime(2025, 10, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3526), null, "Robert Davis", 14 },
                    { 15, new DateTime(2025, 10, 24, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3529), null, new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3529), "Decline", "Fault description for technician assignment 15", 1, "Technical Fault", "Medium", "In Progress", new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3529), "Resolution notes for fault 15", "James Miller", 15 }
                });

            migrationBuilder.InsertData(
                table: "tblFridgeReplacements",
                columns: new[] { "FridgeReplacementId", "ActionBy", "ActionDate", "AdditionalNotes", "ApplicationUserId", "ApprovedBy", "CustomerID", "DeclineReason", "NewFridgeInStockId", "OldFridgeNo", "ReasonForReplacement", "ReplacementDate", "ReplacementStatus", "RequestDate", "TechnicianNotes", "VisitId" },
                values: new object[,]
                {
                    { 1, "William Moore", new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3608), "Customer reported inconsistent temperature for several weeks.", "24", "Technical Support", 7, "Unit still under warranty, repair recommended instead.", null, "FRG-002-008", "Electrical Fault - Mainboard failure, replacement parts unavailable", new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3608), "Rejected", new DateTime(2025, 10, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3608), "Customer satisfied with current model, requesting same replacement.", 20 },
                    { 2, "Linda Taylor", new DateTime(2025, 11, 29, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3646), "Interior lighting not working, bulbs already replaced.", "6", "Admin User", 8, "Unit still under warranty, repair recommended instead.", null, "FRG-014-006", "Noise Complaint - Excessive noise that cannot be resolved", new DateTime(2025, 11, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3646), "Rejected", new DateTime(2025, 11, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3646), "Customer satisfied with current model, requesting same replacement.", 13 },
                    { 3, "Lisa Davis", new DateTime(2025, 10, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3652), "Customer reported inconsistent temperature for several weeks.", "6", "Operations Team", 3, "Unit is only 2 years old, repair is more cost effective.", null, "FRG-005-007", "Structural Damage - Internal corrosion affecting performance", new DateTime(2025, 10, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3652), "Rejected", new DateTime(2025, 9, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3652), "Evaporator fan motor noisy, replacement part no longer available.", 8 },
                    { 4, null, null, "Customer reported inconsistent temperature for several weeks.", "10", null, 6, null, null, "FRG-015-009", "Frequent Breakdowns - Multiple service calls in last 3 months", new DateTime(2025, 11, 13, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3657), "Pending", new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3657), "Multiple component failures detected during diagnostic testing.", 16 },
                    { 5, "Jennifer Wilson", new DateTime(2025, 9, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3662), "Customer complains about high electricity consumption.", "23", "Technical Support", 11, "Replacement stock currently unavailable for this model.", null, "FRG-008-010", "Old Age - Unit over 10 years old with deteriorating performance", new DateTime(2025, 9, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3662), "Rejected", new DateTime(2025, 9, 14, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3662), "Customer satisfied with current model, requesting same replacement.", 18 },
                    { 6, "Robert Miller", new DateTime(2025, 10, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3675), "Unit making loud grinding noise during compressor operation.", "16", "Service Department", 6, null, 19, "FRG-011-004", "Fridge Beyond Repair - Compressor failure", new DateTime(2025, 10, 4, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3675), "Approved", new DateTime(2025, 9, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3675), "Unit reached end of service life, recommended replacement.", 9 },
                    { 7, "Michael Brown", new DateTime(2025, 10, 3, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3681), "Door seal broken, causing cold air escape.", "22", "Service Department", 4, null, 108, "FRG-003-008", "Electrical Fault - Mainboard failure, replacement parts unavailable", new DateTime(2025, 10, 1, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3681), "Approved", new DateTime(2025, 9, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3681), "Diagnosed compressor failure - replacement cost exceeds unit value.", 2 },
                    { 8, "Linda Taylor", new DateTime(2025, 11, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3686), "Door seal broken, causing cold air escape.", "23", "Manager Office", 1, null, 60, "FRG-007-007", "Customer Request - Customer requested upgrade to newer model", new DateTime(2025, 11, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3686), "Approved", new DateTime(2025, 11, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3686), "Thermostat calibration off, causing temperature fluctuations.", 20 },
                    { 9, null, null, "Customer reported inconsistent temperature for several weeks.", "5", null, 12, null, null, "FRG-008-007", "Frequent Breakdowns - Multiple service calls in last 3 months", new DateTime(2025, 10, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3691), "Pending", new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3691), "Refrigerant leak detected in evaporator coils - uneconomical to repair.", 2 },
                    { 10, null, null, "Water leakage from the unit causing floor damage.", "23", null, 2, null, null, "FRG-008-005", "Fridge Beyond Repair - Compressor failure", new DateTime(2025, 11, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3696), "Pending", new DateTime(2025, 11, 2, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3696), "Multiple component failures detected during diagnostic testing.", 15 },
                    { 11, null, null, "Customer requesting energy efficient replacement model.", "21", null, 11, null, null, "FRG-009-010", "Frequent Breakdowns - Multiple service calls in last 3 months", new DateTime(2025, 9, 27, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3700), "Pending", new DateTime(2025, 9, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3700), "Condenser fan motor seized, causing overheating issues.", 10 },
                    { 12, null, null, "Door seal broken, causing cold air escape.", "24", null, 12, null, null, "FRG-012-005", "Customer Request - Customer requested upgrade to newer model", new DateTime(2025, 10, 7, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3705), "Pending", new DateTime(2025, 9, 20, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3705), "Thermostat calibration off, causing temperature fluctuations.", 1 }
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
