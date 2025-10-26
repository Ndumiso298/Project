using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class RequestNote
    {
        [Key]
        public int RequestNoteId { get; set; }

        [Required]
        [ForeignKey("RequestHeader")]
        public int RequestHeaderId { get; set; }

        [Required]
        [StringLength(50)]
        public string NoteType { get; set; } = "DeclineReason";

        [Required]
        [StringLength(500)]
        public string NoteContent { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // navigation
        public RequestHeader? RequestHeader { get; set; }
    }
}
