using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models.ViewModels
{
    public class FridgeVM
    {
        public int Id { get; set; }

        // ===== IDENTIFICATION & BASIC INFO =====
        [Required(ErrorMessage = "Serial number is required.")]
        [StringLength(100, ErrorMessage = "Serial number cannot exceed 100 characters.")]
        [Display(Name = "Serial Number")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Serial number can only contain uppercase letters, numbers, and hyphens.")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        public int FridgeModelId { get; set; }
        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        // ===== LOCATION & STATUS =====
        [Display(Name = "Current Location")]
        public int? LocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Display(Name = "Current Customer")]
        public int? CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }
        public IEnumerable<SelectListItem>? ConditionList { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public FridgeStatus Status { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        // ===== PURCHASE & WARRANTY INFORMATION =====
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Supplier")]
        [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
        public string? Supplier { get; set; }

        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Purchase price must be between 0 and 100,000.")]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "Warranty Expiry")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarrantyExpiryDate { get; set; }

        // ===== MAINTENANCE INFORMATION =====
        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LastServiceDate { get; set; }

        [Display(Name = "Next Service Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NextServiceDue { get; set; }

        [Display(Name = "Total Service Count")]
        [Range(0, 1000, ErrorMessage = "Service count must be between 0 and 1000.")]
        public int TotalServiceCount { get; set; } = 0;

        [Display(Name = "Last Fault Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LastFaultDate { get; set; }

        // ===== NAVIGATION PROPERTIES FOR DISPLAY =====
        [Display(Name = "Fridge Model")]
        public FridgeModelVM? FridgeModelDetails { get; set; }

        [Display(Name = "Location")]
        public LocationVM? LocationDetails { get; set; }

        [Display(Name = "Customer")]
        public UserManagementVM? CustomerDetails { get; set; }

        // ===== COMPUTED PROPERTIES (READ-ONLY FOR DISPLAY) =====
        [Display(Name = "Display Name")]
        public string DisplayName => $"{FridgeModelDetails?.Manufacturer} {FridgeModelDetails?.ModelName} - {SerialNumber}";

        [Display(Name = "Is Active")]
        public bool IsActive => Status != FridgeStatus.Scrapped && Status != FridgeStatus.LostStolen;

        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance => NextServiceDue.HasValue && NextServiceDue <= DateTime.UtcNow;

        [Display(Name = "Under Warranty")]
        public bool UnderWarranty => WarrantyExpiryDate.HasValue && WarrantyExpiryDate > DateTime.UtcNow;

        [Display(Name = "Age (years)")]
        public double? AgeInYears => PurchaseDate.HasValue
            ? (DateTime.UtcNow - PurchaseDate.Value).TotalDays / 365.25
            : null;

        [Display(Name = "Days Until Service Due")]
        public int? DaysUntilServiceDue => NextServiceDue.HasValue
            ? (int)(NextServiceDue.Value - DateTime.UtcNow).TotalDays
            : null;

        [Display(Name = "Allocation History Count")]
        public int AllocationHistoryCount { get; set; }

        [Display(Name = "Maintenance History Count")]
        public int MaintenanceHistoryCount { get; set; }

        [Display(Name = "Fault Report Count")]
        public int FaultReportCount { get; set; }

        [Display(Name = "Open Faults")]
        public int OpenFaultCount { get; set; }

        [Display(Name = "Status Summary")]
        public string StatusSummary
        {
            get
            {
                var summary = Status.ToString();
                if (CustomerDetails != null) summary += $" - Allocated to {CustomerDetails.BusinessName}";
                if (RequiresMaintenance) summary += " - Maintenance Due";
                if (OpenFaultCount > 0) summary += $" - {OpenFaultCount} Open Fault(s)";
                return summary;
            }
        }

        // ===== BUSINESS LOGIC PROPERTIES =====
        [Display(Name = "Can Be Allocated")]
        public bool CanBeAllocated => Status == FridgeStatus.Available &&
                                     Condition == FridgeCondition.Excellent &&
                                     !RequiresMaintenance;

        [Display(Name = "Can Be Serviced")]
        public bool CanBeServiced => IsActive &&
                                    (Status == FridgeStatus.Available || Status == FridgeStatus.UnderMaintenance);

        [Display(Name = "Can Be Scrapped")]
        public bool CanBeScrapped => IsActive &&
                                    (Condition == FridgeCondition.Poor || Status == FridgeStatus.Faulty);

        // ===== METHODS =====
        public void UpdateServiceDueDate()
        {
            if (FridgeModelDetails != null && LastServiceDate.HasValue)
            {
                NextServiceDue = LastServiceDate.Value.AddMonths(FridgeModelDetails.ServiceIntervalMonths);
            }
        }

        public void PopulateComputedProperties()
        {
            // These will be set by the controller based on related data
            // This method is for initialization if needed
        }

        public static FridgeVM FromEntity(Fridge entity)
        {
            if (entity == null) return null;

            return new FridgeVM
            {
                Id = entity.Id,
                SerialNumber = entity.SerialNumber,
                FridgeModelId = entity.FridgeModelId,
                LocationId = entity.LocationId,
                CustomerId = entity.CustomerId,
                Condition = entity.Condition,
                Status = entity.Status,
                PurchaseDate = entity.PurchaseDate,
                Supplier = entity.Supplier,
                PurchasePrice = entity.PurchasePrice,
                WarrantyExpiryDate = entity.WarrantyExpiryDate,
                LastServiceDate = entity.LastServiceDate,
                NextServiceDue = entity.NextServiceDue,
                TotalServiceCount = entity.TotalServiceCount,
                LastFaultDate = entity.LastFaultDate,
                // Populate related details if available
                FridgeModelDetails = entity.FridgeModel != null ? FridgeModelVM.FromEntity(entity.FridgeModel) : null,
                LocationDetails = entity.CurrentLocation != null ? LocationVM.FromEntity(entity.CurrentLocation) : null
            };
        }
    }
}
