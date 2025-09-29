using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models.ViewModels
{
    public class FridgeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Serial number is required.")]
        [StringLength(100, ErrorMessage = "Serial number cannot exceed 100 characters.")]
        [Display(Name = "Serial Number")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Serial number can only contain uppercase letters, numbers, and hyphens.")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        public int FridgeModelId { get; set; }
        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        [Required(ErrorMessage = "Current location is required.")]
        [Display(Name = "Current Location")]
        public int LocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }
        public IEnumerable<SelectListItem>? ConditionList { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Availability Status")]
        public FridgeStatus Status { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Purchase Price (R)")]
        [Range(0, 50000, ErrorMessage = "Purchase price must be between R0 and R50,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "Supplier")]
        [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
        public string? Supplier { get; set; }
        public IEnumerable<SelectListItem>? SupplierList { get; set; }

        [Display(Name = "Warranty Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarrantyExpiryDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Last Service Date")]
        public DateTime? LastServiceDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Next Service Due")]
        public DateTime? NextServiceDue { get; set; }

        [Display(Name = "Total Service Count")]
        public int TotalServiceCount { get; set; } = 0;

        // Audit
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        // Navigation Properties for Display
        [Display(Name = "Fridge Model")]
        public FridgeModelVM? FridgeModelDetails { get; set; }

        [Display(Name = "Location")]
        public LocationVM? LocationDetails { get; set; }

        // Computed Properties (Read-only for display)
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; } = string.Empty;

        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance { get; set; }

        [Display(Name = "Under Warranty")]
        public bool UnderWarranty { get; set; }

        [Display(Name = "Age (years)")]
        public double? AgeInYears { get; set; }

        [Display(Name = "Days Until Service Due")]
        public int? DaysUntilServiceDue { get; set; }

        [Display(Name = "Allocation History Count")]
        public int AllocationHistoryCount { get; set; }

        [Display(Name = "Maintenance History Count")]
        public int MaintenanceHistoryCount { get; set; }

        [Display(Name = "Fault Report Count")]
        public int FaultReportCount { get; set; }

        // Methods
        public void CalculateComputedProperties()
        {
            DisplayName = $"{FridgeModelDetails?.Manufacturer} {FridgeModelDetails?.ModelName} - {SerialNumber}";

            if (LastServiceDate.HasValue && FridgeModelDetails != null)
            {
                RequiresMaintenance = LastServiceDate.Value < DateTime.UtcNow.AddMonths(-FridgeModelDetails.ServiceIntervalMonths);

                var nextServiceDue = LastServiceDate.Value.AddMonths(FridgeModelDetails.ServiceIntervalMonths);
                DaysUntilServiceDue = (int)(nextServiceDue - DateTime.UtcNow).TotalDays;
            }

                UnderWarranty = WarrantyExpiryDate.HasValue && WarrantyExpiryDate > DateTime.UtcNow;

            if (PurchaseDate.HasValue)
            {
                AgeInYears = (DateTime.UtcNow - PurchaseDate.Value).TotalDays / 365.25;
            }
        }
    }
}
