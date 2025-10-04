using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceRecordVM
    {
        public int Id { get; set; }

        // === CORE MAINTENANCE INFORMATION ===
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge Serial Number")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "Maintenance technician is required.")]
        [Display(Name = "Service Technician")]
        public int TechnicianId { get; set; }

        [Display(Name = "Related Maintenance Visit")]
        public int? MaintenanceVisitId { get; set; }

        [Required(ErrorMessage = "Service date is required.")]
        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ServiceDate { get; set; } = DateTime.Today;

        // === SERVICE CHECKLIST (Mandatory per requirements) ===
        [Display(Name = "Service Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        // === TECHNICAL CHECKS ===
        [Display(Name = "Condition Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Condition rating must be between 1 and 5.")]
        public int? ConditionRating { get; set; }

        [Display(Name = "Temperature Reading (°C)")]
        [Range(-30, 10, ErrorMessage = "Temperature must be between -30°C and 10°C.")]
        public decimal? TemperatureReading { get; set; }

        [Display(Name = "Compressor Working")]
        public bool? CompressorWorking { get; set; }

        [Display(Name = "Condenser Clean")]
        public bool? CondenserClean { get; set; }

        [Display(Name = "Door Seal Intact")]
        public bool? DoorSealIntact { get; set; }

        // === SERVICE DETAILS ===
        [StringLength(2000, ErrorMessage = "Service notes cannot exceed 2000 characters.")]
        [Display(Name = "Service Notes & Observations")]
        public string? ServiceNotes { get; set; }

        [StringLength(1000, ErrorMessage = "Checklist notes cannot exceed 1000 characters.")]
        [Display(Name = "Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        [Display(Name = "Follow-up Required")]
        public bool FollowUpRequired { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Follow-up Date")]
        public DateTime? FollowUpDate { get; set; }

        // === DROPDOWN LISTS ===
        [ValidateNever]
        public IEnumerable<SelectListItem> FridgeList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> TechnicianList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> VisitList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> ServiceTypeList { get; set; } = new List<SelectListItem>();
    }
}
