using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceVisitVM
    {
        public int Id { get; set; }

        // === SCHEDULING INFORMATION ===
        [Required(ErrorMessage = "Scheduled date is required.")]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Visit type is required.")]
        [Display(Name = "Visit Type")]
        public ServicingType VisitType { get; set; } = ServicingType.PreventiveMaintenance;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; } = ServicingStatus.Scheduled;

        // === RELATIONSHIPS ===
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [Display(Name = "Allocation")]
        public int? AllocationId { get; set; }

        [Required(ErrorMessage = "Technician is required.")]
        [Display(Name = "Technician")]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        // === VISIT COMPLETION FIELDS (Optional for creation) ===
        [Display(Name = "Actual Start Time")]
        public DateTime? ActualStartTime { get; set; }

        [Display(Name = "Actual End Time")]
        public DateTime? ActualEndTime { get; set; }

        [Display(Name = "Condition Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Condition rating must be between 1 and 5.")]
        public int? ConditionRating { get; set; }

        [Display(Name = "Temperature Reading (°C)")]
        [Range(-30, 10, ErrorMessage = "Temperature must be between -30°C and 10°C.")]
        public decimal? TemperatureReading { get; set; }

        [Display(Name = "Issues Found")]
        public bool IssuesFound { get; set; }

        [StringLength(1000, ErrorMessage = "Issue description cannot exceed 1000 characters.")]
        [Display(Name = "Issue Description")]
        public string? IssueDescription { get; set; }

        [Display(Name = "Maintenance Performed")]
        public bool MaintenancePerformed { get; set; }

        [StringLength(1000, ErrorMessage = "Maintenance details cannot exceed 1000 characters.")]
        [Display(Name = "Maintenance Details")]
        public string? MaintenanceDetails { get; set; }

        [StringLength(500, ErrorMessage = "Parts replaced cannot exceed 500 characters.")]
        [Display(Name = "Parts Replaced")]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Service Cost (R)")]
        [Range(0, 100000, ErrorMessage = "Service cost must be a positive value.")]
        public decimal? ServiceCost { get; set; }

        [Display(Name = "Follow-up Required")]
        public bool FollowUpRequired { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Follow-up Date")]
        public DateTime? FollowUpDate { get; set; }

        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        // === SERVICE CHECKLIST (Mandatory per requirements) ===
        [Display(Name = "Service Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        [StringLength(1000, ErrorMessage = "Checklist notes cannot exceed 1000 characters.")]
        [Display(Name = "Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        // === DROPDOWN LISTS ===
        [ValidateNever]
        public IEnumerable<SelectListItem> CustomerList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> FridgeList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> TechnicianList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> LocationList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> VisitTypeList { get; set; } = new List<SelectListItem>();

        // === COMPUTED/DISPLAY PROPERTIES ===
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes => ActualStartTime.HasValue && ActualEndTime.HasValue
            ? (int)(ActualEndTime.Value - ActualStartTime.Value).TotalMinutes
            : null;

        [Display(Name = "Customer Information")]
        public string? CustomerInfo { get; set; }

        [Display(Name = "Fridge Information")]
        public string? FridgeInfo { get; set; }

        [Display(Name = "Location Information")]
        public string? LocationInfo { get; set; }
    }
}
