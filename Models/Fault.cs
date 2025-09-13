using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;


namespace Project.Models
{
    public class Fault
    {
        [Key]
        public int FaultId { get; set; }
        //public string Description { get; set; }
        public DateTime ReportedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string Notes { get; set; }
        public string Location { get; set; }
        public string Status { get; set; } // Reported, In Progress, Resolved
        public string Severity { get; set; } // Low, Medium, High, Critical
        public int MaintenanceVisitId { get; set; }

        // Foreign keys
        public int FridgeId { get; set; }
        public int? ReportedByCustomerId { get; set; }
        public int? ResolvedByTechnicianId { get; set; }

        // Navigation properties
        public virtual Fridge Fridge { get; set; }
        public virtual Customer ReportedByCustomer { get; set; }
        public virtual FaultTechnician ResolvedByTechnician { get; set; }
        public virtual MaintenanceVisit MaintenanceVisit { get; set; }
    }
}
