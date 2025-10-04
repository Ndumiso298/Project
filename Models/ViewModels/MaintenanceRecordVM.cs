using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceRecordVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [Required]
        [Display(Name = "Technician")]
        public int TechnicianId { get; set; }
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [Display(Name = "Service Type")]
        public IEnumerable<SelectListItem>? ServiceTypeList { get; set; }

        [Display(Name = "Maintenance Visit")]
        public int? MaintenanceVisitId { get; set; }
        public IEnumerable<SelectListItem>? VisitList { get; set; }


        [Required]
        [Display(Name = "Service Date")]
        public DateTime ServiceDate { get; set; } // Changed from MaintenanceDate to match entity

        [Required(ErrorMessage = "Service type is required.")]
        [Display(Name = "Service Type")]
        public ServicingType ServiceType { get; set; } = ServicingType.PreventiveMaintenance;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty; // Changed from ServiceNotes to match entity

        [StringLength(2000, ErrorMessage = "Service notes cannot exceed 2000 characters.")]
        [Display(Name = "Service Notes")]
        public string? ServiceNotes { get; set; }

        [Required(ErrorMessage = "ServiceCost is required.")]
        [Range(0, 100000, ErrorMessage = "ServiceCost must be a positive value.")]
        [Display(Name = "ServiceCost (R)")]
        public decimal ServiceCost { get; set; } // Changed from ServiceCost to match entity and made non-nullable

        [Display(Name = "Parts Used/Replaced")]
        [StringLength(1000, ErrorMessage = "Parts information cannot exceed 1000 characters.")]
        public string? PartsUsed { get; set; } // Changed from PartsReplaced to match entity

        // Service checklist (mandatory per requirements)
        [Display(Name = "Service Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        [StringLength(1000)]
        [Display(Name = "Service Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        [Display(Name = "Next Service Due")]
        public DateTime? NextServiceDue { get; set; }

        [Display(Name = "Work Hours")]
        [Range(0, 24)]
        public decimal? WorkHours { get; set; }

        // Additional properties from entity
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Warranty Claim")]
        public bool IsWarrantyClaim { get; set; } = false;

        [Display(Name = "Warranty Reference")]
        [StringLength(100, ErrorMessage = "Warranty reference cannot exceed 100 characters.")]
        public string? WarrantyReference { get; set; }

        // Computed properties (read-only for display)
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes { get; set; }

        [Display(Name = "Is Emergency Service")]
        public bool IsEmergency { get; set; }

        [Display(Name = "Service Complexity")]
        public string ServiceComplexity { get; set; } = string.Empty;
    }
}
