using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FaultComment
    {
        [Key]
        public int FaultCommentId { get; set; }

        [Required]
        public int FaultReportId { get; set; }

        [ForeignKey("FaultReportId")]
        [ValidateNever]
        public virtual FaultReport FaultReport { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public string CommentBy { get; set; } = string.Empty; // "Customer" or "Technician"

        [Required]
        public string UserId { get; set; } = string.Empty;

        public string? UserName { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;

        public bool IsInternalNote { get; set; } = false;
    }
}