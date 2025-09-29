using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FaultRecordVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [Required]
        [Display(Name = "Reported By")]
        public string ReportedById { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? UserList { get; set; }

        [Display(Name = "Assigned Technician")]
        public int? AssignedTechnicianId { get; set; }
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [Display(Name = "Maintenance Visit")]
        public int? MaintenanceVisitId { get; set; }
        public IEnumerable<SelectListItem>? VisitList { get; set; }

        [Required]
        [Display(Name = "Fault Location")]
        public int FaultLocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Required]
        [Display(Name = "Fault Description")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string FaultDescription { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Status")]
        public FaultStatus FaultStatus { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        [Required]
        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [Display(Name = "Resolution Notes")]
        [StringLength(1000, ErrorMessage = "Resolution notes cannot exceed 1000 characters.")]
        public string? ResolutionNotes { get; set; }

        [Display(Name = "Parts Replaced")]
        [StringLength(500, ErrorMessage = "Parts replaced cannot exceed 500 characters.")]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Repair Cost (R)")]
        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal? RepairCost { get; set; }
    }
}
