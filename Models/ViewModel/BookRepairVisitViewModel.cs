using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class BookRepairVisitViewModel
    {
        // For maintenance faults
        public int? VisitId { get; set; }

        // For customer fault reports
        public int? FaultReportId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Fridge Details")]
        public string FridgeDetails { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Original Visit Date")]
        public DateTime OriginalVisitDate { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [Required]
        [Display(Name = "Repair Date")]
        [DataType(DataType.Date)]
        public DateTime RepairDate { get; set; } = DateTime.Now.AddDays(1);

        [Required]
        [Display(Name = "Time Slot")]
        public string TimeSlot { get; set; } = string.Empty;

        [Display(Name = "Additional Notes")]
        public string? AdditionalNotes { get; set; }
    }
}