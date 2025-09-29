using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestSubmissionVM
    {
        public int CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

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

        [StringLength(500, ErrorMessage = "Special instructions cannot exceed 500 characters.")]
        [Display(Name = "Special Instructions")]
        public string? SpecialInstructions { get; set; }

        [Display(Name = "Urgent Request")]
        public bool IsUrgent { get; set; }

        [Display(Name = "Requires Installation")]
        public bool RequiresInstallation { get; set; }

        [Display(Name = "Preferred Contact Method")]
        public ContactMethod PreferredContactMethod { get; set; } = ContactMethod.Phone;

        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        [Display(Name = "Terms Accepted *")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
        public bool TermsAccepted { get; set; }

        [Display(Name = "Delivery Location")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a delivery location.")]
        public int DeliveryLocationId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        public List<AllocationCartItemVM> Items { get; set; } = new();

        // Computed Properties
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
                               !string.IsNullOrWhiteSpace(PhoneNumber) &&
                               DeliveryLocationId > 0;

        // Validation Methods
        public IEnumerable<string> GetSubmissionErrors()
        {
            var errors = new List<string>();

            if (CustomerId <= 0) errors.Add("Customer selection is required");
            if (string.IsNullOrWhiteSpace(ContactPerson)) errors.Add("Contact person is required");
            if (string.IsNullOrWhiteSpace(PhoneNumber)) errors.Add("Phone number is required");
            if (DeliveryLocationId <= 0) errors.Add("Delivery location is required");
            if (!Items.Any()) errors.Add("At least one fridge item is required");
            if (!TermsAccepted) errors.Add("You must accept the terms and conditions");

            var stockErrors = Items.Where(i => !i.HasSufficientStock)
                .Select(i => $"{i.ModelName}: Only {i.AvailableStock} available, requested {i.Quantity}");
            errors.AddRange(stockErrors);

            return errors;
        }
    }
}
