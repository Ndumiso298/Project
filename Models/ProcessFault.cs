using Project.Models;
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class ProcessFault
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FaultId { get; set; }
        public string Status { get; set; }
        public int TechnicianId { get; set; }
        public DateTime? ScheduleFault { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string Notes { get; set; }
        public string PriorityLevel { get; set; } // Low, High, Medium
        public bool IsConfirmed { get; set; }


        public Fault Fault { get; set; } // Navigation property
    }


    }

