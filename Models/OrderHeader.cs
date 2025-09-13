using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required(ErrorMessage = "CustomerId is required.")]
        [Display(Name = "Customer Id*")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        [Display(Name = "Order Date*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Order total is required.")]
        [Display(Name = "Order Total*")]
        [Range(0, double.MaxValue, ErrorMessage = "Order total must be a positive value.")]
        public decimal OrderTotal { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        [Display(Name = "Order Status*")]
        [StringLength(50, ErrorMessage = "Order status cannot exceed 50 characters.")]
        public string OrderStatus { get; set; } = "Pending";

        [Required(ErrorMessage = "Payment status is required.")]
        [Display(Name = "Payment Status*")]
        [StringLength(50, ErrorMessage = "Payment status cannot exceed 50 characters.")]
        public string PaymentStatus { get; set; } = "Unpaid";

        [Display(Name = "Payment Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment due date is required.")]
        [Display(Name = "Payment Due Date*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PaymentDueDate { get; set; }

        [Required(ErrorMessage = "Shipping date is required.")]
        [Display(Name = "Shipping Date*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ShippingDate { get; set; }

        [Required(ErrorMessage = "Delivery address is required.")]
        [Display(Name = "Delivery Address*")]
        public int DeliveryAddressId { get; set; }

        [ForeignKey("DeliveryAddressId")]
        [ValidateNever]
        public virtual Location DeliveryAddress { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Tracking number cannot exceed 100 characters.")]
        [Display(Name = "Tracking Number")]
        public string? TrackingNumber { get; set; }

        [StringLength(50, ErrorMessage = "Carrier name cannot exceed 50 characters.")]
        [Display(Name = "Carrier")]
        public string? Carrier { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Recipient first name is required.")]
        [StringLength(100, ErrorMessage = "Recipient first name cannot exceed 100 characters.")]
        [Display(Name = "Recipient First Name*")]
        public string RecipientFirstName { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "Recipient last name is required.")]
        [StringLength(100, ErrorMessage = "Recipient last name cannot exceed 100 characters.")]
        [Display(Name = "Recipient Last Name*")]
        public string RecipientLastName { get; set; } = string.Empty;

        [NotMapped]
        [Display(Name = "Recipient Full Name")]
        public string RecipientFullName => $"{RecipientFirstName} {RecipientLastName}";

        [NotMapped]
        [Display(Name = "Primary Contact No")]
        public string RecipientPhone;
    }
}
