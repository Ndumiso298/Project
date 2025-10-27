using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int FaultId { get; set; }
        public int? VisitId { get; set; }
        public int? FaultReportId { get; set; }
        public string? TechnicianAssigned { get; set; }
        public DateTime? Bookingate { get; set; }
        public string? RepairStatus { get; set; } = "Pending";
        public string? CustomerBookingStatus { get; set; }
        public string? ResolutionNotes { get; set; }
        public string? DeclineReason { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public DateTime? Completion { get; set; }

        // Add missing properties
        public string? Priority { get; set; } = "Medium";
        public int? EstimatedRepairTime { get; set; } // in hours
        public int? ActualRepairTime { get; set; } // in hours
        public decimal? RepairCost { get; set; }
        public string? FaultDescription { get; set; }

        // Navigation properties
        public virtual FridgeVisit? FridgeVisit { get; set; }
        public virtual FaultReport? FaultReport { get; set; }
        public virtual ICollection<BookingNotification>? BookingNotifications { get; set; }
        public virtual ICollection<CustomerFeedback>? CustomerFeedbacks { get; set; }
    }
}