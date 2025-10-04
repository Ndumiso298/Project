using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PurchaseRequestItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Purchase request is required.")]
        [Display(Name = "Purchase Request")]
        public int PurchaseRequestId { get; set; }

        [ForeignKey(nameof(PurchaseRequestId))]
        [ValidateNever]
        [Display(Name = "Purchase Request")]
        public virtual PurchaseRequest PurchaseRequest { get; set; } = null!;

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        [Display(Name = "Fridge")]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        // Optional: Estimated pricing
        [Display(Name = "Estimated Unit Price (R)")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Estimated price must be a positive value.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Estimated price must be a valid monetary value.")]
        public decimal? EstimatedUnitPrice { get; set; }

        [NotMapped]
        [Display(Name = "Estimated Line Total (R)")]
        [DataType(DataType.Currency)]
        public decimal EstimatedLineTotal =>
            EstimatedUnitPrice.HasValue
                ? EstimatedUnitPrice.Value * Quantity
                : 0;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        // Tracking for fulfillment
        [Display(Name = "Quantity Ordered")]
        [Range(0, 1000, ErrorMessage = "Quantity ordered must be between 0 and 1000.")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Quantity Received")]
        [Range(0, 1000, ErrorMessage = "Quantity received must be between 0 and 1000.")]
        public int QuantityReceived { get; set; }

        [NotMapped]
        [Display(Name = "Pending Quantity")]
        public int PendingQuantity => Math.Max(0, Quantity - QuantityReceived);

        [NotMapped]
        [Display(Name = "Status")]
        public string Status
        {
            get
            {
                if (QuantityReceived >= Quantity) return "Complete";
                if (QuantityOrdered > 0) return "Partially Received";
                return "Not Ordered";
            }
        }

        // Audit fields
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Modified")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
