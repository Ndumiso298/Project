using Project.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int FaultId { get; set; }

        public int? VisitId { get; set; }

        [StringLength(100)]
        public string? FaultType { get; set; }

        public string? FaultDescription { get; set; }

        public string? ResolutionNotes { get; set; }

        public DateTime? ReportDate { get; set; }

        [StringLength(50)]
        public string? RepairStatus { get; set; } = SD.NotStarted;

        [StringLength(100)]
        public string? TechnicianAssigned { get; set; }

        [StringLength(20)]
        public string? CustomerBookingStatus { get; set; }

        public DateTime? Bookingate { get; set; }

        // Add these missing properties
        public int? FaultReportId { get; set; }

        [StringLength(20)]
        public string? Priority { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? Completion { get; set; }

        // Navigation properties
        [ForeignKey("VisitId")]
        public virtual FridgeVisit? FridgeVisit { get; set; }

        [ForeignKey("FaultReportId")]
        public virtual FaultReport? FaultReport { get; set; }
    }
}