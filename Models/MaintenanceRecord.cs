using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [ValidateNever] 
        public virtual Fridge Fridge { get; set; }
        [ValidateNever] 
        public virtual Employee Technician { get; set; }
        [ValidateNever] 
        public virtual MaintenanceVisit MaintenanceVisit { get; set; }
    }
}
