using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class FridgeReplacementViewModel
    {
        public int VisitId { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Customer Phone")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Old Fridge Number")]
        public string OldFridgeNo { get; set; } = string.Empty;

        [Display(Name = "Fridge Model")]
        public string FridgeModel { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Reason for Replacement")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters")]
        public string ReasonForReplacement { get; set; } = string.Empty;

        [Display(Name = "Additional Notes")]
        [StringLength(1000, ErrorMessage = "Additional notes cannot exceed 1000 characters")]
        public string? AdditionalNotes { get; set; }

        [Display(Name = "Technician Notes")]
        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters")]
        public string? TechnicianNotes { get; set; }

        [Required]
        [Display(Name = "Proposed Replacement Date")]
        [DataType(DataType.Date)]
        public DateTime ReplacementDate { get; set; } = DateTime.Now;

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}