using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int FaultId { get; set; }

        [Required]
        public string FaultDescription { get; set; } = string.Empty;

        public string RepairStatus { get; set; } = "Not Started";

        public string? TechnicianAssigned { get; set; }

        public string? ResolutionNotes { get; set; }

        public DateTime? Bookingate { get; set; }

        public DateTime? Completion { get; set; }

        public string CustomerBookingStatus { get; set; } = "Pending";

        public string Priority { get; set; } = "Medium";

        public int? EstimatedRepairTime { get; set; }

        public int? ActualRepairTime { get; set; }

        public decimal? RepairCost { get; set; }

        // Foreign key for FridgeVisit (maintenance faults)
        public int? VisitId { get; set; }

        [ForeignKey("VisitId")]
        [ValidateNever]
        public virtual FridgeVisit? FridgeVisit { get; set; }

        // Foreign key for FaultReport (customer faults)
        public int? FaultReportId { get; set; }

        [ForeignKey("FaultReportId")]
        [ValidateNever]
        public virtual FaultReport? FaultReport { get; set; }
    }
}