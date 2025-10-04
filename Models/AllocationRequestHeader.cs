using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Project.Utilities.Enums;
using Project.Helpers;
using Project.Data;

namespace Project.Models
{
    public class AllocationRequestHeader
    {
        public AllocationRequestHeader()
        {
            RequestDate = DateTime.UtcNow;
            Status = AllocationRequestStatus.Draft;
            Priority = CustomerRequestPriority.Medium; // Default priority
            RequestDetails = new List<AllocationRequestDetail>();
            Allocations = new List<FridgeAllocation>();
            CreatedAt = DateTime.UtcNow;
            ReplacementAllocations = new List<FridgeAllocation>(); // Track what gets replaced
        }

        [Key]
        public int Id { get; set; }

        // ===== REQUEST INFORMATION =====
        [Required]
        [StringLength(20)]
        [Display(Name = "Request Number")]
        public string RequestNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Request date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Request Status")]
        public AllocationRequestStatus Status { get; set; }

        // ===== PRIORITY FIELD (MISSING) =====
        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; }

        // ===== REPLACEMENT-SPECIFIC FIELDS =====
        [Display(Name = "Replacing Allocation")]
        public int? ReplacingAllocationId { get; set; }

        [ForeignKey(nameof(ReplacingAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation? ReplacingAllocation { get; set; }

        [Display(Name = "Replacing Fridge")]
        public int? ReplacingFridgeId { get; set; }

        [ForeignKey(nameof(ReplacingFridgeId))]
        [ValidateNever]
        public virtual Fridge? ReplacingFridge { get; set; }

        [Display(Name = "Related Fault")]
        public int? RelatedFaultRecordId { get; set; }

        [ForeignKey(nameof(RelatedFaultRecordId))]
        [ValidateNever]
        public virtual FaultRecord? RelatedFaultRecord { get; set; }

        [Display(Name = "Is Urgent Replacement")]
        public bool IsUrgentReplacement { get; set; }

        [StringLength(1000, ErrorMessage = "Replacement reason cannot exceed 1000 characters.")]
        [Display(Name = "Replacement Reason")]
        public string? ReplacementReason { get; set; }

        // ===== CUSTOMER INFORMATION =====
        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact phone number is required.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        [Phone]
        [Display(Name = "Contact Phone")]
        public string ContactPhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }

        // ===== DELIVERY INFORMATION =====
        //[Required(ErrorMessage = "Delivery location is required.")]
        public int? DeliveryLocationId { get; set; }

        [ForeignKey(nameof(DeliveryLocationId))]
        [ValidateNever]
        public virtual Location? DeliveryLocation { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Delivery instructions cannot exceed 500 characters.")]
        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Preferred Delivery Date")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // ===== PRICING AND DISCOUNT =====
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        [Display(Name = "Discount Percentage")]
        public decimal DiscountPercentage { get; set; }

        [StringLength(1000, ErrorMessage = "Special notes cannot exceed 1000 characters.")]
        [Display(Name = "Special Notes")]
        public string? SpecialNotes { get; set; }

        // ===== NAVIGATION PROPERTIES =====
        [ValidateNever]
        [Display(Name = "Request Details")]
        public virtual ICollection<AllocationRequestDetail> RequestDetails { get; set; }

        [ValidateNever]
        [InverseProperty(nameof(FridgeAllocation.RequestHeader))]
        public virtual ICollection<FridgeAllocation> Allocations { get; set; }
          = new List<FridgeAllocation>();


        // ===== REPLACEMENT TRACKING =====
        [ValidateNever]
        [InverseProperty(nameof(FridgeAllocation.ReplacementRequestHeader))]
        public virtual ICollection<FridgeAllocation> ReplacementAllocations { get; set; }
    = new List<FridgeAllocation>();

        // ===== APPROVAL INFORMATION =====
        [Display(Name = "Approved By")]
        public string? ApprovedBy { get; set; }

        [Display(Name = "Approval Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(1000, ErrorMessage = "Approval notes cannot exceed 1000 characters.")]
        [Display(Name = "Approval Notes")]
        public string? ApprovalNotes { get; set; }

        // ===== AUDIT FIELDS =====
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Is Replacement Request")]
        public bool IsReplacementRequest => RequestType == CustomerRequestType.Replacement;

        [NotMapped]
        [Display(Name = "Is New Allocation")]
        public bool IsNewAllocation => RequestType == CustomerRequestType.NewAllocation;

        [NotMapped]
        [Display(Name = "Is Additional Units")]
        public bool IsAdditionalUnits => RequestType == CustomerRequestType.AdditionalUnits;

        [NotMapped]
        [Display(Name = "Has Existing Fault")]
        public bool HasExistingFault => RelatedFaultRecordId.HasValue;

        [NotMapped]
        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => RequestDetails.Sum(d => d.MonthlyTotal);

        [NotMapped]
        [Display(Name = "Total Contract Value")]
        [DataType(DataType.Currency)]
        public decimal TotalContractValue => RequestDetails.Sum(d => d.LineTotal);

        [NotMapped]
        [Display(Name = "Final Amount")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount => TotalContractValue * (1 - DiscountPercentage / 100);

        [NotMapped]
        [Display(Name = "Total Quantity")]
        public int TotalQuantity => RequestDetails.Sum(d => d.Quantity);

        [NotMapped]
        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [NotMapped]
        [Display(Name = "Can Be Edited")]
        public bool CanBeEdited => Status == AllocationRequestStatus.Draft;

        [NotMapped]
        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == AllocationRequestStatus.Completed;

        [NotMapped]
        [Display(Name = "Has Allocations")]
        public bool HasAllocations => Allocations.Any(a => a.IsActive);

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Request #{RequestNumber} - {Customer?.BusinessName ?? "Unknown Customer"}";

        [NotMapped]
        [Display(Name = "Request Summary")]
        public string RequestSummary =>
            $"{Customer?.BusinessName} - {TotalQuantity} fridges - {Status}";

        // ===== ENHANCED BUSINESS LOGIC METHODS =====
        public bool CanTransitionTo(AllocationRequestStatus newStatus)
        {
            return Status switch
            {
                AllocationRequestStatus.Draft => newStatus == AllocationRequestStatus.Submitted,
                AllocationRequestStatus.Submitted => newStatus == AllocationRequestStatus.UnderReview ||
                                                   newStatus == AllocationRequestStatus.AdditionalInfoRequired,
                AllocationRequestStatus.UnderReview => newStatus == AllocationRequestStatus.Approved ||
                                                      newStatus == AllocationRequestStatus.Rejected ||
                                                      newStatus == AllocationRequestStatus.AdditionalInfoRequired,
                AllocationRequestStatus.AdditionalInfoRequired => newStatus == AllocationRequestStatus.UnderReview,
                AllocationRequestStatus.Approved => newStatus == AllocationRequestStatus.InProgress ||
                                                   newStatus == AllocationRequestStatus.Completed ||
                                                   newStatus == AllocationRequestStatus.Cancelled,
                AllocationRequestStatus.InProgress => newStatus == AllocationRequestStatus.Completed,
                _ => false
            };
        }

        public void UpdateStatus(AllocationRequestStatus newStatus, string updatedBy, string? notes = null)
        {
            if (CanTransitionTo(newStatus))
            {
                Status = newStatus;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;

                if (newStatus == AllocationRequestStatus.Approved)
                {
                    ApprovalDate = DateTime.UtcNow;
                    ApprovedBy = updatedBy;
                    ApprovalNotes = notes;
                }
            }
        }

        public bool CanBeProcessedAsReplacement()
        {
            return IsReplacementRequest &&
                   ReplacingFridgeId.HasValue &&
                   ReplacingFridge?.Status == FridgeStatus.Faulty;
        }

        public void MarkAsReplacementFor(FridgeAllocation existingAllocation, FaultRecord faultRecord, string reason)
        {
            RequestType = CustomerRequestType.Replacement;
            ReplacingAllocationId = existingAllocation.Id;
            ReplacingFridgeId = existingAllocation.FridgeId;
            RelatedFaultRecordId = faultRecord.Id;
            ReplacementReason = reason;
            Priority = CustomerRequestPriority.High; // Replacements are typically higher priority
            IsUrgentReplacement = faultRecord.Priority == FaultPriority.Critical;
        }

        // New method for creating replacement from fault
        public static AllocationRequestHeader CreateReplacementRequest(FridgeAllocation allocationToReplace,
            FaultRecord faultRecord, string reason, string createdBy)
        {
            var request = new AllocationRequestHeader
            {
                RequestType = CustomerRequestType.Replacement,
                CustomerId = allocationToReplace.CustomerId,
                ContactPerson = allocationToReplace.Customer.ContactPerson,
                ContactPhoneNumber = allocationToReplace.Customer.BusinessPhoneNumber,
                ContactEmail = allocationToReplace.Customer.BusinessEmail,
                DeliveryLocationId = allocationToReplace.DeliveryLocationId ?? allocationToReplace.Customer.TradingLocationId,
                Priority = CustomerRequestPriority.High,
                Status = AllocationRequestStatus.Draft,
                ReplacementReason = reason,
                ReplacingAllocationId = allocationToReplace.Id,
                ReplacingFridgeId = allocationToReplace.FridgeId,
                RelatedFaultRecordId = faultRecord.Id,
                IsUrgentReplacement = faultRecord.Priority == FaultPriority.Critical,
                CreatedBy = createdBy
            };

            // Auto-add the replacement fridge detail
            request.RequestDetails.Add(new AllocationRequestDetail
            {
                FridgeModelId = allocationToReplace.Fridge.FridgeModelId,
                Quantity = 1,
                RentalDurationMonths = 12, // Default duration
                UnitPrice = allocationToReplace.Fridge.FridgeModel.MonthlyRentalPrice
            });

            return request;
        }

        public (bool isValid, List<string> errors) ValidateForSubmission()
        {
            var errors = new List<string>();

            if (CustomerId <= 0)
                errors.Add("Valid customer is required");

            if (DeliveryLocationId <= 0)
                errors.Add("Delivery location is required");

            if (string.IsNullOrWhiteSpace(ContactPerson))
                errors.Add("Contact person is required");

            if (string.IsNullOrWhiteSpace(ContactPhoneNumber))
                errors.Add("Contact phone number is required");

            if (!RequestDetails.Any())
                errors.Add("At least one fridge item is required");

            // Replacement-specific validation
            if (IsReplacementRequest)
            {
                if (!ReplacingAllocationId.HasValue)
                    errors.Add("Replacement requests must specify which allocation is being replaced");

                if (string.IsNullOrWhiteSpace(ReplacementReason))
                    errors.Add("Replacement reason is required for replacement requests");
            }

            if (TotalQuantity > 50)
                errors.Add("Total quantity cannot exceed 50 units per request");

            if (TotalContractValue > 50000)
                errors.Add("Total contract value cannot exceed R50,000");

            return (!errors.Any(), errors);
        }

        public bool HasSufficientStock()
        {
            return RequestDetails.All(detail =>
            {
                var availableStock = GetAvailableStockForModel(detail.FridgeModelId);
                return detail.Quantity <= availableStock;
            });
        }

        public int GetAvailableStockForModel(int fridgeModelId)
        {
            // This would query your fridge inventory
            // Placeholder implementation
            return _dbContext?.Fridges?.Count(f =>
                f.FridgeModelId == fridgeModelId &&
                f.Status == FridgeStatus.Available) ?? 10;
        }

        public void GenerateRequestNumber()
        {
            if (string.IsNullOrEmpty(RequestNumber))
            {
                var prefix = RequestType switch
                {
                    CustomerRequestType.Replacement => "REP",
                    CustomerRequestType.AdditionalUnits => "ADD",
                    _ => "REQ"
                };
                RequestNumber = $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Id:00000}";
            }
        }

        // Method to process the request and create allocations
        public List<FridgeAllocation> ProcessApprovedRequest(int processedByEmployeeId, string processedBy)
        {
            var newAllocations = new List<FridgeAllocation>();

            if (Status != AllocationRequestStatus.Approved)
                return newAllocations;

            foreach (var detail in RequestDetails)
            {
                for (int i = 0; i < detail.Quantity; i++)
                {
                    var allocation = new FridgeAllocation
                    {
                        FridgeId = GetAvailableFridgeId(detail.FridgeModelId), // You need to implement this
                        CustomerId = CustomerId,
                        AllocatedByEmployeeId = processedByEmployeeId,
                        DeliveryLocationId = DeliveryLocationId,
                        AllocationStatus = AllocationStatus.Active,
                        AllocationDate = DateTime.UtcNow,
                        MonthlyRentalPrice = detail.UnitPrice,
                        AllocationRequestHeaderId = Id,
                        CreatedBy = processedBy
                    };

                    newAllocations.Add(allocation);
                    Allocations.Add(allocation);
                }
            }

            // If this is a replacement, deactivate the old allocation
            if (IsReplacementRequest && ReplacingAllocationId.HasValue)
            {
                var oldAllocation = _dbContext?.FridgeAllocations
                    .FirstOrDefault(a => a.Id == ReplacingAllocationId.Value);

                if (oldAllocation != null)
                {
                    oldAllocation.UpdateStatus(AllocationStatus.Completed, processedBy,
                        $"Replaced by allocation request #{RequestNumber}");
                    ReplacementAllocations.Add(oldAllocation);
                }
            }

            UpdateStatus(AllocationRequestStatus.InProgress, processedBy);
            return newAllocations;
        }

        private int GetAvailableFridgeId(int fridgeModelId)
        {
            // Implement logic to find available fridge of specified model
            // This is a placeholder
            var availableFridge = _dbContext?.Fridges
                .FirstOrDefault(f => f.FridgeModelId == fridgeModelId && f.Status == FridgeStatus.Available);
            return availableFridge?.Id ?? 0;
        }

        // This would be set from your DbContext
        [NotMapped]
        private ApplicationDbContext? _dbContext { get; set; }
        public void SetDbContext(ApplicationDbContext dbContext) => _dbContext = dbContext;
    }
}
