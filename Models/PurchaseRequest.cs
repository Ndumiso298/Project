using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class PurchaseRequest
    {
        public int Id { get; set; }

        [Required]
        public int RequestedById { get; set; }

        [ForeignKey(nameof(RequestedById))]
        [InverseProperty(nameof(Employee.RequestedPurchaseRequests))]
        public virtual Employee RequestedBy { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Status")]
        public PurchaseRequestStatus Status { get; set; } = PurchaseRequestStatus.Draft;

        [Required]
        [Display(Name = "Reason")]
        public PurchaseRequestReason Reason { get; set; } = PurchaseRequestReason.LowStock;

        // For "Other" reason, allow specification
        [StringLength(200, ErrorMessage = "Custom reason cannot exceed 200 characters.")]
        [Display(Name = "Custom Reason")]
        public string? CustomReason { get; set; }

        [Required]
        [Display(Name = "Urgency Level")]
        public PurchaseRequestUrgency Urgency { get; set; } = PurchaseRequestUrgency.Normal;

        [Required(ErrorMessage = "Required by date is essential.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Required By Date")]
        public DateTime RequiredByDate { get; set; }

        // Budget information
        [Display(Name = "Estimated Total Cost")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Estimated cost must be a positive value.")]
        public decimal? EstimatedTotalCost { get; set; }

        [Display(Name = "Approved Budget")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Approved budget must be a positive value.")]
        public decimal? ApprovedBudget { get; set; }

        // Approval information
        [Display(Name = "Approved By")]
        public int? ApprovedById { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(Employee.ApprovedPurchaseRequests))]
        public virtual Employee? ApprovedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(500, ErrorMessage = "Approval notes cannot exceed 500 characters.")]
        [Display(Name = "Approval Notes")]
        public string? ApprovalNotes { get; set; }

        // Request items
        [ValidateNever]
        public virtual ICollection<PurchaseRequestItem> Items { get; set; } = new List<PurchaseRequestItem>();

        // Metadata
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        // Computed properties
        [NotMapped]
        [Display(Name = "Total FridgeAllocations Requested")]
        public int TotalQuantity => Items?.Sum(i => i.Quantity) ?? 0;

        [NotMapped]
        [Display(Name = "Total Estimated Cost")]
        public decimal TotalEstimatedCost => Items?.Sum(i => i.EstimatedLineTotal) ?? 0;

        [NotMapped]
        [Display(Name = "Is Urgent")]
        public bool IsUrgent => Urgency == PurchaseRequestUrgency.High ||
                              Urgency == PurchaseRequestUrgency.Critical;

        [NotMapped]
        [Display(Name = "Days Until Due")]
        public int DaysUntilDue => (RequiredByDate - DateTime.UtcNow).Days;
    }
}
