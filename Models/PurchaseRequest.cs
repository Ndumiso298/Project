using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Requested by employee is required.")]
        public int RequestedById { get; set; }

        [ForeignKey(nameof(RequestedById))]
        [InverseProperty(nameof(Employee.RequestedPurchaseRequests))]
        [ValidateNever]
        public virtual Employee RequestedBy { get; set; } = null!;

        [Required(ErrorMessage = "Request date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Status is required.")]
        public PurchaseRequestStatus Status { get; set; } = PurchaseRequestStatus.Draft;

        [Required(ErrorMessage = "Reason is required.")]
        public PurchaseRequestReason Reason { get; set; } = PurchaseRequestReason.LowStock;

        // For "Other" reason, allow specification
        [StringLength(200, ErrorMessage = "Custom reason cannot exceed 200 characters.")]
        public string? CustomReason { get; set; }

        [Required(ErrorMessage = "Urgency level is required.")]
        public PurchaseRequestUrgency Urgency { get; set; } = PurchaseRequestUrgency.Medium;

        [Required(ErrorMessage = "Required by date is essential.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RequiredByDate { get; set; }

        // Budget information
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Estimated cost must be a positive value.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Estimated cost must be a valid monetary value.")]
        public decimal? EstimatedTotalCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Approved budget must be a positive value.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Approved budget must be a valid monetary value.")]
        public decimal? ApprovedBudget { get; set; }

        // Approval information
        public int? ApprovedById { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(Employee.ApprovedPurchaseRequests))]
        [ValidateNever]
        public virtual Employee? ApprovedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(500, ErrorMessage = "Approval notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        public string? ApprovalNotes { get; set; }

        // Request items
        [ValidateNever]
        [Display(Name = "Items")]
        public virtual ICollection<PurchaseRequestItem> Items { get; set; } = new List<PurchaseRequestItem>();

        // Metadata
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public string? UpdatedBy { get; set; } = string.Empty;

        // Computed properties
        [NotMapped]
        [Display(Name = "Total Quantity Requested")]
        public int TotalQuantity => Items?.Sum(i => i.Quantity) ?? 0;

        [NotMapped]
        [Display(Name = "Total Estimated ServiceCost (R)")]
        [DataType(DataType.Currency)]
        public decimal TotalEstimatedCost => Items?.Sum(i => i.EstimatedLineTotal) ?? 0;

        [NotMapped]
        [Display(Name = "Is Urgent")]
        public bool IsUrgent => Urgency == PurchaseRequestUrgency.High ||
                              Urgency == PurchaseRequestUrgency.Critical;

        [NotMapped]
        [Display(Name = "Days Until Due")]
        public int DaysUntilDue => (RequiredByDate - DateTime.UtcNow.Date).Days;

        [NotMapped]
        [Display(Name = "Status Summary")]
        public string StatusSummary
        {
            get
            {
                if (Status == PurchaseRequestStatus.Approved && DaysUntilDue <= 7 && IsUrgent)
                    return "Urgent - Needs immediate attention";
                if (Status == PurchaseRequestStatus.UnderReview && DaysUntilDue <= 14)
                    return "Needs approval soon";
                return Status.ToString();
            }
        }
    }
}
