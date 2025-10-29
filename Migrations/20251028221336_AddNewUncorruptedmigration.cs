using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUncorruptedmigration : Migration
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
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    RequestHeaderId = table.Column<int>(type: "int", nullable: false)
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
                name: "tblFaultTechnicians",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianAssigned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bookingate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerBookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultTechnicians", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_tblFaultTechnicians_tblFridgeVisits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "tblFridgeVisits",
                        principalColumn: "VisitId",
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
                name: "tblFridgeReplacements",
                columns: table => new
                {
                    FridgeReplacementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    NewFridgeInStockId = table.Column<int>(type: "int", nullable: true),
                    OldFridgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacementStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridgeReplacements", x => x.FridgeReplacementId);
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

            migrationBuilder.InsertData(
                table: "tblFridges",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Description", "ImageUrl", "Location", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 250, "Energy efficient fridge with frost-free technology", "/Images/Fridges/0f189537-b86b-46ed-88b0-697d64518b86.jpg", "Durban", "RT28A", 450.0, "Double Door" },
                    { 2, "Available", "LG", 260, "Smart inverter compressor for energy savings", "/Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", "Johannesburg", "GL-T292", 480.0, "Top Freezer" },
                    { 3, "Rented", "Hisense", 320, "Spacious design with humidity control", "Images/Fridges/1bde2bd0-9345-4868-bf0e-3a568b75b45d.jpg", "Cape Town", "H370BI", 520.0, "Bottom Freezer" },
                    { 4, "Available", "Defy", 350, "A+ energy rated with multi-airflow system", "Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", "Pretoria", "DAC621", 550.0, "Combi Fridge" },
                    { 5, "Available", "Whirlpool", 200, "Compact and efficient single door fridge", "Images/Fridges/3fab2301-7b43-489c-a5eb-a4a84e146a0c.jpg", "Durban", "WDE205", 400.0, "Single Door" },
                    { 6, "Rented", "Bosch", 350, "No frost cooling with LED lighting", "Images/Fridges/4ff51e2e-eb52-464d-9bd0-9b93671b7b1d.jpg", "Port Elizabeth", "KDN42", 600.0, "Frost Free" },
                    { 7, "Available", "Smeg", 270, "Stylish retro fridge with adjustable shelves", "Images/Fridges/5f3c62bc-b7a1-4099-8453-0562449c1eba.jpg", "Johannesburg", "FAB28", 650.0, "Retro Style" },
                    { 8, "Available", "Kelvinator", 265, "Affordable fridge with efficient cooling", "Images/Fridges/06d99650-49bb-46a0-9c87-479b064e20cf.jpg.jpg", "Cape Town", "KRF265", 430.0, "Top Mount" },
                    { 9, "Rented", "Siemens", 360, "No frost with multi-airflow system", "Images/Fridges/6c99da3a-7e53-4a54-a4c2-179ba50f4552.jpg", "Pretoria", "KG36N", 590.0, "Bottom Freezer" },
                    { 10, "Available", "Haier", 290, "Toughened glass shelves and energy efficient", "Images/Fridges/7a5c9f14-43cc-4b88-98a1-2cd4f34b355a.jpg", "Durban", "HRF290", 470.0, "Double Door" },
                    { 11, "Available", "Hisense", 310, "Low noise and efficient compressor", "Images/Fridges/7a5ef7b8-7c58-4d8e-bf27-3c1c9a911b45.jpg", "Bloemfontein", "H310BI", 500.0, "Top Freezer" },
                    { 12, "Rented", "Defy", 420, "LED display and water dispenser", "Images/Fridges/8e2d92bf-c306-4688-89f5-019d76a9539b.jpg", "Cape Town", "DAC700", 700.0, "Side by Side" },
                    { 13, "Available", "LG", 282, "Smart cooling with WiFi control", "Images/Fridges/7e4c22d6-9a91-4d0c-83db-95856b2a30f0.jpg", "Durban", "GL-Q282", 530.0, "Smart Inverter" },
                    { 14, "Rented", "Samsung", 340, "Twin cooling system for freshness", "Images/Fridges/16eaa25a-e6ad-4584-869f-79c59db95573.jpg", "Pretoria", "RT34A", 560.0, "Top Freezer" },
                    { 15, "Available", "Whirlpool", 500, "High capacity with 6th sense technology", "Images/Fridges/33b3ec74-7862-44e1-afa0-4c4a42689a9f.jpg", "Johannesburg", "WDE520", 750.0, "Double Door" },
                    { 16, "Available", "Bosch", 400, "Energy efficient and silent operation", "Images/Fridges/59a41e73-af93-465b-a5aa-f0d7cf37fe2c.jpg", "Durban", "KDN43", 610.0, "Frost Free" },
                    { 17, "Rented", "Smeg", 300, "Vintage design with modern efficiency", "Images/Fridges/be54bce5-b511-4946-8f3a-55ae0a65ec35.jpg", "Cape Town", "FAB32", 670.0, "Retro Style" },
                    { 18, "Available", "Siemens", 390, "Multi-airflow and easy-clean interior", "Images/Fridges/dff205af-9cde-4e97-876d-3b9a603e6459.jpg", "Johannesburg", "KG39N", 620.0, "Combi Fridge" },
                    { 19, "Available", "Haier", 330, "Tough build and fast cooling", "Images/Fridges/45189b3d-8e97-49b3-8c90-47ec9d6db6b9.jpg", "Pretoria", "HRF330", 500.0, "Bottom Freezer" },
                    { 20, "Rented", "Defy", 473, "Spacious and frost-free design", "Images/Fridges/2634148d-20b9-40c2-9849-3566df69f859.jpg", "Durban", "DAC473", 720.0, "Side by Side" }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblFridgeInStocks");

            migrationBuilder.DropTable(
                name: "tblFridgeVisits");

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
