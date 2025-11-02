using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class RelaunchRequestVM
    {
        public int OriginalRequestId { get; set; }

        [Required]
        [Display(Name = "Additional Description")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string AdditionalDescription { get; set; }

        [Display(Name = "Additional Supporting Document")]
        public IFormFile? AdditionalDocument { get; set; }

        // Display only properties
        public string RejectionReason { get; set; }
        public string CustomerName { get; set; }
        public DateTime OriginalRequestDate { get; set; }
        public DateTime? RejectionDate { get; set; }
        public List<RequestDetails> OriginalFridges { get; set; } = new List<RequestDetails>();

        public string? AdditionalDocumentPath { get; set; }
    }
}
