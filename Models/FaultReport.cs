using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FaultReport
    {
        [Key]
        public int FaultReportId { get; set; }
        public int CustomerId { get; set; }
        public int FridgeInStockId { get; set; }
        public string Description { get; set; } = "";
        public string FaultType { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public string Priority { get; set; } = "Medium";
        public DateTime ReportedDate { get; set; } = DateTime.Now;
        public DateTime? ResolvedDate { get; set; }

        // Add missing properties
        public bool RequestReplacement { get; set; }
        public bool IsReplacementRequested { get; set; }
        public string? DeclineReason { get; set; }
        public bool IsRelaunched { get; set; }
        public int? OriginalFaultReportId { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; } = new Customer();
        public virtual FridgeInStock FridgeInStock { get; set; } = new FridgeInStock();
        public virtual ICollection<FaultImage> FaultImages { get; set; } = new List<FaultImage>();
        public virtual ICollection<FaultTechnician> FaultTechnicians { get; set; } = new List<FaultTechnician>();
        public virtual FaultReport? OriginalFaultReport { get; set; }
        public virtual ICollection<FaultReport> RelaunchedFaultReports { get; set; } = new List<FaultReport>();
    }
}