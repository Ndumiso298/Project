using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestVM
    {
        public int Id { get; set; }

        // Basic Request Info
        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Status")]
        public AllocationRequestStatus Status { get; set; } = AllocationRequestStatus.Draft;

        // Customer Information
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Business Type")]
        public BusinessType CustomerBusinessType { get; set; }

        // Contact Information
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        // Delivery Information
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Delivery instructions cannot exceed 250 characters.")]
        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        // Financial Information
        [Display(Name = "Request Total")]
        [DataType(DataType.Currency)]
        public decimal RequestTotal => RequestDetails.Sum(d => d.LineTotal);

        [Display(Name = "Total Items")]
        public int TotalItems => RequestDetails.Sum(d => d.Quantity);

        [Display(Name = "Average Monthly Cost")]
        [DataType(DataType.Currency)]
        public decimal AverageMonthlyCost => RequestTotal / (RequestDetails?.Max(d => d.RentalDurationMonths) ?? 1);

        // Request Items
        [Display(Name = "Request Items")]
        [ValidateEnumerable(ErrorMessage = "At least one fridge item is required")]
        public List<AllocationRequestDetailVM> RequestDetails { get; set; } = new();

        // Dropdown Lists (for views)
        public IEnumerable<SelectListItem>? CustomerList { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }
        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        // Validation Properties
        [Display(Name = "Is Valid")]
        public bool IsValid => CustomerId > 0 && RequestDetails.Any() && RequestDetails.All(d => d.IsValid);

        [Display(Name = "Has Sufficient Stock")]
        public bool HasSufficientStock => RequestDetails?.All(d => d.HasSufficientStock) == true;

        [Display(Name = "Can Edit")]
        public bool CanEdit => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Can Delete")]
        public bool CanDelete => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Can Process")]
        public bool CanProcess => Status == AllocationRequestStatus.Draft ||
                                Status == AllocationRequestStatus.UnderReview;

        public IEnumerable<string> ValidateBusinessRules()
        {
            var errors = new List<string>();

            if (RequestDetails?.Sum(d => d.Quantity) > 100) // Business rule: max 100 total units
                errors.Add("Total quantity cannot exceed 100 units per request");

            if (RequestTotal > 100000) // Business rule: max request value
                errors.Add("Request total cannot exceed R100,000");

            if (!HasSufficientStock)
                errors.Add("One or more items have insufficient stock");

            return errors;
        }

        public void SanitizeInput()
        {
            // Trim all string inputs to prevent padding attacks
            FirstName = FirstName?.Trim() ?? string.Empty;
            LastName = LastName?.Trim() ?? string.Empty;
            PhoneNumber = PhoneNumber?.Trim() ?? string.Empty;
            Email = Email?.Trim();
            AddressLine1 = AddressLine1?.Trim() ?? string.Empty;
            AddressLine2 = AddressLine2?.Trim();
            City = City?.Trim() ?? string.Empty;
            Province = Province?.Trim() ?? string.Empty;
            PostalCode = PostalCode?.Trim() ?? string.Empty;
            DeliveryInstructions = DeliveryInstructions?.Trim();
        }
    }
}

