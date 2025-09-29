using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class FridgeModel
    {
        [Key]
        public int Id { get; set; }

        // Basic Information
        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model name is required.")]
        [StringLength(50, ErrorMessage = "Model name cannot exceed 50 characters.")]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model code is required.")]
        [StringLength(20, ErrorMessage = "Model code cannot exceed 20 characters.")]
        [Display(Name = "Model Code")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Model code can only contain uppercase letters, numbers, and hyphens.")]
        public string ModelCode { get; set; } = string.Empty;

        // Specifications
        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 liters.")]
        [Display(Name = "Capacity (Liters)")]
        public int CapacityLiters { get; set; }

        [Required(ErrorMessage = "Fridge type is required.")]
        [Display(Name = "Type")]
        public FridgeType Type { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        // Pricing
        [Required(ErrorMessage = "Rental price is required.")]
        [Range(0, 10000, ErrorMessage = "Rental price must be between R0 and R10,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monthly Rental Price (R)")]
        public decimal MonthlyRentalPrice { get; set; }

        [Range(0, 50000, ErrorMessage = "Purchase price must be between R0 and R50,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Purchase Price (R)")]
        public decimal? PurchasePrice { get; set; }

        // Technical Specifications
        [StringLength(10, ErrorMessage = "Energy rating cannot exceed 10 characters.")]
        [Display(Name = "Energy Rating")]
        public string? EnergyRating { get; set; }

        [StringLength(50, ErrorMessage = "Dimensions cannot exceed 50 characters.")]
        [Display(Name = "Dimensions (H×W×D cm)")]
        public string? Dimensions { get; set; }

        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 kg.")]
        [Display(Name = "Weight (kg)")]
        public decimal? WeightKg { get; set; }

        [StringLength(30, ErrorMessage = "Color cannot exceed 30 characters.")]
        [Display(Name = "Color")]
        public string? Color { get; set; }

        [Display(Name = "Voltage Requirements")]
        [StringLength(50, ErrorMessage = "Voltage requirements cannot exceed 50 characters.")]
        public string? Voltage { get; set; }

        [Display(Name = "Power Consumption (kWh/year)")]
        [Range(0, 1000, ErrorMessage = "Power consumption must be between 0 and 1000 kWh/year.")]
        public decimal? PowerConsumption { get; set; }

        [Display(Name = "Temperature Range (°C)")]
        [StringLength(20, ErrorMessage = "Temperature range cannot exceed 20 characters.")]
        public string? TemperatureRange { get; set; }

        // Features
        [Display(Name = "Has Glass Door")]
        public bool HasGlassDoor { get; set; }

        [Display(Name = "Has Digital Display")]
        public bool HasDigitalDisplay { get; set; }

        [Display(Name = "Has Lock")]
        public bool HasLock { get; set; }

        [Display(Name = "Is Frost Free")]
        public bool IsFrostFree { get; set; }

        // Maintenance Information
        [Required(ErrorMessage = "Service interval is required.")]
        [Range(1, 24, ErrorMessage = "Service interval must be between 1 and 24 months.")]
        [Display(Name = "Service Interval (Months)")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [Display(Name = "Warranty Period (Months)")]
        [Range(0, 60, ErrorMessage = "Warranty period must be between 0 and 60 months.")]
        public int WarrantyPeriodMonths { get; set; } = 12;

        [Display(Name = "Minimum Stock Level")]
        [Range(0, 100, ErrorMessage = "Minimum stock level must be between 0 and 100.")]
        public int MinimumStockLevel { get; set; } = 2;

        [Display(Name = "Reorder Quantity")]
        [Range(1, 50, ErrorMessage = "Reorder quantity must be between 1 and 50.")]
        public int ReorderQuantity { get; set; } = 5;

        // Media
        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // Status Management (Soft Delete)
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Scrapped")]
        public bool IsScrapped { get; set; } = false;

        // Audit Fields
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        [StringLength(450, ErrorMessage = "Created by cannot exceed 450 characters.")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedAt { get; set; }

        [Display(Name = "Modified By")]
        [StringLength(450, ErrorMessage = "Updated by cannot exceed 450 characters.")]
        public string? ModifiedBy { get; set; }

        // Navigation Properties
        [ValidateNever]
        [Display(Name = "Fridges of This Model")]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        [ValidateNever]
        public virtual ICollection<AllocationRequestDetail> AllocationRequestDetails { get; set; } = new List<AllocationRequestDetail>();

        // Computed Properties
        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{Manufacturer} {ModelName} ({ModelCode})";

        [NotMapped]
        [Display(Name = "Total Fridges")]
        public int TotalFridges => Fridges?.Count(f => f.IsActive && !f.IsScrapped) ?? 0;

        [NotMapped]
        [Display(Name = "Available Fridges")]
        public int AvailableFridges => Fridges?.Count(f => f.IsActive && !f.IsScrapped && f.Status == FridgeStatus.Available) ?? 0;

        [NotMapped]
        [Display(Name = "Allocated Fridges")]
        public int AllocatedFridges => Fridges?.Count(f => f.IsActive && !f.IsScrapped && f.Status == FridgeStatus.Allocated) ?? 0;

        [NotMapped]
        [Display(Name = "In Maintenance Fridges")]
        public int InMaintenanceFridges => Fridges?.Count(f => f.IsActive && !f.IsScrapped && f.Status == FridgeStatus.InService) ?? 0;

        [NotMapped]
        [Display(Name = "Under Repair Fridges")]
        public int UnderRepairFridges => Fridges?.Count(f => f.IsActive && !f.IsScrapped && f.Status == FridgeStatus.Quarantined) ?? 0;

        [NotMapped]
        [Display(Name = "Stock Status")]
        public StockStatus StockStatus
        {
            get
            {
                if (AvailableFridges == 0) return StockStatus.OutOfStock;
                if (AvailableFridges <= MinimumStockLevel) return StockStatus.LowStock;
                return StockStatus.InStock;
            }
        }

        [NotMapped]
        [Display(Name = "Needs Reorder")]
        public bool NeedsReorder => AvailableFridges <= MinimumStockLevel;


        [NotMapped]
        [Display(Name = "Monthly Revenue Potential")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRevenuePotential => AvailableFridges * MonthlyRentalPrice;

        [NotMapped]
        [Display(Name = "Current Monthly Revenue")]
        [DataType(DataType.Currency)]
        public decimal CurrentMonthlyRevenue => AllocatedFridges * MonthlyRentalPrice;

        [NotMapped]
        [Display(Name = "Utilization Rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal UtilizationRate => TotalFridges > 0 ? (decimal)AllocatedFridges / TotalFridges : 0;

        // Business Logic Methods
        public bool CanBeDeleted()
        {
            return TotalFridges == 0 && !IsScrapped;
        }

        public bool CanBeScrapped()
        {
            return !IsScrapped && TotalFridges == 0;
        }
    }
}