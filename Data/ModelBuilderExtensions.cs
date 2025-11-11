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

            // Admin Users
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
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "sarah.johnson@gmail.com",
                    NormalizedUserName = "SARAH.JOHNSON@GMAIL.COM",
                    Email = "sarah.johnson@gmail.com",
                    NormalizedEmail = "SARAH.JOHNSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    StreetAddress = "456 Management Ave",
                    City = "Cape Town",
                    State = "Western Cape",
                    PostalCode = "8001",
                    CellNumber = "0219876543",
                    IsApproved = true,
                    Status = "Approved"
                }
            );

            // Customer Users
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "mike.wilson@gmail.com",
                    NormalizedUserName = "MIKE.WILSON@GMAIL.COM",
                    Email = "mike.wilson@gmail.com",
                    NormalizedEmail = "MIKE.WILSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Mike",
                    LastName = "Wilson",
                    StreetAddress = "789 Customer Road",
                    City = "Durban",
                    State = "KwaZulu-Natal",
                    PostalCode = "4001",
                    CellNumber = "0315551234",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "lisa.brown@gmail.com",
                    NormalizedUserName = "LISA.BROWN@GMAIL.COM",
                    Email = "lisa.brown@gmail.com",
                    NormalizedEmail = "LISA.BROWN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Lisa",
                    LastName = "Brown",
                    StreetAddress = "321 Business Street",
                    City = "Pretoria",
                    State = "Gauteng",
                    PostalCode = "0002",
                    CellNumber = "0124445678",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "5",
                    UserName = "david.jackson@gmail.com",
                    NormalizedUserName = "DAVID.JACKSON@GMAIL.COM",
                    Email = "david.jackson@gmail.com",
                    NormalizedEmail = "DAVID.JACKSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "David",
                    LastName = "Jackson",
                    StreetAddress = "654 Retail Avenue",
                    City = "Port Elizabeth",
                    State = "Eastern Cape",
                    PostalCode = "6001",
                    CellNumber = "0413337890",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "6",
                    UserName = "emma.davis@gmail.com",
                    NormalizedUserName = "EMMA.DAVIS@GMAIL.COM",
                    Email = "emma.davis@gmail.com",
                    NormalizedEmail = "EMMA.DAVIS@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Emma",
                    LastName = "Davis",
                    StreetAddress = "987 Commerce Road",
                    City = "Bloemfontein",
                    State = "Free State",
                    PostalCode = "9301",
                    CellNumber = "0512224567",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "7",
                    UserName = "robert.miller@gmail.com",
                    NormalizedUserName = "ROBERT.MILLER@GMAIL.COM",
                    Email = "robert.miller@gmail.com",
                    NormalizedEmail = "ROBERT.MILLER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Robert",
                    LastName = "Miller",
                    StreetAddress = "147 Trade Street",
                    City = "Nelspruit",
                    State = "Mpumalanga",
                    PostalCode = "1200",
                    CellNumber = "0131112345",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "8",
                    UserName = "sophia.garcia@gmail.com",
                    NormalizedUserName = "SOPHIA.GARCIA@GMAIL.COM",
                    Email = "sophia.garcia@gmail.com",
                    NormalizedEmail = "SOPHIA.GARCIA@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Sophia",
                    LastName = "Garcia",
                    StreetAddress = "258 Market Lane",
                    City = "Polokwane",
                    State = "Limpopo",
                    PostalCode = "0700",
                    CellNumber = "0156667890",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "9",
                    UserName = "james.anderson@gmail.com",
                    NormalizedUserName = "JAMES.ANDERSON@GMAIL.COM",
                    Email = "james.anderson@gmail.com",
                    NormalizedEmail = "JAMES.ANDERSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "James",
                    LastName = "Anderson",
                    StreetAddress = "369 Industry Road",
                    City = "Kimberley",
                    State = "Northern Cape",
                    PostalCode = "8301",
                    CellNumber = "0537771234",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "10",
                    UserName = "olivia.martinez@gmail.com",
                    NormalizedUserName = "OLIVIA.MARTINEZ@GMAIL.COM",
                    Email = "olivia.martinez@gmail.com",
                    NormalizedEmail = "OLIVIA.MARTINEZ@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Olivia",
                    LastName = "Martinez",
                    StreetAddress = "741 Commercial Ave",
                    City = "Rustenburg",
                    State = "North West",
                    PostalCode = "2999",
                    CellNumber = "0148884567",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "21",
                    UserName = "william.thomas@gmail.com",
                    NormalizedUserName = "WILLIAM.THOMAS@GMAIL.COM",
                    Email = "william.thomas@gmail.com",
                    NormalizedEmail = "WILLIAM.THOMAS@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "William",
                    LastName = "Thomas",
                    StreetAddress = "852 Enterprise Street",
                    City = "East London",
                    State = "Eastern Cape",
                    PostalCode = "5201",
                    CellNumber = "0439991234",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "22",
                    UserName = "ava.robinson@gmail.com",
                    NormalizedUserName = "AVA.ROBINSON@GMAIL.COM",
                    Email = "ava.robinson@gmail.com",
                    NormalizedEmail = "AVA.ROBINSON@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Ava",
                    LastName = "Robinson",
                    StreetAddress = "963 Corporate Road",
                    City = "Pietermaritzburg",
                    State = "KwaZulu-Natal",
                    PostalCode = "3201",
                    CellNumber = "0338885678",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "23",
                    UserName = "noah.clark@gmail.com",
                    NormalizedUserName = "NOAH.CLARK@GMAIL.COM",
                    Email = "noah.clark@gmail.com",
                    NormalizedEmail = "NOAH.CLARK@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Noah",
                    LastName = "Clark",
                    StreetAddress = "159 Business Park",
                    City = "Welkom",
                    State = "Free State",
                    PostalCode = "9460",
                    CellNumber = "0577779012",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "24",
                    UserName = "isabella.rodriguez@gmail.com",
                    NormalizedUserName = "ISABELLA.RODRIGUEZ@GMAIL.COM",
                    Email = "isabella.rodriguez@gmail.com",
                    NormalizedEmail = "ISABELLA.RODRIGUEZ@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Isabella",
                    LastName = "Rodriguez",
                    StreetAddress = "753 Industrial Area",
                    City = "Witbank",
                    State = "Mpumalanga",
                    PostalCode = "1035",
                    CellNumber = "0136663456",
                    IsApproved = true,
                    Status = "Approved"
                }
            );

            // Employee Users
            modelBuilder.Entity<ApplicationUser>().HasData(
                // Customer Support Team
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
                    Status = "Approved"
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
                    Status = "Approved"
                },
                // Stock Control Team
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
                    Status = "Approved"
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
                    Status = "Approved"
                },
                // Maintenance Technicians
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
                    Status = "Approved"
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
                    Status = "Approved"
                },
                // Fault Technicians
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
                    Status = "Approved"
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
                    Status = "Approved"
                },
                // Additional Employees
                new ApplicationUser
                {
                    Id = "25",
                    UserName = "daniel.moore@gmail.com",
                    NormalizedUserName = "DANIEL.MOORE@GMAIL.COM",
                    Email = "daniel.moore@gmail.com",
                    NormalizedEmail = "DANIEL.MOORE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Support123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Daniel",
                    LastName = "Moore",
                    StreetAddress = "456 Service Lane",
                    City = "Johannesburg",
                    State = "Gauteng",
                    PostalCode = "2001",
                    CellNumber = "0117772345",
                    IsApproved = true,
                    Status = "Approved"
                },
                new ApplicationUser
                {
                    Id = "26",
                    UserName = "susan.lee@gmail.com",
                    NormalizedUserName = "SUSAN.LEE@GMAIL.COM",
                    Email = "susan.lee@gmail.com",
                    NormalizedEmail = "SUSAN.LEE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Stock123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Susan",
                    LastName = "Lee",
                    StreetAddress = "789 Stock Avenue",
                    City = "Cape Town",
                    State = "Western Cape",
                    PostalCode = "8001",
                    CellNumber = "0215556789",
                    IsApproved = true,
                    Status = "Approved"
                }
            );
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                // Admin roles
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "1" },

                // Customer roles
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
                new IdentityUserRole<string> { UserId = "24", RoleId = "2" },

                // Customer Support roles
                new IdentityUserRole<string> { UserId = "11", RoleId = "3" },
                new IdentityUserRole<string> { UserId = "12", RoleId = "3" },
                new IdentityUserRole<string> { UserId = "25", RoleId = "3" },

                // Stock Controller roles
                new IdentityUserRole<string> { UserId = "13", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "14", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "26", RoleId = "4" },

                // Maintenance Technician roles
                new IdentityUserRole<string> { UserId = "15", RoleId = "5" },
                new IdentityUserRole<string> { UserId = "16", RoleId = "5" },

                // Fault Technician roles
                new IdentityUserRole<string> { UserId = "17", RoleId = "6" },
                new IdentityUserRole<string> { UserId = "18", RoleId = "6" }
            );
        }

        private static void SeedCustomers(ModelBuilder modelBuilder)
        {
            // Create sample document data (simulating small PDF files)
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
                new Employee { EmployeeID = 2, ApplicationUserId = "2", EmployeeNumber = "EMP002" },
                new Employee { EmployeeID = 3, ApplicationUserId = "11", EmployeeNumber = "EMP003" },
                new Employee { EmployeeID = 4, ApplicationUserId = "12", EmployeeNumber = "EMP004" },
                new Employee { EmployeeID = 5, ApplicationUserId = "13", EmployeeNumber = "EMP005" },
                new Employee { EmployeeID = 6, ApplicationUserId = "14", EmployeeNumber = "EMP006" },
                new Employee { EmployeeID = 7, ApplicationUserId = "15", EmployeeNumber = "EMP007" },
                new Employee { EmployeeID = 8, ApplicationUserId = "16", EmployeeNumber = "EMP008" },
                new Employee { EmployeeID = 9, ApplicationUserId = "17", EmployeeNumber = "EMP009" },
                new Employee { EmployeeID = 10, ApplicationUserId = "18", EmployeeNumber = "EMP010" },
                new Employee { EmployeeID = 11, ApplicationUserId = "25", EmployeeNumber = "EMP011" },
                new Employee { EmployeeID = 12, ApplicationUserId = "26", EmployeeNumber = "EMP012" }
            );
        }

        private static void SeedFridges(ModelBuilder modelBuilder)
        {
            var fridgeImages = new[]
            {
        "/Images/Fridges/fridge1.jpg", "/Images/Fridges/fridge2.jpg", "/Images/Fridges/fridge3.jpg",
        "/Images/Fridges/fridge4.jpg", "/Images/Fridges/fridge5.jpg", "/Images/Fridges/fridge6.jpg",
        "/Images/Fridges/fridge7.jpg", "/Images/Fridges/fridge8.jpg", "/Images/Fridges/fridge9.jpg",
        "/Images/Fridges/fridge10.jpg", "/Images/Fridges/fridge11.jpg", "/Images/Fridges/fridge12.jpg",
        "/Images/Fridges/fridge13.jpg", "/Images/Fridges/fridge14.jpg", "/Images/Fridges/fridge15.jpg",
        "/Images/Fridges/fridge16.jpg", "/Images/Fridges/fridge17.jpg", "/Images/Fridges/fridge18.jpg",
        "/Images/Fridges/fridge19.jpg", "/Images/Fridges/fridge20.jpg", "/Images/Fridges/fridge21.jpg",
        "/Images/Fridges/fridge22.jpg", "/Images/Fridges/fridge23.jpg", "/Images/Fridges/fridge24.jpg",
        "/Images/Fridges/fridge25.jpg", "/Images/Fridges/fridge26.jpg", "/Images/Fridges/fridge27.jpg",
        "/Images/Fridges/fridge28.jpg", "/Images/Fridges/fridge29.jpg", "/Images/Fridges/fridge30.jpg",
        "/Images/Fridges/fridge31.jpg", "/Images/Fridges/fridge32.jpg", "/Images/Fridges/fridge33.jpg",
        "/Images/Fridges/fridge34.jpg", "/Images/Fridges/fridge35.jpg", "/Images/Fridges/fridge36.jpg",
        "/Images/Fridges/fridge37.jpg", "/Images/Fridges/fridge38.jpg", "/Images/Fridges/fridge39.jpg",
        "/Images/Fridges/fridge40.jpg", "/Images/Fridges/fridge41.jpg", "/Images/Fridges/fridge42.jpg",
        "/Images/Fridges/fridge43.jpg", "/Images/Fridges/fridge44.jpg", "/Images/Fridges/fridge45.jpg",
        "/Images/Fridges/fridge46.jpg", "/Images/Fridges/fridge47.jpg", "/Images/Fridges/fridge48.jpg"
    };

            modelBuilder.Entity<Fridge>().HasData(
                new Fridge { FridgeId = 1, Brand = "Samsung", Model = "RT28A", CapacityLiters = 250, Type = "Double Door", Description = "Energy efficient fridge with frost-free technology", RentalPricePerMonth = 450.0, ImageUrl = fridgeImages[0], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 2, Brand = "LG", Model = "GL-T292", CapacityLiters = 260, Type = "Top Freezer", Description = "Smart inverter compressor for energy savings", RentalPricePerMonth = 480.0, ImageUrl = fridgeImages[1], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 3, Brand = "Hisense", Model = "H370BI", CapacityLiters = 320, Type = "Bottom Freezer", Description = "Spacious design with humidity control", RentalPricePerMonth = 520.0, ImageUrl = fridgeImages[2], AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 4, Brand = "Defy", Model = "DAC621", CapacityLiters = 350, Type = "Combi Fridge", Description = "A+ energy rated with multi-airflow system", RentalPricePerMonth = 550.0, ImageUrl = fridgeImages[3], AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 5, Brand = "Whirlpool", Model = "WDE205", CapacityLiters = 200, Type = "Single Door", Description = "Compact and efficient single door fridge", RentalPricePerMonth = 400.0, ImageUrl = fridgeImages[4], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 6, Brand = "Bosch", Model = "KDN42", CapacityLiters = 350, Type = "Frost Free", Description = "No frost cooling with LED lighting", RentalPricePerMonth = 600.0, ImageUrl = fridgeImages[5], AvailabilityStatus = "Rented", Location = "Port Elizabeth" },
                new Fridge { FridgeId = 7, Brand = "Smeg", Model = "FAB28", CapacityLiters = 270, Type = "Retro Style", Description = "Stylish retro fridge with adjustable shelves", RentalPricePerMonth = 650.0, ImageUrl = fridgeImages[6], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 8, Brand = "Kelvinator", Model = "KRF265", CapacityLiters = 265, Type = "Top Mount", Description = "Affordable fridge with efficient cooling", RentalPricePerMonth = 430.0, ImageUrl = fridgeImages[7], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 9, Brand = "Siemens", Model = "KG36N", CapacityLiters = 360, Type = "Bottom Freezer", Description = "No frost with multi-airflow system", RentalPricePerMonth = 590.0, ImageUrl = fridgeImages[8], AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 10, Brand = "Haier", Model = "HRF290", CapacityLiters = 290, Type = "Double Door", Description = "Toughened glass shelves and energy efficient", RentalPricePerMonth = 470.0, ImageUrl = fridgeImages[9], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 11, Brand = "Hisense", Model = "H310BI", CapacityLiters = 310, Type = "Top Freezer", Description = "Low noise and efficient compressor", RentalPricePerMonth = 500.0, ImageUrl = fridgeImages[10], AvailabilityStatus = "Available", Location = "Bloemfontein" },
                new Fridge { FridgeId = 12, Brand = "Defy", Model = "DAC700", CapacityLiters = 420, Type = "Side by Side", Description = "LED display and water dispenser", RentalPricePerMonth = 700.0, ImageUrl = fridgeImages[11], AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 13, Brand = "LG", Model = "GL-Q282", CapacityLiters = 282, Type = "Smart Inverter", Description = "Smart cooling with WiFi control", RentalPricePerMonth = 530.0, ImageUrl = fridgeImages[12], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 14, Brand = "Samsung", Model = "RT34A", CapacityLiters = 340, Type = "Top Freezer", Description = "Twin cooling system for freshness", RentalPricePerMonth = 560.0, ImageUrl = fridgeImages[13], AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 15, Brand = "Whirlpool", Model = "WDE520", CapacityLiters = 500, Type = "Double Door", Description = "High capacity with 6th sense technology", RentalPricePerMonth = 750.0, ImageUrl = fridgeImages[14], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 16, Brand = "Samsung", Model = "RT38A", CapacityLiters = 380, Type = "French Door", Description = "Flexible storage with external water dispenser", RentalPricePerMonth = 680.0, ImageUrl = fridgeImages[15], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 17, Brand = "LG", Model = "GL-B422", CapacityLiters = 422, Type = "Bottom Freezer", Description = "Door cooling+ technology for even cooling", RentalPricePerMonth = 620.0, ImageUrl = fridgeImages[16], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 18, Brand = "Hisense", Model = "H450BI", CapacityLiters = 450, Type = "Side by Side", Description = "Premium cooling with smart features", RentalPricePerMonth = 720.0, ImageUrl = fridgeImages[17], AvailabilityStatus = "Rented", Location = "Johannesburg" },
                new Fridge { FridgeId = 19, Brand = "Defy", Model = "DAC800", CapacityLiters = 520, Type = "Double Door", Description = "Large capacity with eco-friendly refrigerant", RentalPricePerMonth = 580.0, ImageUrl = fridgeImages[18], AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 20, Brand = "Whirlpool", Model = "WDE350", CapacityLiters = 350, Type = "Top Freezer", Description = "6th sense technology with adaptive cooling", RentalPricePerMonth = 520.0, ImageUrl = fridgeImages[19], AvailabilityStatus = "Available", Location = "Port Elizabeth" },
                new Fridge { FridgeId = 21, Brand = "Bosch", Model = "KDN56", CapacityLiters = 540, Type = "Frost Free", Description = "VitaFresh technology for longer freshness", RentalPricePerMonth = 780.0, ImageUrl = fridgeImages[20], AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 22, Brand = "Smeg", Model = "FAB32", CapacityLiters = 320, Type = "Retro Style", Description = "50s style retro design with modern features", RentalPricePerMonth = 850.0, ImageUrl = fridgeImages[21], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 23, Brand = "Kelvinator", Model = "KRF320", CapacityLiters = 320, Type = "Top Mount", Description = "Energy efficient with glass shelves", RentalPricePerMonth = 460.0, ImageUrl = fridgeImages[22], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 24, Brand = "Siemens", Model = "KG49", CapacityLiters = 410, Type = "Bottom Freezer", Description = "NoFrost technology with hyperFresh", RentalPricePerMonth = 690.0, ImageUrl = fridgeImages[23], AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 25, Brand = "Haier", Model = "HRF520", CapacityLiters = 520, Type = "French Door", Description = "Triple cooling system with humidity control", RentalPricePerMonth = 720.0, ImageUrl = fridgeImages[24], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 26, Brand = "Hisense", Model = "H280BI", CapacityLiters = 280, Type = "Single Door", Description = "Compact design perfect for small spaces", RentalPricePerMonth = 380.0, ImageUrl = fridgeImages[25], AvailabilityStatus = "Available", Location = "Bloemfontein" },
                new Fridge { FridgeId = 27, Brand = "Defy", Model = "DAC300", CapacityLiters = 300, Type = "Top Freezer", Description = "Economical and reliable performance", RentalPricePerMonth = 420.0, ImageUrl = fridgeImages[26], AvailabilityStatus = "Rented", Location = "Durban" },
                new Fridge { FridgeId = 28, Brand = "LG", Model = "GL-S282", CapacityLiters = 282, Type = "Single Door", Description = "Smart inverter with door cooling", RentalPricePerMonth = 490.0, ImageUrl = fridgeImages[27], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 29, Brand = "Samsung", Model = "RT22A", CapacityLiters = 220, Type = "Single Door", Description = "Compact fridge with digital inverter", RentalPricePerMonth = 410.0, ImageUrl = fridgeImages[28], AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 30, Brand = "Whirlpool", Model = "WDE280", CapacityLiters = 280, Type = "Top Freezer", Description = "6th sense technology in compact size", RentalPricePerMonth = 440.0, ImageUrl = fridgeImages[29], AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 31, Brand = "Bosch", Model = "KDN32", CapacityLiters = 320, Type = "Frost Free", Description = "VitaFresh pro for optimal food storage", RentalPricePerMonth = 580.0, ImageUrl = fridgeImages[30], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 32, Brand = "Smeg", Model = "FAB50", CapacityLiters = 500, Type = "Retro Style", Description = "Large capacity retro fridge", RentalPricePerMonth = 920.0, ImageUrl = fridgeImages[31], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 33, Brand = "Kelvinator", Model = "KRF400", CapacityLiters = 400, Type = "Bottom Freezer", Description = "Spacious design with efficient cooling", RentalPricePerMonth = 540.0, ImageUrl = fridgeImages[32], AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 34, Brand = "Siemens", Model = "KG42", CapacityLiters = 385, Type = "Bottom Freezer", Description = "hyperFresh plus with NoFrost", RentalPricePerMonth = 670.0, ImageUrl = fridgeImages[33], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 35, Brand = "Haier", Model = "HRF380", CapacityLiters = 380, Type = "Double Door", Description = "Triple cooling with HCS technology", RentalPricePerMonth = 590.0, ImageUrl = fridgeImages[34], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 36, Brand = "Hisense", Model = "H520BI", CapacityLiters = 520, Type = "French Door", Description = "Smart cooling with WiFi connectivity", RentalPricePerMonth = 780.0, ImageUrl = fridgeImages[35], AvailabilityStatus = "Rented", Location = "Johannesburg" },
                new Fridge { FridgeId = 37, Brand = "Defy", Model = "DAC450", CapacityLiters = 450, Type = "Side by Side", Description = "Water and ice dispenser with LED display", RentalPricePerMonth = 650.0, ImageUrl = fridgeImages[36], AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 38, Brand = "LG", Model = "GL-F422", CapacityLiters = 422, Type = "French Door", Description = "InstaView door-in-door technology", RentalPricePerMonth = 820.0, ImageUrl = fridgeImages[37], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 39, Brand = "Samsung", Model = "RT45A", CapacityLiters = 450, Type = "French Door", Description = "Twin cooling plus with metal cooling", RentalPricePerMonth = 760.0, ImageUrl = fridgeImages[38], AvailabilityStatus = "Rented", Location = "Durban" },
                new Fridge { FridgeId = 40, Brand = "Whirlpool", Model = "WDE600", CapacityLiters = 600, Type = "French Door", Description = "Large capacity with 6th sense dual cool", RentalPricePerMonth = 880.0, ImageUrl = fridgeImages[39], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 41, Brand = "Bosch", Model = "KDN86", CapacityLiters = 635, Type = "Side by Side", Description = "VitaFresh pro with dual compressors", RentalPricePerMonth = 950.0, ImageUrl = fridgeImages[40], AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 42, Brand = "Smeg", Model = "FAB36", CapacityLiters = 360, Type = "Retro Style", Description = "Classic design with modern features", RentalPricePerMonth = 780.0, ImageUrl = fridgeImages[41], AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 43, Brand = "Kelvinator", Model = "KRF280", CapacityLiters = 280, Type = "Top Mount", Description = "Compact and energy efficient", RentalPricePerMonth = 420.0, ImageUrl = fridgeImages[42], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 44, Brand = "Siemens", Model = "KG56", CapacityLiters = 530, Type = "Bottom Freezer", Description = "hyperFresh with perfect results", RentalPricePerMonth = 740.0, ImageUrl = fridgeImages[43], AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 45, Brand = "Haier", Model = "HRF260", CapacityLiters = 260, Type = "Single Door", Description = "Compact design with HCS technology", RentalPricePerMonth = 380.0, ImageUrl = fridgeImages[44], AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 46, Brand = "Hisense", Model = "H380BI", CapacityLiters = 380, Type = "Bottom Freezer", Description = "Smart features with efficient cooling", RentalPricePerMonth = 550.0, ImageUrl = fridgeImages[45], AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 47, Brand = "Defy", Model = "DAC550", CapacityLiters = 550, Type = "French Door", Description = "Premium cooling with advanced features", RentalPricePerMonth = 720.0, ImageUrl = fridgeImages[46], AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 48, Brand = "LG", Model = "GL-M422", CapacityLiters = 422, Type = "Bottom Freezer", Description = "Door cooling+ with linear cooling", RentalPricePerMonth = 680.0, ImageUrl = fridgeImages[47], AvailabilityStatus = "Rented", Location = "Johannesburg" }
            );
        }

        private static void SeedFridgeInStocks(ModelBuilder modelBuilder)
        {
            var fridgeInStocks = new List<FridgeInStock>();
            var fridgeIds = Enumerable.Range(1, 48).ToArray(); // Now includes 1-48
            var conditions = new[] { "Excellent", "Good", "Very Good", "Excellent", "Good" };
            var locations = new[] { "Durban Warehouse", "Johannesburg Main", "Cape Town Storage", "Pretoria Facility", "Port Elizabeth Depot" };

            var idCounter = 1;
            var random = new Random();

            foreach (var fridgeId in fridgeIds)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var isAvailable = random.Next(0, 2) == 1;
                    fridgeInStocks.Add(new FridgeInStock
                    {
                        FridgeInStockId = idCounter,
                        FridgeNo = $"FRG-{fridgeId:000}-{i:000}",
                        LastMaintenanceDate = DateTime.Now.AddMonths(-random.Next(0, 6)),
                        Condition = conditions[random.Next(conditions.Length)],
                        IsAvailable = isAvailable,
                        Quantity = 1,
                        Location = locations[random.Next(locations.Length)],
                        FridgeId = fridgeId
                    });
                    idCounter++;
                }
            }

            modelBuilder.Entity<FridgeInStock>().HasData(fridgeInStocks);
        }

        private static void SeedBusinessInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessInfo>().HasData(
                new BusinessInfo { BusinessID = 1, BusinessName = "FridgeHub Enterprises", RegistrationNumber = "2024FH001", BusinessType = "Fridge Rental", Industry = "Appliance Rental", Email = "info@gmail.com", PhoneNumber = "0111234567", Website = "www.fridgehub.com", Address = "123 Main Street", City = "Johannesburg", Country = "South Africa", PostalCode = "2000", CreatedAt = DateTime.Now.AddYears(-2) },
                new BusinessInfo { BusinessID = 2, BusinessName = "Cool Solutions SA", RegistrationNumber = "2023CS002", BusinessType = "Appliance Services", Industry = "Maintenance Services", Email = "admin@coolsolutions.co.za", PhoneNumber = "0219876543", Website = "www.coolsolutions.co.za", Address = "456 Service Road", City = "Cape Town", Country = "South Africa", PostalCode = "8001", CreatedAt = DateTime.Now.AddYears(-1) },
                new BusinessInfo { BusinessID = 3, BusinessName = "Fridge Rentals Durban", RegistrationNumber = "2024FR003", BusinessType = "Rental Services", Industry = "Appliance Rental", Email = "rentals@fridgedurban.co.za", PhoneNumber = "0315551234", Website = "www.fridgedurban.co.za", Address = "789 Coastal Road", City = "Durban", Country = "South Africa", PostalCode = "4001", CreatedAt = DateTime.Now.AddMonths(-6) },
                new BusinessInfo { BusinessID = 4, BusinessName = "Pretoria Cooling Systems", RegistrationNumber = "2023PCS004", BusinessType = "HVAC Services", Industry = "Cooling Systems", Email = "info@pretoriacooling.co.za", PhoneNumber = "0124445678", Website = "www.pretoriacooling.co.za", Address = "321 Capital Avenue", City = "Pretoria", Country = "South Africa", PostalCode = "0002", CreatedAt = DateTime.Now.AddYears(-1) },
                new BusinessInfo { BusinessID = 5, BusinessName = "Eastern Cape Appliances", RegistrationNumber = "2024ECA005", BusinessType = "Appliance Retail", Industry = "Retail", Email = "sales@ecappliances.co.za", PhoneNumber = "0413337890", Website = "www.ecappliances.co.za", Address = "654 Ocean View", City = "Port Elizabeth", Country = "South Africa", PostalCode = "6001", CreatedAt = DateTime.Now.AddMonths(-8) },
                new BusinessInfo { BusinessID = 6, BusinessName = "Free State Cooling", RegistrationNumber = "2023FSC006", BusinessType = "Cooling Solutions", Industry = "HVAC Services", Email = "contact@fscooling.co.za", PhoneNumber = "0512224567", Website = "www.fscooling.co.za", Address = "987 Central Street", City = "Bloemfontein", Country = "South Africa", PostalCode = "9301", CreatedAt = DateTime.Now.AddYears(-1) },
                new BusinessInfo { BusinessID = 7, BusinessName = "Mpumalanga Fridge Rentals", RegistrationNumber = "2024MFR007", BusinessType = "Rental Services", Industry = "Appliance Rental", Email = "info@mpumalangafridges.co.za", PhoneNumber = "0131112345", Website = "www.mpumalangafridges.co.za", Address = "147 Highlands Road", City = "Nelspruit", Country = "South Africa", PostalCode = "1200", CreatedAt = DateTime.Now.AddMonths(-4) },
                new BusinessInfo { BusinessID = 8, BusinessName = "Limpopo Cooling Experts", RegistrationNumber = "2023LCE008", BusinessType = "Technical Services", Industry = "Cooling Systems", Email = "support@limpopocooling.co.za", PhoneNumber = "0156667890", Website = "www.limpopocooling.co.za", Address = "258 Bushveld Street", City = "Polokwane", Country = "South Africa", PostalCode = "0700", CreatedAt = DateTime.Now.AddYears(-1) },
                new BusinessInfo { BusinessID = 9, BusinessName = "Northern Cape Appliances", RegistrationNumber = "2024NCA009", BusinessType = "Appliance Sales", Industry = "Retail", Email = "sales@ncappliances.co.za", PhoneNumber = "0537771234", Website = "www.ncappliances.co.za", Address = "369 Diamond Road", City = "Kimberley", Country = "South Africa", PostalCode = "8301", CreatedAt = DateTime.Now.AddMonths(-10) },
                new BusinessInfo { BusinessID = 10, BusinessName = "North West Cooling Solutions", RegistrationNumber = "2023NWC010", BusinessType = "Cooling Services", Industry = "HVAC Services", Email = "info@nwcooling.co.za", PhoneNumber = "0148884567", Website = "www.nwcooling.co.za", Address = "741 Platinum Avenue", City = "Rustenburg", Country = "South Africa", PostalCode = "2999", CreatedAt = DateTime.Now.AddYears(-1) },
                new BusinessInfo { BusinessID = 11, BusinessName = "KZN Appliance Rentals", RegistrationNumber = "2024KZNR011", BusinessType = "Rental Services", Industry = "Appliance Rental", Email = "rentals@kznappliances.co.za", PhoneNumber = "0338885678", Website = "www.kznappliances.co.za", Address = "852 Coastal Highway", City = "Pietermaritzburg", Country = "South Africa", PostalCode = "3201", CreatedAt = DateTime.Now.AddMonths(-3) },
                new BusinessInfo { BusinessID = 12, BusinessName = "Gauteng Cooling Systems", RegistrationNumber = "2023GCS012", BusinessType = "Technical Services", Industry = "Cooling Systems", Email = "service@gautengcooling.co.za", PhoneNumber = "0119992345", Website = "www.gautengcooling.co.za", Address = "963 Metro Road", City = "Johannesburg", Country = "South Africa", PostalCode = "2001", CreatedAt = DateTime.Now.AddYears(-2) }
            );
        }

        private static void SeedRequestHeaders(ModelBuilder modelBuilder)
        {
            var requestHeaders = new List<RequestHeader>();
            var random = new Random();
            var statuses = new[] { SD.Pending, SD.Approved, SD.Rejected, SD.Shipped, SD.Closed };
            var rejectionReasons = new[] {
                "Incomplete business documentation provided",
                "Credit check failed",
                "Required additional verification documents",
                "Business registration not valid",
                "Payment method not approved",
                "Customer history requires review",
                "Document verification pending",
                "Business type not supported"
            };
            var cities = new[] { "Johannesburg", "Cape Town", "Durban", "Pretoria", "Port Elizabeth", "Bloemfontein" };
            var streets = new[] { "Main Street", "Service Road", "Business Avenue", "Commerce Road", "Trade Street" };

            // Valid Employee IDs (1-12)
            var validEmployeeIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            for (int i = 1; i <= 15; i++)
            {
                var customerId = (i % 12) + 1;
                var status = statuses[random.Next(statuses.Length)];
                var requestDate = DateTime.Now.AddDays(-random.Next(1, 90));
                var isRejected = status == SD.Rejected;
                var rejectionDate = isRejected ? requestDate.AddDays(random.Next(1, 5)) : (DateTime?)null;
                var rejectionReason = isRejected ? rejectionReasons[random.Next(rejectionReasons.Length)] : null;

                requestHeaders.Add(new RequestHeader
                {
                    RequestHeaderId = i,
                    CustomerID = customerId,
                    EmployeeID = validEmployeeIds[random.Next(validEmployeeIds.Length)],
                    RequestDate = requestDate,
                    RequestTotal = random.Next(400, 1500),
                    FirstName = $"Customer{i}",
                    LastName = $"LastName{i}",
                    StreetAddress = $"{random.Next(1, 999)} {streets[random.Next(streets.Length)]}",
                    City = cities[random.Next(cities.Length)],
                    State = "Province",
                    PostalCode = $"{random.Next(1000, 9999)}",
                    CellNumber = $"0{random.Next(10, 99)}{random.Next(1000000, 9999999)}",
                    Status = status,
                    DeliveryDate = status == SD.Shipped || status == SD.Closed ? requestDate.AddDays(random.Next(1, 10)) : null,
                    PaymentDueDate = status == SD.Shipped || status == SD.Closed ? requestDate.AddDays(30) : null,
                    RejectionReason = rejectionReason,
                    RejectionDate = rejectionDate
                });
            }

            modelBuilder.Entity<RequestHeader>().HasData(requestHeaders);
        }

        private static void SeedRequestDetails(ModelBuilder modelBuilder)
        {
            var requestDetails = new List<RequestDetails>();
            var random = new Random();

            for (int i = 1; i <= 20; i++)
            {
                var requestHeaderId = (i % 15) + 1;
                var fridgeId = random.Next(1, 49); // Now 1-48
                var count = random.Next(1, 4);
                var price = random.Next(400, 800);

                requestDetails.Add(new RequestDetails
                {
                    RequestDetailId = i,
                    RequestHeaderId = requestHeaderId,
                    FridgeId = fridgeId,
                    Count = count,
                    Price = price
                });
            }

            modelBuilder.Entity<RequestDetails>().HasData(requestDetails);
        }
        private static void SeedCustomerFridges(ModelBuilder modelBuilder)
        {
            var customerFridges = new List<CustomerFridge>();
            var random = new Random();

            // Valid IDs for each foreign key
            var validFridgeIds = Enumerable.Range(1, 48).ToArray(); // Now 1-48
            var validFridgeInStockIds = Enumerable.Range(1, 480).ToArray(); // 1-480 (48 fridges × 10 each)
            var validCustomerIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var validRequestDetailIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            for (int i = 1; i <= 25; i++)
            {
                var reservedDate = DateTime.Now.AddDays(-random.Next(1, 60));
                var allocatedDate = random.Next(0, 2) == 1 ? reservedDate.AddDays(random.Next(1, 7)) : (DateTime?)null;

                customerFridges.Add(new CustomerFridge
                {
                    CustomerFridgeId = i,
                    FridgeId = validFridgeIds[random.Next(validFridgeIds.Length)],
                    FridgeInStockId = validFridgeInStockIds[random.Next(validFridgeInStockIds.Length)],
                    CustomerID = validCustomerIds[random.Next(validCustomerIds.Length)],
                    ReservedDate = reservedDate,
                    AllocatedDate = allocatedDate,
                    RequestDetailId = validRequestDetailIds[random.Next(validRequestDetailIds.Length)]
                });
            }

            modelBuilder.Entity<CustomerFridge>().HasData(customerFridges);
        }
        private static void SeedFridgeVisits(ModelBuilder modelBuilder)
        {
            var fridgeVisits = new List<FridgeVisit>();
            var random = new Random();
            var checkupStatuses = new[] { "Passed", "Failed", "In Progress", "Not Started" };
            var technicianNames = new[] { "Robert Davis", "Jennifer Martin", "James Miller", "Patricia White" };

            for (int i = 1; i <= 20; i++)
            {
                var visitDate = DateTime.Now.AddDays(-random.Next(1, 30));
                var checkupStatus = checkupStatuses[random.Next(checkupStatuses.Length)];

                fridgeVisits.Add(new FridgeVisit
                {
                    VisitId = i,
                    VisitDate = visitDate,
                    TechnicianName = technicianNames[random.Next(technicianNames.Length)],
                    Notes = $"Visit notes for service {i}. Checkup completed with status: {checkupStatus}",
                    CustomerApproval = random.Next(0, 2) == 1 ? SD.Approved : SD.Pending,
                    CheckupStatus = checkupStatus,
                    RequestHeaderId = random.Next(1, 16),
                    VisitType = "Maintenance Check",
                    Status = SD.Pending,
                    CreatedDate = visitDate.AddDays(-1)
                });
            }

            modelBuilder.Entity<FridgeVisit>().HasData(fridgeVisits);
        }

        private static void SeedFaultReports(ModelBuilder modelBuilder)
        {
            var faultReports = new List<FaultReport>();
            var random = new Random();
            var faultTypes = new[] { "Not Cooling", "Strange Noises", "Water Leakage", "Electrical Issues", "Door Problems" };
            var priorities = new[] { "Low", "Medium", "High", "Critical" };
            var statuses = new[] { "Reported", "In Progress", "Resolved", "Declined" };

            for (int i = 1; i <= 15; i++)
            {
                var reportedDate = DateTime.Now.AddDays(-random.Next(1, 45));

                faultReports.Add(new FaultReport
                {
                    FaultReportId = i,
                    CustomerId = random.Next(1, 13),
                    FridgeInStockId = random.Next(1, 151),
                    FaultType = faultTypes[random.Next(faultTypes.Length)],
                    Description = $"Fault description for report {i}. Issue requires attention.",
                    Priority = priorities[random.Next(priorities.Length)],
                    Status = statuses[random.Next(statuses.Length)],
                    ReportedDate = reportedDate,
                    ImageUrl = $"/Images/Faults/fault-{i}.jpg",
                    RequestReplacement = random.Next(0, 2) == 1,
                    IsReplacementRequested = random.Next(0, 2) == 1
                });
            }

            modelBuilder.Entity<FaultReport>().HasData(faultReports);
        }

        private static void SeedFaultTechnicians(ModelBuilder modelBuilder)
        {
            var faultTechnicians = new List<FaultTechnician>();
            var random = new Random();
            var repairStatuses = new[] { "Not Started", "In Progress", "Completed", "Scrapped", "Resolved" };
            var technicians = new[] { "James Miller", "Patricia White", "Robert Davis", "Jennifer Martin" };
            var bookingStatuses = new[] { SD.Pending, SD.Approved, SD.Declined };

            // Valid Visit IDs (1-20)
            var validVisitIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            // Valid FaultReport IDs (1-15)
            var validFaultReportIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            for (int i = 1; i <= 15; i++)
            {
                var reportDate = DateTime.Now.AddDays(-random.Next(1, 30));
                var bookingDate = random.Next(0, 2) == 1 ? reportDate.AddDays(random.Next(1, 14)) : (DateTime?)null;

                faultTechnicians.Add(new FaultTechnician
                {
                    FaultId = i,
                    VisitId = validVisitIds[random.Next(validVisitIds.Length)],
                    FaultType = "Technical Fault",
                    FaultDescription = $"Fault description for technician assignment {i}",
                    ResolutionNotes = random.Next(0, 2) == 1 ? $"Resolution notes for fault {i}" : null,
                    ReportDate = reportDate,
                    RepairStatus = repairStatuses[random.Next(repairStatuses.Length)],
                    TechnicianAssigned = technicians[random.Next(technicians.Length)],
                    CustomerBookingStatus = bookingStatuses[random.Next(bookingStatuses.Length)],
                    Bookingate = bookingDate,
                    FaultReportId = validFaultReportIds[random.Next(validFaultReportIds.Length)],
                    Priority = random.Next(0, 2) == 1 ? "High" : "Medium",
                    CreatedDate = reportDate
                });
            }

            modelBuilder.Entity<FaultTechnician>().HasData(faultTechnicians);
        }

        private static void SeedFridgeReplacements(ModelBuilder modelBuilder)
        {
            var fridgeReplacements = new List<FridgeReplacement>();
            var random = new Random();
            var replacementStatuses = new[] { SD.Pending, SD.Approved, SD.Rejected };
            var reasons = new[] { "Fridge Beyond Repair", "Frequent Breakdowns", "Old Age", "Customer Request" };

            // Valid ApplicationUser IDs that exist in the AspNetUsers table
            var validUserIds = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "21", "22", "23", "24", "25", "26" };

            for (int i = 1; i <= 12; i++)
            {
                var requestDate = DateTime.Now.AddDays(-random.Next(1, 60));
                var replacementDate = requestDate.AddDays(random.Next(1, 30));

                fridgeReplacements.Add(new FridgeReplacement
                {
                    FridgeReplacementId = i,
                    VisitId = random.Next(1, 21),
                    CustomerID = random.Next(1, 13),
                    NewFridgeInStockId = random.Next(1, 151),
                    OldFridgeNo = $"FRG-{random.Next(1, 16):000}-{random.Next(1, 11):000}",
                    ReasonForReplacement = reasons[random.Next(reasons.Length)],
                    AdditionalNotes = $"Additional notes for replacement request {i}",
                    ReplacementDate = replacementDate,
                    RequestDate = requestDate,
                    ReplacementStatus = replacementStatuses[random.Next(replacementStatuses.Length)],
                    ApplicationUserId = validUserIds[random.Next(validUserIds.Length)]
                });
            }

            modelBuilder.Entity<FridgeReplacement>().HasData(fridgeReplacements);
        }

        private static void SeedRequestNotes(ModelBuilder modelBuilder)
        {
            var requestNotes = new List<RequestNote>();
            var random = new Random();
            var noteTypes = new[] { "Internal", "Customer", "Technical", "Administrative" };

            for (int i = 1; i <= 20; i++)
            {
                var createdDate = DateTime.Now.AddDays(-random.Next(1, 90));

                requestNotes.Add(new RequestNote
                {
                    RequestNoteId = i,
                    RequestHeaderId = random.Next(1, 16),
                    NoteContent = $"Note content for request {i}. This is an important note regarding the service.",
                    NoteType = noteTypes[random.Next(noteTypes.Length)],
                    CreatedDate = createdDate
                });
            }

            modelBuilder.Entity<RequestNote>().HasData(requestNotes);
        }

        private static void SeedAllocations(ModelBuilder modelBuilder)
        {
            var allocations = new List<Allocation>();
            var random = new Random();

            for (int i = 1; i <= 15; i++)
            {
                allocations.Add(new Allocation
                {
                    AllocationId = i,
                    CustomerID = random.Next(1, 13),
                    FridgeId = random.Next(1, 49), // Now 1-48
                    Count = random.Next(1, 4)
                });
            }

            modelBuilder.Entity<Allocation>().HasData(allocations);
        }
    }
}