using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class CancelRequestVM
    {
        [Required]
        public int RequestHeaderId { get; set; }

        [Required(ErrorMessage = "Please select a cancellation reason")]
        [Display(Name = "Cancellation Reason")]
        public string CancellationReason { get; set; } = string.Empty;

        [Display(Name = "Additional Details")]
        [StringLength(500, ErrorMessage = "Additional details cannot exceed 500 characters")]
        public string? AdditionalDetails { get; set; }
    }
}