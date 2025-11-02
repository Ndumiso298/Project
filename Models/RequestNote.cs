using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class RequestNote
    {
        [Key]
        public int RequestNoteId { get; set; }

        public int RequestHeaderId { get; set; }

        [Required]
        [StringLength(50)]
        public string NoteType { get; set; } = string.Empty;

        [Required]
        public string NoteContent { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RequestHeaderId")]
        public virtual RequestHeader? RequestHeader { get; set; }
    }
}