using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PurchaseRequestItem
    {
        public int Id { get; set; }

        [Required]
        public int PurchaseRequestId { get; set; }

        [ForeignKey(nameof(PurchaseRequestId))]
        [ValidateNever]
        public virtual PurchaseRequest PurchaseRequest { get; set; } = null!;

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }

        // Optional: Estimated pricing
        [Display(Name = "Estimated Unit Price (R)")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Estimated price must be a positive value.")]
        public decimal? EstimatedUnitPrice { get; set; }

        [NotMapped]
        [Display(Name = "Estimated Line Total (R)")]
        public decimal EstimatedLineTotal =>
            EstimatedUnitPrice.HasValue
                ? EstimatedUnitPrice.Value * Quantity
                : 0;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        // Tracking for fulfillment
        [Display(Name = "Quantity Ordered")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Quantity Received")]
        public int QuantityReceived { get; set; }

        [NotMapped]
        [Display(Name = "Pending Quantity")]
        public int PendingQuantity => Quantity - QuantityReceived;
    }
}
