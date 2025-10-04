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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ScheduledDate { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Visit status is required.")]
        [Display(Name = "Visit Status")]
        public ServicingStatus Status { get; set; } = ServicingStatus.Scheduled;

        // === CUSTOMER & LOCATION ===
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer/Spaza Shop")]
        public int CustomerId { get; set; }

        [Display(Name = "Trading Location")]
        public int? TradingLocationId { get; set; }

        // === FRIDGE INFORMATION ===
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge to Service")]
        public int FridgeId { get; set; }

        [Display(Name = "Fridge Allocation")]
        public int? AllocationId { get; set; }

        // === TECHNICIAN ASSIGNMENT ===
        [Required(ErrorMessage = "Maintenance technician is required.")]
        [Display(Name = "Assigned Technician")]
        public int AssignedTechnicianId { get; set; }

        // === VISIT DETAILS ===
        [Display(Name = "Visit Completed Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CompletedDate { get; set; }

        [Display(Name = "Estimated Duration (hours)")]
        [Range(0.5, 8.0, ErrorMessage = "Duration must be between 0.5 and 8 hours.")]
        public decimal? EstimatedDuration { get; set; }

        [Display(Name = "Actual Duration (hours)")]
        [Range(0.5, 8.0, ErrorMessage = "Duration must be between 0.5 and 8 hours.")]
        public decimal? ActualDuration { get; set; }

        // === TECHNICIAN NOTES ===
        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [Display(Name = "Fault Reported During Visit")]
        public bool FaultReported { get; set; }

        [Display(Name = "Fault Report ID")]
        public int? RelatedFaultId { get; set; }

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

        // === COMPUTED/DISPLAY PROPERTIES ===
        [Display(Name = "Customer Information")]
        public string? CustomerInfo { get; set; }

        [Display(Name = "Fridge Information")]
        public string? FridgeInfo { get; set; }

        [Display(Name = "Location Address")]
        public string? LocationInfo { get; set; }

        [Display(Name = "Technician Name")]
        public string? TechnicianInfo { get; set; }
    }
}
