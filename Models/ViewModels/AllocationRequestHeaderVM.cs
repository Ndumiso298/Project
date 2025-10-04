using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models.ViewModels
{
    public class AllocationRequestHeaderVM
    {
        public int Id { get; set; }

        // ===== REQUEST INFORMATION =====
        [Display(Name = "Request Number")]
        public string RequestNumber { get; set; } = GenerateRequestNumber();

        [Required(ErrorMessage = "Request date is required.")]
        [Display(Name = "Request Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Priority level is required.")]
        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationRequestStatus Status { get; set; } = AllocationRequestStatus.Draft;

        // ===== REPLACEMENT-SPECIFIC FIELDS =====
        [Display(Name = "Replacing Allocation")]
        public int? ReplacingAllocationId { get; set; }

        [Display(Name = "Replacing Fridge")]
        public int? ReplacingFridgeId { get; set; }

        [Display(Name = "Related Fault")]
        public int? RelatedFaultRecordId { get; set; }

        [Display(Name = "Urgent Replacement")]
        public bool IsUrgentReplacement { get; set; }

        [StringLength(1000, ErrorMessage = "Replacement reason cannot exceed 1000 characters.")]
        [Display(Name = "Replacement Reason")]
        public string? ReplacementReason { get; set; }

        // ===== CUSTOMER INFORMATION =====
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid customer.")]
        public int CustomerId { get; set; }

        // ===== CONTACT INFORMATION =====
        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [Display(Name = "Contact Phone")]
        public string ContactPhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }

        // ===== DELIVERY INFORMATION =====
        //[Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid delivery location.")]
        public int? DeliveryLocationId { get; set; }

        [StringLength(500, ErrorMessage = "Delivery instructions cannot exceed 500 characters.")]
        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        [Display(Name = "Preferred Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateGreaterThan("RequestDate", ErrorMessage = "Preferred delivery date must be after request date.")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // ===== FINANCIAL INFORMATION =====
        [Display(Name = "Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        public decimal DiscountPercentage { get; set; }

        [StringLength(1000, ErrorMessage = "Special notes cannot exceed 1000 characters.")]
        [Display(Name = "Special Notes")]
        public string? SpecialNotes { get; set; }

        // ===== REQUEST DETAILS =====
        [Display(Name = "Request Details")]
        [ValidateEnumerable(ErrorMessage = "At least one fridge item is required.")]
        public List<AllocationRequestDetailVM> RequestDetails { get; set; } = new();

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

        // ===== DROPDOWN LISTS =====
        [ValidateNever]
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RequestTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ReplacementAllocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FaultRecordList { get; set; }

        // ===== DISPLAY PROPERTIES =====
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Customer Business")]
        public string CustomerBusinessName { get; set; } = string.Empty;

        [Display(Name = "Business Type")]
        public BusinessType CustomerBusinessType { get; set; }

        [Display(Name = "Location Address")]
        public string? LocationAddress { get; set; }

        [Display(Name = "Replacing Allocation Info")]
        public string? ReplacingAllocationInfo { get; set; }

        [Display(Name = "Related Fault Info")]
        public string? RelatedFaultInfo { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Total Quantity")]
        public int TotalQuantity => RequestDetails.Sum(d => d.Quantity);

        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => RequestDetails.Sum(d => d.MonthlyTotal);

        [Display(Name = "Total Contract Value")]
        [DataType(DataType.Currency)]
        public decimal TotalContractValue => RequestDetails.Sum(d => d.LineTotal);

        [Display(Name = "Discount Amount")]
        [DataType(DataType.Currency)]
        public decimal DiscountAmount => TotalContractValue * (DiscountPercentage / 100);

        [Display(Name = "Final Amount")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount => TotalContractValue - DiscountAmount;

        [Display(Name = "Is Replacement Request")]
        public bool IsReplacementRequest => RequestType == CustomerRequestType.Replacement;

        [Display(Name = "Is New Allocation")]
        public bool IsNewAllocation => RequestType == CustomerRequestType.NewAllocation;

        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [Display(Name = "Can Be Edited")]
        public bool CanBeEdited => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Requires Approval")]
        public bool RequiresApproval => Status == AllocationRequestStatus.Draft ||
                                       Status == AllocationRequestStatus.Submitted;

        [Display(Name = "Has Stock Issues")]
        public bool HasStockIssues => RequestDetails.Any(d => !d.HasSufficientStock);

        [Display(Name = "Is Complete")]
        public bool IsComplete => Status == AllocationRequestStatus.Completed;

        [Display(Name = "Has Existing Fault")]
        public bool HasExistingFault => RelatedFaultRecordId.HasValue;

        [Display(Name = "Request Type Badge Class")]
        public string RequestTypeBadgeClass => RequestType switch
        {
            CustomerRequestType.NewAllocation => "bg-primary",
            CustomerRequestType.Replacement => "bg-warning",
            CustomerRequestType.AdditionalUnits => "bg-info",
            _ => "bg-secondary"
        };

        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            AllocationRequestStatus.Draft => "bg-secondary",
            AllocationRequestStatus.Submitted => "bg-info",
            AllocationRequestStatus.UnderReview => "bg-warning",
            AllocationRequestStatus.Approved => "bg-success",
            AllocationRequestStatus.InProgress => "bg-primary",
            AllocationRequestStatus.Completed => "bg-dark",
            AllocationRequestStatus.Rejected => "bg-danger",
            AllocationRequestStatus.Cancelled => "bg-secondary",
            _ => "bg-secondary"
        };

        [Display(Name = "Priority Badge Class")]
        public string PriorityBadgeClass => Priority switch
        {
            CustomerRequestPriority.Low => "bg-success",
            CustomerRequestPriority.Medium => "bg-info",
            CustomerRequestPriority.High => "bg-warning",
            CustomerRequestPriority.Critical => "bg-danger",
            _ => "bg-secondary"
        };

        // ===== STATIC METHODS =====
        private static string GenerateRequestNumber()
        {
            var prefix = "REQ"; // Will be overridden based on type
            return $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
        }

        // ===== VALIDATION METHODS =====
        public bool IsValidForSubmission()
        {
            return CustomerId > 0 &&
                   DeliveryLocationId > 0 &&
                   !string.IsNullOrWhiteSpace(ContactPerson) &&
                   !string.IsNullOrWhiteSpace(ContactPhoneNumber) &&
                   RequestDetails.Count > 0 &&
                   RequestDetails.All(d => d.IsValid) &&
                   ValidateReplacementSpecificRules();
        }

        private bool ValidateReplacementSpecificRules()
        {
            if (!IsReplacementRequest) return true;

            // Replacement-specific validation
            if (!ReplacingAllocationId.HasValue)
                return false;

            if (string.IsNullOrWhiteSpace(ReplacementReason))
                return false;

            return true;
        }

        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (CustomerId <= 0) errors.Add("Customer selection is required");
            if (DeliveryLocationId <= 0) errors.Add("Delivery location is required");
            if (string.IsNullOrWhiteSpace(ContactPerson)) errors.Add("Contact person is required");
            if (string.IsNullOrWhiteSpace(ContactPhoneNumber)) errors.Add("Phone number is required");
            if (RequestDetails.Count == 0) errors.Add("At least one fridge item is required");

            // Replacement-specific validation
            if (IsReplacementRequest)
            {
                if (!ReplacingAllocationId.HasValue)
                    errors.Add("Replacement requests must specify which allocation is being replaced");
                if (string.IsNullOrWhiteSpace(ReplacementReason))
                    errors.Add("Replacement reason is required for replacement requests");
            }

            // Business rules
            if (TotalQuantity > 100)
                errors.Add("Total quantity cannot exceed 100 units per request");

            if (TotalContractValue > 100000)
                errors.Add("Total contract value cannot exceed R100,000");

            // Stock validation
            var stockErrors = RequestDetails.Where(d => !d.HasSufficientStock)
                .Select(d => $"{d.ModelName}: Only {d.AvailableStock} available, requested {d.Quantity}");
            errors.AddRange(stockErrors);

            return errors;
        }

        // ===== BUSINESS METHODS =====
        public bool CanTransitionTo(AllocationRequestStatus newStatus)
        {
            return Status switch
            {
                AllocationRequestStatus.Draft => newStatus == AllocationRequestStatus.Submitted,
                AllocationRequestStatus.Submitted => newStatus == AllocationRequestStatus.UnderReview ||
                                                   newStatus == AllocationRequestStatus.Rejected,
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

        public void MarkAsReplacementFor(int allocationId, int fridgeId, int? faultRecordId, string reason)
        {
            RequestType = CustomerRequestType.Replacement;
            ReplacingAllocationId = allocationId;
            ReplacingFridgeId = fridgeId;
            RelatedFaultRecordId = faultRecordId;
            ReplacementReason = reason;
            Priority = CustomerRequestPriority.High;
            IsUrgentReplacement = true;
        }

        public bool HasSufficientStock()
        {
            return RequestDetails.All(detail => detail.HasSufficientStock);
        }

        // ===== MAPPING METHODS =====
        public AllocationRequestHeader ToEntity()
        {
            var entity = new AllocationRequestHeader
            {
                Id = Id,
                RequestNumber = RequestNumber,
                RequestDate = RequestDate,
                RequestType = RequestType,
                Priority = Priority,
                Status = Status,
                CustomerId = CustomerId,
                ContactPerson = ContactPerson?.Trim() ?? string.Empty,
                ContactPhoneNumber = ContactPhoneNumber?.Trim() ?? string.Empty,
                ContactEmail = ContactEmail?.Trim(),
                DeliveryLocationId = DeliveryLocationId,
                DeliveryInstructions = DeliveryInstructions?.Trim(),
                PreferredDeliveryDate = PreferredDeliveryDate,
                DiscountPercentage = DiscountPercentage,
                SpecialNotes = SpecialNotes?.Trim(),
                ReplacingAllocationId = ReplacingAllocationId,
                ReplacingFridgeId = ReplacingFridgeId,
                RelatedFaultRecordId = RelatedFaultRecordId,
                IsUrgentReplacement = IsUrgentReplacement,
                ReplacementReason = ReplacementReason?.Trim(),
                ApprovedBy = ApprovedBy,
                ApprovalDate = ApprovalDate,
                ApprovalNotes = ApprovalNotes,
                CreatedAt = CreatedAt,
                CreatedBy = CreatedBy,
                UpdatedAt = UpdatedAt,
                UpdatedBy = UpdatedBy
            };

            // Generate proper request number based on type
            if (string.IsNullOrEmpty(RequestNumber) || RequestNumber.StartsWith("REQ-"))
            {
                var prefix = RequestType switch
                {
                    CustomerRequestType.Replacement => "REP",
                    CustomerRequestType.AdditionalUnits => "ADD",
                    _ => "REQ"
                };
                entity.RequestNumber = $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Id:00000}";
            }

            return entity;
        }

        public static AllocationRequestHeaderVM FromEntity(AllocationRequestHeader entity)
        {
            if (entity == null) return new AllocationRequestHeaderVM();

            return new AllocationRequestHeaderVM
            {
                Id = entity.Id,
                RequestNumber = entity.RequestNumber,
                RequestDate = entity.RequestDate,
                RequestType = entity.RequestType,
                Priority = entity.Priority,
                Status = entity.Status,
                CustomerId = entity.CustomerId,
                ContactPerson = entity.ContactPerson,
                ContactPhoneNumber = entity.ContactPhoneNumber,
                ContactEmail = entity.ContactEmail,
                DeliveryLocationId = entity.DeliveryLocationId,
                DeliveryInstructions = entity.DeliveryInstructions,
                PreferredDeliveryDate = entity.PreferredDeliveryDate,
                DiscountPercentage = entity.DiscountPercentage,
                SpecialNotes = entity.SpecialNotes,
                ReplacingAllocationId = entity.ReplacingAllocationId,
                ReplacingFridgeId = entity.ReplacingFridgeId,
                RelatedFaultRecordId = entity.RelatedFaultRecordId,
                IsUrgentReplacement = entity.IsUrgentReplacement,
                ReplacementReason = entity.ReplacementReason,
                ApprovedBy = entity.ApprovedBy,
                ApprovalDate = entity.ApprovalDate,
                ApprovalNotes = entity.ApprovalNotes,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                CustomerName = entity.Customer?.BusinessName ?? string.Empty,
                CustomerBusinessName = entity.Customer?.BusinessName ?? string.Empty,
                CustomerBusinessType = entity.Customer?.BusinessType ?? BusinessType.SpazaShop,
                LocationAddress = entity.DeliveryLocation?.ToString() ?? string.Empty,
                ReplacingAllocationInfo = entity.ReplacingAllocation?.DisplayName,
                RelatedFaultInfo = entity.RelatedFaultRecord?.Description
            };
        }

        public void SanitizeInput()
        {
            ContactPerson = ContactPerson?.Trim() ?? string.Empty;
            ContactPhoneNumber = ContactPhoneNumber?.Trim() ?? string.Empty;
            ContactEmail = ContactEmail?.Trim();
            DeliveryInstructions = DeliveryInstructions?.Trim();
            SpecialNotes = SpecialNotes?.Trim();
            ReplacementReason = ReplacementReason?.Trim();
        }

        // ===== CALCULATION METHODS =====
        public DateTime CalculateSuggestedTargetDate()
        {
            var baseDate = PreferredDeliveryDate ?? RequestDate.AddDays(7);
            var urgencyDays = IsUrgentReplacement ? 3 : 14;
            return baseDate.AddDays(urgencyDays);
        }

        public decimal CalculateDiscountAmount()
        {
            return TotalContractValue * (DiscountPercentage / 100);
        }
    }
}
