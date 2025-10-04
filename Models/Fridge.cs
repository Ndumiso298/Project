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

        // ===== IDENTIFICATION & BASIC INFO =====
        [Required(ErrorMessage = "Serial number is required.")]
        [StringLength(100, ErrorMessage = "Serial number cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z0-9\\-]+$", ErrorMessage = "Serial number can only contain uppercase letters, numbers, and hyphens.")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        public int FridgeModelId { get; set; }

        [ForeignKey(nameof(FridgeModelId))]
        [ValidateNever]
        public virtual FridgeModel FridgeModel { get; set; } = null!;

        // ===== LOCATION & STATUS =====
        [Display(Name = "Current Location")]
        public int? LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        public virtual Location? CurrentLocation { get; set; }

        [Display(Name = "Current Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer? CurrentCustomer { get; set; }

        [Required(ErrorMessage = "Fridge condition is required.")]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }

        [Required(ErrorMessage = "Fridge status is required.")]
        [Display(Name = "Status")]
        public FridgeStatus Status { get; set; } = FridgeStatus.Available;

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
        [Display(Name = "Maintenance Records")]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        [ValidateNever]
        [Display(Name = "Allocation History")]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{FridgeModel?.Manufacturer} {FridgeModel?.ModelName} - {SerialNumber}";

        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => Status != FridgeStatus.Scrapped && Status != FridgeStatus.LostStolen;

        [NotMapped]
        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance => NextServiceDue.HasValue && NextServiceDue <= DateTime.UtcNow;

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
        public int? DaysUntilServiceDue => NextServiceDue.HasValue
            ? (int)(NextServiceDue.Value - DateTime.UtcNow).TotalDays
            : null;

        [NotMapped]
        [Display(Name = "Current Allocation")]
        public FridgeAllocation? CurrentAllocation =>
            AllocationHistory?.FirstOrDefault(a => a.IsActive && a.AllocationStatus == AllocationStatus.Active);

        [NotMapped]
        [Display(Name = "Allocation History Count")]
        public int AllocationHistoryCount => AllocationHistory?.Count ?? 0;

        [NotMapped]
        [Display(Name = "Maintenance History Count")]
        public int MaintenanceHistoryCount => MaintenanceRecords?.Count ?? 0;

        [NotMapped]
        [Display(Name = "Fault Report Count")]
        public int FaultReportCount => FaultReports?.Count ?? 0;

        [NotMapped]
        [Display(Name = "Open Faults")]
        public int OpenFaultCount => FaultReports?.Count(f =>
            f.Status == FaultStatus.Reported ||
            f.Status == FaultStatus.Assigned ||
            f.Status == FaultStatus.InProgress) ?? 0;

        [NotMapped]
        [Display(Name = "Status Summary")]
        public string StatusSummary
        {
            get
            {
                var summary = Status.ToString();
                if (CurrentCustomer != null) summary += $" - Allocated to {CurrentCustomer.BusinessName}";
                if (RequiresMaintenance) summary += " - Maintenance Due";
                if (OpenFaultCount > 0) summary += $" - {OpenFaultCount} Open Fault(s)";
                return summary;
            }
        }

        // ===== BUSINESS LOGIC METHODS =====
        public bool CanBeAllocated()
        {
            return Status == FridgeStatus.Available &&
                   Condition == FridgeCondition.Excellent &&
                   !RequiresMaintenance;
        }

        public bool CanBeServiced()
        {
            return IsActive &&
                   (Status == FridgeStatus.Available || Status == FridgeStatus.UnderMaintenance);
        }

        public bool CanBeScrapped()
        {
            return IsActive &&
                   (Condition == FridgeCondition.Poor || Status == FridgeStatus.Faulty);
        }

        public void UpdateServiceDueDate()
        {
            if (FridgeModel != null && LastServiceDate.HasValue)
            {
                NextServiceDue = LastServiceDate.Value.AddMonths(FridgeModel.ServiceIntervalMonths);
            }
        }
    }
}