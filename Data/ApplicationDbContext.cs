using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<Fridge> tblFridge { get; set; }
        public DbSet<Allocation> tblAllocation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fridge>().HasData(
                new Fridge
                {
                    FridgeId = 1,
                    Brand = "Samsung",
                    FridgeNo = "FRG-001",
                    Model = "RT28T",
                    CapacityLiters = 253,
                    Type = "Double Door",
                    Description = "Energy-efficient double door fridge with frost-free technology.",
                    RentalPricePerMonth = 1200.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 15),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge1.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 900.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 10),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge2.jpg",
                    AvailabilityStatus = "Rented"
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
                    RentalPricePerMonth = 1500.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge3.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1100.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 1),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge4.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 800.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 20),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge5.jpg",
                    AvailabilityStatus = "Rented"
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
                    RentalPricePerMonth = 1600.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 15),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge6.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 700.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 25),
                    Condition = "Fair",
                    ImageUrl = "https://example.com/images/fridge7.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 2000.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge8.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1800.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 1),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge9.jpg",
                    AvailabilityStatus = "Rented"
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
                    RentalPricePerMonth = 1300.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 10),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge10.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 2200.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 5),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge11.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 2500.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 20),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge12.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1400.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 2),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge13.jpg",
                    AvailabilityStatus = "Rented"
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
                    RentalPricePerMonth = 2300.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 18),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge14.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1000.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 28),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge15.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1250.00m,
                    LastMaintenanceDate = new DateTime(2025, 3, 8),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge16.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1700.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 12),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge17.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 2400.00m,
                    LastMaintenanceDate = new DateTime(2025, 4, 7),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge18.jpg",
                    AvailabilityStatus = "Rented"
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
                    RentalPricePerMonth = 1150.00m,
                    LastMaintenanceDate = new DateTime(2025, 1, 30),
                    Condition = "Good",
                    ImageUrl = "https://example.com/images/fridge19.jpg",
                    AvailabilityStatus = "Available"
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
                    RentalPricePerMonth = 1850.00m,
                    LastMaintenanceDate = new DateTime(2025, 2, 22),
                    Condition = "Excellent",
                    ImageUrl = "https://example.com/images/fridge20.jpg",
                    AvailabilityStatus = "Available"
                }
            );
        }
    }
}

