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

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        // Financial Information
        [Display(Name = "Request Total")]
        [DataType(DataType.Currency)]
        public decimal RequestTotal => RequestDetails.Sum(d => d.LineTotal);

        [Display(Name = "Total Items")]
        public int TotalItems => RequestDetails.Sum(d => d.Quantity);

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

        public bool CanEdit => Status == AllocationRequestStatus.Draft;
        public bool CanDelete => Status == AllocationRequestStatus.Draft;
        public bool CanProcess => Status == AllocationRequestStatus.Draft || Status == AllocationRequestStatus.UnderReview;
    }
}

