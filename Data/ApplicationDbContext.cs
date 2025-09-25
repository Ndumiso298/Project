
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Utilities;
using Project.Utilities.Enums;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeAllocation> FridgeAllocations { get; set; }
        public DbSet<AllocationRequestHeader> AllocationRequestHeaders { get; set; }
        public DbSet<AllocationRequestDetail> AllocationRequestDetails { get; set; }
        public DbSet<FaultRecord> FaultRecords { get; set; }
        public DbSet<MaintenanceVisit> MaintenanceVisits { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<ReplacementRequest> ReplacementRequests { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = SD.AdminRole, NormalizedName = SD.AdminRole.ToUpper() },
                new IdentityRole { Id = "2", Name = SD.CustomerSupportRole, NormalizedName = SD.CustomerSupportRole.ToUpper() },
                new IdentityRole { Id = "3", Name = SD.StockControllerRole, NormalizedName = SD.StockControllerRole.ToUpper() },
                new IdentityRole { Id = "4", Name = SD.FaultTechnicianRole, NormalizedName = SD.FaultTechnicianRole.ToUpper() },
                new IdentityRole { Id = "5", Name = SD.MaintenanceTechnicianRole, NormalizedName = SD.MaintenanceTechnicianRole.ToUpper() },
                new IdentityRole { Id = "6", Name = SD.CustomerRole, NormalizedName = SD.CustomerRole.ToUpper() }
            );

            modelBuilder.Entity<Location>().HasData(
                // 1 - Customer site
                new Location
                {
                    Id = 1,
                    Name = "Boerewors Palace",
                    Province = "Gauteng",
                    City = "Johannesburg",
                    Suburb = "CBD",
                    AddressLine1 = "123 Main Street",
                    AddressLine2 = "Corner of 5th Ave",
                    PostalCode = "2001",
                    Country = "South Africa"
                },

                // 2 - SmartChill Warehouse (Eastern Cape)
                new Location
                {
                    Id = 2,
                    Name = "SmartChill Warehouse - Gqeberha",
                    Province = "Eastern Cape",
                    City = "Gqeberha",
                    Suburb = "Walmer",
                    AddressLine1 = "123 Main Road",
                    AddressLine2 = "Unit 4",
                    PostalCode = "6070",
                    Country = "South Africa"
                },

                // 3 - SmartChill Warehouse (Gauteng)
                new Location
                {
                    Id = 3,
                    Name = "SmartChill Warehouse - Johannesburg",
                    Province = "Gauteng",
                    City = "Johannesburg",
                    Suburb = "Sandton",
                    AddressLine1 = "10 Rivonia Road",
                    AddressLine2 = "Floor 3",
                    PostalCode = "2196",
                    Country = "South Africa"
                },

                // 4 - SmartChill Warehouse (Western Cape)
                new Location
                {
                    Id = 4,
                    Name = "SmartChill Warehouse - Cape Town",
                    Province = "Western Cape",
                    City = "Cape Town",
                    Suburb = "Epping",
                    AddressLine1 = "55 Industria Road",
                    AddressLine2 = null,
                    PostalCode = "7460",
                    Country = "South Africa"
                },

                // 5 - SmartChill Service Center
                new Location
                {
                    Id = 5,
                    Name = "SmartChill Service Center",
                    Province = "KwaZulu-Natal",
                    City = "Durban",
                    Suburb = "Pinetown",
                    AddressLine1 = "18 Workshop Avenue",
                    AddressLine2 = null,
                    PostalCode = "3610",
                    Country = "South Africa"
                },

                // 6 - Regional Office (Free State)
                new Location
                {
                    Id = 6,
                    Name = "SmartChill Regional Office - Bloemfontein",
                    Province = "Free State",
                    City = "Bloemfontein",
                    Suburb = "Westdene",
                    AddressLine1 = "22 Nelson Mandela Drive",
                    AddressLine2 = "Suite 101",
                    PostalCode = "9301",
                    Country = "South Africa"
                },

                // 7 - Depot (Mpumalanga)
                new Location
                {
                    Id = 7,
                    Name = "SmartChill Depot - Nelspruit",
                    Province = "Mpumalanga",
                    City = "Mbombela",
                    Suburb = "Riverside",
                    AddressLine1 = "7 Lowveld Street",
                    AddressLine2 = null,
                    PostalCode = "1201",
                    Country = "South Africa"
                },

                // 8 - Showroom (Limpopo)
                new Location
                {
                    Id = 8,
                    Name = "SmartChill Showroom - Polokwane",
                    Province = "Limpopo",
                    City = "Polokwane",
                    Suburb = "Flora Park",
                    AddressLine1 = "89 Market Street",
                    AddressLine2 = null,
                    PostalCode = "0700",
                    Country = "South Africa"
                },

                // 9 - Satellite Office (North West)
                new Location
                {
                    Id = 9,
                    Name = "SmartChill Satellite Office - Rustenburg",
                    Province = "North West",
                    City = "Rustenburg",
                    Suburb = "Bo-dorp",
                    AddressLine1 = "14 Platinum Drive",
                    AddressLine2 = null,
                    PostalCode = "0299",
                    Country = "South Africa"
                },

                // 10 - Support Hub (Northern Cape)
                new Location
                {
                    Id = 10,
                    Name = "SmartChill Support Hub - Kimberley",
                    Province = "Northern Cape",
                    City = "Kimberley",
                    Suburb = "Monument Heights",
                    AddressLine1 = "5 Diamond Road",
                    AddressLine2 = "Block B",
                    PostalCode = "8301",
                    Country = "South Africa"
                }
            );

            // Precompute password hashes (use the same password for all seeded users for simplicity)
            var user = new ApplicationUser();
            var hasher = new PasswordHasher<ApplicationUser>();
            var defaultPassword = "strongPassword#123"; // Change this to a secure value in production

            // Seed Users
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    EmployeeId = 1,
                    UserName = "admin@smartchill.com",
                    FirstName = "Collins",
                    LastName = "Khosa",
                    Email = "admin@smartchill.com",
                    PhoneNumber = "+27 64 534 7790",
                    UserRole = SD.AdminRole,
                    NormalizedUserName = "ADMIN@SMARTCHILL.COM",
                    NormalizedEmail = "ADMIN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    LocationId = 6
                },
                new ApplicationUser
                {
                    Id = "2",
                    EmployeeId = 2,
                    UserName = "customersupport@smartchill.com",
                    FirstName = "Andries",
                    LastName = "Tatane",
                    Email = "customersupport@smartchill.com",
                    PhoneNumber = "+27 71 073 7734",
                    UserRole = SD.CustomerSupportRole,
                    NormalizedUserName = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    NormalizedEmail = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LocationId = 10
                },
                new ApplicationUser
                {
                    Id = "3",
                    EmployeeId = 3,
                    UserName = "stockcontroller@smartchill.com",
                    FirstName = "Mido",
                    LastName = "Macia",
                    Email = "stockcontroller@smartchill.com",
                    PhoneNumber = "+27 66 293 4430",
                    UserRole = SD.StockControllerRole,
                    NormalizedUserName = "STOCKCONTROLLER@SMARTCHILL.COM",
                    NormalizedEmail = "STOCKCONTROLLER@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LocationId = 2
                },
                new ApplicationUser
                {
                    Id = "4",
                    EmployeeId = 4,
                    UserName = "faulttechnician@smartchill.com",
                    FirstName = "Nathaniel",
                    LastName = "Julies",
                    Email = "faulttechnician@smartchill.com",
                    PhoneNumber = "+27 79 894 6438",
                    UserRole = SD.FaultTechnicianRole,
                    NormalizedUserName = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    NormalizedEmail = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LocationId = 5
                },
                new ApplicationUser
                {
                    Id = "5",
                    EmployeeId = 5,
                    UserName = "maintenancetechnician@smartchill.com",
                    FirstName = "Latiefa",
                    LastName = "Freeman",
                    Email = "maintenancetechnician@smartchill.com",
                    PhoneNumber = "+27 61 483 6998",
                    UserRole = SD.MaintenanceTechnicianRole,
                    NormalizedUserName = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    NormalizedEmail = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LocationId = 5
                },
                new ApplicationUser
                {
                    Id = "6",
                    CustomerId = 1,
                    UserName = "naterobertson@gmail.com",
                    FirstName = "Nathan",
                    LastName = "Robertson",
                    Email = "naterobertson@gmail.com",
                    PhoneNumber = "+27 69 174 5946",
                    UserRole = SD.CustomerRole,
                    NormalizedUserName = "NATEROBERTSON@GMAIL.COM",
                    NormalizedEmail = "NATEROBERTSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(user, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LocationId = 1 // Assuming Location with UserId 1 exists
                }
            );
            // Assign Roles to Users
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "3", RoleId = "3" },
                new IdentityUserRole<string> { UserId = "4", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "5", RoleId = "5" },
                new IdentityUserRole<string> { UserId = "6", RoleId = "6" }
            );


            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmployeeType");

            modelBuilder.Entity<Employee>()
                .Property("EmployeeType")                // Configure discriminator column
                .HasMaxLength(21)
                .HasColumnType("nvarchar(21)")
                .IsRequired();

            modelBuilder.Entity<Employee>().HasData(
                // Customer Support
                new Employee
                {
                    Id = 1,
                    UserId = "2",
                    EmployeeNumber = "CS001",
                    EmployeeType = EmployeeType.CustomerSupport,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    CreatedAt = new DateTime(2025, 9, 21), // fixed value
                    IsActive = true
                },
                // Stock Controller
                new Employee
                {
                    Id = 2,
                    UserId = "3",
                    EmployeeNumber = "SC001",
                    EmployeeType = EmployeeType.StockController,
                    AvailabilityStatus = AvailabilityStatus.OnDuty,
                    CreatedAt = new DateTime(2025, 9, 21),
                    IsActive = true
                },
                // Fault AssignedTechnician
                new Employee
                {
                    Id = 3,
                    UserId = "4",
                    EmployeeNumber = "FT001",
                    EmployeeType = EmployeeType.FaultTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    CreatedAt = new DateTime(2025, 9, 21),
                    IsActive = true
                },
                // Maintenance AssignedTechnician
                new Employee
                {
                    Id = 4,
                    UserId = "5",
                    EmployeeNumber = "MT001",
                    EmployeeType = EmployeeType.MaintenanceTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    CreatedAt = new DateTime(2025, 9, 21),
                    IsActive = true
                }
            );

            //Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    UserId = "6", // FK to ApplicationUser
                    CustomerLiaisonId = 2, // FK to Employee
                    TradingName = "Boerewors Palace",
                    BusinessType = BusinessType.SmallRetail,
                    BusinessEmail = "info@boereworspalace.co.za",
                    BusinessPhoneNumber = "+27 11 555 0101",
                    LocationId = 1,
                    AddressLine1 = "123 Main Street",
                    AddressLine2 = "Corner of 5th Ave",
                    City = "Johannesburg",
                    Province = "Gauteng",
                    PostalCode = "2001",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                }
            );


            modelBuilder.Entity<Fridge>().HasData(
                // Warehouse Distribution (Majority in main warehouses)

                // ===== JOHANNESBURG WAREHOUSE (Largest stock) =====
                new Fridge
                {
                    Id = 1,
                    Manufacturer = "Samsung",
                    SerialNumber = "SAM-BEER-001",
                    Model = "RB29F",
                    CapacityLiters = 290,
                    Type = "Double Door Commercial",
                    Description = "Commercial beverage fridge with glass door, perfect for beer and drinks display.",
                    RentalPricePerMonth = 1500.00m,
                    LastMaintenanceDate = new DateTime(2024, 6, 15),
                    LocationId = 3, // Johannesburg Warehouse
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1629367494173-c78a56567877",
                    PurchaseDate = new DateTime(2024, 1, 10),
                    PurchasePrice = 12000.00m,
                    WarrantyExpiryDate = new DateTime(2026, 1, 10),
                    EnergyRating = "A+",
                    Dimensions = "180×70×70cm",
                    Weight = 85.5m,
                    Color = "Stainless Steel",
                    CreatedDate = new DateTime(2024, 1, 10),
                    ModifiedDate = new DateTime(2024, 6, 15)
                },
                new Fridge
                {
                    Id = 2,
                    Manufacturer = "LG",
                    SerialNumber = "LG-BAR-202",
                    Model = "GL-D422CL",
                    CapacityLiters = 420,
                    Type = "Glass Door Display",
                    Description = "Large capacity glass door fridge for bar use, ideal for beverage storage.",
                    RentalPricePerMonth = 1800.00m,
                    LastMaintenanceDate = new DateTime(2024, 5, 20),
                    LocationId = 3, // Johannesburg Warehouse
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Allocated,
                    ImageUrl = "https://images.unsplash.com/photo-1579389083078-4e7018379f7e",
                    PurchaseDate = new DateTime(2023, 3, 15),
                    PurchasePrice = 15000.00m,
                    WarrantyExpiryDate = new DateTime(2025, 3, 15),
                    EnergyRating = "A",
                    Dimensions = "190×80×75cm",
                    Weight = 92.0m,
                    Color = "Black",
                    CreatedDate = new DateTime(2023, 3, 15),
                    ModifiedDate = new DateTime(2024, 5, 20)
                },
                new Fridge
                {
                    Id = 3,
                    Manufacturer = "Hisense",
                    SerialNumber = "HIS-SHEB-303",
                    Model = "QR638W",
                    CapacityLiters = 638,
                    Type = "Commercial Reach-In",
                    Description = "Large capacity reach-in fridge for high-volume shebeen operations.",
                    RentalPricePerMonth = 2200.00m,
                    LastMaintenanceDate = new DateTime(2024, 4, 10),
                    LocationId = 3, // Johannesburg Warehouse
                    Condition = FridgeCondition.NeedsService,
                    Status = FridgeStatus.InRepair,
                    ImageUrl = "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91",
                    PurchaseDate = new DateTime(2022, 8, 22),
                    PurchasePrice = 18000.00m,
                    WarrantyExpiryDate = new DateTime(2024, 8, 22),
                    EnergyRating = "B",
                    Dimensions = "200×90×85cm",
                    Weight = 110.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2022, 8, 22),
                    ModifiedDate = new DateTime(2024, 4, 10)
                },
                new Fridge
                {
                    Id = 4,
                    Manufacturer = "Defy",
                    SerialNumber = "DEFY-SPAZA-404",
                    Model = "FF388",
                    CapacityLiters = 388,
                    Type = "Upright Freezer",
                    Description = "Upright freezer with multiple shelves, perfect for frozen goods in spaza shops.",
                    RentalPricePerMonth = 1200.00m,
                    LastMaintenanceDate = new DateTime(2024, 7, 5),
                    LocationId = 3, // Johannesburg Warehouse
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19",
                    PurchaseDate = new DateTime(2024, 2, 14),
                    PurchasePrice = 9500.00m,
                    WarrantyExpiryDate = new DateTime(2026, 2, 14),
                    EnergyRating = "A+",
                    Dimensions = "170×65×65cm",
                    Weight = 75.0m,
                    Color = "White",
                    CreatedDate = new DateTime(2024, 2, 14),
                    ModifiedDate = new DateTime(2024, 7, 5)
                },

                // ===== CAPE TOWN WAREHOUSE =====
                new Fridge
                {
                    Id = 5,
                    Manufacturer = "Snapper",
                    SerialNumber = "SNAP-SPAZA-505",
                    Model = "CUF270",
                    CapacityLiters = 270,
                    Type = "Chest Freezer",
                    Description = "Energy-efficient chest freezer for bulk frozen food storage.",
                    RentalPricePerMonth = 950.00m,
                    LastMaintenanceDate = new DateTime(2024, 3, 18),
                    LocationId = 4, // Cape Town Warehouse
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Allocated,
                    ImageUrl = "https://images.unsplash.com/photo-1631549916768-4119c9ff7ac5",
                    PurchaseDate = new DateTime(2023, 5, 30),
                    PurchasePrice = 7000.00m,
                    WarrantyExpiryDate = new DateTime(2025, 5, 30),
                    EnergyRating = "A",
                    Dimensions = "140×75×85cm",
                    Weight = 68.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2023, 5, 30),
                    ModifiedDate = new DateTime(2024, 3, 18)
                },
                new Fridge
                {
                    Id = 6,
                    Manufacturer = "Kelvinator",
                    SerialNumber = "KELV-SPAZA-606",
                    Model = "KFR450",
                    CapacityLiters = 450,
                    Type = "Double Door Fridge",
                    Description = "Spacious double door fridge with separate freezer compartment.",
                    RentalPricePerMonth = 1300.00m,
                    LastMaintenanceDate = new DateTime(2024, 6, 28),
                    LocationId = 4, // Cape Town Warehouse
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5",
                    PurchaseDate = new DateTime(2024, 3, 10),
                    PurchasePrice = 11000.00m,
                    WarrantyExpiryDate = new DateTime(2026, 3, 10),
                    EnergyRating = "A+",
                    Dimensions = "175×70×70cm",
                    Weight = 80.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2024, 3, 10),
                    ModifiedDate = new DateTime(2024, 6, 28)
                },

                // ===== GQEBERHA WAREHOUSE =====
                new Fridge
                {
                    Id = 7,
                    Manufacturer = "LG",
                    SerialNumber = "LG-SHEB-707",
                    Model = "LFXS28566",
                    CapacityLiters = 780,
                    Type = "French Door Commercial",
                    Description = "Large French door commercial fridge with ice maker, perfect for high-volume establishments.",
                    RentalPricePerMonth = 2500.00m,
                    LastMaintenanceDate = new DateTime(2024, 5, 12),
                    LocationId = 2, // Gqeberha Warehouse
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.UnderMaintenance,
                    ImageUrl = "https://images.unsplash.com/photo-1598301257982-0cf01499abb2",
                    PurchaseDate = new DateTime(2023, 1, 15),
                    PurchasePrice = 22000.00m,
                    WarrantyExpiryDate = new DateTime(2025, 1, 15),
                    EnergyRating = "A++",
                    Dimensions = "185×95×80cm",
                    Weight = 125.0m,
                    Color = "Stainless Steel",
                    CreatedDate = new DateTime(2023, 1, 15),
                    ModifiedDate = new DateTime(2024, 5, 12)
                },
                new Fridge
                {
                    Id = 8,
                    Manufacturer = "Samsung",
                    SerialNumber = "SAM-SPAZA-808",
                    Model = "RT38K",
                    CapacityLiters = 385,
                    Type = "Top Mount Freezer",
                    Description = "Reliable top mount freezer fridge for small spaza shops.",
                    RentalPricePerMonth = 1100.00m,
                    LastMaintenanceDate = new DateTime(2024, 4, 22),
                    LocationId = 2, // Gqeberha Warehouse
                    Condition = FridgeCondition.NeedsService,
                    Status = FridgeStatus.InRepair,
                    ImageUrl = "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5",
                    PurchaseDate = new DateTime(2022, 11, 5),
                    PurchasePrice = 9000.00m,
                    WarrantyExpiryDate = new DateTime(2024, 11, 5),
                    EnergyRating = "B",
                    Dimensions = "170×65×65cm",
                    Weight = 72.0m,
                    Color = "White",
                    CreatedDate = new DateTime(2022, 11, 5),
                    ModifiedDate = new DateTime(2024, 4, 22)
                },

                // ===== DURBAN SERVICE CENTER (Fridges being serviced) =====
                new Fridge
                {
                    Id = 9,
                    Manufacturer = "Defy",
                    SerialNumber = "DEFY-SHEB-909",
                    Model = "DDT392",
                    CapacityLiters = 392,
                    Type = "Double Door Commercial",
                    Description = "Commercial double door fridge with digital temperature control.",
                    RentalPricePerMonth = 1600.00m,
                    LastMaintenanceDate = new DateTime(2024, 7, 8),
                    LocationId = 5, // Durban Service Center
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91",
                    PurchaseDate = new DateTime(2024, 2, 20),
                    PurchasePrice = 13000.00m,
                    WarrantyExpiryDate = new DateTime(2026, 2, 20),
                    EnergyRating = "A+",
                    Dimensions = "180×70×70cm",
                    Weight = 85.0m,
                    Color = "Black",
                    CreatedDate = new DateTime(2024, 2, 20),
                    ModifiedDate = new DateTime(2024, 7, 8)
                },
                new Fridge
                {
                    Id = 10,
                    Manufacturer = "Snapper",
                    SerialNumber = "SNAP-SHEB-1010",
                    Model = "CRF550",
                    CapacityLiters = 550,
                    Type = "Commercial Reach-In",
                    Description = "Heavy-duty commercial reach-in fridge for bars and shebeens.",
                    RentalPricePerMonth = 1900.00m,
                    LastMaintenanceDate = new DateTime(2024, 3, 30),
                    LocationId = 5, // Durban Service Center
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Allocated,
                    ImageUrl = "https://images.unsplash.com/photo-1629367494173-c78a56567877",
                    PurchaseDate = new DateTime(2023, 4, 12),
                    PurchasePrice = 16000.00m,
                    WarrantyExpiryDate = new DateTime(2025, 4, 12),
                    EnergyRating = "A",
                    Dimensions = "190×80×75cm",
                    Weight = 95.0m,
                    Color = "Stainless Steel",
                    CreatedDate = new DateTime(2023, 4, 12),
                    ModifiedDate = new DateTime(2024, 3, 30)
                },

                // ===== BLOEMFONTEIN REGIONAL OFFICE =====
                new Fridge
                {
                    Id = 11,
                    Manufacturer = "LG",
                    SerialNumber = "LG-SPAZA-1111",
                    Model = "GN-B472SLC",
                    CapacityLiters = 472,
                    Type = "Bottom Freezer",
                    Description = "Bottom freezer fridge with ample storage for spaza shops.",
                    RentalPricePerMonth = 1400.00m,
                    LastMaintenanceDate = new DateTime(2024, 6, 10),
                    LocationId = 6, // Bloemfontein Regional Office
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19",
                    PurchaseDate = new DateTime(2024, 1, 25),
                    PurchasePrice = 11500.00m,
                    WarrantyExpiryDate = new DateTime(2026, 1, 25),
                    EnergyRating = "A+",
                    Dimensions = "175×70×70cm",
                    Weight = 82.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2024, 1, 25),
                    ModifiedDate = new DateTime(2024, 6, 10)
                },

                // ===== NELSPRUIT DEPOT =====
                new Fridge
                {
                    Id = 12,
                    Manufacturer = "Samsung",
                    SerialNumber = "SAM-SHEB-1212",
                    Model = "BRB260",
                    CapacityLiters = 260,
                    Type = "Bar Fridge",
                    Description = "Compact bar fridge perfect for small shebeens or as additional storage.",
                    RentalPricePerMonth = 850.00m,
                    LastMaintenanceDate = new DateTime(2024, 5, 5),
                    LocationId = 7, // Nelspruit Depot
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.QualityControl,
                    ImageUrl = "https://images.unsplash.com/photo-1579389083078-4e7018379f7e",
                    PurchaseDate = new DateTime(2023, 7, 18),
                    PurchasePrice = 6800.00m,
                    WarrantyExpiryDate = new DateTime(2025, 7, 18),
                    EnergyRating = "A",
                    Dimensions = "85×55×55cm",
                    Weight = 45.0m,
                    Color = "Black",
                    CreatedDate = new DateTime(2023, 7, 18),
                    ModifiedDate = new DateTime(2024, 5, 5)
                },

                // ===== POLOKWANE SHOWROOM =====
                new Fridge
                {
                    Id = 13,
                    Manufacturer = "Defy",
                    SerialNumber = "DEFY-SPAZA-1313",
                    Model = "PLT420",
                    CapacityLiters = 420,
                    Type = "Platinum Series",
                    Description = "Premium fridge with advanced cooling technology for spaza shops.",
                    RentalPricePerMonth = 1700.00m,
                    LastMaintenanceDate = new DateTime(2024, 4, 15),
                    LocationId = 8, // Polokwane Showroom
                    Condition = FridgeCondition.NeedsService,
                    Status = FridgeStatus.InTransit,
                    ImageUrl = "https://images.unsplash.com/photo-1598301257982-0cf01499abb2",
                    PurchaseDate = new DateTime(2022, 12, 10),
                    PurchasePrice = 14000.00m,
                    WarrantyExpiryDate = new DateTime(2024, 12, 10),
                    EnergyRating = "A",
                    Dimensions = "180×70×70cm",
                    Weight = 88.0m,
                    Color = "Stainless Steel",
                    CreatedDate = new DateTime(2022, 12, 10),
                    ModifiedDate = new DateTime(2024, 4, 15)
                },

                // ===== RUSTENBURG SATELLITE OFFICE =====
                new Fridge
                {
                    Id = 14,
                    Manufacturer = "Hisense",
                    SerialNumber = "HIS-SHEB-1414",
                    Model = "QR718W",
                    CapacityLiters = 718,
                    Type = "Commercial Reach-In",
                    Description = "Extra large reach-in fridge for high-capacity shebeen operations.",
                    RentalPricePerMonth = 2400.00m,
                    LastMaintenanceDate = new DateTime(2024, 3, 8),
                    LocationId = 9, // Rustenburg Satellite Office
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Reserved,
                    ImageUrl = "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91",
                    PurchaseDate = new DateTime(2023, 2, 28),
                    PurchasePrice = 20000.00m,
                    WarrantyExpiryDate = new DateTime(2025, 2, 28),
                    EnergyRating = "B",
                    Dimensions = "200×90×85cm",
                    Weight = 115.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2023, 2, 28),
                    ModifiedDate = new DateTime(2024, 3, 8)
                },

                // ===== KIMBERLEY SUPPORT HUB =====
                new Fridge
                {
                    Id = 15,
                    Manufacturer = "Kelvinator",
                    SerialNumber = "KELV-SPAZA-1515",
                    Model = "KFR300",
                    CapacityLiters = 300,
                    Type = "Single Door",
                    Description = "Economical single door fridge for small spaza shops.",
                    RentalPricePerMonth = 950.00m,
                    LastMaintenanceDate = new DateTime(2024, 7, 12),
                    LocationId = 10, // Kimberley Support Hub
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1571175443880-49e1d25b2bc5",
                    PurchaseDate = new DateTime(2024, 4, 5),
                    PurchasePrice = 7800.00m,
                    WarrantyExpiryDate = new DateTime(2026, 4, 5),
                    EnergyRating = "A",
                    Dimensions = "150×60×60cm",
                    Weight = 65.0m,
                    Color = "White",
                    CreatedDate = new DateTime(2024, 4, 5),
                    ModifiedDate = new DateTime(2024, 7, 12)
                },

                // ===== CUSTOMER SITE (Boerewors Palace) =====
                new Fridge
                {
                    Id = 16,
                    Manufacturer = "Snapper",
                    SerialNumber = "SNAP-SHEB-1616",
                    Model = "BVF200",
                    CapacityLiters = 200,
                    Type = "Beverage Cooler",
                    Description = "Compact beverage cooler for bars and shebeens.",
                    RentalPricePerMonth = 800.00m,
                    LastMaintenanceDate = new DateTime(2024, 5, 25),
                    LocationId = 1, // Boerewors Palace (Customer Site)
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Quarantined,
                    ImageUrl = "https://images.unsplash.com/photo-1629367494173-c78a56567877",
                    PurchaseDate = new DateTime(2023, 9, 15),
                    PurchasePrice = 6500.00m,
                    WarrantyExpiryDate = new DateTime(2025, 9, 15),
                    EnergyRating = "A",
                    Dimensions = "90×50×50cm",
                    Weight = 42.0m,
                    Color = "Black",
                    CreatedDate = new DateTime(2023, 9, 15),
                    ModifiedDate = new DateTime(2024, 5, 25)
                },

                // ===== ADDITIONAL WAREHOUSE STOCK =====
                new Fridge
                {
                    Id = 17,
                    Manufacturer = "LG",
                    SerialNumber = "LG-SPAZA-1717",
                    Model = "GL-L502CL",
                    CapacityLiters = 502,
                    Type = "Glass Door Display",
                    Description = "Glass door display fridge for spaza shops to showcase products.",
                    RentalPricePerMonth = 1750.00m,
                    LastMaintenanceDate = new DateTime(2024, 6, 20),
                    LocationId = 3, // Johannesburg Warehouse
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1579389083078-4e7018379f7e",
                    PurchaseDate = new DateTime(2024, 3, 15),
                    PurchasePrice = 14500.00m,
                    WarrantyExpiryDate = new DateTime(2026, 3, 15),
                    EnergyRating = "A+",
                    Dimensions = "185×75×75cm",
                    Weight = 90.0m,
                    Color = "Stainless Steel",
                    CreatedDate = new DateTime(2024, 3, 15),
                    ModifiedDate = new DateTime(2024, 6, 20)
                },
                new Fridge
                {
                    Id = 18,
                    Manufacturer = "Samsung",
                    SerialNumber = "SAM-SHEB-1818",
                    Model = "RB33T",
                    CapacityLiters = 330,
                    Type = "Double Door Commercial",
                    Description = "Commercial double door fridge with digital display and precise temperature control.",
                    RentalPricePerMonth = 1650.00m,
                    LastMaintenanceDate = new DateTime(2024, 4, 28),
                    LocationId = 4, // Cape Town Warehouse
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Allocated,
                    ImageUrl = "https://images.unsplash.com/photo-1598301257982-0cf01499abb2",
                    PurchaseDate = new DateTime(2023, 6, 10),
                    PurchasePrice = 13500.00m,
                    WarrantyExpiryDate = new DateTime(2025, 6, 10),
                    EnergyRating = "A+",
                    Dimensions = "180×70×70cm",
                    Weight = 87.0m,
                    Color = "Black",
                    CreatedDate = new DateTime(2023, 6, 10),
                    ModifiedDate = new DateTime(2024, 4, 28)
                },
                new Fridge
                {
                    Id = 19,
                    Manufacturer = "Defy",
                    SerialNumber = "DEFY-SPAZA-1919",
                    Model = "FFT250",
                    CapacityLiters = 250,
                    Type = "Top Mount Freezer",
                    Description = "Compact top mount freezer fridge for small spaza shop operations.",
                    RentalPricePerMonth = 1000.00m,
                    LastMaintenanceDate = new DateTime(2024, 7, 3),
                    LocationId = 2, // Gqeberha Warehouse
                    Condition = FridgeCondition.New,
                    Status = FridgeStatus.Available,
                    ImageUrl = "https://images.unsplash.com/photo-1595425970377-2f8ded7c7b19",
                    PurchaseDate = new DateTime(2024, 5, 20),
                    PurchasePrice = 8200.00m,
                    WarrantyExpiryDate = new DateTime(2026, 5, 20),
                    EnergyRating = "A",
                    Dimensions = "160×65×65cm",
                    Weight = 70.0m,
                    Color = "White",
                    CreatedDate = new DateTime(2024, 5, 20),
                    ModifiedDate = new DateTime(2024, 7, 3)
                },
                new Fridge
                {
                    Id = 20,
                    Manufacturer = "Hisense",
                    SerialNumber = "HIS-SHEB-2020",
                    Model = "QR828W",
                    CapacityLiters = 828,
                    Type = "Commercial Reach-In",
                    Description = "Extra large commercial reach-in fridge for high-volume shebeen operations.",
                    RentalPricePerMonth = 2600.00m,
                    LastMaintenanceDate = new DateTime(2024, 5, 15),
                    LocationId = 5, // Durban Service Center (Scrapped item)
                    Condition = FridgeCondition.PreOwned,
                    Status = FridgeStatus.Scrapped,
                    ImageUrl = "https://images.unsplash.com/photo-1598300042247-d088f8ab3a91",
                    PurchaseDate = new DateTime(2022, 10, 5),
                    PurchasePrice = 21000.00m,
                    WarrantyExpiryDate = new DateTime(2024, 10, 5),
                    EnergyRating = "B",
                    Dimensions = "210×95×90cm",
                    Weight = 125.0m,
                    Color = "Silver",
                    CreatedDate = new DateTime(2022, 10, 5),
                    ModifiedDate = new DateTime(2024, 5, 15)
                }
            );

            modelBuilder.Entity<PurchaseRequest>().HasData(
                // Request 1: Stock Controller requesting new fridges due to low stock
                new PurchaseRequest
                {
                    Id = 1,
                    RequestedById = 2, // Stock Controller (UserId 2 from prior seeding)
                    RequestDate = new DateTime(2025, 9, 15, 14, 30, 0, DateTimeKind.Utc), // Mid-September 2025
                    Status = PurchaseRequestStatus.Approved,
                    Reason = PurchaseRequestReason.LowStock,
                    Urgency = PurchaseRequestUrgency.High,
                    RequiredByDate = new DateTime(2025, 10, 1), // Needed by early October
                    EstimatedTotalCost = 24000.00m, // e.g., 2 fridges at ~12,000 each
                    CreatedAt = new DateTime(2025, 9, 15, 14, 30, 0, DateTimeKind.Utc)
                },
                // Request 2: Stock Controller requesting maintenance parts due to equipment failure
                new PurchaseRequest
                {
                    Id = 2,
                    RequestedById = 2, // Stock Controller (UserId 2)
                    RequestDate = new DateTime(2025, 8, 20, 9, 15, 0, DateTimeKind.Utc), // Late August 2025
                    Status = PurchaseRequestStatus.Draft,
                    Reason = PurchaseRequestReason.Replacement,
                    CustomReason = "Compressor failure in multiple units",
                    Urgency = PurchaseRequestUrgency.Normal,
                    RequiredByDate = new DateTime(2025, 9, 30), // Needed by end of September
                    EstimatedTotalCost = 5000.00m, // e.g., parts and labor
                    CreatedAt = new DateTime(2025, 8, 20, 9, 15, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}


