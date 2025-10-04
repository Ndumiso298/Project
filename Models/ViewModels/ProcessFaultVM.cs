using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class ProcessFaultVM
    {
        public int Id { get; set; }

        [Display(Name = "Fridge")]
        public string FridgeInfo { get; set; } = string.Empty;

        [Display(Name = "Customer")]
        public string CustomerInfo { get; set; } = string.Empty;

        [Display(Name = "Fault Description")]
        public string FaultDescription { get; set; } = string.Empty;

        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        [Required]
        [Display(Name = "Assigned Technician")]
        public int? AssignedTechnicianId { get; set; }
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [Required]
        [Display(Name = "Status")]
        public FaultStatus FaultStatus { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        [Display(Name = "Resolution Notes")]
        public string? ResolutionNotes { get; set; }

        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [Display(Name = "Parts Replaced")]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Repair Cost (R)")]
        [Range(0, 10000)]
        public decimal? RepairCost { get; set; }
    }
}

