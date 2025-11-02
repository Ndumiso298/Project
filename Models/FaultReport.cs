using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultReport
    {
        [Key]
        public int FaultReportId { get; set; }

        public int? CustomerId { get; set; }

        public int? FridgeInStockId { get; set; }

        [Required]
        [StringLength(100)]
        public string FaultType { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Priority { get; set; } = "Medium";

        [StringLength(50)]
        public string? Status { get; set; } = "Reported";

        public DateTime ReportedDate { get; set; } = DateTime.Now;

        public string? ImageUrl { get; set; }

        public bool RequestReplacement { get; set; }

        // Add these missing properties
        public bool IsReplacementRequested { get; set; }

        public string? DeclineReason { get; set; }

        public bool IsRelaunched { get; set; }

        public int? OriginalFaultReportId { get; set; }

        // Navigation properties
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("FridgeInStockId")]
        public virtual FridgeInStock? FridgeInStock { get; set; }

        public virtual ICollection<FaultTechnician>? FaultTechnicians { get; set; }
    }
}