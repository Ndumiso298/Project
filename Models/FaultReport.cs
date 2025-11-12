using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FaultReport
    {
        [Key]
        public int FaultReportId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [ValidateNever]
        public virtual Customer? Customer { get; set; }

        public int? FridgeInStockId { get; set; }

        [ForeignKey("FridgeInStockId")]
        [ValidateNever]
        public virtual FridgeInStock? FridgeInStock { get; set; }

        [Required]
        [StringLength(100)]
        public string? FaultType { get; set; }

        [Required]
        public string? Description { get; set; }

        [StringLength(20)]
        public string? Priority { get; set; } = "Medium";

        public bool RequestReplacement { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; } = "Reported";

        public DateTime ReportedDate { get; set; } = DateTime.Now;

        public string? ImageUrl { get; set; }

        // Add TechnicianNotes property
        public string? TechnicianNotes { get; set; }

        public bool IsReplacementRequested { get; set; }

        [StringLength(500)]
        public string? DeclineReason { get; set; }

        public bool IsRelaunched { get; set; }

        public int? OriginalFaultReportId { get; set; }
    }
}