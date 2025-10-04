using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class CompleteMaintenanceVM
    {
        public int VisitId { get; set; }
        public string FridgeInfo { get; set; } = string.Empty;
        public string CustomerInfo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Actual Date")]
        public DateTime ActualDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; }

        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [Display(Name = "Parts Used")]
        public string? PartsUsed { get; set; }

        [Display(Name = "Service ServiceCost")]
        [Range(0, 10000)]
        public decimal? ServiceCost { get; set; }
    }
}
