using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int Id { get; set; }

        // Foreign keys
        [Required(ErrorMessage = "Fridge is required.")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "AssignedTechnician is required.")]
        public int TechnicianId { get; set; }

        public int? MaintenanceVisitId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; }

        [ForeignKey(nameof(TechnicianId))]
        [ValidateNever]
        public virtual Employee Technician { get; set; }

        [ForeignKey(nameof(MaintenanceVisitId))]
        [ValidateNever]
        public virtual MaintenanceVisit MaintenanceVisit { get; set; }

        [Required(ErrorMessage = "Service date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ServiceDate { get; set; } = DateTime.UtcNow;

        [StringLength(2000, ErrorMessage = "Technician notes cannot exceed 2000 characters.")]
        [DataType(DataType.MultilineText)]
        public string? ServiceNotes { get; set; }

        // Audit fields
        public bool IsDeleted { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; } = string.Empty;
    }
}
