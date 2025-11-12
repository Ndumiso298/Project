using Project.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int FaultId { get; set; }

        public int? VisitId { get; set; }
        [ForeignKey("VisitId")]
        public virtual FridgeVisit? FridgeVisit { get; set; }

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

        public int? FaultReportId { get; set; }
        [ForeignKey("FaultReportId")]
        public virtual FaultReport? FaultReport { get; set; }

        [StringLength(20)]
        public string? Priority { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? Completion { get; set; }

        // Replacement tracking
        public int? ReplacementRequestId { get; set; }
        [ForeignKey("ReplacementRequestId")]
        public virtual FridgeReplacement? ReplacementRequest { get; set; }

        // Scrapping tracking
        public bool IsScrapped { get; set; } = false;
        public DateTime? ScrappedDate { get; set; }
    }
}