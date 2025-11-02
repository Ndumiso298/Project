
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class RelaunchRequestVM
    {
        public int OriginalRequestId { get; set; }
        public string RejectionReason { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OriginalRequestDate { get; set; }
        public DateTime? RejectionDate { get; set; }
        public List<RequestDetails> OriginalFridges { get; set; } = new();

        [Required(ErrorMessage = "Please provide additional information.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string AdditionalDescription { get; set; } = string.Empty;

        [Display(Name = "Supporting Document (PDF, JPG, PNG, DOC, DOCX - Max 5MB)")]
        public IFormFile? AdditionalDocument { get; set; }
    }
}