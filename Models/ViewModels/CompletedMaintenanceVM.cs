using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class CompleteMaintenanceVM
    {
        public int VisitId { get; set; }

        // === DISPLAY INFORMATION ===
        [Display(Name = "Fridge Information")]
        public string FridgeInfo { get; set; } = string.Empty;

        [Display(Name = "Customer Information")]
        public string CustomerInfo { get; set; } = string.Empty;

        // === COMPLETION DETAILS ===
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; }

        [StringLength(2000, ErrorMessage = "Technician notes cannot exceed 2000 characters.")]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        // === SERVICE CHECKLIST (Mandatory per requirements) ===
        [Required(ErrorMessage = "Service checklist must be completed.")]
        [Display(Name = "Service Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        [StringLength(1000, ErrorMessage = "Checklist notes cannot exceed 1000 characters.")]
        [Display(Name = "Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        // === AUDIT FIELDS ===
        [Display(Name = "Completed By")]
        public int? CompletedById { get; set; }

        [Display(Name = "Completed At")]
        public DateTime? CompletedAt { get; set; }
    }
}
