using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class CustomerFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int FaultTechnicianId { get; set; }
        public string FeedbackMessage { get; set; }
        public DateTime SentDate { get; set; } = DateTime.Now;
        public string SentBy { get; set; }
        public bool IsRead { get; set; }

        // Navigation property
        public virtual FaultTechnician FaultTechnician { get; set; }
    }
}