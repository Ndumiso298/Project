using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class RebookingNotification
    {
        [Key]
        public int RebookingId { get; set; }
        public int FaultTechnicianId { get; set; }
        public DateTime OriginalDate { get; set; }
        public string DeclineReason { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending Reschedule";

        // Navigation property
        public virtual FaultTechnician FaultTechnician { get; set; }
    }
}