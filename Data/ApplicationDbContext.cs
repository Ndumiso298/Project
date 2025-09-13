using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.FridgeManagementSystem.Models;
using Project.Utility;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CustomerSupport> CustomerLiaisons { get; set; }
        public DbSet<StockController> StockControllers { get; set; }
        public DbSet<FaultTechnician> FaultTechnicians { get; set; }
        public DbSet<MaintenanceTechnician> MaintenanceTechnicians { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeAllocation> FridgeAllocations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FridgeFault> FaultRecords { get; set; }
        public DbSet<FridgeMaintenance> MaintenanceRecords { get; set; }
        public DbSet<FridgeRequest> FridgeRequests { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = StaticDetails.AdminRole, NormalizedName = StaticDetails.AdminRole.ToUpper() },
                new IdentityRole { Id = "2", Name = StaticDetails.CustomerSupportRole, NormalizedName = StaticDetails.CustomerSupportRole.ToUpper() },
                new IdentityRole { Id = "3", Name = StaticDetails.StockControllerRole, NormalizedName = StaticDetails.StockControllerRole.ToUpper() },
                new IdentityRole { Id = "4", Name = StaticDetails.FaultTechnicianRole, NormalizedName = StaticDetails.FaultTechnicianRole.ToUpper() },
                new IdentityRole { Id = "5", Name = StaticDetails.MaintenanceTechnicianRole, NormalizedName = StaticDetails.MaintenanceTechnicianRole.ToUpper() },
                new IdentityRole { Id = "6", Name = StaticDetails.CustomerRole, NormalizedName = StaticDetails.CustomerRole.ToUpper() }
            );
            // Precompute password hashes (use the same password for all seeded users for simplicity)
            var hasher = new PasswordHasher<ApplicationUser>();
            var defaultPassword = "strongPassword#123"; // Change this to a secure value in production
            // Seed Users
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin@smartchill.com",
                    FirstName = "Collins",
                    LastName = "Khosa",
                    Email = "admin@smartchill.com",
                    PhoneNumber = "+27 64 534 7790",
                    UserRole = StaticDetails.AdminRole,
                    NormalizedUserName = "ADMIN@SMARTCHILL.COM",
                    NormalizedEmail = "ADMIN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "customersupport@smartchill.com",
                    FirstName = "Andries",
                    LastName = "Tatane",
                    Email = "customersupport@smartchill.com",
                    PhoneNumber = "+27 71 073 7734",
                    UserRole = StaticDetails.CustomerSupportRole,
                    NormalizedUserName = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    NormalizedEmail = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "stockcontroller@smartchill.com",
                    FirstName = "Mido",
                    LastName = "Macia",
                    Email = "stockcontroller@smartchill.com",
                    PhoneNumber = "+27 66 293 4430",
                    UserRole = StaticDetails.StockControllerRole,
                    NormalizedUserName = "STOCKCONTROLLER@SMARTCHILL.COM",
                    NormalizedEmail = "STOCKCONTROLLER@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "faulttechnician@smartchill.com",
                    FirstName = "Nathaniel",
                    LastName = "Julies",
                    Email = "faulttechnician@smartchill.com",
                    PhoneNumber = "+27 79 894 6438",
                    UserRole = StaticDetails.FaultTechnicianRole,
                    NormalizedUserName = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    NormalizedEmail = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "5",
                    UserName = "maintenancetechnician@smartchill.com",
                    FirstName = "Latiefa",
                    LastName = "Freeman",
                    Email = "maintenancetechnician@smartchill.com",
                    PhoneNumber = "+27 61 483 6998",
                    UserRole = StaticDetails.MaintenanceTechnicianRole,
                    NormalizedUserName = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    NormalizedEmail = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "6",
                    UserName = "naterobertson@gmail.com",
                    FirstName = "Nathan",
                    LastName = "Robertson",
                    Email = "naterobertson@gmail.com",
                    PhoneNumber = "+27 69 174 5946",
                    UserRole = StaticDetails.CustomerRole,
                    NormalizedUserName = "NATEROBERTSON@GMAIL.COM",
                    NormalizedEmail = "NATEROBERTSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
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
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "South Africa", Code = "ZA" }
            );
            // Seed Provinces
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, CountryId = 1, Name = "Gauteng", Code = "GP" },
                new Province { Id = 2, CountryId = 1, Name = "Western Cape", Code = "WC" },
                new Province { Id = 3, CountryId = 1, Name = "KwaZulu-Natal", Code = "KZN" },
                new Province { Id = 4, CountryId = 1, Name = "Eastern Cape", Code = "EC" },
                new Province { Id = 5, CountryId = 1, Name = "Free State", Code = "FS", },
                new Province { Id = 6, CountryId = 1, Name = "Limpopo", Code = "LP" },
                new Province { Id = 7, CountryId = 1, Name = "Mpumalanga", Code = "MP" },
                new Province { Id = 8, CountryId = 1, Name = "North West", Code = "NW" },
                new Province { Id = 9, CountryId = 1, Name = "Northern Cape", Code = "NC" }
            );
            // Seed Cities
            // Seed Cities – at least 10 major South African cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Johannesburg", ProvinceId = 1 },       // Gauteng
                new City { Id = 2, Name = "Cape Town", ProvinceId = 2 },          // Western Cape
                new City { Id = 3, Name = "Durban", ProvinceId = 3 },             // KwaZulu-Natal
                new City { Id = 4, Name = "Gqeberha", ProvinceId = 4 },           // Eastern Cape (formerly Port Elizabeth)
                new City { Id = 5, Name = "Soweto", ProvinceId = 1 },             // Gauteng
                new City { Id = 6, Name = "Bloemfontein", ProvinceId = 5 },       // Free State
                new City { Id = 7, Name = "Polokwane", ProvinceId = 6 },          // Limpopo
                new City { Id = 8, Name = "Mbombela", ProvinceId = 7 },           // Mpumalanga (formerly Nelspruit)
                new City { Id = 9, Name = "Mahikeng", ProvinceId = 8 },           // North West
                new City { Id = 10, Name = "Kimberley", ProvinceId = 9 }          // Northern Cape
            );
            // Seed Suburbs
            modelBuilder.Entity<Suburb>().HasData(
                // Johannesburg (CityId = 1)
                new Suburb { Id = 1, Name = "Sandton", CityId = 1, PostalCode = "2196" },
                new Suburb { Id = 2, Name = "Parkhurst", CityId = 1, PostalCode = "2193" },

                // Cape Town (CityId = 2)
                new Suburb { Id = 3, Name = "Sea Point", CityId = 2, PostalCode = "8060" },
                new Suburb { Id = 4, Name = "Claremont", CityId = 2, PostalCode = "7735" },

                // Durban (CityId = 3)
                new Suburb { Id = 5, Name = "Berea", CityId = 3, PostalCode = "4001" },
                new Suburb { Id = 8, Name = "Umhlanga", CityId = 3, PostalCode = "4319" },

                // Gqeberha (CityId = 4)
                new Suburb { Id = 6, Name = "Summerstrand", CityId = 4, PostalCode = "6001" },

                // Soweto (CityId = 5)
                new Suburb { Id = 7, Name = "Orlando East", CityId = 5, PostalCode = "1804" },

                // Bloemfontein (CityId = 6)
                new Suburb { Id = 9, Name = "Fichardt Park", CityId = 6, PostalCode = "9301" },

                // Polokwane (CityId = 7)
                new Suburb { Id = 10, Name = "Flora Park", CityId = 7, PostalCode = "0699" }
            );
            // Seed Locations – linked to existing Suburb IDs
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    AddressLine1 = "123 Vilakazi Street",
                    AddressLine2 = "Orlando West",
                    SuburbId = 7, // Orlando East (Soweto, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 2,
                    AddressLine1 = "45 Victoria Road",
                    AddressLine2 = "Victoria and Alfred Waterfront",
                    SuburbId = 3, // Sea Point (Cape Town, Western Cape)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 3,
                    AddressLine1 = "78 Steve Biko Road",
                    AddressLine2 = "Berea Centre",
                    SuburbId = 5, // Berea (Durban, KZN)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 4,
                    AddressLine1 = "12 Main Road",
                    AddressLine2 = "Sandton City",
                    SuburbId = 1, // Sandton (Johannesburg, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 5,
                    AddressLine1 = "8 4th Avenue",
                    AddressLine2 = "Parkhurst Village",
                    SuburbId = 2, // Parkhurst (Johannesburg, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 6,
                    AddressLine1 = "101 Beach Road",
                    AddressLine2 = "Beachfront Plaza",
                    SuburbId = 4, // Claremont (Cape Town, Western Cape)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 7,
                    AddressLine1 = "22 Marine Drive",
                    AddressLine2 = "Umhlanga Rocks",
                    SuburbId = 8, // Umhlanga (Durban, KZN)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 8,
                    AddressLine1 = "5 University Way",
                    AddressLine2 = "Campus Square",
                    SuburbId = 6, // Summerstrand (Gqeberha, Eastern Cape)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 9,
                    AddressLine1 = "14 Paul Kruger Avenue",
                    AddressLine2 = "Fichardt Park Mall",
                    SuburbId = 9, // Fichardt Park (Bloemfontein, Free State)
                    CreatedAt = DateTime.UtcNow
                },
                new Location
                {
                    Id = 10,
                    AddressLine1 = "77 Marshall Street",
                    AddressLine2 = "Flora Park Centre",
                    SuburbId = 10, // Flora Park (Polokwane, Limpopo)
                    CreatedAt = DateTime.UtcNow
                }
            );
            // Customer Support
            modelBuilder.Entity<CustomerSupport>().HasData(
                new CustomerSupport
                {
                    Id = 1,
                    UserId = "2", // must match seeded ApplicationUser.Id
                    EmployeeNumber = "CS001",
                    EmployeeType = StaticDetails.CustomerSupportRole,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );
            // Stock Controller
            modelBuilder.Entity<StockController>().HasData(
                new StockController
                {
                    Id = 2,
                    UserId = "3",
                    EmployeeNumber = "SC001",
                    EmployeeType = StaticDetails.StockControllerRole,
                    AvailabilityStatus = "On-site",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );
            // Fault Technician
            modelBuilder.Entity<FaultTechnician>().HasData(
                new FaultTechnician
                {
                    Id = 3,
                    UserId = "4",
                    EmployeeNumber = "FT001",
                    EmployeeType = StaticDetails.FaultTechnicianRole,
                    AvailabilityStatus = "Available",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );
            // Maintenance Technician
            modelBuilder.Entity<MaintenanceTechnician>().HasData(
                new MaintenanceTechnician
                {
                    Id = 4,
                    UserId = "5",
                    EmployeeNumber = "MT001",
                    EmployeeType = StaticDetails.MaintenanceTechnicianRole,
                    AvailabilityStatus = "Available",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );
            //Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    UserId = "6", // FK to ApplicationUser
                    CustomerLiaisonId = 1,      // FK to CustomerSupport
                    BusinessName = "Boerewors Palace",
                    BusinessType = "Shebeen",
                    BusinessRegistrationNumber = "REG-1977-001",
                    VATNumber = "VAT-650603",
                    BusinessEmail = "info@boereworspalace.co.za",
                    BusinessPhoneNumber = "+27 11 555 0101",
                    BusinessAddressId = 1,      // FK to Location
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
                );
            modelBuilder.Entity<Fridge>().HasData(
                new Fridge
                {
                    Id = 1,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-001",
                    Manufacturer = "Defy",
                    Model = "DCR520 Commercial Beverage Cooler",
                    CapacityLiters = 520,
                    EnergyRating = "B",
                    Condition = "Used - Good",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-18),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(6),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/beverage-cooler-886lt-double-door-sliding.jpg"
                },
                new Fridge
                {
                    Id = 2,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-002",
                    Manufacturer = "LG",
                    Model = "LC-321CV Glass Door Merchandiser",
                    CapacityLiters = 780,
                    EnergyRating = "A",
                    Condition = "New",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-3),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(33),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/single-glass-door-freezer-carbon-edition-.jpg"
                },
                new Fridge
                {
                    Id = 3,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-003",
                    Manufacturer = "Hisense",
                    Model = "HC-702D Commercial Display Freezer",
                    CapacityLiters = 702,
                    EnergyRating = "A+",
                    Condition = "Used - Excellent",
                    Status = "Allocated",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-2),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(34),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/beverage-cooler-730l-2-door-swing-door-.jpg"
                },
                new Fridge
                {
                    Id = 4,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-004",
                    Manufacturer = "Samsung",
                    Model = "RR-500M Commercial Series Freezer",
                    CapacityLiters = 500,
                    EnergyRating = "A+",
                    Condition = "Needs Repair",
                    Status = "Needs Repair",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-24),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(-6),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/za-t-style-french-door-see-thru-door-rf71db975012fa-543388220.avif"
                },
                new Fridge
                {
                    Id = 5,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-005",
                    Manufacturer = "Kelvinator",
                    Model = "KCR-680GL Glass Door Beverage Cooler",
                    CapacityLiters = 680,
                    EnergyRating = "B",
                    Condition = "Used - Fair",
                    Status = "In Service",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-36),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(-18),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/single-glass-door-freezer-carbon-edition-.jpg"
                },
                new Fridge
                {
                    Id = 6,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-006",
                    Manufacturer = "Smeg",
                    Model = "FAB60RCR Retro Commercial Fridge",
                    CapacityLiters = 600,
                    EnergyRating = "A",
                    Condition = "Refurbished",
                    Status = "Allocated",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-4),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(32),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/za-rs90f-f-hub-rs90f64a2ffa-545559499.avif"
                },
                new Fridge
                {
                    Id = 7,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-007",
                    Manufacturer = "Bosch",
                    Model = "GIC08A15 Commercial UnderCounter Freezer",
                    CapacityLiters = 280,
                    EnergyRating = "A++",
                    Condition = "New",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-7),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(29),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/display-unit-fridge-salvadore-csunk-azelio-1200mm-.jpg"
                },
                new Fridge
                {
                    Id = 8,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-008",
                    Manufacturer = "Whirlpool",
                    Model = "WIO429IY Commercial Ice Maker & Beverage Cooler",
                    CapacityLiters = 429,
                    EnergyRating = "A",
                    Condition = "Used - Excellent",
                    Status = "In Service",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-12),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(24),
                    ImageUrl = "Images/Fridges/juice-dispenser-3-bowl.jpg"
                },
                new Fridge
                {
                    Id = 9,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-009",
                    Manufacturer = "AEG",
                    Model = "RCB836E4MW Commercial Multi-Door Freezer",
                    CapacityLiters = 836,
                    EnergyRating = "A+",
                    Condition = "Used - Good",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-1),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(35),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/wall-chiller-35m-single-glaze-unit.jpg"
                },
                new Fridge
                {
                    Id = 10,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-010",
                    Manufacturer = "Siemens",
                    Model = "KI92RA70 Commercial FrostFree Freezer",
                    CapacityLiters = 920,
                    EnergyRating = "A++",
                    Condition = "New",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-5),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(31),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/double-glass-door-freezer-carbon-edition-.jpg"
                },
                new Fridge
                {
                    Id = 11,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-011",
                    Manufacturer = "Defy",
                    Model = "DTD492 Commercial Top Mount Freezer",
                    CapacityLiters = 492,
                    EnergyRating = "C",
                    Condition = "Faulty",
                    Status = "Decommissioned",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-72),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(-48),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/za-4-door-french-door-beverage-center-rf29bb8600mtfa-533983040.avif"
                },
                new Fridge
                {
                    Id = 12,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-012",
                    Manufacturer = "LG",
                    Model = "GL-D552CRL Commercial Drawer Freezer",
                    CapacityLiters = 552,
                    EnergyRating = "A+",
                    Condition = "Used - Good",
                    Status = "Needs Repair",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-9),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(27),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/wall-chiller-35m-single-glaze-unit.jpg"
                },
                new Fridge
                {
                    Id = 13,
                    StockControllerId = 2,
                    SerialNumber = "FRG-2023-013",
                    Manufacturer = "Hisense",
                    Model = "HR-790D4 Commercial Reach-In Freezer",
                    CapacityLiters = 790,
                    EnergyRating = "A",
                    Condition = "Used - Excellent",
                    Status = "In Stock",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-6),
                    WarrantyExpiryDate = DateTime.UtcNow.AddMonths(30),
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = "Images/Fridges/upright-freezer-double-solid-ssteel-hinged-door-shd1140f.jpg"
                }
            );
            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart
                {
                    Id = 1, // Unique ID
                    FridgeId = 1, // Reference to the Defy DCR520 Commercial Beverage Cooler
                    CustomerId = 1, // Nathan Robertson's user ID
                    Quantity = 4,
                    Price = 15399.99m
                });
            modelBuilder.Entity<FridgeAllocation>().HasData(
                new FridgeAllocation
                {
                    Id = 1,
                    FridgeId = 3,
                    CustomerId = 1,
                    CustomerLiaisonId = 1,
                    Status = "Active",
                    AllocationDate = DateTime.UtcNow.AddMonths(-1),
                    ExpectedReturnDate = DateTime.UtcNow.AddMonths(11),
                    ServiceIntervalMonths = 3,
                    LastServiceDate = DateTime.UtcNow.AddMonths(-1),
                    NextServiceDue = DateTime.UtcNow.AddMonths(2),
                    Notes = "High-usage establishment, requires more frequent servicing",
                    CreatedAt = DateTime.UtcNow.AddMonths(-1),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-1),
                    IsDeleted = false
                },
                // Pending allocation (awaiting approval)
                new FridgeAllocation
                {
                    Id = 2,
                    FridgeId = 10,
                    CustomerId = 1,
                    CustomerLiaisonId = 1,
                    Status = "Pending",
                    Notes = "New customer application under review",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
                );
            modelBuilder.Entity<OrderHeader>().HasData(
                new OrderHeader
                {
                Id = 1,
                CustomerId = 1, // Reference to Customer Id
                OrderDate = DateTime.UtcNow.AddDays(-7),
                ShippingDate = DateTime.UtcNow.AddDays(-5),
                OrderTotal = 16999.99m, // Sum of order details
                OrderStatus = "Completed",
                PaymentStatus = "Paid",
                TrackingNumber = "TRK123456789",
                Carrier = "Fastway Couriers",
                PaymentDate = DateTime.UtcNow.AddDays(-6),
                PaymentDueDate = DateTime.UtcNow.AddDays(-1),
                DeliveryAddressId = 1, // FK to Location
                RecipientFirstName = "Nathan",
                RecipientLastName = "Robertson",
                }
                );
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = 1,
                    OrderHeaderId = 1, // Reference to OrderHeader
                    FridgeId = 1, // Defy DCR520 Commercial Beverage Cooler
                    Quantity = 4,
                    Price = 15399.99m
                });
            modelBuilder.Entity<FridgeFault>().HasData(
               new FridgeFault
               {
                   Id = 1,
                   FridgeAllocationId = 1,
                   FaultTechnicianId = 3,
                   ReportedById = "6",
                   Status = "InProgress",
                   Priority = "High",
                   Description = "Fridge not cooling properly - temperature reading shows 15°C when set to 4°C",
                   Diagnosis = "Preliminary diagnosis suggests possible compressor issue or refrigerant leak",
                   ReportedDate = DateTime.UtcNow.AddDays(-3),
                   AssignedDate = DateTime.UtcNow.AddDays(-2),
                   ResolutionNotes = "Technician dispatched for on-site inspection. Parts may need ordering.",
                   CreatedAt = DateTime.UtcNow.AddDays(-3),
                   UpdatedAt = DateTime.UtcNow.AddDays(-1),
                   IsDeleted = false
               }
               );
            modelBuilder.Entity<FridgeMaintenance>().HasData(
                new FridgeMaintenance
                {
                    Id = 1,
                    FridgeAllocationId = 1,
                    MaintenanceTechnicianId = 4,
                    Description = "Routine preventive maintenance service",
                    ScheduledDate = DateTime.UtcNow.AddDays(-7),
                    Status = "Completed",
                    CustomerConfirmationDate = DateTime.UtcNow.AddDays(-6),
                    CompletedDate = DateTime.UtcNow.AddDays(-5),
                    ServiceNotes = "Performed comprehensive maintenance: cleaned condenser coils, checked refrigerant levels, calibrated thermostat, inspected door seals, and lubricated moving parts. Fridge is operating at optimal efficiency.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                    IsDeleted = false
                }
            );
            modelBuilder.Entity<PurchaseRequest>().HasData(
                new PurchaseRequest
                {
                    Id = 1,
                    FridgeId = 5,
                    StockControllerId = 2, // StockController employee linked to ApplicationUser.Id = "3"
                    Quantity = 24,
                    Reason = "Increase stock levels for upcoming summer beverage promotions in Gauteng region.",
                    RequestDate = DateTime.UtcNow.AddDays(-3), // Requested 3 days ago
                    Status = "Pending",
                    ProcessedDate = null,
                    ProcessingNotes = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    IsDeleted = false
                }
            );
        }
    }
}



