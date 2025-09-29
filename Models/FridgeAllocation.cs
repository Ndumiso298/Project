using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeAllocation
    {
        public FridgeAllocation()
        {
            Status = AllocationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            MaintenanceVisits = new List<MaintenanceVisit>();
            FaultReports = new List<FaultRecord>();
        }

        [Key]
        [Display(Name = "Allocation ID")]
        public int Id { get; set; }

        // Core Relationships
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        // Employee Assignments
        [Required(ErrorMessage = "Allocating employee is required.")]
        [Display(Name = "Allocated By")]
        public int AllocatedByEmployeeId { get; set; }

        [ForeignKey(nameof(AllocatedByEmployeeId))]
        [ValidateNever]
        [Display(Name = "Allocated By")]
        public virtual Employee AllocatedBy { get; set; } = null!;

        [Display(Name = "Processed By")]
        public int? ProcessedByEmployeeId { get; set; }

        [ForeignKey(nameof(ProcessedByEmployeeId))]
        [ValidateNever]
        [Display(Name = "Processed By")]
        public virtual Employee? ProcessedBy { get; set; }

        // Location Information
        [Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location")]
        public int DeliveryLocationId { get; set; }

        [ForeignKey(nameof(DeliveryLocationId))]
        [ValidateNever]
        public virtual Location DeliveryLocation { get; set; } = null!;

        // Request Tracking
        [Display(Name = "Allocation Request")]
        public int? AllocationRequestHeaderId { get; set; }

        [ForeignKey("AllocationRequestHeaderId")]
        [ValidateNever]
        public virtual AllocationRequestHeader? AllocationRequestHeader { get; set; }

        // Status and Quantity
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationStatus Status { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        // Dates
        [Required(ErrorMessage = "Allocation date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Expected Return Date")]
        public DateTime? ExpectedReturnDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual Return Date")]
        public DateTime? ActualReturnDate { get; set; }

        // Pricing
        [Required(ErrorMessage = "Monthly rental price is required.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monthly Rental Price")]
        [Range(0, 10000, ErrorMessage = "Monthly rental must be between 0 and 10,000.")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRentalPrice { get; set; }

        // Notes and Additional Information
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Allocation Notes")]
        public string? Notes { get; set; }

        // Navigation Collections
        [ValidateNever]
        [Display(Name = "Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; }

        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; }

        // Audit Fields
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created By")]
        [StringLength(450)]
        public string? CreatedBy { get; set; }

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedAt { get; set; }

        [Display(Name = "Modified By")]
        [StringLength(450)]
        public string? ModifiedBy { get; set; }

        // Computed Properties
        [NotMapped]
        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => MonthlyRentalPrice * Quantity;

        [NotMapped]
        [Display(Name = "Duration (days)")]
        public int? DurationDays
        {
            get
            {
                var endDate = ActualReturnDate ?? ExpectedReturnDate ?? DateTime.UtcNow;
                return (int)(endDate - AllocationDate).TotalDays;
            }
        }

        [NotMapped]
        [Display(Name = "Is Currently Active")]
        public bool IsCurrentlyActive => Status == AllocationStatus.Active && IsActive;

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => ExpectedReturnDate.HasValue &&
                               ExpectedReturnDate < DateTime.UtcNow &&
                               Status == AllocationStatus.Active;

        [NotMapped]
        [Display(Name = "Total Revenue")]
        [DataType(DataType.Currency)]
        public decimal TotalRevenue
        {
            get
            {
                if (MonthlyRentalPrice == 0) return 0;

                var endDate = ActualReturnDate ?? DateTime.UtcNow;
                var months = Math.Ceiling((endDate - AllocationDate).TotalDays / 30.0);
                return TotalMonthlyRental * (decimal)Math.Max(0, months);
            }
        }

        [NotMapped]
        [Display(Name = "Days Remaining")]
        public int? DaysRemaining
        {
            get
            {
                if (!ExpectedReturnDate.HasValue || Status != AllocationStatus.Active)
                    return null;

                var days = (ExpectedReturnDate.Value - DateTime.UtcNow).Days;
                return Math.Max(0, days);
            }
        }

        [NotMapped]
        [Display(Name = "Has Active Faults")]
        public bool HasActiveFaults => FaultReports?.Any(f => f.Status == FaultStatus.Reported ||
                                                            f.Status == FaultStatus.InProgress) ?? false;

        [NotMapped]
        [Display(Name = "Upcoming Maintenance")]
        public bool HasUpcomingMaintenance => MaintenanceVisits?.Any(m => m.ScheduledDate.Date == DateTime.Today) ?? false;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Allocation #{Id:00000} - {Customer?.TradingName ?? "Unknown Customer"}";

        // Business Logic Methods
        public bool CanBeDeallocated()
        {
            return Status == AllocationStatus.Active && IsActive;
        }

        public bool CanBeModified()
        {
            return Status == AllocationStatus.Pending || Status == AllocationStatus.Active;
        }

        public void Deallocate(DateTime deallocationDate, string modifiedBy)
        {
            if (CanBeDeallocated())
            {
                Status = AllocationStatus.Completed;
                ActualReturnDate = deallocationDate;
                ModifiedAt = DateTime.UtcNow;
                ModifiedBy = modifiedBy;
                IsActive = false;
            }
        }

        public void UpdateStatus(AllocationStatus newStatus, string modifiedBy, string? notes = null)
        {
            if (CanBeModified())
            {
                Status = newStatus;
                ModifiedAt = DateTime.UtcNow;
                ModifiedBy = modifiedBy;

                if (!string.IsNullOrEmpty(notes))
                {
                    Notes += $"\n[{DateTime.UtcNow:dd/MM/yyyy HH:mm}] {notes}";
                }

                // Auto-complete if returned
                if (newStatus == AllocationStatus.Completed && !ActualReturnDate.HasValue)
                {
                    ActualReturnDate = DateTime.UtcNow;
                    IsActive = false;
                }
            }
        }

        public void AddMaintenanceNote(string note, string addedBy)
        {
            if (!string.IsNullOrEmpty(note))
            {
                Notes += $"\n[Maintenance - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {addedBy}: {note}";
                ModifiedAt = DateTime.UtcNow;
                ModifiedBy = addedBy;
            }
        }
    }
}
