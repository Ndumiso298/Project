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
            AllocationStatus = AllocationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            MaintenanceVisits = new List<MaintenanceVisit>();
            FaultReports = new List<FaultRecord>();
        }

        [Key]
        public int Id { get; set; }

        // ===== CORE RELATIONSHIPS =====
        [Required(ErrorMessage = "Fridge is required.")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        // ===== EMPLOYEE ASSIGNMENTS =====
        [Required(ErrorMessage = "Allocating employee is required.")]
        public int AllocatedByEmployeeId { get; set; }

        [ForeignKey(nameof(AllocatedByEmployeeId))]
        [ValidateNever]
        public virtual Employee AllocatedBy { get; set; } = null!;

        public int? ProcessedByEmployeeId { get; set; }

        [ForeignKey(nameof(ProcessedByEmployeeId))]
        [ValidateNever]
        public virtual Employee? ProcessedBy { get; set; }

        // ===== LOCATION INFORMATION =====
        public int? DeliveryLocationId { get; set; }

        [ForeignKey(nameof(DeliveryLocationId))]
        [ValidateNever]
        public virtual Location? DeliveryLocation { get; set; }

        // ===== REQUEST TRACKING =====
        public int AllocationRequestHeaderId { get; set; }

        [ForeignKey(nameof(AllocationRequestHeaderId))]
        [InverseProperty(nameof(AllocationRequestHeader.Allocations))]
        public virtual AllocationRequestHeader RequestHeader { get; set; } = null!;

        // ===== REPLACEMENT TRACKING =====
        public int? ReplacementRequestHeaderId { get; set; }

        [ForeignKey(nameof(ReplacementRequestHeaderId))]
        [InverseProperty(nameof(AllocationRequestHeader.ReplacementAllocations))]
        public virtual AllocationRequestHeader? ReplacementRequestHeader { get; set; }

        [Display(Name = "Replaced Allocation")]
        public int? ReplacedAllocationId { get; set; }

        [ForeignKey(nameof(ReplacedAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation? ReplacedAllocation { get; set; }

        [ValidateNever]
        [Display(Name = "Replacement Allocations")]
        public virtual ICollection<FridgeAllocation> ReplacementAllocations { get; set; } = new List<FridgeAllocation>();

        // ===== STATUS AND DATES =====
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Allocation Status")]
        public AllocationStatus AllocationStatus { get; set; }

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

        // ===== PRICING =====
        [Required(ErrorMessage = "Monthly rental price is required.")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000, ErrorMessage = "Monthly rental must be between 0 and 10,000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Monthly Rental Price")]
        public decimal MonthlyRentalPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // ===== NOTES AND ADDITIONAL INFORMATION =====
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        // ===== NAVIGATION COLLECTIONS =====
        [ValidateNever]
        [Display(Name = "Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; }

        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; }

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

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => AllocationStatus == AllocationStatus.Active;

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => ExpectedReturnDate.HasValue &&
                               ExpectedReturnDate < DateTime.UtcNow &&
                               AllocationStatus == AllocationStatus.Active;

        [NotMapped]
        [Display(Name = "Is Replacement")]
        public bool IsReplacement => ReplacedAllocationId.HasValue;

        [NotMapped]
        [Display(Name = "Has Been Replaced")]
        public bool HasBeenReplaced => ReplacementAllocations.Any(r => r.IsActive);

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
        [Display(Name = "Days Remaining")]
        public int? DaysRemaining
        {
            get
            {
                if (!ExpectedReturnDate.HasValue || AllocationStatus != AllocationStatus.Active)
                    return null;

                var days = (ExpectedReturnDate.Value - DateTime.UtcNow).Days;
                return Math.Max(0, days);
            }
        }

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
                return MonthlyRentalPrice * (decimal)Math.Max(0, months);
            }
        }

        [NotMapped]
        [Display(Name = "Has Active Faults")]
        public bool HasActiveFaults => FaultReports?.Any(f =>
            f.Status == FaultStatus.Reported ||
            f.Status == FaultStatus.Assigned ||
            f.Status == FaultStatus.InProgress) ?? false;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Allocation #{Id:00000} - {Customer?.BusinessName ?? "Unknown Customer"}";

        [NotMapped]
        [Display(Name = "Allocation Summary")]
        public string AllocationSummary =>
            $"{Customer?.BusinessName} - {Fridge?.DisplayName} - {AllocationStatus} since {AllocationDate:dd/MM/yyyy}";

        // ===== ENHANCED BUSINESS LOGIC METHODS =====
        public bool CanBeDeallocated()
        {
            return AllocationStatus == AllocationStatus.Active && !HasBeenReplaced;
        }

        public bool CanBeModified()
        {
            return AllocationStatus == AllocationStatus.Pending || AllocationStatus == AllocationStatus.Active;
        }

        public bool CanBeReplaced()
        {
            return IsActive && (HasActiveFaults || Fridge?.Status == FridgeStatus.Faulty);
        }

        public void Deallocate(DateTime deallocationDate, string updatedBy, string reason = "Deallocated")
        {
            if (CanBeDeallocated())
            {
                AllocationStatus = AllocationStatus.Completed;
                ActualReturnDate = deallocationDate;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;

                if (!string.IsNullOrEmpty(reason))
                {
                    Notes += $"\n[{DateTime.UtcNow:dd/MM/yyyy HH:mm}] {updatedBy}: {reason}";
                }
            }
        }

        public void MarkAsReplacedBy(FridgeAllocation replacementAllocation, string updatedBy)
        {
            if (CanBeReplaced())
            {
                AllocationStatus = AllocationStatus.Completed;
                ActualReturnDate = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;

                Notes += $"\n[{DateTime.UtcNow:dd/MM/yyyy HH:mm}] {updatedBy}: Replaced by allocation #{replacementAllocation.Id}";

                ReplacementAllocations.Add(replacementAllocation);
            }
        }

        public void UpdateStatus(AllocationStatus newStatus, string modifiedBy, string? notes = null)
        {
            if (CanBeModified())
            {
                AllocationStatus = newStatus;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = modifiedBy;

                if (!string.IsNullOrEmpty(notes))
                {
                    Notes += $"\n[{DateTime.UtcNow:dd/MM/yyyy HH:mm}] {modifiedBy}: {notes}";
                }

                // Auto-complete if returned
                if (newStatus == AllocationStatus.Completed && !ActualReturnDate.HasValue)
                {
                    ActualReturnDate = DateTime.UtcNow;
                }
            }
        }

        public void AddMaintenanceNote(string note, string addedBy)
        {
            if (!string.IsNullOrEmpty(note))
            {
                Notes += $"\n[Maintenance - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {addedBy}: {note}";
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = addedBy;
            }
        }

        public bool IsValidForCustomer(Customer customer)
        {
            return customer.AccountStatus == AccountStatus.Approved &&
                   customer.CanLogin;
        }
    }
}
