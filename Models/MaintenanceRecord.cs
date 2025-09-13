using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int MaintenanceRecordId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceType { get; set; } // Routine, Repair, Emergency
        public string Description { get; set; }
        public string TechnicianNotes { get; set; }
        public decimal Cost { get; set; }

        // Foreign keys
        public int FridgeId { get; set; }
        public int TechnicianId { get; set; }
        public int? MaintenanceVisitId { get; set; }

        // Navigation properties
        public virtual Fridge Fridge { get; set; }
        public virtual FaultTechnician Technician { get; set; }
        public virtual MaintenanceVisit MaintenanceVisit { get; set; }
    }
}
