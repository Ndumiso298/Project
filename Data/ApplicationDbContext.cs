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
        public DbSet<Fridge> tblFridges { get; set; }
        public DbSet<FridgeInStock> tblFridgeInStocks { get; set; }
        public DbSet<Allocation> tblAllocations { get; set; }
        public DbSet<RequestHeader> tblRequestHeaders { get; set; }
        public DbSet<RequestDetails> tblRequestDetais { get; set; }
        public DbSet<Fault> tblFaults { get; set; }
        public DbSet<ProcessFault> tblProcessFaults { get; set; }
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<FaultTechnician> tblFaultTechnicians { get; set; }
        public DbSet<MaintenanceVisit> tblMaintenanceVisits { get; set; }
        public DbSet<MaintenanceRecord> tblMaintenanceRecords { get; set; }
        public DbSet<FridgeRequest> tblFridgeRequests { get; set; }
        public DbSet<FridgeVisit> tblFridgeVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure FridgeInStock relationship
            modelBuilder.Entity<FridgeInStock>()
                .HasOne(fis => fis.Fridge)
                .WithMany(f => f.FridgeInstances)
                .HasForeignKey(fis => fis.FridgeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Fridges
            modelBuilder.Entity<Fridge>().HasData(
                new Fridge { FridgeId = 1, Brand = "Samsung", Model = "RT28A", CapacityLiters = 250, Type = "Double Door", Description = "Energy efficient fridge with frost-free technology", RentalPricePerMonth = 450, ImageUrl = "/images/samsung_rt28a.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 2, Brand = "LG", Model = "GL-T292", CapacityLiters = 260, Type = "Top Freezer", Description = "Smart inverter compressor for energy savings", RentalPricePerMonth = 480, ImageUrl = "/images/lg_glt292.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 3, Brand = "Hisense", Model = "H370BI", CapacityLiters = 320, Type = "Bottom Freezer", Description = "Spacious design with humidity control", RentalPricePerMonth = 520, ImageUrl = "/images/hisense_h370bi.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 4, Brand = "Defy", Model = "DAC621", CapacityLiters = 350, Type = "Combi Fridge", Description = "A+ energy rated with multi-airflow system", RentalPricePerMonth = 550, ImageUrl = "/images/defy_dac621.jpg", AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 5, Brand = "Whirlpool", Model = "WDE205", CapacityLiters = 200, Type = "Single Door", Description = "Compact and efficient single door fridge", RentalPricePerMonth = 400, ImageUrl = "/images/whirlpool_wde205.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 6, Brand = "Bosch", Model = "KDN42", CapacityLiters = 350, Type = "Frost Free", Description = "No frost cooling with LED lighting", RentalPricePerMonth = 600, ImageUrl = "/images/bosch_kdn42.jpg", AvailabilityStatus = "Rented", Location = "Port Elizabeth" },
                new Fridge { FridgeId = 7, Brand = "Smeg", Model = "FAB28", CapacityLiters = 270, Type = "Retro Style", Description = "Stylish retro fridge with adjustable shelves", RentalPricePerMonth = 650, ImageUrl = "/images/smeg_fab28.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 8, Brand = "Kelvinator", Model = "KRF265", CapacityLiters = 265, Type = "Top Mount", Description = "Affordable fridge with efficient cooling", RentalPricePerMonth = 430, ImageUrl = "/images/kelvinator_krf265.jpg", AvailabilityStatus = "Available", Location = "Cape Town" },
                new Fridge { FridgeId = 9, Brand = "Siemens", Model = "KG36N", CapacityLiters = 360, Type = "Bottom Freezer", Description = "No frost with multi-airflow system", RentalPricePerMonth = 590, ImageUrl = "/images/siemens_kg36n.jpg", AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 10, Brand = "Haier", Model = "HRF290", CapacityLiters = 290, Type = "Double Door", Description = "Toughened glass shelves and energy efficient", RentalPricePerMonth = 470, ImageUrl = "/images/haier_hrf290.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 11, Brand = "Hisense", Model = "H310BI", CapacityLiters = 310, Type = "Top Freezer", Description = "Low noise and efficient compressor", RentalPricePerMonth = 500, ImageUrl = "/images/hisense_h310bi.jpg", AvailabilityStatus = "Available", Location = "Bloemfontein" },
                new Fridge { FridgeId = 12, Brand = "Defy", Model = "DAC700", CapacityLiters = 420, Type = "Side by Side", Description = "LED display and water dispenser", RentalPricePerMonth = 700, ImageUrl = "/images/defy_dac700.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 13, Brand = "LG", Model = "GL-Q282", CapacityLiters = 282, Type = "Smart Inverter", Description = "Smart cooling with WiFi control", RentalPricePerMonth = 530, ImageUrl = "/images/lg_glq282.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 14, Brand = "Samsung", Model = "RT34A", CapacityLiters = 340, Type = "Top Freezer", Description = "Twin cooling system for freshness", RentalPricePerMonth = 560, ImageUrl = "/images/samsung_rt34a.jpg", AvailabilityStatus = "Rented", Location = "Pretoria" },
                new Fridge { FridgeId = 15, Brand = "Whirlpool", Model = "WDE520", CapacityLiters = 500, Type = "Double Door", Description = "High capacity with 6th sense technology", RentalPricePerMonth = 750, ImageUrl = "/images/whirlpool_wde520.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 16, Brand = "Bosch", Model = "KDN43", CapacityLiters = 400, Type = "Frost Free", Description = "Energy efficient and silent operation", RentalPricePerMonth = 610, ImageUrl = "/images/bosch_kdn43.jpg", AvailabilityStatus = "Available", Location = "Durban" },
                new Fridge { FridgeId = 17, Brand = "Smeg", Model = "FAB32", CapacityLiters = 300, Type = "Retro Style", Description = "Vintage design with modern efficiency", RentalPricePerMonth = 670, ImageUrl = "/images/smeg_fab32.jpg", AvailabilityStatus = "Rented", Location = "Cape Town" },
                new Fridge { FridgeId = 18, Brand = "Siemens", Model = "KG39N", CapacityLiters = 390, Type = "Combi Fridge", Description = "Multi-airflow and easy-clean interior", RentalPricePerMonth = 620, ImageUrl = "/images/siemens_kg39n.jpg", AvailabilityStatus = "Available", Location = "Johannesburg" },
                new Fridge { FridgeId = 19, Brand = "Haier", Model = "HRF330", CapacityLiters = 330, Type = "Bottom Freezer", Description = "Tough build and fast cooling", RentalPricePerMonth = 500, ImageUrl = "/images/haier_hrf330.jpg", AvailabilityStatus = "Available", Location = "Pretoria" },
                new Fridge { FridgeId = 20, Brand = "Defy", Model = "DAC473", CapacityLiters = 473, Type = "Side by Side", Description = "Spacious and frost-free design", RentalPricePerMonth = 720, ImageUrl = "/images/defy_dac473.jpg", AvailabilityStatus = "Rented", Location = "Durban" }
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
        }
    }
}