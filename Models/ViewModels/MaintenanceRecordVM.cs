using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceRecordVM
    {
        public int Id { get; set; }

        // === FORM FIELDS ===
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "Technician is required.")]
        [Display(Name = "Technician")]
        public int TechnicianId { get; set; }

        [Display(Name = "Maintenance Visit")]
        public int? MaintenanceVisitId { get; set; }

        [Required(ErrorMessage = "Service date is required.")]
        [Display(Name = "Service Date")]
        public DateTime? ServiceDate { get; set; }

        [Required(ErrorMessage = "Service type is required.")]
        [Display(Name = "Service Type")]
        public ServicingType ServiceType { get; set; } = ServicingType.PreventiveMaintenance;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Service notes cannot exceed 2000 characters.")]
        [Display(Name = "Service Notes")]
        public string? ServiceNotes { get; set; }

        [Required(ErrorMessage = "Service cost is required.")]
        [Range(0, 100000, ErrorMessage = "Service cost must be a positive value.")]
        [Display(Name = "Service Cost (R)")]
        public decimal? Cost { get; set; }

        [StringLength(1000, ErrorMessage = "Parts used cannot exceed 1000 characters.")]
        [Display(Name = "Parts Used/Replaced")]
        public string? PartsUsed { get; set; }

        // === TIMING INFORMATION ===
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        // === WARRANTY INFORMATION ===
        [Display(Name = "Warranty Claim")]
        public bool IsWarrantyClaim { get; set; } = false;

        [Display(Name = "Warranty Reference")]
        [StringLength(100, ErrorMessage = "Warranty reference cannot exceed 100 characters.")]
        public string? WarrantyReference { get; set; }

        // === DROPDOWN LISTS ===
        [ValidateNever]
        public IEnumerable<SelectListItem> FridgeList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> TechnicianList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> ServiceTypeList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> VisitList { get; set; } = new List<SelectListItem>();

        // === COMPUTED PROPERTIES (Read-only for display) ===
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes => StartTime.HasValue && EndTime.HasValue
            ? (int)(EndTime.Value - StartTime.Value).TotalMinutes
            : null;

        [Display(Name = "Is Emergency Service")]
        public bool IsEmergency => ServiceType == ServicingType.CorrectiveMaintenance;

        [Display(Name = "Service Complexity")]
        public string ServiceComplexity => Cost > 5000 ? "High" : Cost > 1000 ? "Medium" : "Low";
    }
}
