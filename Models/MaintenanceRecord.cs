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
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "AssignedTechnician is required.")]
        [Display(Name = "AssignedTechnician")]
        public int TechnicianId { get; set; }

        [Display(Name = "Maintenance Visit")]
        public int? MaintenanceVisitId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        [Display(Name = "Fridge")]
        public virtual Fridge Fridge { get; set; }

        [ForeignKey(nameof(TechnicianId))]
        [ValidateNever]
        [Display(Name = "AssignedTechnician")]
        public virtual Employee Technician { get; set; }

        [ForeignKey(nameof(MaintenanceVisitId))]
        [ValidateNever]
        [Display(Name = "Maintenance Visit")]
        public virtual MaintenanceVisit MaintenanceVisit { get; set; }

        [Required(ErrorMessage = "Service date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Service Date")]
        public DateTime? ServiceDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Service type is required.")]
        [StringLength(20, ErrorMessage = "Service type cannot exceed 20 characters.")]
        [Display(Name = "Service Type")]
        public ServicingType ServiceType { get; set; } = ServicingType.PreventiveMaintenance; // Routine, Repair, Emergency

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(2000, ErrorMessage = "AssignedTechnician notes cannot exceed 2000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "AssignedTechnician Notes")]
        public string? ServiceNotes { get; set; }

        // Additional properties for better tracking
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Service Cost is required.")]
        [Range(0, 100000, ErrorMessage = "Service Cost must be a positive value.")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Service Cost (R)")]
        public decimal? Cost { get; set; }

        [NotMapped]
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes =>
            (StartTime.HasValue && EndTime.HasValue)
                ? (int)(EndTime.Value - StartTime.Value).TotalMinutes
                : null;

        [Display(Name = "Parts Used/Replaced")]
        [StringLength(1000, ErrorMessage = "Parts information cannot exceed 1000 characters.")]
        public string? PartsUsed { get; set; }

        [Display(Name = "Warranty Claim")]
        public bool IsWarrantyClaim { get; set; } = false;

        [Display(Name = "Warranty Reference")]
        [StringLength(100, ErrorMessage = "Warranty reference cannot exceed 100 characters.")]
        public string? WarrantyReference { get; set; }

        // Audit fields
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Modified")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Computed properties
        [NotMapped]
        [Display(Name = "Is Emergency Service")]
        public bool IsEmergency => ServiceType == ServicingType.CorrectiveMaintenance;

        [NotMapped]
        [Display(Name = "Service Complexity")]
        public string ServiceComplexity
        {
            get
            {
                if (Cost > 5000) return "High";
                if (Cost > 1000) return "Medium";
                return "Low";
            }
        }
    }
}
