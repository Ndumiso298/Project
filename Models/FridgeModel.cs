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

        // ===== BASIC INFORMATION =====
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
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Model code can only contain uppercase letters, numbers, and hyphens.")]
        [Display(Name = "Model Code")]
        public string ModelCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge type is required.")]
        [Display(Name = "Type")]
        public FridgeType Type { get; set; }

        // ===== SPECIFICATIONS =====
        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 liters.")]
        [Display(Name = "Capacity (Liters)")]
        public int CapacityLiters { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Energy rating cannot exceed 10 characters.")]
        [Display(Name = "Energy Rating")]
        public string? EnergyRating { get; set; }

        [StringLength(50, ErrorMessage = "Dimensions cannot exceed 50 characters.")]
        [Display(Name = "Dimensions")]
        public string? Dimensions { get; set; }

        [StringLength(30, ErrorMessage = "Color cannot exceed 30 characters.")]
        [Display(Name = "Color")]
        public string? Color { get; set; }

        // ===== PRICING =====
        [Required(ErrorMessage = "Monthly rental price is required.")]
        [Range(0, 10000, ErrorMessage = "Rental price must be between R0 and R10,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monthly Rental Price")]
        public decimal MonthlyRentalPrice { get; set; }

        [Range(0, 50000, ErrorMessage = "Purchase price must be between R0 and R50,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Purchase Price")]
        public decimal? PurchasePrice { get; set; }

        // ===== FEATURES =====
        [Display(Name = "Has Glass Door")]
        public bool HasGlassDoor { get; set; }

        [Display(Name = "Has Digital Display")]
        public bool HasDigitalDisplay { get; set; }

        [Display(Name = "Has Lock")]
        public bool HasLock { get; set; }

        [Display(Name = "Is Frost Free")]
        public bool IsFrostFree { get; set; }

        // ===== MAINTENANCE & INVENTORY =====
        [Required(ErrorMessage = "Service interval is required.")]
        [Range(1, 24, ErrorMessage = "Service interval must be between 1 and 24 months.")]
        [Display(Name = "Service Interval (Months)")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [Range(0, 60, ErrorMessage = "Warranty period must be between 0 and 60 months.")]
        [Display(Name = "Warranty Period (Months)")]
        public int WarrantyPeriodMonths { get; set; } = 12;

        [Range(0, 100, ErrorMessage = "Minimum stock level must be between 0 and 100.")]
        [Display(Name = "Minimum Stock Level")]
        public int MinimumStockLevel { get; set; } = 2;

        [Range(1, 50, ErrorMessage = "Reorder quantity must be between 1 and 50.")]
        [Display(Name = "Reorder Quantity")]
        public int ReorderQuantity { get; set; } = 5;

        // ===== STATUS & MEDIA =====
        [Required(ErrorMessage = "Model status is required.")]
        [Display(Name = "Status")]
        public FridgeModelStatus Status { get; set; } = FridgeModelStatus.Active;

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // ===== AUDIT FIELDS =====
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; }

        // ===== NAVIGATION PROPERTIES =====
        [ValidateNever]
        [Display(Name = "Fridges")]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{Manufacturer} {ModelName} ({ModelCode})";

        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => Status == FridgeModelStatus.Active;

        [NotMapped]
        [Display(Name = "Total Fridges")]
        public int TotalFridges => Fridges?.Count(f => f.IsActive) ?? 0;

        [NotMapped]
        [Display(Name = "Available Fridges")]
        public int AvailableFridges => Fridges?.Count(f => f.IsActive && f.Status == FridgeStatus.Available) ?? 0;

        [NotMapped]
        [Display(Name = "Allocated Fridges")]
        public int AllocatedFridges => Fridges?.Count(f => f.IsActive && f.Status == FridgeStatus.Allocated) ?? 0;

        [NotMapped]
        [Display(Name = "Under Maintenance Fridges")]
        public int UnderMaintenanceFridges => Fridges?.Count(f => f.IsActive && f.Status == FridgeStatus.UnderMaintenance) ?? 0;

        [NotMapped]
        [Display(Name = "Faulty Fridges")]
        public int FaultyFridges => Fridges?.Count(f => f.IsActive && f.Status == FridgeStatus.Faulty) ?? 0;

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
        [Display(Name = "Current Monthly Revenue")]
        [DataType(DataType.Currency)]
        public decimal CurrentMonthlyRevenue => AllocatedFridges * MonthlyRentalPrice;

        [NotMapped]
        [Display(Name = "Revenue Potential")]
        [DataType(DataType.Currency)]
        public decimal RevenuePotential => AvailableFridges * MonthlyRentalPrice;

        [NotMapped]
        [Display(Name = "Utilization Rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal UtilizationRate => TotalFridges > 0 ? (decimal)AllocatedFridges / TotalFridges : 0;

        [NotMapped]
        [Display(Name = "Model Summary")]
        public string ModelSummary => $"{Manufacturer} {ModelName} - {AvailableFridges} available, {AllocatedFridges} allocated";

        // ===== BUSINESS LOGIC METHODS =====
        public bool CanBeDeleted()
        {
            return TotalFridges == 0 && IsActive;
        }

        public bool CanBeDeactivated()
        {
            return IsActive && AvailableFridges == 0;
        }

        public int CalculateReorderAmount()
        {
            var deficit = MinimumStockLevel - AvailableFridges;
            return Math.Max(ReorderQuantity, deficit);
        }
    }
}