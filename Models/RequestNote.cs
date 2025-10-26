using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class RequestNote
    {
        [Key]
        public int RequestNoteId { get; set; }
        public int RequestHeaderId { get; set; }
        public string NoteType { get; set; } = string.Empty;
        public string? NoteContent { get; set; } // Nullable to avoid non-nullable error
        public DateTime CreatedDate { get; set; }

        public RequestHeader RequestHeader { get; set; }
    }
}