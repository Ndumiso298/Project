using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey("FridgeId")]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Requested By is required.")]
        [Display(Name = "Requested By")]
        public int StockControllerId { get; set; }

        [ForeignKey("StockControllerId")]
        [ValidateNever]
        public virtual StockController StockController { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Fridge Quantity must be at least 1.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Reason")]
        public string Reason { get; set; } = string.Empty;

        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";// Pending, Approved, Rejected

        [Display(Name = "Processed Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ProcessedDate { get; set; }

        [StringLength(500, ErrorMessage = "Processing Notes cannot exceed 500 characters.")]
        [Display(Name = "Processing Notes")]
        public string? ProcessingNotes { get; set; }

        //[Display(Name = "Processed By")]
        //public int? ProcessedById { get; set; }

        //[ForeignKey("ProcessedById")]
        //[ValidateNever]
        //public virtual PurchasingManager? ProcessedBy { get; set; }

        //[ValidateNever]
        //public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
        //[Display(Name = "Created At")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}