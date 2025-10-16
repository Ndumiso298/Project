using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.ViewModel;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<Location> tblLocations { get; set; }
        public DbSet<Fridge> tblFridges { get; set; }
        public DbSet<FridgeInStock> tblFridgeInStocks { get; set; }
        public DbSet<PurchaseRequest> tblPurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItem> tblPurchaseRequestItems { get; set; }
        public DbSet<Allocation> tblAllocations { get; set; }
        public DbSet<RequestHeader> tblRequestHeaders { get; set; }
        public DbSet<RequestDetails> tblRequestDetais { get; set; }
        public DbSet<Fault> tblFaults { get; set; }
        public DbSet<ProcessFault> tblProcessFaults { get; set; }
        public DbSet<Customer> tblCustomers { get; set; }
        public DbSet<Employee> tblEmployees { get; set; }
        public DbSet<Supplier> tblSuppliers { get; set; }
        public DbSet<FaultTechnician> tblFaultTechnicians { get; set; }
        public DbSet<MaintenanceVisit> tblMaintenanceVisits { get; set; }
        public DbSet<MaintenanceRecord> tblMaintenanceRecords { get; set; }
        public DbSet<FridgeRequest> tblFridgeRequests { get; set; }
        public DbSet<FridgeVisit> tblFridgeVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FridgeInStock>()
                .HasOne(fis => fis.Fridge)
                .WithMany(f => f.FridgeInstances)
                .HasForeignKey(fis => fis.FridgeId)
                .OnDelete(DeleteBehavior.Restrict);

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

            new Fridge
            {
                FridgeId = 1,
                Brand = "Samsung",
                FridgeNo = "FRG-001",
                Model = "RT28T",
                CapacityLiters = 253,
                Type = "Double Door",
                Description = "Energy-efficient double door fridge with frost-free technology.",
                RentalPricePerMonth = 1200.00,
                LastMaintenanceDate = new DateTime(2025, 1, 15),
                Condition = "Excellent",
                ImageUrl = "https://example.com/images/fridge1.jpg",
                Status = "Available",
                Location = "Available"
            },
                new Fridge
                {
                    FridgeId = 2,
                    Brand = "LG",
                    FridgeNo = "FRG-002",
                    Model = "GL-B201",
                    CapacityLiters = 190,
                    Type = "Single Door",
                    Description = "Compact single door fridge ideal for small apartments.",
                    RentalPricePerMonth = 900.00,
                    LastMaintenanceDate = new DateTime(2025, 3, 10),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge2.jpg",
                    Status = "Rented",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 3,
                    Brand = "Whirlpool",
                    FridgeNo = "FRG-003",
                    Model = "WRT518",
                    CapacityLiters = 500,
                    Type = "Double Door",
                    Description = "Spacious fridge with advanced cooling technology.",
                    RentalPricePerMonth = 1500.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge3.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 4,
                    Brand = "Defy",
                    FridgeNo = "FRG-004",
                    Model = "DAC700",
                    CapacityLiters = 350,
                    Type = "Double Door",
                    Description = "Durable fridge with energy-saving features.",
                    RentalPricePerMonth = 1100.00,
                    LastMaintenanceDate = new DateTime(2025, 4, 1),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge4.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 5,
                    Brand = "Hisense",
                    FridgeNo = "FRG-005",
                    Model = "H310BI",
                    CapacityLiters = 310,
                    Type = "Single Door",
                    Description = "Compact fridge with adjustable shelves.",
                    RentalPricePerMonth = 800.00,
                    LastMaintenanceDate = new DateTime(2025, 1, 20),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge5.jpg",
                    Status = "Rented",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 6,
                    Brand = "Bosch",
                    FridgeNo = "FRG-006",
                    Model = "KDN42",
                    CapacityLiters = 420,
                    Type = "Double Door",
                    Description = "Premium fridge with no-frost technology.",
                    RentalPricePerMonth = 1600.00,
                    LastMaintenanceDate = new DateTime(2025, 3, 15),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge6.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 7,
                    Brand = "Kelvinator",
                    FridgeNo = "FRG-007",
                    Model = "KEL250",
                    CapacityLiters = 250,
                    Type = "Single Door",
                    Description = "Affordable fridge with basic features.",
                    RentalPricePerMonth = 700.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 25),
                    Condition = "Fair",
                    ImageUrl = "https://example.com/images/fridge7.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 8,
                    Brand = "Smeg",
                    FridgeNo = "FRG-008",
                    Model = "FAB28",
                    CapacityLiters = 281,
                    Type = "Single Door",
                    Description = "Retro-style fridge with modern cooling.",
                    RentalPricePerMonth = 2000.00,
                    LastMaintenanceDate = new DateTime(2025, 4, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge8.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 9,
                    Brand = "AEG",
                    FridgeNo = "FRG-009",
                    Model = "SKE818",
                    CapacityLiters = 300,
                    Type = "Single Door",
                    Description = "Built-in fridge with adjustable compartments.",
                    RentalPricePerMonth = 1800.00,
                    LastMaintenanceDate = new DateTime(2025, 3, 1),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge9.jpg",
                    Status = "Rented",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 10,
                    Brand = "Panasonic",
                    FridgeNo = "FRG-010",
                    Model = "NR-BL347",
                    CapacityLiters = 347,
                    Type = "Double Door",
                    Description = "Fridge with inverter technology for energy saving.",
                    RentalPricePerMonth = 1300.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 10),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge10.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 11,
                    Brand = "Haier",
                    FridgeNo = "FRG-011",
                    Model = "HRF-619",
                    CapacityLiters = 565,
                    Type = "Side by Side",
                    Description = "Large capacity fridge with twin inverter technology.",
                    RentalPricePerMonth = 2200.00,
                    LastMaintenanceDate = new DateTime(2025, 1, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge11.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 12,
                    Brand = "Hitachi",
                    FridgeNo = "FRG-012",
                    Model = "R-WB640",
                    CapacityLiters = 640,
                    Type = "French Door",
                    Description = "Premium French door fridge with eco-friendly features.",
                    RentalPricePerMonth = 2500.00,
                    LastMaintenanceDate = new DateTime(2025, 3, 20),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge12.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 13,
                    Brand = "Electrolux",
                    FridgeNo = "FRG-013",
                    Model = "ETB3700",
                    CapacityLiters = 370,
                    Type = "Top Freezer",
                    Description = "Fridge with taste guard deodorizer.",
                    RentalPricePerMonth = 1400.00,
                    LastMaintenanceDate = new DateTime(2025, 4, 2),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge13.jpg",
                    Status = "Rented",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 14,
                    Brand = "Sharp",
                    FridgeNo = "FRG-014",
                    Model = "SJ-GX60",
                    CapacityLiters = 600,
                    Type = "French Door",
                    Description = "Fridge with plasmacluster ion technology.",
                    RentalPricePerMonth = 2300.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 18),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge14.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 15,
                    Brand = "Midea",
                    FridgeNo = "FRG-015",
                    Model = "HD-400",
                    CapacityLiters = 400,
                    Type = "Double Door",
                    Description = "Affordable fridge with large freezer compartment.",
                    RentalPricePerMonth = 1000.00,
                    LastMaintenanceDate = new DateTime(2025, 1, 28),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge15.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 16,
                    Brand = "Gorenje",
                    FridgeNo = "FRG-016",
                    Model = "NRK6192",
                    CapacityLiters = 326,
                    Type = "Bottom Freezer",
                    Description = "Stylish bottom freezer fridge with crisp zone for vegetables.",
                    RentalPricePerMonth = 1250.00,
                    LastMaintenanceDate = new DateTime(2025, 3, 8),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge16.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 17,
                    Brand = "Westinghouse",
                    FridgeNo = "FRG-017",
                    Model = "WBE5300",
                    CapacityLiters = 528,
                    Type = "Top Freezer",
                    Description = "Family-sized fridge with humidity-controlled crisper.",
                    RentalPricePerMonth = 1700.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 12),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge17.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 18,
                    Brand = "Fisher & Paykel",
                    FridgeNo = "FRG-018",
                    Model = "RF522",
                    CapacityLiters = 519,
                    Type = "French Door",
                    Description = "Premium French door fridge with active smart technology.",
                    RentalPricePerMonth = 2400.00,
                    LastMaintenanceDate = new DateTime(2025, 4, 7),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge18.jpg",
                    Status = "Rented",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 19,
                    Brand = "Ariston",
                    FridgeNo = "FRG-019",
                    Model = "MBA3832",
                    CapacityLiters = 383,
                    Type = "Top Freezer",
                    Description = "Reliable fridge with antibacterial coating.",
                    RentalPricePerMonth = 1150.00,
                    LastMaintenanceDate = new DateTime(2025, 1, 30),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge19.jpg",
                    Status = "Available",
                    Location = "Available"
                },
                new Fridge
                {
                    FridgeId = 20,
                    Brand = "Beko",
                    FridgeNo = "FRG-020",
                    Model = "RCNE560",
                    CapacityLiters = 560,
                    Type = "Bottom Freezer",
                    Description = "Spacious bottom freezer fridge with NeoFrost cooling.",
                    RentalPricePerMonth = 1850.00,
                    LastMaintenanceDate = new DateTime(2025, 2, 22),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge20.jpg",
                    Status = "Available",
                    Location = "Available"
                }
            ) ;
        }
    }
}