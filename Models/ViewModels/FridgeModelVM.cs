using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FridgeModelVM
    {
        public int Id { get; set; }

        // Basic Information
        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer *")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model name is required.")]
        [StringLength(50, ErrorMessage = "Model name cannot exceed 50 characters.")]
        [Display(Name = "Model Name *")]
        public string ModelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model code is required.")]
        [StringLength(20, ErrorMessage = "Model code cannot exceed 20 characters.")]
        [Display(Name = "Model Code *")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Model code can only contain uppercase letters, numbers, and hyphens.")]
        public string ModelCode { get; set; } = string.Empty;

        // Specifications
        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 liters.")]
        [Display(Name = "Capacity (Liters) *")]
        public int CapacityLiters { get; set; }

        [Required(ErrorMessage = "Fridge type is required.")]
        [Display(Name = "Type *")]
        public FridgeType Type { get; set; }
        public IEnumerable<SelectListItem>? TypeList { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Display(Name = "Description *")]
        public string Description { get; set; } = string.Empty;

        // Pricing
        [Required(ErrorMessage = "Rental price is required.")]
        [Range(0, 10000, ErrorMessage = "Rental price must be between R0 and R10,000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Monthly Rental Price (R) *")]
        public decimal MonthlyRentalPrice { get; set; }

        [Range(0, 50000, ErrorMessage = "Purchase price must be between R0 and R50,000.")]
        [DataType(DataType.Currency)]
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

        // Maintenance Information
        [Required(ErrorMessage = "Service interval is required.")]
        [Range(1, 24, ErrorMessage = "Service interval must be between 1 and 24 months.")]
        [Display(Name = "Service Interval (Months) *")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [Display(Name = "Warranty Period (Months)")]
        [Range(0, 60, ErrorMessage = "Warranty period must be between 0 and 60 months.")]
        public int WarrantyPeriodMonths { get; set; } = 12;

        // Media
        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // Status Management
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Scrapped")]
        public bool IsScrapped { get; set; } = false;

        // Statistics (Read-only)
        [Display(Name = "Total Fridges")]
        public int TotalFridges { get; set; }

        [Display(Name = "Available Fridges")]
        public int AvailableFridges { get; set; }

        [Display(Name = "Allocated Fridges")]
        public int AllocatedFridges { get; set; }

        [Display(Name = "In Service Fridges")]
        public int InServiceFridges { get; set; }

        [Display(Name = "Under Repair Fridges")]
        public int UnderRepairFridges { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName => $"{Manufacturer} {ModelName} ({ModelCode})";

        [Display(Name = "Monthly Revenue Potential")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRevenuePotential { get; set; }

        [Display(Name = "Current Monthly Revenue")]
        [DataType(DataType.Currency)]
        public decimal CurrentMonthlyRevenue { get; set; }

        [Display(Name = "Utilization Rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal UtilizationRate { get; set; }

        // Methods
        public void CalculateStatistics(ICollection<Fridge> fridges)
        {
            var activeFridges = fridges?.Where(f => f.IsActive).ToList() ?? new List<Fridge>();

            TotalFridges = activeFridges.Count;
            AvailableFridges = activeFridges.Count(f => f.Status == FridgeStatus.Available);
            AllocatedFridges = activeFridges.Count(f => f.Status == FridgeStatus.Allocated);
            UnderRepairFridges = activeFridges.Count(f => f.Status == FridgeStatus.InService);

            MonthlyRevenuePotential = AvailableFridges * MonthlyRentalPrice;
            CurrentMonthlyRevenue = AllocatedFridges * MonthlyRentalPrice;
            UtilizationRate = TotalFridges > 0 ? (decimal)AllocatedFridges / TotalFridges : 0;
        }

        public bool CanBeScrapped()
        {
            return !IsScrapped && TotalFridges == 0;
        }

        public string GetValidationErrors()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Manufacturer)) errors.Add("Manufacturer is required");
            if (string.IsNullOrEmpty(ModelName)) errors.Add("Model name is required");
            if (string.IsNullOrEmpty(ModelCode)) errors.Add("Model code is required");
            if (CapacityLiters <= 0) errors.Add("Capacity must be greater than 0");
            if (MonthlyRentalPrice < 0) errors.Add("Rental price cannot be negative");

            return string.Join(", ", errors);
        }
    }
}
