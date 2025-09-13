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
                    Id = 1,
                    AddressLine1 = "123 Vilakazi Street",
                    AddressLine2 = "Orlando West",
                    SuburbId = 7, // Orlando East (Soweto, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 2,
                    AddressLine1 = "45 Victoria Road",
                    AddressLine2 = "Victoria and Alfred Waterfront",
                    SuburbId = 3, // Sea Point (Cape Town, Western Cape)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 3,
                    AddressLine1 = "78 Steve Biko Road",
                    AddressLine2 = "Berea Centre",
                    SuburbId = 5, // Berea (Durban, KZN)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 4,
                    AddressLine1 = "12 Main Road",
                    AddressLine2 = "Sandton City",
                    SuburbId = 1, // Sandton (Johannesburg, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 5,
                    AddressLine1 = "8 4th Avenue",
                    AddressLine2 = "Parkhurst Village",
                    SuburbId = 2, // Parkhurst (Johannesburg, Gauteng)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 6,
                    AddressLine1 = "101 Beach Road",
                    AddressLine2 = "Beachfront Plaza",
                    SuburbId = 4, // Claremont (Cape Town, Western Cape)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 7,
                    AddressLine1 = "22 Marine Drive",
                    AddressLine2 = "Umhlanga Rocks",
                    SuburbId = 8, // Umhlanga (Durban, KZN)
                    CreatedAt = DateTime.UtcNow
                },
                new Fridge
                {
                    Id = 8,
                    AddressLine1 = "5 University Way",
                    AddressLine2 = "Campus Square",
                    SuburbId = 6, // Summerstrand (Gqeberha, Eastern Cape)
                    CreatedAt = DateTime.UtcNow
                },
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
                    FridgeId = 14,
                    Brand = "Sharp",
                    FridgeNo = "FRG-014",
                    Model = "SJ-GX60",
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

