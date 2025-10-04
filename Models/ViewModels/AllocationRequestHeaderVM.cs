using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestHeaderVM
    {
        public int Id { get; set; }

        // Customer Information
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer *")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        // Request Information
        [Required(ErrorMessage = "Request date is required.")]
        [Display(Name = "Request Date *")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Waiting For Payment";

        // Contact Person Details
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        [Display(Name = "First Name *")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cell number is required.")]
        [StringLength(15, ErrorMessage = "Cell number cannot exceed 15 characters.")]
        [Phone, RegularExpression(@"^(\+27|0)[0-9]{9}$", ErrorMessage = "Please enter a valid South African phone number.")]
        [Display(Name = "Cell Number *")]
        public string PhoneNumber { get; set; } = string.Empty;

        // Address Information
        [Required(ErrorMessage = "Address line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 1 *")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City *")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [Display(Name = "Province *")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be a 4-digit number.")]
        [Display(Name = "Postal Code *")]
        public string PostalCode { get; set; } = string.Empty;

        // Shipping Information
        [StringLength(50, ErrorMessage = "Carrier name cannot exceed 50 characters.")]
        [Display(Name = "Carrier")]
        public string? Carrier { get; set; }

        [Display(Name = "Shipping Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ShippingDate { get; set; }

        [Display(Name = "Payment Due Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? PaymentDueDate { get; set; }

        // Financial Information
        [Display(Name = "Request Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "R {0:N2}")]
        public decimal RequestTotal => RequestedFridges?.Sum(f => f.TotalPrice) ?? 0;

        // Navigation and Collection
        [ValidateNever]
        [Display(Name = "Requested Fridges")]
        public List<AllocationRequestDetailVM> RequestedFridges { get; set; } = new List<AllocationRequestDetailVM>();

        // Utility Properties
        [Display(Name = "Contact Person")]
        public string ContactPersonFullName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                var addressParts = new List<string> { AddressLine1 };
                if (!string.IsNullOrEmpty(AddressLine2))
                    addressParts.Add(AddressLine2);
                addressParts.AddRange(new[] { City, Province, PostalCode });
                return string.Join(", ", addressParts.Where(p => !string.IsNullOrEmpty(p)));
            }
        }

        // For dropdowns
        public IEnumerable<SelectListItem>? ProvinceList { get; set; }
        public IEnumerable<SelectListItem>? CarrierList { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }
    }
}
