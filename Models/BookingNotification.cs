using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class BookingNotification
    {
        [Key]
        public int NotificationId { get; set; }
        public int FaultTechnicianId { get; set; }
        public DateTime ProposedDate { get; set; }
        public string TechnicianName { get; set; }
        public string Status { get; set; } = "Pending Approval";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ResponseDate { get; set; }
        public string DeclineReason { get; set; }

        // Navigation property
        public virtual FaultTechnician FaultTechnician { get; set; }
    }
}