using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Utility;

namespace Project.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserRoles(modelBuilder);
            SeedCustomers(modelBuilder);
            SeedEmployees(modelBuilder);
            SeedFridges(modelBuilder);
            SeedFridgeInStocks(modelBuilder);
            SeedBusinessInfo(modelBuilder);
            SeedRequestHeaders(modelBuilder);
            SeedRequestDetails(modelBuilder);
            SeedCustomerFridges(modelBuilder);
            SeedFridgeVisits(modelBuilder);
            SeedFaultReports(modelBuilder);
            SeedFaultTechnicians(modelBuilder);
            SeedFridgeReplacements(modelBuilder);
            SeedRequestNotes(modelBuilder);
            SeedAllocations(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = SD.AdminRole, NormalizedName = SD.AdminRole.ToUpper() },
                new IdentityRole { Id = "2", Name = SD.CustomerRole, NormalizedName = SD.CustomerRole.ToUpper() },
                new IdentityRole { Id = "3", Name = SD.CustomerSupport, NormalizedName = SD.CustomerSupport.ToUpper() },
                new IdentityRole { Id = "4", Name = SD.StockController, NormalizedName = SD.StockController.ToUpper() },
                new IdentityRole { Id = "5", Name = SD.MaintenanceTechnician, NormalizedName = SD.MaintenanceTechnician.ToUpper() },
                new IdentityRole { Id = "6", Name = SD.FaultTechnician, NormalizedName = SD.FaultTechnician.ToUpper() }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            // Admin User
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "John",
                    LastName = "Smith",
                    StreetAddress = "123 Admin Street",
                    City = "Johannesburg",
                    State = "Gauteng",
                    PostalCode = "2000",
                    CellNumber = "0111234567",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                }
            );

            // Customer Support Team
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "11",
                    UserName = "emily.wilson@gmail.com",
                    NormalizedUserName = "EMILY.WILSON@GMAIL.COM",
                    Email = "emily.wilson@gmail.com",
                    NormalizedEmail = "EMILY.WILSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Support123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Emily",
                    LastName = "Wilson",
                    StreetAddress = "789 Support Road",
                    City = "Durban",
                    State = "KwaZulu-Natal",
                    PostalCode = "4001",
                    CellNumber = "0315551234",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "12",
                    UserName = "michael.brown@gmail.com",
                    NormalizedUserName = "MICHAEL.BROWN@GMAIL.COM",
                    Email = "michael.brown@gmail.com",
                    NormalizedEmail = "MICHAEL.BROWN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Support123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Michael",
                    LastName = "Brown",
                    StreetAddress = "321 Help Street",
                    City = "Pretoria",
                    State = "Gauteng",
                    PostalCode = "0002",
                    CellNumber = "0124445678",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                }
            );

            // Stock Control Team
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "13",
                    UserName = "david.taylor@gmail.com",
                    NormalizedUserName = "DAVID.TAYLOR@GMAIL.COM",
                    Email = "david.taylor@gmail.com",
                    NormalizedEmail = "DAVID.TAYLOR@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Stock123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "David",
                    LastName = "Taylor",
                    StreetAddress = "654 Warehouse Ave",
                    City = "Johannesburg",
                    State = "Gauteng",
                    PostalCode = "2001",
                    CellNumber = "0113337890",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "14",
                    UserName = "sarah.anderson@gmail.com",
                    NormalizedUserName = "SARAH.ANDERSON@GMAIL.COM",
                    Email = "sarah.anderson@gmail.com",
                    NormalizedEmail = "SARAH.ANDERSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Stock123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Sarah",
                    LastName = "Anderson",
                    StreetAddress = "852 Inventory Street",
                    City = "Cape Town",
                    State = "Western Cape",
                    PostalCode = "8001",
                    CellNumber = "0216667890",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                }
            );

            // Maintenance Technicians
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "15",
                    UserName = "robert.davis@gmail.com",
                    NormalizedUserName = "ROBERT.DAVIS@GMAIL.COM",
                    Email = "robert.davis@gmail.com",
                    NormalizedEmail = "ROBERT.DAVIS@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tech123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Robert",
                    LastName = "Davis",
                    StreetAddress = "987 Service Road",
                    City = "Cape Town",
                    State = "Western Cape",
                    PostalCode = "8001",
                    CellNumber = "0212224567",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "16",
                    UserName = "jennifer.martin@gmail.com",
                    NormalizedUserName = "JENNIFER.MARTIN@GMAIL.COM",
                    Email = "jennifer.martin@gmail.com",
                    NormalizedEmail = "JENNIFER.MARTIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tech123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Jennifer",
                    LastName = "Martin",
                    StreetAddress = "147 Repair Lane",
                    City = "Durban",
                    State = "KwaZulu-Natal",
                    PostalCode = "4001",
                    CellNumber = "0317778901",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                }
            );

            // Fault Technicians
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "17",
                    UserName = "james.miller@gmail.com",
                    NormalizedUserName = "JAMES.MILLER@GMAIL.COM",
                    Email = "james.miller@gmail.com",
                    NormalizedEmail = "JAMES.MILLER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tech123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "James",
                    LastName = "Miller",
                    StreetAddress = "258 Fault Street",
                    City = "Johannesburg",
                    State = "Gauteng",
                    PostalCode = "2001",
                    CellNumber = "0118881234",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                },
                new ApplicationUser
                {
                    Id = "18",
                    UserName = "patricia.white@gmail.com",
                    NormalizedUserName = "PATRICIA.WHITE@GMAIL.COM",
                    Email = "patricia.white@gmail.com",
                    NormalizedEmail = "PATRICIA.WHITE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tech123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Patricia",
                    LastName = "White",
                    StreetAddress = "369 Diagnostic Road",
                    City = "Pretoria",
                    State = "Gauteng",
                    PostalCode = "0002",
                    CellNumber = "0129994567",
                    IsApproved = true,
                    Status = "Approved",
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false
                }
            );

            // Business Customers (12 customers)
            var businessCustomers = new[]
            {
                new { Id = "3", FirstName = "Mike", LastName = "Wilson", Email = "mike.wilson@gmail.com", City = "Durban", Cell = "0315551234" },
                new { Id = "4", FirstName = "Lisa", LastName = "Brown", Email = "lisa.brown@gmail.com", City = "Pretoria", Cell = "0124445678" },
                new { Id = "5", FirstName = "David", LastName = "Jackson", Email = "david.jackson@gmail.com", City = "Port Elizabeth", Cell = "0413337890" },
                new { Id = "6", FirstName = "Emma", LastName = "Davis", Email = "emma.davis@gmail.com", City = "Bloemfontein", Cell = "0512224567" },
                new { Id = "7", FirstName = "Robert", LastName = "Miller", Email = "robert.miller@gmail.com", City = "Nelspruit", Cell = "0131112345" },
                new { Id = "8", FirstName = "Sophia", LastName = "Garcia", Email = "sophia.garcia@gmail.com", City = "Polokwane", Cell = "0156667890" },
                new { Id = "9", FirstName = "James", LastName = "Anderson", Email = "james.anderson@gmail.com", City = "Kimberley", Cell = "0537771234" },
                new { Id = "10", FirstName = "Olivia", LastName = "Martinez", Email = "olivia.martinez@gmail.com", City = "Rustenburg", Cell = "0148884567" },
                new { Id = "21", FirstName = "William", LastName = "Thomas", Email = "william.thomas@gmail.com", City = "East London", Cell = "0439991234" },
                new { Id = "22", FirstName = "Ava", LastName = "Robinson", Email = "ava.robinson@gmail.com", City = "Pietermaritzburg", Cell = "0338885678" },
                new { Id = "23", FirstName = "Noah", LastName = "Clark", Email = "noah.clark@gmail.com", City = "Welkom", Cell = "0577779012" },
                new { Id = "24", FirstName = "Isabella", LastName = "Rodriguez", Email = "isabella.rodriguez@gmail.com", City = "Witbank", Cell = "0136663456" }
            };

            foreach (var customer in businessCustomers)
            {
                modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = customer.Id,
                        UserName = customer.Email,
                        NormalizedUserName = customer.Email.ToUpper(),
                        Email = customer.Email,
                        NormalizedEmail = customer.Email.ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Customer123!"),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        StreetAddress = $"{new Random().Next(100, 999)} Business Street",
                        City = customer.City,
                        State = GetProvince(customer.City),
                        PostalCode = GetPostalCode(customer.City),
                        CellNumber = customer.Cell,
                        IsApproved = true,
                        Status = "Approved",
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false
                    }
                );
            }
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                // Admin role
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },

                // Customer Support roles
                new IdentityUserRole<string> { UserId = "11", RoleId = "3" },
                new IdentityUserRole<string> { UserId = "12", RoleId = "3" },

                // Stock Controller roles
                new IdentityUserRole<string> { UserId = "13", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "14", RoleId = "4" },

                // Maintenance Technician roles
                new IdentityUserRole<string> { UserId = "15", RoleId = "5" },
                new IdentityUserRole<string> { UserId = "16", RoleId = "5" },

                // Fault Technician roles
                new IdentityUserRole<string> { UserId = "17", RoleId = "6" },
                new IdentityUserRole<string> { UserId = "18", RoleId = "6" },

                // Business Customer roles
                new IdentityUserRole<string> { UserId = "3", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "4", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "5", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "6", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "7", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "8", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "9", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "10", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "21", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "22", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "23", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "24", RoleId = "2" }
            );
        }

        private static void SeedCustomers(ModelBuilder modelBuilder)
        {
            // Create sample document data (PDF header bytes)
            var sampleDocumentData = new byte[] {
                0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E, 0x34, 0x0A, 0x25,
                0xE2, 0xE3, 0xCF, 0xD3, 0x0A, 0x31, 0x20, 0x30, 0x20, 0x6F,
                0x62, 0x6A, 0x0A, 0x3C, 0x3C, 0x2F, 0x54, 0x79, 0x70, 0x65
            };

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, ApplicationUserId = "3", CustomerNumber = "CUST001", BusinessDocumentPath = "/docs/business-license.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 2, ApplicationUserId = "4", CustomerNumber = "CUST002", BusinessDocumentPath = "/docs/tax-certificate.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 3, ApplicationUserId = "5", CustomerNumber = "CUST003", BusinessDocumentPath = "/docs/registration-document.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 4, ApplicationUserId = "6", CustomerNumber = "CUST004", BusinessDocumentPath = "/docs/business-permit.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 5, ApplicationUserId = "7", CustomerNumber = "CUST005", BusinessDocumentPath = "/docs/trade-license.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 6, ApplicationUserId = "8", CustomerNumber = "CUST006", BusinessDocumentPath = "/docs/certificate.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 7, ApplicationUserId = "9", CustomerNumber = "CUST007", BusinessDocumentPath = "/docs/business-registration.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 8, ApplicationUserId = "10", CustomerNumber = "CUST008", BusinessDocumentPath = "/docs/compliance-doc.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 9, ApplicationUserId = "21", CustomerNumber = "CUST009", BusinessDocumentPath = "/docs/operating-license.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 10, ApplicationUserId = "22", CustomerNumber = "CUST010", BusinessDocumentPath = "/docs/business-permit.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 11, ApplicationUserId = "23", CustomerNumber = "CUST011", BusinessDocumentPath = "/docs/certificate.pdf", BusinessDocumentData = sampleDocumentData },
                new Customer { CustomerID = 12, ApplicationUserId = "24", CustomerNumber = "CUST012", BusinessDocumentPath = "/docs/registration-document.pdf", BusinessDocumentData = sampleDocumentData }
            );
        }

        private static void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, ApplicationUserId = "1", EmployeeNumber = "EMP001" },
                new Employee { EmployeeID = 2, ApplicationUserId = "11", EmployeeNumber = "EMP002" },
                new Employee { EmployeeID = 3, ApplicationUserId = "12", EmployeeNumber = "EMP003" },
                new Employee { EmployeeID = 4, ApplicationUserId = "13", EmployeeNumber = "EMP004" },
                new Employee { EmployeeID = 5, ApplicationUserId = "14", EmployeeNumber = "EMP005" },
                new Employee { EmployeeID = 6, ApplicationUserId = "15", EmployeeNumber = "EMP006" },
                new Employee { EmployeeID = 7, ApplicationUserId = "16", EmployeeNumber = "EMP007" },
                new Employee { EmployeeID = 8, ApplicationUserId = "17", EmployeeNumber = "EMP008" },
                new Employee { EmployeeID = 9, ApplicationUserId = "18", EmployeeNumber = "EMP009" }
            );
        }

        private static void SeedFridges(ModelBuilder modelBuilder)
        {
            var fridgeData = new List<Fridge>
            {
                new Fridge { FridgeId = 1, Brand = "Samsung", Model = "RT28A", CapacityLiters = 250, Type = "Double Door", Description = "Energy efficient fridge with frost-free technology and digital inverter compressor", RentalPricePerMonth = 450.0, ImageUrl = "/Images/Fridges/fridge1.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 2, Brand = "LG", Model = "GL-T292", CapacityLiters = 260, Type = "Top Freezer", Description = "Smart inverter compressor for energy savings with multi-air flow system", RentalPricePerMonth = 480.0, ImageUrl = "/Images/Fridges/fridge2.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 3, Brand = "Hisense", Model = "H370BI", CapacityLiters = 320, Type = "Bottom Freezer", Description = "Spacious design with humidity control and LED lighting", RentalPricePerMonth = 520.0, ImageUrl = "/Images/Fridges/fridge3.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 4, Brand = "Defy", Model = "DAC621", CapacityLiters = 350, Type = "Combi Fridge", Description = "A+ energy rated with multi-airflow system and glass shelves", RentalPricePerMonth = 550.0, ImageUrl = "/Images/Fridges/fridge4.jpg", AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 5, Brand = "Whirlpool", Model = "WDE205", CapacityLiters = 200, Type = "Single Door", Description = "Compact and efficient single door fridge perfect for small spaces", RentalPricePerMonth = 400.0, ImageUrl = "/Images/Fridges/fridge5.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 6, Brand = "Bosch", Model = "KDN42", CapacityLiters = 350, Type = "Frost Free", Description = "No frost cooling with LED lighting and VitaFresh technology", RentalPricePerMonth = 600.0, ImageUrl = "/Images/Fridges/fridge6.jpg", AvailabilityStatus = "Rented", Location = "Port Elizabeth" },
                new Fridge { FridgeId = 7, Brand = "Smeg", Model = "FAB28", CapacityLiters = 270, Type = "Retro Style", Description = "Stylish retro fridge with adjustable shelves and modern cooling", RentalPricePerMonth = 650.0, ImageUrl = "/Images/Fridges/fridge7.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 8, Brand = "Kelvinator", Model = "KRF265", CapacityLiters = 265, Type = "Top Mount", Description = "Affordable fridge with efficient cooling and durable design", RentalPricePerMonth = 430.0, ImageUrl = "/Images/Fridges/fridge8.jpg", AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 9, Brand = "Siemens", Model = "KG36N", CapacityLiters = 360, Type = "Bottom Freezer", Description = "No frost with multi-airflow system and hyperFresh technology", RentalPricePerMonth = 590.0, ImageUrl = "/Images/Fridges/fridge9.jpg", AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 10, Brand = "Haier", Model = "HRF290", CapacityLiters = 290, Type = "Double Door", Description = "Toughened glass shelves and energy efficient with HCS technology", RentalPricePerMonth = 470.0, ImageUrl = "/Images/Fridges/fridge10.jpg", AvailabilityStatus = "Available", Location = "Durban" }
            };

            modelBuilder.Entity<Fridge>().HasData(fridgeData);
        }

        private static void SeedFridgeInStocks(ModelBuilder modelBuilder)
        {
            var fridgeInStocks = new List<FridgeInStock>();
            var random = new Random();
            var conditions = new[] { "Excellent", "Good", "Very Good" };
            var locations = new[] { "Johannesburg Main Warehouse", "Cape Town Storage", "Durban Distribution", "Pretoria Facility", "Port Elizabeth Depot" };

            var idCounter = 1;
            for (int fridgeId = 1; fridgeId <= 10; fridgeId++)
            {
                for (int i = 1; i <= 8; i++)
                {
                    var isAvailable = random.Next(0, 4) != 0; // 75% available
                    fridgeInStocks.Add(new FridgeInStock
                    {
                        FridgeInStockId = idCounter,
                        FridgeNo = $"FRG-{fridgeId:000}-{i:000}",
                        LastMaintenanceDate = DateTime.Now.AddMonths(-random.Next(0, 8)),
                        Condition = conditions[random.Next(conditions.Length)],
                        IsAvailable = isAvailable,
                        Quantity = 1,
                        Location = locations[random.Next(locations.Length)],
                        FridgeId = fridgeId,
                        Status = isAvailable ? "Available" : "Maintenance"
                    });
                    idCounter++;
                }
            }

            modelBuilder.Entity<FridgeInStock>().HasData(fridgeInStocks);
        }

        private static void SeedBusinessInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessInfo>().HasData(
                new BusinessInfo { BusinessID = 1, BusinessName = "FridgeHub Enterprises", RegistrationNumber = "2024FH001", BusinessType = "Fridge Rental", Industry = "Appliance Rental", Email = "info@gmail.com", PhoneNumber = "0111234567", Website = "www.fridgehub.com", Address = "123 Main Street", City = "Johannesburg", Country = "South Africa", PostalCode = "2000", CreatedAt = new DateTime(2023, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9229) },
                new BusinessInfo { BusinessID = 2, BusinessName = "Cool Solutions SA", RegistrationNumber = "2023CS002", BusinessType = "Appliance Services", Industry = "Maintenance Services", Email = "admin@coolsolutions.co.za", PhoneNumber = "0219876543", Website = "www.coolsolutions.co.za", Address = "456 Service Road", City = "Cape Town", Country = "South Africa", PostalCode = "8001", CreatedAt = new DateTime(2024, 11, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9234) },
                new BusinessInfo { BusinessID = 3, BusinessName = "Fridge Rentals Durban", RegistrationNumber = "2024FR003", BusinessType = "Rental Services", Industry = "Appliance Rental", Email = "rentals@fridgedurban.co.za", PhoneNumber = "0315551234", Website = "www.fridgedurban.co.za", Address = "789 Coastal Road", City = "Durban", Country = "South Africa", PostalCode = "4001", CreatedAt = new DateTime(2025, 5, 12, 10, 28, 47, 510, DateTimeKind.Local).AddTicks(9238) }
            );
        }

        private static void SeedRequestHeaders(ModelBuilder modelBuilder)
        {
            var requestHeaders = new List<RequestHeader>
            {
                new RequestHeader { RequestHeaderId = 1, CustomerID = 1, EmployeeID = 2, RequestDate = new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(1543), RequestTotal = 1350.0, FirstName = "Mike", LastName = "Wilson", StreetAddress = "857 Trade Street", City = "Port Elizabeth", State = "Eastern Cape", PostalCode = "6001", CellNumber = "0315551234", Status = "Pending" },
                new RequestHeader { RequestHeaderId = 2, CustomerID = 2, EmployeeID = 3, RequestDate = new DateTime(2025, 10, 17, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558), RequestTotal = 980.0, FirstName = "Lisa", LastName = "Brown", StreetAddress = "642 Commerce Road", City = "Johannesburg", State = "Gauteng", PostalCode = "2000", CellNumber = "0124445678", Status = "Rejected", RejectionReason = "Required additional verification documents", RejectionDate = new DateTime(2025, 10, 21, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2558) },
                new RequestHeader { RequestHeaderId = 3, CustomerID = 3, EmployeeID = 4, RequestDate = new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), RequestTotal = 2200.0, FirstName = "David", LastName = "Jackson", StreetAddress = "358 Commerce Road", City = "Johannesburg", State = "Gauteng", PostalCode = "2001", CellNumber = "0413337890", Status = "Shipped", DeliveryDate = new DateTime(2025, 11, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572), PaymentDueDate = new DateTime(2025, 12, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2572) },
                new RequestHeader { RequestHeaderId = 4, CustomerID = 4, EmployeeID = 5, RequestDate = new DateTime(2025, 8, 19, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2578), RequestTotal = 1650.0, FirstName = "Emma", LastName = "Davis", StreetAddress = "720 Trade Street", City = "Bloemfontein", State = "Free State", PostalCode = "9301", CellNumber = "0512224567", Status = "Approved" },
                new RequestHeader { RequestHeaderId = 5, CustomerID = 5, EmployeeID = 6, RequestDate = new DateTime(2025, 10, 26, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584), RequestTotal = 1200.0, FirstName = "Robert", LastName = "Miller", StreetAddress = "653 Business Avenue", City = "Durban", State = "KwaZulu-Natal", PostalCode = "4001", CellNumber = "0131112345", Status = "Rejected", RejectionReason = "Credit check failed", RejectionDate = new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2584) }
            };

            modelBuilder.Entity<RequestHeader>().HasData(requestHeaders);
        }

        private static void SeedRequestDetails(ModelBuilder modelBuilder)
        {
            var requestDetails = new List<RequestDetails>
            {
                new RequestDetails { RequestDetailId = 1, RequestHeaderId = 1, FridgeId = 1, Count = 2, Price = 900.0 },
                new RequestDetails { RequestDetailId = 2, RequestHeaderId = 1, FridgeId = 5, Count = 1, Price = 450.0 },
                new RequestDetails { RequestDetailId = 3, RequestHeaderId = 2, FridgeId = 2, Count = 1, Price = 480.0 },
                new RequestDetails { RequestDetailId = 4, RequestHeaderId = 2, FridgeId = 10, Count = 1, Price = 500.0 },
                new RequestDetails { RequestDetailId = 5, RequestHeaderId = 3, FridgeId = 4, Count = 2, Price = 1100.0 },
                new RequestDetails { RequestDetailId = 6, RequestHeaderId = 3, FridgeId = 7, Count = 1, Price = 650.0 },
                new RequestDetails { RequestDetailId = 7, RequestHeaderId = 3, FridgeId = 8, Count = 1, Price = 450.0 },
                new RequestDetails { RequestDetailId = 8, RequestHeaderId = 4, FridgeId = 3, Count = 1, Price = 520.0 },
                new RequestDetails { RequestDetailId = 9, RequestHeaderId = 4, FridgeId = 6, Count = 1, Price = 600.0 },
                new RequestDetails { RequestDetailId = 10, RequestHeaderId = 4, FridgeId = 9, Count = 1, Price = 530.0 },
                new RequestDetails { RequestDetailId = 11, RequestHeaderId = 5, FridgeId = 1, Count = 3, Price = 1200.0 }
            };

            modelBuilder.Entity<RequestDetails>().HasData(requestDetails);
        }

        private static void SeedCustomerFridges(ModelBuilder modelBuilder)
        {
            var customerFridges = new List<CustomerFridge>
            {
                new CustomerFridge { CustomerFridgeId = 1, FridgeId = 1, FridgeInStockId = 5, CustomerID = 1, ReservedDate = new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2961), AllocatedDate = new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2961), RequestDetailId = 1, IsActive = true },
                new CustomerFridge { CustomerFridgeId = 2, FridgeId = 5, FridgeInStockId = 41, CustomerID = 1, ReservedDate = new DateTime(2025, 10, 15, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2978), AllocatedDate = new DateTime(2025, 10, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2978), RequestDetailId = 2, IsActive = true },
                new CustomerFridge { CustomerFridgeId = 3, FridgeId = 4, FridgeInStockId = 29, CustomerID = 3, ReservedDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), AllocatedDate = new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2980), RequestDetailId = 5, IsActive = true },
                new CustomerFridge { CustomerFridgeId = 4, FridgeId = 7, FridgeInStockId = 53, CustomerID = 3, ReservedDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), AllocatedDate = new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2992), RequestDetailId = 6, IsActive = true },
                new CustomerFridge { CustomerFridgeId = 5, FridgeId = 8, FridgeInStockId = 61, CustomerID = 3, ReservedDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), AllocatedDate = new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(2995), RequestDetailId = 7, IsActive = true }
            };

            modelBuilder.Entity<CustomerFridge>().HasData(customerFridges);
        }

        private static void SeedFridgeVisits(ModelBuilder modelBuilder)
        {
            var fridgeVisits = new List<FridgeVisit>
            {
                new FridgeVisit { VisitId = 1, VisitDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132), TechnicianName = "Jennifer Martin", Notes = "Routine maintenance completed. Checked compressor, condenser coils, and door seals. All components functioning normally.", CustomerApproval = "Approved", CheckupStatus = "Passed", RequestHeaderId = 3, VisitType = "Maintenance Check", Status = "Completed", CreatedDate = new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3132) },
                new FridgeVisit { VisitId = 2, VisitDate = new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161), TechnicianName = "Jennifer Martin", Notes = "Customer reported temperature fluctuations. Found faulty thermostat. Replaced thermostat and recalibrated temperature settings.", CustomerApproval = "Approved", CheckupStatus = "Passed", RequestHeaderId = 1, VisitType = "Repair", Status = "Completed", CreatedDate = new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3161) },
                new FridgeVisit { VisitId = 3, VisitDate = new DateTime(2025, 10, 31, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164), TechnicianName = "James Miller", Notes = "Quarterly preventive maintenance. Cleaned condenser coils, checked refrigerant levels, and verified door seal integrity.", CustomerApproval = "Approved", CheckupStatus = "Passed", RequestHeaderId = 4, VisitType = "Preventive Maintenance", Status = "Completed", CreatedDate = new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3164) }
            };

            modelBuilder.Entity<FridgeVisit>().HasData(fridgeVisits);
        }

        private static void SeedFaultReports(ModelBuilder modelBuilder)
        {
            var faultReports = new List<FaultReport>
            {
                new FaultReport { FaultReportId = 1, CustomerId = 1, FridgeInStockId = 5, FaultType = "Not Cooling", Description = "Fridge not maintaining temperature. Food items spoiling. Compressor running but not cooling properly.", Priority = "Critical", Status = "Resolved", ReportedDate = new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3301), ImageUrl = "/Images/Faults/fault-1.jpg", RequestReplacement = false, IsReplacementRequested = false },
                new FaultReport { FaultReportId = 2, CustomerId = 3, FridgeInStockId = 29, FaultType = "Strange Noises", Description = "Loud grinding noise coming from compressor area. Noise occurs every 15 minutes during cooling cycle.", Priority = "High", Status = "In Progress", ReportedDate = new DateTime(2025, 11, 6, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3319), ImageUrl = "/Images/Faults/fault-2.jpg", RequestReplacement = true, IsReplacementRequested = true },
                new FaultReport { FaultReportId = 3, CustomerId = 4, FridgeInStockId = 33, FaultType = "Water Leakage", Description = "Water pooling under fridge. Leak appears to be coming from defrost drain tube. Ice buildup in freezer compartment.", Priority = "Medium", Status = "Resolved", ReportedDate = new DateTime(2025, 10, 30, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3323), ImageUrl = "/Images/Faults/fault-3.jpg", RequestReplacement = false, IsReplacementRequested = false }
            };

            modelBuilder.Entity<FaultReport>().HasData(faultReports);
        }

        private static void SeedFaultTechnicians(ModelBuilder modelBuilder)
        {
            var faultTechnicians = new List<FaultTechnician>
            {
                new FaultTechnician { FaultId = 1, VisitId = 2, FaultType = "Not Cooling", FaultDescription = "Diagnosed faulty compressor relay. Replaced relay and tested system. Temperature now stable at 4°C.", ResolutionNotes = "Compressor relay replacement completed successfully. System cooling efficiently.", ReportDate = new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), RepairStatus = "Completed", TechnicianAssigned = "Jennifer Martin", CustomerBookingStatus = "Approved", Bookingate = new DateTime(2025, 10, 23, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361), FaultReportId = 1, Priority = "Critical", CreatedDate = new DateTime(2025, 10, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3361) },
                new FaultTechnician { FaultId = 2, VisitId = 1, FaultType = "Strange Noises", FaultDescription = "Identified worn compressor mounts causing vibration noise. Requires compressor replacement.", ResolutionNotes = "Compressor mounts worn beyond repair. Replacement scheduled for next week.", ReportDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), RepairStatus = "In Progress", TechnicianAssigned = "James Miller", CustomerBookingStatus = "Approved", Bookingate = new DateTime(2025, 11, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365), FaultReportId = 2, Priority = "High", CreatedDate = new DateTime(2025, 11, 8, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3365) }
            };

            modelBuilder.Entity<FaultTechnician>().HasData(faultTechnicians);
        }

        private static void SeedFridgeReplacements(ModelBuilder modelBuilder)
        {
            var fridgeReplacements = new List<FridgeReplacement>
            {
                new FridgeReplacement { FridgeReplacementId = 1, VisitId = 1, CustomerID = 3, OldFridgeNo = "FRG-004-005", ReasonForReplacement = "Compressor failure beyond economical repair", AdditionalNotes = "Customer approved replacement with similar capacity model. Old unit has served 7 years.", RequestDate = new DateTime(2025, 11, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), ReplacementDate = new DateTime(2025, 11, 16, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), ReplacementStatus = "Approved", ApplicationUserId = "3", NewFridgeInStockId = 30, TechnicianNotes = "Compressor seized due to refrigerant leak. Repair cost exceeds 70% of replacement value.", ActionDate = new DateTime(2025, 11, 10, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3401), ActionBy = "James Miller", ApprovedBy = "Emily Wilson" }
            };

            modelBuilder.Entity<FridgeReplacement>().HasData(fridgeReplacements);
        }

        private static void SeedRequestNotes(ModelBuilder modelBuilder)
        {
            var requestNotes = new List<RequestNote>
            {
                new RequestNote { RequestNoteId = 1, RequestHeaderId = 1, NoteContent = "Customer called to confirm delivery address. Confirmed business hours for delivery between 9 AM - 4 PM.", NoteType = "Customer", CreatedDate = new DateTime(2025, 9, 28, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3817) },
                new RequestNote { RequestNoteId = 2, RequestHeaderId = 2, NoteContent = "Additional business registration documents requested. Customer to email copies by end of week.", NoteType = "Administrative", CreatedDate = new DateTime(2025, 10, 12, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3832) },
                new RequestNote { RequestNoteId = 3, RequestHeaderId = 3, NoteContent = "Installation completed successfully. Customer trained on temperature settings and basic maintenance.", NoteType = "Technical", CreatedDate = new DateTime(2025, 10, 9, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3836) },
                new RequestNote { RequestNoteId = 4, RequestHeaderId = 4, NoteContent = "Credit application approved. Standard rental agreement terms applied.", NoteType = "Internal", CreatedDate = new DateTime(2025, 8, 22, 10, 28, 47, 511, DateTimeKind.Local).AddTicks(3838) }
            };

            modelBuilder.Entity<RequestNote>().HasData(requestNotes);
        }

        private static void SeedAllocations(ModelBuilder modelBuilder)
        {
            var allocations = new List<Allocation>
            {
                new Allocation { AllocationId = 1, CustomerID = 1, FridgeId = 1, Count = 2 },
                new Allocation { AllocationId = 2, CustomerID = 1, FridgeId = 5, Count = 1 },
                new Allocation { AllocationId = 3, CustomerID = 3, FridgeId = 4, Count = 2 },
                new Allocation { AllocationId = 4, CustomerID = 3, FridgeId = 7, Count = 1 },
                new Allocation { AllocationId = 5, CustomerID = 3, FridgeId = 8, Count = 1 },
                new Allocation { AllocationId = 6, CustomerID = 4, FridgeId = 3, Count = 1 },
                new Allocation { AllocationId = 7, CustomerID = 4, FridgeId = 6, Count = 1 },
                new Allocation { AllocationId = 8, CustomerID = 4, FridgeId = 9, Count = 1 }
            };

            modelBuilder.Entity<Allocation>().HasData(allocations);
        }

        // Helper methods
        private static string GetProvince(string city)
        {
            return city switch
            {
                "Johannesburg" or "Pretoria" or "Witbank" => "Gauteng",
                "Cape Town" => "Western Cape",
                "Durban" or "Pietermaritzburg" => "KwaZulu-Natal",
                "Port Elizabeth" or "East London" => "Eastern Cape",
                "Bloemfontein" or "Welkom" => "Free State",
                "Nelspruit" => "Mpumalanga",
                "Polokwane" => "Limpopo",
                "Kimberley" => "Northern Cape",
                "Rustenburg" => "North West",
                _ => "Gauteng"
            };
        }

        private static string GetPostalCode(string city)
        {
            return city switch
            {
                "Johannesburg" => "2000",
                "Cape Town" => "8001",
                "Durban" => "4001",
                "Pretoria" => "0002",
                "Port Elizabeth" => "6001",
                "Bloemfontein" => "9301",
                "Nelspruit" => "1200",
                "Polokwane" => "0700",
                "Kimberley" => "8301",
                "Rustenburg" => "2999",
                "East London" => "5201",
                "Pietermaritzburg" => "3201",
                "Welkom" => "9460",
                "Witbank" => "1035",
                _ => "2000"
            };
        }
    }
}