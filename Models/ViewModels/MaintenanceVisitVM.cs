using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceVisitVM
    {
        public int Id { get; set; }

        [Display(Name = "Allocation")]
        public int? AllocationId { get; set; }

        [Required]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [Required]
        [Display(Name = "Technician")]
        public int TechnicianId { get; set; }
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [Required]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Actual Date")]
        public DateTime? ActualDate { get; set; }

        [Display(Name = "Location")]
        public int? LocationId { get; set; }   // relational FK

        [Display(Name = "Location")]
        public string? LocationDisplay { get; set; }  // read-only for showing address/name
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Required]
        [Display(Name = "Visit Type")]
        public ServicingType VisitType { get; set; }
        public IEnumerable<SelectListItem>? VisitTypeList { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [Display(Name = "Parts Used")]
        public string? PartsUsed { get; set; }

        [Display(Name = "Service ServiceCost")]
        [Range(0, 10000)]
        public decimal? ServiceCost { get; set; }
    }
}
