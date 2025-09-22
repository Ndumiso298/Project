using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Project.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class RequestHeader
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Request date is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Request total is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Request total must be a positive value.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Amount")]
        public decimal RequestTotal { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be a 4-digit number.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Cell number is required.")]
        [StringLength(15, ErrorMessage = "Cell number cannot exceed 15 characters.")]
        [Phone, RegularExpression(@"^(\+27|0)[0-9]{9}$", ErrorMessage = "Please enter a valid South African phone number.")]
        [Display(Name = "Cell Number")]
        public string PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Carrier name cannot exceed 50 characters.")]
        [Display(Name = "Carrier")]
        public string? Carrier { get; set; }

        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        [Display(Name = "Status")]
        public string? Status { get; set; } = "Waiting For Payment";

        [DataType(DataType.DateTime)]
        [Display(Name = "Shipping Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? ShippingDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Payment Due Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? PaymentDueDate { get; set; }

        [ValidateNever]
        [Display(Name = "Fridge Allocations")]
        public ICollection<FridgeAllocation> Allocations { get; set; }

        [ValidateNever]
        [Display(Name = "Requested Fridges")]
        public ICollection<RequestDetail> RequestFridges { get; set; }
    }
}
