using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Project.Models;
using Project.Utility;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<Fridge> tblFridges { get; set; }
        public DbSet<FridgeInStock> tblFridgeInStocks { get; set; }
        public DbSet<Allocation> tblAllocations { get; set; }
        public DbSet<RequestHeader> tblRequestHeaders { get; set; }
        public DbSet<RequestDetails> tblRequestDetais { get; set; }
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<FaultTechnician> tblFaultTechnicians { get; set; }
        public DbSet<FridgeVisit> tblFridgeVisits { get; set; }
        public DbSet<CustomerFridge> tblCustomerFridge { get; set; }
        public DbSet<BusinessInfo> tblBusinessInfo { get; set; }
        public DbSet<FaultReport> tblFaultReports { get; set; }
        public DbSet<RequestNote> tblRequestNotes { get; set; }
        public DbSet<CustomerFeedback> tblCustomerFeedbacks { get; set; }
        public DbSet<BookingNotification> tblBookingNotifications { get; set; }
        public DbSet<RebookingNotification> tblRebookingNotifications { get; set; }
        public DbSet<FaultImage> tblFaultImages { get; set; }
   





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Identity entities
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
                entity.HasOne(c => c.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<Customer>(c => c.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.HasOne(e => e.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<Employee>(e => e.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Fridge
            modelBuilder.Entity<Fridge>(entity =>
            {
                entity.HasKey(e => e.FridgeId);
            });

            // Configure FridgeInStock
            modelBuilder.Entity<FridgeInStock>(entity =>
            {
                entity.HasKey(e => e.FridgeInStockId);
                entity.HasOne(fis => fis.Fridge)
                    .WithMany(f => f.FridgeInstances)
                    .HasForeignKey(fis => fis.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure CustomerFridge
            modelBuilder.Entity<CustomerFridge>(entity =>
            {
                entity.HasKey(e => e.CustomerFridgeId);
                entity.HasOne(cf => cf.Customer)
                    .WithMany()
                    .HasForeignKey(cf => cf.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(cf => cf.FridgeInStock)
                    .WithMany()
                    .HasForeignKey(cf => cf.FridgeInStockId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(cf => cf.Fridge)
                    .WithMany()
                    .HasForeignKey(cf => cf.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestHeader
            modelBuilder.Entity<RequestHeader>(entity =>
            {
                entity.HasKey(e => e.RequestHeaderId);
                entity.HasOne(r => r.Customer)
                    .WithMany()
                    .HasForeignKey(r => r.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Employee)
                    .WithMany()
                    .HasForeignKey(r => r.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.OriginalRequest)
                    .WithMany()
                    .HasForeignKey(r => r.OriginalRequestHeaderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestDetails
            modelBuilder.Entity<RequestDetails>(entity =>
            {
                entity.HasKey(e => e.RequestDetailId);
                entity.HasOne(rd => rd.RequestHeader)
                    .WithMany(r => r.RequestFridges)
                    .HasForeignKey(rd => rd.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(rd => rd.Fridge)
                    .WithMany()
                    .HasForeignKey(rd => rd.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestNote
            modelBuilder.Entity<RequestNote>(entity =>
            {
                entity.HasKey(e => e.RequestNoteId);
                entity.HasOne(rn => rn.RequestHeader)
                    .WithMany()
                    .HasForeignKey(rn => rn.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure FridgeVisit
            modelBuilder.Entity<FridgeVisit>(entity =>
            {
                entity.HasKey(e => e.VisitId);
                entity.HasOne(fv => fv.RequestHeader)
                    .WithMany(r => r.FridgeVisits)
                    .HasForeignKey(fv => fv.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure FaultReport
            modelBuilder.Entity<FaultReport>(entity =>
            {
                entity.HasKey(e => e.FaultReportId);
                entity.HasOne(fr => fr.Customer)
                    .WithMany()
                    .HasForeignKey(fr => fr.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(fr => fr.FridgeInStock)
                    .WithMany()
                    .HasForeignKey(fr => fr.FridgeInStockId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(fr => fr.FaultTechnicians)
                    .WithOne(ft => ft.FaultReport)
                    .HasForeignKey(ft => ft.FaultReportId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure FaultTechnician
            modelBuilder.Entity<FaultTechnician>(entity =>
            {
                entity.HasKey(e => e.FaultId);
                entity.HasOne(ft => ft.FaultReport)
                    .WithMany(fr => fr.FaultTechnicians)
                    .HasForeignKey(ft => ft.FaultReportId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ft => ft.FridgeVisit)
                    .WithMany()
                    .HasForeignKey(ft => ft.VisitId)
                    .OnDelete(DeleteBehavior.Restrict);



                // Seed Admin User
                var hasher = new PasswordHasher<ApplicationUser>();
                var adminUser = new ApplicationUser
                {
                    Id = "admin-id-123",
                    UserName = "admin@fridgesystem.com",
                    NormalizedUserName = "ADMIN@FRIDGESYSTEM.COM",
                    Email = "admin@fridgesystem.com",
                    NormalizedEmail = "ADMIN@FRIDGESYSTEM.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "System",
                    LastName = "Administrator",
                    CellNumber = "+27123456789",
                    StreetAddress = "123 Admin Street",
                    City = "Johannesburg",
                    State = "Gauteng",
                    PostalCode = "2000",
                    Status = SD.Approved,
                    IsApproved = true
                };
                adminUser.PasswordHash = hasher.HashPassword(adminUser, "Sthandwa@97");

                modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

                // Seed Admin Role
                modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "admin-role-id-123",
                        Name = SD.AdminRole,
                        NormalizedName = SD.AdminRole.ToUpper()
                    }
                );

                // Assign Admin Role to Admin User
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "admin-role-id-123",
                        UserId = "admin-id-123"
                    }
                );

                // Seed Employee record for the admin
                modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        EmployeeID = 1,
                        ApplicationUserId = "admin-id-123",
                        EmployeeNumber = "EMP001"
                    }
                );

                // Seed Fridges
                modelBuilder.Entity<Fridge>().HasData(
                    new Fridge { FridgeId = 1, Brand = "Samsung", Model = "RT28A", CapacityLiters = 250, Type = "Double Door", Description = "Energy efficient fridge with frost-free technology", RentalPricePerMonth = 450, ImageUrl = "/Images/Fridges/0f189537-b86b-46ed-88b0-697d64518b86.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                    new Fridge { FridgeId = 2, Brand = "LG", Model = "GL-T292", CapacityLiters = 260, Type = "Top Freezer", Description = "Smart inverter compressor for energy savings", RentalPricePerMonth = 480, ImageUrl = "/Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                    new Fridge { FridgeId = 3, Brand = "Hisense", Model = "H370BI", CapacityLiters = 320, Type = "Bottom Freezer", Description = "Spacious design with humidity control", RentalPricePerMonth = 520, ImageUrl = "Images/Fridges/1bde2bd0-9345-4868-bf0e-3a568b75b45d.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                    new Fridge { FridgeId = 4, Brand = "Defy", Model = "DAC621", CapacityLiters = 350, Type = "Combi Fridge", Description = "A+ energy rated with multi-airflow system", RentalPricePerMonth = 550, ImageUrl = "Images/Fridges/3af820d9-c376-4432-8a69-db81af07350d.jpg", AvailabilityStatus = "Available", Location = "Pretoria" },
                    new Fridge { FridgeId = 5, Brand = "Whirlpool", Model = "WDE205", CapacityLiters = 200, Type = "Single Door", Description = "Compact and efficient single door fridge", RentalPricePerMonth = 400, ImageUrl = "Images/Fridges/3fab2301-7b43-489c-a5eb-a4a84e146a0c.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                    new Fridge { FridgeId = 6, Brand = "Bosch", Model = "KDN42", CapacityLiters = 350, Type = "Frost Free", Description = "No frost cooling with LED lighting", RentalPricePerMonth = 600, ImageUrl = "Images/Fridges/4ff51e2e-eb52-464d-9bd0-9b93671b7b1d.jpg", AvailabilityStatus = "Rented", Location = "Port Elizabeth" },
                    new Fridge { FridgeId = 7, Brand = "Smeg", Model = "FAB28", CapacityLiters = 270, Type = "Retro Style", Description = "Stylish retro fridge with adjustable shelves", RentalPricePerMonth = 650, ImageUrl = "Images/Fridges/5f3c62bc-b7a1-4099-8453-0562449c1eba.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                    new Fridge { FridgeId = 8, Brand = "Kelvinator", Model = "KRF265", CapacityLiters = 265, Type = "Top Mount", Description = "Affordable fridge with efficient cooling", RentalPricePerMonth = 430, ImageUrl = "Images/Fridges/06d99650-49bb-46a0-9c87-479b064e20cf.jpg.jpg", AvailabilityStatus = "Available", Location = "Cape Town" },
                    new Fridge { FridgeId = 9, Brand = "Siemens", Model = "KG36N", CapacityLiters = 360, Type = "Bottom Freezer", Description = "No frost with multi-airflow system", RentalPricePerMonth = 590, ImageUrl = "Images/Fridges/6c99da3a-7e53-4a54-a4c2-179ba50f4552.jpg", AvailabilityStatus = "Rented", Location = "Pretoria" },
                    new Fridge { FridgeId = 10, Brand = "Haier", Model = "HRF290", CapacityLiters = 290, Type = "Double Door", Description = "Toughened glass shelves and energy efficient", RentalPricePerMonth = 470, ImageUrl = "Images/Fridges/7a5c9f14-43cc-4b88-98a1-2cd4f34b355a.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                    new Fridge { FridgeId = 11, Brand = "Hisense", Model = "H310BI", CapacityLiters = 310, Type = "Top Freezer", Description = "Low noise and efficient compressor", RentalPricePerMonth = 500, ImageUrl = "Images/Fridges/7a5ef7b8-7c58-4d8e-bf27-3c1c9a911b45.jpg", AvailabilityStatus = "Available", Location = "Bloemfontein" },
                    new Fridge { FridgeId = 12, Brand = "Defy", Model = "DAC700", CapacityLiters = 420, Type = "Side by Side", Description = "LED display and water dispenser", RentalPricePerMonth = 700, ImageUrl = "Images/Fridges/8e2d92bf-c306-4688-89f5-019d76a9539b.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                    new Fridge { FridgeId = 13, Brand = "LG", Model = "GL-Q282", CapacityLiters = 282, Type = "Smart Inverter", Description = "Smart cooling with WiFi control", RentalPricePerMonth = 530, ImageUrl = "Images/Fridges/7e4c22d6-9a91-4d0c-83db-95856b2a30f0.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                    new Fridge { FridgeId = 14, Brand = "Samsung", Model = "RT34A", CapacityLiters = 340, Type = "Top Freezer", Description = "Twin cooling system for freshness", RentalPricePerMonth = 560, ImageUrl = "Images/Fridges/16eaa25a-e6ad-4584-869f-79c59db95573.jpg", AvailabilityStatus = "Rented", Location = "Pretoria" },
                    new Fridge { FridgeId = 15, Brand = "Whirlpool", Model = "WDE520", CapacityLiters = 500, Type = "Double Door", Description = "High capacity with 6th sense technology", RentalPricePerMonth = 750, ImageUrl = "Images/Fridges/33b3ec74-7862-44e1-afa0-4c4a42689a9f.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                    new Fridge { FridgeId = 16, Brand = "Bosch", Model = "KDN43", CapacityLiters = 400, Type = "Frost Free", Description = "Energy efficient and silent operation", RentalPricePerMonth = 610, ImageUrl = "Images/Fridges/59a41e73-af93-465b-a5aa-f0d7cf37fe2c.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                    new Fridge { FridgeId = 17, Brand = "Smeg", Model = "FAB32", CapacityLiters = 300, Type = "Retro Style", Description = "Vintage design with modern efficiency", RentalPricePerMonth = 670, ImageUrl = "Images/Fridges/be54bce5-b511-4946-8f3a-55ae0a65ec35.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                    new Fridge { FridgeId = 18, Brand = "Siemens", Model = "KG39N", CapacityLiters = 390, Type = "Combi Fridge", Description = "Multi-airflow and easy-clean interior", RentalPricePerMonth = 620, ImageUrl = "Images/Fridges/dff205af-9cde-4e97-876d-3b9a603e6459.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                    new Fridge { FridgeId = 19, Brand = "Haier", Model = "HRF330", CapacityLiters = 330, Type = "Bottom Freezer", Description = "Tough build and fast cooling", RentalPricePerMonth = 500, ImageUrl = "Images/Fridges/45189b3d-8e97-49b3-8c90-47ec9d6db6b9.jpg", AvailabilityStatus = "Available", Location = "Pretoria" },
                    new Fridge { FridgeId = 20, Brand = "Defy", Model = "DAC473", CapacityLiters = 473, Type = "Side by Side", Description = "Spacious and frost-free design", RentalPricePerMonth = 720, ImageUrl = "Images/Fridges/2634148d-20b9-40c2-9849-3566df69f859.jpg", AvailabilityStatus = "Rented", Location = "Durban" }
                );

                // Seed FridgeInStocks
                modelBuilder.Entity<FridgeInStock>().HasData(
                    // Fridge 1
                    new FridgeInStock { FridgeInStockId = 1, FridgeNo = "FRG001", LastMaintenanceDate = new DateTime(2025, 3, 12), Condition = "Excellent", IsAvailable = true, Location = "Durban", FridgeId = 1 },
                    new FridgeInStock { FridgeInStockId = 2, FridgeNo = "FRG002", LastMaintenanceDate = new DateTime(2025, 1, 8), Condition = "Good", IsAvailable = false, Location = "Durban", FridgeId = 1 },

                    // Fridge 2
                    new FridgeInStock { FridgeInStockId = 3, FridgeNo = "FRG003", LastMaintenanceDate = new DateTime(2025, 4, 5), Condition = "Excellent", IsAvailable = true, Location = "Johannesburg", FridgeId = 2 },
                    new FridgeInStock { FridgeInStockId = 4, FridgeNo = "FRG004", LastMaintenanceDate = new DateTime(2025, 2, 10), Condition = "Good", IsAvailable = false, Location = "Johannesburg", FridgeId = 2 },

                    // Fridge 3
                    new FridgeInStock { FridgeInStockId = 5, FridgeNo = "FRG005", LastMaintenanceDate = new DateTime(2025, 5, 20), Condition = "Fair", IsAvailable = false, Location = "Cape Town", FridgeId = 3 },
                    new FridgeInStock { FridgeInStockId = 6, FridgeNo = "FRG006", LastMaintenanceDate = new DateTime(2025, 6, 11), Condition = "Excellent", IsAvailable = true, Location = "Cape Town", FridgeId = 3 },

                    // Fridge 4
                    new FridgeInStock { FridgeInStockId = 7, FridgeNo = "FRG007", LastMaintenanceDate = new DateTime(2025, 4, 1), Condition = "Good", IsAvailable = true, Location = "Pretoria", FridgeId = 4 },
                    new FridgeInStock { FridgeInStockId = 8, FridgeNo = "FRG008", LastMaintenanceDate = new DateTime(2025, 2, 15), Condition = "Fair", IsAvailable = false, Location = "Pretoria", FridgeId = 4 },

                    // Fridge 5
                    new FridgeInStock { FridgeInStockId = 9, FridgeNo = "FRG009", LastMaintenanceDate = new DateTime(2025, 1, 30), Condition = "Good", IsAvailable = true, Location = "Durban", FridgeId = 5 },
                    new FridgeInStock { FridgeInStockId = 10, FridgeNo = "FRG010", LastMaintenanceDate = new DateTime(2025, 5, 3), Condition = "Excellent", IsAvailable = true, Location = "Durban", FridgeId = 5 },

                    // Fridge 6
                    new FridgeInStock { FridgeInStockId = 11, FridgeNo = "FRG011", LastMaintenanceDate = new DateTime(2025, 3, 19), Condition = "Good", IsAvailable = false, Location = "Port Elizabeth", FridgeId = 6 },
                    new FridgeInStock { FridgeInStockId = 12, FridgeNo = "FRG012", LastMaintenanceDate = new DateTime(2025, 6, 7), Condition = "Excellent", IsAvailable = true, Location = "Port Elizabeth", FridgeId = 6 },

                    // Fridge 7
                    new FridgeInStock { FridgeInStockId = 13, FridgeNo = "FRG013", LastMaintenanceDate = new DateTime(2025, 4, 4), Condition = "Excellent", IsAvailable = true, Location = "Johannesburg", FridgeId = 7 },
                    new FridgeInStock { FridgeInStockId = 14, FridgeNo = "FRG014", LastMaintenanceDate = new DateTime(2025, 3, 11), Condition = "Fair", IsAvailable = false, Location = "Johannesburg", FridgeId = 7 },

                    // Fridge 8
                    new FridgeInStock { FridgeInStockId = 15, FridgeNo = "FRG015", LastMaintenanceDate = new DateTime(2025, 2, 26), Condition = "Good", IsAvailable = true, Location = "Cape Town", FridgeId = 8 },
                    new FridgeInStock { FridgeInStockId = 16, FridgeNo = "FRG016", LastMaintenanceDate = new DateTime(2025, 4, 9), Condition = "Excellent", IsAvailable = false, Location = "Cape Town", FridgeId = 8 },

                    // Fridge 9
                    new FridgeInStock { FridgeInStockId = 17, FridgeNo = "FRG017", LastMaintenanceDate = new DateTime(2025, 1, 17), Condition = "Good", IsAvailable = true, Location = "Pretoria", FridgeId = 9 },
                    new FridgeInStock { FridgeInStockId = 18, FridgeNo = "FRG018", LastMaintenanceDate = new DateTime(2025, 6, 2), Condition = "Excellent", IsAvailable = false, Location = "Pretoria", FridgeId = 9 },

                    // Fridge 10
                    new FridgeInStock { FridgeInStockId = 19, FridgeNo = "FRG019", LastMaintenanceDate = new DateTime(2025, 3, 8), Condition = "Fair", IsAvailable = false, Location = "Durban", FridgeId = 10 },
                    new FridgeInStock { FridgeInStockId = 20, FridgeNo = "FRG020", LastMaintenanceDate = new DateTime(2025, 5, 13), Condition = "Excellent", IsAvailable = true, Location = "Durban", FridgeId = 10 },

                    // Fridge 11
                    new FridgeInStock { FridgeInStockId = 21, FridgeNo = "FRG021", LastMaintenanceDate = new DateTime(2025, 3, 6), Condition = "Excellent", IsAvailable = true, Location = "Bloemfontein", FridgeId = 11 },
                    new FridgeInStock { FridgeInStockId = 22, FridgeNo = "FRG022", LastMaintenanceDate = new DateTime(2025, 2, 18), Condition = "Fair", IsAvailable = false, Location = "Bloemfontein", FridgeId = 11 },

                    // Fridge 12
                    new FridgeInStock { FridgeInStockId = 23, FridgeNo = "FRG023", LastMaintenanceDate = new DateTime(2025, 5, 25), Condition = "Good", IsAvailable = false, Location = "Cape Town", FridgeId = 12 },
                    new FridgeInStock { FridgeInStockId = 24, FridgeNo = "FRG024", LastMaintenanceDate = new DateTime(2025, 6, 10), Condition = "Excellent", IsAvailable = true, Location = "Cape Town", FridgeId = 12 },

                    // Fridge 13
                    new FridgeInStock { FridgeInStockId = 25, FridgeNo = "FRG025", LastMaintenanceDate = new DateTime(2025, 1, 21), Condition = "Good", IsAvailable = true, Location = "Durban", FridgeId = 13 },
                    new FridgeInStock { FridgeInStockId = 26, FridgeNo = "FRG026", LastMaintenanceDate = new DateTime(2025, 4, 27), Condition = "Fair", IsAvailable = false, Location = "Durban", FridgeId = 13 },

                    // Fridge 14
                    new FridgeInStock { FridgeInStockId = 27, FridgeNo = "FRG027", LastMaintenanceDate = new DateTime(2025, 3, 14), Condition = "Excellent", IsAvailable = false, Location = "Pretoria", FridgeId = 14 },
                    new FridgeInStock { FridgeInStockId = 28, FridgeNo = "FRG028", LastMaintenanceDate = new DateTime(2025, 6, 20), Condition = "Good", IsAvailable = true, Location = "Pretoria", FridgeId = 14 },

                    // Fridge 15
                    new FridgeInStock { FridgeInStockId = 29, FridgeNo = "FRG029", LastMaintenanceDate = new DateTime(2025, 2, 2), Condition = "Excellent", IsAvailable = true, Location = "Johannesburg", FridgeId = 15 },
                    new FridgeInStock { FridgeInStockId = 30, FridgeNo = "FRG030", LastMaintenanceDate = new DateTime(2025, 4, 17), Condition = "Fair", IsAvailable = false, Location = "Johannesburg", FridgeId = 15 },

                    // Fridge 16
                    new FridgeInStock { FridgeInStockId = 31, FridgeNo = "FRG031", LastMaintenanceDate = new DateTime(2025, 5, 22), Condition = "Excellent", IsAvailable = true, Location = "Durban", FridgeId = 16 },
                    new FridgeInStock { FridgeInStockId = 32, FridgeNo = "FRG032", LastMaintenanceDate = new DateTime(2025, 3, 10), Condition = "Good", IsAvailable = false, Location = "Durban", FridgeId = 16 },

                    // Fridge 17
                    new FridgeInStock { FridgeInStockId = 33, FridgeNo = "FRG033", LastMaintenanceDate = new DateTime(2025, 1, 25), Condition = "Fair", IsAvailable = false, Location = "Cape Town", FridgeId = 17 },
                    new FridgeInStock { FridgeInStockId = 34, FridgeNo = "FRG034", LastMaintenanceDate = new DateTime(2025, 6, 5), Condition = "Excellent", IsAvailable = true, Location = "Cape Town", FridgeId = 17 },

                    // Fridge 18
                    new FridgeInStock { FridgeInStockId = 35, FridgeNo = "FRG035", LastMaintenanceDate = new DateTime(2025, 4, 12), Condition = "Good", IsAvailable = true, Location = "Johannesburg", FridgeId = 18 },
                    new FridgeInStock { FridgeInStockId = 36, FridgeNo = "FRG036", LastMaintenanceDate = new DateTime(2025, 2, 28), Condition = "Fair", IsAvailable = false, Location = "Johannesburg", FridgeId = 18 },

                    // Fridge 19
                    new FridgeInStock { FridgeInStockId = 37, FridgeNo = "FRG037", LastMaintenanceDate = new DateTime(2025, 5, 30), Condition = "Excellent", IsAvailable = true, Location = "Pretoria", FridgeId = 19 },
                    new FridgeInStock { FridgeInStockId = 38, FridgeNo = "FRG038", LastMaintenanceDate = new DateTime(2025, 6, 14), Condition = "Good", IsAvailable = false, Location = "Pretoria", FridgeId = 19 },

                    // Fridge 20
                    new FridgeInStock { FridgeInStockId = 39, FridgeNo = "FRG039", LastMaintenanceDate = new DateTime(2025, 1, 9), Condition = "Fair", IsAvailable = false, Location = "Durban", FridgeId = 20 },
                    new FridgeInStock { FridgeInStockId = 40, FridgeNo = "FRG040", LastMaintenanceDate = new DateTime(2025, 5, 18), Condition = "Excellent", IsAvailable = true, Location = "Durban", FridgeId = 20 }
                );
            });
        }
    }
}