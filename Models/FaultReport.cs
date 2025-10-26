using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FaultReport
    {
        [Key]
        public int FaultReportId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Customer { get; set; }

        public int FridgeInStockId { get; set; }
        [ForeignKey("FridgeInStockId")]
        [ValidateNever]
        public FridgeInStock FridgeInStock { get; set; }

        [Required]
        public string FaultType { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Reported";

        public string Priority { get; set; } = "Medium";

        public DateTime ReportedDate { get; set; }

        public string? ImageUrl { get; set; }

        public bool RequestReplacement { get; set; }
        public DateTime ResolvedDate { get; set; }
        
        public string? DeclineReason { get; set; }

        public bool IsRelaunched { get; set; } = false;

        public int? OriginalFaultReportId { get; set; }
        [ForeignKey("OriginalFaultReportId")]
        [ValidateNever]
        public FaultReport? OriginalFaultReport { get; set; }
        public string? ReportedBy { get; set; } // "Customer" or "Maintenance"
        public int? VisitId { get; set; } // Reference to maintenance visit
        public bool IsMaintenanceReported => !string.IsNullOrEmpty(ReportedBy) && ReportedBy == "Maintenance";

        // Navigation property
        public virtual FridgeVisit? FridgeVisit { get; set; }
        
        public ICollection<FaultTechnician> FaultTechnicians { get; set; } = new List<FaultTechnician>();
    }
}