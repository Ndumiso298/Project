using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FridgeModelVM
    {
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
        [Display(Name = "Model Code")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Model code can only contain uppercase letters, numbers, and hyphens.")]
        public string ModelCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge type is required.")]
        [Display(Name = "Type")]
        public FridgeType Type { get; set; }
        public IEnumerable<SelectListItem>? TypeList { get; set; }

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
        [Display(Name = "Monthly Rental Price")]
        public decimal MonthlyRentalPrice { get; set; }

        [Range(0, 50000, ErrorMessage = "Purchase price must be between R0 and R50,000.")]
        [DataType(DataType.Currency)]
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
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Display Name")]
        public string DisplayName => $"{Manufacturer} {ModelName} ({ModelCode})";

        [Display(Name = "Is Active")]
        public bool IsActive => Status == FridgeModelStatus.Active;

        [Display(Name = "Total Fridges")]
        public int TotalFridges { get; set; }

        [Display(Name = "Available Fridges")]
        public int AvailableFridges { get; set; }

        [Display(Name = "Allocated Fridges")]
        public int AllocatedFridges { get; set; }

        [Display(Name = "Under Maintenance Fridges")]
        public int UnderMaintenanceFridges { get; set; }

        [Display(Name = "Faulty Fridges")]
        public int FaultyFridges { get; set; }

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

        [Display(Name = "Needs Reorder")]
        public bool NeedsReorder => AvailableFridges <= MinimumStockLevel;

        [Display(Name = "Current Monthly Revenue")]
        [DataType(DataType.Currency)]
        public decimal CurrentMonthlyRevenue => AllocatedFridges * MonthlyRentalPrice;

        [Display(Name = "Revenue Potential")]
        [DataType(DataType.Currency)]
        public decimal RevenuePotential => AvailableFridges * MonthlyRentalPrice;

        [Display(Name = "Utilization Rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal UtilizationRate => TotalFridges > 0 ? (decimal)AllocatedFridges / TotalFridges : 0;

        [Display(Name = "Model Summary")]
        public string ModelSummary => $"{Manufacturer} {ModelName} - {AvailableFridges} available, {AllocatedFridges} allocated";

        [Display(Name = "Reorder Amount")]
        public int ReorderAmount
        {
            get
            {
                var deficit = MinimumStockLevel - AvailableFridges;
                return Math.Max(ReorderQuantity, deficit);
            }
        }

        // ===== BUSINESS LOGIC METHODS =====
        public bool CanBeDeleted()
        {
            return TotalFridges == 0 && IsActive;
        }

        public bool CanBeDeactivated()
        {
            return IsActive && AvailableFridges == 0;
        }

        public void CalculateStatistics(ICollection<Fridge> fridges)
        {
            var activeFridges = fridges?.Where(f => f.IsActive).ToList() ?? new List<Fridge>();

            TotalFridges = activeFridges.Count;
            AvailableFridges = activeFridges.Count(f => f.Status == FridgeStatus.Available);
            AllocatedFridges = activeFridges.Count(f => f.Status == FridgeStatus.Allocated);
            UnderMaintenanceFridges = activeFridges.Count(f => f.Status == FridgeStatus.UnderMaintenance);
            FaultyFridges = activeFridges.Count(f => f.Status == FridgeStatus.Faulty);
        }

        public string GetValidationSummary()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Manufacturer))
                errors.Add("Manufacturer is required");
            if (string.IsNullOrWhiteSpace(ModelName))
                errors.Add("Model name is required");
            if (string.IsNullOrWhiteSpace(ModelCode))
                errors.Add("Model code is required");
            if (CapacityLiters <= 0)
                errors.Add("Capacity must be greater than 0");
            if (MonthlyRentalPrice < 0)
                errors.Add("Rental price cannot be negative");
            if (ServiceIntervalMonths <= 0)
                errors.Add("Service interval must be greater than 0");

            return errors.Any() ? string.Join("; ", errors) : "Valid";
        }

        public static FridgeModelVM FromEntity(FridgeModel entity)
        {
            if (entity == null) return null;

            return new FridgeModelVM
            {
                Id = entity.Id,
                Manufacturer = entity.Manufacturer,
                ModelName = entity.ModelName,
                CapacityLiters = entity.CapacityLiters,
                MonthlyRentalPrice = entity.MonthlyRentalPrice
                // Add other properties as needed
            };
        }
    }
}
