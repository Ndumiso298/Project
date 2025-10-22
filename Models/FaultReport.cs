using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultReport
    {
        [Key]
        public int FaultReportId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int FridgeInStockId { get; set; }

        [Required]
        public string FaultType { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime ReportedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Reported";

        public string Priority { get; set; } = "Medium";

        public string? ImageUrl { get; set; }

        public bool RequestReplacement { get; set; } = false;

        public string? DeclineReason { get; set; }

        public bool IsRelaunched { get; set; } = false;

        public int? OriginalFaultReportId { get; set; }
        public DateTime? ReportDate { get; set; }   
        public DateTime? ResolvedDate { get; set; }

        public string? AdditionalNotes { get; set; }

        // Navigation properties
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("FridgeInStockId")]
        public virtual FridgeInStock? FridgeInStock { get; set; }

        public virtual ICollection<FaultTechnician>? FaultTechnicians { get; set; }
    }
}