
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
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
        public DbSet<RequestHeader> RequestHeaders { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<FridgeFault> FaultRecords { get; set; }
        public DbSet<FridgeVisit> FridgeVisits { get; set; }
        public DbSet<MaintenanceVisit> MaintenanceVisits { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<FridgeRequest> ReplacementRequests { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //        {
            //            base.OnModelCreating(modelBuilder);
            //            // Seed Roles
            //            modelBuilder.Entity<IdentityRole>().HasData(
            //                new IdentityRole { Id = "1", Name = StaticDetails.AdminRole, NormalizedName = StaticDetails.AdminRole.ToUpper() },
            //                new IdentityRole { Id = "2", Name = StaticDetails.CustomerSupportRole, NormalizedName = StaticDetails.CustomerSupportRole.ToUpper() },
            //                new IdentityRole { Id = "3", Name = StaticDetails.StockControllerRole, NormalizedName = StaticDetails.StockControllerRole.ToUpper() },
            //                new IdentityRole { Id = "4", Name = StaticDetails.FaultTechnicianRole, NormalizedName = StaticDetails.FaultTechnicianRole.ToUpper() },
            //                new IdentityRole { Id = "5", Name = StaticDetails.MaintenanceTechnicianRole, NormalizedName = StaticDetails.MaintenanceTechnicianRole.ToUpper() },
            //                new IdentityRole { Id = "6", Name = StaticDetails.CustomerRole, NormalizedName = StaticDetails.CustomerRole.ToUpper() }
            //            );
            //            // Precompute password hashes (use the same password for all seeded users for simplicity)
            //            var user = new ApplicationUser();
            //            var hasher = new PasswordHasher<ApplicationUser>();
            //            var defaultPassword = "strongPassword#123"; // Change this to a secure value in production
            //            // Seed Users
            //            modelBuilder.Entity<ApplicationUser>().HasData(
            //                new ApplicationUser
            //                {
            //                    Id = "1",
            //                    UserName = "admin@smartchill.com",
            //                    FirstName = "Collins",
            //                    LastName = "Khosa",
            //                    Email = "admin@smartchill.com",
            //                    PhoneNumber = "+27 64 534 7790",
            //                    UserRole = StaticDetails.AdminRole,
            //                    NormalizedUserName = "ADMIN@SMARTCHILL.COM",
            //                    NormalizedEmail = "ADMIN@SMARTCHILL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString(),
            //                    AccessFailedCount = 0
            //                },
            //                new ApplicationUser
            //                {
            //                    Id = "2",
            //                    UserName = "customersupport@smartchill.com",
            //                    FirstName = "Andries",
            //                    LastName = "Tatane",
            //                    Email = "customersupport@smartchill.com",
            //                    PhoneNumber = "+27 71 073 7734",
            //                    UserRole = StaticDetails.CustomerSupportRole,
            //                    NormalizedUserName = "CUSTOMERSUPPORT@SMARTCHILL.COM",
            //                    NormalizedEmail = "CUSTOMERSUPPORT@SMARTCHILL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString()
            //                },
            //                new ApplicationUser
            //                {
            //                    Id = "3",
            //                    UserName = "stockcontroller@smartchill.com",
            //                    FirstName = "Mido",
            //                    LastName = "Macia",
            //                    Email = "stockcontroller@smartchill.com",
            //                    PhoneNumber = "+27 66 293 4430",
            //                    UserRole = StaticDetails.StockControllerRole,
            //                    NormalizedUserName = "STOCKCONTROLLER@SMARTCHILL.COM",
            //                    NormalizedEmail = "STOCKCONTROLLER@SMARTCHILL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString()
            //                },
            //                new ApplicationUser
            //                {
            //                    Id = "4",
            //                    UserName = "faulttechnician@smartchill.com",
            //                    FirstName = "Nathaniel",
            //                    LastName = "Julies",
            //                    Email = "faulttechnician@smartchill.com",
            //                    PhoneNumber = "+27 79 894 6438",
            //                    UserRole = StaticDetails.FaultTechnicianRole,
            //                    NormalizedUserName = "FAULTTECHNICIAN@SMARTCHILL.COM",
            //                    NormalizedEmail = "FAULTTECHNICIAN@SMARTCHILL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString()
            //                },
            //                new ApplicationUser
            //                {
            //                    Id = "5",
            //                    UserName = "maintenancetechnician@smartchill.com",
            //                    FirstName = "Latiefa",
            //                    LastName = "Freeman",
            //                    Email = "maintenancetechnician@smartchill.com",
            //                    PhoneNumber = "+27 61 483 6998",
            //                    UserRole = StaticDetails.MaintenanceTechnicianRole,
            //                    NormalizedUserName = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
            //                    NormalizedEmail = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString()
            //                },
            //                new ApplicationUser
            //                {
            //                    Id = "6",
            //                    UserName = "naterobertson@gmail.com",
            //                    FirstName = "Nathan",
            //                    LastName = "Robertson",
            //                    Email = "naterobertson@gmail.com",
            //                    PhoneNumber = "+27 69 174 5946",
            //                    UserRole = StaticDetails.CustomerRole,
            //                    NormalizedUserName = "NATEROBERTSON@GMAIL.COM",
            //                    NormalizedEmail = "NATEROBERTSON@GMAIL.COM",
            //                    EmailConfirmed = true,
            //                    PhoneNumberConfirmed = true,
            //                    PasswordHash = hasher.HashPassword(user, defaultPassword),
            //                    SecurityStamp = Guid.NewGuid().ToString()
            //                }
            //            );
            //            // Assign Roles to Users
            //            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
            //                new IdentityUserRole<string> { UserId = "2", RoleId = "2" },
            //                new IdentityUserRole<string> { UserId = "3", RoleId = "3" },
            //                new IdentityUserRole<string> { UserId = "4", RoleId = "4" },
            //                new IdentityUserRole<string> { UserId = "5", RoleId = "5" },
            //                new IdentityUserRole<string> { UserId = "6", RoleId = "6" }
            //            );
            //modelBuilder.Entity<Employee>()
            //                .HasDiscriminator<string>("EmployeeType")
            //                .HasValue<CustomerSupport>("CustomerSupport")
            //                .HasValue<StockController>("StockController")
            //                .HasValue<FaultTechnician>("FaultTechnician")
            //                .HasValue<MaintenanceTechnician>("MaintenanceTechnician"); // Just set column name

            //            modelBuilder.Entity<Employee>()
            //                .Property("EmployeeType")                // Configure discriminator column
            //                .HasMaxLength(21)
            //                .HasColumnType("nvarchar(21)")
            //                .IsRequired();

            //            // Customer Support
            //            modelBuilder.Entity<CustomerSupport>().HasData(
            //                new CustomerSupport
            //                {
            //                    Id = 1,
            //                    UserId = "2", // must match seeded ApplicationUser.Id
            //                    AvailabilityStatus = AvailabilityStatus.Available,
            //                    EmployeeNumber = "CS001",
            //                    CreatedAt = DateTime.UtcNow,
            //                    IsActive = true
            //                }
            //            );
            //            // Stock Controller
            //            modelBuilder.Entity<StockController>().HasData(
            //                new StockController
            //                {
            //                    Id = 2,
            //                    UserId = "3",
            //                    EmployeeNumber = "SC001",
            //                    AvailabilityStatus = AvailabilityStatus.OnDuty,
            //                    CreatedAt = DateTime.UtcNow,
            //                    IsActive = true
            //                }
            //            );
            //            // Fault Technician
            //            modelBuilder.Entity<FaultTechnician>().HasData(
            //                new FaultTechnician
            //                {
            //                    Id = 3,
            //                    UserId = "4",
            //                    EmployeeNumber = "FT001",
            //                    AvailabilityStatus = AvailabilityStatus.Available,
            //                    CreatedAt = DateTime.UtcNow,
            //                    IsActive = true
            //                }
            //            );
            //            // Maintenance Technician
            //            modelBuilder.Entity<MaintenanceTechnician>().HasData(
            //                new MaintenanceTechnician
            //                {
            //                    Id = 4,
            //                    UserId = "5",
            //                    EmployeeNumber = "MT001",
            //                    AvailabilityStatus = AvailabilityStatus.Available,
            //                    CreatedAt = DateTime.UtcNow,
            //                    IsActive = true
            //                }
            //            );
            //            //Customer
            //            modelBuilder.Entity<Customer>().HasData(
            //                new Customer
            //                {
            //                    Id = 1,
            //                    UserId = "6", // FK to ApplicationUser
            //                    CustomerLiaisonId = 1,      // FK to CustomerSupport
            //                    TradingName = "Boerewors Palace",
            //                    BusinessType = BusinessType.SmallRetail,
            //                    BusinessRegistrationNumber = "REG-1977-001",
            //                    VATNumber = "VAT-650603",
            //                    BusinessEmail = "info@boereworspalace.co.za",
            //                    BusinessPhoneNumber = "+27 11 555 0101",
            //                    DeliveryAddressId = 1,      // FK to Location
            //                    CreatedAt = DateTime.UtcNow,
            //                    IsActive = true
            //                }
            //                );


            modelBuilder.Entity<Fridge>().HasData(

            new Fridge
            {
                Id = 1,
                Manufacturer = "Samsung",
                SerialNumber = "FRG-001",
                Model = "RT28T",
                CapacityLiters = 253,
                Type = "Double Door",
                Description = "Energy-efficient double door fridge with frost-free technology.",
                RentalPricePerMonth = 1200.00m,
                LastMaintenanceDate = new DateTime(2025, 1, 15),
                Condition = FridgeCondition.New,
                ImageUrl = "https://example.com/images/fridge1.jpg",
                Status = FridgeStatus.Available,
                Location = "Available"
            },
                new Fridge
                {
                    Id = 2,
                    Manufacturer = "LG",
                    SerialNumber = "FRG-002",
                    Model = "GL-B201",
                    CapacityLiters = 190,
                    Type = "Single Door",
                    Description = "Compact single door fridge ideal for small apartments.",
                    RentalPricePerMonth = 900.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 10),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge2.jpg",
                    Status = FridgeStatus.Allocated,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 3,
                    Manufacturer = "Whirlpool",
                    SerialNumber = "FRG-003",
                    Model = "WRT518",
                    CapacityLiters = 500,
                    Type = "Double Door",
                    Description = "Spacious fridge with advanced cooling technology.",
                    RentalPricePerMonth = 1500.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 5),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge3.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 4,
                    Manufacturer = "Defy",
                    SerialNumber = "FRG-004",
                    Model = "DAC700",
                    CapacityLiters = 350,
                    Type = "Double Door",
                    Description = "Durable fridge with energy-saving features.",
                    RentalPricePerMonth = 1100.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 1),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge4.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 5,
                    Manufacturer = "Hisense",
                    SerialNumber = "FRG-005",
                    Model = "H310BI",
                    CapacityLiters = 310,
                    Type = "Single Door",
                    Description = "Compact fridge with adjustable shelves.",
                    RentalPricePerMonth = 800.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 20),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge5.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 6,
                    Manufacturer = "Bosch",
                    SerialNumber = "FRG-006",
                    Model = "KDN42",
                    CapacityLiters = 420,
                    Type = "Double Door",
                    Description = "Premium fridge with no-frost technology.",
                    RentalPricePerMonth = 1600.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 15),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge6.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 7,
                    Manufacturer = "Kelvinator",
                    SerialNumber = "FRG-007",
                    Model = "KEL250",
                    CapacityLiters = 250,
                    Type = "Single Door",
                    Description = "Affordable fridge with basic features.",
                    RentalPricePerMonth = 700.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 25),
                    Condition = FridgeCondition.NeedsService,
                    ImageUrl = "https://example.com/images/fridge7.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 8,
                    Manufacturer = "Smeg",
                    SerialNumber = "FRG-008",
                    Model = "FAB28",
                    CapacityLiters = 281,
                    Type = "Single Door",
                    Description = "Retro-style fridge with modern cooling.",
                    RentalPricePerMonth = 2000.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 5),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge8.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 9,
                    Manufacturer = "AEG",
                    SerialNumber = "FRG-009",
                    Model = "SKE818",
                    CapacityLiters = 300,
                    Type = "Single Door",
                    Description = "Built-in fridge with adjustable compartments.",
                    RentalPricePerMonth = 1800.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 1),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge9.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 10,
                    Manufacturer = "Panasonic",
                    SerialNumber = "FRG-010",
                    Model = "NR-BL347",
                    CapacityLiters = 347,
                    Type = "Double Door",
                    Description = "Fridge with inverter technology for energy saving.",
                    RentalPricePerMonth = 1300.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 10),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge10.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 11,
                    Manufacturer = "Haier",
                    SerialNumber = "FRG-011",
                    Model = "HRF-619",
                    CapacityLiters = 565,
                    Type = "Side by Side",
                    Description = "Large capacity fridge with twin inverter technology.",
                    RentalPricePerMonth = 2200.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 5),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge11.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 12,
                    Manufacturer = "Hitachi",
                    SerialNumber = "FRG-012",
                    Model = "R-WB640",
                    CapacityLiters = 640,
                    Type = "French Door",
                    Description = "Premium French door fridge with eco-friendly features.",
                    RentalPricePerMonth = 2500.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 20),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge12.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 13,
                    Manufacturer = "Electrolux",
                    SerialNumber = "FRG-013",
                    Model = "ETB3700",
                    CapacityLiters = 370,
                    Type = "Top Freezer",
                    Description = "Fridge with taste guard deodorizer.",
                    RentalPricePerMonth = 1400.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 2),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge13.jpg",
                    Status = FridgeStatus.Allocated,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 14,
                    Manufacturer = "Sharp",
                    SerialNumber = "FRG-014",
                    Model = "SJ-GX60",
                    CapacityLiters = 600,
                    Type = "French Door",
                    Description = "Fridge with plasmacluster ion technology.",
                    RentalPricePerMonth = 2300.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 18),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge14.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 15,
                    Manufacturer = "Midea",
                    SerialNumber = "FRG-015",
                    Model = "HD-400",
                    CapacityLiters = 400,
                    Type = "Double Door",
                    Description = "Affordable fridge with large freezer compartment.",
                    RentalPricePerMonth = 1000.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 28),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge15.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 16,
                    Manufacturer = "Gorenje",
                    SerialNumber = "FRG-016",
                    Model = "NRK6192",
                    CapacityLiters = 326,
                    Type = "Bottom Freezer",
                    Description = "Stylish bottom freezer fridge with crisp zone for vegetables.",
                    RentalPricePerMonth = 1250.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 8),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge16.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 17,
                    Manufacturer = "Westinghouse",
                    SerialNumber = "FRG-017",
                    Model = "WBE5300",
                    CapacityLiters = 528,
                    Type = "Top Freezer",
                    Description = "Family-sized fridge with humidity-controlled crisper.",
                    RentalPricePerMonth = 1700.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 12),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge17.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 18,
                    Manufacturer = "Fisher & Paykel",
                    SerialNumber = "FRG-018",
                    Model = "RF522",
                    CapacityLiters = 519,
                    Type = "French Door",
                    Description = "Premium French door fridge with active smart technology.",
                    RentalPricePerMonth = 2400.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 7),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge18.jpg",
                    Status = FridgeStatus.Allocated,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 19,
                    Manufacturer = "Ariston",
                    SerialNumber = "FRG-019",
                    Model = "MBA3832",
                    CapacityLiters = 383,
                    Type = "Top Freezer",
                    Description = "Reliable fridge with antibacterial coating.",
                    RentalPricePerMonth = 1150.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 30),
                    Condition = FridgeCondition.PreOwned,
                    ImageUrl = "https://example.com/images/fridge19.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                },
                new Fridge
                {
                    Id = 20,
                    Manufacturer = "Beko",
                    SerialNumber = "FRG-020",
                    Model = "RCNE560",
                    CapacityLiters = 560,
                    Type = "Bottom Freezer",
                    Description = "Spacious bottom freezer fridge with NeoFrost cooling.",
                    RentalPricePerMonth = 1850.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 22),
                    Condition = FridgeCondition.New,
                    ImageUrl = "https://example.com/images/fridge20.jpg",
                    Status = FridgeStatus.Available,
                    Location = "Available"
                }
            ) ;
        }
    }
}

