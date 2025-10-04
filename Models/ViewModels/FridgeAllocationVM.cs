using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FridgeAllocationVM
    {
        public int Id { get; set; }

        // Core Relationships
        [Required(ErrorMessage = "Fridge selection is required.")]
        [Display(Name = "Fridge")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid fridge.")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "Customer selection is required.")]
        [Display(Name = "Customer")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid customer.")]
        public int CustomerId { get; set; }

        [Display(Name = "Delivery Location")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid delivery location.")]
        public int? DeliveryLocationId { get; set; }

        // ===== REPLACEMENT TRACKING =====
        [Display(Name = "Replaced Allocation")]
        public int? ReplacedAllocationId { get; set; }

        [Display(Name = "Replacement Request")]
        public int? ReplacementRequestId { get; set; }

        // Employee Assignments
        [Required(ErrorMessage = "Allocating employee is required.")]
        [Display(Name = "Allocated By")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid employee.")]
        public int AllocatedByEmployeeId { get; set; }

        [Display(Name = "Processed By")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid employee.")]
        public int? ProcessedByEmployeeId { get; set; }

        [Display(Name = "Request Reference")]
        public int AllocationRequestHeaderId { get; set; }

        // Status and Dates
        [Required(ErrorMessage = "Allocation status is required.")]
        [Display(Name = "Status")]
        public AllocationStatus Status { get; set; } = AllocationStatus.Pending;

        [Required(ErrorMessage = "Allocation date is required.")]
        [Display(Name = "Allocation Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime AllocationDate { get; set; } = DateTime.Now;

        [Display(Name = "Expected Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateGreaterThan("AllocationDate", ErrorMessage = "Expected return date must be after allocation date.")]
        public DateTime? ExpectedReturnDate { get; set; }

        [Display(Name = "Actual Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateGreaterThan("AllocationDate", ErrorMessage = "Actual return date must be after allocation date.")]
        public DateTime? ActualReturnDate { get; set; }

        // Pricing
        [Required(ErrorMessage = "Monthly rental price is required.")]
        [Display(Name = "Monthly Rental Price (R)")]
        [Range(0, 10000, ErrorMessage = "Monthly rental must be between R0 and R10,000.")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRentalPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;


        // Notes
        [StringLength(500, ErrorMessage = "Allocation notes cannot exceed 500 characters.")]
        [Display(Name = "Allocation Notes")]
        public string? Notes { get; set; }

        // Navigation Collections (for display only)
        [Display(Name = "Maintenance Visits")]
        public ICollection<MaintenanceVisitVM>? MaintenanceVisits { get; set; }

        [Display(Name = "Fault Reports")]
        public ICollection<FaultRecordVM>? FaultReports { get; set; }

        // Dropdown Lists
        [ValidateNever]
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RequestList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ReplacementAllocationList { get; set; }

        // Display Properties
        [Display(Name = "Fridge Details")]
        public FridgeVM? FridgeDetails { get; set; }

        [Display(Name = "Customer Details")]
        public UserManagementVM? CustomerDetails { get; set; }

        [Display(Name = "Location Details")]
        public LocationVM? LocationDetails { get; set; }

        [Display(Name = "Allocated By")]
        public string? AllocatedByEmployeeName { get; set; }

        [Display(Name = "Processed By")]
        public string? ProcessedByEmployeeName { get; set; }

        [Display(Name = "Replaced Allocation")]
        public string? ReplacedAllocationDisplay { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Is Active")]
        public bool IsActive => Status == AllocationStatus.Active;

        [Display(Name = "Is Replacement")]
        public bool IsReplacement => ReplacedAllocationId.HasValue;

        [Display(Name = "Has Been Replaced")]
        public bool HasBeenReplaced { get; set; }

        [Display(Name = "Is Overdue")]
        public bool IsOverdue => ExpectedReturnDate.HasValue &&
                               ExpectedReturnDate < DateTime.Today &&
                               Status == AllocationStatus.Active;

        [Display(Name = "Duration")]
        public string Duration
        {
            get
            {
                var endDate = ActualReturnDate ?? (IsActive ? DateTime.Today : ExpectedReturnDate);
                if (!endDate.HasValue) return "N/A";

                var duration = endDate.Value - AllocationDate;
                return $"{duration.Days} days";
            }
        }

        [Display(Name = "Total Revenue")]
        [DataType(DataType.Currency)]
        public decimal TotalRevenue
        {
            get
            {
                if (MonthlyRentalPrice == 0) return 0;

                var endDate = ActualReturnDate ?? (IsActive ? DateTime.Today : ExpectedReturnDate);
                if (!endDate.HasValue) return 0;

                var months = Math.Ceiling((endDate.Value - AllocationDate).TotalDays / 30.0);
                return MonthlyRentalPrice * (decimal)Math.Max(0, months);
            }
        }

        [Display(Name = "Days Remaining")]
        public int? DaysRemaining
        {
            get
            {
                if (!ExpectedReturnDate.HasValue || !IsActive) return null;
                var days = (ExpectedReturnDate.Value - DateTime.Today).Days;
                return Math.Max(0, days);
            }
        }

        [Display(Name = "Can Edit")]
        public bool CanEdit => Status == AllocationStatus.Pending;

        [Display(Name = "Can Deallocate")]
        public bool CanDeallocate => Status == AllocationStatus.Active && !HasBeenReplaced;

        [Display(Name = "Can Replace")]
        public bool CanReplace => IsActive && (FaultReports?.Any(f => f.IsResolved) == false);

        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            AllocationStatus.Pending => "bg-warning",
            AllocationStatus.Active => "bg-success",
            AllocationStatus.Completed => "bg-info",
            AllocationStatus.Cancelled => "bg-secondary",
            _ => "bg-secondary"
        };

        // ===== VALIDATION METHODS =====
        public bool IsValidForSubmission()
        {
            return FridgeId > 0 &&
                   CustomerId > 0 &&
                   DeliveryLocationId > 0 &&
                   AllocatedByEmployeeId > 0 &&
                   AllocationDate <= DateTime.Now &&
                   MonthlyRentalPrice > 0;
        }

        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (FridgeId <= 0) errors.Add("Fridge selection is required");
            if (CustomerId <= 0) errors.Add("Customer selection is required");
            if (DeliveryLocationId <= 0) errors.Add("Delivery location is required");
            if (AllocatedByEmployeeId <= 0) errors.Add("Allocating employee is required");
            if (AllocationDate > DateTime.Now) errors.Add("Allocation date cannot be in the future");
            if (MonthlyRentalPrice <= 0) errors.Add("Monthly rental price must be greater than 0");
            if (ExpectedReturnDate.HasValue && ExpectedReturnDate <= AllocationDate)
                errors.Add("Expected return date must be after allocation date");
            if (ActualReturnDate.HasValue && ActualReturnDate <= AllocationDate)
                errors.Add("Actual return date must be after allocation date");

            return errors;
        }

        // ===== MAPPING METHODS =====
        public FridgeAllocation ToEntity()
        {
            return new FridgeAllocation
            {
                Id = Id,
                FridgeId = FridgeId,
                CustomerId = CustomerId,
                DeliveryLocationId = DeliveryLocationId,
                ReplacedAllocationId = ReplacedAllocationId,
                AllocatedByEmployeeId = AllocatedByEmployeeId,
                ProcessedByEmployeeId = ProcessedByEmployeeId,
                AllocationRequestHeaderId = AllocationRequestHeaderId,
                AllocationStatus = Status,
                AllocationDate = AllocationDate,
                ExpectedReturnDate = ExpectedReturnDate,
                ActualReturnDate = ActualReturnDate,
                MonthlyRentalPrice = MonthlyRentalPrice,
                Notes = Notes
            };
        }

        public static FridgeAllocationVM FromEntity(FridgeAllocation entity)
        {
            if (entity == null) return new FridgeAllocationVM();

            return new FridgeAllocationVM
            {
                Id = entity.Id,
                FridgeId = entity.FridgeId,
                CustomerId = entity.CustomerId,
                DeliveryLocationId = entity.DeliveryLocationId,
                ReplacedAllocationId = entity.ReplacedAllocationId,
                AllocatedByEmployeeId = entity.AllocatedByEmployeeId,
                ProcessedByEmployeeId = entity.ProcessedByEmployeeId,
                AllocationRequestHeaderId = entity.AllocationRequestHeaderId,
                Status = entity.AllocationStatus,
                AllocationDate = entity.AllocationDate,
                ExpectedReturnDate = entity.ExpectedReturnDate,
                ActualReturnDate = entity.ActualReturnDate,
                MonthlyRentalPrice = entity.MonthlyRentalPrice,
                Notes = entity.Notes,
                AllocatedByEmployeeName = entity.AllocatedBy?.FullName,
                ProcessedByEmployeeName = entity.ProcessedBy?.FullName,
                ReplacedAllocationDisplay = entity.ReplacedAllocation?.DisplayName,
                HasBeenReplaced = entity.ReplacementAllocations?.Any(r => r.IsActive) == true,
                FridgeDetails = entity.Fridge != null ? FridgeVM.FromEntity(entity.Fridge) : null,
                CustomerDetails = entity.Customer != null ? UserManagementVM.FromEntity(entity.Customer) : null,
                LocationDetails = entity.DeliveryLocation != null ? LocationVM.FromEntity(entity.DeliveryLocation) : null
            };
        }

        // ===== BUSINESS METHODS =====
        public void MarkAsReplacementFor(int existingAllocationId, string notes = "")
        {
            ReplacedAllocationId = existingAllocationId;
            if (!string.IsNullOrEmpty(notes))
            {
                Notes = $"Replacement allocation. {notes}";
            }
        }
    }
}
