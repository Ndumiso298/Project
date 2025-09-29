
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
        public DbSet<FridgeModel> FridgeModels { get; set; }
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

            var hasher = new PasswordHasher<ApplicationUser>();
            const string defaultPassword = "strongPassword#123";
            var seedDate = new DateTime(2025, 2, 14, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin@smartchill.com",
                    NormalizedUserName = "ADMIN@SMARTCHILL.COM",
                    Email = "admin@smartchill.com",
                    NormalizedEmail = "ADMIN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27645347790",
                    PhoneNumberConfirmed = true,
                    FirstName = "Collins",
                    LastName = "Khosa",
                    UserRole = SD.AdminRole,
                    EmployeeId = 1,
                    LocationId = 6, // Potchefstroom location
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "1b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "1b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "customersupport@smartchill.com",
                    NormalizedUserName = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    Email = "customersupport@smartchill.com",
                    NormalizedEmail = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27710737734",
                    PhoneNumberConfirmed = true,
                    FirstName = "Andries",
                    LastName = "Tatane",
                    UserRole = SD.CustomerSupportRole,
                    EmployeeId = 2,
                    LocationId = 10, // Kimberley location
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "2b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "2b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "stockcontroller@smartchill.com",
                    NormalizedUserName = "STOCKCONTROLLER@SMARTCHILL.COM",
                    Email = "stockcontroller@smartchill.com",
                    NormalizedEmail = "STOCKCONTROLLER@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27662934430",
                    PhoneNumberConfirmed = true,
                    FirstName = "Mido",
                    LastName = "Macia",
                    UserRole = SD.StockControllerRole,
                    EmployeeId = 3,
                    LocationId = 2, // East London location
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "3b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "3b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "faulttechnician@smartchill.com",
                    NormalizedUserName = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    Email = "faulttechnician@smartchill.com",
                    NormalizedEmail = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27798946438",
                    PhoneNumberConfirmed = true,
                    FirstName = "Nathaniel",
                    LastName = "Julies",
                    UserRole = SD.FaultTechnicianRole,
                    EmployeeId = 4,
                    LocationId = 5, // Durban location
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "4b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "4b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "5",
                    UserName = "maintenancetechnician@smartchill.com",
                    NormalizedUserName = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    Email = "maintenancetechnician@smartchill.com",
                    NormalizedEmail = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27614836998",
                    PhoneNumberConfirmed = true,
                    FirstName = "Latiefa",
                    LastName = "Freeman",
                    UserRole = SD.MaintenanceTechnicianRole,
                    EmployeeId = 5,
                    LocationId = 5, // Durban location (same as fault technician)
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "5b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "5b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "6",
                    UserName = "naterobertson@gmail.com",
                    NormalizedUserName = "NATEROBERTSON@GMAIL.COM",
                    Email = "naterobertson@gmail.com",
                    NormalizedEmail = "NATEROBERTSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27691745946",
                    PhoneNumberConfirmed = true,
                    FirstName = "Nathan",
                    LastName = "Robertson",
                    UserRole = SD.CustomerRole,
                    CustomerId = 1, // Boerewors Palace customer
                    LocationId = 1, // Paarl location (Boerewors Palace)
                    AccountStatus = AccountStatus.Active,
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "6b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    ConcurrencyStamp = "6b4b0b6a-0a3a-4a2a-8a1a-5a5a5a5a5a5a",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                }
            );

            // Seed Identity Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "admin_role_id",
                    Name = SD.AdminRole,
                    NormalizedName = SD.AdminRole.ToUpper(),
                    ConcurrencyStamp = "admin_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "customer_support_role_id",
                    Name = SD.CustomerSupportRole,
                    NormalizedName = SD.CustomerSupportRole.ToUpper(),
                    ConcurrencyStamp = "customer_support_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "stock_controller_role_id",
                    Name = SD.StockControllerRole,
                    NormalizedName = SD.StockControllerRole.ToUpper(),
                    ConcurrencyStamp = "stock_controller_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "fault_technician_role_id",
                    Name = SD.FaultTechnicianRole,
                    NormalizedName = SD.FaultTechnicianRole.ToUpper(),
                    ConcurrencyStamp = "fault_technician_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "maintenance_technician_role_id",
                    Name = SD.MaintenanceTechnicianRole,
                    NormalizedName = SD.MaintenanceTechnicianRole.ToUpper(),
                    ConcurrencyStamp = "maintenance_technician_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "customer_role_id",
                    Name = SD.CustomerRole,
                    NormalizedName = SD.CustomerRole.ToUpper(),
                    ConcurrencyStamp = "customer_concurrency_stamp"
                }
            );

            // Seed User Roles (AspNetUserRoles)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "admin_role_id" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "customer_support_role_id" },
                new IdentityUserRole<string> { UserId = "3", RoleId = "stock_controller_role_id" },
                new IdentityUserRole<string> { UserId = "4", RoleId = "fault_technician_role_id" },
                new IdentityUserRole<string> { UserId = "5", RoleId = "maintenance_technician_role_id" },
                new IdentityUserRole<string> { UserId = "6", RoleId = "customer_role_id" }
            );

            modelBuilder.Entity<Employee>()
    .HasDiscriminator<string>("EmployeeType");

            modelBuilder.Entity<Employee>()
                .Property("EmployeeType")                // Configure discriminator column
                .HasMaxLength(21)
                .HasColumnType("nvarchar(21)")
                .IsRequired();

            // In your ApplicationDbContext OnModelCreating method
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    UserId = "1", // Collins Khosa - Administrator
                    EmployeeNumber = "EMP00001",
                    EmployeeType = EmployeeType.Administrator,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    EmploymentType = EmploymentType.FullTime,
                    WorkPhone = "+27645347790",
                    WorkEmail = "admin@smartchill.com",
                    WorkLocationId = 6, // Potchefstroom
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                },
                new Employee
                {
                    Id = 2,
                    UserId = "2", // Andries Tatane - Customer Support
                    EmployeeNumber = "EMP00002",
                    EmployeeType = EmployeeType.CustomerSupport,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    EmploymentType = EmploymentType.FullTime,
                    WorkPhone = "+27710737734",
                    WorkEmail = "customersupport@smartchill.com",
                    WorkLocationId = 10, // Kimberley
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                },
                new Employee
                {
                    Id = 3,
                    UserId = "3", // Mido Macia - Stock Controller
                    EmployeeNumber = "EMP00003",
                    EmployeeType = EmployeeType.StockController,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    EmploymentType = EmploymentType.FullTime,
                    WorkPhone = "+27662934430",
                    WorkEmail = "stockcontroller@smartchill.com",
                    WorkLocationId = 2, // East London
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                },
                new Employee
                {
                    Id = 4,
                    UserId = "4", // Nathaniel Julies - Fault Technician
                    EmployeeNumber = "EMP00004",
                    EmployeeType = EmployeeType.FaultTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    EmploymentType = EmploymentType.FullTime,
                    WorkPhone = "+27798946438",
                    WorkEmail = "faulttechnician@smartchill.com",
                    WorkLocationId = 5, // Durban
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                },
                new Employee
                {
                    Id = 5,
                    UserId = "5", // Latiefa Freeman - Maintenance Technician
                    EmployeeNumber = "EMP00005",
                    EmployeeType = EmployeeType.MaintenanceTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    EmploymentType = EmploymentType.FullTime,
                    WorkPhone = "+27614836998",
                    WorkEmail = "maintenancetechnician@smartchill.com",
                    WorkLocationId = 5, // Durban
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                }
            );

            // In your ApplicationDbContext OnModelCreating method
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    UserId = "6", // Nathan Robertson - Links to ApplicationUser ID 6
                    AssignedEmployeeId = 2, // Andries Tatane - Customer Support Specialist
                    TradingName = "Boerewors Palace",
                    BusinessType = BusinessType.Shebeen,
                    RegistrationNumber = "2024/123456/07",
                    VATNumber = "4871253690",
                    BusinessEmail = "orders@boereworspalace.co.za",
                    BusinessPhoneNumber = "+27218765432",
                    AlternativePhone = "+27836549871",
                    LocationId = 1, // Paarl location (matches the Location seeding)
                    // Address details matching Location ID 1
                    AddressLine1 = "12 Voortrekker Road",
                    AddressLine2 = null,
                    Suburb = "Paarl",
                    City = "Paarl",
                    Province = "Western Cape",
                    PostalCode = "7646",
                    // Financial Information
                    CreditLimit = 50000.00m,
                    CurrentBalance = 1250.50m,
                    PaymentTermsDays = 30,
                    DiscountRate = 5.00m, // 5% discount for good standing
                                          // Status and Metadata
                    IsActive = true,
                    CreditStatus = CreditStatus.Good,
                    CustomerSince = new DateTime(2023, 6, 15),
                    OperatingHours = "Mon-Fri: 7:00-18:00, Sat: 7:00-14:00, Sun: Closed",
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    UpdatedAt = seedDate,
                    UpdatedBy = "System"
                }
            );

            modelBuilder.Entity<Location>().HasData(
        // 1 - Customer site
        new Location
        {
            Id = 1,
            AddressLine1 = "12 Voortrekker Road",
            AddressLine2 = null,
            Suburb = "Paarl",
            City = "Paarl",
            Province = "Western Cape",
            PostalCode = "7646",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 15, 8, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 2,
            AddressLine1 = "45 Mitchell Street",
            AddressLine2 = null,
            Suburb = "Berea",
            City = "East London",
            Province = "Eastern Cape",
            PostalCode = "5241",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 16, 9, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 3,
            AddressLine1 = "88 Goble Road",
            AddressLine2 = "Unit 5",
            Suburb = "Yeoville",
            City = "Johannesburg",
            Province = "Gauteng",
            PostalCode = "2198",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 17, 10, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 4,
            AddressLine1 = "15 Jan Shoba Street",
            AddressLine2 = null,
            Suburb = "Hatfield",
            City = "Pretoria",
            Province = "Gauteng",
            PostalCode = "0028",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 18, 11, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 5,
            AddressLine1 = "247 Florida Road",
            AddressLine2 = null,
            Suburb = "Morningside",
            City = "Durban",
            Province = "KwaZulu-Natal",
            PostalCode = "4001",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 19, 12, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 6,
            AddressLine1 = "88 Kerk Street",
            AddressLine2 = null,
            Suburb = "Potchefstroom",
            City = "Potchefstroom",
            Province = "North West",
            PostalCode = "2531",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 20, 13, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 7,
            AddressLine1 = "22 Beatrix Street",
            AddressLine2 = null,
            Suburb = "Arcadia",
            City = "Bloemfontein",
            Province = "Free State",
            PostalCode = "9301",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 21, 14, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 8,
            AddressLine1 = "45 Colinton Road",
            AddressLine2 = null,
            Suburb = "Newlands",
            City = "Cape Town",
            Province = "Western Cape",
            PostalCode = "7700",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 22, 15, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 9,
            AddressLine1 = "1 Kerk Street",
            AddressLine2 = null,
            Suburb = "Dullstroom",
            City = "Dullstroom",
            Province = "Mpumalanga",
            PostalCode = "1110",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 23, 16, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        },
        new Location
        {
            Id = 10,
            AddressLine1 = "12 Schröder Street",
            AddressLine2 = null,
            Suburb = "Kimberley",
            City = "Kimberley",
            Province = "Northern Cape",
            PostalCode = "8301",
            Country = "South Africa",
            IsActive = true,
            CreatedAt = new DateTime(2024, 1, 24, 17, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedAt = null,
            ModifiedBy = null
        }
    );

            // In your ApplicationDbContext OnModelCreating method
            modelBuilder.Entity<FridgeModel>().HasData(
                // 1-5: Small models for Spaza Shops & Convenience Stores
                new FridgeModel
                {
                    Id = 1,
                    Manufacturer = "Defy",
                    ModelName = "Compact 100L",
                    ModelCode = "DEF-C100",
                    CapacityLiters = 100,
                    Type = FridgeType.UprightFridge,
                    Description = "Compact upright fridge perfect for small businesses with limited space. Energy efficient and reliable.",
                    MonthlyRentalPrice = 299.00m,
                    PurchasePrice = 3499.00m,
                    EnergyRating = "A",
                    Dimensions = "85×55×60",
                    WeightKg = 45,
                    Color = "White",
                    Voltage = "220-240V",
                    PowerConsumption = 180,
                    TemperatureRange = "2°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    ImageUrl = "/images/fridges/defy-compact-100l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 2,
                    Manufacturer = "LG",
                    ModelName = "Business Cool 150L",
                    ModelCode = "LG-BC150",
                    CapacityLiters = 150,
                    Type = FridgeType.UprightFridge,
                    Description = "Reliable commercial fridge with digital temperature control and robust construction.",
                    MonthlyRentalPrice = 399.00m,
                    PurchasePrice = 4599.00m,
                    EnergyRating = "A+",
                    Dimensions = "90×60×65",
                    WeightKg = 52,
                    Color = "Silver",
                    Voltage = "220-240V",
                    PowerConsumption = 210,
                    TemperatureRange = "1°C to 10°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    ImageUrl = "/images/fridges/lg-business-cool-150l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 3,
                    Manufacturer = "Hisense",
                    ModelName = "FrostFree 120L",
                    ModelCode = "HIS-FF120",
                    CapacityLiters = 120,
                    Type = FridgeType.UprightFridge,
                    Description = "Budget-friendly frost-free fridge ideal for small retail spaces and startups.",
                    MonthlyRentalPrice = 259.00m,
                    PurchasePrice = 2999.00m,
                    EnergyRating = "B",
                    Dimensions = "88×58×62",
                    WeightKg = 48,
                    Color = "White",
                    Voltage = "220-240V",
                    PowerConsumption = 195,
                    TemperatureRange = "3°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 4,
                    ReorderQuantity = 6,
                    ImageUrl = "/images/fridges/hisense-frostfree-120l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 4,
                    Manufacturer = "Samsung",
                    ModelName = "Commercial 180L",
                    ModelCode = "SAM-C180",
                    CapacityLiters = 180,
                    Type = FridgeType.UprightFridge,
                    Description = "Medium capacity commercial fridge with digital controls and efficient cooling.",
                    MonthlyRentalPrice = 449.00m,
                    PurchasePrice = 5199.00m,
                    EnergyRating = "A+",
                    Dimensions = "95×65×68",
                    WeightKg = 58,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 225,
                    TemperatureRange = "0°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    ImageUrl = "/images/fridges/samsung-commercial-180l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 5,
                    Manufacturer = "KIC",
                    ModelName = "Small Chest 150L",
                    ModelCode = "KIC-SC150",
                    CapacityLiters = 150,
                    Type = FridgeType.ChestFreezer,
                    Description = "Energy-efficient chest freezer perfect for frozen goods storage in small businesses.",
                    MonthlyRentalPrice = 279.00m,
                    PurchasePrice = 3299.00m,
                    EnergyRating = "A",
                    Dimensions = "85×55×80",
                    WeightKg = 42,
                    Color = "White",
                    Voltage = "220-240V",
                    PowerConsumption = 190,
                    TemperatureRange = "-18°C to -25°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = false,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    ImageUrl = "/images/fridges/kic-chest-150l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },

                // 6-10: Medium models for Restaurants & Bars
                new FridgeModel
                {
                    Id = 6,
                    Manufacturer = "Bartech",
                    ModelName = "Glass Display 280L",
                    ModelCode = "BAR-GD280",
                    CapacityLiters = 280,
                    Type = FridgeType.GlassDisplayFridge,
                    Description = "Professional glass door display fridge perfect for bars and restaurants showcasing beverages.",
                    MonthlyRentalPrice = 699.00m,
                    PurchasePrice = 7899.00m,
                    EnergyRating = "A",
                    Dimensions = "185×65×70",
                    WeightKg = 95,
                    Color = "Black Glass",
                    Voltage = "220-240V",
                    PowerConsumption = 320,
                    TemperatureRange = "2°C to 6°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/bartech-glass-display-280l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 7,
                    Manufacturer = "Foster",
                    ModelName = "Undercounter 150L",
                    ModelCode = "FOS-UC150",
                    CapacityLiters = 150,
                    Type = FridgeType.UndercounterFridge,
                    Description = "Professional undercounter fridge built for commercial kitchens with stainless steel construction.",
                    MonthlyRentalPrice = 549.00m,
                    PurchasePrice = 6299.00m,
                    EnergyRating = "A+",
                    Dimensions = "85×60×70",
                    WeightKg = 68,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 280,
                    TemperatureRange = "1°C to 7°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/foster-undercounter-150l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 8,
                    Manufacturer = "True",
                    ModelName = "Beverage Cooler 200L",
                    ModelCode = "TRU-BC200",
                    CapacityLiters = 200,
                    Type = FridgeType.BeverageCooler,
                    Description = "Dedicated beverage cooler with multiple shelves, perfect for canned drinks and bottles.",
                    MonthlyRentalPrice = 499.00m,
                    PurchasePrice = 5799.00m,
                    EnergyRating = "A",
                    Dimensions = "85×60×65",
                    WeightKg = 55,
                    Color = "Black",
                    Voltage = "220-240V",
                    PowerConsumption = 240,
                    TemperatureRange = "3°C to 8°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    ImageUrl = "/images/fridges/true-beverage-200l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 9,
                    Manufacturer = "Hoshizaki",
                    ModelName = "Ice Maker Pro",
                    ModelCode = "HOS-IM25",
                    CapacityLiters = 25, // Ice production capacity
                    Type = FridgeType.IceMaker,
                    Description = "Commercial ice maker producing up to 25kg of ice per day, essential for bars and restaurants.",
                    MonthlyRentalPrice = 429.00m,
                    PurchasePrice = 4899.00m,
                    EnergyRating = "A",
                    Dimensions = "75×55×65",
                    WeightKg = 48,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 180,
                    TemperatureRange = "N/A",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = false,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 3,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/hoshizaki-ice-maker.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 10,
                    Manufacturer = "Perlick",
                    ModelName = "Wine Cooler 120L",
                    ModelCode = "PER-WC120",
                    CapacityLiters = 120,
                    Type = FridgeType.WineCooler,
                    Description = "Dual-zone wine cooler with precise temperature control for red and white wines.",
                    MonthlyRentalPrice = 399.00m,
                    PurchasePrice = 4599.00m,
                    EnergyRating = "A+",
                    Dimensions = "85×60×60",
                    WeightKg = 52,
                    Color = "Black Glass",
                    Voltage = "220-240V",
                    PowerConsumption = 160,
                    TemperatureRange = "5°C to 18°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/perlick-wine-cooler.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },

                // 11-15: Large models for Supermarkets & Hotels
                new FridgeModel
                {
                    Id = 11,
                    Manufacturer = "Hussmann",
                    ModelName = "Multi-Deck 500L",
                    ModelCode = "HUS-MD500",
                    CapacityLiters = 500,
                    Type = FridgeType.GlassDisplayFridge,
                    Description = "Large multi-deck display fridge for supermarkets with excellent product visibility.",
                    MonthlyRentalPrice = 1199.00m,
                    PurchasePrice = 13999.00m,
                    EnergyRating = "A+",
                    Dimensions = "200×120×80",
                    WeightKg = 220,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 580,
                    TemperatureRange = "2°C to 6°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 3,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/hussmann-multideck-500l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 12,
                    Manufacturer = "Beverage-Air",
                    ModelName = "Bottle Cooler 350L",
                    ModelCode = "BEV-BC350",
                    CapacityLiters = 350,
                    Type = FridgeType.BottleCooler,
                    Description = "High-capacity bottle cooler designed for liquor stores and large bars.",
                    MonthlyRentalPrice = 849.00m,
                    PurchasePrice = 9899.00m,
                    EnergyRating = "A",
                    Dimensions = "190×70×75",
                    WeightKg = 125,
                    Color = "Glass Door",
                    Voltage = "220-240V",
                    PowerConsumption = 420,
                    TemperatureRange = "3°C to 7°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/beverage-air-bottle-350l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 13,
                    Manufacturer = "Traulsen",
                    ModelName = "Combi 400L",
                    ModelCode = "TRA-C400",
                    CapacityLiters = 400,
                    Type = FridgeType.CombiFridgeFreezer,
                    Description = "Professional combination fridge-freezer unit for commercial kitchens and hotels.",
                    MonthlyRentalPrice = 999.00m,
                    PurchasePrice = 11599.00m,
                    EnergyRating = "A+",
                    Dimensions = "185×80×75",
                    WeightKg = 145,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 480,
                    TemperatureRange = "-18°C to 5°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 3,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/traulsen-combi-400l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 14,
                    Manufacturer = "Victory",
                    ModelName = "Upright Freezer 300L",
                    ModelCode = "VIC-UF300",
                    CapacityLiters = 300,
                    Type = FridgeType.UprightFreezer,
                    Description = "Large upright freezer with multiple shelves for organized frozen storage.",
                    MonthlyRentalPrice = 599.00m,
                    PurchasePrice = 6999.00m,
                    EnergyRating = "A",
                    Dimensions = "180×70×70",
                    WeightKg = 98,
                    Color = "White",
                    Voltage = "220-240V",
                    PowerConsumption = 350,
                    TemperatureRange = "-18°C to -25°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/victory-upright-freezer-300l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 15,
                    Manufacturer = "Nor-Lake",
                    ModelName = "Walk-In Cooler",
                    ModelCode = "NOR-WIC1000",
                    CapacityLiters = 1000,
                    Type = FridgeType.UprightFridge,
                    Description = "Modular walk-in cooler system for large-scale storage in supermarkets and hotels.",
                    MonthlyRentalPrice = 2499.00m,
                    PurchasePrice = 28999.00m,
                    EnergyRating = "A+",
                    Dimensions = "240×200×220",
                    WeightKg = 450,
                    Color = "White",
                    Voltage = "380V",
                    PowerConsumption = 1200,
                    TemperatureRange = "1°C to 4°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 2,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 0,
                    ReorderQuantity = 1,
                    ImageUrl = "/images/fridges/norlake-walk-in.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },

                // 16-20: Specialized models for various business types
                new FridgeModel
                {
                    Id = 16,
                    Manufacturer = "Delfield",
                    ModelName = "Pizza Prep 250L",
                    ModelCode = "DEL-PP250",
                    CapacityLiters = 250,
                    Type = FridgeType.UndercounterFridge,
                    Description = "Specialized undercounter fridge with roll-down door for pizza restaurants.",
                    MonthlyRentalPrice = 549.00m,
                    PurchasePrice = 6399.00m,
                    EnergyRating = "A",
                    Dimensions = "85×75×70",
                    WeightKg = 72,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 280,
                    TemperatureRange = "1°C to 5°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/delfield-pizza-prep.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 17,
                    Manufacturer = "Avantco",
                    ModelName = "Drawer Freezer 150L",
                    ModelCode = "AVA-DF150",
                    CapacityLiters = 150,
                    Type = FridgeType.UndercounterFreezer,
                    Description = "Undercounter drawer freezer for easy access in commercial kitchens.",
                    MonthlyRentalPrice = 479.00m,
                    PurchasePrice = 5599.00m,
                    EnergyRating = "A+",
                    Dimensions = "85×60×70",
                    WeightKg = 65,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 260,
                    TemperatureRange = "-18°C to -22°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/avantco-drawer-freezer.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 18,
                    Manufacturer = "Summit",
                    ModelName = "Beverage Center 180L",
                    ModelCode = "SUM-BC180",
                    CapacityLiters = 180,
                    Type = FridgeType.BeverageCooler,
                    Description = "Compact beverage center with glass door and adjustable shelving.",
                    MonthlyRentalPrice = 429.00m,
                    PurchasePrice = 4999.00m,
                    EnergyRating = "A",
                    Dimensions = "85×55×60",
                    WeightKg = 58,
                    Color = "Black",
                    Voltage = "220-240V",
                    PowerConsumption = 220,
                    TemperatureRange = "3°C to 8°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/summit-beverage-center.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 19,
                    Manufacturer = "EdgeStar",
                    ModelName = "Kegerator 100L",
                    ModelCode = "EDG-K100",
                    CapacityLiters = 100,
                    Type = FridgeType.BeverageCooler,
                    Description = "Specialized kegerator for draft beer systems in bars and restaurants.",
                    MonthlyRentalPrice = 599.00m,
                    PurchasePrice = 6999.00m,
                    EnergyRating = "A",
                    Dimensions = "90×55×60",
                    WeightKg = 52,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 180,
                    TemperatureRange = "2°C to 6°C",
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 3,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/edgestar-kegerator.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 20,
                    Manufacturer = "Whynter",
                    ModelName = "Dual Zone 140L",
                    ModelCode = "WHY-DZ140",
                    CapacityLiters = 140,
                    Type = FridgeType.CombiFridgeFreezer,
                    Description = "Portable dual-zone fridge-freezer combination for flexible commercial use.",
                    MonthlyRentalPrice = 399.00m,
                    PurchasePrice = 4699.00m,
                    EnergyRating = "A",
                    Dimensions = "95×55×65",
                    WeightKg = 48,
                    Color = "Silver",
                    Voltage = "220-240V",
                    PowerConsumption = 200,
                    TemperatureRange = "-18°C to 10°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = false,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/whynter-dual-zone.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },

                // 21-25: Additional specialized and premium models
                new FridgeModel
                {
                    Id = 21,
                    Manufacturer = "Frigidaire",
                    ModelName = "Professional 350L",
                    ModelCode = "FRI-P350",
                    CapacityLiters = 350,
                    Type = FridgeType.UprightFridge,
                    Description = "Professional-grade upright fridge with advanced temperature management.",
                    MonthlyRentalPrice = 799.00m,
                    PurchasePrice = 9299.00m,
                    EnergyRating = "A+",
                    Dimensions = "190×75×75",
                    WeightKg = 110,
                    Color = "Stainless Steel",
                    Voltage = "220-240V",
                    PowerConsumption = 380,
                    TemperatureRange = "0°C to 7°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 4,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/frigidaire-professional-350l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 22,
                    Manufacturer = "Kelvinator",
                    ModelName = "Commercial 200L",
                    ModelCode = "KEL-C200",
                    CapacityLiters = 200,
                    Type = FridgeType.UprightFridge,
                    Description = "Reliable commercial fridge with robust construction and energy efficiency.",
                    MonthlyRentalPrice = 379.00m,
                    PurchasePrice = 4399.00m,
                    EnergyRating = "A",
                    Dimensions = "92×65×68",
                    WeightKg = 62,
                    Color = "White",
                    Voltage = "220-240V",
                    PowerConsumption = 240,
                    TemperatureRange = "2°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 4,
                    ImageUrl = "/images/fridges/kelvinator-commercial-200l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 23,
                    Manufacturer = "Midea",
                    ModelName = "EcoCool 130L",
                    ModelCode = "MID-EC130",
                    CapacityLiters = 130,
                    Type = FridgeType.UprightFridge,
                    Description = "Economical and eco-friendly fridge with low power consumption.",
                    MonthlyRentalPrice = 229.00m,
                    PurchasePrice = 2699.00m,
                    EnergyRating = "A++",
                    Dimensions = "86×56×62",
                    WeightKg = 46,
                    Color = "Silver",
                    Voltage = "220-240V",
                    PowerConsumption = 150,
                    TemperatureRange = "3°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 4,
                    ReorderQuantity = 6,
                    ImageUrl = "/images/fridges/midea-ecocool-130l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 24,
                    Manufacturer = "Panasonic",
                    ModelName = "Inverter 250L",
                    ModelCode = "PAN-I250",
                    CapacityLiters = 250,
                    Type = FridgeType.UprightFridge,
                    Description = "Advanced inverter technology fridge with precise temperature control and quiet operation.",
                    MonthlyRentalPrice = 549.00m,
                    PurchasePrice = 6399.00m,
                    EnergyRating = "A++",
                    Dimensions = "170×60×65",
                    WeightKg = 68,
                    Color = "Silver",
                    Voltage = "220-240V",
                    PowerConsumption = 200,
                    TemperatureRange = "0°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    ImageUrl = "/images/fridges/panasonic-inverter-250l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 25,
                    Manufacturer = "Smeg",
                    ModelName = "Retro 180L",
                    ModelCode = "SME-R180",
                    CapacityLiters = 180,
                    Type = FridgeType.UprightFridge,
                    Description = "Stylish retro-design fridge perfect for boutique hotels and premium bars.",
                    MonthlyRentalPrice = 699.00m,
                    PurchasePrice = 7999.00m,
                    EnergyRating = "A+",
                    Dimensions = "125×60×65",
                    WeightKg = 58,
                    Color = "Cream",
                    Voltage = "220-240V",
                    PowerConsumption = 220,
                    TemperatureRange = "2°C to 8°C",
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    ImageUrl = "/images/fridges/smeg-retro-180l.jpg",
                    IsActive = true,
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                }
            );
        }
    }
}

