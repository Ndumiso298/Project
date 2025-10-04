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
        public int PurchaseRequestId { get; set; }

        [ForeignKey(nameof(PurchaseRequestId))]
        [ValidateNever]
        public virtual PurchaseRequest PurchaseRequest { get; set; } = null!;

        [Required]
        public int FridgeModelId { get; set; }

        [ForeignKey(nameof(FridgeModelId))]
        [ValidateNever]
        public virtual FridgeModel FridgeModel { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }

        // Optional: Estimated pricing
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Estimated price must be a positive value.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Estimated price must be a valid monetary value.")]
        public decimal? EstimatedUnitPrice { get; set; }

        [NotMapped]
        [DataType(DataType.Currency)]
        public decimal EstimatedLineTotal =>
            EstimatedUnitPrice.HasValue
                ? EstimatedUnitPrice.Value * Quantity
                : 0;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        // Tracking for fulfillment
        [Range(0, 1000, ErrorMessage = "Quantity ordered must be between 0 and 1000.")]
        public int QuantityOrdered { get; set; }

        [Range(0, 1000, ErrorMessage = "Quantity received must be between 0 and 1000.")]
        public int QuantityReceived { get; set; }

        [NotMapped]
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

        // Metadata
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;
    }
}
