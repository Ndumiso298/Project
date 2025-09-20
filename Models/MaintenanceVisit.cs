using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class MaintenanceVisit
    {

        [Key]
        public int MaintenanceVisitId { get; set; }
        [Required]
        public DateTime ScheduledDate { get; set; }
        [Required]
        public string Status { get; set; } // Scheduled, In Progress, Completed, Cancelled
        public string TechnicianNotes { get; set; }
        public string CustomerNote { get; set; }
        public string Location { get; set; }

        // Foreign keys
        public int CustomerId { get; set; }
        public int? TechnicianId { get; set; }
        public int?FridgeId { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Employee Technician { get; set; }
        public virtual Fridge Fridge { get; set; }

        [ValidateNever] 
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    }
}
