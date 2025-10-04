using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestSubmissionVM
    {
        // ===== CUSTOMER INFORMATION =====
        public int CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [Display(Name = "Contact Phone Number")]
        public string ContactPhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Contact Email Address")]
        public string? ContactEmail { get; set; }

        // ===== REQUEST TYPE & PRIORITY =====
        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        // ===== REPLACEMENT-SPECIFIC FIELDS =====
        [Display(Name = "Replacing Allocation")]
        public int? ReplacingAllocationId { get; set; }

        [Display(Name = "Replacement Reason")]
        [StringLength(1000, ErrorMessage = "Replacement reason cannot exceed 1000 characters.")]
        public string? ReplacementReason { get; set; }

        [Display(Name = "Urgent Replacement")]
        public bool IsUrgentReplacement { get; set; }

        // ===== DELIVERY INFORMATION =====
        [Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a delivery location.")]
        public int DeliveryLocationId { get; set; }

        [StringLength(500, ErrorMessage = "Special instructions cannot exceed 500 characters.")]
        [Display(Name = "Special Instructions")]
        public string? SpecialInstructions { get; set; }

        [Display(Name = "Preferred Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // ===== ADDITIONAL OPTIONS =====
        [Display(Name = "Requires Installation")]
        public bool RequiresInstallation { get; set; }

        [Display(Name = "Preferred Contact Method")]
        public ContactMethod PreferredContactMethod { get; set; } = ContactMethod.Phone;

        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        [Display(Name = "Terms Accepted")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
        public bool TermsAccepted { get; set; }

        // ===== CART ITEMS =====
        public List<AllocationCartItemVM> Items { get; set; } = new();

        // ===== DROPDOWN LISTS =====
        [ValidateNever]
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RequestTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ReplacementAllocationList { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Is Replacement Request")]
        public bool IsReplacementRequest => RequestType == CustomerRequestType.Replacement;

        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => Items.Sum(i => i.MonthlyTotal);

        [Display(Name = "Total Contract Value")]
        [DataType(DataType.Currency)]
        public decimal TotalContractValue => Items.Sum(i => i.LineTotal);

        [Display(Name = "Total Items")]
        public int TotalItems => Items.Sum(i => i.Quantity);

        [Display(Name = "Has Stock Issues")]
        public bool HasStockIssues => Items.Any(i => !i.HasSufficientStock);

        [Display(Name = "Can Submit")]
        public bool CanSubmit => Items.Any() &&
                               TermsAccepted &&
                               !HasStockIssues &&
                               !string.IsNullOrWhiteSpace(ContactPerson) &&
                               !string.IsNullOrWhiteSpace(ContactPhoneNumber) &&
                               DeliveryLocationId > 0 &&
                               ValidateReplacementSpecificRules();

        // ===== VALIDATION METHODS =====
        private bool ValidateReplacementSpecificRules()
        {
            if (!IsReplacementRequest) return true;

            // Replacement-specific validation
            return ReplacingAllocationId.HasValue &&
                   !string.IsNullOrWhiteSpace(ReplacementReason);
        }

        public IEnumerable<string> GetSubmissionErrors()
        {
            var errors = new List<string>();

            if (CustomerId <= 0) errors.Add("Customer selection is required");
            if (string.IsNullOrWhiteSpace(ContactPerson)) errors.Add("Contact person is required");
            if (string.IsNullOrWhiteSpace(ContactPhoneNumber)) errors.Add("Phone number is required");
            if (DeliveryLocationId <= 0) errors.Add("Delivery location is required");
            if (!Items.Any()) errors.Add("At least one fridge item is required");
            if (!TermsAccepted) errors.Add("You must accept the terms and conditions");

            // Replacement-specific validation
            if (IsReplacementRequest)
            {
                if (!ReplacingAllocationId.HasValue)
                    errors.Add("Replacement requests must specify which allocation is being replaced");
                if (string.IsNullOrWhiteSpace(ReplacementReason))
                    errors.Add("Replacement reason is required for replacement requests");
            }

            var stockErrors = Items.Where(i => !i.HasSufficientStock)
                .Select(i => $"{i.ModelName}: Only {i.AvailableStock} available, requested {i.Quantity}");
            errors.AddRange(stockErrors);

            return errors;
        }

        // ===== BUSINESS METHODS =====
        public void MarkAsReplacementFor(int allocationId, string reason)
        {
            RequestType = CustomerRequestType.Replacement;
            ReplacingAllocationId = allocationId;
            ReplacementReason = reason;
            Priority = CustomerRequestPriority.High;
            IsUrgentReplacement = true;
        }

        // ===== MAPPING METHODS =====
        public AllocationRequestHeaderVM ToRequestHeaderVM()
        {
            return new AllocationRequestHeaderVM
            {
                CustomerId = CustomerId,
                ContactPerson = ContactPerson,
                ContactPhoneNumber = ContactPhoneNumber,
                ContactEmail = ContactEmail,
                DeliveryLocationId = DeliveryLocationId,
                DeliveryInstructions = SpecialInstructions,
                PreferredDeliveryDate = PreferredDeliveryDate,
                RequestType = RequestType,
                Priority = Priority,
                ReplacingAllocationId = ReplacingAllocationId,
                ReplacementReason = ReplacementReason,
                IsUrgentReplacement = IsUrgentReplacement,
                RequestDetails = Items.Select(i => i.ToRequestDetailVM()).ToList()
            };
        }
    }
}
