using Project.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeReplacement
    {
        [Key]
        public int FridgeReplacementId { get; set; }

        [Required]
        public int VisitId { get; set; }
        [ForeignKey("VisitId")]
        public virtual FridgeVisit? FridgeVisit { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }

        [Required]
        [StringLength(50)]
        public string OldFridgeNo { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string ReasonForReplacement { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? AdditionalNotes { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime ReplacementDate { get; set; }

        [Required]
        [StringLength(20)]
        public string ReplacementStatus { get; set; } = SD.Pending;

        [StringLength(500)]
        public string? DeclineReason { get; set; }

        public string? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        public int? NewFridgeInStockId { get; set; }
        [ForeignKey("NewFridgeInStockId")]
        public virtual FridgeInStock? NewFridgeInStock { get; set; }

        [StringLength(1000)]
        public string? TechnicianNotes { get; set; }
        public DateTime? ActionDate { get; set; }

        [StringLength(100)]
        public string? ActionBy { get; set; }

        [StringLength(100)]
        public string? ApprovedBy { get; set; }

        // Scrapping information
        public bool IsScrapped { get; set; } = false;
        public DateTime? ScrappedDate { get; set; }

        [StringLength(100)]
        public string? ScrappedBy { get; set; }

        [StringLength(500)]
        public string? ScrappingReason { get; set; }

        public int? FaultReportId { get; set; }
        [ForeignKey("FaultReportId")]
        public virtual FaultReport? FaultReport { get; set; }
    }
}