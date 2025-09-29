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

        // Request Information
        [Display(Name = "Request Number")]
        public string RequestNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = "Request date is required.")]
        [Display(Name = "Request Date *")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type *")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Priority level is required.")]
        [Display(Name = "Priority *")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status *")]
        public AllocationRequestStatus Status { get; set; } = AllocationRequestStatus.Draft;

        // Customer Information
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer *")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid customer.")]
        public int CustomerId { get; set; }

        // Contact Information
        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person *")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [Display(Name = "Phone Number *")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        // Delivery Information
        [Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location *")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid delivery location.")]
        public int DeliveryLocationId { get; set; }

        [StringLength(500, ErrorMessage = "Delivery instructions cannot exceed 500 characters.")]
        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        [Display(Name = "Preferred Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateGreaterThan("RequestDate", ErrorMessage = "Preferred delivery date must be after request date.")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // Financial Information
        [Display(Name = "Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        public decimal DiscountPercentage { get; set; }

        [Display(Name = "Special Notes")]
        [StringLength(1000, ErrorMessage = "Special notes cannot exceed 1000 characters.")]
        public string? SpecialNotes { get; set; }

        // Request Details
        [Display(Name = "Request Details")]
        [ValidateEnumerable(ErrorMessage = "At least one fridge item is required.")]
        public List<AllocationRequestDetailVM> RequestDetails { get; set; } = new();

        // Dropdown Lists
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

        // Display Properties (for read-only views)
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Customer Business Type")]
        public BusinessType CustomerBusinessType { get; set; }

        [Display(Name = "Location Address")]
        public string? LocationAddress { get; set; }

        // Computed Properties
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

        [Display(Name = "Total Items")]
        public int TotalItems => RequestDetails.Sum(d => d.Quantity);

        // Status Flags
        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [Display(Name = "Can Be Edited")]
        public bool CanBeEdited => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Requires Approval")]
        public bool RequiresApproval => Status == AllocationRequestStatus.Draft || Status == AllocationRequestStatus.Submitted;

        [Display(Name = "Has Stock Issues")]
        public bool HasStockIssues => RequestDetails.Any(d => !d.HasSufficientStock);

        [Display(Name = "Is Complete")]
        public bool IsComplete => Status == AllocationRequestStatus.Completed;

        // Validation Methods
        public bool IsValidForSubmission()
        {
            return CustomerId > 0 &&
                   DeliveryLocationId > 0 &&
                   !string.IsNullOrWhiteSpace(ContactPerson) &&
                   !string.IsNullOrWhiteSpace(PhoneNumber) &&
                   RequestDetails.Count > 0 &&
                   RequestDetails.All(d => d.IsValid) &&
                   !HasStockIssues;
        }

        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (CustomerId <= 0) errors.Add("Customer selection is required");
            if (DeliveryLocationId <= 0) errors.Add("Delivery location is required");
            if (string.IsNullOrWhiteSpace(ContactPerson)) errors.Add("Contact person is required");
            if (string.IsNullOrWhiteSpace(PhoneNumber)) errors.Add("Phone number is required");
            if (RequestDetails.Count == 0) errors.Add("At least one fridge item is required");

            var stockErrors = RequestDetails.Where(d => !d.HasSufficientStock)
                .Select(d => $"{d.ModelName}: Only {d.AvailableStock} available, requested {d.Quantity}");
            errors.AddRange(stockErrors);

            var invalidDetails = RequestDetails.Where(d => !d.IsValid)
                .Select(d => $"{d.ModelName}: Invalid quantity or rental duration");
            errors.AddRange(invalidDetails);

            return errors;
        }

        // Mapping helper methods
        public AllocationRequestHeader ToEntity(string currentUserId, string currentUserName)
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
                ContactPhoneNumber = PhoneNumber?.Trim() ?? string.Empty,
                ContactEmail = Email?.Trim(),
                DeliveryLocationId = DeliveryLocationId,
                DeliveryInstructions = DeliveryInstructions?.Trim(),
                PreferredDeliveryDate = PreferredDeliveryDate,
                DiscountPercentage = DiscountPercentage,
                SpecialNotes = SpecialNotes?.Trim(),
            };

            // Set CreatedAt for new entities only
            if (Id == 0)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            return entity;
        }


        public static AllocationRequestHeaderVM FromEntity(AllocationRequestHeader entity)
        {
            return new AllocationRequestHeaderVM
            {
                Id = entity.Id,
                RequestDate = entity.RequestDate,
                RequestType = entity.RequestType,
                Priority = entity.Priority,
                Status = entity.Status,
                CustomerId = entity.CustomerId,
                ContactPerson = entity.ContactPerson,
                PhoneNumber = entity.ContactPhoneNumber,
                Email = entity.ContactEmail,
                DeliveryLocationId = entity.DeliveryLocationId,
                DeliveryInstructions = entity.DeliveryInstructions,
                PreferredDeliveryDate = entity.PreferredDeliveryDate,
                DiscountPercentage = entity.DiscountPercentage,
                SpecialNotes = entity.SpecialNotes,
                CustomerName = entity.Customer?.TradingName ?? string.Empty,
                CustomerBusinessType = entity.Customer?.BusinessType ?? BusinessType.SpazaShop,
                LocationAddress = entity.DeliveryLocation?.ToString() ?? string.Empty
            };
        }

        public void SanitizeInput()
        {
            ContactPerson = ContactPerson?.Trim() ?? string.Empty;
            PhoneNumber = PhoneNumber?.Trim() ?? string.Empty;
            Email = Email?.Trim();
            DeliveryInstructions = DeliveryInstructions?.Trim();
            SpecialNotes = SpecialNotes?.Trim();
        }

        // Business rule: Calculate suggested target date
        public DateTime CalculateSuggestedTargetDate()
        {
            var baseDate = PreferredDeliveryDate ?? RequestDate.AddDays(7);
            return baseDate.AddDays(14); // 2 weeks after preferred date or 3 weeks after request
        }

    }
}
