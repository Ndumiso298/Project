using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

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

        [Display(Name = "Carrier")]
        public string? Carrier { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Display(Name = "Shipping Date")]
        public DateTime? ShippingDate { get; set; }

        [Display(Name = "Payment Due Date")]
        public DateTime? PaymentDueDate { get; set; }

        [Display(Name = "Request Items")]
        public List<AllocationRequestDetailVM> RequestDetails { get; set; } = new();

        public IEnumerable<SelectListItem>? FridgeList { get; set; }
    }
}

