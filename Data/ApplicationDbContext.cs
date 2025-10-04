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
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:N → new Allocations
            modelBuilder.Entity<AllocationRequestHeader>()
              .HasMany(h => h.Allocations)
              .WithOne(a => a.RequestHeader)
              .HasForeignKey(a => a.AllocationRequestHeaderId)
              .OnDelete(DeleteBehavior.Cascade);

            // 1:N → replacement Allocations
            modelBuilder.Entity<AllocationRequestHeader>()
              .HasMany(h => h.ReplacementAllocations)
              .WithOne(a => a.ReplacementRequestHeader)
              .HasForeignKey(a => a.ReplacementRequestHeaderId)
              .OnDelete(DeleteBehavior.Restrict);

            var hasher = new PasswordHasher<ApplicationUser>();
            const string defaultPassword = "strongPassword#123";
            var seedDate = new DateTime(2025, 2, 14, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1",
                    UserName = "admin@smartchill.com",
                    NormalizedUserName = "ADMIN@SMARTCHILL.COM",
                    Email = "admin@smartchill.com",
                    NormalizedEmail = "ADMIN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27645347790",
                    PhoneNumberConfirmed = true,
                    FirstName = "Collins",
                    LastName = "Khosa",
                    DOB = new DateTime(2000, 10, 1),
                    //LocationId = 6, // Potchefstroom - personal/home location
                    UserRole = SD.AdminRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "c1fa9012-34b5-4c6d-8e7f-56a7890bc123",
                    ConcurrencyStamp = "a1b234c5-d6e7-4f8a-9b0c-1d2e3f4a5b6c",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "b5a771e9-2f8b-437a-9d0e-7f8b901cde12",
                    UserName = "customersupport@smartchill.com",
                    NormalizedUserName = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    Email = "customersupport@smartchill.com",
                    NormalizedEmail = "CUSTOMERSUPPORT@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27710737734",
                    PhoneNumberConfirmed = true,
                    FirstName = "Andries",
                    LastName = "Tatane",
                    DOB = new DateTime(1985, 1, 1),
                    //LocationId = 10, // Kimberley - personal/home location
                    UserRole = SD.CustomerSupportRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "d2c345e6-f7a8-4b0c-9d1e-2f3a4b5c6d7e",
                    ConcurrencyStamp = "c3d456f7-a8b0-4c1d-9e2f-3a4b5c6d7e8f",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "c6d882fa-47b9-448b-a9e0-8f9b012d3e45",
                    UserName = "stockcontroller@smartchill.com",
                    NormalizedUserName = "STOCKCONTROLLER@SMARTCHILL.COM",
                    Email = "stockcontroller@smartchill.com",
                    NormalizedEmail = "STOCKCONTROLLER@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27662934430",
                    PhoneNumberConfirmed = true,
                    FirstName = "Mido",
                    LastName = "Macia",
                    DOB = new DateTime(1999, 9, 1),
                    //LocationId = 2, // East London - personal/home location
                    UserRole = SD.StockControllerRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "f4e678a9-b0c1-4d3e-9f5a-6b7c8d9e0f12",
                    ConcurrencyStamp = "d5f789ab-c0de-4e1f-9a2b-7c8d9e0f1234",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "d7e9930b-58c0-459c-ba1f-9a0a123b4c56",
                    UserName = "faulttechnician@smartchill.com",
                    NormalizedUserName = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    Email = "faulttechnician@smartchill.com",
                    NormalizedEmail = "FAULTTECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27798946438",
                    PhoneNumberConfirmed = true,
                    FirstName = "Nathaniel",
                    LastName = "Julies",
                    DOB = new DateTime(1983, 11, 10),
                    //LocationId = 5, // Durban - personal/home location
                    UserRole = SD.FaultTechnicianRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "e6f89abc-0d12-4f2e-8b3c-0d4e5f6a7b8c",
                    ConcurrencyStamp = "f7a9bcde-1e23-4f3a-9c4d-1e5f6a7b8c9d",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e",
                    UserName = "maintenancetechnician@smartchill.com",
                    NormalizedUserName = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    Email = "maintenancetechnician@smartchill.com",
                    NormalizedEmail = "MAINTENANCETECHNICIAN@SMARTCHILL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27614836998",
                    PhoneNumberConfirmed = true,
                    FirstName = "Latiefa",
                    LastName = "Freeman",
                    DOB = new DateTime(1978, 2, 1),
                    //LocationId = 5, // Durban (proximity to Pietermaritzburg) - personal/home location
                    UserRole = SD.MaintenanceTechnicianRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "a7b8c9d0-2f34-4e5a-9f6b-7c8d9e0f1a2b",
                    ConcurrencyStamp = "b8c9d0e1-3f45-4a6b-9f7c-8d9e0f1a2b3c",
                    PasswordHash = hasher.HashPassword(null, defaultPassword),
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d",
                    UserName = "naterobertson@gmail.com",
                    NormalizedUserName = "NATEROBERTSON@GMAIL.COM",
                    Email = "naterobertson@gmail.com",
                    NormalizedEmail = "NATEROBERTSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "+27691745946",
                    PhoneNumberConfirmed = true,
                    FirstName = "Nathan",
                    LastName = "Robertson",
                    DOB = new DateTime(1985, 1, 1),
                    //LocationId = 3, // Johannesburg - personal/home location
                    UserRole = SD.CustomerRole,
                    IsDeleted = false,
                    CreatedAt = seedDate,
                    CreatedBy = "System",
                    SecurityStamp = "c9d0e1f2-4a56-4b7c-8d9e-0f1a2b3c4d5f",
                    ConcurrencyStamp = "d0e1f2a3-5b67-4c8d-9e0f-1a2b3c4d5e6f",
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
                new IdentityUserRole<string> { UserId = "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1", RoleId = "admin_role_id" },
                new IdentityUserRole<string> { UserId = "b5a771e9-2f8b-437a-9d0e-7f8b901cde12", RoleId = "customer_support_role_id" },
                new IdentityUserRole<string> { UserId = "c6d882fa-47b9-448b-a9e0-8f9b012d3e45", RoleId = "stock_controller_role_id" },
                new IdentityUserRole<string> { UserId = "d7e9930b-58c0-459c-ba1f-9a0a123b4c56", RoleId = "fault_technician_role_id" },
                new IdentityUserRole<string> { UserId = "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e", RoleId = "maintenance_technician_role_id" },
                new IdentityUserRole<string> { UserId = "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d", RoleId = "customer_role_id" }
            );

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.WorkLocation)
                .WithMany(l => l.Employees) // This tells EF Core to use the Employees collection
                .HasForeignKey(e => e.WorkLocationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.TradingLocation)
                .WithMany()
                .HasForeignKey(c => c.TradingLocationId)
                .OnDelete(DeleteBehavior.Restrict);


            // Seed Employees with WorkLocationId (work location) matching ApplicationUser LocationId where applicable
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    UserId = "e4b662f8-9c3a-4d6e-8a9f-8d7f784b4ac1", // Collins Khosa - Administrator
                    EmployeeNumber = "EMP00001",
                    EmployeeType = EmployeeType.Administrator,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    WorkPhone = "+27645347790",
                    WorkEmail = "admin@smartchill.com",
                    WorkLocationId = 6, // Potchefstroom - work location
                    IsDeleted = false
                },
                new Employee
                {
                    Id = 2,
                    UserId = "b5a771e9-2f8b-437a-9d0e-7f8b901cde12", // Andries Tatane - Customer Support
                    EmployeeNumber = "EMP00002",
                    EmployeeType = EmployeeType.CustomerSupport,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    WorkPhone = "+27710737734",
                    WorkEmail = "customersupport@smartchill.com",
                    WorkLocationId = 10, // Kimberley - work location
                    IsDeleted = false
                },
                new Employee
                {
                    Id = 3,
                    UserId = "c6d882fa-47b9-448b-a9e0-8f9b012d3e45", // Mido Macia - Stock Controller
                    EmployeeNumber = "EMP00003",
                    EmployeeType = EmployeeType.StockController,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    WorkPhone = "+27662934430",
                    WorkEmail = "stockcontroller@smartchill.com",
                    WorkLocationId = 2, // East London - work location
                    IsDeleted = false
                },
                new Employee
                {
                    Id = 4,
                    UserId = "d7e9930b-58c0-459c-ba1f-9a0a123b4c56", // Nathaniel Julies - Fault Technician
                    EmployeeNumber = "EMP00004",
                    EmployeeType = EmployeeType.FaultTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    WorkPhone = "+27798946438",
                    WorkEmail = "faulttechnician@smartchill.com",
                    WorkLocationId = 5, // Durban - work location
                    IsDeleted = false
                },
                new Employee
                {
                    Id = 5,
                    UserId = "f8a0ab1c-6a1d-46bd-cb2e-0f1a2b3c4d5e", // Latiefa Freeman - Maintenance Technician
                    EmployeeNumber = "EMP00005",
                    EmployeeType = EmployeeType.MaintenanceTechnician,
                    AvailabilityStatus = AvailabilityStatus.Available,
                    WorkPhone = "+27614836998",
                    WorkEmail = "maintenancetechnician@smartchill.com",
                    WorkLocationId = 5, // Durban (proximity to Pietermaritzburg) - work location
                    IsDeleted = false
                }
            );

            // Seed Customers with LocationId as business address
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    UserId = "a9b1c2d3-7e4f-45a6-bc3d-9e0f1a2b3c4d", // Nathan Robertson - Links to ApplicationUser ID
                    AssignedEmployeeId = 2, // Andries Tatane - Customer Support Specialist
                    BusinessName = "Boerewors Palace",
                    BusinessType = BusinessType.Shebeen,
                    RegistrationNumber = "2024/123456/07",
                    VATNumber = "4871253690",
                    BusinessEmail = "orders@boereworspalace.co.za",
                    BusinessPhoneNumber = "+27218765432",
                    AlternativePhone = "+27836549871",
                    TradingLocationId = 1, // Paarl Spaza Shop - business location/address
                    StreetAddress = "12 Voortrekker Road",
                    Suburb = "Paarl",
                    City = "Paarl",
                    Province = "Western Cape",
                    PostalCode = "7646",
                    CreditLimit = 50000.00m,
                    OutstandingBalance = 1250.50m,
                    PaymentTermsDays = 30,
                    DiscountRate = 5.00m, // 5% discount for good standing
                    CreditStatus = CreditStatus.Good,
                    CustomerSince = new DateTime(2023, 6, 15),
                    OperatingHours = "Mon-Fri: 7:00-18:00, Sat: 7:00-14:00, Sun: Closed",
                    AccountStatus = AccountStatus.Approved,
                    IsDeleted = false
                }
            );

            //// Configure Customer - TradingLocation relationship
            //modelBuilder.Entity<Customer>()
            //    .HasOne(c => c.TradingLocation)
            //    .WithMany()
            //    .HasForeignKey(c => c.LocationId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(false);

            //// Configure ApplicationUser - PrimaryLocation relationship
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(u => u.PrimraryLocation)
            //    .WithMany()
            //    .HasForeignKey(u => u.LocationId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(false);

            modelBuilder.Entity<Location>().HasData(
    new Location
    {
        Id = 1,
        Name = "Paarl Spaza Shop",
        LocationType = LocationType.CustomerSite,
        LocationCode = "PAARL-SPZ",
        StreetAddress = "12 Voortrekker Road",
        Suburb = "Paarl",
        City = "Paarl",
        Province = "Western Cape",
        PostalCode = "7646",
        Country = "South Africa",
        ContactPerson = "Sophie van der Merwe",
        ContactPhone = "+27 21 865 1234",
        ContactEmail = "sophie@paarlspaza.co.za",
        OperatingHours = "08:00 – 20:00",
        Capacity = 60,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 15, 8, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 2,
        Name = "Berea Convenience Store",
        LocationType = LocationType.CustomerSite,
        LocationCode = "BEREA-CSV",
        StreetAddress = "45 Mitchell Street",
        Suburb = "Berea",
        City = "East London",
        Province = "Eastern Cape",
        PostalCode = "5241",
        Country = "South Africa",
        ContactPerson = "Sipho Mkhize",
        ContactPhone = "+27 43 743 5567",
        ContactEmail = "sipho@bereaconvenience.co.za",
        OperatingHours = "07:00 – 21:00",
        Capacity = 80,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 16, 9, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 3,
        Name = "Yeoville Shebeen",
        LocationType = LocationType.CustomerSite,
        LocationCode = "YEOV-SHB",
        StreetAddress = "88 Goble Road",
        Suburb = "Yeoville",
        City = "Johannesburg",
        Province = "Gauteng",
        PostalCode = "2198",
        Country = "South Africa",
        ContactPerson = "Thabo Khumalo",
        ContactPhone = "+27 11 482 3344",
        ContactEmail = "thabo@yeovilleshebeen.co.za",
        OperatingHours = "10:00 – 23:00",
        Capacity = 40,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 17, 10, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 4,
        Name = "Hatfield Campus Depot",
        LocationType = LocationType.Warehouse,
        LocationCode = "HATF-DEPOT",
        StreetAddress = "15 Jan Shoba Street",
        Suburb = "Hatfield",
        City = "Pretoria",
        Province = "Gauteng",
        PostalCode = "0028",
        Country = "South Africa",
        ContactPerson = "Claire van Wyk",
        ContactPhone = "+27 12 420 5000",
        ContactEmail = "cw@campusdepot.example.com",
        OperatingHours = "08:00 – 17:00",
        Capacity = 200,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 18, 11, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 5,
        Name = "Morningside Distribution Hub",
        LocationType = LocationType.Warehouse,
        LocationCode = "MORN-HUB",
        StreetAddress = "247 Florida Road",
        Suburb = "Morningside",
        City = "Durban",
        Province = "KwaZulu-Natal",
        PostalCode = "4001",
        Country = "South Africa",
        ContactPerson = "Lindiwe Dlamini",
        ContactPhone = "+27 31 577 8900",
        ContactEmail = "lindiwe@distmorningside.co.za",
        OperatingHours = "07:00 – 18:00",
        Capacity = 300,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 19, 12, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 6,
        Name = "Potchefstroom Depot",
        LocationType = LocationType.Warehouse,
        LocationCode = "POTCH-DEP",
        StreetAddress = "88 Kerk Street",
        Suburb = "Potchefstroom",
        City = "Potchefstroom",
        Province = "North West",
        PostalCode = "2531",
        Country = "South Africa",
        ContactPerson = "Jan van der Merwe",
        ContactPhone = "+27 18 299 4000",
        ContactEmail = "jan@potchdepot.co.za",
        OperatingHours = "08:30 – 17:30",
        Capacity = 250,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 20, 13, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 7,
        Name = "Arcadia Service Centre",
        LocationType = LocationType.ServiceCenter,
        LocationCode = "ARCA-SVC",
        StreetAddress = "22 Beatrix Street",
        Suburb = "Arcadia",
        City = "Bloemfontein",
        Province = "Free State",
        PostalCode = "9301",
        Country = "South Africa",
        ContactPerson = "Nokuthula Mokoena",
        ContactPhone = "+27 51 432 2100",
        ContactEmail = "nokuthula@arcadiaservice.co.za",
        OperatingHours = "09:00 – 17:00",
        Capacity = 100,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 21, 14, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 8,
        Name = "Newlands Central Warehouse",
        LocationType = LocationType.Warehouse,
        LocationCode = "NEWL-WHS",
        StreetAddress = "45 Colinton Road",
        Suburb = "Newlands",
        City = "Cape Town",
        Province = "Western Cape",
        PostalCode = "7700",
        Country = "South Africa",
        ContactPerson = "Peter Adams",
        ContactPhone = "+27 21 650 1234",
        ContactEmail = "peter@newlandswhs.co.za",
        OperatingHours = "08:00 – 18:00",
        Capacity = 400,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 22, 15, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 9,
        Name = "Dullstroom Spaza Shop",
        LocationType = LocationType.CustomerSite,
        LocationCode = "DULL-SPZ",
        StreetAddress = "1 Kerk Street",
        Suburb = "Dullstroom",
        City = "Dullstroom",
        Province = "Mpumalanga",
        PostalCode = "1110",
        Country = "South Africa",
        ContactPerson = "Mpho Khumalo",
        ContactPhone = "+27 13 253 4021",
        ContactEmail = "mpho@dullstroomspaza.co.za",
        OperatingHours = "08:00 – 19:00",
        Capacity = 45,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 23, 16, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    },
    new Location
    {
        Id = 10,
        Name = "Kimberley Supplier Yard",
        LocationType = LocationType.SupplierSite,
        LocationCode = "KIMB-SUP",
        StreetAddress = "12 Schröder Street",
        Suburb = "Kimberley",
        City = "Kimberley",
        Province = "Northern Cape",
        PostalCode = "8301",
        Country = "South Africa",
        ContactPerson = "Cheryl Schröder",
        ContactPhone = "+27 53 831 9000",
        ContactEmail = "cheryl.schroeder@mandela.ac.za",
        OperatingHours = "07:30 – 16:30",
        Capacity = 150,
        IsDeleted = false,
        CreatedAt = new DateTime(2024, 1, 24, 17, 0, 0, DateTimeKind.Utc),
        CreatedBy = "System",
        UpdatedAt = null,
        UpdatedBy = null
    }
);


            modelBuilder.Entity<FridgeModel>().HasData(
                new FridgeModel
                {
                    Id = 1,
                    Manufacturer = "Defy",
                    ModelName = "Compact 100L",
                    ModelCode = "DEF-C100",
                    Type = FridgeType.UprightFridge,
                    CapacityLiters = 100,
                    Description = "Compact upright fridge ideal for limited-space spaza shops.",
                    EnergyRating = "A",
                    Dimensions = "85×55×60",
                    Color = "White",
                    MonthlyRentalPrice = 299.00m,
                    PurchasePrice = 3499.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/defy-compact-100l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 2,
                    Manufacturer = "Defy",
                    ModelName = "Classic Chest 150L",
                    ModelCode = "DEF-CF150",
                    Type = FridgeType.ChestFreezer,
                    CapacityLiters = 150,
                    Description = "Sturdy chest freezer for high-volume frozen storage.",
                    EnergyRating = "B",
                    Dimensions = "85×70×60",
                    Color = "White",
                    MonthlyRentalPrice = 319.00m,
                    PurchasePrice = 3899.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = false,
                    IsFrostFree = false,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/defy-chest-150l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 3,
                    Manufacturer = "Hisense",
                    ModelName = "Upright Freezer 200L",
                    ModelCode = "HIS-UF200",
                    Type = FridgeType.UprightFreezer,
                    CapacityLiters = 200,
                    Description = "Vertical freezer with adjustable shelves and frost-free tech.",
                    EnergyRating = "B",
                    Dimensions = "170×58×60",
                    Color = "White",
                    MonthlyRentalPrice = 429.00m,
                    PurchasePrice = 4999.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/hisense-upright-freezer-200l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 4,
                    Manufacturer = "Galaxy",
                    ModelName = "Display Chiller 200L",
                    ModelCode = "GAL-DF200",
                    Type = FridgeType.GlassDisplayFridge,
                    CapacityLiters = 200,
                    Description = "Glass-fronted display fridge with internal LED lighting.",
                    EnergyRating = "A+",
                    Dimensions = "180×58×60",
                    Color = "Silver",
                    MonthlyRentalPrice = 499.00m,
                    PurchasePrice = 5499.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/galaxy-display-200l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 5,
                    Manufacturer = "LG",
                    ModelName = "Beverage Cooler 120L",
                    ModelCode = "LG-BC120",
                    Type = FridgeType.BeverageCooler,
                    CapacityLiters = 120,
                    Description = "Slim beverage cooler for cans and bottles display.",
                    EnergyRating = "A",
                    Dimensions = "90×50×60",
                    Color = "Black",
                    MonthlyRentalPrice = 389.00m,
                    PurchasePrice = 4299.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/lg-beverage-120l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 6,
                    Manufacturer = "Defy",
                    ModelName = "Undercounter 120L",
                    ModelCode = "DEF-UC120",
                    Type = FridgeType.UndercounterFridge,
                    CapacityLiters = 120,
                    Description = "Under-counter fridge perfect for back-bar integration.",
                    EnergyRating = "A",
                    Dimensions = "82×60×57",
                    Color = "White",
                    MonthlyRentalPrice = 349.00m,
                    PurchasePrice = 4299.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/defy-undercounter-120l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 7,
                    Manufacturer = "LG",
                    ModelName = "Undercounter Freezer 100L",
                    ModelCode = "LG-UCF100",
                    Type = FridgeType.UndercounterFreezer,
                    CapacityLiters = 100,
                    Description = "Under-counter freezer module for compact storage.",
                    EnergyRating = "B",
                    Dimensions = "82×60×57",
                    Color = "White",
                    MonthlyRentalPrice = 369.00m,
                    PurchasePrice = 4299.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/lg-undercounter-freezer-100l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 8,
                    Manufacturer = "KIC",
                    ModelName = "Wine Cooler 50L",
                    ModelCode = "KIC-WC50",
                    Type = FridgeType.WineCooler,
                    CapacityLiters = 50,
                    Description = "Temperature-controlled wine cooler with glass door.",
                    EnergyRating = "A",
                    Dimensions = "85×50×60",
                    Color = "Black",
                    MonthlyRentalPrice = 519.00m,
                    PurchasePrice = 5799.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = false,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/kic-wine-50l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 9,
                    Manufacturer = "Samsung",
                    ModelName = "Combi 300L",
                    ModelCode = "SAM-CBF300",
                    Type = FridgeType.CombiFridgeFreezer,
                    CapacityLiters = 300,
                    Description = "Combined fridge-freezer with separate temperature zones.",
                    EnergyRating = "A+",
                    Dimensions = "175×70×65",
                    Color = "Grey",
                    MonthlyRentalPrice = 599.00m,
                    PurchasePrice = 6499.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/samsung-combi-300l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 10,
                    Manufacturer = "KIC",
                    ModelName = "Ice Maker Pro",
                    ModelCode = "KIC-IM50",
                    Type = FridgeType.IceMaker,
                    CapacityLiters = 0,
                    Description = "High-capacity ice maker, up to 50kg daily output.",
                    EnergyRating = "B",
                    Dimensions = "85×60×60",
                    Color = "White",
                    MonthlyRentalPrice = 799.00m,
                    PurchasePrice = 8999.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = false,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 1,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/kic-ice-maker-50kg.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 11,
                    Manufacturer = "Hisense",
                    ModelName = "Bottle Cooler 80L",
                    ModelCode = "HIS-BC80",
                    Type = FridgeType.BottleCooler,
                    CapacityLiters = 80,
                    Description = "Slim bottle cooler with glass door, ideal for display.",
                    EnergyRating = "A",
                    Dimensions = "82×43×58",
                    Color = "Black",
                    MonthlyRentalPrice = 289.00m,
                    PurchasePrice = 3299.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 4,
                    ReorderQuantity = 6,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/hisense-bottle-80l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 12,
                    Manufacturer = "Samsung",
                    ModelName = "Upright Fridge 250L",
                    ModelCode = "SAM-UF250",
                    Type = FridgeType.UprightFridge,
                    CapacityLiters = 250,
                    Description = "High-capacity upright fridge for beverage storage.",
                    EnergyRating = "A+",
                    Dimensions = "175×70×68",
                    Color = "Grey",
                    MonthlyRentalPrice = 599.00m,
                    PurchasePrice = 6499.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/samsung-upright-250l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 13,
                    Manufacturer = "Whirlpool",
                    ModelName = "Chest Freezer 300L",
                    ModelCode = "WHR-CF300",
                    Type = FridgeType.ChestFreezer,
                    CapacityLiters = 300,
                    Description = "Large chest freezer for bulk frozen inventory.",
                    EnergyRating = "B",
                    Dimensions = "90×85×65",
                    Color = "White",
                    MonthlyRentalPrice = 489.00m,
                    PurchasePrice = 5599.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = false,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/whirlpool-chest-300l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 14,
                    Manufacturer = "Bosch",
                    ModelName = "Glass Display 350L",
                    ModelCode = "BOS-GDF350",
                    Type = FridgeType.GlassDisplayFridge,
                    CapacityLiters = 350,
                    Description = "Extra-large glass display fridge for retail aisles.",
                    EnergyRating = "A+",
                    Dimensions = "190×80×70",
                    Color = "Silver",
                    MonthlyRentalPrice = 799.00m,
                    PurchasePrice = 8999.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/bosch-display-350l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 15,
                    Manufacturer = "Kelvinator",
                    ModelName = "Beverage Cooler 150L",
                    ModelCode = "KEL-BC150",
                    Type = FridgeType.BeverageCooler,
                    CapacityLiters = 150,
                    Description = "Medium-size beverage cooler with fan-forced cooling.",
                    EnergyRating = "A",
                    Dimensions = "150×60×60",
                    Color = "White",
                    MonthlyRentalPrice = 519.00m,
                    PurchasePrice = 5799.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 4,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/kelvinator-beverage-150l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 16,
                    Manufacturer = "Russell Hobbs",
                    ModelName = "UnderCounter 100L",
                    ModelCode = "RH-UC100",
                    Type = FridgeType.UndercounterFridge,
                    CapacityLiters = 100,
                    Description = "Compact under-counter fridge for limited space.",
                    EnergyRating = "A",
                    Dimensions = "82×60×57",
                    Color = "White",
                    MonthlyRentalPrice = 319.00m,
                    PurchasePrice = 3799.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 3,
                    ReorderQuantity = 5,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/rh-undercounter-100l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 17,
                    Manufacturer = "Hisense",
                    ModelName = "UnderCounter Freezer 120L",
                    ModelCode = "HIS-UCF120",
                    Type = FridgeType.UndercounterFreezer,
                    CapacityLiters = 120,
                    Description = "Under-counter freezer for back-bar deployment.",
                    EnergyRating = "B",
                    Dimensions = "82×60×57",
                    Color = "White",
                    MonthlyRentalPrice = 399.00m,
                    PurchasePrice = 4599.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 12,
                    WarrantyPeriodMonths = 36,
                    MinimumStockLevel = 2,
                    ReorderQuantity = 3,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/hisense-undercounter-freezer-120l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 18,
                    Manufacturer = "Defy",
                    ModelName = "Wine Cooler 70L",
                    ModelCode = "DEF-WC70",
                    Type = FridgeType.WineCooler,
                    CapacityLiters = 70,
                    Description = "Stylish wine cooler with precise temperature control.",
                    EnergyRating = "A",
                    Dimensions = "85×50×60",
                    Color = "Black",
                    MonthlyRentalPrice = 579.00m,
                    PurchasePrice = 6299.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = true,
                    HasLock = false,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/defy-wine-70l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 19,
                    Manufacturer = "LG",
                    ModelName = "Combi 450L",
                    ModelCode = "LG-CBF450",
                    Type = FridgeType.CombiFridgeFreezer,
                    CapacityLiters = 450,
                    Description = "Large combi fridge-freezer with water dispenser.",
                    EnergyRating = "A+",
                    Dimensions = "179×91×76",
                    Color = "Stainless Steel",
                    MonthlyRentalPrice = 1099.00m,
                    PurchasePrice = 11999.00m,
                    HasGlassDoor = false,
                    HasDigitalDisplay = true,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 1,
                    ReorderQuantity = 2,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/lg-combi-450l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                },
                new FridgeModel
                {
                    Id = 20,
                    Manufacturer = "Whirlpool",
                    ModelName = "Bottle Cooler 90L",
                    ModelCode = "WHR-BC90",
                    Type = FridgeType.BottleCooler,
                    CapacityLiters = 90,
                    Description = "Bottle cooler with glass door and internal LED.",
                    EnergyRating = "A",
                    Dimensions = "90×50×60",
                    Color = "Silver",
                    MonthlyRentalPrice = 329.00m,
                    PurchasePrice = 3899.00m,
                    HasGlassDoor = true,
                    HasDigitalDisplay = false,
                    HasLock = true,
                    IsFrostFree = true,
                    ServiceIntervalMonths = 6,
                    WarrantyPeriodMonths = 24,
                    MinimumStockLevel = 4,
                    ReorderQuantity = 6,
                    Status = FridgeModelStatus.Active,
                    ImageUrl = "/images/fridges/whirlpool-bottle-90l.jpg",
                    CreatedAt = seedDate,
                    CreatedBy = "System"
                }
            );


        }
    }
}