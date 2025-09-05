using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
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
                name: "tblFridge",
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
                    RentalPricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFridge", x => x.FridgeId);
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

            migrationBuilder.InsertData(
                table: "tblFridge",
                columns: new[] { "FridgeId", "AvailabilityStatus", "Brand", "CapacityLiters", "Condition", "Description", "FridgeNo", "ImageUrl", "LastMaintenanceDate", "Model", "RentalPricePerMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Available", "Samsung", 253, "Excellent", "Energy-efficient double door fridge with frost-free technology.", "FRG-001", "https://example.com/images/fridge1.jpg", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "RT28T", 1200.00m, "Double Door" },
                    { 2, "Rented", "LG", 190, "Good", "Compact single door fridge ideal for small apartments.", "FRG-002", "https://example.com/images/fridge2.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GL-B201", 900.00m, "Single Door" },
                    { 3, "Available", "Whirlpool", 500, "Excellent", "Spacious fridge with advanced cooling technology.", "FRG-003", "https://example.com/images/fridge3.jpg", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT518", 1500.00m, "Double Door" },
                    { 4, "Available", "Defy", 350, "Good", "Durable fridge with energy-saving features.", "FRG-004", "https://example.com/images/fridge4.jpg", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DAC700", 1100.00m, "Double Door" },
                    { 5, "Rented", "Hisense", 310, "Good", "Compact fridge with adjustable shelves.", "FRG-005", "https://example.com/images/fridge5.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "H310BI", 800.00m, "Single Door" },
                    { 6, "Available", "Bosch", 420, "Excellent", "Premium fridge with no-frost technology.", "FRG-006", "https://example.com/images/fridge6.jpg", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "KDN42", 1600.00m, "Double Door" },
                    { 7, "Available", "Kelvinator", 250, "Fair", "Affordable fridge with basic features.", "FRG-007", "https://example.com/images/fridge7.jpg", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "KEL250", 700.00m, "Single Door" },
                    { 8, "Available", "Smeg", 281, "Excellent", "Retro-style fridge with modern cooling.", "FRG-008", "https://example.com/images/fridge8.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAB28", 2000.00m, "Single Door" },
                    { 9, "Rented", "AEG", 300, "Excellent", "Built-in fridge with adjustable compartments.", "FRG-009", "https://example.com/images/fridge9.jpg", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SKE818", 1800.00m, "Single Door" },
                    { 10, "Available", "Panasonic", 347, "Good", "Fridge with inverter technology for energy saving.", "FRG-010", "https://example.com/images/fridge10.jpg", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "NR-BL347", 1300.00m, "Double Door" },
                    { 11, "Available", "Haier", 565, "Excellent", "Large capacity fridge with twin inverter technology.", "FRG-011", "https://example.com/images/fridge11.jpg", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HRF-619", 2200.00m, "Side by Side" },
                    { 12, "Available", "Hitachi", 640, "Excellent", "Premium French door fridge with eco-friendly features.", "FRG-012", "https://example.com/images/fridge12.jpg", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "R-WB640", 2500.00m, "French Door" },
                    { 13, "Rented", "Electrolux", 370, "Good", "Fridge with taste guard deodorizer.", "FRG-013", "https://example.com/images/fridge13.jpg", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETB3700", 1400.00m, "Top Freezer" },
                    { 14, "Available", "Sharp", 600, "Excellent", "Fridge with plasmacluster ion technology.", "FRG-014", "https://example.com/images/fridge14.jpg", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "SJ-GX60", 2300.00m, "French Door" },
                    { 15, "Available", "Midea", 400, "Good", "Affordable fridge with large freezer compartment.", "FRG-015", "https://example.com/images/fridge15.jpg", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HD-400", 1000.00m, "Double Door" },
                    { 16, "Available", "Gorenje", 326, "Good", "Stylish bottom freezer fridge with crisp zone for vegetables.", "FRG-016", "https://example.com/images/fridge16.jpg", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "NRK6192", 1250.00m, "Bottom Freezer" },
                    { 17, "Available", "Westinghouse", 528, "Excellent", "Family-sized fridge with humidity-controlled crisper.", "FRG-017", "https://example.com/images/fridge17.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WBE5300", 1700.00m, "Top Freezer" },
                    { 18, "Rented", "Fisher & Paykel", 519, "Excellent", "Premium French door fridge with active smart technology.", "FRG-018", "https://example.com/images/fridge18.jpg", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RF522", 2400.00m, "French Door" },
                    { 19, "Available", "Ariston", 383, "Good", "Reliable fridge with antibacterial coating.", "FRG-019", "https://example.com/images/fridge19.jpg", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "MBA3832", 1150.00m, "Top Freezer" },
                    { 20, "Available", "Beko", 560, "Excellent", "Spacious bottom freezer fridge with NeoFrost cooling.", "FRG-020", "https://example.com/images/fridge20.jpg", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "RCNE560", 1850.00m, "Bottom Freezer" }
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
                name: "tblFridge");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
