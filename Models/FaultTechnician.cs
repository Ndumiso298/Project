using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int TechnicianId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }
        public string Note { get; set; }

        // Navigation properties
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; }
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
        public virtual ICollection<Fault> ResolvedFaults { get; set; }
    }
}
