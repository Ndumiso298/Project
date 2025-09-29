using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Serial Number")]
        [RegularExpression(@"^[A-Z0-9\\-]+$")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Fridge ModelName")]
        public int FridgeModelId { get; set; }

        [ForeignKey(nameof(FridgeModelId))]
        [ValidateNever]
        public virtual FridgeModel FridgeModel { get; set; } = null!;

        [Required]
        [Display(Name = "Current Location")]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        public virtual Location CurrentLocation { get; set; } = null!;

        [Required]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }

        [Required]
        [Display(Name = "Availability Status")]
        public FridgeStatus Status { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Purchase Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "Supplier")]
        [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
        public string? Supplier { get; set; }

        [Display(Name = "Warranty Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime? WarrantyExpiryDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Service Date")]
        public DateTime? LastServiceDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Next Service Due")]
        public DateTime? NextServiceDue { get; set; }

        [Display(Name = "Total Service Count")]
        public int TotalServiceCount { get; set; } = 0;

        // Audit
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Scrapped")]
        public bool IsScrapped { get; set; } = false;

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Modified Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedAt { get; set; }

        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

        // Navigation
        [ValidateNever]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        [ValidateNever]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [ValidateNever]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

        // Computed
        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{FridgeModel?.Manufacturer} {FridgeModel?.ModelName} - {SerialNumber}";

        [NotMapped]
        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance => LastServiceDate < DateTime.UtcNow.AddMonths(-FridgeModel.ServiceIntervalMonths);

        [NotMapped]
        [Display(Name = "Under Warranty")]
        public bool UnderWarranty => WarrantyExpiryDate.HasValue && WarrantyExpiryDate > DateTime.UtcNow;

        [NotMapped]
        [Display(Name = "Age (years)")]
        public double? AgeInYears => PurchaseDate.HasValue
            ? (DateTime.UtcNow - PurchaseDate.Value).TotalDays / 365.25
            : null;

        [NotMapped]
        [Display(Name = "Days Until Service Due")]
        public int? DaysUntilServiceDue
        {
            get
            {
                if (!LastServiceDate.HasValue || FridgeModel == null) return null;
                var nextServiceDue = LastServiceDate.Value.AddMonths(FridgeModel.ServiceIntervalMonths);
                return (int)(nextServiceDue - DateTime.UtcNow).TotalDays;
            }
        }

        [NotMapped]
        [Display(Name = "Current Allocation")]
        public FridgeAllocation? CurrentAllocation =>
    AllocationHistory?.FirstOrDefault(a => a.IsActive && a.Status == AllocationStatus.Active);

        [NotMapped]
        [Display(Name = "Allocation History Count")]
        public int AllocationHistoryCount => AllocationHistory?.Count ?? 0;

        [NotMapped]
        [Display(Name = "Maintenance History Count")]
        public int MaintenanceHistoryCount => MaintenanceRecords?.Count ?? 0;

        [NotMapped]
        [Display(Name = "Fault Report Count")]
        public int FaultReportCount => FaultReports?.Count ?? 0;
    }
}