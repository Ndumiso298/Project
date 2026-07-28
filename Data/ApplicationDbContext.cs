using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<FridgeReplacement> tblFridgeReplacements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FridgeInStock>()
                .HasOne(fis => fis.Fridge)
                .WithMany(f => f.FridgeInstances)
                .HasForeignKey(fis => fis.FridgeId)
                .OnDelete(DeleteBehavior.Restrict);
        
            modelBuilder.Entity<FridgeReplacement>()
                .HasOne(fr => fr.FridgeVisit)
                .WithMany() 
                .HasForeignKey(fr => fr.VisitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FridgeReplacement>()
                .HasOne(fr => fr.Customer)
                .WithMany() 
                .HasForeignKey(fr => fr.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FridgeReplacement>()
                .HasOne(fr => fr.NewFridgeInStock)
                .WithMany()
                .HasForeignKey(fr => fr.NewFridgeInStockId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RequestDetails>()
           .HasOne(rd => rd.Fridge)
           .WithMany()
           .HasForeignKey(rd => rd.FridgeId)
           .OnDelete(DeleteBehavior.Restrict);


            //// Seed Admin User
            //var hasher = new PasswordHasher<ApplicationUser>();
            //var adminUser = new ApplicationUser
            //{
            //    Id = "admin-id-123",
            //    UserName = "admin@fridgesystem.com",
            //    NormalizedUserName = "ADMIN@FRIDGESYSTEM.COM",
            //    Email = "admin@fridgesystem.com",
            //    NormalizedEmail = "ADMIN@FRIDGESYSTEM.COM",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //    FirstName = "System",
            //    LastName = "Administrator",
            //    CellNumber = "+27123456789",
            //    StreetAddress = "123 Admin Street",
            //    City = "Johannesburg",
            //    State = "Gauteng",
            //    PostalCode = "2000",
            //    Status = SD.Approved,
            //    IsApproved = true
            //};
            //adminUser.PasswordHash = hasher.HashPassword(adminUser, "Sthandwa@97");

            //modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            //// Seed Admin Role
            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Id = "admin-role-id-123",
            //        Name = SD.AdminRole,
            //        NormalizedName = SD.AdminRole.ToUpper()
            //    }
            //);

            //// Assign Admin Role to Admin User
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "admin-role-id-123",
            //        UserId = "admin-id-123"
            //    }
            //);

            //// Seed Employee record for the admin
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        EmployeeID = 1,
            //        ApplicationUserId = "admin-id-123",
            //        EmployeeNumber = "EMP001"
            //    }
            //);

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

          
        }
    }
}